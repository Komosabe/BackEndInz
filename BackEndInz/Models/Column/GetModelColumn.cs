using BackEndInz.Entities;
using BackEndInz.Models.Note;

namespace BackEndInz.Models.Column
{
    public class GetModelColumn
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<NoteOnly>? Notes { get; set; }
    }
}
