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
    public class HRDataController : ControllerBase
    {
        private readonly IHRDataRepository _hrdataRepository;

        public HRDataController(IHRDataRepository hrdataRepository)
        {
            this._hrdataRepository = hrdataRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<HRData>> GetHRData()
        {
            return await _hrdataRepository.Get();
        }

        [HttpGet("HRDataId={id}")]
        public async Task<ActionResult<HRData>> GetHRData(int id)
        {
            return await _hrdataRepository.Get(id);
        }

        [HttpGet("UserId={id}")]
        public async Task<IEnumerable<HRData>> GetHRDataUser(int id)
        {
            var result = await _hrdataRepository.GetSpecificUser(id);
            return result;
        }
       
        [HttpPost]
        public async Task<ActionResult<HRData>> PostHRData([FromBody] HRData hrdata)
        {
            var newHrData = await _hrdataRepository.Create(hrdata);
            return CreatedAtAction(nameof(GetHRData), new { id = newHrData.HRDataId }, newHrData);
        }

        [HttpPut]
        public async Task<ActionResult<HRData>> UpdateHRData(int id, [FromBody] HRData hrdata)
        {
            if(id != hrdata.HRDataId)
            {
                return BadRequest();
            }

            await _hrdataRepository.Update(hrdata);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<HRData>> DeleteHRData(int id)
        {
            var hrdataDelete = await _hrdataRepository.Get(id);
            if(hrdataDelete == null)
            {
                return NotFound();
            }

            await _hrdataRepository.Delete(hrdataDelete.HRDataId);
            return NoContent();
        }
    }
}
