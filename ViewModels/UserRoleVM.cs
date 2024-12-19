using System.ComponentModel.DataAnnotations;

namespace RolesDemo.ViewModels
{
  public class UserRoleVM
  {
    [Required]
    [Display(Name = "User ID")]
    public int? ID { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Role { get; set; }
  }
}