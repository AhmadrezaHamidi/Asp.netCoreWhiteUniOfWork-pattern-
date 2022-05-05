using System.ComponentModel.DataAnnotations;

namespace TamsaApi.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        public string UserName { get; set; }
        
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        
        
        [Required]
        [MaxLength(12)]
        public string PhoneNumber { get; set; }
        
        
        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(12)]
        public string Password { get; set; }
        
        
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [MinLength(12)]
        public string RepeatPassword { get; set; }
        
    }
}