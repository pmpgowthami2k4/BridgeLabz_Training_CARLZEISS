//using BusinessLayer.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using ModelLayer.DTOs;

//namespace FundooDapper.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class LabelsController : ControllerBase
//    {
//        private readonly ILabelBL _labelBL;
//        private readonly INoteBL _noteBL;

//        // Constructor Injection 
//        public LabelsController(ILabelBL labelBL, INoteBL noteBL)
//        {
//            _labelBL = labelBL;
//            _noteBL = noteBL;
//        }

//        // CREATE LABEL
//        [HttpPost]
//        public async Task<IActionResult> Create(CreateLabelDto dto)
//        {
//            int userId = 1; // TODO: replace with JWT/user context later
//            var id = await _labelBL.CreateLabel(dto.Name, userId);
//            return Ok(id);
//        }

//        // GET ALL LABELS
//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            int userId = 1;
//            var labels = await _labelBL.GetLabels(userId);
//            return Ok(labels);
//        }

//        // UPDATE LABEL
//        [HttpPut("{labelId}")]
//        public async Task<IActionResult> Update(int labelId, UpdateLabelDto dto)
//        {
//            int userId = 1;
//            var result = await _labelBL.UpdateLabel(labelId, userId, dto.Name);
//            return Ok(result);
//        }

//        // DELETE LABEL
//        [HttpDelete("{labelId}")]
//        public async Task<IActionResult> Delete(int labelId)
//        {
//            int userId = 1;
//            var result = await _labelBL.DeleteLabel(labelId, userId);
//            return Ok(result);
//        }

//        // ADD LABEL TO NOTE
//        [HttpPost("{noteId}/label/{labelId}")]
//        public async Task<IActionResult> AddLabel(int noteId, int labelId)
//        {
//            var result = await _noteBL.AddLabelToNote(noteId, labelId);
//            return Ok(result);
//        }


//        // REMOVE LABEL FROM NOTE
//        [HttpDelete("{noteId}/label/{labelId}")]
//        public async Task<IActionResult> RemoveLabel(int noteId, int labelId)
//        {
//            var result = await _noteBL.RemoveLabelFromNote(noteId, labelId);
//            return Ok(result);
//        }

//        // GET NOTES BY LABEL
//        [HttpGet("label/{labelId}/notes")]
//        public async Task<IActionResult> GetNotesByLabel(int labelId)
//        {
//            var result = await _noteBL.GetNotesByLabel(labelId);
//            return Ok(result);
//        }
//    }
//}

//===================================================================================================
// MONGO SETUP
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTOs;

namespace FundooDapper.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        private readonly ILabelBL _labelBL;
        private readonly INoteBL _noteBL;

        public LabelsController(ILabelBL labelBL, INoteBL noteBL)
        {
            _labelBL = labelBL;
            _noteBL = noteBL;
        }

        // ✅ GET USER ID FROM JWT
        private string GetUserId()
        {
            return User.FindFirst("UserId")?.Value;
        }

        // CREATE LABEL
        [HttpPost]
        public async Task<IActionResult> Create(CreateLabelDto dto)
        {
            var userId = GetUserId();
            var id = await _labelBL.CreateLabel(dto.Name, userId);
            return Ok(id);
        }

        // GET ALL LABELS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserId();
            var labels = await _labelBL.GetLabels(userId);
            return Ok(labels);
        }

        // UPDATE LABEL
        [HttpPut("{labelName}")]
        public async Task<IActionResult> Update(string labelName, UpdateLabelDto dto)
        {
            var userId = GetUserId();
            var result = await _labelBL.UpdateLabel(labelName, userId, dto.Name);
            return Ok(result);
        }

        // DELETE LABEL
        [HttpDelete("{labelName}")]
        public async Task<IActionResult> Delete(string labelName)
        {
            var userId = GetUserId();
            var result = await _labelBL.DeleteLabel(labelName, userId);
            return Ok(result);
        }

        // 🔥 ADD LABEL TO NOTE
        [HttpPost("{noteId}/label/{labelName}")]
        public async Task<IActionResult> AddLabel(string noteId, string labelName)
        {
            var result = await _noteBL.AddLabelToNote(noteId, labelName);
            return Ok(result);
        }

        // 🔥 REMOVE LABEL FROM NOTE
        [HttpDelete("{noteId}/label/{labelName}")]
        public async Task<IActionResult> RemoveLabel(string noteId, string labelName)
        {
            var result = await _noteBL.RemoveLabelFromNote(noteId, labelName);
            return Ok(result);
        }

        // 🔥 GET NOTES BY LABEL
        [HttpGet("label/{labelName}/notes")]
        public async Task<IActionResult> GetNotesByLabel(string labelName)
        {
            var result = await _noteBL.GetNotesByLabel(labelName);
            return Ok(result);
        }
    }
}