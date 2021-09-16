using Microsoft.EntityFrameworkCore;
using NETCore.Models;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Context
{
    public class MyContext : DbContext // merupakan gateaway aplikasi dengan database
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) 
        { 
            
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
       // public DbSet<RegisterVM> RegisterVM { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Person>()
                .HasOne(a => a.Account).WithOne(b => b.Person)
                .HasForeignKey<Account>(e => e.NIK);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Profiling).WithOne(b => b.Account)
                .HasForeignKey<Profiling>(e => e.NIK);

            modelBuilder.Entity<Education>()
                .HasMany(a => a.Profilings).WithOne(b => b.Education);

            modelBuilder.Entity<University>()
                .HasMany(a => a.Educations).WithOne(b => b.University);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.AccountRoles).WithOne(r => r.Role);
            
            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountRoles).WithOne(a => a.Account);

            modelBuilder.Entity<AccountRole>().HasKey(ar => new { ar.AccountNIK, ar.RoleId });

            //modelBuilder.Entity<RegisterVM>().HasNoKey();
        }

        



    }
}
