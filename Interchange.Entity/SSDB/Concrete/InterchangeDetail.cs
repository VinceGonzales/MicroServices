using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interchange.Entity
{
    public class InterchangeDetail : IInterchangeDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int IntrChgId { get; set; }
        public virtual int LineItemNbr { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(45)]
        public virtual string FeeType { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public virtual string FeeGrp { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public virtual string FeeCod { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public virtual string FeePeriod { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public virtual string FeeCat { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(16)]
        public virtual string Dept { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(8)]
        public virtual string Fund { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(8)]
        public virtual string RevenueCode { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(2)]
        public virtual string SubRevenueCode { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(4)]
        public virtual string BalanceSheet { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string Description { get; set; }
        public virtual decimal FeeSort { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(4)]
        public virtual string PmtStatus { get; set; }
        public virtual decimal FeeAmt { get; set; }
        public virtual decimal AmtPaid { get; set; }
        public virtual decimal Balance { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public virtual string TransRefNbr { get; set; }
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