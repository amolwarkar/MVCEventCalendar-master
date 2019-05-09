using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventCalendar.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image

        ClassroomAllocationSystemEntities1 entities = new ClassroomAllocationSystemEntities1();
        Question question = new Question();
        public ActionResult Image()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return View();
        }
        [HttpPost]
        public ActionResult Image(ClassRoom classRoom,String Command,string ClassRoomName, HttpPostedFileBase file1)
        {
            try
            {
                if (Command == "Create") { 
                if (file1 != null)
                {
                        string fileName = System.IO.Path.GetFileName(file1.FileName);

                        string filePath = "~/Content/Images/ClassroomImages" + fileName;

                        file1.SaveAs(Server.MapPath(filePath));
                        byte[] bytes = null;
                        using (BinaryReader br = new System.IO.BinaryReader(file1.InputStream))
                        {
                            bytes = br.ReadBytes(file1.ContentLength);
                        }
                        using (SqlConnection connection = new SqlConnection("server=VDI-NET-0010\\LOCAL;database=ClassroomAllocationSystem;trusted_connection=true"))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand("insert into ClassRooms(ClassRoomName,ClassroomImage) values(@name,@image)", connection);
                            command.Parameters.AddWithValue("@name", ClassRoomName);
                            command.Parameters.AddWithValue("@image", bytes);
                            command.ExecuteNonQuery();
                        }
                            return Content("<script languagr='javascript' type='text/javascript'>alert('Data added to the database successfully');windows.location='/Admin/Welcome';</script>");                        
                    }
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult List()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            List<ClassRoom> classRooms = GetClasses();
           
            return View(classRooms);
        }
        public ActionResult Delete()
        {
            ViewBag.AllQuestions = new SelectList(entities.Questions.ToList(), "Question1", "Question1");
            return PartialView("_DeleteClassroom", entities.ClassRooms);
        }

        private List<ClassRoom> GetClasses()
        {
            List<ClassRoom> images = new List<ClassRoom>();
            SqlConnection connection = new SqlConnection("server=VDI-NET-0015\\LOCAL;database=ClassroomAllocationSystem;trusted_connection=true");
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from ClassRooms", connection);
            using (SqlDataReader sdr = command.ExecuteReader())
            {
                while (sdr.Read())
                {
                    images.Add(new ClassRoom
                    {
                       
                        ClassRoomName = sdr["ClassRoomName"].ToString(),
                        
                        ClassroomImage = (byte[])sdr["ClassroomImage"],
 
                    }

                    );
                    
                }
            }
            connection.Close();
            return images;
        }
        //public ActionResult Delete()
        //{
        //    return View();
        //}

    }
}