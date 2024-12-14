using ITIL.Domin.Entities;
using ITIL.Infrastructure.Config;
using ITIL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Infrastructure
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser, IdentityRole,string>,IApplicationDbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<City> CityList { get; set; }
        public DbSet<Department> DepartmentList { get; set; }
        public DbSet<Person> PersonList { get; set; }
        public DbSet<PersonDepartment> PersonDepartmentList { get; set; }


    }
}
