using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Номер телефону")]
        public string Number { get; set; }
    }
}