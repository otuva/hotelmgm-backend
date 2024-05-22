using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Guests.Commands.UpdateGuest
{
    public class UpdateGuestCommand : IRequest<Response<int>>
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
        public int Id { get; set; }

        public class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand, Response<int>>
        {
            private readonly IGuestRepositoryAsync _GuestRepository;
            public UpdateGuestCommandHandler(IGuestRepositoryAsync GuestRepository)
            {
                _GuestRepository = GuestRepository;
            }
            public async Task<Response<int>> Handle(UpdateGuestCommand command, CancellationToken cancellationToken)
            {
                var Guest = await _GuestRepository.GetByIdAsync(command.Id);

                if (Guest == null) throw new EntityNotFoundException("Guest", command.Id);

                var isUniqueEmail = await _GuestRepository.IsUniqueEmailAsync(command.Email);

                if(!isUniqueEmail) throw new EmailIsNotUniqueException(command.Email);

                Guest.Gender = command.Gender;
                Guest.Title = command.Title;
                Guest.FirstName = command.FirstName;
                Guest.LastName = command.LastName;
                Guest.Email = command.Email;
                Guest.Phone = command.Phone;
                Guest.AddressId = command.AddressId;
                Guest.DateOfBirth = command.DateOfBirth;
                Guest.AnniversaryDate = command.AnniversaryDate;
                Guest.IdName = command.IdName;
                Guest.IdValue = command.IdValue;
                Guest.Nationality = command.Nationality;
                await _GuestRepository.UpdateAsync(Guest);
                return new Response<int>(Guest.Id);
            }
        }
    }
}
