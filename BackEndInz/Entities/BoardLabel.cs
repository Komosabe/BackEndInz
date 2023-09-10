namespace BackEndInz.Entities
{
    public class BoardLabel
    {
        public int Id { get; set; }


        public int BoardId { get; set; }
        public Board Board { get; set; }


        public int LabelId { get; set; }
        public Label Label { get; set; }
    }
}
