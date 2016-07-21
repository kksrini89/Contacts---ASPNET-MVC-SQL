using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsAPI.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long MobileNumber { get; set; }
        public string Relationship { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
        //public Address Address { get; set; }        
    }
}