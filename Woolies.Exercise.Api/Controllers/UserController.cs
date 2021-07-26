using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Woolies.Exercise.Application.Common;
using Woolies.Exercise.Application.Features.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Woolies.Exercise.Api.Controllers
{
    [Route("api/WooliesExercise/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

       
        [HttpGet]
        public async Task<ActionResult<UserData>> GetUser()
        {
            var user = await _mediator.Send(new GetUserQuery());
            return Ok(user);
        }

    }
}