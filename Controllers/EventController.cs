using Event_Management_System_CRUD_Application.Models;
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
            EventService eventService = new EventService();
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
                EventService eventService = new EventService();
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
            EventService eventService = new EventService();
            var specificEvent = eventService.GetAllEvents().Find(e => e.EventId == id);
            return View(specificEvent);
        }

        [HttpPost]
        public ActionResult Edit(Event e)
        {
            try
            {
                EventService eventService = new EventService();
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
            EventService eventService = new EventService();
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
