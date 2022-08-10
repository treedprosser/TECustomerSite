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

        [Required(ErrorMessage = "This field is required")]
        [StringLength(25)]
        public string CustFirstName { get; set; } = null!;

        [Required(ErrorMessage = "This field is required")]
        [StringLength(25)]
        public string CustLastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(75)]
        public string CustAddress { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string CustCity { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(2)]
        public string CustProv { get; set; }

        [Required(ErrorMessage = "This field is required")]
        //[RegularExpression(@"^([a-zA-Z]\\d[a-zA-Z]\\s?\\d[a-zA-Z]\\d)$", ErrorMessage = "Please enter a valid Postal Code")]
        [StringLength(7, MinimumLength = 6, ErrorMessage = "Please enter a valid Postal Code")]
        public string CustPostal { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(25)]
        public string? CustCountry { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        [StringLength(20)]
        public string? CustHomePhone { get; set; }

        [StringLength(20)]
        public string? CustBusPhone { get; set; } = "_";

        [StringLength(50)]
        public string? CustEmail { get; set; } = "_";

        public int? AgentId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage ="Passwords must match")]
        public string ComparePassword { get; set; }

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
