using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterLife.Application.Conference.Commands.EditConference
{
    public class EditConferenceCommandValidator : AbstractValidator<EditConferenceCommand>
    {
        public EditConferenceCommandValidator()
        {
            RuleFor(c => c.DateOfMeetings).NotEmpty().WithMessage("Please enter date");

            RuleFor(c => c.Country).NotEmpty();

            RuleFor(c => c.City).NotEmpty();

            RuleFor(c => c.Street).NotEmpty();

            RuleFor(c => c.PostalCode)
                .MinimumLength(5).WithMessage("PostalCode should have atleast 5 characters")
                .MaximumLength(7).WithMessage("PostalCode should have maximum of 7 characters");
        }
    }
}
