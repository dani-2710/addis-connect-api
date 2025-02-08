using Application.Features.Users.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Authentication.Dtos
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<(UserDto, TokenDto), AuthenticationResponse>()
                .ConstructUsing(src => new AuthenticationResponse(
                    src.Item1,
                    src.Item2.AccessToken,
                    src.Item2.RefreshToken));

        }
    }
}
