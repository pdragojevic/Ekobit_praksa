using System.ComponentModel.DataAnnotations;

namespace Business.Services.Models.User
{
    public class UserDtoLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
