using CoreCourse.EFBasics.Web.Data;
using CoreCourse.EFBasics.Web.Entities;
using CoreCourse.EFBasics.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.EFBasics.Web.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext schoolContext;

        public HomeController(SchoolContext context)
        {
            schoolContext = context;
        }


        public async Task<IActionResult> Index()
        {
            IndexVm vm = new IndexVm(); //will be passed to Index View

            //1. get teacher with Id == 1 
            vm.TeacherWidthIdOne = await schoolContext.Teachers.FindAsync(5L);

            //2. get students born before 2000, ordered by Name
            vm.StudentsBornBefore2k = await schoolContext.Students
                .Where(s => s.Birthdate.Year < 2000)
                .OrderBy(s => s.Name)
                .ToListAsync();

            //3. get total amount of scholarships
            vm.TotalScholarships = await schoolContext.Students
                .SumAsync(s => s.Scholarship) ?? 0; //return 0 if null

            //4. get scholarship student with studentinfo loaded
            //   order by scholarship, then by name
            vm.ScholarshipStudentsWithInfo = await schoolContext.Students
                .Include(s => s.ContactInfo)
                .Where(s => s.Scholarship != null)
                .OrderBy(s => s.Scholarship)
                .ThenBy(s => s.Name)
                .ToListAsync();

            //5. get a full graph of all courses
            //   order by the amount of student in course, descending
            var allStudentCourses = await schoolContext.Set<StudentCourse>() //start in the join table
                .Include(sc => sc.Course)
                .ThenInclude(c => c.Lecturer)
                .Include(sc => sc.Student)
                .ThenInclude(s => s.ContactInfo)
                .ToListAsync();

            //operations beyond this point happen in memory, not in database 
            vm.Courses = allStudentCourses
                .Select(sc => sc.Course)                    //select by Course, once results are in
                .Distinct()                                 //select each course only once
                .OrderByDescending(sc => sc.StudentCourses.Count);    //order by number of StudentCourses

            return View(vm);
        }
    }
}