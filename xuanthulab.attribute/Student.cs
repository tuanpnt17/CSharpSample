using System.ComponentModel.DataAnnotations;

namespace xuanthulab.attribute
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }

        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public required string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        [MinAge(18, ErrorMessage = "Invalid birthdate")]
        public DateTime BirthDate { get; set; }
    }
}
