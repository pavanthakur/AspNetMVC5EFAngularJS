using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EH.Entity
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email ID is Required")]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        [Index("UQ_Email", IsUnique = true)]
        public string Email { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(30)]
        public string PhoneNumber { get; set; }

        [Required]
        [ForeignKey("StatusType")]
        public int StatusID { get; set; }
        public virtual Status StatusType { get; set; }
    }
}
