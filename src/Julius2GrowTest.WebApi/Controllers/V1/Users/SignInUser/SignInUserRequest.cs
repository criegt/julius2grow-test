using System.ComponentModel.DataAnnotations;

namespace Julius2GrowTest.WebApi.Controllers.V1.Users.SignInUser
{
    public class SignInUserRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
