using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsAPI.Repository
{
    public class ContactsRepository
    {
        public IEnumerable<Contact> GetContacts()
        {
            var contacts = new List<Contact>();
            var one = new Contact()
            {
                Name = "Srinivasan",
                Mobile = 9791166630,
                Relationship = "Self",
                Address = new Address()
                {
                    Street = "6F, New mahalipatti Road",
                    City = "Madurai",
                    State = "TN",
                    Country = "IN"
                }
            };
            var two = new Contact()
            {
                Name = "Asvini",
                Mobile = 1236547896,
                Relationship = "Woodbie",
                Address = new Address()
                {
                    Street = "Munichalai",
                    City = "Madurai",
                    State = "TN",
                    Country = "IN"
                }
            };
            contacts.Add(one);
            contacts.Add(two);
            return contacts;
        }
    }
}