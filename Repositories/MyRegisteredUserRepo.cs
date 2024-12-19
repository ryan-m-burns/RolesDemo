using Microsoft.AspNetCore.Identity;
using RolesDemo.Data;
using RolesDemo.ViewModels;
using RolesDemo.Repositories.Interfaces;
using RolesDemo.Models;

namespace RolesDemo.Repositories
{
  public class MyRegisteredUserRepo : IMyRegisteredUserRepo
  {
    private readonly ApplicationDbContext _context;
    public MyRegisteredUserRepo(ApplicationDbContext context)
    {
      _context = context;
    }

    public void AddUser(MyRegisteredUser user)
    {
      // Input validation
      if (user == null)
      {
        throw new ArgumentNullException(nameof(user), "User cannot be null");
      }

      if (string.IsNullOrWhiteSpace(user.Email))
      {
        throw new ArgumentException("Email is required", nameof(user));
      }

      // Check if user already exists
      if (_context.MyRegisteredUsers.Any(u => u.Email == user.Email))
      {
        throw new InvalidOperationException($"User with email {user.Email} already exists");
      }

      // Add the user
      _context.MyRegisteredUsers.Add(user);
      _context.SaveChanges();
    }

    public MyRegisteredUser GetUser(string email)
    {
      // Input validation
      if (string.IsNullOrWhiteSpace(email))
      {
        throw new ArgumentException("Email is required", nameof(email));
      }

      // Get the user
      return _context.MyRegisteredUsers.FirstOrDefault(u => u.Email == email);
    }
  }
}