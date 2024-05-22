using CleanArchitecture.Core.Interfaces.Repositories;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Guests.Commands.CreateGuest
{
    public class CreateGuestCommandValidator : AbstractValidator<CreateGuestCommand>
    {
        private readonly IGuestRepositoryAsync GuestRepository;

        public CreateGuestCommandValidator(IGuestRepositoryAsync GuestRepository)
        {
            this.GuestRepository = GuestRepository;

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueEmail).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }

        private async Task<bool> IsUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return await GuestRepository.IsUniqueEmailAsync(email);
        }
    }
}
