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

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Full Name must be between 2 and 50 characters")]
        [Display(Name = "Full Name")]
        [RegularExpression(@"^[a-zA-Z\s.'-]+$", ErrorMessage = "Full Name can only contain letters, spaces, periods, apostrophes, and hyphens")]
        public string Name { get; set; } = string.Empty;
       

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Range(1, 4)]
        [Display(Name = "Ticket Quantity")]
        public int Quantity { get; set; }

        [Required]
        [CreditCard]
        [Display(Name = "Credit Card Number")]
        public string CreditCard { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiration Date is required")]
        [Display(Name = "Expiration Date")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Expiration Date must be exactly 5 characters in MM/YY format")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Expiration Date must be in MM/YY format")]
        public string Expiration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Security Code is required")]
        [Display(Name = "Security Code")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "Security Code must be 3 or 4 digits")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Security Code must contain only numeric digits (3 or 4 digits)")]
        public string SecurityCode { get; set; } = string.Empty;

        [Display(Name = "Street Address")]
        [StringLength(100, ErrorMessage = "Street Address cannot exceed 200 characters")]
        [RegularExpression(@"^[a-zA-Z0-9\s,#.-]+$", ErrorMessage = "Address can contain letters, numbers, spaces, commas, periods, hyphens, and pound signs only.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "City name cannot exceed 100 characters")]
        [RegularExpression(@"^[a-zA-Z\s.'-]+$", ErrorMessage = "City can only contain letters, spaces, periods, apostrophes, and hyphens")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province/State is required")]
        [Display(Name = "Province/State")]
        [StringLength(100, ErrorMessage = "Province/State name cannot exceed 100 characters")]
        [RegularExpression(@"^[a-zA-Z\s.'-]+$", ErrorMessage = "Province/State can only contain letters, spaces, periods, apostrophes, and hyphens")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal Code is required")]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"(^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$)|(^\d{5}(-\d{4})?$)", ErrorMessage = "Enter a valid Canadian/U.S. postal/zip code")]
        public string PostalCode { get; set; } = string.Empty;


        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        [StringLength(100, ErrorMessage = "Country name cannot exceed 100 characters")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Country can only contain letters, spaces, hyphens, and apostrophes")]
        public string Country { get; set; } = string.Empty;
    }
}

