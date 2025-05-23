namespace WinFormsApp1.Constants
{
    /// <summary>
    /// Application-wide constants to eliminate hardcoded strings and magic numbers
    /// </summary>
    public static class AppConstants
    {
        /// <summary>
        /// Database configuration constants
        /// </summary>
        public static class Database
        {
            public const string DefaultConnectionString = "Server=.\\sqlexpress;Database=Tung_DB;Trusted_Connection=True;TrustServerCertificate=True";
            public const int CommandTimeout = 30;
            public const int MaxRetryAttempts = 3;
        }

        /// <summary>
        /// User interface messages
        /// </summary>
        public static class Messages
        {
            // Success messages
            public const string SaveSuccess = "Lưu dữ liệu thành công!";
            public const string DeleteSuccess = "Xóa dữ liệu thành công!";
            public const string UpdateSuccess = "Cập nhật dữ liệu thành công!";
            public const string AddSuccess = "Thêm dữ liệu thành công!";
            public const string ExportSuccess = "Xuất file thành công!";
            public const string ImportSuccess = "Nhập file thành công!";
            public const string ResetPasswordSuccess = "Reset mật khẩu thành công! Mật khẩu mới là: 123";

            // Error messages
            public const string ErrorLoadingData = "Lỗi khi tải dữ liệu";
            public const string ErrorSavingData = "Lỗi khi lưu dữ liệu";
            public const string ErrorDeletingData = "Lỗi khi xóa dữ liệu";
            public const string ErrorUpdatingData = "Lỗi khi cập nhật dữ liệu";
            public const string ErrorAddingData = "Lỗi khi thêm dữ liệu";
            public const string ErrorExportingData = "Lỗi khi xuất file";
            public const string ErrorImportingData = "Lỗi khi nhập file";
            public const string ErrorDatabaseConnection = "Lỗi kết nối cơ sở dữ liệu";
            public const string ErrorInvalidData = "Dữ liệu không hợp lệ";
            public const string ErrorFileNotFound = "Không tìm thấy file";
            public const string ErrorFileAccess = "Không thể truy cập file";
            public const string ErrorUnauthorized = "Bạn không có quyền thực hiện thao tác này";

            // Warning messages
            public const string WarningSelectItem = "Vui lòng chọn một mục để thực hiện thao tác!";
            public const string WarningUnsavedChanges = "Có thay đổi chưa được lưu. Bạn có muốn tiếp tục?";
            public const string WarningDeleteConfirm = "Bạn có chắc chắn muốn xóa mục này?";
            public const string WarningResetPassword = "Bạn có chắc chắn muốn reset mật khẩu về '123'?";

            // Validation messages
            public const string ValidationRequired = "Vui lòng nhập {0}!";
            public const string ValidationMinLength = "{0} phải có ít nhất {1} ký tự!";
            public const string ValidationMaxLength = "{0} không được vượt quá {1} ký tự!";
            public const string ValidationInvalidFormat = "{0} không đúng định dạng!";
            public const string ValidationDuplicateEntry = "{0} đã tồn tại!";
            public const string ValidationInvalidRange = "{0} phải từ {1} đến {2}!";

            // Information messages
            public const string InfoNoDataFound = "Không tìm thấy dữ liệu";
            public const string InfoDataLoaded = "Đã tải {0} bản ghi";
            public const string InfoProcessing = "Đang xử lý...";
            public const string InfoExporting = "Đang xuất file...";
            public const string InfoImporting = "Đang nhập file...";
            public const string NoFileToDownload = "Không có file để tải xuống";
            public const string DownloadSuccess = "Tải file thành công!";
            public const string PleaseSelectUnit = "Vui lòng chọn đơn vị!";
        }

        /// <summary>
        /// File operation constants
        /// </summary>
        public static class Files
        {
            // File filters
            public const string ExcelFilter = "Excel Files|*.xlsx|All Files|*.*";
            public const string WordFilter = "Word Files|*.docx|All Files|*.*";
            public const string PdfFilter = "PDF Files|*.pdf|All Files|*.*";
            public const string AllFilesFilter = "All Files|*.*";
            public const string AllFileFilter = "All Files|*.*";
            public const string ImageFilter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";

            // File size limits (in bytes)
            public const long MaxFileSize = 10 * 1024 * 1024; // 10MB
            public const long MaxImageSize = 5 * 1024 * 1024;  // 5MB
            public const long MaxDocumentSize = 20 * 1024 * 1024; // 20MB

            // File extensions
            public static readonly string[] AllowedImageExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            public static readonly string[] AllowedDocumentExtensions = { ".pdf", ".doc", ".docx", ".txt" };
            public static readonly string[] AllowedExcelExtensions = { ".xlsx", ".xls" };
        }

        /// <summary>
        /// Validation constants
        /// </summary>
        public static class Validation
        {
            // Length constraints
            public const int MinUsernameLength = 3;
            public const int MaxUsernameLength = 50;
            public const int MinPasswordLength = 3;
            public const int MaxPasswordLength = 100;
            public const int MaxNameLength = 100;
            public const int MaxDescriptionLength = 500;
            public const int MaxAddressLength = 200;
            public const int PhoneNumberLength = 10;

            // Numeric constraints
            public const int MinYear = 1900;
            public const int MaxYearOffset = 10; // Current year + 10
            public const decimal MinBudget = 0;
            public const decimal MaxBudget = 999999999999; // 999 billion

            // Regular expressions
            public const string UsernamePattern = @"^[a-zA-Z0-9_]+$";
            public const string PhonePattern = @"^(0[3|5|7|8|9])[0-9]{8}$";
            public const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        }

        /// <summary>
        /// UI constants
        /// </summary>
        public static class UI
        {
            // Form titles
            public const string MainFormTitle = "Hệ thống quản lý đề tài nghiên cứu";
            public const string LoginFormTitle = "Đăng nhập hệ thống";
            public const string StatisticsFormTitle = "Thống kê";
            public const string ProjectManagementTitle = "Quản lý đề tài";
            public const string StaffManagementTitle = "Quản lý cán bộ";
            public const string AccountManagementTitle = "Quản lý tài khoản";

            // Button texts
            public const string AddButtonText = "Thêm";
            public const string EditButtonText = "Sửa";
            public const string DeleteButtonText = "Xóa";
            public const string SaveButtonText = "Lưu";
            public const string CancelButtonText = "Hủy";
            public const string RefreshButtonText = "Làm mới";
            public const string ExportButtonText = "Xuất file";
            public const string ImportButtonText = "Nhập file";
            public const string SearchButtonText = "Tìm kiếm";
            public const string ResetButtonText = "Reset";

            // Grid column widths
            public const int SmallColumnWidth = 60;
            public const int MediumColumnWidth = 120;
            public const int LargeColumnWidth = 200;
            public const int ExtraLargeColumnWidth = 300;

            // Loading messages
            public const string LoadingData = "Đang tải dữ liệu...";
            public const string LoadingStatistics = "Đang tải dữ liệu thống kê...";
            public const string ProcessingRequest = "Đang xử lý yêu cầu...";
        }

        /// <summary>
        /// Application settings
        /// </summary>
        public static class Settings
        {
            // Default values
            public const string DefaultPassword = "123";
            public const int DefaultPageSize = 50;
            public const int DefaultTimeout = 30;

            // Cache settings
            public const int CacheExpirationMinutes = 30;
            public const int MaxCacheSize = 100;

            // Export settings
            public const string DefaultExportPath = "Exports";
            public const string ExportDateFormat = "yyyyMMdd_HHmmss";
        }

        /// <summary>
        /// Role and permission constants
        /// </summary>
        public static class Roles
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }

        /// <summary>
        /// Status constants
        /// </summary>
        public static class Status
        {
            public const string Active = "Hoạt động";
            public const string Inactive = "Không hoạt động";
            public const string Completed = "Hoàn thành";
            public const string InProgress = "Đang thực hiện";
            public const string Pending = "Chờ xử lý";
            public const string Cancelled = "Đã hủy";
        }

        /// <summary>
        /// Format constants
        /// </summary>
        public static class Formats
        {
            public const string DateFormat = "dd/MM/yyyy";
            public const string DateTimeFormat = "dd/MM/yyyy HH:mm:ss";
            public const string CurrencyFormat = "#,##0";
            public const string PercentageFormat = "0.00%";
            public const string ProjectCodeFormat = "DT{0:D6}";
        }
    }
}
