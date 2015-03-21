using System;
using System.Linq;
using ContosoUniversity.Core.Data.Entities;

namespace ContosoUniversity.Core.Lib.Services
{
    public interface IStudentService : IEntityService
    {
        Student InsertOrUpdateStudent(int id, string lastName, string firstMidName, DateTime enrollmentDate);
        IQueryable<Student> GetAll();
    }
}
