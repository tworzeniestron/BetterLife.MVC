using AutoMapper;
using BetterLife.Application.ApplicationUser;
using BetterLife.Domain.Interfaces;
using MediatR;

namespace BetterLife.Application.Conference.Commands.CreateConference
{
    public class CreateConferenceCommandHandler : IRequestHandler<CreateConferenceCommand>
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateConferenceCommandHandler(IConferenceRepository conferenceRepository, IMapper mapper, IUserContext userContext)
        {
            _conferenceRepository = conferenceRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateConferenceCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if(currentUser == null || !currentUser.IsInRole("Organizer"))
            {
                return Unit.Value;
            }
            var conference = _mapper.Map<Domain.Entities.Conference>(request);
            conference.EncodeType();

            conference.CreatedById = currentUser.Id;

            await _conferenceRepository.Create(conference);

            return Unit.Value;
        }
    }
}
