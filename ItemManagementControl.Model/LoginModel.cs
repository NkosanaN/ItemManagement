using System.ComponentModel.DataAnnotations;

namespace ItemManagementControl.Model
{
    public class LoginModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string LoginInValid { get; set; } = default!;
        public string LoginFailedMessage { get; set; } = default!;

    }
}
