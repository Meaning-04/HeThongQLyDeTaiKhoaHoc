using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CanBo",
                columns: table => new
                {
                    MaCanBo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    ChucVu = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    QuanHam = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "DATE", nullable: true),
                    GioiTinh = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    HocVi = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Nam_HocVi = table.Column<int>(type: "INT", nullable: true),
                    HocHam = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Nam_HocHam = table.Column<int>(type: "INT", nullable: true),
                    ChucDanhCMKTNV = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Nam_PhongChucDanh = table.Column<int>(type: "INT", nullable: true),
                    ChuyenNganh = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    DienThoai = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    DiaChi = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    PhongBan = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    File_LyLich = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanBo", x => x.MaCanBo);
                });

            migrationBuilder.CreateTable(
                name: "DeTai",
                columns: table => new
                {
                    MaDeTai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDeTai = table.Column<string>(type: "TEXT", nullable: true),
                    MoTaTomTat = table.Column<string>(type: "TEXT", nullable: true),
                    LinhVuc = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    ThoiGianBatDau = table.Column<DateTime>(type: "DATE", nullable: true),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "DATE", nullable: true),
                    CapQuanLy = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeTai", x => x.MaDeTai);
                });

            migrationBuilder.CreateTable(
                name: "DonViHanhChinh",
                columns: table => new
                {
                    MaDonViHC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TinhThanh = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViHanhChinh", x => x.MaDonViHC);
                });

            migrationBuilder.CreateTable(
                name: "DonViPhoiHop",
                columns: table => new
                {
                    MaDonVi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDonVi = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    DiaChi = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViPhoiHop", x => x.MaDonVi);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    MatKhau = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    VaiTro = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    MaCanBo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.MaTaiKhoan);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_CanBo_MaCanBo",
                        column: x => x.MaCanBo,
                        principalTable: "CanBo",
                        principalColumn: "MaCanBo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSanPham_DangII",
                columns: table => new
                {
                    MaBaoCao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDeTai = table.Column<int>(type: "int", nullable: false),
                    TenBaoCao = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    LoaiBaoCao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    MoTa = table.Column<string>(type: "TEXT", nullable: true),
                    NgayHoanThanh = table.Column<DateTime>(type: "DATE", nullable: true),
                    TrangThai = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    FileBaoCao = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true),
                    TomTatNoiDung = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPham_DangII", x => x.MaBaoCao);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_DangII_DeTai_MaDeTai",
                        column: x => x.MaDeTai,
                        principalTable: "DeTai",
                        principalColumn: "MaDeTai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSanPham_DangIII",
                columns: table => new
                {
                    MaBaiBao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDeTai = table.Column<int>(type: "int", nullable: false),
                    TieuDe = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    TacGia = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    TenTapChi = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    ISSN = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Nam = table.Column<int>(type: "INT", nullable: true),
                    So = table.Column<int>(type: "INT", nullable: true),
                    Trang = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    DOI = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    LoaiBaiBao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    TrangThai = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    NgayXuatBan = table.Column<DateTime>(type: "DATE", nullable: true),
                    TomTat = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPham_DangIII", x => x.MaBaiBao);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_DangIII_DeTai_MaDeTai",
                        column: x => x.MaDeTai,
                        principalTable: "DeTai",
                        principalColumn: "MaDeTai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KinhPhi",
                columns: table => new
                {
                    MaKinhPhi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDeTai = table.Column<int>(type: "int", nullable: false),
                    NganSach = table.Column<long>(type: "BIGINT", nullable: true),
                    Khac = table.Column<long>(type: "BIGINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KinhPhi", x => x.MaKinhPhi);
                    table.ForeignKey(
                        name: "FK_KinhPhi_DeTai_MaDeTai",
                        column: x => x.MaDeTai,
                        principalTable: "DeTai",
                        principalColumn: "MaDeTai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaiTroThamGia",
                columns: table => new
                {
                    MaDeTai = table.Column<int>(type: "int", nullable: false),
                    MaCanBo = table.Column<int>(type: "int", nullable: false),
                    VaiTro = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTroThamGia", x => new { x.MaDeTai, x.MaCanBo });
                    table.ForeignKey(
                        name: "FK_VaiTroThamGia_CanBo_MaCanBo",
                        column: x => x.MaCanBo,
                        principalTable: "CanBo",
                        principalColumn: "MaCanBo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaiTroThamGia_DeTai_MaDeTai",
                        column: x => x.MaDeTai,
                        principalTable: "DeTai",
                        principalColumn: "MaDeTai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSanPham_DangI",
                columns: table => new
                {
                    MaSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDeTai = table.Column<int>(type: "int", nullable: false),
                    TenSanPham = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    MoTa = table.Column<string>(type: "TEXT", nullable: true),
                    DonViTinh = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    SoLuong = table.Column<int>(type: "INT", nullable: true),
                    GiaTri = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: true),
                    NgayHoanThanh = table.Column<DateTime>(type: "DATE", nullable: true),
                    TrangThai = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    MaDonViHC = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPham_DangI", x => x.MaSanPham);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_DangI_DeTai_MaDeTai",
                        column: x => x.MaDeTai,
                        principalTable: "DeTai",
                        principalColumn: "MaDeTai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_DangI_DonViHanhChinh_MaDonViHC",
                        column: x => x.MaDonViHC,
                        principalTable: "DonViHanhChinh",
                        principalColumn: "MaDonViHC",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DeTai_DonVi",
                columns: table => new
                {
                    MaDeTai = table.Column<int>(type: "int", nullable: false),
                    MaDonVi = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeTai_DonVi", x => new { x.MaDeTai, x.MaDonVi });
                    table.ForeignKey(
                        name: "FK_DeTai_DonVi_DeTai_MaDeTai",
                        column: x => x.MaDeTai,
                        principalTable: "DeTai",
                        principalColumn: "MaDeTai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeTai_DonVi_DonViPhoiHop_MaDonVi",
                        column: x => x.MaDonVi,
                        principalTable: "DonViPhoiHop",
                        principalColumn: "MaDonVi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DacTinhKyThuat",
                columns: table => new
                {
                    MaDacTinh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    TenDacTinh = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    GiaTri = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    DonVi = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    MoTa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DacTinhKyThuat", x => x.MaDacTinh);
                    table.ForeignKey(
                        name: "FK_DacTinhKyThuat_ChiTietSanPham_DangI_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "ChiTietSanPham_DangI",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_DangI_MaDeTai",
                table: "ChiTietSanPham_DangI",
                column: "MaDeTai");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_DangI_MaDonViHC",
                table: "ChiTietSanPham_DangI",
                column: "MaDonViHC");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_DangII_MaDeTai",
                table: "ChiTietSanPham_DangII",
                column: "MaDeTai");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_DangIII_MaDeTai",
                table: "ChiTietSanPham_DangIII",
                column: "MaDeTai");

            migrationBuilder.CreateIndex(
                name: "IX_DacTinhKyThuat_MaSanPham",
                table: "DacTinhKyThuat",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DeTai_DonVi_MaDonVi",
                table: "DeTai_DonVi",
                column: "MaDonVi");

            migrationBuilder.CreateIndex(
                name: "IX_KinhPhi_MaDeTai",
                table: "KinhPhi",
                column: "MaDeTai");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_MaCanBo",
                table: "TaiKhoan",
                column: "MaCanBo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_TenDangNhap",
                table: "TaiKhoan",
                column: "TenDangNhap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaiTroThamGia_MaCanBo",
                table: "VaiTroThamGia",
                column: "MaCanBo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietSanPham_DangII");

            migrationBuilder.DropTable(
                name: "ChiTietSanPham_DangIII");

            migrationBuilder.DropTable(
                name: "DacTinhKyThuat");

            migrationBuilder.DropTable(
                name: "DeTai_DonVi");

            migrationBuilder.DropTable(
                name: "KinhPhi");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "VaiTroThamGia");

            migrationBuilder.DropTable(
                name: "ChiTietSanPham_DangI");

            migrationBuilder.DropTable(
                name: "DonViPhoiHop");

            migrationBuilder.DropTable(
                name: "CanBo");

            migrationBuilder.DropTable(
                name: "DeTai");

            migrationBuilder.DropTable(
                name: "DonViHanhChinh");
        }
    }
}
