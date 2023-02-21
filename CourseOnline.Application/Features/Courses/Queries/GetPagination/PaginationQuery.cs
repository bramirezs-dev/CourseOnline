using CourseOnline.Application.DTOs.Dapper;
using MediatR;

namespace CourseOnline.Application.Features.Courses.Queries.GetPagination
{
    public class PaginationQuery : IRequest<PaginationModel>
    {
        public string? Title { get; set; }

        public int NumberPage { get; set; }

        public int CountElement { get; set; }

    }
}