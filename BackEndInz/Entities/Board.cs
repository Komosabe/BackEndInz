using BackEndInz.Models.User;
using System.Text.Json.Serialization;

namespace BackEndInz.Entities
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //public ICollection<Label>? Labels { get; set; }
        public int? LabelId { get; set; } 
        public Label? Label { get; set; } 

        public ICollection<Column>? Columns { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
