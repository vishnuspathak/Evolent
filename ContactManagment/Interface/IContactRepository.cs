using ContactManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagment.Interface
{
    interface IContactRepository
    {
        bool AddContact(ContactDto contact);
        bool EditContact(long id, ContactDto contact);
        bool DeleteContact(long Id);
        List<Contact> GetContacts();
        Contact GetContactById(long id);
    }
}
