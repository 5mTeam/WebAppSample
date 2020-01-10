using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.Entities;

namespace WebApplication.Models
{
    public class ArticleModel:BaseModel
    {
        public Article Article { get; set; }

        //aggiungiamo le altre proprietà per la pagina, 
        //proprietà che non sono presenti in basemodel
        // esempio 
        public string AuthorLabel { get; set; }
    }
}