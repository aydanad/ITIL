using System.ComponentModel.DataAnnotations;

namespace ITIL.Shared
{
    public enum DepartmentType:short
    {
        [Display(Name ="هیچکدام")]
        None = 0,
        [Display(Name = "بیمارستان")]
        Hospital =1,
        [Display(Name = "مرکز بهداشت")]
        HealthCenter =2

    }
}
