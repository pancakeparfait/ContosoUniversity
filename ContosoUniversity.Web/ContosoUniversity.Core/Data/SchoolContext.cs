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

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseId")
                    .MapRightKey("InstructorId")
                    .ToTable("CourseInstructor"));
        }
    }
}
