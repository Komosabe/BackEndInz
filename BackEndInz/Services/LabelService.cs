using AutoMapper;
using BackEndInz.Entities;
using BackEndInz.Helpers;
using BackEndInz.Interfaces;
using BackEndInz.Models.Column;
using BackEndInz.Models.Label;
using Microsoft.EntityFrameworkCore;

namespace BackEndInz.Services
{
    public class LabelService : ILabelService
    {
        private readonly IMapper _mapper;
        private BackEndInzDbContext _context;

        public LabelService(
            IMapper mapper,
            BackEndInzDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<Label> GetAll()
        {
            return _context.labels;
        }

        public void AddLabelToBoard(int boardId, CreateRequestLabelToBoard model)
        {
            var board = _context.boards
                .Include(b => b.Label)
                .FirstOrDefault(b => b.Id == boardId);

            if (board == null)
            {
                throw new KeyNotFoundException("Board not found");
            }

            var newLabel = _mapper.Map<Label>(model);

            newLabel.BoardId = boardId;


            _context.labels.Add(newLabel);
            _context.SaveChanges();


            board.LabelId = newLabel.Id;
            _context.SaveChanges(); 
        }

        public void AddLabelToNote(int noteId, CreateRequestLabelToNote model)
        {
            var note = _context.notes
                .Include(n => n.Label)
                .FirstOrDefault(n => n.Id == noteId);

            if (note == null)
            {
                throw new KeyNotFoundException("Note not found");
            }

            var newLabel = _mapper.Map<Label>(model);

            newLabel.NoteId = noteId;

            _context.labels.Add(newLabel);
            _context.SaveChanges();

            note.LabelId = newLabel.Id;
            _context.SaveChanges();
        }

        public LabelOnly GetById(int id)
        {
            return getLabelModel(id);
        }

        public void Delete(int id)
        {
            var label = getLabel(id);
            if (label != null)
            {
                _context.labels.Remove(label);
                _context.SaveChanges();
            }
        }

        public GetModelLabel GetLabelByBoardId(int boardId)
        {
            var label = _context.labels
                .Include(c => c.Board)
                .FirstOrDefault(c => c.BoardId == boardId);

            if (label != null)
            {
                label.Board = _context.boards
                    .Include(b => b.Label)
                    .FirstOrDefault(b => b.Id == boardId);
            }

            return _mapper.Map<GetModelLabel>(label);
        }

        public GetModelLabel GetLabelByNoteId(int noteId)
        {
            var label = _context.labels
                .Include(d => d.Note)
                .FirstOrDefault(c => c.NoteId == noteId);

            if (label != null)
            {
                label.Note = _context.notes
                    .Include(n => n.Label)
                    .FirstOrDefault(n => n.Id == label.NoteId);
            }

            return _mapper.Map<GetModelLabel>(label);
        }

        private Label getLabel(int id)
        {
            var label = _context.labels
                .Include(c => c.Board)
                .Include(d => d.Note)
                .FirstOrDefault(c => c.Id == id);

            return label;
        }

        private LabelOnly getLabelModel(int id)
        {
            var label = _context.labels
                .Include(c => c.Board)
                .Include(d => d.Note)
                .FirstOrDefault(c => c.Id == id);

            if (label != null)
            {
                label.Board = _context.boards
                    .Include(b => b.Label)
                    .FirstOrDefault(b => b.Id == label.BoardId);

                label.Note = _context.notes
                    .Include(n => n.Label)
                    .FirstOrDefault(n => n.Id == label.NoteId);
            }

            var labelOnly = _mapper.Map<LabelOnly>(label);

            return labelOnly;
        }
    }
}
