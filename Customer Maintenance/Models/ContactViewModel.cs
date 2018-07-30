using CustomerMaintenance.CustomerServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerMaintenance.Models
{
    public class ContactViewModel
    {
        [Required]
        public string ContactNo { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Felt må være minst 2 karakterer og ikke mer enn 30.", MinimumLength = 2)]
        [Display(Name = "Fornavn")]
        public string FirstName { get; set; }       

        [Required]
        [StringLength(30, ErrorMessage = "Felt må være minst 2 karakterer og ikke mer enn 30.", MinimumLength = 2)]
        [Display(Name = "Etternavn")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "Felt må være minst 2 karakterer og ikke mer enn 50.", MinimumLength = 2)]
        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [StringLength(20, ErrorMessage = "Felt må være minst 4 karakterer og ikke mer enn 20.", MinimumLength = 2)]
        [Display(Name = "Postnr.")]
        public string PostCode { get; set; }

        [StringLength(30, ErrorMessage = "Felt må være minst 4 karakterer og ikke mer enn 30.", MinimumLength = 2)]
        [Display(Name = "Sted")]
        public string City { get; set; }

        [StringLength(30, ErrorMessage = "Felt må være minst 4 karakterer og ikke mer enn 30.", MinimumLength = 2)]
        [Display(Name = "Telefon")]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Felt må være minst 4 karakterer og ikke mer enn 80.", MinimumLength = 2)]
        [Display(Name = "E-post")]
        public string Email { get; set; }

        public static ContactViewModel ServiceModelToViewModel(ReadContact contact)
        {
            return new ContactViewModel()
            {
                ContactNo = contact.ContactNo,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Address = contact.Address,                
                PostCode = contact.PostCode,
                City = contact.City,
                PhoneNo = contact.PhoneNo,
                Email = contact.Email
            };
        }

        public static UpdateContact ViewModelToServiceModel(ContactViewModel model)
        {
            return new UpdateContact()
            {
                ContactNo = model.ContactNo,
                FirstName = string.IsNullOrEmpty(model.FirstName) ? string.Empty : model.FirstName,                
                LastName = string.IsNullOrEmpty(model.LastName) ? string.Empty : model.LastName,
                Address = string.IsNullOrEmpty(model.Address) ? string.Empty : model.Address,                
                PostCode = string.IsNullOrEmpty(model.PostCode) ? string.Empty : model.PostCode,
                City = string.IsNullOrEmpty(model.City) ? string.Empty : model.City,
                PhoneNo = string.IsNullOrEmpty(model.PhoneNo) ? string.Empty : model.PhoneNo,
                Email = string.IsNullOrEmpty(model.Email) ? string.Empty : model.Email
            };
        }
    }
}