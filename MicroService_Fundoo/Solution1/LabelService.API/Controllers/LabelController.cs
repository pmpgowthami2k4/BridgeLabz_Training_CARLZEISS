using LabelService.Application.DTOs;
using LabelService.Application.Services;
using LabelService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.CustomExceptions;

namespace LabelService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LabelController : ControllerBase
    {
        private readonly LabelManager _service;
        private readonly NoteLabelManager _mapService;

        public LabelController(
    LabelManager service,
    NoteLabelManager mapService)
        {
            _service = service;
            _mapService = mapService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateLabelDto dto)
        {
            var label = new Label
            {
                UserId = dto.UserId,
                Name = dto.Name
            };

            await _service.AddAsync(label);

            return Ok("Label Created");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            var result = await _service.GetByUserIdAsync(userId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (result == 0)
                throw new NotFoundException("Label not found");

            return Ok("Deleted");
        }

        [HttpPost("assign")]
        public async Task<IActionResult> Assign(AssignLabelDto dto)
        {
            var model = new NoteLabel
            {
                NoteId = dto.NoteId,
                LabelId = dto.LabelId
            };

            await _mapService.AddAsync(model);

            return Ok("Label Assigned To Note");
        }

        [HttpGet("note/{noteId}")]
        public async Task<IActionResult> GetByNote(int noteId)
        {
            var result = await _mapService.GetByNoteIdAsync(noteId);
            return Ok(result);
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mapService.DeleteAsync(id);
            return Ok("Mapping Removed");
        }
    }
}