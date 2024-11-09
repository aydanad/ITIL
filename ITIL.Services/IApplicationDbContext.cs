using ITIL.Domin.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITIL.Services
{

    public interface IApplicationDbContext
    {
        DbSet<City> CityList { get; set; }
        DbSet<Department> DepartmentList { get; set; }
        DbSet<Person> PersonList { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
