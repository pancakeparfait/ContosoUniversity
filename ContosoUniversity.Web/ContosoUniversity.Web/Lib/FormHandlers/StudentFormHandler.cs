using ContosoUniversity.Core.Data.Entities;
using ContosoUniversity.Core.Lib.Services;

namespace ContosoUniversity.Web.Lib.FormHandlers
{
    public class StudentFormHandler : FormHandlerBase<Student>
    {
        #region [Properties]

        private readonly IStudentService _studentService;

        #endregion

        #region [Ctors]

        public StudentFormHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        #endregion

        public override void Handle(Student form)
        {
            _studentService.InsertOrUpdateStudent(
                form.Id,
                form.LastName,
                form.FirstMidName,
                form.EnrollmentDate);
            _studentService.SaveChanges();
        }
    }
}