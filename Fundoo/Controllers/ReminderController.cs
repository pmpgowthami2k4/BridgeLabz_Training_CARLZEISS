using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTOs;


namespace Fundoo.Controllers
{
    [ApiController]
    [Route("reminder")]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderBL bl;

        public ReminderController(IReminderBL bl)
        {
            this.bl = bl;
        }

        [HttpPost]
        public IActionResult Add(ReminderDTO dto)
            => Ok(bl.Add(dto));

        [HttpGet("{noteId}")]
        public IActionResult Get(int noteId)
            => Ok(bl.Get(noteId));
    }
}
