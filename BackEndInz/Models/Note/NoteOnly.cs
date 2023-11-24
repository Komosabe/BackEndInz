namespace BackEndInz.Models.Note
{
    public class NoteOnly
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Description { get; set; }
        public bool isDone { get; set; }
        public bool isImportant { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? LabelId { get; set; }
        public Models.Label.LabelOnly? Label { get; set; }
    }
}
