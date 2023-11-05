using AutoMapper;
using BackEndInz.Entities;
using BackEndInz.Helpers;
using BackEndInz.Interfaces;
using BackEndInz.Models.Column;
using BackEndInz.Models.Note;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BackEndInz.Services
{
    public class NoteService : INoteService
    {
        private BackEndInzDbContext _context;
        private readonly IMapper _mapper;

        public NoteService(
            IMapper mapper,
            BackEndInzDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.notes;
        }

        public void Create(int columnId, CreateRequestNote model)
        {
            var column = _context.columns
                .Include(c => c.Notes)
                .FirstOrDefault(c => c.Id == columnId);

            if (column == null)
            {
                throw new KeyNotFoundException("Column not found");
            }

            var note = _mapper.Map<Note>(model);

            note.ColumnId = columnId;
            note.CreatedDate = DateTime.Now;

            _context.notes.Add(note);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequestNote model)
        {
            var note = getNote(id);

            if (note == null)
            {
                throw new KeyNotFoundException("Note not found");
            }

            _mapper.Map(model, note);

            _context.notes.Update(note);
            _context.SaveChanges();
        }

        public Note GetById(int id)
        {
            var note = getNote(id);

            if (note == null)
            {
                throw new KeyNotFoundException("Note not found");
            }

            return note;
        }

        public IEnumerable<GetModelNote> GetAllNotesForColumn(int columnId)
        {
            var notes = _context.notes
                .Where(a => a.ColumnId == columnId)
                .ToList();

            return _mapper.Map<IEnumerable<GetModelNote>>(notes);
        }

        public void Delete(int id)
        {
            var note = getNote(id);
            _context.notes.Remove(note);
            _context.SaveChanges();
        }

        private Note getNote(int id)
        {
            var note = _context.notes
                .FirstOrDefault(c => c.Id == id);

            return note;
        }
    }
}
