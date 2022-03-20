using datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace libbook.Controllers
{
    public class StudentController : Controller
    {
        Services.Student m_student = new Services.Student(); 
        Entities db = new Entities();
        // GET: Student
        public ActionResult Index()
        {

            return View();
        }
        public JsonResult Autocomplete(string term)
        {
            var student = m_student.GetStudent(term);
            return Json(
                new
                {
                    student = student
                }, JsonRequestBehavior.AllowGet);
        }
    }
}