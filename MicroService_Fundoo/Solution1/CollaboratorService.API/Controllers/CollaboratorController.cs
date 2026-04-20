using CollaboratorService.Application.DTOs;
using CollaboratorService.Application.Services;
using CollaboratorService.Domain.Entities;
using CollaboratorService.Infrastructure.Email;
using CollaboratorService.Infrastructure.RabbitMQ;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.CustomExceptions;

namespace CollaboratorService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly CollaboratorManager _service;
        private readonly RabbitMqPublisher _rabbit;
        private readonly EmailService _email;

        public CollaboratorController(
            CollaboratorManager service,
            RabbitMqPublisher rabbit,
            EmailService email)
        {
            _service = service;
            _rabbit = rabbit;
            _email = email;
        }

        // ADD COLLABORATOR
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddCollaboratorDto dto)
        {
            try
            {
                var collaborator = new Collaborator
                {
                    NoteId = dto.NoteId,
                    OwnerUserId = "1", // Later replace with JWT UserId
                    CollaboratorEmail = dto.CollaboratorEmail
                };

                await _service.AddAsync(collaborator);

                // RabbitMQ Publish
                await _rabbit.PublishAsync("collaboratorQueue", new
                {
                    collaborator.NoteId,
                    collaborator.CollaboratorEmail
                });

                // Send Email
                await _email.SendInviteAsync(
                    collaborator.CollaboratorEmail,
                    collaborator.NoteId);

                return Ok(new
                {
                    Success = true,
                    Message = "Collaborator Added Successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // GET ALL COLLABORATORS BY NOTE ID
        [HttpGet("{noteId}")]
        public async Task<IActionResult> Get(int noteId)
        {
            try
            {
                var result = await _service.GetByNoteIdAsync(noteId);

                return Ok(new
                {
                    Success = true,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        // DELETE COLLABORATOR
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (result == 0)
                throw new NotFoundException("Collaborator not found");

            return Ok("Deleted");
        }
    }
}