using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using CleanArchitecture.Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Guests.Queries.GetGuestById
{
    public class GetGuestByIdQuery : IRequest<Response<Guest>>
    {
        public int Id { get; set; }
        public class GetGuestByIdQueryHandler : IRequestHandler<GetGuestByIdQuery, Response<Guest>>
        {
            private readonly IGuestRepositoryAsync _GuestRepository;
            public GetGuestByIdQueryHandler(IGuestRepositoryAsync GuestRepository)
            {
                _GuestRepository = GuestRepository;
            }
            public async Task<Response<Guest>> Handle(GetGuestByIdQuery query, CancellationToken cancellationToken)
            {
                var Guest = await _GuestRepository.GetByIdAsync(query.Id);
                if (Guest == null) throw new ApiException($"Guest Not Found.");
                return new Response<Guest>(Guest);
            }
        }
    }
}
