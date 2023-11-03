using BackEndInz.Interfaces;
using BackEndInz.Models.Column;
using BackEndInz.Models.Label;
using BackEndInz.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEndInz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : Controller
    {
        // to do
        // Dodawanie do tablicy
        // dodawanie do notatki
        // usuwanie w tablicy
        // dodawanie w tablicy
    
        private readonly ILabelService _labelService;

        public LabelController(
            ILabelService labelService)
        {
            _labelService = labelService;
        }

        [HttpGet] // Get All Labels
        public IActionResult GetAllLabels()
        {
            var labels = _labelService.GetAll();
            return Ok(labels);
        }

        [HttpPost("{boardId}/AddLabelToBoard")] // Create Label to Board
        public IActionResult AddLabelToBoard(int boardId, CreateRequestLabelToBoard model)
        {
            try
            {
                _labelService.AddLabelToBoard(boardId, model);
                return Ok(new { message = "Label added to board successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("{id}")] // Get Label by id
        public IActionResult GetLabelById(int id)
        {
            var label = _labelService.GetById(id);

            if (label == null)
            {
                return NotFound();
            }

            return Ok(label);
        }

        [HttpGet("{boardId}/GetLabelBoard")] // Get Label By BoardId
        public IActionResult GetLabelByBoardId(int boardId)
        {
            var label = _labelService.GetLabelByBoardId(boardId);

            if (label == null)
            {
                return NotFound();
            }

            return Ok(label);
        }

        [HttpPost("{noteId}/AddLabelToNote")] // Create Label to Note
        public IActionResult AddLabelToNote(int noteId, CreateRequestLabelToNote model)
        {
            try
            {
                _labelService.AddLabelToNote(noteId, model);
                return Ok(new { message = "Label added to note successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{noteId}/GetLabelNote")] // Get Label By NoteId
        public IActionResult GetLabelByNoteId(int noteId)
        {
            var label = _labelService.GetLabelByNoteId(noteId);

            if (label == null)
            {
                return NotFound();
            }

            return Ok(label);
        }

        [HttpDelete("{id}")] // Delete Label 
        public IActionResult DeleteBoard(int id)
        {
            _labelService.Delete(id);
            return Ok(new { message = "Label deleted" });
        }
    }
}
