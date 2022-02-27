using System;

namespace UniversityAPI.Services.Requests.Student
{
    public class CreateInstructorRequest: BaseRequest
    {
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
