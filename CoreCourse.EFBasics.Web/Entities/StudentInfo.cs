using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.EFBasics.Web.Entities
{
    public class StudentInfo
    {
        public long Id { get; set; }

        public long StudentId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// A navigation property to the related Student
        /// </summary>
        public Student Student { get; set; }

    }
}
