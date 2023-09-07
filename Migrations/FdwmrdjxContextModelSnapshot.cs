﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Petrol_Pump1.ModelPostgres;

#nullable disable

namespace Petrol_Pump1.Migrations
{
    [DbContext(typeof(FdwmrdjxContext))]
    partial class FdwmrdjxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "btree_gin");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "btree_gist");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "citext");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "cube");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "dblink");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "dict_int");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "dict_xsyn");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "earthdistance");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "fuzzystrmatch");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "hstore");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "intarray");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "ltree");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pg_stat_statements");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pg_trgm");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pgcrypto");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pgrowlocks");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pgstattuple");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "tablefunc");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "unaccent");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "xml2");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Petrol_Pump1.ModelPostgres.Contractor", b =>
                {
                    b.Property<int>("ContractorId")
                        .HasColumnType("integer")
                        .HasColumnName("contractor_id");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("LoginPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("login_password");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("phone");

                    b.HasKey("ContractorId")
                        .HasName("contractor_pkey");

                    b.ToTable("contractor", (string)null);
                });

            modelBuilder.Entity("Petrol_Pump1.ModelPostgres.Employee", b =>
                {
                    b.Property<decimal>("EmployeeId")
                        .HasColumnType("numeric")
                        .HasColumnName("employee_id");

                    b.Property<string>("EmployeeEmail")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("employee_email");

                    b.Property<string>("EmployeeName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("employee_name");

                    b.Property<string>("EmployeePhone")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("employee_phone");

                    b.Property<string>("LoginPassword")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("login_password");

                    b.HasKey("EmployeeId")
                        .HasName("employee_pkey");

                    b.ToTable("employee", (string)null);
                });

            modelBuilder.Entity("Petrol_Pump1.ModelPostgres.ExternalOrder", b =>
                {
                    b.Property<decimal>("ExtOrderid")
                        .HasColumnType("numeric")
                        .HasColumnName("ext_orderid");

                    b.Property<string>("BuyerName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("buyer_name");

                    b.Property<string>("BuyerPhone")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("buyer_phone");

                    b.Property<DateOnly?>("DateOrdered")
                        .HasColumnType("date")
                        .HasColumnName("date_ordered");

                    b.Property<decimal?>("OverseenBy")
                        .HasColumnType("numeric")
                        .HasColumnName("overseen_by");

                    b.Property<int?>("ProductBought")
                        .HasColumnType("integer")
                        .HasColumnName("product_bought");

                    b.Property<decimal?>("TotalPayable")
                        .HasColumnType("numeric")
                        .HasColumnName("total_payable");

                    b.Property<decimal?>("UnitsBought")
                        .HasColumnType("numeric")
                        .HasColumnName("units_bought");

                    b.HasKey("ExtOrderid")
                        .HasName("external_orders_pkey");

                    b.HasIndex("OverseenBy");

                    b.HasIndex("ProductBought");

                    b.ToTable("external_orders", (string)null);
                });

            modelBuilder.Entity("Petrol_Pump1.ModelPostgres.InternalOrder", b =>
                {
                    b.Property<decimal>("IntOrderid")
                        .HasColumnType("numeric")
                        .HasColumnName("int_orderid");

                    b.Property<DateOnly?>("DateOrdered")
                        .HasColumnType("date")
                        .HasColumnName("date_ordered");

                    b.Property<bool?>("OrderConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("order_confirmed");

                    b.Property<bool?>("OrderDispatched")
                        .HasColumnType("boolean")
                        .HasColumnName("order_dispatched");

                    b.Property<int?>("ProductBought")
                        .HasColumnType("integer")
                        .HasColumnName("product_bought");

                    b.Property<bool?>("ProductDelivered")
                        .HasColumnType("boolean")
                        .HasColumnName("product_delivered");

                    b.Property<int?>("SuppliedBy")
                        .HasColumnType("integer")
                        .HasColumnName("supplied_by");

                    b.Property<decimal?>("TotalPayable")
                        .HasColumnType("numeric")
                        .HasColumnName("total_payable");

                    b.Property<decimal?>("UnitsBought")
                        .HasColumnType("numeric")
                        .HasColumnName("units_bought");

                    b.HasKey("IntOrderid")
                        .HasName("internal_orders_pkey");

                    b.HasIndex("ProductBought");

                    b.HasIndex("SuppliedBy");

                    b.ToTable("internal_orders", (string)null);
                });

            modelBuilder.Entity("Petrol_Pump1.ModelPostgres.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.Property<decimal>("PricePerUnit")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("price_per_unit");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("product_description");

                    b.Property<int?>("SuppliedBy")
                        .HasColumnType("integer")
                        .HasColumnName("supplied_by");

                    b.Property<decimal?>("ThresholdUnits")
                        .HasColumnType("numeric")
                        .HasColumnName("threshold_units");

                    b.Property<decimal>("UnitsInStock")
                        .HasColumnType("numeric")
                        .HasColumnName("units_in_stock");

                    b.HasKey("ProductId")
                        .HasName("products_pkey");

                    b.HasIndex("SuppliedBy");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("Petrol_Pump1.ModelPostgres.User", b =>
                {
                    b.Property<decimal>("UserId")
                        .HasColumnType("numeric");

                    b.Property<byte[]>("PasswordHarsh")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Petrol_Pump1.ModelPostgres.ExternalOrder", b =>
                {
                    b.HasOne("Petrol_Pump1.ModelPostgres.Employee", "OverseenByNavigation")
                        .WithMany("ExternalOrders")
                        .HasForeignKey("OverseenBy")
                        .HasConstraintName("external_orders_overseen_by_fkey");

                    b.HasOne("Petrol_Pump1.ModelPostgres.Product", "ProductBoughtNavigation")
                        .WithMany("ExternalOrders")
                        .HasForeignKey("ProductBought")
                        .HasConstraintName("external_orders_product_bought_fkey");

                    b.Navigation("OverseenByNavigation");

                    b.Navigation("ProductBoughtNavigation");
                });

            modelBuilder.Entity("Petrol_Pump1.ModelPostgres.InternalOrder", b =>
                {
                    b.HasOne("Petrol_Pump1.ModelPostgres.Product", "ProductBoughtNavigation")
                        .WithMany("InternalOrders")
                        .HasForeignKey("ProductBought")
                        .HasConstraintName("internal_orders_product_bought_fkey");

                    b.HasOne("Petrol_Pump1.ModelPostgres.Contractor", "SuppliedByNavigation")
                        .WithMany("InternalOrders")
                        .HasForeignKey("SuppliedBy")
                        .HasConstraintName("internal_orders_supplied_by_fkey");

                    b.Navigation("ProductBoughtNavigation");

                    b.Navigation("SuppliedByNavigation");
                });

            modelBuilder.Entity("Petrol_Pump1.ModelPostgres.Product", b =>
                {
                    b.HasOne("Petrol_Pump1.ModelPostgres.Contractor", "SuppliedByNavigation")
                        .WithMany("Products")
                        .HasForeignKey("SuppliedBy")
                        .HasConstraintName("products_supplied_by_fkey");

                    b.Navigation("SuppliedByNavigation");
                });

            modelBuilder.Entity("Petrol_Pump1.ModelPostgres.Contractor", b =>
                {
                    b.Navigation("InternalOrders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Petrol_Pump1.ModelPostgres.Employee", b =>
                {
                    b.Navigation("ExternalOrders");
                });

            modelBuilder.Entity("Petrol_Pump1.ModelPostgres.Product", b =>
                {
                    b.Navigation("ExternalOrders");

                    b.Navigation("InternalOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
