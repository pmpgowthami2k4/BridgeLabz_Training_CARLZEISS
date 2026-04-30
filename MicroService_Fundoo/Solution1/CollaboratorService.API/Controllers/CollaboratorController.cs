
//using CollaboratorService.Application.DTOs;
//using CollaboratorService.Application.Services;
//using CollaboratorService.Domain.Entities;
//using CollaboratorService.Infrastructure.Email;
//using CollaboratorService.Infrastructure.RabbitMQ;
//using Dapr;
//using Microsoft.AspNetCore.Mvc;
//using SharedLibrary.CustomExceptions;

//namespace CollaboratorService.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class CollaboratorController : ControllerBase
//    {
//        private readonly CollaboratorManager _service;
//        private readonly RabbitMqPublisher _rabbit;
//        private readonly EmailService _email;

//        public CollaboratorController(
//            CollaboratorManager service,
//            RabbitMqPublisher rabbit,
//            EmailService email)
//        {
//            _service = service;
//            _rabbit = rabbit;
//            _email = email;
//        }

//        // ADD COLLABORATOR
//        [HttpPost("add")]
//        public async Task<IActionResult> Add([FromBody] AddCollaboratorDto dto)
//        {
//            try
//            {
//                // Gateway validates token, fixed userId for now
//                var userId = "1";

//                var collaborator = new Collaborator
//                {
//                    NoteId = dto.NoteId,
//                    OwnerUserId = userId,
//                    CollaboratorEmail = dto.CollaboratorEmail
//                };

//                await _service.AddAsync(collaborator);

//                // Existing RabbitMQ publish
//                await _rabbit.PublishAsync("collaboratorQueue", new
//                {
//                    collaborator.NoteId,
//                    collaborator.CollaboratorEmail
//                });

//                return Ok(new
//                {
//                    Success = true,
//                    Message = "Collaborator Added Successfully"
//                });
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new
//                {
//                    Success = false,
//                    Message = ex.Message
//                });
//            }
//        }

//        // DAPR PUB/SUB SUBSCRIBER
//        [Topic("pubsub", "collaborator-added")]
//        [HttpPost("notify")]
//        public async Task<IActionResult> Notify([FromBody] CollaboratorEvent model)
//        {
//            await _email.SendInviteAsync(
//                model.CollaboratorEmail,
//                model.NoteId);

//            return Ok(new
//            {
//                Success = true,
//                Message = "Email Sent Successfully"
//            });
//        }

//        // GET ALL COLLABORATORS BY NOTE ID
//        [HttpGet("{noteId}")]
//        public async Task<IActionResult> Get(int noteId)
//        {
//            try
//            {
//                var result = await _service.GetByNoteIdAsync(noteId);

//                return Ok(new
//                {
//                    Success = true,
//                    Data = result
//                });
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new
//                {
//                    Success = false,
//                    Message = ex.Message
//                });
//            }
//        }

//        // DELETE COLLABORATOR
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var result = await _service.DeleteAsync(id);

//            if (result == 0)
//                throw new NotFoundException("Collaborator not found");

//            return Ok("Deleted");
//        }
//    }

//    public class CollaboratorEvent
//    {
//        public int NoteId { get; set; }
//        public string CollaboratorEmail { get; set; }
//    }
//}
using CollaboratorService.Application.DTOs;
using CollaboratorService.Application.Services;
using CollaboratorService.Domain.Entities;
using CollaboratorService.Infrastructure.Email;
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.CustomExceptions;

namespace CollaboratorService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly CollaboratorManager _service;
        private readonly EmailService _email;

        public CollaboratorController(
            CollaboratorManager service,
            EmailService email)
        {
            _service = service;
            _email = email;
        }

        //  ADD COLLABORATOR (PUBLISH EVENT)
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddCollaboratorDto dto)
        {
            try
            {
                var userId = "1";

                var collaborator = new Collaborator
                {
                    NoteId = dto.NoteId,
                    OwnerUserId = userId,
                    CollaboratorEmail = dto.CollaboratorEmail
                };

                await _service.AddAsync(collaborator);

                // 🔥 DAPR PUBLISH
                var daprClient = new DaprClientBuilder().Build();

                await daprClient.PublishEventAsync(
                    "pubsub",
                    "collaborator-added",
                    new CollaboratorEvent
                    {
                        NoteId = collaborator.NoteId,
                        CollaboratorEmail = collaborator.CollaboratorEmail
                    }
                );

                return Ok(new
                {
                    Success = true,
                    Message = "Collaborator Added + Event Published"
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

        // SUBSCRIBER (EVENT HANDLER)
        [Topic("pubsub", "collaborator-added")]
        [HttpPost("notify")]
        public async Task<IActionResult> Notify([FromBody] CollaboratorEvent model)
        {
            Console.WriteLine("🔥 EVENT RECEIVED");

            await _email.SendInviteAsync(
                model.CollaboratorEmail,
                model.NoteId);

            return Ok(new
            {
                Success = true,
                Message = "Email Sent via Pub/Sub"
            });
        }

        // GET ALL COLLABORATORS
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

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (result == 0)
                throw new NotFoundException("Collaborator not found");

            return Ok("Deleted");
        }
    }

    //  EVENT MODEL
    public class CollaboratorEvent
    {
        public int NoteId { get; set; }
        public string CollaboratorEmail { get; set; }
    }
}