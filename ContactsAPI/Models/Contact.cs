using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsAPI.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public double Mobile { get; set; }
        public string Relationship { get; set; }
        public Address Address { get; set; }

        public Contact()
        {
            Address = new Address();
        }
    }
}