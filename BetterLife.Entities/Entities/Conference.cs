using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BetterLife.Domain.Entities
{
    public class Conference
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DateOfMeetings { get; set; } = default!;
        public double TicketPrice { get; set; }
        public string? Description { get; set; }
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
        public ConferenceAddress Addresses { get; set; } = default!;

        public string EncodedType { get; private set; } = default!;
        public void EncodeType() => EncodedType = Type.ToLower().Replace("-", " ");
    //    public List<Participant>? Participants { get; set; }
    }
}
