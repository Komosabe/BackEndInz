namespace BackEndInz.Entities
{
    public class Column
    {
        public int Id { get; set; }
        public string Title { get; set; }


        public int BoardId { get; set; }
        public Board Board { get; set; }


        public ICollection<Note> Notes { get; set;}
    }
}
