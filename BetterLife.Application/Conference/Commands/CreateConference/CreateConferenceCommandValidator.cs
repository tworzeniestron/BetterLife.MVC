using BetterLife.Domain.Interfaces;
using FluentValidation;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterLife.Application.Conference.Commands.CreateConference
{
    public class CreateConferenceCommandValidator : AbstractValidator<CreateConferenceCommand>
    {
        public CreateConferenceCommandValidator(IConferenceRepository repository)
        {
            RuleFor(c => c.Type).NotEmpty().WithMessage("Please enter type of conference");

            RuleFor(c => c.DateOfMeetings).NotEmpty().WithMessage("Please enter date");

            RuleFor(c => c.Country).NotEmpty();

            RuleFor(c => c.City).NotEmpty();

            RuleFor(c => c.Street).NotEmpty();

            RuleFor(c => c.PostalCode)
                .MinimumLength(5).WithMessage("PostalCode should have atleast 5 characters")
                .MaximumLength(7).WithMessage("PostalCode should have maximum of 7 characters");

            RuleFor(c => c.EncodedType).NotEmpty()
                .WithMessage("Please enter encoded type")
                .Custom((encodedValue, context) =>
                {
                    var existingConference = repository.GetByEncodedType(encodedValue).Result;//od wiersza 20-24 sprawdzenie unikalności
                    if (existingConference != null)
                    {
                        context.AddFailure($"{encodedValue} is not unique type for conference");
                    }
                });
        }

    }
}
