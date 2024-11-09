namespace ITIL.Services.Contract
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }  
        
        public int DepartmentCount {  get; set; }
    }

    public class CreateCityDto
    {
        public string Title { get; set; }
    }
    public class UpdateCityDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }

}
