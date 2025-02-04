using Application.Features.Authentication.Common;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Register
{
    public sealed record RegisterCommand(
        string Name,
        string Email,
        string Password,
        string PhoneNumber) : ICommand<AuthenticationResponse>;
}
