using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Julius2GrowTest.WebApi.Controllers.V1.Posts.AddPost
{
    public class AddPostRequest
    {
        [FromForm(Name = "title")]
        public string Title { get; set; }

        [FromForm(Name = "content")]
        public string Content { get; set; }

        [FromForm(Name = "image")]
        public IFormFile Image { get; set; }
    }
}
