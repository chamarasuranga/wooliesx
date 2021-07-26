using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Woolies.Exercise.Application.Features.User
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserData>
    {
        public Task<UserData> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user= new UserData() { Name = "Chamara", Token = "11c0ecff-835f-4942-858d-d53b86c4236e" };
            return Task.FromResult(user);
        }
    }
}
