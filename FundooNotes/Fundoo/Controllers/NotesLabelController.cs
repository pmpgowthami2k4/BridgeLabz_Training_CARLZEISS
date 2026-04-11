using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Fundoo.Controllers
{
    [ApiController]
    [Route("notelabel")]
    public class NotesLabelController : ControllerBase
    {
        private readonly INotesLabelBL bl;

        public NotesLabelController(INotesLabelBL bl)
        {
            this.bl = bl;
        }

        [HttpPost]
        public IActionResult Add(AddLabelToNoteDTO dto)
            => Ok(bl.AddLabel(dto));

        [HttpDelete]
        public IActionResult Remove(AddLabelToNoteDTO dto)
            => Ok(bl.RemoveLabel(dto));

        [HttpGet("{noteId}")]
        public IActionResult Get(int noteId)
            => Ok(bl.GetLabels(noteId));
    }
}
