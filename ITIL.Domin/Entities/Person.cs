﻿namespace ITIL.Domin.Entities
{
    public class Person : BaseEntity
    {
		public string? UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

		public string NationalCode { get; set; }

        public ICollection<PersonDepartment> PersonDepartmentList { get; set; }

    }
}
