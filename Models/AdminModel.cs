using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }
        
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
