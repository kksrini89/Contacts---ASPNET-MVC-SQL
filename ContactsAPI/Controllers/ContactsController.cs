using ContactsAPI.Models;
using ContactsAPI.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace ContactsAPI.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactsController : ApiController
    {
        ContactRepository repository = null;

        #region API Methods

        // GET api/contact
        [Route("getall")]
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            repository = new ContactRepository();
            return repository.GetContacts();
        }

        // GET api/contact/5
        [Route("get/{id}")]
        [HttpGet]
        public Contact Get(int id)
        {
            repository = new ContactRepository();
            return repository.GetContact(id);
        }

        // POST api/contact
        [Route("save")]
        [HttpPost]
        public void Post([FromBody]Contact value)
        {
            repository = new ContactRepository();
            repository.SaveContact(value);
        }

        // PUT api/contact/5
        [Route("put/{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]Contact value)
        {
            repository = new ContactRepository();
            repository.UpdateContact(id, value);
        }

        // DELETE api/contact/5
        [Route("delete/{id}")]
        [HttpGet,HttpDelete]
        public void Delete(int id)
        {
            repository = new ContactRepository();
            repository.DeleteContact(id);
        }

        #endregion
    }
}
