namespace BackEndInz.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public ICollection<BoardUser> BoardUsers { get; set; }
    
    
        public int RoleInApplicationId { get; set; }
        public RoleInApplication RoleInApplication { get; set; }
    
        
        public ICollection<Note> CreatedNotes { get; set; }


        public ICollection<UserNote> UserNotes { get; set; }
    }
}
