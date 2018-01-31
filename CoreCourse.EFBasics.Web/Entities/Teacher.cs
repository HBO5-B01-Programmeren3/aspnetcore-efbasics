using System.Collections.Generic;

namespace CoreCourse.EFBasics.Web.Entities
{
    public class Teacher
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal YearlyWage { get; set; }

        public ICollection<Course> Courses { get; set; }
    }

}
