using System.ComponentModel.DataAnnotations;

namespace Julius2GrowTest.WebApi.Controllers.V1.Users.SignUpUser
{
    public class SignUpUserRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
