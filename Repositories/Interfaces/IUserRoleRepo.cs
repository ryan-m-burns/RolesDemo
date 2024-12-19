using RolesDemo.ViewModels;

namespace RolesDemo.Repositories.Interfaces
{
  public interface IUserRoleRepo
  {
    Task<bool> AddUserRoleAsync(string email, string roleName);
    Task<bool> RemoveUserRoleAsync(string email, string roleName);
    Task<IEnumerable<RoleVM>> GetUserRolesAsync(string email);
  }
}