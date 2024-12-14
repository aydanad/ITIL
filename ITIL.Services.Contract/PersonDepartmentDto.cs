using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Services.Contract
{
    public class PersonDepartmentDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string PersonFullName { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentTitle { get; set; }
        public bool IsBossOffice { get; set; }
    }
    public class CreatePersonDepartmentDto
    {
        public Guid PersonId { get; set; }
        public Guid DepartmentId { get; set; }
        public bool IsBossOffice { get; set; }

    }
    public class UpdatePersonDepartmentDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid DepartmentId { get; set; }
        public bool IsBossOffice { get; set; }
    }
}
