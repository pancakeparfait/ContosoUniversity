using System;
using System.Linq;
using ContosoUniversity.Core.Data.Entities;

namespace ContosoUniversity.Core.Lib.Extensions
{
    public static class EnumerableExtensions
    {
        public static IQueryable<Student> SearchBy(this IQueryable<Student> source, string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return source.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                    || s.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
            }
            return source;
        }

        public static IQueryable<Student> OrderBy(this IQueryable<Student> source, string sortOrder)
        {
            switch (sortOrder)
            {
                case "name_desc":
                    return source.OrderByDescending(s => s.LastName);
                case "Date":
                    return source.OrderBy(s => s.EnrollmentDate);
                case "date_desc":
                    return source.OrderByDescending(s => s.EnrollmentDate);
                default:
                    return source.OrderBy(s => s.LastName);
            }
        }
    }
}
