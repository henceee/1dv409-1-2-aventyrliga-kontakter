using AdventurousContacts.Models;
using AdventurousContacts.Models.DataModels;
using AdventurousContacts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventurousContacts.Controllers
{
    public class ContactController : Controller
    {
        private IRepository _repository = new Repository();
        private Contact_Entities _context = new Contact_Entities();

        //TODO: Add constructor to controller? ContactController.ContactController(IRepository repository)
        //
        // GET: /Contact/
         public ActionResult Index()
        {
            var model = _context.Contact.ToList();
            return View(model);
        }

         //
         // GET: /Contact/Create
         public ActionResult Create()
         {
            return View();
         }

         //
         // POST: /Contact/Create
         [HttpPost]
         public ActionResult Create(Contact contact)
         {
             _context.Contact.Add(contact);
             _context.SaveChanges();

             return RedirectToAction("Index");
         }

        //TODO: Implement ContactController.Delete(int id=0) : ActionResult

        //TODO: Implement ContactController.DeleteContirmed(int id) : ActionResult

        //Överskugga dispose för att kalla Dispose på Repository obj.

         protected override void Dispose(bool disposing)
         {
                 if (disposing)
                 {
                     //_repository.Dispose();
                 }

                 base.Dispose(disposing);

         }
        //TODO: Implement ContactController.Dispose(bool disposing) : void

        //TODO: Implement ContactController.Edit(int id=0) : ActionResult
        
        //TODO: Implement ContactController.Edit(Contact contact) : ActionResult

    }
}


