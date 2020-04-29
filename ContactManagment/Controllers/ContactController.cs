using ContactManagment.Interface;
using ContactManagment.Models;
using ContactManagment.Repositories;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Web.Http;

namespace ContactManagment.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        private IContactRepository _contactRepository = null;

        public ContactController()
        {
            _contactRepository = new ContactRepository();
        }

        // GET api/contact
        [Route("")]
        public IHttpActionResult GetContacts()
        {
            var contacts =  this._contactRepository.GetContacts();
            return Ok(contacts);
        }
       
        [Route("{id:long}")]
        public IHttpActionResult GetContactById(long id)
        {
            var contact = this._contactRepository.GetContactById(id);
            return Ok(contact);
        }

        // POST api/contact
        [Route("")]
        public IHttpActionResult PostContact(ContactDto contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            this._contactRepository.AddContact(contact);

            return Ok();
        }

        // PUT api/contact/5
        [Route("{id:long}")]
        public IHttpActionResult Put(long id, ContactDto contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contactData = this._contactRepository.GetContactById(id);

            if (contactData == null) return NotFound();

            this._contactRepository.EditContact(id, contact);

            return Ok();
        }

        // DELETE api/contact/5
        [Route("{id:long}")]
        public IHttpActionResult DeleteContact(long id)
        {
            if (id <= 0)
                return BadRequest("Invalid contactId");

            this._contactRepository.DeleteContact(id);

            return Ok();
        }
    }

  
}
