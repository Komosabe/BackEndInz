namespace BackEndInz.Entities
{
    public class Label
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public int? Priority { get; set; }


        public ICollection<Board>? Boards { get; set; }


        public ICollection<Note>? Notes { get; set; }
    }
}
