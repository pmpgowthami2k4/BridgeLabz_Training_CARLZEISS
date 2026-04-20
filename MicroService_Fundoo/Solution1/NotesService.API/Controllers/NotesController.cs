using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesService.Application.DTOs;
using NotesService.Application.Interfaces;
using NotesService.Domain.Entities;
using System.Security.Claims;

namespace NotesService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NotesController : ControllerBase
{
    private readonly INoteRepository _repo;

    public NotesController(INoteRepository repo)
    {
        _repo = repo;
    }

    private string GetUserId()
    {
        return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
    }

    // CREATE NOTE
    [HttpPost]
    public async Task<IActionResult> Create(CreateNoteDto dto)
    {
        var note = new Note
        {
            UserId = GetUserId(),
            Title = dto.Title,
            Content = dto.Content
        };

        var id = await _repo.AddAsync(note);

        return Ok(new { id });
    }

    // GET ALL NOTES OF LOGGED USER
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var notes = await _repo.GetByUserIdAsync(GetUserId());

        return Ok(notes);
    }

    // UPDATE NOTE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateNoteDto dto)
    {
        var result = await _repo.UpdateAsync(
            id,
            GetUserId(),
            dto.Title,
            dto.Content
        );

        if (!result)
            return NotFound("Note not found");

        return Ok("Note updated successfully");
    }

    // DELETE NOTE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _repo.DeleteAsync(
            id,
            GetUserId()
        );

        if (!result)
            return NotFound("Note not found");

        return Ok("Note deleted successfully");
    }
}


////TESTIG
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using NotesService.Application.DTOs;
//using NotesService.Application.Interfaces;
//using NotesService.Domain.Entities;
//using System.Security.Claims;

//namespace NotesService.API.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//[Authorize]
//public class NotesController : ControllerBase
//{
//    private readonly INoteRepository _repo;

//    public NotesController(INoteRepository repo)
//    {
//        _repo = repo;
//    }

//    private string GetUserId()
//    {
//        return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
//    }

//    // TEST ENDPOINT (PUBLIC)
//    [AllowAnonymous]
//    [HttpGet("ping")]
//    public IActionResult Ping()
//    {
//        return Ok("Notes Service Alive");
//    }

//    // CREATE NOTE
//    [HttpPost]
//    public async Task<IActionResult> Create(CreateNoteDto dto)
//    {
//        var note = new Note
//        {
//            UserId = GetUserId(),
//            Title = dto.Title,
//            Content = dto.Content
//        };

//        var id = await _repo.AddAsync(note);

//        return Ok(new { id });
//    }

//    // GET ALL NOTES OF LOGGED USER
//    [HttpGet]
//    public async Task<IActionResult> GetAll()
//    {
//        var notes = await _repo.GetByUserIdAsync(GetUserId());

//        return Ok(notes);
//    }

//    // UPDATE NOTE
//    [HttpPut("{id}")]
//    public async Task<IActionResult> Update(string id, UpdateNoteDto dto)
//    {
//        var result = await _repo.UpdateAsync(
//            id,
//            GetUserId(),
//            dto.Title,
//            dto.Content
//        );

//        if (!result)
//            return NotFound("Note not found");

//        return Ok("Note updated successfully");
//    }

//    // DELETE NOTE
//    [HttpDelete("{id}")]
//    public async Task<IActionResult> Delete(string id)
//    {
//        var result = await _repo.DeleteAsync(
//            id,
//            GetUserId()
//        );

//        if (!result)
//            return NotFound("Note not found");

//        return Ok("Note deleted successfully");
//    }
//}