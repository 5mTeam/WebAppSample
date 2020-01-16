using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Helpers;
using WebApplication.Models;

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
            if(!string.IsNullOrWhiteSpace(name))
            {
                model.Title = name;
            }
            model.AuthorLabel = "Autore";
            model.Article = DatabaseHelper.GetArticleByid(id);
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
            if (DatabaseHelper.Login(model.Username,model.Password))
            {
                //andremo verso l'area riservata
            }
            model.ErrorMessage = "Wrong login!";

            return View(model);
        }

    }
}