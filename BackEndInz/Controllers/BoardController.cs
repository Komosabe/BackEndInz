using BackEndInz.Authorization;
using BackEndInz.Interfaces;
using BackEndInz.Models.Board;
using Microsoft.AspNetCore.Mvc;

namespace BackEndInz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : Controller
    {
        private readonly IBoardService _boardService;

        public BoardController(
            IBoardService boardService)
        {
            _boardService = boardService;
        }

        //[Authorize]
        [HttpGet] // Get All Boards
        public IActionResult GetAllBoards()
        {
            var boards = _boardService.GetAll();
            return Ok(boards);
        }

        [HttpGet("ViewAll")] // Get View All BoardsAll Boards
        public IActionResult GetViewAllBoards()
        {
            var boards = _boardService.GetViewAll();
            return Ok(boards);
        }

        [HttpGet("{id}")] // Get by Id Board
        public IActionResult GetByIdBoard(int id)
        {
            var board = _boardService.GetById(id);
            return Ok(board);
        }

        [HttpGet("{id}/ViewBoard")] // Get by Id Board
        public IActionResult GetView(int id)
        {
            var board = _boardService.GetViewById(id);
            return Ok(board);
        }

        [Authorize]
        [HttpGet("{userId}/Boards")] // Get by UserId Boards
        public IActionResult GetByUserIdBoards(int userId)
        {
            var boards = _boardService.GetByUserIdBoards(userId);
            return Ok(boards);
        }

        //[Authorize]
        [HttpPost] // Create Board
        public IActionResult CreateBoard(CreateRequestBoard model)
        {
            _boardService.Create(model);
            return Ok(new { message = "Board created" });
        }
        [Authorize]
        [HttpPut("{id}")] // Update Board
        public IActionResult UpdateBoard(int id, UpdateRequestBoard model)
        {
            _boardService.Update(id, model);
            return Ok(new { message = "Board updated" });
        }
        [Authorize]
        [HttpDelete("{id}")] // Delete Board
        public IActionResult DeleteBoard(int id)
        {
            _boardService.Delete(id);
            return Ok(new { message = "Board deleted" });
        }
    }
}
