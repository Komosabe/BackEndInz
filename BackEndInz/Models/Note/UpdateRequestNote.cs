namespace BackEndInz.Models.Note
{
    public class UpdateRequestNote
    {
        public string CreatedBy { get; set; }
        public bool isDone { get; set; }
        public bool isImportant { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public int? LabelId { get; set; }
        //public int? ColumnId { get; set; }
        //public ICollection<int>? UserIds { get; set; }
    }
}
