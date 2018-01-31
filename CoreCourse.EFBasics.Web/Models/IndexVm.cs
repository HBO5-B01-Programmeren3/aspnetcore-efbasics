using CoreCourse.EFBasics.Web.Entities;
using System.Collections.Generic;

namespace CoreCourse.EFBasics.Web.Models
{
    public class IndexVm
    {
        /// <summary>
        /// Holds Teacher with Id = 1
        /// </summary>
        public Teacher TeacherWidthIdOne { get; set; }

        /// <summary>
        /// Holds all students born before 2000 ordered by Name
        /// </summary>
        public IEnumerable<Student> StudentsBornBefore2k { get; set; }

        /// <summary>
        /// The total amount of scholarship grants
        /// </summary>
        public decimal TotalScholarships { get; set; }

        /// <summary>
        /// Holds students with a scholarship, with their StudentInfo loaded
        /// Students are ordered by Scholarship, then by name
        /// </summary>
        public IEnumerable<Student> ScholarshipStudentsWithInfo { get; set; }

        /// <summary>
        /// All courses, with all related Teacher, StudentCourse and Students loaded
        /// </summary>
        public IEnumerable<Course> Courses { get; set; }
    }

}
