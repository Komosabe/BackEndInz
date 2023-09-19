using AutoMapper;
using BackEndInz.Entities;
using BackEndInz.Helpers;
using BackEndInz.Interfaces;
using BackEndInz.Models.Board;
using BackEndInz.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BackEndInz.Services
{
    public class BoardService : IBoardService
    {
        private readonly IMapper _mapper;
        private BackEndInzDbContext _context;
        private IUserService _userService;


        public BoardService(
            IMapper mapper,
            BackEndInzDbContext context,
            IUserService userService)
        {
            _mapper = mapper;
            _context = context;
            _userService = userService;
        }

        public IEnumerable<Board> GetAll()
        {
            return _context.boards;
        }

        public Board GetById(int id)
        {
            return getBoard(id);
        }

        public GetModelBoard GetViewById(int id)
        {
            var board = _context.boards
                    .Include(a => a.Labels)
                    .Include(b => b.Columns)
                    .Include(c => c.Users)
                    .FirstOrDefault(b => b.Id == id);
            if (board == null) throw new KeyNotFoundException("Board not found");
            return _mapper.Map<GetModelBoard>(board);
        }

        public IEnumerable<Board> GetByUserIdBoards(int userId)
        {
            var boards = _context.boards
                .Include(b => b.Users)
                .Where(b => b.Users.Any(u => u.Id == userId))
                .ToList();

            return boards;
        }

        public void Create(CreateRequestBoard model)
        {
            var board = _mapper.Map<Board>(model);

            _context.boards.Add(board);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequestBoard model)
        {
            var board = getBoard(id);

            if (model.UsersIds == null) board.Users = null;
            else board.Users = _userService.GetUsersByIds(model.UsersIds);

            _mapper.Map(model, board);
            _context.boards.Update(board);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var board = getBoard(id);
            _context.boards.Remove(board);
            _context.SaveChanges();
        }

        private Board getBoard(int id)
        {
            var board = _context.boards
                    .Include(b => b.Labels)
                    .Include(b => b.Columns)
                    .FirstOrDefault(b => b.Id == id);


            var users = _context.users
                                .Where(u => u.Boards.Any(b => b.Id == id))
                                .ToList();

            board.Users = users;

            if (board == null) 
                throw new KeyNotFoundException("Board not found");
            
            
            return board;
        }
    }
}
