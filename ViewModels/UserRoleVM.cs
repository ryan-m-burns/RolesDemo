using System.ComponentModel.DataAnnotations;
namespace RolesDemo.ViewModels
{
  public class UserRoleVM
  {
    public int? Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Display(Name = "Role")]
    public string Role { get; set; }
  }
}