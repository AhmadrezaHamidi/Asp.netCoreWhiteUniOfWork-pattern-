using System.ComponentModel.DataAnnotations;

namespace TamsaApi.Dtos
{
    public class LoginInWhiteEmailAddressPutDto
    {
        [Required]
        public string emailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool RememeberMe { get; set; }
    }
}