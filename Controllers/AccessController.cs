using Microsoft.AspNetCore.Mvc;
using MVC_CRUD_Users.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace MVC_CRUD_Users.Controllers
{
    private readonly MvccrudusersContext _db;
    public class AccessController : Controller
    {
        public AccessController(MvccrudusersContext context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
