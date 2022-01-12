using EXOLiveDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXOLiveDataService.Repositories
{
    public interface IMouseDataRepository
    {
        Task<IEnumerable<MouseData>> Get();
        Task<MouseData> Get(int id);
        Task<MouseData> Create(MouseData mousePos);
        Task Update(MouseData mousePos);
        Task Delete(int id);
    }
}
