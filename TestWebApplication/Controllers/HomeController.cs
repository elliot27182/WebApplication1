using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApplication.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly masterEntities _context;

        public HomeController() : this(new masterEntities())
        {
        }
        public HomeController(masterEntities context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if (userViewModel.Image != null && userViewModel.Image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(userViewModel.Image.FileName);
                    var vpath = Server.MapPath("~/Images");
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    userViewModel.Image.SaveAs(path);

                    // Store the relative path to the image file in the ImagePath property
                    userViewModel.ImagePath = Url.Content("~/Images/" + fileName);
                }

                // Map from UserViewModel to User
                var user = new Users
                {
                    Username = userViewModel.Username,
                    Email = userViewModel.Email,
                    Password = userViewModel.Password,
                    ImagePath = userViewModel.ImagePath
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                //Redirect to the GetUser action to retrieve the data from the database
                return RedirectToAction("GetUser", new { id = user.Id });
            }

            return View("Index");
        }

        public ActionResult GetUser(int id)  // changed from string username to int id
        {
            Users user = _context.Users.Find(id);  // use Find to get the user by Id
            if (user != null)
            {
                // Map from Users to UserViewModel
                var userViewModel = new UserViewModel
                {
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                    ImagePath = user.ImagePath
                };

                return View("UserDetail", userViewModel);
            }

            return RedirectToAction("Index");
        }
    }
}