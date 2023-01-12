
using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogModule.Domain
{
    [Index("Slug" , IsUnique =true)]
    class Post: BaseEntity
    {
        [MaxLength(80)]
        public string Title { get; set; }
        
        public string Descriptions { get; set; }

        [MaxLength(80)]
        public string OwnerName { get; set; }

        public long Visit { get; set; }
        [MaxLength(110)]
        public string ImageName { get; set; }

        [MaxLength(80)]
        public string Slug { get; set; }

        public bool IsDelete { get; set; } = false;
        public Guid UserId { get; set; }

        public Guid CategoryId { get; set; }

    }
}
