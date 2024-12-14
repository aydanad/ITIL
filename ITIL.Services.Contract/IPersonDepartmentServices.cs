using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Services.Contract
{
    public interface IPersonDepartmentServices
    {
        Task<IList<PersonDepartmentDto>> GetAllAsync(Guid id);
        Task<IList<PersonDepartmentDto>> GetAllByIdAsync(Guid id);
        Task<PersonDepartmentDto?> GetAsync(Guid id);
        Task<Guid?> InsertAsync(CreatePersonDepartmentDto createPersonDepartmentDto, CancellationToken cancellationToken);
        Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(UpdatePersonDepartmentDto updatePersonDepartmentDto, CancellationToken cancellationToken);
    }
}
