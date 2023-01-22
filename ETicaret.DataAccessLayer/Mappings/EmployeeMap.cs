using Eticaret.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DataAccesLayer.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");


            builder.HasKey(x => x.EmployeeId);


            builder.Property(x => x.EmployeeName)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(x => x.EmployeeLastname)
                 .HasColumnType("nvarchar")
                 .HasMaxLength(100)
                 .IsRequired();


            builder.Property(x => x.EmployeeUserName)
               .HasColumnType("nvarchar")
               .HasMaxLength(100)
               .IsRequired();


            builder.Property(x => x.EmployeeEmail)
               .HasColumnType("nvarchar")
               .HasMaxLength(100)
               .IsRequired();


            builder.Property(x => x.EmployeeStatu)
                .HasDefaultValue(true);


            builder.Property(x => x.StartDate);






            builder.HasData(new Employee
            {
                EmployeeName = "denemeName",
                EmployeeLastname = "denemeLastname",
                EmployeeUserName = "denemeUserName",
                EmployeeEmail = "denemeEmail",
                EmployeeId = 1,
                EmployeeStatu = true,
                StartDate = DateTime.Now,


            });


        }
    }
}
