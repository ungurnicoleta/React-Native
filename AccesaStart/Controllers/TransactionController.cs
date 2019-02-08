using System;
using System.Threading.Tasks;
using AccesaStart.DAL;
using AccesaStart.DAL.Repositories;
using AccesaStart.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AccesaStart.WebApi.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IRepository<User> _userRepository = new UserRepository();

        [Route("{phoneNumber}")]
        public async Task<IActionResult> GetBalance(string phoneNumber)
        {
            try
            {
                var user = await _userRepository.Read(phoneNumber);

                return Ok(user.TotalBalance);
            }
            catch (Exception e)
            {
                //TODO: log exception
                return BadRequest("This user does not exist");
            }
        }

        [HttpPost]
        [Route("{phoneNumber}/topup")]
        public async Task<IActionResult> TopUp(string phoneNumber, double amount)
        {
            try
            {
                var user = await _userRepository.Read(phoneNumber);

                if (user == null)
                {
                    return BadRequest("This user does not exist");
                }

                user.TotalBalance += amount;
                await _userRepository.Update(user);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("{phoneNumber}/transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferViewModel transferViewModel)
        {
            try
            {
                var user = await _userRepository.Read(transferViewModel.PhoneNumber);

                if (user == null)
                {
                    return BadRequest("This user does not exist.");
                }

                var targetUser = await _userRepository.Read(transferViewModel.TargetPhoneNumber);
                if (targetUser == null)
                {
                    return BadRequest("The target user does not exist.");
                }

                user.TotalBalance -= transferViewModel.Amount;
                targetUser.TotalBalance += transferViewModel.Amount;

                await _userRepository.Update(user);
                await _userRepository.Update(targetUser);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
