using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApp.Migrations
{
    /// <inheritdoc />
    public partial class time1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Industri__808DEDCC9FC2A857", x => x.IndustryId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Symbol = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Change = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    Sector = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Industry = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stocks__2C83A9C208180A4D", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CC4CBB8AF620", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "IndustryStocks",
                columns: table => new
                {
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__IndustryS__Indus__4CA06362",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "IndustryId");
                    table.ForeignKey(
                        name: "FK__IndustryS__Stock__4D94879B",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "StockId");
                });

            migrationBuilder.CreateTable(
                name: "Watchlists",
                columns: table => new
                {
                    WatchlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Watchlis__48DE55CB96392774", x => x.WatchlistId);
                    table.ForeignKey(
                        name: "FK__Watchlist__UserI__3F466844",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "WatchlistStocks",
                columns: table => new
                {
                    WatchlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Watchlist__Stock__4AB81AF0",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "StockId");
                    table.ForeignKey(
                        name: "FK__Watchlist__Watch__49C3F6B7",
                        column: x => x.WatchlistId,
                        principalTable: "Watchlists",
                        principalColumn: "WatchlistId");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Industri__737584F6FADF0965",
                table: "Industries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndustryStocks_IndustryId",
                table: "IndustryStocks",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustryStocks_StockId",
                table: "IndustryStocks",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "UQ__Stocks__B7CC3F0176D4C920",
                table: "Stocks",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__536C85E4A44CBD1C",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534ADC48351",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_UserId",
                table: "Watchlists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistStocks_StockId",
                table: "WatchlistStocks",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistStocks_WatchlistId",
                table: "WatchlistStocks",
                column: "WatchlistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndustryStocks");

            migrationBuilder.DropTable(
                name: "WatchlistStocks");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Watchlists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
