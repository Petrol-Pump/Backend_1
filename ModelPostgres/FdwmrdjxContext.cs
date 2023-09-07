using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Petrol_Pump1.ModelPostgres;

public partial class FdwmrdjxContext : DbContext
{
    public FdwmrdjxContext()
    {
    }

    public FdwmrdjxContext(DbContextOptions<FdwmrdjxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contractor> Contractors { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<ExternalOrder> ExternalOrders { get; set; }

    public virtual DbSet<InternalOrder> InternalOrders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=berry.db.elephantsql.com;Database=fdwmrdjx;Username=fdwmrdjx;Password=wPJzR6k6ZYtJJG5gIU4oQztRpjmCQKDr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("btree_gin")
            .HasPostgresExtension("btree_gist")
            .HasPostgresExtension("citext")
            .HasPostgresExtension("cube")
            .HasPostgresExtension("dblink")
            .HasPostgresExtension("dict_int")
            .HasPostgresExtension("dict_xsyn")
            .HasPostgresExtension("earthdistance")
            .HasPostgresExtension("fuzzystrmatch")
            .HasPostgresExtension("hstore")
            .HasPostgresExtension("intarray")
            .HasPostgresExtension("ltree")
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("pgcrypto")
            .HasPostgresExtension("pgrowlocks")
            .HasPostgresExtension("pgstattuple")
            .HasPostgresExtension("tablefunc")
            .HasPostgresExtension("unaccent")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("xml2");

        modelBuilder.Entity<Contractor>(entity =>
        {
            entity.HasKey(e => e.ContractorId).HasName("contractor_pkey");

            entity.ToTable("contractor");

            entity.Property(e => e.ContractorId)
                .ValueGeneratedNever()
                .HasColumnName("contractor_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.LoginPassword)
                .HasMaxLength(255)
                .HasColumnName("login_password");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("employee_pkey");

            entity.ToTable("employee");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(50)
                .HasColumnName("employee_email");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .HasColumnName("employee_name");
            entity.Property(e => e.EmployeePhone)
                .HasMaxLength(10)
                .HasColumnName("employee_phone");
            entity.Property(e => e.LoginPassword)
                .HasMaxLength(50)
                .HasColumnName("login_password");
        });

        modelBuilder.Entity<ExternalOrder>(entity =>
        {
            entity.HasKey(e => e.ExtOrderid).HasName("external_orders_pkey");

            entity.ToTable("external_orders");

            entity.Property(e => e.ExtOrderid).HasColumnName("ext_orderid");
            entity.Property(e => e.BuyerName)
                .HasMaxLength(100)
                .HasColumnName("buyer_name");
            entity.Property(e => e.BuyerPhone)
                .HasMaxLength(10)
                .HasColumnName("buyer_phone");
            entity.Property(e => e.DateOrdered).HasColumnName("date_ordered");
            entity.Property(e => e.OverseenBy).HasColumnName("overseen_by");
            entity.Property(e => e.ProductBought).HasColumnName("product_bought");
            entity.Property(e => e.TotalPayable).HasColumnName("total_payable");
            entity.Property(e => e.UnitsBought).HasColumnName("units_bought");

            entity.HasOne(d => d.OverseenByNavigation).WithMany(p => p.ExternalOrders)
                .HasForeignKey(d => d.OverseenBy)
                .HasConstraintName("external_orders_overseen_by_fkey");

            entity.HasOne(d => d.ProductBoughtNavigation).WithMany(p => p.ExternalOrders)
                .HasForeignKey(d => d.ProductBought)
                .HasConstraintName("external_orders_product_bought_fkey");
        });

        modelBuilder.Entity<InternalOrder>(entity =>
        {
            entity.HasKey(e => e.IntOrderid).HasName("internal_orders_pkey");

            entity.ToTable("internal_orders");

            entity.Property(e => e.IntOrderid).HasColumnName("int_orderid");
            entity.Property(e => e.DateOrdered).HasColumnName("date_ordered");
            entity.Property(e => e.OrderConfirmed).HasColumnName("order_confirmed");
            entity.Property(e => e.OrderDispatched).HasColumnName("order_dispatched");
            entity.Property(e => e.ProductBought).HasColumnName("product_bought");
            entity.Property(e => e.ProductDelivered).HasColumnName("product_delivered");
            entity.Property(e => e.SuppliedBy).HasColumnName("supplied_by");
            entity.Property(e => e.TotalPayable).HasColumnName("total_payable");
            entity.Property(e => e.UnitsBought).HasColumnName("units_bought");

            entity.HasOne(d => d.ProductBoughtNavigation).WithMany(p => p.InternalOrders)
                .HasForeignKey(d => d.ProductBought)
                .HasConstraintName("internal_orders_product_bought_fkey");

            entity.HasOne(d => d.SuppliedByNavigation).WithMany(p => p.InternalOrders)
                .HasForeignKey(d => d.SuppliedBy)
                .HasConstraintName("internal_orders_supplied_by_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("product_id");
            entity.Property(e => e.PricePerUnit)
                .HasPrecision(10, 2)
                .HasColumnName("price_per_unit");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(255)
                .HasColumnName("product_description");
            entity.Property(e => e.SuppliedBy).HasColumnName("supplied_by");
            entity.Property(e => e.ThresholdUnits).HasColumnName("threshold_units");
            entity.Property(e => e.UnitsInStock).HasColumnName("units_in_stock");

            entity.HasOne(d => d.SuppliedByNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.SuppliedBy)
                .HasConstraintName("products_supplied_by_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
