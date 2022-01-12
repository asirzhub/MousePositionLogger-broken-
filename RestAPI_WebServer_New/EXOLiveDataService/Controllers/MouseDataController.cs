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
    public class MouseDataController : ControllerBase
    {
        private readonly IMouseDataRepository _mouseDataRepository;

        public MouseDataController(IMouseDataRepository mouseDataRepository)
        {
            this._mouseDataRepository = mouseDataRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<MouseData>> GetMouseData()
        {
            return await _mouseDataRepository.Get();
        }

        [HttpGet("MouseDataId={id}")]
        public async Task<ActionResult<MouseData>> GetMouseData(int id)
        {
            
            return await _mouseDataRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<MouseData>> PostUserData([FromBody] MouseData mousePos)
        {
            var newMouseData = await _mouseDataRepository.Create(mousePos);
            return CreatedAtAction(nameof(GetMouseData), new { id = newMouseData.MouseDataId }, newMouseData);
        }        

        [HttpPut]
        public async Task<ActionResult<MouseData>> UpdateUserData(int id, [FromBody] MouseData mousePos)
        {
            if (id != mousePos.MouseDataId)
            {
                return BadRequest();
            }

            await _mouseDataRepository.Update(mousePos);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<MouseData>> DeleteUserData(int id)
        {
            var mousedataDelete = await _mouseDataRepository.Get(id);
            if (mousedataDelete == null)
            {
                return NotFound();
            }

            await _mouseDataRepository.Delete(mousedataDelete.MouseDataId);
            return NoContent();
        }
    }
}
