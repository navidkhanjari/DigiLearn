using Microsoft.AspNetCore.Http;
using System;

namespace BlogModule.Services.DTOs.Command
{
    public class BlogEditPostCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string OwnerName { get; set; }
        public long Visit { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Slug { get; set; }
        public bool IsDelete { get; set; } = false;
      
    }
}
