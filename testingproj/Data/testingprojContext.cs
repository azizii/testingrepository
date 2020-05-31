using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testingproj.Models;

namespace testingproj.Models
{
    public class testingprojContext : DbContext
    {
        public testingprojContext (DbContextOptions<testingprojContext> options)
            : base(options)
        {
        }

        public DbSet<testingproj.Models.check> check { get; set; }
        public DbSet<testingproj.Models.Food> foods { get; set; }
        public DbSet<testingproj.Models.aziz> aziz { get; set; }
        public DbSet<testingproj.Models.nori> nori { get; set; }
        public DbSet<testingproj.Models.myfoods> Myfoods { get; set; }
    }
}
