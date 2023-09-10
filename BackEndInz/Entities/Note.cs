namespace BackEndInz.Entities
{
    public class Note
    {
        public int Id { get; set; }
        //public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isDone { get; set; }
        public bool isImportant { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public ICollection<NoteLabel> NoteLabels { get; set; }
    

        public int ColumnId { get; set; }
        public Column Column { get; set; }


        public int UserId { get; set; }
        public User CreatedBy { get; set; }


        public ICollection<UserNote> UserNotes { get; set; }
    }
}
