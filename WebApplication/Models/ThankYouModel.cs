using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ThankYouModel : BaseModel
    {
        public string WelcomeMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}