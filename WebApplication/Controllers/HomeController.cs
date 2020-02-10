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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            var model = new IndexModel
            {
                Title = "Salvo",
                Text = "my <strong>first</strong> web application",
                Number = CustomRandomHelper.RandomNumber(3, 7)
            };
            model.Articles = DatabaseHelper.GetAllArticles();
            ViewBag.Pippo = "gfhfhgj";
            return View(model);
        }

        public ActionResult Article(int id, string name)
        {
            var model = new ArticleModel();
            if (!string.IsNullOrWhiteSpace(name))
            {
                model.Title = name;
            }
            model.AuthorLabel = "Autore";
            model.Article = DatabaseHelper.GetArticleById(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginModel();
            LoadLabelLoginModel(model);
            return View(model);
        }

        private static void LoadLabelLoginModel(LoginModel model)
        {
            model.LabelButtonSend = "Send";
            model.LabelLogin = "Login";
            model.LabelPassword = "Password";
            model.LabelUsername = "Username";
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            LoadLabelLoginModel(model);
            var user = DatabaseHelper.Login(model.Username, model.Password);
            if (user != null)
            {
                //carichiamo l'utente loggato in sessione
                Session["loggedUser"] = user;
                //andremo verso l'area riservata
                return RedirectToAction("Profile", "Reserved", new { id = user.Id });
            }
            model.ErrorMessage = "Wrong login!";

            return View(model);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            var model = new SignUpModel();
            LoadLabelSignUpModel(model);
            return View(model);
        }

        private static void LoadLabelSignUpModel(SignUpModel model)
        {
            model.LabelButtonSend = "Send";
            model.LabelSignUp = "Sign Up";
            model.LabelPassword = "Password";
            model.LabelConfirmPassword = "Confirm Password";
            model.LabelEmail = "Email";
            model.LabelUsername = "Username";
            model.LabelName = "Name";
            model.LabelPrivacy = "Accept privacy terms";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpModel model)
        {
            LoadLabelSignUpModel(model);
            var hasErrors = false;
            if (model.User.Password != model.ConfirmPassword)
            {
                hasErrors = true;
                model.ErrorConfirmPasswordMessage = "Confirm password MUST match Password";
            }

            if (!model.IsPrivacyChecked)
            {
                hasErrors = true;
                model.ErrorPrivacyNotCheckedMessage = "Privacy MUST be checked";
            }

            //controllo email non esistente - accesso al db
            //ma prima verifico che il campo email sia validato correttamente
            if (ModelState["user.Email"].Errors.Count() == 0 && DatabaseHelper.GetUserByEmail(model.User.Email) != null)
            {
                hasErrors = true;
                model.ErrorEmailExistsMessage = "A registration with this email already exists";
            }

            //controllo username non esistente - accesso al db
            //ma prima verifico che il campo username sia validato correttamente
            if (ModelState["user.Username"].Errors.Count() == 0 && DatabaseHelper.GetUserByUsername(model.User.Username) != null)
            {
                hasErrors = true;
                model.ErrorUsernameExistsMessage = "A registration with this username already exists";
            }



            if (hasErrors)
                return View(model);

            if (ModelState.IsValid)
            {
                //faccio l'insert sul db
                model.User = DatabaseHelper.Save(model.User);
                if (model.User != null)
                {
                    //mando a pagina di benvenuto
                    Session["signUpUser"] = model.User;
                    return RedirectToAction("ThankYou", "Home");
                }
                model.ErrorMessage = "Server error. Try later";


            }
            return View(model);
        }


        [HttpGet]
        public ActionResult ThankYou()
        {
            var model = new ThankYouModel();
            var signUpUser = (User)Session["signUpUser"];
            if (signUpUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Session["signUpUser"] = null;

            //invio mail di conferma
            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            var resultEmail = EmailHelper.SendConfirmationEmail(baseUrl, signUpUser);
            model.WelcomeMessage = "Thank you <strong>" + signUpUser.Name + "</strong> for your registration";

            return View(model);
        }

    }
}