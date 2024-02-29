using Event_Management_System_CRUD_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Event_Management_System_CRUD_Application.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        private static List<Event> _events = new List<Event>
        {
            new Event { EventID = 1, EventName = "Event 1", EventDate = DateTime.Now, Location = "Location 1", Description = "Description 1" },
            new Event { EventID = 2, EventName = "Event 2", EventDate = DateTime.Now.AddDays(1), Location = "Location 2", Description = "Description 2" },
        };

        private static readonly List<Registration> _registrations = new List<Registration>();

        public IActionResult Index()
        {
            try
            {
                return View(_events);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View(new List<Event>());
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event newEvent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newEvent.EventID = _events.Count + 1;
                    _events.Add(newEvent);
                    return RedirectToAction("Index");
                }

                return View(newEvent);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View(newEvent);
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                var existingEvent = _events.FirstOrDefault(e => e.EventID == id);

                if (existingEvent == null)
                {
                    return NotFound();
                }

                return View(existingEvent);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(Event updatedEvent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingEvent = _events.FirstOrDefault(e => e.EventID == updatedEvent.EventID);

                    if (existingEvent != null)
                    {
                        existingEvent.EventName = updatedEvent.EventName;
                        existingEvent.EventDate = updatedEvent.EventDate;
                        existingEvent.Location = updatedEvent.Location;
                        existingEvent.Description = updatedEvent.Description;
                    }

                    return RedirectToAction("Index");
                }

                return View(updatedEvent);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return View(updatedEvent);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var existingEvent = _events.FirstOrDefault(e => e.EventID == id);

                if (existingEvent == null)
                {
                    return NotFound();
                }

                return View(existingEvent);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var existingEvent = _events.FirstOrDefault(e => e.EventID == id);

                if (existingEvent != null)
                {
                    _events.Remove(existingEvent);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult RegisterAttendee(int eventId)
        {
            try
            {
                var existingEvent = _events.FirstOrDefault(e => e.EventID == eventId);

                if (existingEvent == null)
                {
                    return NotFound();
                }

                ViewBag.EventId = eventId;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult RegisterAttendee(Registration registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _registrations.Add(registration);
                    return RedirectToAction("Index");
                }

                return View(registration);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
