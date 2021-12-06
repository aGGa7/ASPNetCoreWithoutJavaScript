using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [UIHint("passwprd")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
