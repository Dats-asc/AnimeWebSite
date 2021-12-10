using System.ComponentModel.DataAnnotations;

namespace AnimeWebSite.Models
{
    public class Autithication
    {
        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}