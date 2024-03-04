using System;
using System.Collections.Generic;
using EMS_BLL;
using EMS_ENTITIES;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event_Management_System_CRUD_Application.Controllers
{
    public class RegistrationController : Controller
    {
        public ActionResult Index(int eventId)
        {
            Registration_Service registrationService = new Registration_Service();
            var registrations = registrationService.GetAllRegistrations(eventId);
            TempData["EventId"] = eventId;
            TempData.Keep();
            return View(registrations);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            var events = new Event_Service().GetAllEvents();
            ViewBag.Events = events;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Registration registration)
        {
            try
            {
                Registration_Service registrationService = new Registration_Service();
                bool result = registrationService.AddRegistrationService(registration);
                if (result)
                {
                    return RedirectToAction("Index", new { eventId = registration.EventID });
                }
                else
                {
                    return View(registration);
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Registration_Service registrationService = new Registration_Service();
            var specificRegistration = registrationService.GetAllRegistrations(0).Find(r => r.RegistrationID == id);
            return View(specificRegistration);
        }

        [HttpPost]
        public ActionResult Edit(Registration r)
        {
            try
            {
                Registration_Service registrationService = new Registration_Service();
                bool result = registrationService.UpdateRegistrationService(r);
                if (result)
                {
                    ViewBag.Message = "Registration updated successfully";
                    return View();
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int registrationId)
        {
            Registration_Service registrationService = new Registration_Service();
            if (registrationService.DeleteRegistrationService(registrationId))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}