using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXOLiveDataService.Models
{
    public class ExoLiveDataContext : DbContext
    {
        public ExoLiveDataContext(DbContextOptions<ExoLiveDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<MouseData> MouseData { get; set; }
        
    }
}
