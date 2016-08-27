using ContactsAPI.Models;
using ContactsAPI.Repository;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
        public IHttpActionResult Get()
        {
            repository = new ContactRepository();
            return Ok(repository.GetContacts());
        }

        [HttpGet]
        [Route("search/{name:alpha}")]        
        public IHttpActionResult Get(string name)
        {
            repository = new ContactRepository();
            if (string.IsNullOrEmpty(name))
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Search Name can not be empty")
                };
                throw new HttpResponseException(message);
            }
            return Ok(repository.GetContact(name));
        }

        // GET api/contact/5
        [HttpGet]
        [Route("get/{id:int}")]        
        public IHttpActionResult Get(int id)
        {
            repository = new ContactRepository();
            if (id == 0)
            {
                var message = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent("Issue with Passed Id Parameter.") };
                throw new HttpResponseException(message);
            }
            return Ok(repository.GetContact(id));
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
        [HttpGet, HttpDelete]
        public void Delete(int id)
        {
            repository = new ContactRepository();
            repository.DeleteContact(id);
        }

        #endregion
    }
}
