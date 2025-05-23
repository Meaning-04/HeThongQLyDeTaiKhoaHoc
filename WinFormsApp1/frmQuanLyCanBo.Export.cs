using Microsoft.EntityFrameworkCore;
using Models.HandleData;
using Models.Models;
using WinFormsApp1.Constants;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace WinFormsApp1
{
    public partial class frmQuanLyCanBo
    {
        private async void ExportSelectedRecordToExcel(string filePath, int maCanBo)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Chi tiết cán bộ");

                // Tiêu đề
                worksheet.Cell(1, 1).Value = "BÁO CÁO CHI TIẾT CÁN BỘ";
                worksheet.Range(1, 1, 1, 4).Merge().Style.Font.Bold = true;
                worksheet.Range(1, 1, 1, 4).Style.Font.FontSize = 16;
                worksheet.Range(1, 1, 1, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Thông tin xuất
                worksheet.Cell(2, 1).Value = $"Mã cán bộ: CB{maCanBo:D6}";
                worksheet.Cell(3, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                worksheet.Cell(4, 1).Value = $"Người xuất: {currentUser.TenDangNhap}";

                int currentRow = 6;

                // Lấy thông tin cán bộ từ database
                using (var context = new DAContext())
                {
                    var canBo = await context.CanBo.FindAsync(maCanBo);
                    if (canBo != null)
                    {
                        // Thông tin cán bộ
                        worksheet.Cell(currentRow, 1).Value = "THÔNG TIN CÁN BỘ";
                        worksheet.Range(currentRow, 1, currentRow, 4).Merge().Style.Font.Bold = true;
                        worksheet.Range(currentRow, 1, currentRow, 4).Style.Font.FontSize = 14;
                        currentRow += 2;

                        // Thông tin chi tiết
                        var staffInfo = new[]
                        {
                            new { Label = "Mã cán bộ:", Value = $"CB{canBo.MaCanBo:D6}" },
                            new { Label = "Họ và tên:", Value = canBo.HoTen ?? "" },
                            new { Label = "Chức vụ:", Value = canBo.ChucVu ?? "" },
                            new { Label = "Quân hàm:", Value = canBo.QuanHam ?? "" },
                            new { Label = "Ngày sinh:", Value = canBo.NgaySinh?.ToString("dd/MM/yyyy") ?? "" },
                            new { Label = "Giới tính:", Value = canBo.GioiTinh == GioiTinh.Nam ? "Nam" : "Nữ" },
                            new { Label = "Học vị:", Value = canBo.HocVi ?? "" },
                            new { Label = "Năm nhận học vị:", Value = canBo.Nam_HocVi?.ToString() ?? "" },
                            new { Label = "Học hàm:", Value = canBo.HocHam ?? "" },
                            new { Label = "Năm nhận học hàm:", Value = canBo.Nam_HocHam?.ToString() ?? "" },
                            new { Label = "Chức danh CMKTNV:", Value = canBo.ChucDanhCMKTNV ?? "" },
                            new { Label = "Năm phong chức danh:", Value = canBo.Nam_PhongChucDanh?.ToString() ?? "" },
                            new { Label = "Chuyên ngành:", Value = canBo.ChuyenNganh ?? "" },
                            new { Label = "Điện thoại:", Value = canBo.DienThoai ?? "" },
                            new { Label = "Email:", Value = canBo.Email ?? "" },
                            new { Label = "Địa chỉ:", Value = canBo.DiaChi ?? "" },
                            new { Label = "Phòng ban:", Value = canBo.PhongBan ?? "" }
                        };

                        foreach (var info in staffInfo)
                        {
                            worksheet.Cell(currentRow, 1).Value = info.Label;
                            worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                            worksheet.Cell(currentRow, 2).Value = info.Value;
                            currentRow++;
                        }

                        currentRow += 2;

                        // Danh sách đề tài tham gia
                        var projects = await context.VaiTroThamGia
                            .Where(vt => vt.MaCanBo == maCanBo)
                            .Include(vt => vt.DeTai)
                            .ToListAsync();

                        if (projects.Any())
                        {
                            worksheet.Cell(currentRow, 1).Value = "DANH SÁCH ĐỀ TÀI THAM GIA";
                            worksheet.Range(currentRow, 1, currentRow, 4).Merge().Style.Font.Bold = true;
                            worksheet.Range(currentRow, 1, currentRow, 4).Style.Font.FontSize = 14;
                            currentRow += 2;

                            // Header
                            worksheet.Cell(currentRow, 1).Value = "STT";
                            worksheet.Cell(currentRow, 2).Value = "Mã đề tài";
                            worksheet.Cell(currentRow, 3).Value = "Tên đề tài";
                            worksheet.Cell(currentRow, 4).Value = "Vai trò";
                            worksheet.Range(currentRow, 1, currentRow, 4).Style.Font.Bold = true;
                            worksheet.Range(currentRow, 1, currentRow, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            worksheet.Range(currentRow, 1, currentRow, 4).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                            currentRow++;

                            // Data
                            int stt = 1;
                            foreach (var project in projects)
                            {
                                worksheet.Cell(currentRow, 1).Value = stt++;
                                worksheet.Cell(currentRow, 2).Value = $"DT{project.MaDeTai:D6}";
                                worksheet.Cell(currentRow, 3).Value = project.DeTai?.TenDeTai ?? "";
                                worksheet.Cell(currentRow, 4).Value = project.VaiTro == VaiTroThamGiaEnum.ChuNhiem ? "Chủ nhiệm" : "Tham gia";
                                worksheet.Range(currentRow, 1, currentRow, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                worksheet.Range(currentRow, 1, currentRow, 4).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                                currentRow++;
                            }
                        }
                        else
                        {
                            worksheet.Cell(currentRow, 1).Value = "DANH SÁCH ĐỀ TÀI THAM GIA";
                            worksheet.Range(currentRow, 1, currentRow, 4).Merge().Style.Font.Bold = true;
                            worksheet.Range(currentRow, 1, currentRow, 4).Style.Font.FontSize = 14;
                            currentRow += 2;
                            worksheet.Cell(currentRow, 1).Value = "Cán bộ này chưa tham gia đề tài nào.";
                            worksheet.Range(currentRow, 1, currentRow, 4).Merge().Style.Font.Italic = true;
                        }
                    }
                }

                // Auto fit columns
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }

        private async void ExportAllRecordsToExcel(string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Danh sách cán bộ");

                // Tiêu đề
                worksheet.Cell(1, 1).Value = "DANH SÁCH CÁN BỘ";
                worksheet.Range(1, 1, 1, 9).Merge().Style.Font.Bold = true;
                worksheet.Range(1, 1, 1, 9).Style.Font.FontSize = 16;
                worksheet.Range(1, 1, 1, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Thông tin xuất
                worksheet.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                worksheet.Cell(3, 1).Value = $"Người xuất: {currentUser.TenDangNhap}";
                worksheet.Cell(4, 1).Value = $"Tổng số: {dgvCanBo.Rows.Count} cán bộ";

                int headerRow = 6;

                // Header
                var headers = new[] { "STT", "Mã CB", "Họ và tên", "Chức vụ", "Học vị", "Học hàm", "Chuyên ngành", "Điện thoại", "Email", "Phòng ban" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cell(headerRow, i + 1).Value = headers[i];
                    worksheet.Cell(headerRow, i + 1).Style.Font.Bold = true;
                    worksheet.Cell(headerRow, i + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                int currentRow = headerRow + 1;

                // Data rows
                for (int i = 0; i < dgvCanBo.Rows.Count; i++)
                {
                    var row = dgvCanBo.Rows[i];
                    worksheet.Cell(currentRow, 1).Value = i + 1;
                    worksheet.Cell(currentRow, 2).Value = row.Cells["MaCanBo"].Value?.ToString() ?? "";
                    worksheet.Cell(currentRow, 3).Value = row.Cells["HoTen"].Value?.ToString() ?? "";
                    worksheet.Cell(currentRow, 4).Value = row.Cells["ChucVu"].Value?.ToString() ?? "";
                    worksheet.Cell(currentRow, 5).Value = row.Cells["HocVi"].Value?.ToString() ?? "";
                    worksheet.Cell(currentRow, 6).Value = row.Cells["HocHam"].Value?.ToString() ?? "";
                    worksheet.Cell(currentRow, 7).Value = row.Cells["ChuyenNganh"].Value?.ToString() ?? "";
                    worksheet.Cell(currentRow, 8).Value = row.Cells["DienThoai"].Value?.ToString() ?? "";
                    worksheet.Cell(currentRow, 9).Value = row.Cells["Email"].Value?.ToString() ?? "";
                    worksheet.Cell(currentRow, 10).Value = row.Cells["PhongBan"].Value?.ToString() ?? "";

                    // Style data row
                    worksheet.Range(currentRow, 1, currentRow, 10).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Range(currentRow, 1, currentRow, 10).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    currentRow++;
                }

                // Auto fit columns
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }
    }
}
