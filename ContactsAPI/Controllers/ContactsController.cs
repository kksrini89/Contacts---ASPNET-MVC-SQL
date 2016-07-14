﻿using ContactsAPI.Models;
using ContactsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactsAPI.Controllers
{
    public class ContactsController : ApiController
    {
        // GET: api/Contacts
        public IEnumerable<Contact> Get()
        {
            var repository = new ContactsRepository();
            return repository.GetContacts();
        }

        // GET: api/Contacts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contacts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contacts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contacts/5
        public void Delete(int id)
        {
        }
    }
}
