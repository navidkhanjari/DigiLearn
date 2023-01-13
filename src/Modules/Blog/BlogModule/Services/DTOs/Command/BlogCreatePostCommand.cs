using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogModule.Services.DTOs.Command
{
    public class BlogCreatePostCommand
    {
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string OwnerName { get; set; }
        public long Visit { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Slug { get; set; }
        public bool IsDelete { get; set; } = false;
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
