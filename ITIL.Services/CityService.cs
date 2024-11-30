using ITIL.Domin.Entities;
using ITIL.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Services
{
    public class CityService : ICityService
    {
        IApplicationDbContext db;
        public CityService(IApplicationDbContext dbContext)
        {

            db = dbContext;
        }
        private IQueryable<CityDto> getListQuery()
        {
            return from city in db.CityList
                   select new CityDto
                   {
                       Id = city.Id,
                       Title = city.Title,
                       DepartmentCount = city.DepartmentList.Count
                   };
        }
        public async Task<IList<CityDto>> GetAllAsync()
        {
            var query = getListQuery();
            return await query.ToListAsync();
        }
        public async Task<CityDto?> GetAsync(Guid id)
        {
            var query = getListQuery().Where(t => t.Id == id);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Guid?> InsertAsync(CreateCityDto createCityDto, CancellationToken cancellationToken)
        {
            bool isDuplicate = db.CityList.Any(t => t.Title == createCityDto.Title);
            if (isDuplicate)
                throw new Exception("City Is Duplicate");
            var newEntity = new City();
            newEntity.Title = createCityDto.Title;
            var result = db.CityList.Add(newEntity);
            if (cancellationToken.IsCancellationRequested)
                return null;
            await db.SaveChangesAsync(cancellationToken);
            return result.Entity.Id;



        }
        public async Task<bool> UpdateAsync(UpdateCityDto updateCityDto, CancellationToken cancellationToken)
        {
            bool isDuplicate = db.CityList.Any(t => t.Title == updateCityDto.Title && t.Id != updateCityDto.Id);

            if (isDuplicate)
                throw new Exception("City Is Duplicate");
            var ediEntity = db.CityList.Where(t => t.Id == updateCityDto.Id).FirstOrDefault();
            if (ediEntity != null)
            {
                ediEntity.Title = updateCityDto.Title;
                if (cancellationToken.IsCancellationRequested)
                    return false;
                await db.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;


        }
        public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            var ediEntity = db.CityList.Where(t => t.Id == id).FirstOrDefault();
            if (ediEntity != null)
            {
                db.CityList.Remove(ediEntity);
                if (cancellationToken.IsCancellationRequested)
                    return false;
                await db.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        public async Task<bool> ExistsAsync(string cityTitle)
        {
            return await db.CityList.Where(c => c.Title== cityTitle).AnyAsync();
        }
    }
}
