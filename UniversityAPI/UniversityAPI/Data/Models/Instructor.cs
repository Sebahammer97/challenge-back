using System;
using System.Collections.Generic;

namespace UniversityAPI.Data.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? SoftDeleted { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
