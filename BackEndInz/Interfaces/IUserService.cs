using BackEndInz.Entities;
using BackEndInz.Models.Board;
using BackEndInz.Models.User;

namespace BackEndInz.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        ICollection<User> GetUsersByIds(ICollection<int> ids);
        User GetById(int id);
        GetModelUser GetViewById(int id);
        void Register(RegisterRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
}
