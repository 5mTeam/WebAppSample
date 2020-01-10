using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.Entities;

namespace WebApplication.Models
{
    public class IndexModel : BaseModel
    {
        public int Number { get; set; }
        public List<Article> Articles { get; set; }


    }
}