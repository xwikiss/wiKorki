using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MaturaToBzdura.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }  

        public DbSet<HSClass> HSClass { get; set; }
        public DbSet<Chapter> Chapters{ get; set; }
        public DbSet<Models.Exercise> Exercises { get; set; }
        
    }
}
