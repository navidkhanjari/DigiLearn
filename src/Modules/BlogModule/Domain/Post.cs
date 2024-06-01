using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.Domain;

namespace BlogModule.Domain
{
    public class Post : BaseEntity
    {
        [MaxLength(80)]
        public string Title { get; set; }
        public Guid UserId { get; set; }

        [MaxLength(80)]
        public string AutherName { get; set; }

        public string Description { get; set; }

        [MaxLength(80)]
        public string Slug { get; set; }
        public long Visit { get; set; }

        [MaxLength(110)]
        public string ImageName { get; set; }
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
