using CroweContacts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CroweContacts.Models.ContactVM
{
    [Table("Contact")]
    public class ContactVm
    {
        [Key]
        public int ContactId { get; set; }
        
        [Required(ErrorMessage = "Enter First Name.")]
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Enter Last Name.")]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3,ErrorMessage = "Must be at least 3 characters.")]
        public string LastName { get; set; }
        
        [Display(Name = "Social")]
        [Required(ErrorMessage = "Must enter your social security number.")]
        [RegularExpression(@"^\d{3}\-?\d{2}\-?\d{4}$", ErrorMessage = "Must be in form 999-99-9999.")]
        [MinLength(11, ErrorMessage = "Must be in form 999-99-9999.")]
        [StringLength(11)]
        public string SSN { get; set; }

        [Display(Name = "Birth Date"), DataType(DataType.Date),Required(ErrorMessage = "Please enter your birthday.")]
        public DateTime DOB { get; set; }
        
        [Required,EmailAddress(ErrorMessage = "Enter valid email address.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please Enter Street."), Display(Name = "Street")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter City.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter State.")]
        public string State { get; set; }
      
        [Required, Display(Name = "Zip")]
        public string PostalCode { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Date Created")]
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public List<PhoneVm> Phones { get; set; }
    }
}