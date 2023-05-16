using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.Entity.Entities
{
    public class SubSystem
    {
        [Key]
        [Required]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [MaxLength(500)]
        public string? Description { get; set; }

        public virtual ICollection<Device>? Devices { get; set; }
    }
}
