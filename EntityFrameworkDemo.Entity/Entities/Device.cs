using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EntityFrameworkDemo.Entity.Entities
{
    public class Device
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

        [ForeignKey("SubSystemId")]
        [Column("SubSystemId")]
        public int SubSystemId { get; set; }
        public virtual SubSystem? SubSystem { get; set; }
    }
}
