using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CroweContacts.Models.ContactVM
{
    [Table("Phone")]
    public class PhoneVm
    {
        [Key]
        public int PhoneId { get; set; }

        [Required]
        public string Device { get; set; }
        [Required]
        public string Number { get; set; }
        public string Extension { get; set; }

        public int ContactId { get; set; }
        [ForeignKey("ContactId")]
        public virtual ContactVm ContactVm  { get; set; }
    }
}