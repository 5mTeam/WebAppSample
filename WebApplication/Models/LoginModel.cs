using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.Entities;

namespace WebApplication.Models
{
    public class LoginModel : BaseModel
    {
        public string LabelLogin { get; set; }
        public string LabelUsername { get; set; }
        public string LabelPassword { get; set; }
        public string LabelButtonSend { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
    }
}