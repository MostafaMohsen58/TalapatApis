using System.ComponentModel.DataAnnotations;

namespace TalapatApis.DTOS
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
       // [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+~`\\-={}[\\]:;'\"<>,.?/]).*$",
            ErrorMessage ="password must contain 1 uppercase, 1 lowercase, 1 digit, 1 special charchter")]//Secure@2023
        public string Password { get; set; }

    }
}
