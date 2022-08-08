using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TECustomerSite.Models
{
    [Index("AgentId", Name = "EmployeesCustomers")]
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            CreditCards = new HashSet<CreditCard>();
            CustomersRewards = new HashSet<CustomersReward>();
        }

        [Key]
        public int CustomerId { get; set; }
        [StringLength(25)]
        public string CustFirstName { get; set; } = null!;
        [StringLength(25)]
        public string CustLastName { get; set; } = null!;
        [StringLength(75)]
        public string CustAddress { get; set; } = null!;
        [StringLength(50)]
        public string CustCity { get; set; } = null!;
        [StringLength(2)]
        public string CustProv { get; set; } = null!;
        [StringLength(7)]
        public string CustPostal { get; set; } = null!;
        [StringLength(25)]
        public string? CustCountry { get; set; }
        [StringLength(20)]
        public string? CustHomePhone { get; set; }
        [StringLength(20)]
        public string CustBusPhone { get; set; } = null!;
        [StringLength(50)]
        public string CustEmail { get; set; } = null!;
        public int? AgentId { get; set; }
        [Column("username")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Username { get; set; }
        [Column("password")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Password { get; set; }

        [ForeignKey("AgentId")]
        [InverseProperty("Customers")]
        public virtual Agent? Agent { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<CustomersReward> CustomersRewards { get; set; }
    }
}
