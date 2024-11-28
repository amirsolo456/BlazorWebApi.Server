using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Domain.Entities
{
    public class GiftCarts
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        [StringLength(50)] // Max length for Code
        public string Code { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")] // Precision for Balance
        [Range(0, double.MaxValue)] // Prevent negative balances
        public decimal? Price { get; set; } = 0;
        [Required]
        [Column(TypeName = "decimal(18,3)")] // Precision for Balance
        [Range(0, double.MaxValue)] // Prevent negative balances
        public decimal Balance { get; set; }
        [Required]
        [StringLength(10)] // Limit length of Currency (e.g., 'IRR', 'USD')
        public string Currency { get; set; } = "IRR"; // Default to IRR
        [Required]
        [MaxLength(20)]
        public string IssueDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string ExpirationDate { get; set; }
        [Required]
        [EnumDataType(typeof(GiftCardStatus))] // Enum for Status
        public GiftCardStatus Status { get; set; } = GiftCardStatus.Active;
        public int? UsageLimit { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        [Range(0, double.MaxValue)]
        public decimal UsedAmount { get; set; } = 0; // Default used amount is 0

        [Required]
        [StringLength(50)] // Max length for CreatedBy
        public string CreatedBy { get; set; }
        [MaxLength(200)]
        public string Description { get; set; } // Optional description

        public bool IsTransferable { get; set; } = false; // Default not transferable

        // Navigation property for the related Customer
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }

    public enum GiftCardStatus
    {
        Active,
        Expired,
        Used
    }
}
