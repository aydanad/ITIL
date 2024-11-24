using ITIL.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Services.Contract
{
	public class DepartmentDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public Guid CityId { get;set; }
		public string CityTitle { get; set; }
		public DepartmentType DepartmentType { get; set; }
	}
	public class CreateDepartmentDto
	{
        [Required(ErrorMessage = "نام را وارد کنید")]
		[StringLength(120,MinimumLength =3,ErrorMessage ="نام باید بین 3 تا 120 کاراکتر باشد")]
        public string Title { get; set; }
        [Required]
        public Guid CityId { get; set; }
        [Required]
        public DepartmentType DepartmentType { get; set; }
	}
	public class UpdateDepartmentDto
	{
		public Guid Id { get; set; }
		[Required]
        [StringLength(120, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        public Guid CityId { get; set; }
        [Required]
        public DepartmentType DepartmentType { get; set; }
	}
}
