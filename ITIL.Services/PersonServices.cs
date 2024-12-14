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
	public class PersonServices:IPersonServices
	{
		IApplicationDbContext db;
		public PersonServices(IApplicationDbContext dbContext) 
		{
			db = dbContext;
		}
		private IQueryable<PersonDto> getListQuery()
		{
			return from person in db.PersonList
				   select new PersonDto
				   {
					   Id = person.Id,
					   UserId = person.UserId,
					   FirstName = person.FirstName,
					   LastName = person.LastName,
					   NationalCode = person.NationalCode,
					   PersonDepartmentCount = person.PersonDepartmentList.Count()
				   };
		}
		public async Task<IList<PersonDto>> GetAllAsync()
		{
			var query = getListQuery();
			return await query.ToListAsync();
		}
        public async Task<PersonDto?> GetAsync(Guid id)
		{
			var query = getListQuery().Where(t => t.Id == id);
			return await query.FirstOrDefaultAsync();
		}
		public async Task<Guid?> InsertAsync(CreatePersonDto createPersonDto,CancellationToken cancellationToken)
		{
			var newEntity = new Person();
			 
			newEntity.FirstName=createPersonDto.FirstName;
			newEntity.LastName=createPersonDto.LastName;
			newEntity.NationalCode=createPersonDto.NationalCode;
			var result = db.PersonList.Add(newEntity);
			if (cancellationToken.IsCancellationRequested)
				return null;
			await db.SaveChangesAsync(cancellationToken);
			return result.Entity.Id;
		}
		public async Task<bool> UpdateAsync(UpdatePersonDto updatePersonDto,CancellationToken cancellationToken)
		{
			var ediEntity=db.PersonList.Where(t=>t.Id==updatePersonDto.Id).FirstOrDefault();
			if (ediEntity != null)
			{
				 
				ediEntity.FirstName=updatePersonDto.FirstName;
				ediEntity.LastName=updatePersonDto.LastName;
				ediEntity.NationalCode = updatePersonDto.NationalCode;
				if (cancellationToken.IsCancellationRequested)
					return false;
				await db.SaveChangesAsync(cancellationToken);
				return true;
			}
			return false;
		}
		public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken)
		{
			var ediEntity = db.PersonList.Where(t => t.Id == id).FirstOrDefault();
			if (ediEntity != null)
			{
				db.PersonList.Remove(ediEntity);
				if (cancellationToken.IsCancellationRequested)
					return false;
				await db.SaveChangesAsync(cancellationToken);
				return true;
			}
			return false;
		}
        public async Task<bool> ExistsAsync(string nationalCode)
        {
            return await db.PersonList.Where(c => c.NationalCode == nationalCode).AnyAsync();
        }
    }
}
