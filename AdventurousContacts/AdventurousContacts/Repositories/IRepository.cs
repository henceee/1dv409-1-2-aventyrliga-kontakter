using AdventurousContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventurousContacts.Repositories
{
    public interface IRepository : IDisposable
    {
        void Add(Contact contact);
        void Delete(Contact contact);
        IQueryable FindAllContacts();
        Contact GetContactById(int contactId);
        IList<Contact> GetLastContact(int count=20);
        void Save();
        void Update(Contact contact);
    }
}
