using System;
using System.Threading.Tasks;
using AccesaStart.DAL;
using AccesaStart.DAL.Repositories;
using AccesaStart.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AccesaStart.WebApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepository<User> _userRepository = new UserRepository();

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]UserViewModel userViewModel)
        {
            try
            {
                var user = await _userRepository.Read(userViewModel.PhoneNumber);

                if (user != null)
                {
                    return BadRequest("A user with this phone number already exists");
                }

                if (!userViewModel.Password.Equals(userViewModel.ConfirmPassword, StringComparison.InvariantCulture))
                {
                    return BadRequest("The passwords do not match.");
                }

                user = new User
                {
                    PhoneNumber = userViewModel.PhoneNumber,
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    Password = userViewModel.Password
                };

                await _userRepository.Create(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserViewModel userViewModel)
        {
            try
            {
                var user = await _userRepository.Read(userViewModel.PhoneNumber);

                if (user == null)
                {
                    return BadRequest("The user does not exist.");
                }

                if (!user.Password.Equals(userViewModel.Password, StringComparison.InvariantCulture))
                {
                    return BadRequest("The password is not correct.");
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
