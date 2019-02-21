using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interchange.Entity
{
    public class InterchangeAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int IntrChgId { get; set; }
        public virtual int LineItemNbr { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public virtual string AddressType { get; set; }
        public virtual int? NbrRangeStart { get; set; }
        public virtual int? NbrRangeEnd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(5)]
        public virtual string FracRangeStart { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(5)]
        public virtual string FracRangeEnd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(5)]
        public virtual string UnitRangeStart { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(5)]
        public virtual string UnitRangeEnd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(2)]
        public virtual string StrDir { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(40)]
        public virtual string StrName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(4)]
        public virtual string StrSuff { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(5)]
        public virtual string StrSuffDir { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string CityName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(2)]
        public virtual string StateCode { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(9)]
        public virtual string ZipCode { get; set; }
    }
}