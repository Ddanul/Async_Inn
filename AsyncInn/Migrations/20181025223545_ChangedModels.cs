using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class ChangedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_RoomAmenities_RoomAmenitiesAmenitiesID_RoomAmenitiesRoomID",
                table: "Amenities");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_HotelRooms_HotelRoomHotelID_HotelRoomRoomNumber",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HotelRooms_HotelRoomHotelID_HotelRoomRoomNumber",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomAmenities_RoomAmenitiesAmenitiesID_RoomAmenitiesRoomID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelRoomHotelID_HotelRoomRoomNumber",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomAmenitiesAmenitiesID_RoomAmenitiesRoomID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_HotelRoomHotelID_HotelRoomRoomNumber",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Amenities_RoomAmenitiesAmenitiesID_RoomAmenitiesRoomID",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HotelRoomHotelID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HotelRoomRoomNumber",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomAmenitiesAmenitiesID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomAmenitiesRoomID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HotelRoomHotelID",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HotelRoomRoomNumber",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "RoomAmenitiesAmenitiesID",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "RoomAmenitiesRoomID",
                table: "Amenities");

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "HotelRooms",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_RoomID",
                table: "RoomAmenities",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomID",
                table: "HotelRooms",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Hotels_HotelID",
                table: "HotelRooms",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Rooms_RoomID",
                table: "HotelRooms",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenitiesID",
                table: "RoomAmenities",
                column: "AmenitiesID",
                principalTable: "Amenities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomID",
                table: "RoomAmenities",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Hotels_HotelID",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Rooms_RoomID",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenitiesID",
                table: "RoomAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomID",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_RoomID",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_HotelRooms_RoomID",
                table: "HotelRooms");

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomHotelID",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomRoomNumber",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomAmenitiesAmenitiesID",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomAmenitiesRoomID",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomHotelID",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelRoomRoomNumber",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RoomID",
                table: "HotelRooms",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RoomAmenitiesAmenitiesID",
                table: "Amenities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomAmenitiesRoomID",
                table: "Amenities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelRoomHotelID_HotelRoomRoomNumber",
                table: "Rooms",
                columns: new[] { "HotelRoomHotelID", "HotelRoomRoomNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomAmenitiesAmenitiesID_RoomAmenitiesRoomID",
                table: "Rooms",
                columns: new[] { "RoomAmenitiesAmenitiesID", "RoomAmenitiesRoomID" });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HotelRoomHotelID_HotelRoomRoomNumber",
                table: "Hotels",
                columns: new[] { "HotelRoomHotelID", "HotelRoomRoomNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_RoomAmenitiesAmenitiesID_RoomAmenitiesRoomID",
                table: "Amenities",
                columns: new[] { "RoomAmenitiesAmenitiesID", "RoomAmenitiesRoomID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_RoomAmenities_RoomAmenitiesAmenitiesID_RoomAmenitiesRoomID",
                table: "Amenities",
                columns: new[] { "RoomAmenitiesAmenitiesID", "RoomAmenitiesRoomID" },
                principalTable: "RoomAmenities",
                principalColumns: new[] { "AmenitiesID", "RoomID" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_HotelRooms_HotelRoomHotelID_HotelRoomRoomNumber",
                table: "Hotels",
                columns: new[] { "HotelRoomHotelID", "HotelRoomRoomNumber" },
                principalTable: "HotelRooms",
                principalColumns: new[] { "HotelID", "RoomNumber" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_HotelRooms_HotelRoomHotelID_HotelRoomRoomNumber",
                table: "Rooms",
                columns: new[] { "HotelRoomHotelID", "HotelRoomRoomNumber" },
                principalTable: "HotelRooms",
                principalColumns: new[] { "HotelID", "RoomNumber" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomAmenities_RoomAmenitiesAmenitiesID_RoomAmenitiesRoomID",
                table: "Rooms",
                columns: new[] { "RoomAmenitiesAmenitiesID", "RoomAmenitiesRoomID" },
                principalTable: "RoomAmenities",
                principalColumns: new[] { "AmenitiesID", "RoomID" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
