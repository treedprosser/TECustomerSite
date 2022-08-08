using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TECustomerSite.Models
{
    public partial class Fee
    {
        public Fee()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        [Key]
        [StringLength(10)]
        public string FeeId { get; set; } = null!;
        [StringLength(50)]
        public string FeeName { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal FeeAmt { get; set; }
        [StringLength(50)]
        public string? FeeDesc { get; set; }

        [InverseProperty("Fee")]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
