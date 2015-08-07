﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace henning.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var result = new FilePathResult("~/grand-legacy.html", "text/html");
            return result;
        }



        public ActionResult grand()
        {
            var result = new FilePathResult("~/grand-legacy.html", "text/html");
            return result;
        }

   

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        { 
            ViewBag.Message = "Your contact page.";
            
            return View(new ContactInfo());
        }
        [HttpPost]
        public ActionResult Contact(ContactInfo contact)
        {
            ViewBag.Message = "Your contact page.";

            var firstName = contact.FirstName;
            var lastName = contact.LastName;
           SendEmail(firstName, lastName);
            return RedirectToAction("Index");
        }

        public ActionResult ContactSubmited()
        {

            var result = new FilePathResult("~/grand-legacy.html", "text/html");
            return result;

        }


        public void SendEmail(string firstName, string lastName)
        {

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               System.Configuration.ConfigurationManager.AppSettings["MAILGUN_API_KEY"]);

            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                 System.Configuration.ConfigurationManager.AppSettings["MAILGUN_DOMAIN"], ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@mailgun.org>");
            //request.AddParameter("to", "bar@example.com");
            request.AddParameter("to", "tosca.ragnini@gmail.com");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", "Testing some Mailgun awesomness!");
            request.Method = Method.POST;
            var result = client.Execute(request);
            return;
        }


    }


    public class ContactInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

    }
}