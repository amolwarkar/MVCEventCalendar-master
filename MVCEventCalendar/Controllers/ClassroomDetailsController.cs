using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEventCalendar;

namespace MVCEventCalendar.Controllers
{
    public class ClassroomDetailsController : Controller
    {

        ClassroomAllocationSystemEntities1 entities = new ClassroomAllocationSystemEntities1();
        // GET: ClassroomDetails
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddClassroomDetails()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            ClassRoom room = new ClassRoom();
            Resource resource = new Resource();
            ViewBag.AllResourceId = new SelectList(entities.Resources.ToList(), "ResourceId", "ResourceName");
            ViewBag.AllClassroomId = new SelectList(entities.ClassRooms.ToList(), "ClassRoomId", "ClassRoomName");
            return View();
        }

        [HttpPost]
        public ActionResult AddClassroomDetails(FormCollection form)
        {
          
            ClassRoomDetail detail = new ClassRoomDetail();
            detail.ClassroomId =Convert.ToInt32( form["AllClassroomId"]);
            detail.ResourceQuantity =Convert.ToInt32(form["ResourceQuantity"]);
            detail.ResourceId = Convert.ToInt32(form["AllResourceId"]);
            entities.ClassRoomDetails.Add(detail);
            entities.SaveChanges();
            return RedirectToAction("List", "ClassroomDetails");

        }

        public ActionResult List()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return View(entities.ClassRoomDetails.ToList());
        }
       
        public ActionResult DeleteClassRoomDetails(int id)
        {
            var result = entities.ClassRoomDetails.Find(id);
            entities.ClassRoomDetails.Remove(result);
            entities.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult UpdateClassroomDetails(int id)
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            ViewBag.AllResourceId = new SelectList(entities.Resources.ToList(), "ResourceId", "ResourceName");
            ViewBag.AllClassroomId = new SelectList(entities.ClassRooms.ToList(), "ClassroomId", "ClassroomName");
            ClassRoomDetail user = entities.ClassRoomDetails.Where(e => e.DetailsId == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateClassroomDeatils(FormCollection collection)
        {
            ClassRoomDetail classRoom = new ClassRoomDetail();
            var user = entities.ClassRoomDetails.Where(r => r.DetailsId ==classRoom.DetailsId).FirstOrDefault();
            classRoom.ResourceId = Convert.ToInt32(collection["AllResourceId"]);
            classRoom.ResourceQuantity = Convert.ToInt32(collection["ResourceQuantity"]);
            classRoom.ClassroomId = Convert.ToInt32(collection["AllClassroomId"]);
            entities.SaveChanges();
            return RedirectToAction("List");
        }

    }
}