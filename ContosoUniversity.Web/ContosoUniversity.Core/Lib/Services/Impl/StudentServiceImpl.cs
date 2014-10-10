using System;
using System.Collections.Generic;
using ContosoUniversity.Core.Data;
using ContosoUniversity.Core.Data.Entities;

namespace ContosoUniversity.Core.Lib.Services.Impl
{
    public class StudentServiceImpl : EntityServiceBase, IStudentService
    {
        #region [Ctors]

        public StudentServiceImpl(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        public Student InsertOrUpdateStudent(int id, string lastName, string firstMidName, DateTime enrollmentDate)
        {
            return InsertOrUpdate<Student>(id, entity =>
            {
                entity.LastName = lastName;
                entity.FirstMidName = firstMidName;
                entity.EnrollmentDate = enrollmentDate;
            });
        }

        public IEnumerable<Student> GetAll()
        {
            return UnitOfWork.All<Student>();
        }
    }
}