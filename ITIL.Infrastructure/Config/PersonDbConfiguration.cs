using ITIL.Domin.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Infrastructure.Config
{
    public class PersonDbConfiguration : IEntityTypeConfiguration<Person>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Person> builder)
        {

            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.HasKey(t => t.Id);

            
            builder.Property(t => t.UserId).IsRequired(false).HasMaxLength(50);
            builder.Property(t => t.NationalCode).IsRequired().HasMaxLength(10);
            builder.Property(t => t.FirstName).IsRequired().HasMaxLength(120).IsUnicode();
            builder.Property(t => t.LastName).IsRequired().HasMaxLength(120).IsUnicode();
             


        }
    }
}
