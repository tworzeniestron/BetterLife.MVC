using AutoMapper;
using BetterLife.Application.ApplicationUser;
using BetterLife.Domain.Interfaces;
using MediatR;

namespace BetterLife.Application.Conference.Commands.Queries.GetConferenceByEncodedType
{
    public class GetConferenceByEncodedTypeHandler : IRequestHandler<GetConferenceByEncodedType, ConferenceDTO>
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IMapper _mapper;

        public GetConferenceByEncodedTypeHandler(IConferenceRepository conferenceRepository, IMapper mapper)
        {
            _conferenceRepository = conferenceRepository;
            _mapper = mapper;
        }
        public async Task<ConferenceDTO> Handle(GetConferenceByEncodedType request, CancellationToken cancellationToken)
        {
            var conference = await _conferenceRepository.GetByEncodedType(request.EncodedType);
            var dto = _mapper.Map<ConferenceDTO>(conference);

            return dto;
        }
    }
}
