using EXOLiveDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXOLiveDataService.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> Get();
        Task<Users> Get(int id);
        Task<Users> Create(Users users);
        Task Update(Users users);
        Task Delete(int id);
    }
}