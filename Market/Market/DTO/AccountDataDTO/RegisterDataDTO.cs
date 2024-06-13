using System.ComponentModel.DataAnnotations;

namespace Market.DTO.AccountDataDTO
{
    public class RegisterDataDTO
    {
        [Required]
        [StringLength(100)]
        [Display(Name="FullName")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
