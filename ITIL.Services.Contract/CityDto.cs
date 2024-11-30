using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "نام را وارد کنید")]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "نام باید بین 3 تا 120 کاراکتر باشد")]
        public string Title { get; set; }
    }
    public class UpdateCityDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(120, MinimumLength = 3)]
        public string Title { get; set; }
    }

}
