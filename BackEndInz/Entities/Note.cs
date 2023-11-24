namespace BackEndInz.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isDone { get; set; }
        public bool isImportant { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public int? LabelId { get; set; } 
        public Label Label { get; set; } 

        public int? ColumnId { get; set; }
        public Column? Column { get; set; }


        public ICollection<User>? Users { get; set; }
    }
}
