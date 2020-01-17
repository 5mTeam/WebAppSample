using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ReservedController : Controller
    {
        [HttpGet]
        public ActionResult Profile(int id)
        {
            var model = new ProfileModel();
            model.Title = "Salvo";
            model.Text = "my <strong>first</strong> web application";
            model.ReservedTitle = "Reserved Area";
            model.LabelProfile = "Profile";
            var loggedUser = Session["loggedUser"];
            if (loggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if ((int)loggedUser != id)
            {
                return RedirectToAction("Profile", "Reserved", new { id = loggedUser });
            }


            model.Id = id;

            return View(model);
        }
    }
}