using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "UserImages");

            migrationBuilder.DropColumn(
                name: "StorageType",
                table: "UserImages");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "Users",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "TotalSearchCount",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "UserImages",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UserImages",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionType",
                table: "UserImages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "FileAttachmentId",
                table: "UserImages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "FileAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FilePath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    StorageType = table.Column<int>(type: "integer", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAttachments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "PasswordHash", "PasswordSalt", "TotalSearchCount" },
                values: new object[] { new byte[] { 208, 214, 151, 67, 180, 148, 249, 167, 61, 224, 204, 207, 0, 220, 216, 159, 255, 59, 244, 33, 45, 103, 72, 164, 202, 53, 110, 88, 131, 76, 93, 177, 221, 156, 51, 118, 15, 234, 95, 41, 47, 156, 192, 155, 176, 114, 113, 65, 49, 157, 170, 179, 193, 65, 12, 205, 31, 108, 222, 109, 62, 141, 41, 47 }, new byte[] { 248, 242, 182, 151, 148, 206, 234, 215, 122, 1, 156, 128, 226, 229, 57, 97, 45, 215, 171, 239, 94, 13, 114, 26, 100, 99, 61, 174, 203, 77, 234, 86, 66, 223, 203, 196, 167, 100, 187, 93, 54, 92, 209, 147, 87, 192, 87, 26, 107, 22, 170, 187, 85, 132, 248, 103, 84, 169, 27, 242, 5, 237, 5, 74, 10, 146, 51, 96, 22, 6, 85, 129, 95, 246, 215, 150, 239, 249, 160, 15, 89, 89, 174, 31, 60, 63, 25, 81, 4, 117, 200, 53, 169, 211, 93, 31, 124, 109, 48, 200, 21, 243, 61, 188, 29, 252, 131, 34, 19, 202, 131, 113, 66, 253, 248, 178, 64, 94, 39, 216, 66, 121, 222, 165, 154, 44, 185, 200 }, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "PasswordHash", "PasswordSalt", "TotalSearchCount" },
                values: new object[] { new byte[] { 26, 10, 207, 76, 245, 238, 217, 157, 47, 132, 64, 156, 68, 208, 253, 34, 148, 51, 225, 116, 45, 155, 95, 165, 52, 22, 148, 49, 94, 67, 28, 199, 79, 144, 118, 57, 110, 90, 16, 154, 173, 243, 106, 107, 236, 175, 116, 125, 111, 151, 143, 59, 149, 231, 117, 249, 170, 238, 74, 10, 255, 190, 8, 69 }, new byte[] { 227, 202, 132, 218, 167, 198, 49, 104, 148, 71, 216, 122, 10, 46, 38, 33, 60, 111, 54, 178, 49, 181, 209, 13, 64, 141, 119, 60, 52, 90, 31, 174, 237, 102, 165, 100, 33, 66, 147, 69, 25, 105, 124, 44, 131, 82, 26, 63, 51, 168, 145, 124, 163, 1, 226, 148, 220, 13, 217, 126, 169, 186, 145, 216, 31, 21, 105, 86, 248, 180, 58, 21, 76, 30, 195, 88, 170, 30, 119, 204, 83, 99, 244, 217, 96, 85, 254, 180, 141, 117, 56, 159, 50, 36, 252, 95, 65, 118, 84, 81, 95, 176, 88, 177, 34, 100, 76, 24, 32, 62, 169, 255, 77, 158, 254, 141, 124, 11, 186, 183, 86, 207, 185, 13, 253, 85, 83, 152 }, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "PasswordHash", "PasswordSalt", "TotalSearchCount" },
                values: new object[] { new byte[] { 179, 225, 128, 111, 207, 123, 212, 211, 167, 50, 80, 113, 127, 29, 42, 164, 140, 64, 90, 90, 114, 62, 31, 173, 200, 196, 189, 60, 62, 106, 65, 168, 43, 6, 203, 144, 127, 7, 211, 218, 123, 249, 132, 187, 122, 41, 70, 172, 114, 18, 125, 100, 253, 227, 35, 227, 65, 35, 199, 242, 10, 175, 175, 216 }, new byte[] { 88, 54, 127, 93, 79, 152, 89, 202, 73, 198, 53, 187, 229, 209, 145, 233, 160, 164, 45, 217, 93, 41, 214, 128, 129, 140, 53, 190, 236, 58, 232, 100, 213, 215, 223, 117, 112, 181, 96, 246, 212, 91, 169, 183, 161, 121, 88, 220, 228, 226, 232, 20, 248, 87, 95, 8, 157, 255, 51, 85, 12, 7, 51, 224, 137, 187, 251, 2, 11, 207, 166, 246, 196, 16, 205, 139, 145, 60, 74, 109, 176, 236, 214, 242, 145, 4, 116, 212, 179, 123, 26, 79, 111, 4, 168, 96, 107, 141, 45, 176, 191, 221, 50, 48, 141, 161, 116, 68, 178, 253, 215, 146, 26, 111, 221, 186, 110, 121, 4, 6, 144, 110, 70, 187, 99, 177, 2, 136 }, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "PasswordHash", "PasswordSalt", "TotalSearchCount" },
                values: new object[] { new byte[] { 14, 22, 86, 109, 202, 228, 228, 117, 141, 210, 141, 243, 170, 164, 101, 104, 116, 130, 34, 228, 201, 105, 94, 209, 134, 197, 228, 182, 97, 182, 148, 170, 251, 223, 193, 136, 141, 104, 242, 22, 245, 68, 8, 170, 215, 126, 40, 62, 92, 197, 121, 135, 112, 86, 42, 187, 129, 4, 190, 213, 38, 242, 55, 107 }, new byte[] { 34, 142, 50, 7, 243, 254, 33, 65, 135, 165, 207, 75, 115, 53, 224, 234, 35, 115, 241, 173, 225, 8, 249, 131, 49, 101, 207, 240, 21, 1, 0, 70, 205, 98, 125, 21, 165, 180, 23, 2, 18, 26, 91, 199, 88, 82, 53, 146, 126, 228, 151, 70, 132, 8, 172, 160, 175, 148, 148, 1, 59, 37, 49, 59, 52, 54, 24, 122, 6, 237, 23, 235, 7, 61, 251, 250, 179, 99, 4, 17, 37, 7, 43, 40, 104, 24, 195, 84, 215, 3, 194, 98, 165, 11, 181, 164, 199, 196, 41, 112, 216, 172, 174, 32, 206, 176, 46, 184, 68, 245, 19, 116, 234, 169, 139, 246, 87, 247, 195, 127, 64, 154, 37, 27, 203, 22, 3, 135 }, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryCode_PhoneNumber",
                table: "Users",
                columns: new[] { "CountryCode", "PhoneNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_FileAttachmentId",
                table: "UserImages",
                column: "FileAttachmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImages_FileAttachments_FileAttachmentId",
                table: "UserImages",
                column: "FileAttachmentId",
                principalTable: "FileAttachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserImages_FileAttachments_FileAttachmentId",
                table: "UserImages");

            migrationBuilder.DropTable(
                name: "FileAttachments");

            migrationBuilder.DropIndex(
                name: "IX_Users_CountryCode_PhoneNumber",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserImages_FileAttachmentId",
                table: "UserImages");

            migrationBuilder.DropColumn(
                name: "TotalSearchCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DescriptionType",
                table: "UserImages");

            migrationBuilder.DropColumn(
                name: "FileAttachmentId",
                table: "UserImages");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "UserImages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UserImages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "UserImages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StorageType",
                table: "UserImages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "DemoUser", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 109, 160, 105, 75, 241, 116, 48, 18, 233, 185, 249, 20, 96, 70, 236, 247, 208, 176, 214, 70, 165, 130, 68, 82, 178, 104, 207, 42, 48, 150, 65, 220, 73, 152, 155, 225, 128, 78, 105, 212, 85, 152, 238, 135, 93, 189, 120, 114, 241, 89, 145, 13, 241, 111, 173, 175, 134, 243, 94, 216, 19, 127, 219, 93 }, new byte[] { 119, 169, 78, 1, 82, 254, 132, 192, 75, 233, 194, 135, 43, 102, 138, 116, 90, 44, 165, 218, 33, 225, 217, 133, 164, 145, 224, 175, 85, 185, 78, 105, 125, 246, 122, 89, 50, 135, 27, 8, 226, 89, 92, 188, 153, 138, 247, 102, 49, 97, 51, 32, 237, 241, 228, 235, 19, 17, 74, 105, 137, 78, 6, 133, 179, 10, 109, 41, 244, 75, 32, 129, 192, 55, 151, 120, 251, 21, 98, 107, 98, 125, 132, 19, 241, 9, 151, 140, 159, 125, 28, 26, 113, 238, 6, 61, 78, 146, 181, 155, 49, 151, 85, 23, 94, 204, 35, 221, 254, 140, 2, 76, 192, 84, 209, 177, 234, 58, 127, 222, 229, 222, 68, 55, 122, 68, 225, 81 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 42, 138, 9, 188, 241, 12, 113, 223, 149, 218, 231, 89, 116, 26, 26, 169, 197, 161, 246, 41, 166, 57, 198, 78, 246, 72, 214, 152, 75, 225, 35, 236, 35, 46, 13, 222, 193, 80, 72, 214, 94, 157, 191, 64, 168, 80, 177, 129, 158, 176, 3, 208, 16, 173, 70, 197, 225, 127, 32, 90, 104, 103, 45, 7 }, new byte[] { 165, 95, 245, 157, 68, 226, 38, 70, 186, 33, 92, 16, 110, 30, 218, 237, 213, 61, 254, 40, 229, 254, 218, 46, 97, 26, 113, 209, 188, 17, 0, 181, 152, 249, 76, 169, 123, 208, 121, 79, 30, 144, 174, 20, 137, 61, 232, 38, 109, 50, 68, 131, 177, 27, 117, 199, 7, 179, 197, 104, 228, 248, 57, 222, 212, 216, 188, 193, 212, 47, 102, 55, 24, 28, 133, 210, 187, 129, 33, 67, 225, 226, 157, 226, 226, 245, 200, 15, 153, 44, 77, 10, 36, 78, 74, 26, 26, 198, 160, 243, 59, 77, 187, 196, 164, 121, 6, 250, 251, 129, 196, 82, 174, 229, 155, 247, 154, 53, 159, 36, 249, 133, 67, 189, 216, 68, 213, 178 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 254, 75, 129, 99, 189, 121, 139, 155, 125, 232, 214, 212, 215, 185, 239, 84, 11, 0, 145, 76, 128, 111, 65, 92, 157, 193, 148, 193, 192, 179, 185, 71, 199, 66, 179, 119, 45, 59, 131, 107, 179, 135, 161, 207, 74, 185, 35, 101, 109, 202, 236, 39, 105, 225, 200, 252, 129, 99, 140, 18, 188, 203, 229, 185 }, new byte[] { 40, 18, 83, 177, 208, 175, 67, 185, 100, 99, 70, 216, 190, 91, 85, 20, 167, 164, 239, 84, 53, 132, 147, 39, 240, 88, 108, 136, 179, 70, 196, 27, 29, 251, 171, 165, 45, 186, 182, 78, 227, 34, 55, 149, 115, 234, 168, 109, 46, 116, 249, 177, 112, 130, 215, 17, 24, 178, 65, 74, 36, 102, 189, 254, 99, 186, 246, 43, 115, 255, 217, 88, 78, 171, 102, 124, 162, 215, 51, 119, 152, 250, 100, 241, 58, 156, 6, 118, 78, 200, 2, 86, 225, 231, 46, 197, 64, 222, 61, 184, 159, 34, 96, 180, 134, 34, 229, 82, 8, 173, 185, 12, 80, 104, 221, 73, 117, 203, 221, 102, 19, 118, 197, 222, 30, 192, 15, 186 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 231, 133, 31, 220, 48, 138, 98, 2, 110, 31, 93, 58, 77, 114, 139, 58, 74, 129, 93, 9, 250, 96, 52, 136, 102, 135, 245, 109, 221, 170, 5, 223, 23, 128, 184, 185, 178, 168, 160, 43, 40, 255, 102, 119, 94, 151, 111, 167, 81, 176, 19, 10, 138, 236, 2, 154, 135, 107, 174, 149, 97, 120, 107 }, new byte[] { 47, 28, 204, 238, 83, 176, 21, 156, 205, 239, 79, 147, 139, 41, 177, 65, 53, 1, 88, 190, 253, 186, 124, 227, 86, 2, 100, 241, 71, 218, 179, 2, 235, 25, 117, 1, 164, 131, 116, 94, 135, 3, 57, 213, 101, 201, 6, 164, 182, 152, 46, 61, 16, 111, 123, 51, 216, 248, 68, 177, 250, 169, 122, 236, 211, 44, 45, 4, 112, 44, 82, 180, 53, 202, 88, 247, 25, 28, 140, 173, 100, 177, 123, 150, 244, 2, 238, 17, 219, 69, 100, 243, 251, 236, 216, 177, 150, 57, 66, 177, 135, 182, 221, 249, 41, 196, 236, 185, 226, 187, 33, 247, 66, 179, 118, 41, 251, 0, 142, 154, 10, 34, 227, 180, 114, 54, 3, 54 } });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("00000000-0000-0000-0000-000000000003"), null, new Guid("33333333-3333-3333-3333-333333333333") });
        }
    }
}
