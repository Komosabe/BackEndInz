namespace BackEndInz.Models.Label
{
    public class CreateRequestLabelToNote
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public int? Priority { get; set; }
    }
}
