using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Woolies.Exercise.Application.Features.User
{
    


    public class UserData
    {
        public string Name { get; set; }
        public string Token { get; set; }

    }

    public class GetUserQuery : IRequest<UserData>
    {
        public string test = "";
    }
}
