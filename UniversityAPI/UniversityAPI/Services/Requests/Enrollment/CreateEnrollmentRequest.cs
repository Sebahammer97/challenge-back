namespace UniversityAPI.Services.Requests.Enrollment
{
    public class CreateEnrollmentRequest : BaseRequest
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }
}
