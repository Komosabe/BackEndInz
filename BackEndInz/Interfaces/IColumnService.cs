using BackEndInz.Entities;
using BackEndInz.Models.Board;
using BackEndInz.Models.Column;

namespace BackEndInz.Interfaces
{
    public interface IColumnService
    {
        IEnumerable<Column> GetAll();
        IEnumerable<GetModelColumn> GetAllColumnsForBoard(int boardId);
        void Create(int boardId, CreateRequestColumn model);
        void Update(int id, UpdateRequestColumn model);
        void Delete(int id);
    }
}
