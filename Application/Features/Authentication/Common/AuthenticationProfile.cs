using Application.Features.Authentication.Login;
using Application.Features.Authentication.Register;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Authentication.Common
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            
            CreateMap<(User, TokenResponse), AuthenticationResponse>()
                .ConstructUsing(src => new AuthenticationResponse(
                    src.Item1.Id,
                    src.Item1.Name,
                    src.Item1.Email,
                    src.Item1.PhoneNumber,
                    src.Item2.AccessToken,
                    src.Item2.RefreshToken));
                
        }
    }
}
