using System.ComponentModel.DataAnnotations;

namespace RolesDemo.Models
{
    public class MyRegisteredUser
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
