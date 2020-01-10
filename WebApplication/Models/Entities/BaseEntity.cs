using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Entities
{
    public class BaseEntity
    {
        public DateTime InsertDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}