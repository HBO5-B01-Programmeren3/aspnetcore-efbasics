using CoreCourse.EFBasics.Web.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace CoreCourse.EFBasics.Web.Data
{
    public class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // create teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Name = "Mr. Ned Farious", YearlyWage = 27150 },
                new Teacher { Id = 2, Name = "Mrs. Alley Hope", YearlyWage = 31520 }
            );

            // create students
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Marty Pants",
                    Scholarship = null,
                    Birthdate = DateTime.ParseExact("10/05/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                },
                new Student
                {
                    Id = 2,
                    Name = "Chris Mahs",
                    Scholarship = 1200,
                    Birthdate = DateTime.ParseExact("25/12/1998", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                },
                new Student
                {
                    Id = 3,
                    Name = "Ann A. Fabettick",
                    Scholarship = 600,
                    Birthdate = DateTime.ParseExact("15/08/1997", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                },
                new Student
                {
                    Id = 4,
                    Name = "Will Szeedt",
                    Scholarship = null,
                    Birthdate = DateTime.ParseExact("26/02/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                }
            );

            // create studentinfo and link to their student record using Foreign Key property StudendId
            modelBuilder.Entity<StudentInfo>().HasData(
                new StudentInfo
                {
                    Id = 100,
                    StudentId = 1,  // Marty Pants
                    Email = "martypants@school.example",
                    Phone = null,
                },
                new StudentInfo
                {
                    Id = 101,
                    StudentId = 2,  // Chris Mahs
                    Email = "chrismahs@school.example",
                    Phone = "111 11 11 11",
                },
                new StudentInfo
                {
                    Id = 102,
                    StudentId = 3,  // Ann A. Fabettick
                    Email = "annaf@school.example",
                    Phone = "222 22 22 22",
                },
                new StudentInfo
                {
                    Id = 103,
                    StudentId = 4,  // Will Szeedt
                    Email = "willszeedt@school.example",
                    Phone = null,
                }
            );

            // create courses, and link to a teacher by using anonymous types that have a LecturerId
            modelBuilder.Entity<Course>().HasData(
                new
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Programming C#",
                    LecturerId = (long?)1   // 1 = Mr. Ned Farious
                },
                new
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Elementary Database Design",
                    LecturerId = (long?)2  // 2 = Mrs. Alley Hope
                },
                new
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "ASP.NET Core",
                    LecturerId = (long?)1  // 1 = Mr. Ned Farious
                }
            );

            //link students to courses
            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse {
                    StudentId = 1,              // Marty -> Programming C#
                    CourseId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                },
                new StudentCourse {
                    StudentId = 1,              // Marty -> ASP.NET Core
                    CourseId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                },
                new StudentCourse {
                    StudentId = 2,              // Chris -> Programming C#
                    CourseId = Guid.Parse("11111111-1111-1111-1111-111111111111"), 
                },
                new StudentCourse {
                    StudentId = 2,              // Chris -> Elementary Database Design
                    CourseId = Guid.Parse("22222222-2222-2222-2222-222222222222"), 
                },
                new StudentCourse {
                    StudentId = 2,              // Chris -> ASP.NET Core
                    CourseId = Guid.Parse("33333333-3333-3333-3333-333333333333"), 
                },
                new StudentCourse {
                    StudentId = 4,              // Will -> Elementary Database Design
                    CourseId = Guid.Parse("22222222-2222-2222-2222-222222222222"), 
                },
                new StudentCourse {
                    StudentId = 4,              // Will -> ASP.NET Core
                    CourseId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                }
            );
        }
    }
}
