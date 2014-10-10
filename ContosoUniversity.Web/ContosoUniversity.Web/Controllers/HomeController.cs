using System.Linq;
using System.Web.Mvc;
using ContosoUniversity.Core.Data;
using ContosoUniversity.Web.Models;

namespace ContosoUniversity.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region [Properties]

        private readonly SchoolContext _db;

        #endregion

        #region [Ctors]

        public HomeController(SchoolContext db)
        {
            _db = db;
        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var data = _db.Students.GroupBy(x => x.EnrollmentDate).Select(x => new EnrollmentDateGroupModel
            {
                EnrollmentDate = x.Key,
                StudentCount = x.Count()
            });
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}