using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogModule.Services.DTOs.Command
{
    public class BlogCreateCategoryCommand
    {
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
