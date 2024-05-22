using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Guests.Commands.DeleteGuestById
{
    public class DeleteGuestByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteGuestByIdCommandHandler : IRequestHandler<DeleteGuestByIdCommand, Response<int>>
        {
            private readonly IGuestRepositoryAsync _GuestRepository;
            public DeleteGuestByIdCommandHandler(IGuestRepositoryAsync GuestRepository)
            {
                _GuestRepository = GuestRepository;
            }
            public async Task<Response<int>> Handle(DeleteGuestByIdCommand command, CancellationToken cancellationToken)
            {
                var Guest = await _GuestRepository.GetByIdAsync(command.Id);
                if (Guest == null) throw new ApiException($"Guest Not Found.");
                await _GuestRepository.DeleteAsync(Guest);
                return new Response<int>(Guest.Id);
            }
        }
    }
}
