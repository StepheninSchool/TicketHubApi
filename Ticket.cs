using System.ComponentModel.DataAnnotations;

namespace TicketHubApi
{
    public class Ticket
    {
        [Display(Name = "Concert ID")]
        public int ConcertId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Range(1, 10)]
        [Display(Name = "Ticket Quantity")]
        public int Quantity { get; set; }

        [Required]
        [CreditCard]
        [Display(Name = "Credit Card Number")]
        public string CreditCard { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Expiration Date")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Expiration Date must be in MM/YY format")]
        public string Expiration { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Security Code")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "Security Code must be 3 or 4 digits")]
        public string SecurityCode { get; set; } = string.Empty;

        [Display(Name = "Street Address")]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "City")]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [Display(Name = "Province/State")]
        [StringLength(100)]
        public string Province { get; set; } = string.Empty;

        [Display(Name = "Postal Code")]
        [StringLength(7, MinimumLength = 6)]
        public string PostalCode { get; set; } = string.Empty;

        [Display(Name = "Country")]
        [StringLength(100)]
        public string Country { get; set; } = string.Empty;
    }
}

