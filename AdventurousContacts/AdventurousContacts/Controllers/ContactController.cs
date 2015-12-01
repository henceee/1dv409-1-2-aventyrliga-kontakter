using AdventurousContacts.Models;
using AdventurousContacts.Models.DataModels;
using AdventurousContacts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Net;

//TODO ADD BUNDLING N STUFF N THINGS: http://go.microsoft.com/fwlink/?LinkId=254725

namespace AdventurousContacts.Controllers
{
    public class ContactController : Controller
    {
        #region fields
        private IRepository _repository;
        #endregion

        #region controller(s)
        public ContactController()
            :this(new Repository())
        {
            //empty
        }

        public ContactController(IRepository repository)
        {
            _repository = repository;
        }
        #endregion
        // GET: /Contact/
         public ActionResult Index()
        {
            //throw new Exception("kasdfjs");
            return View("Index", _repository.GetLastContacts());       
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
         public ActionResult Create([Bind(Include = "FirstName,LastName,EmailAddress")] Contact contact)
         {
             if (ModelState.IsValid)
             {
                 try
                 {
                     _repository.Add(contact);
                     _repository.Save();
                     TempData["sucess"] = string.Format("{0} {1} ({2}) saved.",
                                                        contact.FirstName, contact.LastName,contact.EmailAddress);
                     return RedirectToAction("Index");
                 }
                 catch (DataException)
                 {
                     TempData["error"] = "Failed to save contact.";
                 }    
             }
             return View();
         }

        

         //GET: /Contact(Delete/ID
         public ActionResult Delete(int? id)
         {
              if(!id.HasValue)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }

             var contact = _repository.GetContactById(id.Value);

             if(contact == null)
             {
                 return HttpNotFound();
             }

             return View(contact);

         }
         //POST: /Contact/Delete/ID
         [HttpPost]
         [ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id=0)
         {
             try
             {
                 var contactToDelete = new Contact { ContactID = id };
                 _repository.Delete(contactToDelete);
                 _repository.Save();
                 TempData["sucess"] = TempData["sucess"] = "Contact deleted."; 
                 
                 return RedirectToAction("Index");
             }
             catch (DataException)
             {                 
                  TempData["error"] = "Failed to delete contact.";
                  
             }

             return RedirectToAction("Delete", new { id = id });
         }
         //Överskugga dispose för att kalla Dispose på Repository obj.

         #region dispose
         protected override void Dispose(bool disposing)
         {
             _repository.Dispose();
             base.Dispose(disposing);

         }
         #endregion

         //GET: /Contact/Edit/ID
         public ActionResult Edit(int? id)
         {
             if(!id.HasValue)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }

             var contact = _repository.GetContactById(id.Value);

             if(contact == null)
             {
                 return HttpNotFound();
             }

             return View(contact);
         }
        
         //POST: /Contact/Edit/ID
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
         public ActionResult EditPost(int? id)
         {
             var contact = _repository.GetContactById(id.Value);

             if (contact == null)
             {
                 return HttpNotFound();
             }

             if (TryUpdateModel(contact, new string[] { "FirstName", "LastName", "EmailAddress" }))
             {
                 try
                 {
                     _repository.Update(contact);
                     _repository.Save();
                     TempData["sucess"] = "Changes saved.";
                     return RedirectToAction("Index");
                 }
                 catch (DataException)
                 {
                      TempData["error"] = "Failed to save changes.";
                 }
             }

             return View(contact);
         }
  

    }
}


