using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCourse.EFBasics.Web.Entities
{
    public class StudentInfo
    {
        public long Id { get; set; }

        public long StudentId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// Navigation property to related Student
        /// </summary>
        public Student Student { get; set; }
    }


}
