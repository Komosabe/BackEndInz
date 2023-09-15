using System.ComponentModel.DataAnnotations;

namespace BackEndInz.Models.Board
{
    public class CreateRequestBoard
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        public bool IsAutomated { get; set; }

    }
}
