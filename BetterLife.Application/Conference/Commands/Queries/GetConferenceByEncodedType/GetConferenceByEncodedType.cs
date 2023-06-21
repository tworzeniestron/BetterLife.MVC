using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterLife.Application.Conference.Commands.Queries.GetConferenceByEncodedType
{
    public class GetConferenceByEncodedType : IRequest<ConferenceDTO>
    {
        public string EncodedType { get; set; }
        public GetConferenceByEncodedType(string encodedType)
        {
            EncodedType = encodedType;
        }
    }
}
