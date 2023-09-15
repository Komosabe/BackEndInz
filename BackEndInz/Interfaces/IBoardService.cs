using BackEndInz.Entities;
using BackEndInz.Models.Board;

namespace BackEndInz.Interfaces
{
    public interface IBoardService
    {
        IEnumerable<Board> GetAll();
        void Create(CreateRequestBoard model);
        Board GetById(int id);
        void Update(int id, UpdateRequestBoard model);
        void Delete(int id);
    }
}
