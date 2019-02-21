using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interchange.Entity
{
    public class InterchangeHeader : IInterchangeHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int IntrChgId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(2)]
        public virtual string DeptId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(3)]
        public virtual int AppId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string ApplicationNbr { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string BarCode { get; set; }
        public virtual bool IsBldCrd { get; set; }
        public virtual bool IsBldPermit { get; set; }
        public virtual int NoOfPermits { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string ReceiptRefNbr { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public virtual string RPRNbr { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public virtual string BuildingCardNbr { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public virtual string Grouping { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string CustomerNbr { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string Origin { get; set; }
        public virtual decimal FeeAmt { get; set; }
        public virtual decimal AmtPaid { get; set; }
        public virtual decimal Balance { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public virtual string Warning { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string UDFText1 { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string UDFText2 { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string UDFText3 { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string UDFText4 { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string UDFText5 { get; set; }
        public virtual DateTime? UDFDate1 { get; set; }
        public virtual DateTime? UDFDate2 { get; set; }
        public virtual DateTime? UDFDate3 { get; set; }
        public virtual DateTime? UDFDate4 { get; set; }
        public virtual DateTime? UDFDate5 { get; set; }
        public virtual int? UDFNum1 { get; set; }
        public virtual int? UDFNum2 { get; set; }
        public virtual int? UDFNum3 { get; set; }
        public virtual int? UDFNum4 { get; set; }
        public virtual int? UDFNum5 { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public virtual string UpdatedBy { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
    }
}