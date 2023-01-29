using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models
{
    public class ContactForm
    {
		private string _countryCodeSelected;
		[Required]
        [EmailAddress]
        [Display(Name = "Email", Prompt = "example@example.com")]
        public string? Email { get; set; }
        [Required]
        public string? Name { get; set; }
		[Required]
		[Display(Name = "Issuing Country")]
		public string CountryCodeSelected
		{
			get => _countryCodeSelected;
			set => _countryCodeSelected = value.ToUpperInvariant();
		}

		[Required]
		[Display(Name = "Number to Check")]
		public string? PhoneNumberRaw { get; set; }

		// Holds the validation response. Not for data entry.
		[Display(Name = "Valid Number")]
		public bool Valid { get; set; }

		// Holds the validation response. Not for data entry.
		[Display(Name = "Has Extension")]
		public bool HasExtension { get; set; }

		// Optionally, add more fields here for returning data to the user.
       [Required]
		//Number to Check
		public string? MobileNumber { get; set; }

        [Required]
        [StringLength(220, MinimumLength = 20)]
        public string? Message { get; set; }

    }

    public class QuoteForm
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string phonenumber { get; set; }

        public string BusinessIndividual { get; set; }
        public string ERPExist { get; set; }
      
        public string[] Services { get; set; }

        public string Message { get; set; }

    }
}
