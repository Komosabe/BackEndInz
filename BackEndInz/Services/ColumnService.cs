using AutoMapper;
using BackEndInz.Entities;
using BackEndInz.Helpers;
using BackEndInz.Interfaces;
using BackEndInz.Models.Board;
using BackEndInz.Models.Column;
using Microsoft.EntityFrameworkCore;

namespace BackEndInz.Services
{
    public class ColumnService : IColumnService
    {
        private readonly IMapper _mapper;
        private BackEndInzDbContext _context;

        public ColumnService(
            IMapper mapper,
            BackEndInzDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<Column> GetAll() // Get All Columns
        {
            return _context.columns;
        }

        public IEnumerable<GetModelColumn> GetAllColumnsForBoard(int boardId) // Get All Columns for Board (View)
        {
            var columns = _context.columns
                .Where(c => c.BoardId == boardId)
                .Include(c => c.Notes)
                .ToList();

            return _mapper.Map<IEnumerable<GetModelColumn>>(columns);
        }

        public void Create(int boardId, CreateRequestColumn model)
        {
            var board = _context.boards
                .Include(b => b.Columns)
                .FirstOrDefault(b => b.Id == boardId);

            if (board == null)
            {
                throw new KeyNotFoundException("Board not found");
            }

            var newColumn = _mapper.Map<Column>(model);

            newColumn.BoardId = boardId;

            board.Columns.Add(newColumn);

            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequestColumn model)
        {
            var column = getColumn(id);

            if (column == null)
            {
                throw new KeyNotFoundException("Column not found");
            }

            _mapper.Map(model, column);

            _context.columns.Update(column);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var column = getColumn(id);
            _context.columns.Remove(column);
            _context.SaveChanges();
        }

        private Column getColumn(int id)
        {
            var column = _context.columns
                .Include(c => c.Board)
                .FirstOrDefault(c => c.Id == id);

            return column;
        }
    }
}
