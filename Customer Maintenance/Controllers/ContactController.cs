using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerMaintenance.WebServices;
using CustomerMaintenance.CustomerServiceReference;
using CustomerMaintenance.Models;
using System.Configuration;

namespace Customer_Maintenance.Controllers
{
    public class ContactController : Controller
    {
        private ServiceUserSettings _settings;

        public ContactController()
        {
            _settings = new ServiceUserSettings
            {
                BaseUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString(),
                UserAccount = ConfigurationManager.AppSettings["UserAccount"].ToString(),
                Password = ConfigurationManager.AppSettings["Password"].ToString()
            };
        }

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Update(string hashCode)
        {
            if(string.IsNullOrEmpty(hashCode))
                return RedirectToAction("Index", "Contact");

            CustomerService service = new CustomerService(_settings);
            ReadContact contact = new ReadContact();

            service.GetContact(hashCode, ref contact);

            return View(ContactViewModel.ServiceModelToViewModel(contact));
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ContactViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CustomerService service = new CustomerService(_settings);

                    UpdateContact contact = ContactViewModel.ViewModelToServiceModel(model);

                    service.UpdateContact(contact);
                }

                return RedirectToAction("Index", "Contact");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }
    }
}