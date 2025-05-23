# Hướng Dẫn Setup Dự Án WinForms - Quản Lý Đề Tài

## 📋 Yêu Cầu Hệ Thống

### Phần Mềm Cần Thiết:
- **.NET 8.0 SDK** hoặc cao hơn
- **SQL Server** (SQL Server Express, LocalDB, hoặc SQL Server đầy đủ)
- **Git** (để clone repository)
- **Command Prompt** hoặc **PowerShell**

### Kiểm Tra Yêu Cầu:
```bash
# Kiểm tra .NET SDK
dotnet --version

# Kiểm tra Git
git --version

# Kiểm tra SQL Server (nếu dùng sqlcmd)
sqlcmd -S .\sqlexpress -E -Q "SELECT @@VERSION"
```

---

## 🚀 Hướng Dẫn Setup Nhanh

### Bước 1: Clone Repository
```bash
# Clone dự án từ repository
git clone <repository-url>
cd Tung_Project

# Hoặc nếu đã có source code, chuyển đến thư mục dự án
cd f:\Temp_Project\Tung_Project
```

### Bước 2: Restore Dependencies
```bash
# Restore tất cả packages cho solution
dotnet restore WinFormsApp1.sln

# Hoặc restore từng project riêng lẻ
dotnet restore WinFormsApp1/WinFormsApp1.csproj
dotnet restore Models/Models.csproj
dotnet restore DbHelper/DbHelper.csproj
```

### Bước 3: Cấu Hình Database

#### 3.1. Cài Đặt SQL Server Express (nếu chưa có):
```bash
# Download và cài đặt SQL Server Express từ Microsoft
# Hoặc sử dụng LocalDB (đã có sẵn với Visual Studio)

# Kiểm tra SQL Server Express
sqlcmd -S .\sqlexpress -E -Q "SELECT 1"

# Hoặc kiểm tra LocalDB
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -Q "SELECT 1"
```

#### 3.2. Tạo Database:
```bash
# Tạo database bằng sqlcmd
sqlcmd -S .\sqlexpress -E -Q "CREATE DATABASE Tung_DB"

# Hoặc với LocalDB
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -Q "CREATE DATABASE Tung_DB"
```

#### 3.3. Chạy Migration:
```bash
# Chuyển đến thư mục Models (nơi chứa DbContext)
cd Models

# Chạy migration để tạo tables
dotnet ef database update --startup-project ../WinFormsApp1

# Quay lại thư mục gốc
cd ..
```

### Bước 4: Build Solution
```bash
# Build toàn bộ solution
dotnet build WinFormsApp1.sln --configuration Debug

# Hoặc build Release
dotnet build WinFormsApp1.sln --configuration Release
```

### Bước 5: Chạy Ứng Dụng
```bash
# Chạy ứng dụng WinForms
dotnet run --project WinFormsApp1/WinFormsApp1.csproj

# Hoặc chạy file exe đã build
cd WinFormsApp1/bin/Debug/net8.0-windows
./WinFormsApp1.exe
```

---

## 🔧 Cấu Hình Chi Tiết

### Connection String
Mặc định ứng dụng sử dụng connection string:
```
Server=.\sqlexpress;Database=Tung_DB;Trusted_Connection=True;TrustServerCertificate=True
```

Nếu cần thay đổi, sửa file `Models/HandleData/DAContext.cs` dòng 38.

### Các Lệnh Entity Framework Hữu Ích:
```bash
# Tạo migration mới
dotnet ef migrations add <TenMigration> --project Models --startup-project WinFormsApp1

# Xem danh sách migrations
dotnet ef migrations list --project Models --startup-project WinFormsApp1

# Rollback migration
dotnet ef database update <TenMigrationTruoc> --project Models --startup-project WinFormsApp1

# Xóa migration cuối
dotnet ef migrations remove --project Models --startup-project WinFormsApp1

# Tạo script SQL từ migrations
dotnet ef migrations script --project Models --startup-project WinFormsApp1 --output migration.sql
```

---

## 🛠️ Troubleshooting

### Lỗi Thường Gặp:

#### 1. Lỗi Connection String:
```bash
# Kiểm tra SQL Server service
net start MSSQL$SQLEXPRESS

# Hoặc với LocalDB
sqllocaldb start MSSQLLocalDB
```

#### 2. Lỗi Migration:
```bash
# Xóa database và tạo lại
sqlcmd -S .\sqlexpress -E -Q "DROP DATABASE IF EXISTS Tung_DB"
sqlcmd -S .\sqlexpress -E -Q "CREATE DATABASE Tung_DB"

# Chạy lại migration
cd Models
dotnet ef database update --startup-project ../WinFormsApp1
cd ..
```

#### 3. Lỗi Dependencies:
```bash
# Clean và rebuild
dotnet clean WinFormsApp1.sln
dotnet restore WinFormsApp1.sln
dotnet build WinFormsApp1.sln
```

#### 4. Lỗi .NET SDK:
```bash
# Kiểm tra version
dotnet --list-sdks

# Cài đặt .NET 8.0 nếu chưa có
# Download từ: https://dotnet.microsoft.com/download/dotnet/8.0
```

---

## 📦 Cấu Trúc Dự Án

```
Tung_Project/
├── WinFormsApp1/          # Main WinForms Application
├── Models/                # Entity Framework Models & DbContext
├── DbHelper/              # Database Helper Classes
├── WinFormsApp1.sln       # Solution File
└── huongDanSetUp.md       # File hướng dẫn này
```

---

## 🎯 Script Setup Tự Động

Tạo file `setup.bat` để tự động hóa quá trình setup:

```batch
@echo off
echo ========================================
echo    SETUP DU AN WINFORMS - QUAN LY DE TAI
echo ========================================

echo.
echo [1/5] Kiem tra .NET SDK...
dotnet --version
if %errorlevel% neq 0 (
    echo ERROR: .NET SDK khong duoc cai dat!
    echo Vui long tai va cai dat .NET 8.0 SDK
    pause
    exit /b 1
)

echo.
echo [2/5] Restore dependencies...
dotnet restore WinFormsApp1.sln
if %errorlevel% neq 0 (
    echo ERROR: Khong the restore dependencies!
    pause
    exit /b 1
)

echo.
echo [3/5] Tao database...
sqlcmd -S .\sqlexpress -E -Q "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Tung_DB') CREATE DATABASE Tung_DB"

echo.
echo [4/5] Chay migration...
cd Models
dotnet ef database update --startup-project ../WinFormsApp1
cd ..

echo.
echo [5/5] Build solution...
dotnet build WinFormsApp1.sln --configuration Debug

echo.
echo ========================================
echo    SETUP HOAN THANH!
echo ========================================
echo.
echo De chay ung dung, su dung lenh:
echo dotnet run --project WinFormsApp1/WinFormsApp1.csproj
echo.
pause
```

Để sử dụng script:
```bash
# Tạo file setup.bat và chạy
./setup.bat
```

---

## 📞 Hỗ Trợ

Nếu gặp vấn đề trong quá trình setup, hãy kiểm tra:

1. **Log files** trong thư mục `bin/Debug/`
2. **Event Viewer** của Windows
3. **SQL Server Error Log**

Hoặc liên hệ team phát triển để được hỗ trợ.

---

*Cập nhật lần cuối: $(Get-Date)*