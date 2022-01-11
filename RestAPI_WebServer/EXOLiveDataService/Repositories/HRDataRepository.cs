using EXOLiveDataService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXOLiveDataService.Repositories
{
    /**
    public class HRDataRepository : IHRDataRepository
    {
        private readonly ExoLiveDataContext _context;
        public HRDataRepository(ExoLiveDataContext context)
        {
            this._context = context;
        }
        public async Task<HRData> Create(HRData hrdata)
        {
            _context.HRData.Add(hrdata);
            await _context.SaveChangesAsync();

            return hrdata;
        }

        public async Task Delete(int id)
        {
            var hrdataDelete = await _context.HRData.FindAsync(id);
            _context.HRData.Remove(hrdataDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HRData>> Get()
        {
            return await _context.HRData.ToListAsync();
        }

        public async Task<HRData> Get(int id)
        {
            return await _context.HRData.FindAsync(id);
        }

        public async Task<IEnumerable<HRData>> GetSpecificUser(int? id)
        {
            return await _context.HRData.OrderBy(a => a.Timestamp).Where(b=>b.UserId == id).ToListAsync();
        }
        public async Task Update(HRData hrdata)
        {
            _context.Entry(hrdata).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
    */
}
