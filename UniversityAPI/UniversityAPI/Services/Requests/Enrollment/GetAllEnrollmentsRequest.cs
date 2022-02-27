namespace UniversityAPI.Services.Requests.Enrollment
{
    public class GetAllEnrollmentsRequest: BaseRequest
    {
        public int? Id { get; set; }
        public int? CourseId { get; set; }
        public int? StudentId { get; set; }
    }
}
