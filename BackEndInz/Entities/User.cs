using System.Text.Json.Serialization;

namespace BackEndInz.Entities
{
    public class User
    {
        public int Id { get; set; } // 
        public string Username { get; set; } // 


        [JsonIgnore]
        public string PasswordHash { get; set; } 


        public ICollection<Board>? Boards { get; set; } 
    
    
        //public int? RoleInApplicationId { get; set; }
        //public RoleInApplication? RoleInApplication { get; set; }
    


        public ICollection<Note>? Notes { get; set; }
    }
}
