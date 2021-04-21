using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N01366903_Cumulative_Part_1_Att2.Models;

namespace N01366903_Cumulative_Part_1_Att2.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/List
        public ActionResult List()
        {
            Teacher model = new Teacher();
            List<Teacher> lstT = new List<Teacher>();
            var listOfTeachers = new TeacherDataController().GetListTeachers();
            return View(listOfTeachers);

        }
        public ActionResult Show(int id)
        {
            CoursesViewModel model = new CoursesViewModel();
            List<CoursesViewModel> lstT = new List<CoursesViewModel>();
            var listOfTeachersCourse = new TeacherDataController().GetListTeachersCourses(id);
            return View(listOfTeachersCourse);
        }
        
    }
}