using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.Entity.Entities
{
    public class Password
    {
        [Key]
        [Required]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Hash")]
        [MaxLength(100)]
        public byte[] Hash { get; set; } = Array.Empty<byte>();

        [Required]
        [Column("Salt")]
        public byte[] Salt { get; set; } = Array.Empty<byte>();

        [ForeignKey("UserId")]
        [Column("UserId")]
        public int UserId { get; set; }

        public virtual User? User { get; set; } 
    }
}
