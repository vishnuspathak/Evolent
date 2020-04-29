using ContactManagment.Interface;
using ContactManagment.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ContactManagment.Repositories
{
    public class ContactRepository: IContactRepository
    {
        private List<Contact> _contacts = null;

        public ContactRepository()
        {
            this._contacts = new List<Contact>();
            this._contacts.Add(new Contact() { Id= 1, FirstName = "Arya", LastName = "Stark", PhoneNumber = 9898989898, Status = true });
            this._contacts.Add(new Contact() { Id = 2, FirstName = "Edderd", LastName = "Stark", PhoneNumber = 9898989898, Status = true });
            this._contacts.Add(new Contact() { Id = 3, FirstName = "John", LastName = "sno", PhoneNumber = 9898989898, Status = true });
        }

        public bool AddContact(ContactDto contact)
        {
            if (contact == null) return false;
            var contactData = this.MapDtoToModel(contact);
            contactData.Id = this._contacts.Count();
            // Add contact to DB
            this._contacts.Add(contactData);
            return true;
        }

        public bool EditContact(long id, ContactDto contact)
        {
            if (contact == null) return false;

            var contactToEdit = this._contacts.FirstOrDefault(c => c.Id == id);
            contactToEdit.FirstName = contact.FirstName;
            contactToEdit.LastName = contact.LastName;
            contactToEdit.PhoneNumber = contact.PhoneNumber;
            contactToEdit.Status = contact.Status;
            contactToEdit.Email = contact.Email;
            return true;
        }

        public bool DeleteContact(long Id)
        {
            var contact = this._contacts.FirstOrDefault(c => c.Id == Id);
            return this._contacts.Remove(contact);
        }

        public List<Contact> GetContacts()
        {
            return this._contacts;
        }

        public Contact GetContactById(long id)
        {
            if (id <= 0) return null;

            return this._contacts.FirstOrDefault(c => c.Id == id);
        }

        #region private methods
        private Contact MapDtoToModel(ContactDto contact)
        {
            Contact contactModel = new Contact()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Status = contact.Status
            };
            return contactModel;
        }
        #endregion

    }
}