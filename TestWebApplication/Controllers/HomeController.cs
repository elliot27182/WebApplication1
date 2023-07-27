using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_BusinessLogicLayer;
using MVC_DataAccessLayer;



namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private UserService userService = new UserService();
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
      

                userService.AddUser(userViewModel);

                //Redirect to the GetUser action to retrieve the data from the database
                return RedirectToAction("GetUser", new { username = userViewModel.Username });
            }

            return View("Index");
        }

        public ActionResult GetUser(string username)
        {
            UserViewModel user = userService.GetUserByUsername(username);
            if (user != null)
            {
                // Map from User to UserViewModel
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