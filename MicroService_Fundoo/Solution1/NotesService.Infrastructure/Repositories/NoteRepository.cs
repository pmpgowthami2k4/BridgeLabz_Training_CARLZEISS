using MongoDB.Driver;
using NotesService.Domain.Entities;
using NotesService.Infrastructure.Data;
using NotesService.Infrastructure.Cache;
using NotesService.Application.Interfaces;

namespace NotesService.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository 
    {
        private readonly IMongoCollection<Note> _notes;
        private readonly IRedisCacheService _cache;

        public NoteRepository(MongoDbContext context, IRedisCacheService cache)
        {
            _notes = context.Database.GetCollection<Note>("Notes");
            _cache = cache;
        }

        // CREATE NOTE
        public async Task<string> AddAsync(Note note)
        {
            await _notes.InsertOneAsync(note);

            // Remove cache for this user
            await _cache.RemoveAsync($"notes_user_{note.UserId}");
            Console.WriteLine("🗑 Cache Removed after Create");
            return note.Id;
        }

        // GET NOTES BY USER
        public async Task<List<Note>> GetByUserIdAsync(string userId)
        {
            string cacheKey = $"notes_user_{userId}";

            // Check Redis first
            var cachedNotes = await _cache.GetAsync<List<Note>>(cacheKey);

            if (cachedNotes != null)
            {
                Console.WriteLine("Data from Redis");
                return cachedNotes;
            }

            // MongoDB fetch
            Console.WriteLine("Data from DB");

            var notes = await _notes
                .Find(n => n.UserId == userId)
                .ToListAsync();

            // Save to Redis
            await _cache.SetAsync(cacheKey, notes, TimeSpan.FromMinutes(10));

            return notes;
        }

        // UPDATE NOTE
        public async Task<bool> UpdateAsync(string id, string userId, string title, string content)
        {
            var update = Builders<Note>.Update
                .Set(n => n.Title, title)
                .Set(n => n.Content, content);

            var result = await _notes.UpdateOneAsync(
                n => n.Id == id && n.UserId == userId,
                update);

            // Clear cache
            await _cache.RemoveAsync($"notes_user_{userId}");
            Console.WriteLine("Cache Removed after Update");
            return result.ModifiedCount > 0;
        }

        // DELETE NOTE
        public async Task<bool> DeleteAsync(string id, string userId)
        {
            var result = await _notes.DeleteOneAsync(
                n => n.Id == id && n.UserId == userId);

            // Clear cache
            await _cache.RemoveAsync($"notes_user_{userId}");
            Console.WriteLine("Cache Removed after Delete");
            return result.DeletedCount > 0;
        }
    }
}