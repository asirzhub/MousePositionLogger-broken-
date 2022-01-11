using EXOLiveDataService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXOLiveDataService.Repositories
{
    /***
    public class RRDataRepository : IRRDataRepository
    {
        private readonly ExoLiveDataContext _context;
        public RRDataRepository(ExoLiveDataContext context)
        {
            this._context = context;
        }
        public async Task<RRData> Create(RRData rrdata)
        {
            _context.RRData.Add(rrdata);
            await _context.SaveChangesAsync();

            return rrdata;
        }

        public async Task Delete(int id)
        {
            var rrdataDelete = await _context.RRData.FindAsync(id);
            _context.RRData.Remove(rrdataDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RRData>> Get()
        {
            return await _context.RRData.ToListAsync();
        }

        public async Task<RRData> Get(int id)
        {
            return await _context.RRData.FindAsync(id);
        }

        public async Task<IEnumerable<RRData>> GetSpecificUser(int? id)
        {
            return await _context.RRData.OrderBy(a => a.UserId).Where(b => b.UserId == id).ToListAsync();
        }
        public async Task Update(RRData rrdata)
        {
            _context.Entry(rrdata).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
    */
}
