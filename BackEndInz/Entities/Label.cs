namespace BackEndInz.Entities
{
    public class Label
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int Priority { get; set; }


        public ICollection<BoardLabel> BoardLabels { get; set; }


        public ICollection<NoteLabel> NoteLabels { get; set; }
    }
}
