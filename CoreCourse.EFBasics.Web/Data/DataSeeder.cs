using CoreCourse.EFBasics.Web.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CoreCourse.EFBasics.Web.Data
{
    public class DataSeeder
    {
        public static void Seed(SchoolContext context)
        {
            List<Course> allCourses = context.Courses.ToList(); //get all current Courses in DB

            //seed Courses
            if (!context.Courses.Any())
            {
                Course[] courses = new[]{
                    new Course{ Name = "Programming C#" },
                    new Course{ Name = "Elementary Database Design" },
                    new Course{ Name = "ASP.NET Core" },
                };
                context.Courses.AddRange(courses);

                allCourses = courses.ToList(); //to use when assigning students and teachers
            }

            //seed Teachers
            if (!context.Teachers.Any())
            {
                Teacher[] teachers = new[]{
                    new Teacher{ Name = "Mr. Ned Farious", YearlyWage = 27150 },
                    new Teacher{ Name = "Mrs. Alley Hope", YearlyWage = 31520 },
                };

                //add teachers to Courses
                teachers[0].Courses = new[]
                {
                    allCourses[0], //Mr. Ned Farious teaches Programming C#
                    allCourses[2], //Mr. Ned Farious teaches ASP.NET Core
                };
                teachers[1].Courses = new[]
                {
                    allCourses[1], //Mrs. Alley Hope teaches Elementary Database Design
                };

                context.Teachers.AddRange(teachers);
            }

            //seed Students and StudentInfo
            if (!context.Students.Any())
            {
                //create student and student entities
                Student[] students = new[]{
                    new Student{ Name = "Marty Pants",
                                    Birthdate = DateTime.ParseExact("10/05/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                    Scholarship = null,
                                    ContactInfo = new StudentInfo { Email = "martypants@school.example", Phone = null }
                    },
                    new Student{ Name = "Chris Mahs",
                                    Birthdate = DateTime.ParseExact("25/12/1998", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                    Scholarship = 1200,
                                    ContactInfo = new StudentInfo { Email = "nedfarious@school.example", Phone = "111 11 11 11" }
                    },
                    new Student{ Name = "Ann A. Fabettick",
                                    Birthdate = DateTime.ParseExact("15/08/1997", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                    Scholarship = 600,
                                    ContactInfo = new StudentInfo { Email = "annafabettick@school.example", Phone = "222 22 22 22" }
                    },
                    new Student{ Name = "Will Szeedt",
                                    Birthdate = DateTime.ParseExact("26/02/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                    Scholarship = null,
                                    ContactInfo = new StudentInfo { Email = "willszeedt@school.example", Phone = null }
                    },
                };

                //add students to courses
                students[0].StudentCourses = new[]
                {
                    new StudentCourse{ Student = students[0], Course = allCourses[0] }, //Marty -> Programming C#
                    new StudentCourse{ Student = students[0], Course = allCourses[2] }  //Marty -> ASP.NET Core
                };
                students[1].StudentCourses = new[]
                {
                    new StudentCourse{ Student = students[1], Course = allCourses[0] }, //Chris follows all courses
                    new StudentCourse{ Student = students[1], Course = allCourses[1] },
                    new StudentCourse{ Student = students[1], Course = allCourses[2] }
                };
                students[2].StudentCourses = null; //Ann doesn't follow any courses at all

                students[3].StudentCourses = new[]
                {
                    new StudentCourse{ Student = students[3], Course = allCourses[1] }, //Will -> Database Design
                    new StudentCourse{ Student = students[3], Course = allCourses[2] }, //Will -> ASP.NET Core
                };

                context.Students.AddRange(students);
            }

            context.SaveChanges();
        }
    }
}
