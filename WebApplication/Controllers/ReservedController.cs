using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.Entities;

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

            var user = (User)loggedUser; //abbiamo preso l'utente loggato

            if (user.Id != id)  //per beccare i furbetti
            {
                return RedirectToAction("Profile", "Reserved", new { id = user.Id });
            }


            model.User = user; //voglio portare alla view i dati dell'utente

            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["loggedUser"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}