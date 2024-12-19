using RolesDemo.Models;

namespace RolesDemo.Repositories.Interfaces
{
  public interface IMyRegisteredUserRepo
  {
    void AddUser(MyRegisteredUser user);
    MyRegisteredUser GetUser(string email);
  }
}