using BackEndInz.Interfaces;
using BackEndInz.Models.Board;
using BackEndInz.Models.Column;
using BackEndInz.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEndInz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColumnController : Controller
    {
        private readonly IColumnService _columnService;

        public ColumnController(
            IColumnService columnService)
        {
            _columnService = columnService;
        }

        [HttpGet] // Get All Columns
        public IActionResult GetAllBoards()
        {
            var columns = _columnService.GetAll();
            return Ok(columns);
        }

        [HttpGet("{boardId}/Columns")] // Get all columns for board
        public IActionResult GetAllColumnsForBoard(int boardId)
        {
            var columns = _columnService.GetAllColumnsForBoard(boardId);
            return Ok(columns);
        }

        [HttpPost("{boardId}/AddColumn")] // Create Board
        public IActionResult AddColumnToBoard(int boardId, CreateRequestColumn model)
        {
            try
            {
                _columnService.Create(boardId, model);
                return Ok(new { message = "Column added to board successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")] // Update Board
        public IActionResult UpdateBoard(int id, UpdateRequestColumn model)
        {
            _columnService.Update(id, model);
            return Ok(new { message = "Column updated" });
        }

        [HttpDelete("{id}")] // Delete Column
        public IActionResult DeleteBoard(int id)
        {
            _columnService.Delete(id);
            return Ok(new { message = "Column deleted" });
        }
    }
}
