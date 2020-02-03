using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using WebApplication.Models.Entities;

namespace WebApplication.Helpers
{
    public class EmailHelper
    {
        private static string _smtp = ConfigurationManager.AppSettings["SmtpServer"];
        private static string _port = ConfigurationManager.AppSettings["PortServer"];
        private static string _username = ConfigurationManager.AppSettings["UsernameEmail"];
        private static string _password = ConfigurationManager.AppSettings["PasswordEmail"];

        public static bool SendConfirmationEmail(User user)
        {
            try
            {
                MailMessage msg = new MailMessage(_username, user.Email);
                msg.Subject = "WebApplication 5M - Confirm registration";
                msg.IsBodyHtml = true;
                msg.Body = "";
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}