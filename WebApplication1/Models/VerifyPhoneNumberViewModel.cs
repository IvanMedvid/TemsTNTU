using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "���")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "����� ��������")]
        public string PhoneNumber { get; set; }
    }
}