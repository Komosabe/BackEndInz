using Microsoft.AspNetCore.SignalR;

namespace BackEndInz.Entities
{
    public class BoardUser
    {
        public int Id { get; set; }
        public string RoleInBoard { get; set; }


        public int BoardId { get; set; }
        public Board Board { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}
