using EXOLiveDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXOLiveDataService.Repositories
{
    public interface IHRDataRepository
    {
        Task<IEnumerable<HRData>> Get();
        Task<HRData> Get(int Id);
        Task<IEnumerable<HRData>> GetSpecificUser(int? Id);
        Task<HRData> Create(HRData hrdata);
        Task Update(HRData hrdata);
        Task Delete(int Id);
    }
}
