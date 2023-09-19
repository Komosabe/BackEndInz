using AutoMapper;
using BackEndInz.Authorization;
using BackEndInz.Entities;
using BackEndInz.Helpers;
using BackEndInz.Interfaces;
using BackEndInz.Models.Board;
using BackEndInz.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BackEndInz.Services
{
    public class UserService : IUserService
    {
        private BackEndInzDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(
            BackEndInzDbContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.users.SingleOrDefault(x => x.Username == model.Username);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);
            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.users;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public GetModelUser GetViewById(int id)
        {
            var user = _context.users
                    .Include(a => a.Boards)
                    .FirstOrDefault(b => b.Id == id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return _mapper.Map<GetModelUser>(user);
        }

        public void Register(RegisterRequest model)
        {
            // validate
            if (_context.users.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password

            //user.PasswordHash = BCrypt.HashPassword(model.Password);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            // save user
            _context.users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var user = getUser(id);

            // validate
            if (model.Username != user.Username && _context.users.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            _context.users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.users.Remove(user);
            _context.SaveChanges();
        }

        public ICollection<User> GetUsersByIds(ICollection<int> ids)
        {
            var users = _context.users.Where(u => ids.Contains(u.Id)).ToList();
            if(users.Count <= 0) throw new KeyNotFoundException("No users");
            return users;
        }

        private User getUser(int id)
        {
            var user = _context.users
                    .Include(b => b.Notes)
                    .FirstOrDefault(b  => b.Id == id);

            var boards = _context.boards
                                    .Where(u => u.Users.Any(b => b.Id == id))
                                    .ToList();

            user.Boards = boards;

            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
