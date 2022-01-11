using EXOLiveDataService.Models;
using EXOLiveDataService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXOLiveDataService.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Users>> GetUserData()
        {
            return await _userRepository.Get();
        }

        [HttpGet("UserId={id}")]
        public async Task<ActionResult<Users>> GetUserData(int id)
        {
            
            return await _userRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Users>> PostUserData([FromBody] Users users)
        {
            var newUserData = await _userRepository.Create(users);
            return CreatedAtAction(nameof(GetUserData), new { id = newUserData.UserId }, newUserData);
        }        

        [HttpPut]
        public async Task<ActionResult<Users>> UpdateUserData(int id, [FromBody] Users users)
        {
            if (id != users.UserId)
            {
                return BadRequest();
            }

            await _userRepository.Update(users);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Users>> DeleteUserData(int id)
        {
            var userdataDelete = await _userRepository.Get(id);
            if (userdataDelete == null)
            {
                return NotFound();
            }

            await _userRepository.Delete(userdataDelete.UserId);
            return NoContent();
        }
    }
}
