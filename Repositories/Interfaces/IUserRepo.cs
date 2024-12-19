using RolesDemo.ViewModels;

namespace RolesDemo.Repositories.Interfaces
{
  /// <summary>
  /// Interface for managing user-related data operations
  /// </summary>
  public interface IUserRepo
  {
    /// <summary>
    /// Retrieves all users from the system
    /// </summary>
    /// <returns>List of users as UserVM objects</returns>
    List<UserVM> GetAllUsers();
  }
}