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
    public class RRDataController : ControllerBase
    {
        private readonly IRRDataRepository _rrdataRepository;

        public RRDataController(IRRDataRepository rrdataRepository)
        {
            this._rrdataRepository = rrdataRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<RRData>> GetRRData()
        {
            return await _rrdataRepository.Get();
        }

        [HttpGet("RRDataId={id}")]
        public async Task<ActionResult<RRData>> GetRRData(int id)
        {
            return await _rrdataRepository.Get(id);
        }

        [HttpGet("UserId={id}")]
        public async Task<IEnumerable<RRData>> GetRRDataUser(int id)
        {
            var result = await _rrdataRepository.GetSpecificUser(id);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<RRData>> PostRRData([FromBody] RRData rrdata)
        {
            var newRrData = await _rrdataRepository.Create(rrdata);
            return CreatedAtAction(nameof(GetRRData), new { id = newRrData.RRDataId }, newRrData);
        }

        [HttpPut]
        public async Task<ActionResult<RRData>> UpdateRRData(int id, [FromBody] RRData rrdata)
        {
            if (id != rrdata.RRDataId)
            {
                return BadRequest();
            }

            await _rrdataRepository.Update(rrdata);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<RRData>> DeleteRRData(int id)
        {
            var rrdataDelete = await _rrdataRepository.Get(id);
            if (rrdataDelete == null)
            {
                return NotFound();
            }

            await _rrdataRepository.Delete(rrdataDelete.RRDataId);
            return NoContent();
        }
    }
}
