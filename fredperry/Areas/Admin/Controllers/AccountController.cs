using fredperry.Core.Entities.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace fredperry.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // CRUD actions for managing users
        // Example: Index, Create, Edit, Delete

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        // GET: /Admin/Account/Detail/{id}
        public async Task<IActionResult> Detail(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public async Task<IActionResult> Create()
        {
            var model = new CreateAccountViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Assign the Admin role to the new user
                    await _userManager.AddToRoleAsync(user, "Admin");

                    // Redirect to the user list or other appropriate action
                    return RedirectToAction("Index");
                }

                // If creation fails, add model errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If model state is not valid, return to the create view with errors
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var currentRole = roles.FirstOrDefault(); // Get the first role, assuming a user has only one role

            var model = new EditAccountViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                CurrentRole = currentRole,
                AllRoles = _roleManager.Roles.Select(r => r.Name).ToList()
            };

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by ID
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    return NotFound();
                }

                if (model.SelectedRole != null)
                {
                    // Retrieve the current roles of the user
                    var roles = await _userManager.GetRolesAsync(user);
                    var currentRole = roles.FirstOrDefault();

                    await _userManager.RemoveFromRoleAsync(user, currentRole);
                    await _userManager.AddToRoleAsync(user, model.SelectedRole);
                }
       
                // Update other user details if necessary
                user.UserName = model.UserName;
                user.Email = model.Email;

                // Update the user
                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    foreach (var error in updateResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    model.AllRoles = _roleManager.Roles.Select(r => r.Name).ToList(); // Repopulate roles for the view
                    return View(model);
                }

                // Redirect to the user list
                return RedirectToAction("Index");
            }

            // If model state is not valid, return to the edit view with errors
            model.AllRoles = _roleManager.Roles.Select(r => r.Name).ToList(); // Repopulate roles for the view
            return View(model);
        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            if (user.UserName == User.Identity.Name)
            {
                // Prevent deleting the current account
                return BadRequest("Cannot delete the current account.");
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            // If deletion fails, handle errors
            return RedirectToAction("Index"); // Redirect to a suitable page or display an error message
        }


    }
}
