using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace libbook.Controllers
{
    public class TeacherController : Controller
    {
        Services.Teacher m_teacher = new Services.Teacher();
        public ActionResult Index()
        {
            var teachers = m_teacher.GetAllTeachers();
            return View(teachers);
        }
        //автозаполнение на форме
        public JsonResult Autocomplete(string term)
        {
            var teacher = m_teacher.GetTeacher(term);
            return Json(
                new
                {
                    teacher = teacher
                }, JsonRequestBehavior.AllowGet);
        }
    }
}