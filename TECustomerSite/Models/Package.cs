using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TECustomerSite.Models
{
    public partial class Package
    {
        public Package()
        {
            Bookings = new HashSet<Booking>();
            ProductSuppliers = new HashSet<ProductsSupplier>();
        }

        [Key]
        public int PackageId { get; set; }
        [StringLength(50)]
        public string PkgName { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? PkgStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PkgEndDate { get; set; }
        [StringLength(50)]
        public string? PkgDesc { get; set; }
        [Column(TypeName = "money")]
        public decimal PkgBasePrice { get; set; }
        [Column(TypeName = "money")]
        public decimal? PkgAgencyCommission { get; set; }

        [InverseProperty("Package")]
        public virtual ICollection<Booking> Bookings { get; set; }

        [ForeignKey("PackageId")]
        [InverseProperty("Packages")]
        public virtual ICollection<ProductsSupplier> ProductSuppliers { get; set; }
    }
}
