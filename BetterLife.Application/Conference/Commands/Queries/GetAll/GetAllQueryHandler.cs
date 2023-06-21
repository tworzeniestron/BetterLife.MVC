using AutoMapper;
using BetterLife.Domain.Interfaces;
using MediatR;

namespace BetterLife.Application.Conference.Commands.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<ConferenceDTO>>
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IConferenceRepository conferenceRepository, IMapper mapper)
        {
            _conferenceRepository = conferenceRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ConferenceDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var Conferences = await _conferenceRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ConferenceDTO>>(Conferences);

            return dtos;
        }
    }
}
