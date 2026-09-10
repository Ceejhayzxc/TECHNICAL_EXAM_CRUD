using EXAM.CRUD.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EXAM.CRUD.Models
{
    public class Persons : BaseEntity
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name must containts atleast minimum of 2 characters")]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [DisplayName("Middle Name")]
        public string? middleName { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "last name must containts atleast minimum of 2 characters")]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public PersonsGender Gender { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [RegularExpression(@"^09\d{9}", ErrorMessage = "Contact Number must contain at least 11-digits")]
        [DisplayName("Contact Number")]
        public string contactNumber { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        [DisplayName("Birth date")]
        public DateOnly birthDate { get; set; }
        public string? Occupation { get; set; }
    }
}
