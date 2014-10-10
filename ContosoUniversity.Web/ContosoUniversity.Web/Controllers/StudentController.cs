using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ContosoUniversity.Core.Data.Entities;
using ContosoUniversity.Core.Data;
using ContosoUniversity.Core.Lib.Extensions;
using ContosoUniversity.Core.Lib.Services;
using PagedList;

namespace ContosoUniversity.Web.Controllers
{
    public class StudentController : BaseController
    {
        #region [Properties]

        private readonly IStudentService _studentService;
        private readonly SchoolContext _db;

        #endregion

        #region [Ctors]

        public StudentController(SchoolContext db, IStudentService studentService)
        {
            _db = db;
            _studentService = studentService;
        }

        #endregion

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            return Get(() =>
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

                if (searchString != null)
                    page = 1;
                else
                    searchString = currentFilter;

                ViewBag.CurrentFilter = searchString;

                var students = _studentService.GetAll().SearchBy(searchString).OrderBy(sortOrder);

                const int pageSize = 3;
                var pageNumber = (page ?? 1);
                return View(students.ToPagedList(pageNumber, pageSize));
            });
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            return Get(() =>
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var student = _studentService.GetById<Student>(id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            });
        }

        // GET: /Student/Create
        public ActionResult Create()
        {
            return Get(View);
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            return Form(student, () => RedirectToAction("Index"), () => View(student));

            return Get(() =>
            {
                if (ModelState.IsValid)
                {
                    _db.Students.Add(student);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(student);
            }, () => View(student));
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            return Get(() =>
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var student = _studentService.GetById<Student>(id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            });
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            return Get(() =>
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(student).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(student);
            }, () => View(student));
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage =
                    "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            var student = _studentService.GetById<Student>(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            return Get(() =>
            {
                var student = _studentService.GetById<Student>(id);
                _db.Students.Remove(student);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }, () => RedirectToAction("Delete", new { id, saveChangesError = true }));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
