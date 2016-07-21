using ContactsAPI.Models;
using ContactsAPI.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace ContactsAPI.Controllers
{
    public class ContactsController : ApiController
    {
        ContactRepository repository = null;

        #region API Methods

        // GET api/contact
        public IEnumerable<Contact> Get()
        {
            repository = new ContactRepository();
            return repository.GetContacts();
        }

        // GET api/contact/5
        public Contact Get(int id)
        {
            repository = new ContactRepository();
            return repository.GetContact(id);
        }

        // POST api/contact
        public void Post([FromBody]Contact value)
        {
            repository = new ContactRepository();
            repository.SaveContact(value);
        }

        // PUT api/contact/5
        public void Put(int id, [FromBody]Contact value)
        {
            repository = new ContactRepository();
            repository.UpdateContact(id, value);
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
            repository = new ContactRepository();
            repository.DeleteContact(id);
        }

        #endregion
    }
}
