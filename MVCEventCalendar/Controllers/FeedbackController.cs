using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventCalendar.Controllers
{
    public class FeedbackController : Controller
    {

        ClassroomAllocationSystemEntities1 entities = new ClassroomAllocationSystemEntities1();
        // GET: Feedback
        Question question = new Question();
        public ActionResult ViewFeedback()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            var result = entities.Feedbacks;
           // ViewBag.Allfeedback = result;
            return View(result.ToList());
        }
    }
}