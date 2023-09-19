using BackEndInz.Models.User;
using System.ComponentModel.DataAnnotations;

namespace BackEndInz.Models.Board
{
    public class UpdateRequestBoard
    {
        [MinLength(3)]
        public string Title { get; set; }


        public ICollection<int>? UsersIds { get; set; }
    }
}
