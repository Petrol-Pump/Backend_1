using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Petrol_Pump1.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:btree_gin", ",,")
                .Annotation("Npgsql:PostgresExtension:btree_gist", ",,")
                .Annotation("Npgsql:PostgresExtension:citext", ",,")
                .Annotation("Npgsql:PostgresExtension:cube", ",,")
                .Annotation("Npgsql:PostgresExtension:dblink", ",,")
                .Annotation("Npgsql:PostgresExtension:dict_int", ",,")
                .Annotation("Npgsql:PostgresExtension:dict_xsyn", ",,")
                .Annotation("Npgsql:PostgresExtension:earthdistance", ",,")
                .Annotation("Npgsql:PostgresExtension:fuzzystrmatch", ",,")
                .Annotation("Npgsql:PostgresExtension:hstore", ",,")
                .Annotation("Npgsql:PostgresExtension:intarray", ",,")
                .Annotation("Npgsql:PostgresExtension:ltree", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_stat_statements", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_trgm", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .Annotation("Npgsql:PostgresExtension:pgrowlocks", ",,")
                .Annotation("Npgsql:PostgresExtension:pgstattuple", ",,")
                .Annotation("Npgsql:PostgresExtension:tablefunc", ",,")
                .Annotation("Npgsql:PostgresExtension:unaccent", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .Annotation("Npgsql:PostgresExtension:xml2", ",,");

            migrationBuilder.CreateTable(
                name: "contractor",
                columns: table => new
                {
                    contractor_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    login_password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("contractor_pkey", x => x.contractor_id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    employee_id = table.Column<decimal>(type: "numeric", nullable: false),
                    employee_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    employee_phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    employee_email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    login_password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_pkey", x => x.employee_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<decimal>(type: "numeric", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    PasswordHarsh = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    product_description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    units_in_stock = table.Column<decimal>(type: "numeric", nullable: false),
                    price_per_unit = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    supplied_by = table.Column<int>(type: "integer", nullable: true),
                    threshold_units = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("products_pkey", x => x.product_id);
                    table.ForeignKey(
                        name: "products_supplied_by_fkey",
                        column: x => x.supplied_by,
                        principalTable: "contractor",
                        principalColumn: "contractor_id");
                });

            migrationBuilder.CreateTable(
                name: "external_orders",
                columns: table => new
                {
                    ext_orderid = table.Column<decimal>(type: "numeric", nullable: false),
                    buyer_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    overseen_by = table.Column<decimal>(type: "numeric", nullable: true),
                    product_bought = table.Column<int>(type: "integer", nullable: true),
                    total_payable = table.Column<decimal>(type: "numeric", nullable: true),
                    units_bought = table.Column<decimal>(type: "numeric", nullable: true),
                    buyer_phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    date_ordered = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("external_orders_pkey", x => x.ext_orderid);
                    table.ForeignKey(
                        name: "external_orders_overseen_by_fkey",
                        column: x => x.overseen_by,
                        principalTable: "employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "external_orders_product_bought_fkey",
                        column: x => x.product_bought,
                        principalTable: "products",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "internal_orders",
                columns: table => new
                {
                    int_orderid = table.Column<decimal>(type: "numeric", nullable: false),
                    supplied_by = table.Column<int>(type: "integer", nullable: true),
                    product_bought = table.Column<int>(type: "integer", nullable: true),
                    units_bought = table.Column<decimal>(type: "numeric", nullable: true),
                    total_payable = table.Column<decimal>(type: "numeric", nullable: true),
                    order_confirmed = table.Column<bool>(type: "boolean", nullable: true),
                    product_delivered = table.Column<bool>(type: "boolean", nullable: true),
                    order_dispatched = table.Column<bool>(type: "boolean", nullable: true),
                    date_ordered = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("internal_orders_pkey", x => x.int_orderid);
                    table.ForeignKey(
                        name: "internal_orders_product_bought_fkey",
                        column: x => x.product_bought,
                        principalTable: "products",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "internal_orders_supplied_by_fkey",
                        column: x => x.supplied_by,
                        principalTable: "contractor",
                        principalColumn: "contractor_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_external_orders_overseen_by",
                table: "external_orders",
                column: "overseen_by");

            migrationBuilder.CreateIndex(
                name: "IX_external_orders_product_bought",
                table: "external_orders",
                column: "product_bought");

            migrationBuilder.CreateIndex(
                name: "IX_internal_orders_product_bought",
                table: "internal_orders",
                column: "product_bought");

            migrationBuilder.CreateIndex(
                name: "IX_internal_orders_supplied_by",
                table: "internal_orders",
                column: "supplied_by");

            migrationBuilder.CreateIndex(
                name: "IX_products_supplied_by",
                table: "products",
                column: "supplied_by");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "external_orders");

            migrationBuilder.DropTable(
                name: "internal_orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "contractor");
        }
    }
}
