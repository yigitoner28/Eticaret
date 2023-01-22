using Eticaret.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETicaret.DataAccesLayer.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Product");

            builder.Property(x => x.ProductName)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.ProductDescription)
                .HasColumnType("nvarchar")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.ProductCode)
                .HasColumnType("nvarchar")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.SubCategoryId)
                .HasColumnType("int")
                .HasMaxLength(500)
            .IsRequired();



            builder.HasData(new Product
            {
                ProductName = "Telefon",
                ProductCode = "denemeKod",
                ProductDescription = "Description",
                ProductId = 1,
                SubCategoryId = 1


            });



        }
    }
}
