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
    public class PersonDepartmentServices : IPersonDepartmentServices
    {
        IApplicationDbContext db;
        public PersonDepartmentServices(IApplicationDbContext dbContext)
        {

            db = dbContext;
        }
        private IQueryable<PersonDepartmentDto> getListQuery(Guid id)
        {
            return from personDepartment in db.PersonDepartmentList
                   join person in db.PersonList on personDepartment.PersonId equals person.Id
                   join department in db.DepartmentList on personDepartment.DepartmentId equals department.Id
                   where personDepartment.PersonId==id
                   select new PersonDepartmentDto
                   {
                       Id = personDepartment.Id,
                       PersonId=personDepartment.PersonId,
                       DepartmentId=personDepartment.DepartmentId,
                       PersonFullName=person.FirstName+" "+person.LastName,
                       DepartmentTitle=department.Title,
                       IsBossOffice=personDepartment.IsBossOffice
                   };
        }
        private IQueryable<PersonDepartmentDto> getListQuery()
        {
            return from personDepartment in db.PersonDepartmentList
                   join person in db.PersonList on personDepartment.PersonId equals person.Id
                   join department in db.DepartmentList on personDepartment.DepartmentId equals department.Id
                   select new PersonDepartmentDto
                   {
                       Id = personDepartment.Id,
                       PersonId = personDepartment.PersonId,
                       DepartmentId = personDepartment.DepartmentId,
                       PersonFullName = person.FirstName + " " + person.LastName,
                       DepartmentTitle = department.Title,
                       IsBossOffice = personDepartment.IsBossOffice
                   };
        }
        public async Task<IList<PersonDepartmentDto>> GetAllAsync(Guid id)
        {
            var query = getListQuery(id);
            return await query.ToListAsync();
        }
        public async Task<PersonDepartmentDto?> GetAsync(Guid id)
        {
            var query = getListQuery().Where(t => t.Id == id);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Guid?> InsertAsync(CreatePersonDepartmentDto createPersonDepartmentDto, CancellationToken cancellationToken)
        {
            var newEntity = new PersonDepartment();

            newEntity.PersonId = createPersonDepartmentDto.PersonId;
            newEntity.DepartmentId = createPersonDepartmentDto.DepartmentId;
            newEntity.IsBossOffice=createPersonDepartmentDto.IsBossOffice;
            var result = db.PersonDepartmentList.Add(newEntity);
            if (cancellationToken.IsCancellationRequested)
                return null;
            await db.SaveChangesAsync(cancellationToken);
            return result.Entity.Id;



        }

        public async Task<bool> UpdateAsync(UpdatePersonDepartmentDto updatePersonDepartmentDto, CancellationToken cancellationToken)
        {
            var ediEntity = db.PersonDepartmentList.Where(t => t.Id == updatePersonDepartmentDto.Id).FirstOrDefault();
            if (ediEntity != null)
            {
                ediEntity.PersonId = updatePersonDepartmentDto.PersonId;
                ediEntity.DepartmentId = updatePersonDepartmentDto.DepartmentId;
                ediEntity.IsBossOffice = updatePersonDepartmentDto.IsBossOffice;
                if (cancellationToken.IsCancellationRequested)
                    return false;
                await db.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;


        }
        public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            var ediEntity = db.PersonDepartmentList.Where(t => t.Id == id).FirstOrDefault();
            if (ediEntity != null)
            {
                db.PersonDepartmentList.Remove(ediEntity);
                if (cancellationToken.IsCancellationRequested)
                    return false;
                await db.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
