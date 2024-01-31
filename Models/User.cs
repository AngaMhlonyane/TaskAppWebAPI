using System.ComponentModel.DataAnnotations;

namespace TaskApp.Models
{
    public class User
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string ApiKey { get; set; }

    }
}
