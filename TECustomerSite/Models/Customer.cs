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

        [Required]
        [StringLength(25)]
        public string CustFirstName { get; set; } = null!;

        [Required]
        [StringLength(25)]
        public string CustLastName { get; set; }

        [Required]
        [StringLength(75)]
        public string CustAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string CustCity { get; set; }

        [Required]
        [StringLength(2)]
        public string CustProv { get; set; }

        [Required]
        [StringLength(7)]
        //[RegularExpression("/^[A-Z]\\d[A-Z] ?\\d[A-Z]\\d$/", ErrorMessage = "Please enter a valid Postal Code")]
        public string CustPostal { get; set; }

        [Required]
        [StringLength(25)]
        public string? CustCountry { get; set; }

        [Required]
        [StringLength(20)]
        //[RegularExpression("/(?:\\d{1}\\s)?\\(?(\\d{3})\\)?-?\\s?(\\d{3})-?\\s?(\\d{4})/g", ErrorMessage = "Please Enter a valid phone number")]
        public string? CustHomePhone { get; set; }
        
        [StringLength(20)]
        public string? CustBusPhone { get; set; }

        [StringLength(50)]
        public string? CustEmail { get; set; }

        public int? AgentId { get; set; }

        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }

        // Double check password (enter twice?)
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }

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
