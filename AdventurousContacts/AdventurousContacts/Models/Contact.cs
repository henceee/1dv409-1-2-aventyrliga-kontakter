using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {
        /* Don't these implement props, part of partial class
         * generated from DB (see DataModels.Contact)!!
         *
         *  public int ContactID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailAddress { get; set; }*/

        private class Contact_Metadata
        {
            [Required(ErrorMessage = "Förnamn måste anges.")]
            [DisplayName("Förnamn")]
            public string FirstName { get; set; }
            [Required(ErrorMessage = "Efternamn måste anges")]
            [DisplayName("Efternamn")]
            public string LastName { get; set; }
            [Required(ErrorMessage = "Email måste anges")]
            [DisplayName("Email Adress")]
            public string EmailAddress { get; set; }
          

            
        }
    }
}