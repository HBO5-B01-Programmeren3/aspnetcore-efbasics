using System;

namespace CoreCourse.EFBasics.Web.Entities
{
    public class StudentCourse
    {
        /// <summary>
        /// The Foreign key of the Student entity.
        /// </summary>
        public long StudentId { get; set; }

        /// <summary>
        /// The Foreign key of the Course entity.
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// A navigation property to Student entity
        /// </summary>
        public Student Student { get; set; }

        /// <summary>
        /// A navigation property to Course entity
        /// </summary>
        public Course Course { get; set; }

    }
}
