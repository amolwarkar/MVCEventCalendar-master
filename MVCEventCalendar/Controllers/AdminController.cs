using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEventCalendar;

namespace MVCEventCalendar.Controllers
{
    public class AdminController : Controller
    {
        ClassroomAllocationSystemEntities1 entities = new ClassroomAllocationSystemEntities1();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return View();
        }

        
        public ActionResult AddResource()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return View();
        }

        //after adding new resource
        [HttpPost]
        public ActionResult AddResource(Resource form)
        {
            Resource resource = new Resource();
            resource.ResourceName =form.ResourceName;
            entities.Resources.Add(resource);
            entities.SaveChanges();
            //return View("List");
            return RedirectToAction("List","Admin");
        }

        public ActionResult List()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            //return PartialView("_AdminList",entities.Resources);
            return View(entities.Resources);
        }
   
        public ActionResult DeleteResources(int id)
        {
            var result = entities.ClassRoomDetails.Where(e => e.ResourceId == id);
            entities.ClassRoomDetails.RemoveRange(result);
            entities.SaveChanges();
            var user = entities.Resources.Find(id);
            entities.Resources.Remove(user);
            entities.SaveChanges();
            return RedirectToAction("List","Admin");
            //return PartialView("_AdminList", entities.Resources);
        }

        public ActionResult Welcome()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return View();
        }
    }
}