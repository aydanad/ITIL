
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Services.Contract
{
	public interface IDepartmentServices
	{
		Task<IList<DepartmentDto>> GetAllAsync();
		Task<DepartmentDto?> GetAsync(Guid id);
		Task<Guid?> InsertAsyns(CreateDepartmentDto createDepartmentDto, CancellationToken cancellationToken);
		Task<bool> UpdateAsync(UpdateDepartmentDto updateDepartmentDto, CancellationToken cancellationToken);
		Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken);
	}
}
