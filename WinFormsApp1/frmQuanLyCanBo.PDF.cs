using Microsoft.EntityFrameworkCore;
using Models.HandleData;
using Models.Models;
using WinFormsApp1.Constants;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.IO.Font;

namespace WinFormsApp1
{
    public partial class frmQuanLyCanBo
    {
        private async void ExportSelectedRecordToPDF(string filePath, int maCanBo)
        {
            using (var writer = new PdfWriter(filePath))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);

                    // Set font - Use fonts that support Vietnamese characters
                    PdfFont font;
                    PdfFont boldFont;
                    PdfFont italicFont;

                    try
                    {
                        // Try to use system fonts that support Vietnamese
                        font = PdfFontFactory.CreateFont("c:/windows/fonts/arial.ttf", PdfEncodings.IDENTITY_H);
                        boldFont = PdfFontFactory.CreateFont("c:/windows/fonts/arialbd.ttf", PdfEncodings.IDENTITY_H);
                        italicFont = PdfFontFactory.CreateFont("c:/windows/fonts/ariali.ttf", PdfEncodings.IDENTITY_H);
                    }
                    catch
                    {
                        // Fallback to embedded fonts if system fonts are not available
                        font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA, PdfEncodings.IDENTITY_H);
                        boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD, PdfEncodings.IDENTITY_H);
                        italicFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE, PdfEncodings.IDENTITY_H);
                    }

                    // Tiêu đề chính
                    var title = new Paragraph("BÁO CÁO CHI TIẾT CÁN BỘ")
                        .SetFont(boldFont)
                        .SetFontSize(18)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetMarginBottom(20);
                    document.Add(title);

                    // Thông tin xuất
                    document.Add(new Paragraph($"Mã cán bộ: CB{maCanBo:D6}")
                        .SetFont(boldFont)
                        .SetFontSize(12));
                    document.Add(new Paragraph($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                        .SetFont(font)
                        .SetFontSize(10));
                    document.Add(new Paragraph($"Người xuất: {currentUser.TenDangNhap}")
                        .SetFont(font)
                        .SetFontSize(10)
                        .SetMarginBottom(20));

                    // Lấy thông tin cán bộ từ database
                    using (var context = new DAContext())
                    {
                        var canBo = await context.CanBo.FindAsync(maCanBo);
                        if (canBo != null)
                        {
                            // Thông tin cán bộ
                            document.Add(new Paragraph("I. THÔNG TIN CÁN BỘ")
                                .SetFont(boldFont)
                                .SetFontSize(14)
                                .SetMarginBottom(10));

                            // Tạo bảng thông tin cán bộ
                            var infoTable = new Table(2).UseAllAvailableWidth();
                            infoTable.SetBorder(new iText.Layout.Borders.SolidBorder(1));

                            // Thông tin chi tiết
                            var staffInfo = new[]
                            {
                                new { Label = "Mã cán bộ", Value = $"CB{canBo.MaCanBo:D6}" },
                                new { Label = "Họ và tên", Value = canBo.HoTen ?? "" },
                                new { Label = "Chức vụ", Value = canBo.ChucVu ?? "" },
                                new { Label = "Quân hàm", Value = canBo.QuanHam ?? "" },
                                new { Label = "Ngày sinh", Value = canBo.NgaySinh?.ToString("dd/MM/yyyy") ?? "" },
                                new { Label = "Giới tính", Value = canBo.GioiTinh == GioiTinh.Nam ? "Nam" : "Nữ" },
                                new { Label = "Học vị", Value = canBo.HocVi ?? "" },
                                new { Label = "Năm nhận học vị", Value = canBo.Nam_HocVi?.ToString() ?? "" },
                                new { Label = "Học hàm", Value = canBo.HocHam ?? "" },
                                new { Label = "Năm nhận học hàm", Value = canBo.Nam_HocHam?.ToString() ?? "" },
                                new { Label = "Chức danh CMKTNV", Value = canBo.ChucDanhCMKTNV ?? "" },
                                new { Label = "Năm phong chức danh", Value = canBo.Nam_PhongChucDanh?.ToString() ?? "" },
                                new { Label = "Chuyên ngành", Value = canBo.ChuyenNganh ?? "" },
                                new { Label = "Điện thoại", Value = canBo.DienThoai ?? "" },
                                new { Label = "Email", Value = canBo.Email ?? "" },
                                new { Label = "Địa chỉ", Value = canBo.DiaChi ?? "" },
                                new { Label = "Phòng ban", Value = canBo.PhongBan ?? "" }
                            };

                            foreach (var info in staffInfo)
                            {
                                infoTable.AddCell(new Cell()
                                    .Add(new Paragraph(info.Label).SetFont(boldFont).SetFontSize(10))
                                    .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                                    .SetPadding(5));
                                infoTable.AddCell(new Cell()
                                    .Add(new Paragraph(info.Value).SetFont(font).SetFontSize(10))
                                    .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                                    .SetPadding(5));
                            }

                            document.Add(infoTable);
                            document.Add(new Paragraph("\n"));

                            // Danh sách đề tài tham gia
                            document.Add(new Paragraph("II. DANH SÁCH ĐỀ TÀI THAM GIA")
                                .SetFont(boldFont)
                                .SetFontSize(14)
                                .SetMarginBottom(10));

                            var projects = await context.VaiTroThamGia
                                .Where(vt => vt.MaCanBo == maCanBo)
                                .Include(vt => vt.DeTai)
                                .ToListAsync();

                            if (projects.Any())
                            {
                                // Tạo bảng đề tài
                                var projectTable = new Table(4).UseAllAvailableWidth();
                                projectTable.SetBorder(new iText.Layout.Borders.SolidBorder(1));

                                // Header row
                                projectTable.AddHeaderCell(new Cell()
                                    .Add(new Paragraph("STT").SetFont(boldFont).SetFontSize(10))
                                    .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                                    .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY)
                                    .SetPadding(5)
                                    .SetTextAlignment(TextAlignment.CENTER));
                                projectTable.AddHeaderCell(new Cell()
                                    .Add(new Paragraph("Mã đề tài").SetFont(boldFont).SetFontSize(10))
                                    .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                                    .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY)
                                    .SetPadding(5)
                                    .SetTextAlignment(TextAlignment.CENTER));
                                projectTable.AddHeaderCell(new Cell()
                                    .Add(new Paragraph("Tên đề tài").SetFont(boldFont).SetFontSize(10))
                                    .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                                    .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY)
                                    .SetPadding(5)
                                    .SetTextAlignment(TextAlignment.CENTER));
                                projectTable.AddHeaderCell(new Cell()
                                    .Add(new Paragraph("Vai trò").SetFont(boldFont).SetFontSize(10))
                                    .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                                    .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY)
                                    .SetPadding(5)
                                    .SetTextAlignment(TextAlignment.CENTER));

                                // Data rows
                                int stt = 1;
                                foreach (var project in projects)
                                {
                                    projectTable.AddCell(new Cell()
                                        .Add(new Paragraph(stt.ToString()).SetFont(font).SetFontSize(10))
                                        .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                                        .SetPadding(5)
                                        .SetTextAlignment(TextAlignment.CENTER));
                                    projectTable.AddCell(new Cell()
                                        .Add(new Paragraph($"DT{project.MaDeTai:D6}").SetFont(font).SetFontSize(10))
                                        .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                                        .SetPadding(5));
                                    projectTable.AddCell(new Cell()
                                        .Add(new Paragraph(project.DeTai?.TenDeTai ?? "").SetFont(font).SetFontSize(10))
                                        .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                                        .SetPadding(5));
                                    projectTable.AddCell(new Cell()
                                        .Add(new Paragraph(project.VaiTro == VaiTroThamGiaEnum.ChuNhiem ? "Chủ nhiệm" : "Tham gia").SetFont(font).SetFontSize(10))
                                        .SetBorder(new iText.Layout.Borders.SolidBorder(1))
                                        .SetPadding(5)
                                        .SetTextAlignment(TextAlignment.CENTER));
                                    stt++;
                                }

                                document.Add(projectTable);
                            }
                            else
                            {
                                document.Add(new Paragraph("Cán bộ này chưa tham gia đề tài nào.")
                                    .SetFont(italicFont)
                                    .SetFontSize(10)
                                    .SetFontColor(iText.Kernel.Colors.ColorConstants.GRAY));
                            }
                        }
                    }

                    document.Close();
                }
            }
        }
    }
}
