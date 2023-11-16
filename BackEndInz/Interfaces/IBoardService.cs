using BackEndInz.Entities;
using BackEndInz.Models.Board;

namespace BackEndInz.Interfaces
{
    public interface IBoardService
    {
        IEnumerable<Board> GetAll();
        IEnumerable<GetModelBoard> GetViewAll();
        void Create(CreateRequestBoard model);
        Board GetById(int id);
        GetModelBoard GetViewById(int id);
        IEnumerable<Board> GetByUserIdBoards(int userId);
        void Update(int id, UpdateRequestBoard model);
        void Delete(int id);
    }
}
