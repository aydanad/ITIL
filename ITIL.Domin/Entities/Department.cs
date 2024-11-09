namespace ITIL.Domin.Entities
{
    public class Department:BaseEntity
	{
		 
		public string Title { get; set; }

		public Guid CityId { get; set; }
		public City City { get; set; }

		public DepartmentType DepartmentType { get; set; }
		 
	}
}
