using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Helpers;
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

        [HttpGet]
        public ActionResult ConfirmEmail(string token)
        {
            //validare il token
            if (string.IsNullOrWhiteSpace(token))
                return RedirectToAction("Index", "Home");
            var tokenParts = token.Split('-');
            if (tokenParts.Length!=2)
                return RedirectToAction("Index", "Home");
            var id = 0;
            try
            {
                id = Int32.Parse(tokenParts[0]);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = DatabaseHelper.GetUserByIdNotConfirmed(id);
            if (user==null)
                return RedirectToAction("Index", "Home");
            //significa che l'utente esiste e non è confermato
            if (user.RegistrationDate.ToString("yyMMddhhmmss")!=tokenParts[1])
                return RedirectToAction("Index", "Home");
            //fine validazione token

            //se arriviamo qui siamo sicuri che è l'utente che ha cliccato sul link email per la prima volta
            //update su database di isconfirmed
            user.IsConfirmed = true;
            user = DatabaseHelper.Save(user);
            if (user == null)
                return RedirectToAction("Index", "Home"); //dovrebbe essere sostituito con una pagina che mostra un errore server e chiede di riprovare più tardi

            //metto in sessione se son riuscito ad aggiornare il database
            Session["loggedUser"] = user;

            return RedirectToAction("Profile", "Reserved", new { id = user.Id }); 
        }

    }
}