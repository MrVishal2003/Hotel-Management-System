using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class Login
    {

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
