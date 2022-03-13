using Domain.Entities;
using MediatR;

namespace Application.Api.Queries.GetComics
{
    public class GetComicsQuery : IRequest<ComicsDto>
    {
    }

    public class GetComicsQueryHandler : IRequestHandler<GetComicsQuery, ComicsDto>
    {
        public async Task<ComicsDto> Handle(GetComicsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return new ComicsDto { Comics = new List<Comic> { new Comic { Id = 1, Name = "DC" }, { new Comic { Id = 2, Name = "Marvel" } } } };
        }
    }
}