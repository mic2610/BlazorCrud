using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Api.Queries.GetComics
{
    public class GetComicsQuery : IRequest<ComicsDto>
    {
    }

    public class GetComicsQueryHandler : IRequestHandler<GetComicsQuery, ComicsDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetComicsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ComicsDto> Handle(GetComicsQuery request, CancellationToken cancellationToken)
        {
            return new ComicsDto { Comics = await _applicationDbContext.Comics.ToListAsync(cancellationToken) };
        }
    }
}