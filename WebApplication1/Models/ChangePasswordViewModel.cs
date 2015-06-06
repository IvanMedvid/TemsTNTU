using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Наявний пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значення {0} повинне містити символів не менше: {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новий пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження нового пароля")]
        [Compare("NewPassword", ErrorMessage = "Новий пароль і його підтвердження не співпадають.")]
        public string ConfirmPassword { get; set; }
    }
}