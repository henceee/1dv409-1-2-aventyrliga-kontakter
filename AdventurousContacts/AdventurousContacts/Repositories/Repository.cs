using AdventurousContacts.Models;
using AdventurousContacts.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Repositories
{
    public class Repository : IRepository
    {
        
        private bool _disposed = false;

        private Contact_Entities _entities = new Contact_Entities();
     
        public void Add(Contact contact)
        {
            _entities.Contact.Add(contact);         
        }

        public void Delete(Contact contact)
        {
            if (_entities.Entry(contact).State == EntityState.Detached)
            {
                _entities.Contact.Attach(contact);
            }
            _entities.Contact.Remove(contact);
        }

        public IQueryable FindAllContacts()
        {
            return _entities.Contact.AsQueryable();
        }

        public Models.Contact GetContactById(int contactId)
        {   
            return _entities.Contact.Find(contactId);
        }

        public IList<Contact> GetLastContact(int count = 20)
        {
            //TODO: Implement Models.Repository.GetLastContact(int count = 20)
            throw new NotImplementedException();
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public void Update(Contact contact)
        {   
            _entities.Entry(contact).State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();                   
                }              
            }
            _disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}