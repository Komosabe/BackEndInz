namespace BackEndInz.Entities
{
    public class UserNote
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}
