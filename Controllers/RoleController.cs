using Microsoft.AspNetCore.Mvc;
using RolesDemo.Repositories;
using RolesDemo.ViewModels;
using RolesDemo.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace RolesDemo.Controllers
{
  public class RoleController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IRoleRepo _roleRepo;
    public RoleController(ILogger<HomeController> logger,
    IRoleRepo roleRepo)
    {
      _logger = logger;
      _roleRepo = roleRepo;
    }
    public IActionResult Index()
    {
      List<RoleVM> roleVM = _roleRepo.GetAllRoles();
      return View(roleVM);
    }

    [HttpGet]
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(RoleVM roleVM)
    {
      if (ModelState.IsValid)
      {
        bool isSuccess = _roleRepo.CreateRole(roleVM.RoleName);
        if (isSuccess)
        {
          return RedirectToAction(nameof(Index));
        }
        else
        {
          ModelState.AddModelError("", "Role creation failed." +
          " The role may already exist.");
        }
      }
      return View(roleVM);
    }

    [HttpGet]
    public ActionResult Delete(string id)
    {
      if (string.IsNullOrEmpty(id))
      {
        return NotFound();
      }

      RoleVM roleVM = _roleRepo.GetRole(id);
      if (roleVM == null)
      {
        return NotFound();
      }

      return View(roleVM);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(string id)
    {
      if (string.IsNullOrEmpty(id))
      {
        return NotFound();
      }

      var (isSuccess, error) = await _roleRepo.DeleteRole(id);
      if (isSuccess)
      {
        TempData["SuccessMessage"] = "Role deleted successfully.";
        return RedirectToAction(nameof(Index));
      }
      else
      {
        var role = _roleRepo.GetRole(id);
        ViewBag.Message = error;  // Just pass the error as a message
        return View(role);
      }
    }
  }
}