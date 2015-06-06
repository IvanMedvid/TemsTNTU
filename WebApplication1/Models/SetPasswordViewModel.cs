using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "�������� {0} ������� ������ ������� �� �����: {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "����� ������")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ϳ����������� ������ ������")]
        [Compare("NewPassword", ErrorMessage = "����� ������ � ���� ������������ �� ����������.")]
        public string ConfirmPassword { get; set; }
    }
}