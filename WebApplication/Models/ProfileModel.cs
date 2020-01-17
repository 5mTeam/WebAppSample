using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.Entities;

namespace WebApplication.Models
{
    public class ProfileModel:ReservedModel
    {
        public string LabelProfile { get; set; }

        public User User { get;  set; }
    }
}