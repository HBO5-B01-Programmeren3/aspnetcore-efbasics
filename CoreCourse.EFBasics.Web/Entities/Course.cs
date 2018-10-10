using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCourse.EFBasics.Web.Entities
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Navigation property to related Teacher
        /// </summary>
        public Teacher Lecturer { get; set; }

        /// <summary>
        /// Navigation property to related StudentCourses
        /// </summary>
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
