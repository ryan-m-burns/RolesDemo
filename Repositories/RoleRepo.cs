using Microsoft.AspNetCore.Identity;
using RolesDemo.Data;
using RolesDemo.ViewModels;
using RolesDemo.Repositories.Interfaces;

namespace RolesDemo.Repositories
{
  public class RoleRepo : IRoleRepo
  {
    private readonly ApplicationDbContext _context;

    private readonly UserManager<IdentityUser> _userManager;
    public RoleRepo(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
      _context = context;
      _userManager = userManager;
      CreateInitialRole();
    }
    public List<RoleVM> GetAllRoles()
    {
      var roles = _context.Roles.Select(r => new RoleVM
      {
        Id = r.Id,
        RoleName = r.Name
      }).ToList();
      return roles;
    }
    public RoleVM GetRole(string roleName)
    {
      var role =
      _context.Roles.Where(r => r.Name == roleName)
      .FirstOrDefault();
      if (role != null)
      {
        return new RoleVM()
        {
          Id = role.Id,
          RoleName = role.Name
        };
      }
      return null;
    }
    public bool CreateRole(string roleName)
    {
      bool isSuccess = true;
      try
      {
        _context.Roles.Add(new IdentityRole
        {
          Name = roleName,
          Id = roleName,
          NormalizedName = roleName.ToUpper()
        });
        _context.SaveChanges();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error creating role:" +
        $" {ex.Message}");
        isSuccess = false;
      }
      return isSuccess;
    }

    public async Task<(bool success, string error)> DeleteRole(string roleName)
    {
      try
      {
        var role = _context.Roles
          .Where(r => r.Name == roleName)
          .FirstOrDefault();

        if (role == null)
        {
          return (false, "Role not found.");
        }

        // Check if any users are in this role
        var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
        if (usersInRole.Any())
        {
          return (false, $"Cannot delete role '{roleName}' because it is assigned to {usersInRole.Count} user(s).");
        }

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
        return (true, string.Empty);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error deleting role: {ex.Message}");
        return (false, $"An error occurred while deleting the role: {ex.Message}");
      }
    }
    private void CreateInitialRole()
    {
      const string ADMIN = "Admin";
      var role = GetRole(ADMIN);
      if (role == null)
      {
        CreateRole(ADMIN);
      }
    }
  }
}