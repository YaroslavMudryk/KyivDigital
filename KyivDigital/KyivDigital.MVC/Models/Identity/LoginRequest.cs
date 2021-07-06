using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KyivDigital.MVC.Models.Identity
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Телефон обов'язковий")]
        [StringLength(13, ErrorMessage = "Довжина має бути 13 символів", MinimumLength = 13)]
        [DisplayName("Мобільний телефон")]
        public string Phone { get; set; }
        [DisplayName("Код підтведження")]
        public string Code { get; set; }
        public bool IsVerify { get; set; }
    }
}