using EXOLiveDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXOLiveDataService.Repositories
{
    public interface IRRDataRepository
    {
        Task<IEnumerable<RRData>> Get();
        Task<RRData> Get(int id);
        Task<IEnumerable<RRData>> GetSpecificUser(int? Id);
        Task<RRData> Create(RRData rrdata);
        Task Update(RRData rrdata);
        Task Delete(int id);
    }
}
