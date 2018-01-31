using System;

namespace CoreCourse.EFBasics.Web.Entities
{
    public class Course
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Teacher Lecturer { get; set; }
    }
}
