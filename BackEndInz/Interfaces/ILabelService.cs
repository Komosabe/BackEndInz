using BackEndInz.Entities;
using BackEndInz.Models.Label;

namespace BackEndInz.Interfaces
{
    public interface ILabelService
    {
        IEnumerable<Label> GetAll();
        void AddLabelToBoard(int boardId, CreateRequestLabelToBoard model);
        void Delete(int id);
        LabelOnly GetById(int id);
        GetModelLabel GetLabelByBoardId(int boardId);
        void UpdateLabel(int labelId, UpdateRequestLabel model);
        void AddLabelToNote(int noteId, CreateRequestLabelToNote model);
        GetModelLabel GetLabelByNoteId(int noteId);
    }
}
