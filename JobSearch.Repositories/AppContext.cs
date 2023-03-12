using JobSearch.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories
{
    public class AppContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<JobFeadback> JobFeadbacks { get; set; }

        public DbSet<FavoriteJob> FavoriteJobs { get; set; }

        public AppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JobSearch;Trusted_Connection=True;");
        }
    }
}
