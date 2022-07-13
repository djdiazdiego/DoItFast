using System.ComponentModel.DataAnnotations;

namespace DoItFast.Application.Dtos.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
