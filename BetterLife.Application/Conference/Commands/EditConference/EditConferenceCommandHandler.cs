using BetterLife.Application.ApplicationUser;
using BetterLife.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterLife.Application.Conference.Commands.EditConference
{
    public class EditConferenceCommandHandler : IRequestHandler<EditConferenceCommand>
    {
        private readonly IConferenceRepository _repository;
        private readonly IUserContext _userContext;

        public EditConferenceCommandHandler(IConferenceRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditConferenceCommand request, CancellationToken cancellationToken)
        {
            var conference = await _repository.GetByEncodedType(request.EncodedType!);

            var user = _userContext.GetCurrentUser();
            var isEditable = conference.CreatedById == user.Id || user.IsInRole("Admin");

            if (!isEditable)
            {
                return Unit.Value;
            }
    
            conference.DateOfMeetings = request.DateOfMeetings;
            conference.TicketPrice = (double)request.TicketPrice;
            conference.Description = request.Description;
            conference.Addresses.Country = request.Country;
            conference.Addresses.City = request.City;
            conference.Addresses.Street = request.Street;
            conference.Addresses.PostalCode = request.PostalCode;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
