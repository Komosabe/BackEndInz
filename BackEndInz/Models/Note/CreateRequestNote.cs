namespace BackEndInz.Models.Note
{
    public class CreateRequestNote
    {
        public string CreatedBy { get; set; }
        public bool isDone { get; set; }
        public bool isImportant { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public int? LabelId { get; set; }
        //public ICollection<int>? UserIds { get; set; }
    }
}
