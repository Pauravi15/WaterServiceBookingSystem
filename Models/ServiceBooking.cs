using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterServiceBookingSystem.Models
{
    public class ServiceBooking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        [Column(TypeName = "TEXT")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [Column(TypeName = "TEXT")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Column(TypeName = "TEXT")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Address")]
        [Column(TypeName = "TEXT")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Service Type")]
        [Column(TypeName = "TEXT")]
        public string ServiceType { get; set; }

        [Required]
        [Display(Name = "Preferred Date")]
        public DateTime PreferredDate { get; set; }

        [Display(Name = "Additional Notes")]
        [Column(TypeName = "TEXT")]
        public string? Notes { get; set; }
    }
}