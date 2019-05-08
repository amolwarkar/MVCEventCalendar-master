using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCEventCalendar.Controllers
{
    public class ClassroomController : Controller
    {
        

        ClassroomAllocationSystemEntities1 entities = new ClassroomAllocationSystemEntities1();
        // GET: Classroom
        Question question = new Question();
        public ActionResult AddClassroom()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return View();
        }

        [HttpPost]
        public ActionResult AddClassroom(ClassRoom model,string ClassRoomName, HttpPostedFileBase ClassroomImage)
        {
            try
            {
                if (ClassroomImage != null)
                {
                    model.ClassroomImage = new byte[ClassroomImage.ContentLength];
                    ClassroomImage.InputStream.Read(model.ClassroomImage, 0, ClassroomImage.ContentLength);
                }  
             
                string fileName = Path.GetFileName(ClassroomImage.FileName);
                string filePath = "~/Content/Images/ClassroomImages" + fileName;
                ClassroomImage.SaveAs(Server.MapPath(filePath));
               
                entities.ClassRooms.Add(model);
                entities.SaveChanges();

                return RedirectToAction("Welcome", "Resource");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public PartialViewResult DeleteClassroom()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return PartialView("_DeleteClassroom", entities.ClassRooms);
        }

        public ActionResult ConfirmDeleteClassroom(int id)
        {
            var user = entities.ClassRooms.Find(id);
            entities.ClassRooms.Remove(user);
            entities.SaveChanges();
            return RedirectToAction("Welcome","Resource");
        }
    }
}