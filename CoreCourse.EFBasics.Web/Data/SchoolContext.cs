using CoreCourse.EFBasics.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreCourse.EFBasics.Web.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
    }

}
