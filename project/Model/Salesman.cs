using System.ComponentModel.DataAnnotations;

namespace project.Model
{
    public class Salesman
    {
        [Key] // Denotes the primary key
        public int SalesmanId { get; set; } // Unique identifier for the Salesman

        [Required(ErrorMessage = "Salesman Name is required.")]
        [StringLength(100, ErrorMessage = "Salesman Name can't be longer than 100 characters.")]
        public string SalesmanName { get; set; } // Salesman Name

        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; } // Salesman Phone Number

        [StringLength(200, ErrorMessage = "Address can't be longer than 200 characters.")]
        public string Address { get; set; } // Salesman Address

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string EmailAddress { get; set; } // Salesman Email Address

        [Phone(ErrorMessage = "Invalid emergency contact number format.")]
        public string EmergencyNumber { get; set; } // Emergency Contact Number

        [StringLength(50, ErrorMessage = "Designation can't be longer than 50 characters.")]
        public string Designation { get; set; } // Designation (Job Title)

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public decimal Salary { get; set; } // Salesman Salary

        [Required(ErrorMessage = "Commission is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Commission must be a positive value.")]
        public decimal Commission { get; set; } // Salesman Commission

        [Required(ErrorMessage = "Current Invoice Number is required.")]
        [StringLength(8, ErrorMessage = "Invoice Number must be exactly 8 digits.")]
        public string CurrentInvoiceNumber { get; set; } // Salesman's Current Invoice Number

        [Required(ErrorMessage = "Set Invoice Number is required.")]
        [StringLength(8, ErrorMessage = "Set Invoice Number must be exactly 8 digits.")]
        public string SetInvoiceNumber { get; set; } // Salesman's Set Invoice Number
        // Method to set the invoice number
        public void SetInvoiceNumberMethod(string newInvoiceNumber)
        {
            if (newInvoiceNumber.Length == 8 && int.TryParse(newInvoiceNumber, out _))
            {
                CurrentInvoiceNumber = newInvoiceNumber;
            }
            else
            {
                throw new ArgumentException("Invoice number must be exactly 8 digits.");
            }
        }
    }
}
