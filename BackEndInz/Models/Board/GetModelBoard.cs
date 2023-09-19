using BackEndInz.Models.Column;
using BackEndInz.Models.Label;
using BackEndInz.Models.User;

namespace BackEndInz.Models.Board
{
    public class GetModelBoard
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<UserOnly> Users { get; set; }
        public ICollection<ColumnOnly> Columns { get; set; }
        public ICollection<LabelOnly> Labels { get; set; }
    }
}
