using System;
using System.Collections.Generic;
using UniversityAPI.Data.Models;

namespace UniversityAPI.Data.Models
{
    public partial class Enrollment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int? Grade { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? SoftDeleted { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
