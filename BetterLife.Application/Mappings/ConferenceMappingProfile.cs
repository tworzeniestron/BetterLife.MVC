using AutoMapper;
using BetterLife.Application.ApplicationUser;
using BetterLife.Application.Conference;
using BetterLife.Application.Conference.Commands.EditConference;
using BetterLife.Domain.Entities;

namespace BetterLife.Application.Mappings
{
    public class ConferenceMappingProfile : Profile
    {
        public ConferenceMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<ConferenceDTO, Domain.Entities.Conference>()
                .ForMember(e => e.Addresses, opt => opt.MapFrom(src => new ConferenceAddress()
                {
                    Country = src.Country,
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode
                }));

            CreateMap<Domain.Entities.Conference, ConferenceDTO>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null &&
                                                    (src.CreatedById == user.Id || user.IsInRole("Admin"))))
                .ForMember(dto => dto.Country, opt => opt.MapFrom(src => src.Addresses.Country))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.Addresses.City))
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.Addresses.Street))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.Addresses.PostalCode));

            CreateMap<ConferenceDTO, EditConferenceCommand>();

            CreateMap<ConferenceDTO, Domain.Entities.Conference>();
        }
    }
}
