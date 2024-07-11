using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ClarkCodingChallenge.BusinessLogic
{
    public class ContactsService
    {
        public ContactsDataAccess _dataAccess = new ContactsDataAccess();
        public Contact CreateContact(string firstName, string lastName, string Email)
        {
            Contact newContact = new Contact(firstName, lastName, Email);
            _dataAccess.SaveContactToList(newContact);
            return newContact;
        }

        public List<Contact> GetFilteredAndOrderedContacts(string lastName = null, string ordering = null)
        {
            // check if there is a last name and if so, filter by the last name
            List<Contact> contacts = lastName == null ? GetAllContacts() : GetContactsUsingLastName(lastName);
            if (ordering == "desc")
            {
                contacts.Sort((x, y) =>
                {
                    int c = y.LastName.CompareTo(x.LastName);
                    if (c == 0)
                    {
                        c = y.FirstName.CompareTo(x.FirstName);
                    }
                    return c;
                });
            }
            else
            {
                contacts.Sort((x, y) =>
                {
                    int c = x.LastName.CompareTo(y.LastName);
                    if (c == 0)
                    {
                        c = x.FirstName.CompareTo(y.FirstName);
                    }
                    return c;
                });
            }
            return contacts;
        }

        public List<Contact> GetAllContacts()
        {
            return _dataAccess.GetAllContacts();
        }

        public List<Contact> GetContactsUsingLastName(string lastName)
        {
            List<Contact> allContacts = _dataAccess.GetAllContacts();
            List<Contact> results = new List<Contact>();
            foreach (var contact in allContacts)
            {
                if(contact.LastName.ToLower() == lastName.ToLower())
                {
                    results.Add(contact);
                }
            }
            return results;
        }
    }
}
