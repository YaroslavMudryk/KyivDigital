using System.ComponentModel.DataAnnotations;

namespace KyivDigital.MVC.Models.Identity
{
    public class LoginRequest
    {
        [Required, MinLength(13), MaxLength(13)]
        public string Phone { get; set; }
        public string Code { get; set; }
        public bool IsVerify { get; set; }
    }
}