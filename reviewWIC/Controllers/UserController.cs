using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using reviewWIC.Areas.Identity.Data;
using reviewWIC.Models;
using reviewWIC.Models.Repositories;

namespace reviewWIC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(IUnitOfWork unitOfWork, SignInManager<ApplicationUser> signInManager) 
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var users = _unitOfWork.User.GetUsers();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ApplicationUser user = _unitOfWork.User.GetById(id);
            IEnumerable<IdentityRole> roles = _unitOfWork.Role.GetRoles();
            var roleList = new List<SelectListItem>();
            var userRoles = await _signInManager.UserManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                var isChecked = userRoles.Any(ur => ur.Contains(role.Name));
                roleList.Add(new SelectListItem(role.Name, role.Id, isChecked));
            }
            var model = new EditUserViewModel
            {
                User = user,
                Roles = roleList
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(EditUserViewModel model)
        {
            var user = _unitOfWork.User.GetById(model.User.Id);
            if (user == null)
            {
                return NotFound();
            }

            // user
            var userRolesInDb = await _signInManager.UserManager.GetRolesAsync(user);

            var rolesToAdd = new List<string>();
            var rolesToDelete = new List<string>();

            foreach (var role in model.Roles)
            {
                var assignedInDb = userRolesInDb.FirstOrDefault(ur => ur == role.Text);
                if (role.Selected)
                {
                    if (assignedInDb == null)
                    {
                        rolesToAdd.Add(role.Text);
                    }
                }
                else
                {
                    if (assignedInDb != null)
                    {
                        rolesToDelete.Add(role.Text);
                    }
                }
            }

            if (rolesToAdd.Any())
            {
                await _signInManager.UserManager.AddToRolesAsync(user, rolesToAdd);
            }

            if (rolesToDelete.Any())
            {
                await _signInManager.UserManager.RemoveFromRolesAsync(user, rolesToDelete);
            }

            _unitOfWork.User.UpdateUser(user);
            return RedirectToAction("Edit", new { id = user.Id });
        }
    }
}
