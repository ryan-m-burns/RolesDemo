using System.ComponentModel.DataAnnotations;
namespace RolesDemo.ViewModels
{
  public class UserVM
  {
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
  }
}