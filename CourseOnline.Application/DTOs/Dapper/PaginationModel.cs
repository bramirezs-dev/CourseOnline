namespace CourseOnline.Application.DTOs.Dapper
{
    public class PaginationModel
    {
        public List<IDictionary<string,object>> RecordsList { get; set; }
        public int TotalRecords { get; set; }
        public int NumberPages { get; set; }
    }
}