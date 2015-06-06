using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "���")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "�����'����� �������?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }
}