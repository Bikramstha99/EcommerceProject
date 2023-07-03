using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AddRoles : Controller
    {
       
        private readonly RoleManager<IdentityRole> rolemanager;

        public AddRoles(RoleManager<IdentityRole> rolemanager)
        {
            this.rolemanager = rolemanager;
        }
        [HttpGet]

        public IActionResult Index()
        {
            var role= rolemanager.Roles.ToList();
            return View(role);
            
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            if (!rolemanager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                rolemanager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");

        }
    }
}
