using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Services.Contract
{
	public class PersonDto
	{
		public Guid Id { get; set; }
		public string? UserId { get; set; }
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string NationalCode { get; set; }
		public int PersonDepartmentCount { get; set; }
	}
	public class CreatePersonDto
	{
		public string? UserId { get; set; }
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string NationalCode { get; set; }
	}
	public class UpdatePersonDto
	{
		public Guid Id { get; set; }
		public string? UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string NationalCode { get; set; }
	}
}
