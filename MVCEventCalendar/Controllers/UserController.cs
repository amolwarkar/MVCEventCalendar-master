using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventCalendar.Controllers
{
    public class UserController : Controller
    {
        ClassroomAllocationSystemEntities1 dc = new ClassroomAllocationSystemEntities1();

        Question question = new Question();
        // GET: User
        public ActionResult UserLogin()
        {
            if (Session["EmployeeNumber"] != null)
            {
                ViewBag.AllQuestions = new SelectList(dc.Questions.ToList(), "Question1", "Question1");
                ViewBag.data1 = new SelectList(dc.ClassRooms.ToList(), "ClassRoomId", "ClassroomName");
                return View();
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Login');window.location = '/Home/Index';</script>");
            }



        }

        public JsonResult GetEvents()
        {


            var events = (from e in dc.Events
                          join c in dc.ClassRooms
                           on e.ClassRoomId equals c.ClassRoomId
                          select new
                          {
                              e.EventID,
                              e.Subject,
                              e.Description,
                              e.Start,
                              e.End,

                              e.IsfullDay,
                              e.ClassRoomId,
                              c.ClassRoomName,
                              e.Employeeid

                          }).ToList();




            //var events = dc.Events.ToList();

            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        [HttpPost]
        public ActionResult SaveEvent(Event e)
        {
            var status = false;
            using (ClassroomAllocationSystemEntities1 dc = new ClassroomAllocationSystemEntities1())
            {

                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsfullDay = e.IsfullDay;

                        v.ClassRoomId = e.ClassRoomId;
                        v.Employeeid = e.Employeeid;
                        dc.SaveChanges();
                        status = true;

                    }
                }
                else
                {
                    var count = dc.ValidateBookingClassroom(e.Start, e.End, e.ClassRoomId).ToList();
                    int? save = count.FirstOrDefault();
                    Int32 insert = save.HasValue ? save.Value : 0;
                    if (insert == 0)
                    {
                        dc.Events.Add(e);
                        dc.SaveChanges();

                        status = true;

                    }
                    else
                    {
                        status = false;
                    }
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {

            var status = false;
            using (ClassroomAllocationSystemEntities1 dc = new ClassroomAllocationSystemEntities1())
            {

                var v = dc.Events.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Events.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult AllRooms()
        {
            if (Session["EmployeeNumber"] != null)
            {
                ViewBag.AllQuestions = new SelectList(dc.Questions.ToList(), "Question1", "Question1");   
                return View(dc.ClassRooms.ToList());
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Login');window.location = '/Home/Index';</script>");

            }
        }
        public ActionResult BookRoomByRequirements()
        {
            ViewBag.AllQuestions = new SelectList(dc.Questions.ToList(), "Question1", "Question1");

            return View(dc.Resources.ToList());
        }

        
        public ActionResult BookRoomByRequirementsCalender(FormCollection formCollection)
        {
            ViewBag.AllQuestions = new SelectList(dc.Questions.ToList(), "Question1", "Question1");

   

            int chair = Convert.ToInt32(formCollection["chairs"]);
            int pcs = Convert.ToInt32(formCollection["pcs"]);
            int projector = Convert.ToInt32(formCollection["projectors"]);
            if(chair==0)
            {
                chair = 0;
            }
            if (pcs==0)
            {
                pcs = 0;
            }
            if (projector==0)
            {
                projector = 0;
            }
            if(chair==0 && pcs==0 && projector == 0)
            {

                ViewBag.data1 = new SelectList(dc.ClassRooms.ToList(), "ClassRoomId", "ClassroomName");
            }
           
            else
            {
                var name = dc.GetResourcebyName(projector, chair, pcs).ToList();
                if (name == null){
                    return Content("<script language='javascript' type='text/javascript'>alert('Your requirements dont have any match');window.location = '/User/BookRoomByRequirements';</script>");
                                     
                }
                if (name.ToString() =="0" )
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Your requirements dont have any match');window.location = '/User/BookRoomByRequirements';</script>");

                }


                else
                { 
                     ViewBag.data1 = new SelectList(name);
                }
            }
            return View();
        }


        public ActionResult GiveFeedback()
        {
            ViewBag.AllQuestions = new SelectList(dc.Questions.ToList(), "Question1", "Question1");

            return View();
        }

        [HttpPost]
        public ActionResult GiveFeedback(FormCollection formCollection)
        {
            ViewBag.AllQuestions = new SelectList(dc.Questions.ToList(), "Question1", "Question1");
            DateTime date = DateTime.Now;
            string feedback = formCollection["Feedback1"];
            int employeeno=Convert.ToInt32(Session["EmployeeNumber"]);
            var result = dc.InsertFeedback(employeeno,feedback,date);
            return Content("<script language='javascript' type='text/javascript'>alert('Your feedback is recorded successfully');window.location = '/User/GiveFeedback';</script>");
          
        }
        
        public ActionResult showclassroomdetails(int id)
        {
            //int id = Convert.ToInt32(form["ClassroomId"]);
            ViewBag.AllQuestions = new SelectList(dc.Questions.ToList(), "Question1", "Question1");
            var result = dc.getResourcesbyClassroom(id);
            ViewBag.cs = id;
            return View(result.ToList());
            
        }
        
        public ActionResult showclassroomdetails1(FormCollection form)
        {
            ViewBag.AllQuestions = new SelectList(dc.Questions.ToList(), "Question1", "Question1");
            int a = Convert.ToInt32(form["classId"]);
            //var classroom = a[0];
            var cs = dc.ClassRooms.Where(s=>s.ClassRoomId==a).ToList();

            //ViewBag.AllQuestions = new SelectList(dc.Questions.ToList(), "Question1", "Question1");
            ViewBag.data1 = new SelectList(cs, "ClassRoomId", "ClassRoomName");

            return View();

        }



    }
}
