using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreCourse.EFBasics.Web.Entities
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public decimal? YearlyWage { get; set; }

        public ICollection<Course> Courses { get; set; }
    }

}
