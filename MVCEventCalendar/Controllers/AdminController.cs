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
            if (Session["EmployeeNumber"] != null)
            {

                ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
                return View();
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Please Login First');window.location = '/Home/Index';</script>");
            }
        }

        //after adding new resource
        [HttpPost]
        public ActionResult AddResource(Resource form)
        {
            try
            {
                Resource resource = new Resource();
                resource.ResourceName = form.ResourceName;
                entities.Resources.Add(resource);
                entities.SaveChanges();
                //return View("List");
               // return RedirectToAction("List", "Admin");
                return Content("<script languagr='javascript' type='text/javascript'>alert('Resource added to the database successfully');window.location = '/Home/Index';</script>");
            }
            catch(Exception)
            {
                return Content("<script languagr='javascript' type='text/javascript'>alert('Resource already in the database');window.location = '/Admin/AddResource';</script>");
            }
        }

        public ActionResult List()
        {
            if (Session["EmployeeNumber"] != null)
            {
                ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
                return View(entities.Resources);
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Please Login First');window.location = '/Home/Index';</script>");
            }
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