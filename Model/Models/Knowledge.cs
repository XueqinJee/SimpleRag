using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Knowledge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string? Icon { get; set; }
        public int EmbeddedId { get; set; }

        public string? Description { get; set; }
    }
}
