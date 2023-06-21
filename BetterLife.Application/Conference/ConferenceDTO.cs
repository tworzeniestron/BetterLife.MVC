using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BetterLife.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterLife.Application.Conference
{
    public class ConferenceDTO
    {
        public string Type { get; set; } = default!;
        public DateTime? DateOfMeetings { get; set; }
        public double TicketPrice { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? EncodedType { get; set; }
        public bool IsEditable { get; set; }

    }
}
