# 🏢 Dự Án Quản Lý Đề Tài - WinForms Application

Ứng dụng WinForms để quản lý đề tài nghiên cứu, cán bộ, và các sản phẩm liên quan.

## 🚀 Setup Nhanh

### Cách 1: Sử dụng Script Tự Động (Khuyến nghị)

```bash
# Chạy script batch
./setup.bat

# Hoặc chạy script PowerShell
./setup.ps1
```

### Cách 2: Setup Thủ Công

```bash
# 1. Restore dependencies
dotnet restore WinFormsApp1.sln

# 2. Tạo database
sqlcmd -S .\sqlexpress -E -Q "CREATE DATABASE Tung_DB"

# 3. Chạy migration
cd Models
dotnet ef database update --startup-project ../WinFormsApp1
cd ..

# 4. Build và chạy
dotnet build WinFormsApp1.sln
dotnet run --project WinFormsApp1/WinFormsApp1.csproj
```

## 📋 Yêu Cầu Hệ Thống

- **.NET 8.0 SDK**
- **SQL Server Express** hoặc **LocalDB**
- **Windows OS** (cho WinForms)

## 📁 Cấu Trúc Dự Án

```
├── WinFormsApp1/          # Main Application
├── Models/                # Entity Framework Models
├── DbHelper/              # Database Utilities
├── setup.bat              # Auto Setup Script (Batch)
├── setup.ps1              # Auto Setup Script (PowerShell)
└── huongDanSetUp.md       # Hướng dẫn chi tiết
```

## 🔧 Cấu Hình

**Connection String mặc định:**
```
Server=.\sqlexpress;Database=Tung_DB;Trusted_Connection=True;TrustServerCertificate=True
```

## 📚 Tài Liệu

- **[huongDanSetUp.md](huongDanSetUp.md)** - Hướng dẫn setup chi tiết
- **[MoTaDuAn.md](MoTaDuAn.md)** - Mô tả dự án
- **[ThietKeCSDL.md](ThietKeCSDL.md)** - Thiết kế cơ sở dữ liệu

## 🛠️ Troubleshooting

Nếu gặp lỗi, hãy thử:

```bash
# Clean và rebuild
dotnet clean WinFormsApp1.sln
dotnet restore WinFormsApp1.sln
dotnet build WinFormsApp1.sln

# Hoặc xem log chi tiết
dotnet build WinFormsApp1.sln --verbosity detailed
```

## 📞 Hỗ Trợ

Xem file `huongDanSetUp.md` để biết thêm chi tiết về troubleshooting và cấu hình nâng cao.
