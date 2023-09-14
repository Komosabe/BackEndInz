﻿namespace BackEndInz.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public ICollection<Board> Boards { get; set; }
    
    
        public int RoleInApplicationId { get; set; }
        public RoleInApplication RoleInApplication { get; set; }
    
        //// Created by User notes
        //public ICollection<Note> CreatedNotes { get; set; }


        // User Notes
        public ICollection<Note> Notes { get; set; }
    }
}