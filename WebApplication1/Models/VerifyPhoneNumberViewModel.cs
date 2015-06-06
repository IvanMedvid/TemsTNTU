using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Код")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }
    }
}