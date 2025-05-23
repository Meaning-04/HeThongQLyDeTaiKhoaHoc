using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSanPhamModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPham_DangI_DonViHanhChinh_MaDonViHC",
                table: "ChiTietSanPham_DangI");

            migrationBuilder.DropForeignKey(
                name: "FK_DacTinhKyThuat_ChiTietSanPham_DangI_MaSanPham",
                table: "DacTinhKyThuat");

            migrationBuilder.DropColumn(
                name: "DOI",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "ISSN",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "LoaiBaiBao",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "Nam",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "NgayXuatBan",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "So",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "TacGia",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "TenTapChi",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "TomTat",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "Trang",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "LoaiBaoCao",
                table: "ChiTietSanPham_DangII");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "ChiTietSanPham_DangII");

            migrationBuilder.DropColumn(
                name: "NgayHoanThanh",
                table: "ChiTietSanPham_DangII");

            migrationBuilder.DropColumn(
                name: "TenBaoCao",
                table: "ChiTietSanPham_DangII");

            migrationBuilder.DropColumn(
                name: "TomTatNoiDung",
                table: "ChiTietSanPham_DangII");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietSanPham_DangII");

            migrationBuilder.DropColumn(
                name: "DonViTinh",
                table: "ChiTietSanPham_DangI");

            migrationBuilder.DropColumn(
                name: "GiaTri",
                table: "ChiTietSanPham_DangI");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "ChiTietSanPham_DangI");

            migrationBuilder.DropColumn(
                name: "NgayHoanThanh",
                table: "ChiTietSanPham_DangI");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "ChiTietSanPham_DangI");

            migrationBuilder.DropColumn(
                name: "TenSanPham",
                table: "ChiTietSanPham_DangI");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietSanPham_DangI");

            migrationBuilder.RenameColumn(
                name: "TenDacTinh",
                table: "DacTinhKyThuat",
                newName: "ThongSo");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DacTinhKyThuat",
                newName: "ChiChu");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "DacTinhKyThuat",
                newName: "MaSanPham_I");

            migrationBuilder.RenameColumn(
                name: "DonVi",
                table: "DacTinhKyThuat",
                newName: "DonViDo");

            migrationBuilder.RenameColumn(
                name: "MaDacTinh",
                table: "DacTinhKyThuat",
                newName: "MaDacTinhKyThuat");

            migrationBuilder.RenameIndex(
                name: "IX_DacTinhKyThuat_MaSanPham",
                table: "DacTinhKyThuat",
                newName: "IX_DacTinhKyThuat_MaSanPham_I");

            migrationBuilder.RenameColumn(
                name: "TieuDe",
                table: "ChiTietSanPham_DangIII",
                newName: "NoiCongBo");

            migrationBuilder.RenameColumn(
                name: "MaBaiBao",
                table: "ChiTietSanPham_DangIII",
                newName: "MaSanPham_III");

            migrationBuilder.RenameColumn(
                name: "FileBaoCao",
                table: "ChiTietSanPham_DangII",
                newName: "file_SanPham_II");

            migrationBuilder.RenameColumn(
                name: "MaBaoCao",
                table: "ChiTietSanPham_DangII",
                newName: "MaSanPham_II");

            migrationBuilder.RenameColumn(
                name: "MaSanPham",
                table: "ChiTietSanPham_DangI",
                newName: "MaSanPham_I");

            migrationBuilder.AlterColumn<decimal>(
                name: "GiaTri",
                table: "DacTinhKyThuat",
                type: "NUMERIC(10,6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiSanPham_III",
                table: "ChiTietSanPham_DangIII",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "BangSangChe");

            migrationBuilder.AddColumn<string>(
                name: "TenSanPham_III",
                table: "ChiTietSanPham_DangIII",
                type: "TEXT",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<byte[]>(
                name: "file_SanPham_III",
                table: "ChiTietSanPham_DangIII",
                type: "VARBINARY(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiSanPham_II",
                table: "ChiTietSanPham_DangII",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "BaoCao");

            migrationBuilder.AddColumn<string>(
                name: "TenSanPham_II",
                table: "ChiTietSanPham_DangII",
                type: "TEXT",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AlterColumn<int>(
                name: "MaDonViHC",
                table: "ChiTietSanPham_DangI",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenSanPham_I",
                table: "ChiTietSanPham_DangI",
                type: "TEXT",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<byte[]>(
                name: "file_SanPham_I",
                table: "ChiTietSanPham_DangI",
                type: "VARBINARY(MAX)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPham_DangI_DonViHanhChinh_MaDonViHC",
                table: "ChiTietSanPham_DangI",
                column: "MaDonViHC",
                principalTable: "DonViHanhChinh",
                principalColumn: "MaDonViHC",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DacTinhKyThuat_ChiTietSanPham_DangI_MaSanPham_I",
                table: "DacTinhKyThuat",
                column: "MaSanPham_I",
                principalTable: "ChiTietSanPham_DangI",
                principalColumn: "MaSanPham_I",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPham_DangI_DonViHanhChinh_MaDonViHC",
                table: "ChiTietSanPham_DangI");

            migrationBuilder.DropForeignKey(
                name: "FK_DacTinhKyThuat_ChiTietSanPham_DangI_MaSanPham_I",
                table: "DacTinhKyThuat");

            migrationBuilder.DropColumn(
                name: "LoaiSanPham_III",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "TenSanPham_III",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "file_SanPham_III",
                table: "ChiTietSanPham_DangIII");

            migrationBuilder.DropColumn(
                name: "LoaiSanPham_II",
                table: "ChiTietSanPham_DangII");

            migrationBuilder.DropColumn(
                name: "TenSanPham_II",
                table: "ChiTietSanPham_DangII");

            migrationBuilder.DropColumn(
                name: "TenSanPham_I",
                table: "ChiTietSanPham_DangI");

            migrationBuilder.DropColumn(
                name: "file_SanPham_I",
                table: "ChiTietSanPham_DangI");

            migrationBuilder.RenameColumn(
                name: "ThongSo",
                table: "DacTinhKyThuat",
                newName: "TenDacTinh");

            migrationBuilder.RenameColumn(
                name: "MaSanPham_I",
                table: "DacTinhKyThuat",
                newName: "MaSanPham");

            migrationBuilder.RenameColumn(
                name: "DonViDo",
                table: "DacTinhKyThuat",
                newName: "DonVi");

            migrationBuilder.RenameColumn(
                name: "ChiChu",
                table: "DacTinhKyThuat",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "MaDacTinhKyThuat",
                table: "DacTinhKyThuat",
                newName: "MaDacTinh");

            migrationBuilder.RenameIndex(
                name: "IX_DacTinhKyThuat_MaSanPham_I",
                table: "DacTinhKyThuat",
                newName: "IX_DacTinhKyThuat_MaSanPham");

            migrationBuilder.RenameColumn(
                name: "NoiCongBo",
                table: "ChiTietSanPham_DangIII",
                newName: "TieuDe");

            migrationBuilder.RenameColumn(
                name: "MaSanPham_III",
                table: "ChiTietSanPham_DangIII",
                newName: "MaBaiBao");

            migrationBuilder.RenameColumn(
                name: "file_SanPham_II",
                table: "ChiTietSanPham_DangII",
                newName: "FileBaoCao");

            migrationBuilder.RenameColumn(
                name: "MaSanPham_II",
                table: "ChiTietSanPham_DangII",
                newName: "MaBaoCao");

            migrationBuilder.RenameColumn(
                name: "MaSanPham_I",
                table: "ChiTietSanPham_DangI",
                newName: "MaSanPham");

            migrationBuilder.AlterColumn<string>(
                name: "GiaTri",
                table: "DacTinhKyThuat",
                type: "VARCHAR(255)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(10,6)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DOI",
                table: "ChiTietSanPham_DangIII",
                type: "VARCHAR(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISSN",
                table: "ChiTietSanPham_DangIII",
                type: "VARCHAR(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiBaiBao",
                table: "ChiTietSanPham_DangIII",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nam",
                table: "ChiTietSanPham_DangIII",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXuatBan",
                table: "ChiTietSanPham_DangIII",
                type: "DATE",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "So",
                table: "ChiTietSanPham_DangIII",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TacGia",
                table: "ChiTietSanPham_DangIII",
                type: "VARCHAR(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenTapChi",
                table: "ChiTietSanPham_DangIII",
                type: "VARCHAR(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TomTat",
                table: "ChiTietSanPham_DangIII",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Trang",
                table: "ChiTietSanPham_DangIII",
                type: "VARCHAR(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ChiTietSanPham_DangIII",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiBaoCao",
                table: "ChiTietSanPham_DangII",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "ChiTietSanPham_DangII",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayHoanThanh",
                table: "ChiTietSanPham_DangII",
                type: "DATE",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenBaoCao",
                table: "ChiTietSanPham_DangII",
                type: "VARCHAR(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TomTatNoiDung",
                table: "ChiTietSanPham_DangII",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ChiTietSanPham_DangII",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaDonViHC",
                table: "ChiTietSanPham_DangI",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DonViTinh",
                table: "ChiTietSanPham_DangI",
                type: "VARCHAR(50)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaTri",
                table: "ChiTietSanPham_DangI",
                type: "DECIMAL(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "ChiTietSanPham_DangI",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayHoanThanh",
                table: "ChiTietSanPham_DangI",
                type: "DATE",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "ChiTietSanPham_DangI",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenSanPham",
                table: "ChiTietSanPham_DangI",
                type: "VARCHAR(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ChiTietSanPham_DangI",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPham_DangI_DonViHanhChinh_MaDonViHC",
                table: "ChiTietSanPham_DangI",
                column: "MaDonViHC",
                principalTable: "DonViHanhChinh",
                principalColumn: "MaDonViHC",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DacTinhKyThuat_ChiTietSanPham_DangI_MaSanPham",
                table: "DacTinhKyThuat",
                column: "MaSanPham",
                principalTable: "ChiTietSanPham_DangI",
                principalColumn: "MaSanPham",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
