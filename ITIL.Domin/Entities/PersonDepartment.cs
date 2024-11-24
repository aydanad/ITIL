namespace ITIL.Domin.Entities
{
    public class PersonDepartment : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person Person {  get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public bool IsBossOffice {  get; set; }
         


    }
}
