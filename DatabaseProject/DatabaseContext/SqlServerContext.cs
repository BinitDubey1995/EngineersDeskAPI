using DatabaseProject.Entity_Model;
using DatabaseProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.DatabaseContext
{
   /// <summary>
   /// save
   /// </summary>
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> DbContextOptions) : base(DbContextOptions)
        {
        }
        public DbSet<DEmployee> DEmployee { get; set; }

        public DbSet<Users> UsersTbls { get; set; }

        public DbSet<Subject> Subject { get; set; }

        public DbSet<DEmployeeAddress> DEmployeeAddress { get; set; }

        
        public DbSet<State> StateLookup { get; set; }

        public DbSet<City> all_cities {get; set; }

        public DbSet<DEmployeeFileDetails> DEmployeeFileDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DEmployee>().HasKey(e => e.EmployeeId);
            modelBuilder.Entity<Users>().HasKey(e => e.ID);
            modelBuilder.Entity<Subject>().HasKey(e => e.SubjectId);
            modelBuilder.Entity<DEmployeeAddress>().HasKey(e => e.Id);
            modelBuilder.Entity<State>().HasKey(e => e.StateID);
            modelBuilder.Entity<City>().HasKey(e => e.cityId);
            modelBuilder.Entity<DEmployeeFileDetails>().HasKey(e => e.ID);



            base.OnModelCreating(modelBuilder);
        }
    }
}
