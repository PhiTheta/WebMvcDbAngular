using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_SchoolTest.DataAccessLayer;
using WebApplication_SchoolTest.Models;

namespace WebApplication_SchoolTest.Controllers
{
    public class CourseVm
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Instructor { get; set; }
    }

    public class CoursesController : Controller
    {
        private SchoolContext db = new SchoolContext();

        public string GetSerializedCourseVms()
        {
            var courses = new[]
                {
                    new CourseVm {Number = "CREA101", Name = "Care of Magical Creatures", Instructor = "Rubeus Hagrid"},
                    new CourseVm { Number = "DARK502", Name = "Defence Against the Dark Arts", Instructor = "Severus Snape"},
                    new CourseVm {Number = "TRAN201", Name = "Transfiguration", Instructor = "Minerva McGonagall"},
                };
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return JsonConvert.SerializeObject(courses, Formatting.None, settings);
        }

        // GET: Courses
        public ActionResult Index()
        {

            //return View(Json(db.Courses.ToList(), JsonRequestBehavior.AllowGet));

            var data = db.Enrollments.Join(db.Courses,
                    e => e.CourseID,
                    c => c.CourseID,
                    (e, c) => new { e, c })

            .Join(db.Students,
                    d => d.e.StudentID,
                    s => s.ID,
                    (d, s) => new DbEnrollments
                    {
                        EnrollmentID = d.e.EnrollmentID,
                        _Course = d.c,
                        _Student = s,
                        Grade = d.e.Grade
                    });

            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            return View("Index", "", JsonConvert.SerializeObject(data.ToArray(), Formatting.None, settings));
            //return View("Index", "", Json(db.Courses.ToList(), JsonRequestBehavior.AllowGet).ToString());
            //return View("Index", "", GetSerializedCourseVms());

        }

        // GET: Courses
        public ActionResult Index2()
        {
            return View();
        }

        //// GET: Courses
        //public JsonResult Index2()
        //{

        //    //return View(Json(db.Courses.ToList(), JsonRequestBehavior.AllowGet));

        //    var data = db.Enrollments.Join(db.Courses,
        //            e => e.CourseID,
        //            c => c.CourseID,
        //            (e, c) => new { e, c })

        //    .Join(db.Students,
        //            d => d.e.StudentID,
        //            s => s.ID,
        //            (d, s) => new DbEnrollments
        //            {
        //                EnrollmentID = d.e.EnrollmentID,
        //                _Course = d.c,
        //                _Student = s,
        //                Grade = d.e.Grade
        //            });

        //    //var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        //    //return JsonConvert.SerializeObject(data.ToArray(), Formatting.None, settings);
        //    //return View("Index", "", Json(db.Courses.ToList(), JsonRequestBehavior.AllowGet).ToString());
        //    //return View("Index", "", GetSerializedCourseVms());
        //    return Json(db.Courses.ToList(), JsonRequestBehavior.AllowGet);
        //}


        public ActionResult DataGet()
        {
            //var movies = new List<object>();

            //movies.Add(new { Title = "Ghostbusters", Genre = "Comedy", Year = 1984 });
            //movies.Add(new { Title = "Gone with Wind", Genre = "Drama", Year = 1939 });
            //movies.Add(new { Title = "Star Wars", Genre = "Science Fiction", Year = 1977 });

            //return View("Index", "", Json(movies, JsonRequestBehavior.AllowGet).ToString());
            ////return Json(db.Courses.ToList(), JsonRequestBehavior.AllowGet);

            ////return View(db.Courses.ToList());
            ////var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            ////return JsonConvert.SerializeObject(db.Courses.ToArray(), Formatting.None, settings);

            var data = db.Enrollments.Join(db.Courses,
                    e => e.CourseID,
                    c => c.CourseID,
                    (e, c) => new { e, c })

            .Join(db.Students,
                    d => d.e.StudentID,
                    s => s.ID,
                    (d, s) => new DbEnrollments
                    {
                        EnrollmentID = d.e.EnrollmentID,
                        _Course = d.c,
                        _Student = s,
                        Grade = d.e.Grade
                    });

            //var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            //return JsonConvert.SerializeObject(data.ToArray(), Formatting.None, settings);
            //return View("Index", "", Json(db.Courses.ToList(), JsonRequestBehavior.AllowGet).ToString());
            //return View("Index", "", GetSerializedCourseVms());
            return Json(db.Courses.ToList(), JsonRequestBehavior.AllowGet);

        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Title,Credits,EnrollmentID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,EnrollmentID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
