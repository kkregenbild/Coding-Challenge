using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using System;
using ClarkCodingChallenge.BusinessLogic;
using System.Collections.Generic;

namespace ClarkCodingChallenge.Controllers
{

    public class ContactsController : Controller
    {
        public ContactsService _contactsService = new ContactsService();
        public IActionResult Index()
        {
            return View();
        }

        
		public IActionResult Create()
		{
			return View();
		}

        [HttpPost]
        public ActionResult Create(string FirstName, string LastName, string Email)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            _contactsService.CreateContact(FirstName, LastName, Email);

            // Make sure to return the user to a confirmation page
            return View("Confirmation");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
