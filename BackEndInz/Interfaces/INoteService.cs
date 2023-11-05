using BackEndInz.Entities;
using BackEndInz.Models.Column;
using BackEndInz.Models.Note;

namespace BackEndInz.Interfaces
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll();
        void Create(int columnId, CreateRequestNote model);
        void Update(int id, UpdateRequestNote model);
        Note GetById(int id);
        IEnumerable<GetModelNote> GetAllNotesForColumn(int columnId);
        void Delete(int id);
    }
}
