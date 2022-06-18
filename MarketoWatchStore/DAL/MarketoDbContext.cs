using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.DAL
{
    public class MarketoDbContext : DbContext
    {
        public MarketoDbContext(DbContextOptions<MarketoDbContext> options) : base(options) { }
    }
}
