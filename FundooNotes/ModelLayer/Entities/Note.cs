//using System;

//namespace ModelLayer.Entities
//{

//    public class Note
//    {
//        public int NotesId { get; set; }

//        public string Title { get; set; }

//        public string Description { get; set; }

//        public DateTime? Reminder { get; set; }

//        public string Colour { get; set; } = "#FFFFFF";

//        public string Image { get; set; }

//        public bool IsArchive { get; set; } = false;

//        public bool IsPin { get; set; } = false;

//        //public bool IsTrash { get; set; } = false;
//        public bool IsTrash { get; set; } = false;

//        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

//        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

//        public int UserId { get; set; }
//    }

//}

//===================================================================================================
//M0NGO SETUP
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Note
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string NotesId { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public string UserId { get; set; }   // 🔥 string now

    public List<string> Labels { get; set; } = new List<string>();

    public bool IsArchive { get; set; }
    public bool IsPin { get; set; }
    public bool IsTrash { get; set; }
    public string Colour { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? Reminder { get; set; }
    public List<string> Collaborators { get; set; } = new();
}