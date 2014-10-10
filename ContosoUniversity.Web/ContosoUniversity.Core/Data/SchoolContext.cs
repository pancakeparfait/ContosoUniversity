using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ContosoUniversity.Core.Data.Entities;

namespace ContosoUniversity.Core.Data
{
    public class SchoolContext : DbContext
    {
        #region [Ctors]

        public SchoolContext()
            : base("SchoolContext")
        {
        }

        #endregion

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
