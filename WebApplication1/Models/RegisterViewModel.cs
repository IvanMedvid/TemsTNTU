using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "�������� {0} ������� ������ �� ����� {2} �������.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ϳ����������� ������")]
        [Compare("Password", ErrorMessage = "������ � ���� ������������ �� ����������.")]
        public string ConfirmPassword { get; set; }
    }
}