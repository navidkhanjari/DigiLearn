using Common.Domain;
using System.ComponentModel.DataAnnotations;

namespace UserModule.Data.Entitities
{
    public class Role:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
