using BackEndInz.Entities;
using BackEndInz.Models.Board;
using BackEndInz.Models.Note;

namespace BackEndInz.Models.Label
{
    public class LabelOnly
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public int? Priority { get; set; }

        public int? BoardId { get; set; }
        public BoardOnly Board { get; set; }
        public int? NoteId { get; set; }
        public NoteOnly Note { get; set; }
    }
}
