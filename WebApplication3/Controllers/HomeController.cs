﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult  Contact(string textBoxStringData, int textBoxIntData, string checkboxData)
        {
            //Do something
            SendEmail(this, null);
            ViewBag.Message = "Email submitted.";

            return View();
        }

        protected void SendEmail(object sender, EventArgs e)
        {
            string txtEmail = "asmithaabb@gmail.com";
            string txtPassword = "kzq1968AA!";
            string txtSubject = "Test email";
            string txtBody = "This is just a test email";
            string txtTo = "irfanzub@gmail.com";
            using (MailMessage mm = new MailMessage(txtEmail, txtTo))
            {
                mm.Subject = txtSubject;
                mm.Body = txtBody;
                //if (fuAttachment.HasFile)
                //{
                //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                //}
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(txtEmail, txtPassword);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
            }
        }
    }
}