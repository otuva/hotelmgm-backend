using AutoMapper;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using CleanArchitecture.Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Guests.Commands.CreateGuest
{
    public partial class CreateGuestCommand : IRequest<Response<int>>
    {
        public char Gender { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }
        public string DateOfBirth { get; set; }
        public string AnniversaryDate { get; set; }
        public string IdName { get; set; }
        public string IdValue { get; set; }
        public string Nationality { get; set; }
    }
    public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand, Response<int>>
    {
        private readonly IGuestRepositoryAsync _GuestRepository;
        private readonly IMapper _mapper;
        public CreateGuestCommandHandler(IGuestRepositoryAsync GuestRepository, IMapper mapper)
        {
            _GuestRepository = GuestRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            var Guest = _mapper.Map<Guest>(request);
            await _GuestRepository.AddAsync(Guest);
            return new Response<int>(Guest.Id);
        }
    }
}
