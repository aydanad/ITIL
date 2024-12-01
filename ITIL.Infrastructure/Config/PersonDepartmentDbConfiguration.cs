using ITIL.Domin.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Infrastructure.Config
{
    public class PersonDepartmentDbConfiguration: IEntityTypeConfiguration<PersonDepartment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PersonDepartment> builder)
        {

            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.HasKey(t => t.Id);

            builder.Property(t => t.PersonId).IsRequired();
            builder.Property(t => t.DepartmentId).IsRequired();
            builder.Property(t => t.IsBossOffice).IsRequired();
            builder.HasOne(d => d.Person) 
                            .WithMany(p => p.PersonDepartmentList) 
                            .HasForeignKey(d => d.PersonId)
                            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
