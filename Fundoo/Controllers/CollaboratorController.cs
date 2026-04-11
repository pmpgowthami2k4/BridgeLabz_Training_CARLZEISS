using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interfaces;

[Route("[controller]")]
[ApiController]
public class CollaboratorController : ControllerBase
{
    private readonly ICollaboratorBL _collabBL;

    public CollaboratorController(ICollaboratorBL collabBL)
    {
        _collabBL = collabBL;
    }

    // ADD
    [HttpPost("{noteId}")]
    public async Task<IActionResult> Add(int noteId, [FromQuery] string email)
    {
        int userId = 1; // temp

        var result = await _collabBL.AddCollaborator(noteId, userId, email);
        return Ok(result);
    }

    // GET ALL
    [HttpGet("{noteId}")]
    public async Task<IActionResult> Get(int noteId)
    {
        var result = await _collabBL.GetCollaborators(noteId);
        return Ok(result);
    }

    // REMOVE
    [HttpDelete("{noteId}")]
    public async Task<IActionResult> Remove(int noteId, [FromQuery] string email)
    {
        var result = await _collabBL.RemoveCollaborator(noteId, email);
        return Ok(result);
    }

    // SHARED NOTES
    [HttpGet("shared")]
    public async Task<IActionResult> Shared([FromQuery] string email)
    {
        var result = await _collabBL.GetSharedNotes(email);
        return Ok(result);
    }
}