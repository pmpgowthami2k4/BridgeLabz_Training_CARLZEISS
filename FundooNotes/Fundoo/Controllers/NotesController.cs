//using BusinessLayer.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using ModelLayer.DTOs;
//using Microsoft.AspNetCore.Authorization;
//namespace FundooDapper.Controllers
//{
//    //[Authorize]
//    [Route("[controller]")]
//    [ApiController]
//    public class NotesController : ControllerBase
//    {
//        private readonly INoteBL _noteBL;

//        public NotesController(INoteBL noteBL)
//        {
//            _noteBL = noteBL;
//        }

//        private int GetUserId()
//        {
//            //return int.Parse(User.FindFirst("UserId").Value);
//            return 1; //temp
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateNoteDto dto)
//        {
//            //var userId = GetUserId();
//            var userId = User.FindFirst("UserId")?.Value;
//            var result = await _noteBL.CreateNote(dto, userId);
//            return Ok(result);
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var userId = GetUserId();
//            var notes = await _noteBL.GetNotes(userId);
//            return Ok(notes);
//        }

//        [HttpDelete("{noteId}")]
//        public async Task<IActionResult> MoveToTrash(int noteId)
//        {
//            var userId = GetUserId();
//            var result = await _noteBL.MoveToTrash(noteId, userId);
//            return Ok(result);
//        }

//        [HttpGet("trash")]
//        public async Task<IActionResult> GetTrash()
//        {
//            var userId = GetUserId();
//            var result = await _noteBL.GetTrashNotes(userId);
//            return Ok(result);
//        }

//        [HttpPatch("{noteId}/restore")]
//        public async Task<IActionResult> Restore(int noteId)
//        {
//            var userId = GetUserId();
//            var result = await _noteBL.RestoreNote(noteId, userId);
//            return Ok(result);
//        }

//        [HttpDelete("{noteId}/permanent")]
//        public async Task<IActionResult> DeletePermanent(int noteId)
//        {
//            var userId = GetUserId();
//            var result = await _noteBL.DeletePermanently(noteId, userId);
//            return Ok(result);
//        }

//        [HttpGet("{noteId}")]
//        public async Task<IActionResult> GetById(int noteId)
//        {
//            //var userId = int.Parse(User.FindFirst("UserId").Value);
//            int userId = 1; // TEMP

//            var note = await _noteBL.GetNoteById(noteId, userId);
//            return Ok(note);
//        }

//        [HttpPut("{noteId}")]
//        public async Task<IActionResult> Update(int noteId, UpdateNoteDto dto)
//        {
//            int userId = 1; // TEMP

//            var result = await _noteBL.UpdateNote(noteId, userId, dto);

//            if (!result)
//                return NotFound("Note not found");

//            return Ok("Note updated successfully");
//        }


//        //archive
//        [HttpPatch("{noteId}/archive")]
//        public async Task<IActionResult> Archive(int noteId)
//        {
//            int userId = 1;
//            var result = await _noteBL.ArchiveNote(noteId, userId);
//            return Ok(result);
//        }


//        //unarchive
//        [HttpPatch("{noteId}/unarchive")]
//        public async Task<IActionResult> Unarchive(int noteId)
//        {
//            int userId = 1;
//            var result = await _noteBL.UnarchiveNote(noteId, userId);
//            return Ok(result);
//        }

//        //GET archived notes
//        [HttpGet("archived")]
//        public async Task<IActionResult> GetArchived()
//        {
//            int userId = 1;
//            var result = await _noteBL.GetArchivedNotes(userId);
//            return Ok(result);
//        }

//        //PIN
//        [HttpPatch("{noteId}/pin")]
//        public async Task<IActionResult> Pin(int noteId)
//        {
//            int userId = 1;
//            var result = await _noteBL.PinNote(noteId, userId);
//            return Ok(result);
//        }

//        //UNPIN
//        [HttpPatch("{noteId}/unpin")]
//        public async Task<IActionResult> Unpin(int noteId)
//        {
//            int userId = 1;
//            var result = await _noteBL.UnpinNote(noteId, userId);
//            return Ok(result);
//        }

//        //color
//        [HttpPatch("{noteId}/color")]
//        public async Task<IActionResult> ChangeColor(int noteId, UpdateColorDto dto)
//        {
//            int userId = 1;
//            var result = await _noteBL.ChangeColor(noteId, userId, dto.Colour);
//            return Ok(result);
//        }
//    }

//}

//===================================================================================================

using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace FundooDapper.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteBL _noteBL;

        public NotesController(INoteBL noteBL)
        {
            _noteBL = noteBL;
        }

        // ✅ GET USER ID FROM JWT
        private string GetUserId()
        {
            return User.FindFirst("UserId")?.Value;
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create(CreateNoteDto dto)
        {
            var userId = GetUserId();
            var result = await _noteBL.CreateNote(dto, userId);
            return Ok(result);
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserId();
            var notes = await _noteBL.GetNotes(userId);
            return Ok(notes);
        }

        // MOVE TO TRASH
        [HttpDelete("{noteId}")]
        public async Task<IActionResult> MoveToTrash(string noteId)
        {
            var userId = GetUserId();
            var result = await _noteBL.MoveToTrash(noteId, userId);
            return Ok(result);
        }

        // GET TRASH
        [HttpGet("trash")]
        public async Task<IActionResult> GetTrash()
        {
            var userId = GetUserId();
            var result = await _noteBL.GetTrashNotes(userId);
            return Ok(result);
        }

        // RESTORE
        [HttpPatch("{noteId}/restore")]
        public async Task<IActionResult> Restore(string noteId)
        {
            var userId = GetUserId();
            var result = await _noteBL.RestoreNote(noteId, userId);
            return Ok(result);
        }

        // DELETE PERMANENT
        [HttpDelete("{noteId}/permanent")]
        public async Task<IActionResult> DeletePermanent(string noteId)
        {
            var userId = GetUserId();
            var result = await _noteBL.DeletePermanently(noteId, userId);
            return Ok(result);
        }

        // GET BY ID
        [HttpGet("{noteId}")]
        public async Task<IActionResult> GetById(string noteId)
        {
            var userId = GetUserId();
            var note = await _noteBL.GetNoteById(noteId, userId);
            return Ok(note);
        }

        // UPDATE
        [HttpPut("{noteId}")]
        public async Task<IActionResult> Update(string noteId, UpdateNoteDto dto)
        {
            var userId = GetUserId();

            var result = await _noteBL.UpdateNote(noteId, userId, dto);

            if (!result)
                return NotFound("Note not found");

            return Ok("Note updated successfully");
        }

        // ARCHIVE
        [HttpPatch("{noteId}/archive")]
        public async Task<IActionResult> Archive(string noteId)
        {
            var userId = GetUserId();
            var result = await _noteBL.ArchiveNote(noteId, userId);
            return Ok(result);
        }

        // UNARCHIVE
        [HttpPatch("{noteId}/unarchive")]
        public async Task<IActionResult> Unarchive(string noteId)
        {
            var userId = GetUserId();
            var result = await _noteBL.UnarchiveNote(noteId, userId);
            return Ok(result);
        }

        // GET ARCHIVED
        [HttpGet("archived")]
        public async Task<IActionResult> GetArchived()
        {
            var userId = GetUserId();
            var result = await _noteBL.GetArchivedNotes(userId);
            return Ok(result);
        }

        // PIN
        [HttpPatch("{noteId}/pin")]
        public async Task<IActionResult> Pin(string noteId)
        {
            var userId = GetUserId();
            var result = await _noteBL.PinNote(noteId, userId);
            return Ok(result);
        }

        // UNPIN
        [HttpPatch("{noteId}/unpin")]
        public async Task<IActionResult> Unpin(string noteId)
        {
            var userId = GetUserId();
            var result = await _noteBL.UnpinNote(noteId, userId);
            return Ok(result);
        }

        // CHANGE COLOR
        [HttpPatch("{noteId}/color")]
        public async Task<IActionResult> ChangeColor(string noteId, UpdateColorDto dto)
        {
            var userId = GetUserId();
            var result = await _noteBL.ChangeColor(noteId, userId, dto.Colour);
            return Ok(result);
        }

        //SET REMINDER
        [HttpPatch("{noteId}/reminder")]
        public async Task<IActionResult> SetReminder(string noteId, DateTime reminder)
        {
            var userId = User.FindFirst("UserId")?.Value;

            var result = await _noteBL.SetReminder(noteId, userId, reminder);

            return Ok(result);
        }

        //REMOVE REMINDER
        [HttpDelete("{noteId}/reminder")]
        public async Task<IActionResult> RemoveReminder(string noteId)
        {
            var userId = User.FindFirst("UserId")?.Value;

            var result = await _noteBL.RemoveReminder(noteId, userId);

            return Ok(result);
        }

        //GET REMINDERS
        [HttpGet("reminders")]
        public async Task<IActionResult> GetReminders()
        {
            var userId = User.FindFirst("UserId")?.Value;

            var result = await _noteBL.GetReminderNotes(userId);

            return Ok(result);
        }


    }

}