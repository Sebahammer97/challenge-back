namespace UniversityAPI.Services.Requests.Course
{
    public class UpdateCourseRequest : BaseRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Hours { get; set; }
        public int Credits { get; set; }
        public int InstructorId { get; set; }
    }
}
