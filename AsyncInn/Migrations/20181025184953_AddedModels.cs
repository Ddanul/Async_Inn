using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class AddedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    HotelID = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    RoomID = table.Column<decimal>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    PetFriendly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => new { x.HotelID, x.RoomNumber });
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    AmenitiesID = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => new { x.AmenitiesID, x.RoomID });
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    HotelRoomHotelID = table.Column<int>(nullable: true),
                    HotelRoomRoomNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hotels_HotelRooms_HotelRoomHotelID_HotelRoomRoomNumber",
                        columns: x => new { x.HotelRoomHotelID, x.HotelRoomRoomNumber },
                        principalTable: "HotelRooms",
                        principalColumns: new[] { "HotelID", "RoomNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    RoomAmenitiesAmenitiesID = table.Column<int>(nullable: true),
                    RoomAmenitiesRoomID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Amenities_RoomAmenities_RoomAmenitiesAmenitiesID_RoomAmenitiesRoomID",
                        columns: x => new { x.RoomAmenitiesAmenitiesID, x.RoomAmenitiesRoomID },
                        principalTable: "RoomAmenities",
                        principalColumns: new[] { "AmenitiesID", "RoomID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Layout = table.Column<int>(nullable: false),
                    HotelRoomHotelID = table.Column<int>(nullable: true),
                    HotelRoomRoomNumber = table.Column<int>(nullable: true),
                    RoomAmenitiesAmenitiesID = table.Column<int>(nullable: true),
                    RoomAmenitiesRoomID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_HotelRooms_HotelRoomHotelID_HotelRoomRoomNumber",
                        columns: x => new { x.HotelRoomHotelID, x.HotelRoomRoomNumber },
                        principalTable: "HotelRooms",
                        principalColumns: new[] { "HotelID", "RoomNumber" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomAmenities_RoomAmenitiesAmenitiesID_RoomAmenitiesRoomID",
                        columns: x => new { x.RoomAmenitiesAmenitiesID, x.RoomAmenitiesRoomID },
                        principalTable: "RoomAmenities",
                        principalColumns: new[] { "AmenitiesID", "RoomID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_RoomAmenitiesAmenitiesID_RoomAmenitiesRoomID",
                table: "Amenities",
                columns: new[] { "RoomAmenitiesAmenitiesID", "RoomAmenitiesRoomID" });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HotelRoomHotelID_HotelRoomRoomNumber",
                table: "Hotels",
                columns: new[] { "HotelRoomHotelID", "HotelRoomRoomNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelRoomHotelID_HotelRoomRoomNumber",
                table: "Rooms",
                columns: new[] { "HotelRoomHotelID", "HotelRoomRoomNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomAmenitiesAmenitiesID_RoomAmenitiesRoomID",
                table: "Rooms",
                columns: new[] { "RoomAmenitiesAmenitiesID", "RoomAmenitiesRoomID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "RoomAmenities");
        }
    }
}
