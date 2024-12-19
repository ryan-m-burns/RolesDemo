using RolesDemo.ViewModels;

public interface IRoleRepo
{
    List<RoleVM> GetAllRoles();
    RoleVM GetRole(string roleName);
    bool CreateRole(string roleName);
    Task<(bool success, string error)> DeleteRole(string roleName);
}