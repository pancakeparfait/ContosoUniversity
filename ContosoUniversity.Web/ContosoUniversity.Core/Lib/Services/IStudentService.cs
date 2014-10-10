using System;
using System.Collections.Generic;
using ContosoUniversity.Core.Data.Entities;

namespace ContosoUniversity.Core.Lib.Services
{
    public interface IStudentService : IEntityService
    {
        Student InsertOrUpdateStudent(int id, string lastName, string firstMidName, DateTime enrollmentDate);
        IEnumerable<Student> GetAll();
    }
}
