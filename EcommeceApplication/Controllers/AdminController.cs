using EcommeceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommeceApplication.Controllers
{
    public class AdminController : Controller
    {
        private myContext _context;
        public AdminController(myContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            string admin_session = HttpContext.Session.GetString("admin_session");
            if (admin_session != null)
            {

            return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(string adminEmail,string adminPassword)
        {
            var row = _context.tbl_admin.FirstOrDefault(a => a.admin_email == adminEmail);
            if (row != null && row.admin_password == adminPassword)
            {
                HttpContext.Session.SetString("admin_session",row.admin_id.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Invalid Email or Password";
                return View();
            }
        }
        public IActionResult logout()
        {
            HttpContext.Session.Remove("admin_session");
            return RedirectToAction("login");
        }
        public IActionResult profile()
        {
            var adminId = HttpContext.Session.GetString("admin_session");
            var row = _context.tbl_admin.Where(a=>a.admin_id == int.Parse(adminId));
            return View(row);
        }   
    }
}
