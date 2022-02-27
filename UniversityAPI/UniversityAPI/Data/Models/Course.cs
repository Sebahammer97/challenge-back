using System;
using System.Collections.Generic;

namespace UniversityAPI.Data.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Hours { get; set; }
        public int? Credits { get; set; }
        public int InstructorId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? SoftDeleted { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
