using System.ComponentModel.DataAnnotations;

namespace TaskApp.Models
{
    public class Story
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int Assignee { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}
