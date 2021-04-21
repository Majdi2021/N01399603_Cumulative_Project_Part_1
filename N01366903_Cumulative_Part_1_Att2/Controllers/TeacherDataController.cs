using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using N01366903_Cumulative_Part_1_Att2.Models;
using MySql.Data.MySqlClient;

namespace N01366903_Cumulative_Part_1_Att2.Controllers
{

    public class TeacherDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext school = new SchoolDbContext();

        //This Controller Will access the teacher table of our school database.
        /// <summary>
        /// Returns a list of Teachers
        /// </summary>
        /// <example>GET api/TeacherData/GetListTeachers</example>
        /// <returns>
        /// A list of teachers
        /// </returns>

        [HttpGet]
        public IEnumerable<Teacher> GetListTeachers()
        {
            //Create an instance of a connection
            MySqlConnection Conn = school.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teacher Names
            List<Teacher> TeacherList = new List<Teacher>();
            Teacher obj = new Teacher();
            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                obj.teacherid = Convert.ToInt32(ResultSet["teacherid"]);
                obj.teacherfname = ResultSet["teacherfname"].ToString();
                obj.teacherlname = ResultSet["teacherlname"].ToString();
                obj.hiredate = Convert.ToDateTime(ResultSet["hiredate"]);
                obj.salary = Convert.ToDecimal(ResultSet["salary"]);
                
                TeacherList.Add(obj);
            }

            //Close the connection 
            Conn.Close();

            //Return the final list of Teachers
            return TeacherList;
        }

        /// <summary>
        /// Returns a list of Courses tought by Teachers
        /// </summary>
        /// <example>GET api/TeacherData/GetListTeachersCourses</example>
        /// <returns>
        /// A show of courses/classes
        /// </returns>

        [HttpGet]
        public IEnumerable<CoursesViewModel> GetListTeachersCourses(int TeacherId)
        {
            //Create an instance of a connection
            MySqlConnection Conn = school.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes where teacherid=" + +TeacherId + "";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Courses Names
            List<CoursesViewModel> TeacherCourseList = new List<CoursesViewModel>();
            CoursesViewModel obj = new CoursesViewModel();

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                obj.teacherid = Convert.ToInt32(ResultSet["teacherid"]);
                obj.classcode = ResultSet["classcode"].ToString();
                obj.classid = Convert.ToInt32(ResultSet["classid"]);
                obj.classname = ResultSet["classname"].ToString();
                obj.startdate = Convert.ToDateTime(ResultSet["startdate"]);
                obj.finishdate = Convert.ToDateTime(ResultSet["finishdate"]);

                TeacherCourseList.Add(obj);
            }

            //Close the connection 
            Conn.Close();

            //Return the final list of Teachers
            return TeacherCourseList;
        }
    }
}
