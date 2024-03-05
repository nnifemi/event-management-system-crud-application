using Event_Management_System_CRUD_Application.Controllers;
using EMS_BLL;
using EMS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Event_Management_System_CRUD_Application.Controllers
{
    public class EventController : Controller
    {
        public ActionResult Index()
        {
            Event_Service eventService = new Event_Service();
            var events = eventService.GetAllEvents();
            return View(events);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event e)
        {
            try
            {
                Event_Service eventService = new Event_Service();
                if (eventService.AddEventService(e))
                {
                    ViewBag.Message = "Event added successfully";
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

        public ActionResult Edit(int id)
        {
            Event_Service eventService = new Event_Service();
            var specificEvent = eventService.GetAllEvents().Find(e => e.EventID == id);
            return View(specificEvent);
        }

        [HttpPost]
        public ActionResult Edit(Event e)
        {
            try
            {
                Event_Service eventService = new Event_Service();
                if (eventService.UpdateEventService(e))
                {
                    ViewBag.Message = "Event updated successfully";
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

        public ActionResult Delete(int eventId)
        {
            Event_Service eventService = new Event_Service();
            if (eventService.DeleteEventService(eventId))
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
