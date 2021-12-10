using System.ComponentModel.DataAnnotations;

namespace AnimeWebSite.Models
{
    public class Registration
    {
        [Required]
        [EmailAddress]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public string ConfirmPassword { get; set; }
        public string Nickname { get; set; }
    }
}