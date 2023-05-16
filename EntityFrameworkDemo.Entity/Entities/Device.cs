using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        public string? Description { get; set; }

        [ForeignKey("SubSystemId")]
        [Column("SubSystemId")]
        public int SubSystemId { get; set; }
        public virtual SubSystem? SubSystem { get; set; }
    }
}
