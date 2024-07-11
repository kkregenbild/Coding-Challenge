using ClarkCodingChallenge.Models;
using System;
using System.Collections.Generic;

namespace ClarkCodingChallenge.DataAccess
{
    public class ContactsDataAccess
    {
        public static List<Contact> contacts { get; set; } = new List<Contact>();
        public void SaveContactToList(Contact contact)
        {
            contacts.Add(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return contacts;
        }
    }
}
