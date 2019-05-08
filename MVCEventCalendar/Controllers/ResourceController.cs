using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCEventCalendar.Controllers
{
    public class ResourceController : Controller
    {

        ClassroomAllocationSystemEntities1 entities = new ClassroomAllocationSystemEntities1();
        Question question = new Question();
        public ActionResult AddResources()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return View();
        }

        [HttpPost]
        public ActionResult AddResources(FormCollection form)
        {
            Resource resources = new Resource();
            //resources.ResourceId = Convert.ToInt32(form["ResourceId"]);
            resources.ResourceName = form["ResourceName"];
            entities.Resources.Add(resources);
            entities.SaveChanges();
            return View();
        }


        public PartialViewResult DeleteResource()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return PartialView("_DeleteResource", entities.Resources);
        }

      
        public ActionResult DeleteResource1(int id)
        {
            var user = entities.Resources.Find(id);
            // var user = entities.Resources.Where(e=>e.ResourceId== id).FirstOrDefault();
            entities.Resources.Remove(user);
            entities.SaveChanges();
            return RedirectToAction("Message", "Resource");
        }

       






        //public ActionResult DeleteResource(int id)
        //{
        //    Resource resource = entities.Resources.Find(id);
        //    entities.Resources.Remove(resource);
        //    entities.SaveChanges();
        //    return RedirectToAction("Welcome", "Resource");
        //}



        //public ActionResult Deleteresource(int id)
        //{
        //    Resource resource = entities.Resources.Find(id);
        //    return View(resource);
        //}

        //[HttpPost]
        //public ActionResult DeleteResource_Post(int id)
        //{
        //    Resource resource = entities.Resources.Find(id);
        //    entities.Resources.Remove(resource);
        //    entities.SaveChanges();
        //    return View();
        //}










        //public PartialViewResult DeleteResource()
        //{
        //    return PartialView("_DeleteResource",entities.Resources);
        //}
        //[HttpPost]
        //public ActionResult ConfirmDeleteRersource(int id)
        //{
        //    var result = entities.Resources.Find(id);
        //    entities.Resources.Remove(result);
        //    entities.SaveChanges();
        //    return RedirectToAction("Welcome", "resource");
        //}



        //public ActionResult DeleteResource(int id)
        //{
        //    Resource resource = entities.Resources.Find(id);
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult ConfirmDeleteResource(int id)
        //{
        //    Resource resource = entities.Resources.Find(id);
        //    entities.Resources.Remove(resource);
        //    entities.SaveChanges();
        //    return RedirectToAction("Welcome");
        //}
        //public ActionResult DeleteResource()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult DeleteResource(int id)
        //{
        //    var resource = entities.Resources.Find(id);
        //    entities.Resources.Remove(resource);
        //    entities.SaveChanges();
        //    return RedirectToAction("Welcome", "Resource");
        //}


        //public ActionResult DeleteResource(int id)
        //{
        //    entities.Resources.Remove(entities.Resources.Find(id));
        //    entities.SaveChanges();
        //    return RedirectToAction("Welcome");
        //}
        //public PartialViewResult DeleteResources()
        //{
        //    return PartialView("_DeleteResource", entities.Resources);
        //}
        //[HttpPost]
        //public ActionResult ConfirmDeleteResources(int id)
        //{
        //    var resource = entities.Resources.Where(e=>e.ResourceId==id).FirstOrDefault();
        //    entities.Resources.Remove(resource);
        //    entities.SaveChanges();
        //    return RedirectToAction("Welcome","Resource");
        //}

        //    public PartialViewResult DeleteResource()
        //{

        //}

        public ActionResult Message()
        {
            return View();
        }
        //public ActionResult UpdateResources(int id)
        //{
        //    var result = entities.Resources.Find(id);
        //    return View(result);
        //}

        //[HttpPost]
        //public ActionResult UpdateResources(Resource resource)
        //{

        //    entities.SaveChanges();
        //    return RedirectToAction("Updateresources","resource");
        //}

        public ActionResult Welcome()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return View();
        }
    }

   
}