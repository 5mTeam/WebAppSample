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

        public static bool SendConfirmationEmail(string baseUrl, User user)
        {
            try
            {
                MailMessage msg = new MailMessage(_username, user.Email);
                msg.Subject = "WebApplication 5M - Confirm registration";
                msg.IsBodyHtml = true;
                var token = user.Id + "-" + user.RegistrationDate.ToString("yyMMddhhmmss");
                var link = baseUrl+"Reserved/ConfirmEmail/?token=" + token;
                msg.Body = "<a href=\""+link+"\">Confirm registration</a>";


                SmtpClient client = new SmtpClient(_smtp, Convert.ToInt32(_port));
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new System.Net.NetworkCredential(_username, _password);
                client.EnableSsl = true;

                client.Send(msg);

            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}