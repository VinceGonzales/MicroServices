using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interchange.Entity
{
    public class InterchangeName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int IntrChgId { get; set; }
        public virtual int LineItemNbr { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public virtual string Relationship { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string FName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string MName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string LName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(75)]
        public virtual string Email { get; set; }
    }
}