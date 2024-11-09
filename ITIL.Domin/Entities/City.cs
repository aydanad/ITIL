namespace ITIL.Domin.Entities
{
    public class City:BaseEntity {

        public string Title { get; set; }

        public ICollection<Department> DepartmentList { get; set; }
    }
}
