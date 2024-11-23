using ITIL.Domin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Infrastructure.Config
{
	public class CityDbConfiguration : IEntityTypeConfiguration<City>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<City> builder)
		{
			builder.Property(t => t.Id).ValueGeneratedOnAdd();
			builder.HasKey(t => t.Id);

			builder.Property(t => t.Title).IsRequired().HasMaxLength(120);
		}
	}
}
