using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "نام را وارد کنید")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "نام  خانوادگی را وارد کنید")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "کد ملی را وارد کنید")]
        [StringLength(10,ErrorMessage = "نام باید بین 10 کاراکتر باشد")]
        public string NationalCode { get; set; }
	}
	public class UpdatePersonDto
	{
		public Guid Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
        [StringLength(10)]
        public string NationalCode { get; set; }
	}
}
