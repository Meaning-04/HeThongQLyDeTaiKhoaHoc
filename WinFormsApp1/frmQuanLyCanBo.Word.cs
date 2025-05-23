using Microsoft.EntityFrameworkCore;
using Models.HandleData;
using Models.Models;
using WinFormsApp1.Constants;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;

namespace WinFormsApp1
{
    public partial class frmQuanLyCanBo
    {
        private async void ExportSelectedRecordToWord(string filePath, int maCanBo)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Tiêu đề chính
                AddHeading(body, "BÁO CÁO CHI TIẾT CÁN BỘ", 1);
                AddParagraph(body, $"Mã cán bộ: CB{maCanBo:D6}", true);
                AddParagraph(body, $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                AddParagraph(body, $"Người xuất: {currentUser.TenDangNhap}");
                AddParagraph(body, ""); // Dòng trống

                // Lấy thông tin cán bộ từ database
                using (var context = new DAContext())
                {
                    var canBo = await context.CanBo.FindAsync(maCanBo);
                    if (canBo != null)
                    {
                        // Thông tin cán bộ
                        AddHeading(body, "I. THÔNG TIN CÁN BỘ", 2);

                        // Tạo bảng thông tin cán bộ
                        Table infoTable = new Table();

                        // Table properties
                        TableProperties tableProps = new TableProperties(
                            new TableBorders(
                                new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                                new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                                new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                                new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                                new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                                new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 }
                            )
                        );
                        infoTable.AppendChild(tableProps);

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
                            TableRow row = new TableRow();
                            row.Append(CreateTableCell(info.Label, true));
                            row.Append(CreateTableCell(info.Value));
                            infoTable.Append(row);
                        }

                        body.Append(infoTable);
                        AddParagraph(body, ""); // Dòng trống

                        // Danh sách đề tài tham gia
                        AddHeading(body, "II. DANH SÁCH ĐỀ TÀI THAM GIA", 2);

                        var projects = await context.VaiTroThamGia
                            .Where(vt => vt.MaCanBo == maCanBo)
                            .Include(vt => vt.DeTai)
                            .ToListAsync();

                        if (projects.Any())
                        {
                            // Tạo bảng đề tài
                            Table projectTable = new Table();
                            projectTable.AppendChild(tableProps.CloneNode(true));

                            // Header row
                            TableRow headerRow = new TableRow();
                            headerRow.Append(CreateTableCell("STT", true));
                            headerRow.Append(CreateTableCell("Mã đề tài", true));
                            headerRow.Append(CreateTableCell("Tên đề tài", true));
                            headerRow.Append(CreateTableCell("Vai trò", true));
                            projectTable.Append(headerRow);

                            // Data rows
                            int stt = 1;
                            foreach (var project in projects)
                            {
                                TableRow dataRow = new TableRow();
                                dataRow.Append(CreateTableCell(stt.ToString()));
                                dataRow.Append(CreateTableCell($"DT{project.MaDeTai:D6}"));
                                dataRow.Append(CreateTableCell(project.DeTai?.TenDeTai ?? ""));
                                dataRow.Append(CreateTableCell(project.VaiTro == VaiTroThamGiaEnum.ChuNhiem ? "Chủ nhiệm" : "Tham gia"));
                                projectTable.Append(dataRow);
                                stt++;
                            }

                            body.Append(projectTable);
                        }
                        else
                        {
                            AddParagraph(body, "Cán bộ này chưa tham gia đề tài nào.", false, true);
                        }
                    }
                }

                mainPart.Document.Save();
            }
        }

        private void ExportAllRecordsToWord(string filePath)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Tiêu đề chính
                AddHeading(body, "DANH SÁCH CÁN BỘ", 1);
                AddParagraph(body, $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                AddParagraph(body, $"Người xuất: {currentUser.TenDangNhap}");
                AddParagraph(body, $"Tổng số: {dgvCanBo.Rows.Count} cán bộ");
                AddParagraph(body, ""); // Dòng trống

                // Tạo bảng
                Table table = new Table();

                // Table properties
                TableProperties tableProps = new TableProperties(
                    new TableBorders(
                        new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                        new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 }
                    )
                );
                table.AppendChild(tableProps);

                // Header row
                TableRow headerRow = new TableRow();
                headerRow.Append(CreateTableCell("STT", true));
                headerRow.Append(CreateTableCell("Mã CB", true));
                headerRow.Append(CreateTableCell("Họ và tên", true));
                headerRow.Append(CreateTableCell("Chức vụ", true));
                headerRow.Append(CreateTableCell("Học vị", true));
                headerRow.Append(CreateTableCell("Học hàm", true));
                headerRow.Append(CreateTableCell("Chuyên ngành", true));
                headerRow.Append(CreateTableCell("Điện thoại", true));
                headerRow.Append(CreateTableCell("Email", true));
                headerRow.Append(CreateTableCell("Phòng ban", true));
                table.Append(headerRow);

                // Data rows
                for (int i = 0; i < dgvCanBo.Rows.Count; i++)
                {
                    var row = dgvCanBo.Rows[i];
                    TableRow dataRow = new TableRow();
                    dataRow.Append(CreateTableCell((i + 1).ToString()));
                    dataRow.Append(CreateTableCell(row.Cells["MaCanBo"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["HoTen"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["ChucVu"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["HocVi"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["HocHam"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["ChuyenNganh"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["DienThoai"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["Email"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["PhongBan"].Value?.ToString() ?? ""));
                    table.Append(dataRow);
                }

                body.Append(table);
                mainPart.Document.Save();
            }
        }

        // Helper methods for Word document creation
        private void AddHeading(Body body, string text, int level)
        {
            Paragraph heading = new Paragraph();
            ParagraphProperties paragraphProps = new ParagraphProperties();

            if (level == 1)
            {
                paragraphProps.Append(new Justification() { Val = JustificationValues.Center });
            }

            heading.Append(paragraphProps);

            Run run = new Run();
            RunProperties runProps = new RunProperties();
            runProps.Append(new Bold());
            runProps.Append(new FontSize() { Val = level == 1 ? "28" : "24" });
            run.Append(runProps);
            run.Append(new Text(text));
            heading.Append(run);
            body.Append(heading);
        }

        private void AddParagraph(Body body, string text, bool bold = false, bool italic = false)
        {
            Paragraph paragraph = new Paragraph();
            Run run = new Run();

            if (bold || italic)
            {
                RunProperties runProps = new RunProperties();
                if (bold) runProps.Append(new Bold());
                if (italic) runProps.Append(new Italic());
                run.Append(runProps);
            }

            run.Append(new Text(text));
            paragraph.Append(run);
            body.Append(paragraph);
        }

        private TableCell CreateTableCell(string text, bool bold = false)
        {
            TableCell cell = new TableCell();
            Paragraph paragraph = new Paragraph();
            Run run = new Run();

            if (bold)
            {
                RunProperties runProps = new RunProperties();
                runProps.Append(new Bold());
                run.Append(runProps);
            }

            run.Append(new Text(text));
            paragraph.Append(run);
            cell.Append(paragraph);
            return cell;
        }
    }
}
