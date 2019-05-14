using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCEventCalendar.Controllers
{
    
    public class HomeController : Controller
    {

        ClassroomAllocationSystemEntities1 entities = new ClassroomAllocationSystemEntities1();

        Question question = new Question();
        
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return View();
        }

        //login validation 
        [HttpPost]
        public ActionResult Login(AdminDetail adminDetail, FormCollection formCollection)
        {
            string user = formCollection["Username"];
            string pass = formCollection["Password"];
       
            var adminResult = entities.AdminDetails.Where(s => s.Username == user && s.Password == pass).FirstOrDefault();
            if (adminResult != null)
            {
                Session["Username"] = adminResult.Username;
                Session["EmployeeNumber"] = adminResult.EmployeeNumber;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var userResult = entities.UserRegistrationDetails.Where(q => q.Username == adminDetail.Username && q.Password == adminDetail.Password).FirstOrDefault();
                if (userResult == null)
                {
                    // return View();
                    return Content("<script language='javascript' type='text/javascript'>alert('User Not Found');window.location = 'Index';</script>");

           
                    
                }
                else
                {
                    Session["Username"] = userResult.Username;
                    Session["EmployeeNumber"] = userResult.EmployeeNumber;
                    return RedirectToAction("UserLogin", "User");
                }
            }
        }


        //Register

        [HttpPost]
        public ActionResult Register(FormCollection formCollection)
        {
            int empId = Convert.ToInt32(formCollection["EmployeeNumber"]);

            //check the record is already available or not
            var checkRegistration = entities.UserRegistrationDetails.Where(q => q.EmployeeNumber == empId).FirstOrDefault();
            if (checkRegistration == null)
            {
                //inserting data into User registration details table
                UserRegistrationDetail user = new UserRegistrationDetail();
                user.EmployeeNumber = empId;
                user.EmployeeName = formCollection["EmployeeName"];
                user.ContactNumber = formCollection["ContactNumber"];
                user.Username = formCollection["NewUsername"];
                user.Password = formCollection["Pass"];
                entities.UserRegistrationDetails.Add(user);

                //adding data in user questions details
                UserQuestionDetail userQuestion = new UserQuestionDetail();
                string qname = formCollection["AllQuestions"];
                int qid = (from res in entities.Questions
                           where res.Question1 == qname
                           select res.QuestionId).FirstOrDefault();

                userQuestion.QuestionId = qid;
                userQuestion.Answer = formCollection["Answer"];
                userQuestion.EmpoyeeNumber = Convert.ToInt32(formCollection["EmployeeNumber"]);
                entities.UserQuestionDetails.Add(userQuestion);
                entities.SaveChanges();

                return Content("<script language='javascript' type='text/javascript'>alert('Employee Registered Successfully');window.location = 'Index';</script>");
            }
            else
            {
                //   Content("<script language='javascript' type='text/javascript'>alert('This EmployeeId already Registered');window.location = "Index";</script>");


                return Content("<script language='javascript' type='text/javascript'>alert('This EmployeeId already Registered');window.location = 'Index';</script>");

            }




        }


        //Forgot Password

        public ActionResult ForgotPass()
        {
            
                ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
                return View();
            
            
        }


        [HttpPost]
        public ActionResult ForgotPass(FormCollection formCollection)
        {
            if (formCollection["EmployeeId"] == "")
            {
                return RedirectToAction("ForgotPass");
            }
            else
            {
                try
                {
                    int empid = Convert.ToInt32(formCollection["EmployeeId"]);
                    int questionId = entities.UserQuestionDetails.Where(s => s.EmpoyeeNumber == empid).First().QuestionId;
                    Session["forgotPassEmployeeId"] = empid;
                    TempData["EmployeeId"] = empid;
                    TempData["question"] = (from res in entities.Questions
                                            where res.QuestionId == questionId
                                            select res.Question1).FirstOrDefault();
                    return RedirectToAction("ForgotPass");
                }
                catch (Exception)
                {

                    return Content("<script language='javascript' type='text/javascript'>alert('This EmployeeId is not registered yet');window.location = 'ForgotPass';</script>");
                }
            }
        }


        [HttpPost]
        public ActionResult GetPassword(FormCollection formCollection)
        {
            string ans = formCollection["Answer"];
            int empid = Convert.ToInt32(TempData["EmployeeId"]);
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            var result = entities.UserQuestionDetails.Where(s => s.EmpoyeeNumber == empid && s.Answer == ans).FirstOrDefault();
            if (result != null)
            {
                var data = entities.UserRegistrationDetails.Where(s => s.EmployeeNumber == result.EmpoyeeNumber).ToList();
                return View();
            }
            else
            {
                //return RedirectToAction("ForgotPass");
                return Content("<script language='javascript' type='text/javascript'>alert('Wrong Answer');window.location = 'ForgotPass';</script>");
            }
        }


        //resetting password
        public ActionResult setNewPassword(FormCollection formCollection)
        {
            int eid = Convert.ToInt32(Session["forgotPassEmployeeId"]);
            var fetchData = entities.UserRegistrationDetails.Where(w => w.EmployeeNumber == eid).FirstOrDefault();
            var newPassword = formCollection["newPass"];
            fetchData.Password = newPassword;
            entities.SaveChanges();
            return RedirectToAction("Index", "Home");
        }



        //logout 
        public ActionResult LogoutSystem()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return View();
        }





    }
}