using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVMEntityLayer
{
    [Table("Product", Schema = "SalesLT")]
    public partial class Product
    {
        public int? ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Name { get; set; }

        [Display(Name = "Product Number")]
        [StringLength(25, MinimumLength = 3)]
        public string ProductNumber { get; set; }

        [StringLength(15, MinimumLength = 3)]
        public string Color { get; set; }

        [Display(Name = "Cost")]
        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 9999)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal StandardCost { get; set; }

        [Display(Name = "Price")]
        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 9999)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ListPrice { get; set; }

        [StringLength(5)]
        public string Size { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        [Range(0.5, 2000)]
        public decimal? Weight { get; set; }

        [Display(Name = "Start Selling Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime SellStartDate { get; set; }

        [Display(Name = "End Selling Date")]
        [DataType(DataType.Date)]
        public DateTime? SellEndDate { get; set; }

        [Display(Name = "Date Discontinued")]
        [DataType(DataType.Date)]
        public DateTime? DiscontinuedDate { get; set; }
    }

}
