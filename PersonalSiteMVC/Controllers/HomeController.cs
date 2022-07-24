using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using PersonalSiteMVC.Models;
using DataLayer;

namespace PersonalSiteMVC.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Resume()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }
            
            string emailBody = $"You have recieved an email from {cvm.firstName} {cvm.lastName} <br /><br />" +
                $"With {cvm.Company} / {cvm.Position}<br /><br />" +
                $"About {cvm.Subject}<br /><br />  with the following message: <br /> <br /> {cvm.Message}" +
                $"Please respond to {cvm.Email}";

            MailMessage msg = new MailMessage
            (
                //From
                "no-reply@tessatoney.com",
                //To (Where the actual message is sent)
                "stacy.toney@protonmail.com",
                //Subject
                "Email from tessatoney.com",
                //Body
                emailBody
            );

            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("192.168.0.200");//("mail.tessatoney.com");
            //client.Credentials = new NetworkCredential("no-reply@tessatoney.com", "N3wP@ss21");//change to ****** before pushing to GitHub but use password for deploy
           // SmtpClient port = new SmtpClient("smtp.Port = 8889;");
           // SmtpClient port = 8889;
            try
            {
                
                client.Send(msg);
            }
            catch (Exception ex)
            {
                //TODO Implement custom error response
                ViewBag.ErrorMessage = $"Sorry, something went wrong. Error message : {ex.Message}<br />{ex.StackTrace}";
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);

        }

        public ActionResult Links()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Thumbnail()
        {
            return View();
        }

        public ActionResult Undeliverable()
        {
            return View();
        }

        public ActionResult Examples()
        {
            //string delUserHtml = "<div>\n<telerik:RadTextBox runat=\"server\"";
            //delUser.InnerHtml = delUserHtml;

            ViewData["delUserHtml"] = "does \n it \n work \n \"now\"<telerik:RadTextBox runat=\"server\" ID=\"boxDelUser\" Text=\"Delete User\" Skin=\"Web20\"></telerik:RadTextBox>";//"<div>\n<telerik:RadTextBox runat=\"server\" ID=\"boxDelUser\" Text=\"Delete User\" Skin=\"Web20\"></telerik:RadTextBox>";
            return View();
        }

        [HttpPost]
        public ActionResult TestErrorWriteToDB_Click(object sender, EventArgs e)
        {
            Exception ex = new Exception();
            PSDataLayer PSDL = new PSDataLayer();
            PSDL.ErrorMessageWriter(ex, "Testing Error writing connection to DB", "testing", PSDL.ApplicationName);
            //throw;
            return View(); 
        }
    }
}