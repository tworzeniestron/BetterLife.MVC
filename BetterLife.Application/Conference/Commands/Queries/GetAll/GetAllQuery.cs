using MediatR;

namespace BetterLife.Application.Conference.Commands.Queries.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<ConferenceDTO>>
    {

    }
}
