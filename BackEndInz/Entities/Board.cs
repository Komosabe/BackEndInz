namespace BackEndInz.Entities
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsAutomated { get; set; }


        public ICollection<Column> Columns { get; set; }


        public ICollection<BoardUser> BoardUsers { get; set; }
    }
}
