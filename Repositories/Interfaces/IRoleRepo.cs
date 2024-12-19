using RolesDemo.ViewModels;

namespace RolesDemo.Repositories.Interfaces
{
  public interface IRoleRepo
  {
    /// <summary>
    /// Gets all roles from the system
    /// </summary>
    /// <returns>List of roles as RoleVM objects</returns>
    List<RoleVM> GetAllRoles();

    /// <summary>
    /// Gets a specific role by name
    /// </summary>
    /// <param name="roleName">Name of the role to retrieve</param>
    /// <returns>RoleVM if found, null if not found</returns>
    RoleVM GetRole(string roleName);

    /// <summary>
    /// Creates a new role in the system
    /// </summary>
    /// <param name="roleName">Name of the role to create</param>
    /// <returns>True if creation was successful, false otherwise</returns>
    bool CreateRole(string roleName);

    /// <summary>
    /// Creates the initial Admin role if it doesn't exist
    /// </summary>
    void CreateInitialRole();
  }
}