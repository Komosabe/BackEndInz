using BackEndInz.Entities;
using BackEndInz.Models.Board;

namespace BackEndInz.Models.User
{
    public class GetModelUser
    {
        public int Id { get; set; } 
        public string Username { get; set; } 


        public ICollection<BoardOnly>? Boards { get; set; }


        public int? RoleInApplicationId { get; set; }
        public RoleInApplication? RoleInApplication { get; set; }
    }
}
