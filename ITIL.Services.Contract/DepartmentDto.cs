using ITIL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Services.Contract
{
	public class DepartmentDto
	{
		public Guid Id { get; set; }
		public string TiTle { get; set; }
		public Guid CityId { get;set; }
		public string CityTitle { get; set; }
		public DepartmentType DepartmentType { get; set; }
	}
	public class CreateDepartmentDto
	{
		public string TiTle { get; set; }
		public Guid CityId { get; set; }
		public DepartmentType DepartmentType { get; set; }
	}
	public class UpdateDepartmentDto
	{
		public Guid Id { get; set; }
		public string TiTle { get; set; }
        public Guid CityId { get; set; }
        public DepartmentType DepartmentType { get; set; }
	}
}
