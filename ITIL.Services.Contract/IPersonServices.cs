using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Services.Contract
{
	public interface IPersonServices
	{
		Task<IList<PersonDto>> GetAllAsync();
		Task<PersonDto?> GetAsync(Guid id);
		Task<Guid?> InsertAsync(CreatePersonDto createPersonDto, CancellationToken cancellationToken);
		Task<bool> UpdateAsync(UpdatePersonDto updatePersonDto, CancellationToken cancellationToken);
		Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken);
	}
}
