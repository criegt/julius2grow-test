﻿using System;

namespace Julius2GrowTest.Domain.Posts
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
    }
}
