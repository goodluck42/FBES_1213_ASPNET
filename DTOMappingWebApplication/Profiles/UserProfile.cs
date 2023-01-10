using AutoMapper;

using DTOMappingWebApplication.DTO;
using DTOMappingWebApplication.Entities;

namespace DTOMappingWebApplication.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserAddDTO, User>()
            .ForMember(d => d.FirstName, options =>
            {
                options.MapFrom(dto => dto.Name);
            });
    }
}
