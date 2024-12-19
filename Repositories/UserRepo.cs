using Microsoft.AspNetCore.Identity;
using RolesDemo.Data;
using RolesDemo.ViewModels;
namespace RolesDemo.Repositories
{
  public class UserRepo
  {
    private readonly ApplicationDbContext _context;

    public UserRepo(ApplicationDbContext context)
    {
      _context = context;
    }
    public List<UserVM> GetAllUsers()
    {
      var users = _context.Users.Select(u => new UserVM
      {
        Email = u.Email
      }).ToList();
      return users;
    }
  }
}
