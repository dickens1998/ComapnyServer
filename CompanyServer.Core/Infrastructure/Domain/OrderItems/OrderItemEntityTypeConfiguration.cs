using CompanyServer.Core.Domain.OrderItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyServer.Core.Infrastructure.Domain.OrderItems;

public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("order_items")
            .HasKey(o => o.Id);

        builder.OwnsOne(p => p.Material, m =>
        {
            m.Property(mp => mp.Number).HasColumnName("material_number").HasColumnType("varchar(255)");
            m.Property(mp => mp.Description).HasColumnName("material_description").HasColumnType("varchar(255)");
            m.Property(mp => mp.QcType).HasColumnName("qc_type").HasColumnType("varchar(20)");
        });

        builder.OwnsOne(p => p.Weight, w =>
        {
            w.Property(wp => wp.Value).HasColumnName("weight_value").HasColumnType("decimal(6,2)");
            w.Property(wp => wp.Unit).HasColumnName("weight_unit").HasColumnType("varchar(20)");
        });

        builder.OwnsMany(x => x.GoodsList, m =>
        {
            m.WithOwner().HasForeignKey(p => p.OrderItemId);
            m.ToTable("goods");
            m.HasKey(p => p.Id);

            m.Property(p => p.MaterialNumber)
                .HasColumnName("material_number")
                .HasColumnType("varchar(255)");

            m.OwnsOne(p => p.Weight, w =>
            {
                w.Property(wp => wp.Value).HasColumnName("weight_value").HasColumnType("decimal(6,2)");
                w.Property(wp => wp.Unit).HasColumnName("weight_unit").HasColumnType("varchar(20)");
            });

            m.OwnsOne(p => p.UnitPriceWeight, w =>
            {
                w.Property(wp => wp.Value).HasColumnName("price").HasColumnType("decimal(6,2)");
                w.Property(wp => wp.Unit).HasColumnName("unit").HasColumnType("varchar(20)");
            });
        });
    }
}