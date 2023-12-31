﻿namespace BackEndInz.Entities
{
    public class Label
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public int? Priority { get; set; }


        public int? BoardId { get; set; } 
        public Board Board { get; set; }
        public int? NoteId { get; set; } 
        public Note Note { get; set; }
    }
}
