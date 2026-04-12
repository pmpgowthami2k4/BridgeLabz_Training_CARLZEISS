using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interfaces;
using System.Security.Claims;

[Route("[controller]")]
[ApiController]
public class CollaboratorController : ControllerBase
{
    private readonly ICollaboratorBL _collabBL;

public CollaboratorController(ICollaboratorBL collabBL)
    {
        _collabBL = collabBL;
    }

    // ✅ ADD COLLABORATOR
    [HttpPost("{noteId}")]
    public async Task<IActionResult> Add(string noteId, [FromQuery] string email)
    {
        var userId = User.FindFirst("UserId")?.Value ?? "1"; // temp fallback

        var result = await _collabBL.AddCollaborator(noteId, userId, email);
        return Ok(result);
    }

    // ✅ GET ALL COLLABORATORS OF A NOTE
    [HttpGet("{noteId}")]
    public async Task<IActionResult> Get(string noteId)
    {
        var result = await _collabBL.GetCollaborators(noteId);
        return Ok(result);
    }

    // ✅ REMOVE COLLABORATOR
    [HttpDelete("{noteId}")]
    public async Task<IActionResult> Remove(string noteId, [FromQuery] string email)
    {
        var userId = User.FindFirst("UserId")?.Value ?? "1";

        var result = await _collabBL.RemoveCollaborator(noteId, userId, email);
        return Ok(result);
    }

    // ✅ GET SHARED NOTES
    [HttpGet("shared")]
    public async Task<IActionResult> Shared()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value ?? "";

        var result = await _collabBL.GetSharedNotes(email);
        return Ok(result);
    }

}
