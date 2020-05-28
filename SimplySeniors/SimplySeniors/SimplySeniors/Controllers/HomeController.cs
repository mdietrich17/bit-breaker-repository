using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimplySeniors.Attributes;
using Microsoft.AspNet.Identity;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace SimplySeniors.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult HelpPage()
        {
            ViewBag.Message = "Your application help page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Services that are offered in our community.";

            return View();
        }
        public ActionResult emailservice()
        {
            var message = Request.QueryString["message"];
            string sender;
            if (User.Identity.GetUserId() == null) //Random User
            {
                 sender = Request.ServerVariables["REMOTE_ADDR"]; //send their IP Address. 
            }
            else { sender = User.Identity.GetUserId(); } //only sending user id to prevent massive trips to DB

            sendemail(sender, message);

            return new ContentResult
            {
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8,
                Content = JsonConvert.SerializeObject(message)



            };


        }

        public void sendemail(string user, string message)
        {

            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(
            new System.Net.Mail.MailAddress("teamBitBreakers@gmail.com", "Web Registration"),
            new System.Net.Mail.MailAddress("teamBitBreakers@gmail.com"));
            m.Subject = "Sender: " + user;
            string path = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/Template/") + "Suggestionbox" + ".html"); //path for template
            string body = string.Format("<p> {0} </p>",
            message);
            m.Body = appendmessage(path, body);
            m.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("teamBitBreakers@gmail.com", "WesternOreg0n");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(m);

        }

        public string appendmessage(string emailtemplatepath, string message)
        {
            var template = new HtmlAgilityPack.HtmlDocument();
            template.LoadHtml(emailtemplatepath);
            foreach (var item in template.DocumentNode.Descendants())
            {
                if (item.Id == "insideboxid")
                {
                    var loadbody = new HtmlAgilityPack.HtmlDocument();
                    loadbody.LoadHtml(message);
                    var paragraph = loadbody.DocumentNode.SelectSingleNode("//p");
                    item.AppendChild(paragraph);
                }
            }

            return template.DocumentNode.OuterHtml;

        }



    }
}