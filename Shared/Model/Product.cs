using System.ComponentModel.DataAnnotations;

namespace project.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProductCode { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Selling price must be greater than zero.")]
        public decimal SellingPrice { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be non-negative.")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Purchasing price must be greater than zero.")]
        public decimal PurchasingPrice { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Volume must be greater than zero.")]
        public double Volume { get; set; }

        [MaxLength(10)]
        public string VolumeType { get; set; } // kg or mm

        [MaxLength(100)]
        public string VendorName { get; set; }

        [MaxLength(15)]
        public string VendorNumber { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Range(0, int.MaxValue, ErrorMessage = "Notify limit must be non-negative.")]
        public int NotifyLimit { get; set; }

        public byte[] ProductPic { get; set; } // for storing image in byte array

        [MaxLength(50)]
        public string ProductType { get; set; }
    }
}
