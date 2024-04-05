using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class RegisterModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name required.")]
        public string LastName { get; set; }

        
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

  
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
