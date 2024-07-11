using ClarkCodingChallenge.BusinessLogic;
using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ApiController : Controller
    {
        public readonly ContactsService _contactsService = new ContactsService();

        [HttpGet("")]
        public IActionResult Get([FromQuery] string lastName = null, [FromQuery] string ordering = "asc")
        {
            List<Contact> contacts = _contactsService.GetFilteredAndOrderedContacts(lastName, ordering);
            return Json(contacts);
        }
    }
}
