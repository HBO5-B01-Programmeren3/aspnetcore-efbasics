using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCourse.EFBasics.Web.Entities
{
    public class Student
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public decimal? Scholarship { get; set; }

        /// <summary>
        /// Navigation property to related StudentCourses
        /// </summary>
        public ICollection<StudentCourse> StudentCourses { get; set; }

        /// <summary>
        /// Navigation property to related StudentInfo
        /// </summary>
        public StudentInfo ContactInfo { get; set; }
    }

}
