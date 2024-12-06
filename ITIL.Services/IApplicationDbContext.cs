using ITIL.Domin.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITIL.Services
{

    public interface IApplicationDbContext
    {
        DbSet<City> CityList { get; set; }
        DbSet<Department> DepartmentList { get; set; }
        DbSet<Person> PersonList { get; set; }
        DbSet<PersonDepartment> PersonDepartmentList { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
