using BackEndInz.Authorization;
using BackEndInz.Interfaces;
using BackEndInz.Models.Label;
using BackEndInz.Models.Note;
using BackEndInz.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEndInz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(
            INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet] // Get All Notes
        public IActionResult GetAllNotes()
        {
            var boards = _noteService.GetAll();
            return Ok(boards);
        }

        [HttpPost("{columnId}/AddNote")] // Create Note to Column
        public IActionResult AddNoteToColumn(int columnId, CreateRequestNote model)
        {
            try
            {
                _noteService.Create(columnId, model);
                return Ok(new { message = "Note added to Column successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")] // Update Note
        public IActionResult UpdateNote(int id, UpdateRequestNote model)
        {
            try
            {
                _noteService.Update(id, model);
                return Ok(new { message = "Note updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")] // Get Note by Id
        public IActionResult GetNoteById(int id)
        {
            try
            {
                var note = _noteService.GetById(id);
                return Ok(note);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{columnId}/Notes")] // Get all notes for column
        public IActionResult GetAllNotesForColumn(int columnId)
        {
            var notes = _noteService.GetAllNotesForColumn(columnId);
            return Ok(notes);
        }

        [HttpDelete("{id}")] // Delete Note
        public IActionResult DeleteNote(int id)
        {
            _noteService.Delete(id);
            return Ok(new { message = "Note deleted" });
        }
    }
}
