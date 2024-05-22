using AutoMapper;
using CleanArchitecture.Core.Features.Products.Queries.GetAllProducts;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Guests.Queries.GetAllGuests
{
    public class GetAllGuestsQuery : IRequest<PagedResponse<IEnumerable<GetAllGuestsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllGuestsQueryHandler : IRequestHandler<GetAllGuestsQuery, PagedResponse<IEnumerable<GetAllGuestsViewModel>>>
    {
        private readonly IGuestRepositoryAsync _GuestRepository;
        private readonly IMapper _mapper;
        public GetAllGuestsQueryHandler(IGuestRepositoryAsync GuestRepository, IMapper mapper)
        {
            _GuestRepository = GuestRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllGuestsViewModel>>> Handle(GetAllGuestsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllGuestsParameter>(request);
            var Guest = await _GuestRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var GuestViewModel = _mapper.Map<IEnumerable<GetAllGuestsViewModel>>(Guest);
            return new PagedResponse<IEnumerable<GetAllGuestsViewModel>>(GuestViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
