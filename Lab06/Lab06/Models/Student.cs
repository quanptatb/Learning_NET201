using System.ComponentModel.DataAnnotations;

namespace Lab06.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")] // Ví dụ validate số điện thoại
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter website url")]
        [Url(ErrorMessage = "Invalid URL")]
        public string WebsiteUrl { get; set; }

        [Required(ErrorMessage = "Please choose gender")]
        public string Gender { get; set; } // Có thể dùng Enum hoặc bool nếu muốn

        [Required(ErrorMessage = "Please enter date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter batch time")]
        [DataType(DataType.Time)]
        public DateTime BatchTime { get; set; }
    }
}