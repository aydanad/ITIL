using ITIL.Domin.Entities;
using ITIL.Services.Contract;
using ITIL.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Services
{
	public class DepartmentServices: IDepartmentServices
	{
		IApplicationDbContext db;
		public DepartmentServices(IApplicationDbContext dbContext)
		{
			db = dbContext;
		}
		private IQueryable<DepartmentDto> GetListQuery()
		{
			return from department in db.DepartmentList
				   join city in db.CityList on department.CityId equals city.Id
				   select new DepartmentDto
				   {
					   Id = department.Id,
					   Title = department.Title,
					   CityTitle = city.Title,
					   CityId = department.CityId,
					   DepartmentType = department.DepartmentType
				   };
		}
		public async Task<IList<DepartmentDto>> GetAllAsync()
		{
			var query = GetListQuery();
			return await query.ToListAsync();
		}
		public async Task<DepartmentDto?> GetAsync(Guid id)
		{
			var query = GetListQuery().Where(t => t.Id == id);
			return await query.FirstOrDefaultAsync();
		}

		public async Task<Guid?> InsertAsync(CreateDepartmentDto createDepartmentDto, CancellationToken cancellationToken)
		{
			var newEntity = new Department();
			newEntity.Title = createDepartmentDto.Title;
			newEntity.CityId = createDepartmentDto.CityId;
			newEntity.DepartmentType = createDepartmentDto.DepartmentType;
			var result = db.DepartmentList.Add(newEntity);
			if (cancellationToken.IsCancellationRequested)
				return null;
			await db.SaveChangesAsync(cancellationToken);
			return result.Entity.Id;
		}
		public async Task<bool> UpdateAsync(UpdateDepartmentDto updateDepartmentDto, CancellationToken cancellationToken)
		{
			var ediEntity = db.DepartmentList.Where(t => t.Id == updateDepartmentDto.Id).FirstOrDefault();
			if (ediEntity != null)
			{
				ediEntity.Title = updateDepartmentDto.Title;
                ediEntity.CityId = updateDepartmentDto.CityId;
                ediEntity.DepartmentType = updateDepartmentDto.DepartmentType;
                if (cancellationToken.IsCancellationRequested)
					return false;
				await db.SaveChangesAsync(cancellationToken);
				return true;
			}
			return false;
		}
		public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken)
		{
			var ediEntity = db.DepartmentList.Where(t => t.Id == id).FirstOrDefault();
			if (ediEntity != null)
			{
				db.DepartmentList.Remove(ediEntity);
				if (cancellationToken.IsCancellationRequested)
					return false;
				await db.SaveChangesAsync(cancellationToken);
				return true;
			}
			return false;
		}

        
    }
}
