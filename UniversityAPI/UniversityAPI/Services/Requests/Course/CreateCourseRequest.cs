namespace UniversityAPI.Services.Requests.Course
{
    public class CreateCourseRequest : BaseRequest
    {
        public string Title { get; set; }
        public int Hours { get; set; }
        public int Credits { get; set; }
        public int InstructorId { get; set; }
    }
}
