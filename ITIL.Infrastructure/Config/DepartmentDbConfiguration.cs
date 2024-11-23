using ITIL.Domin.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Infrastructure.Config
{
	public class DepartmentDbConfiguration: IEntityTypeConfiguration<Department>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Department> builder)
		{
			builder.Property(t => t.Id).ValueGeneratedOnAdd();
			builder.HasKey(t => t.Id);

			builder.Property(t => t.Title).IsRequired().HasMaxLength(120);
			builder.Property(t=>t.CityId).IsRequired(false).HasMaxLength(50);
			builder.Property(t => t.City).IsRequired().HasMaxLength(120);
			builder.Property(t => t.DepartmentType).IsRequired().HasMaxLength(50);
		}
	}
}
