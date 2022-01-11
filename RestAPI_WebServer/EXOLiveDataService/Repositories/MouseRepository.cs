using EXOLiveDataService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXOLiveDataService.Repositories
{
    public class MouseRepository : IMouseRepository
    {
        private readonly ExoLiveDataContext _context;
        public MouseRepository(ExoLiveDataContext context)
        {
            this._context = context;
        }

        public async Task<MouseData> Create(MouseData mousePos)
        {
            _context.MouseData.Add(mousePos);
            await _context.SaveChangesAsync();

            return mousePos;
        }

        public async Task Delete(int id)
        {
            var userdataDelete = await _context.MouseData.FindAsync(id);
            _context.MouseData.Remove(userdataDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MouseData>> Get()
        {
            return await _context.MouseData.ToListAsync();
        }

        public async Task<MouseData> Get(int id)
        {
            return await _context.MouseData.FindAsync(id);
        }

        public async Task Update(MouseData mousePos)
        {
            _context.Entry(mousePos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}