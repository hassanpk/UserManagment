using System.Runtime.InteropServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagment.API.Application.Commands.CreateUser;
using UserManagment.API.Application.Commands.DeleteUser;
using UserManagment.API.Application.Commands.UpdateUser;
using UserManagment.API.Application.Queries.GetAllUsers;
using UserManagment.API.Application.Queries.GetUserById;
using UserManagment.API.Domain.Entities;

using UserManagment.API.Presentation.ViewModels;

namespace UserManagment.API.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetailsViewModel>>> GetAll()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetails>> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { Id = id });
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] UserDetailsCreateViewModel userInfo, IFormFile passportFile, IFormFile personPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (passportFile == null || passportFile.Length == 0)
            {
                return BadRequest("PassPort File is required");
            }

            if (personPhoto == null || personPhoto.Length == 0)
            {
                return BadRequest("User Photo File is required");
            }

            var command = new CreateUserCommand
            {
                UserInfo = userInfo,
                PassportFile = passportFile,
                PersonPhoto = personPhoto
            };

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = userInfo.LocationId }, userInfo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromForm] UserDetailsCreateViewModel userInfo, [Optional] IFormFile passportFile, [Optional] IFormFile personPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (passportFile == null || passportFile.Length == 0)
            {
                return BadRequest("PassPort File is required");
            }

            if (personPhoto == null || personPhoto.Length == 0)
            {
                return BadRequest("User Photo File is required");
            }
            try
            {

                var command = new UpdateUserCommand
                {
                    Id = id,
                    UserInfo = userInfo,
                    PassportFile = passportFile,
                    PersonPhoto = personPhoto
                };

                await _mediator.Send(command);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteUserCommand { Id = id };
                await _mediator.Send(command);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}