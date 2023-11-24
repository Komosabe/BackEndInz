namespace BackEndInz.Models.Note
{
    public class UpdateRequestNote
    {
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public bool isDone { get; set; }
        public string? Description { get; set; }
        public bool isImportant { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
