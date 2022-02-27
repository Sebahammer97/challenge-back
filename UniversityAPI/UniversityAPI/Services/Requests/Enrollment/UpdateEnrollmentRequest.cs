namespace UniversityAPI.Services.Requests.Enrollment
{
    public class UpdateEnrollmentRequest : BaseRequest
    {
        public int Id { get; set; }
        public int Grade { get; set; }
    }
}
