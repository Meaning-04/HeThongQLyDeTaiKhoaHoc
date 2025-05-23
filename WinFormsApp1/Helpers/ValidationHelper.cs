using System.Text.RegularExpressions;

namespace WinFormsApp1.Helpers
{
    /// <summary>
    /// Utility class for common validation operations
    /// Centralizes validation logic to eliminate code duplication
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Validates that a text field is not empty
        /// </summary>
        public static ValidationResult ValidateRequired(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return ValidationResult.Error($"Vui lòng nhập {fieldName}!");
            }
            return ValidationResult.Success();
        }

        /// <summary>
        /// Validates minimum length for a text field
        /// </summary>
        public static ValidationResult ValidateMinLength(string value, int minLength, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < minLength)
            {
                return ValidationResult.Error($"{fieldName} phải có ít nhất {minLength} ký tự!");
            }
            return ValidationResult.Success();
        }

        /// <summary>
        /// Validates maximum length for a text field
        /// </summary>
        public static ValidationResult ValidateMaxLength(string value, int maxLength, string fieldName)
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Trim().Length > maxLength)
            {
                return ValidationResult.Error($"{fieldName} không được vượt quá {maxLength} ký tự!");
            }
            return ValidationResult.Success();
        }

        /// <summary>
        /// Validates phone number format (Vietnamese format)
        /// </summary>
        public static ValidationResult ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return ValidationResult.Success(); // Optional field
            }

            // Remove spaces and special characters
            string cleanPhone = Regex.Replace(phoneNumber, @"[\s\-\(\)]", string.Empty);

            // Vietnamese phone number patterns
            if (!Regex.IsMatch(cleanPhone, @"^(0[3|5|7|8|9])[0-9]{8}$"))
            {
                return ValidationResult.Error("Số điện thoại không đúng định dạng! (VD: 0912345678)");
            }

            return ValidationResult.Success();
        }

        /// <summary>
        /// Validates email format
        /// </summary>
        public static ValidationResult ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return ValidationResult.Success(); // Optional field
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return ValidationResult.Error("Email không đúng định dạng!");
            }

            return ValidationResult.Success();
        }

        /// <summary>
        /// Validates username format (alphanumeric and underscore only)
        /// </summary>
        public static ValidationResult ValidateUsername(string username)
        {
            var requiredResult = ValidateRequired(username, "tên đăng nhập");
            if (!requiredResult.IsValid)
                return requiredResult;

            var lengthResult = ValidateMinLength(username, 3, "Tên đăng nhập");
            if (!lengthResult.IsValid)
                return lengthResult;

            if (!Regex.IsMatch(username.Trim(), @"^[a-zA-Z0-9_]+$"))
            {
                return ValidationResult.Error("Tên đăng nhập chỉ được chứa chữ cái, số và dấu gạch dưới!");
            }

            return ValidationResult.Success();
        }

        /// <summary>
        /// Validates numeric input within range
        /// </summary>
        public static ValidationResult ValidateNumericRange(string value, decimal min, decimal max, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return ValidationResult.Error($"Vui lòng nhập {fieldName}!");
            }

            if (!decimal.TryParse(value, out decimal numValue))
            {
                return ValidationResult.Error($"{fieldName} phải là số!");
            }

            if (numValue < min || numValue > max)
            {
                return ValidationResult.Error($"{fieldName} phải từ {min:N0} đến {max:N0}!");
            }

            return ValidationResult.Success();
        }

        /// <summary>
        /// Validates year input
        /// </summary>
        public static ValidationResult ValidateYear(int? year, string fieldName)
        {
            if (!year.HasValue || year.Value <= 0)
            {
                return ValidationResult.Success(); // Optional field
            }

            int currentYear = DateTime.Now.Year;
            if (year.Value < 1900 || year.Value > currentYear + 10)
            {
                return ValidationResult.Error($"{fieldName} phải từ 1900 đến {currentYear + 10}!");
            }

            return ValidationResult.Success();
        }

        /// <summary>
        /// Validates ComboBox selection
        /// </summary>
        public static ValidationResult ValidateComboBoxSelection(ComboBox comboBox, string fieldName)
        {
            if (comboBox.SelectedIndex == -1)
            {
                return ValidationResult.Error($"Vui lòng chọn {fieldName}!");
            }
            return ValidationResult.Success();
        }

        /// <summary>
        /// Validates date range
        /// </summary>
        public static ValidationResult ValidateDateRange(DateTime? startDate, DateTime? endDate)
        {
            if (startDate.HasValue && endDate.HasValue && startDate.Value > endDate.Value)
            {
                return ValidationResult.Error("Ngày bắt đầu không được lớn hơn ngày kết thúc!");
            }
            return ValidationResult.Success();
        }
    }

    /// <summary>
    /// Represents the result of a validation operation
    /// </summary>
    public class ValidationResult
    {
        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; }

        private ValidationResult(bool isValid, string errorMessage = "")
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public static ValidationResult Success()
        {
            return new ValidationResult(true);
        }

        public static ValidationResult Error(string message)
        {
            return new ValidationResult(false, message);
        }
    }

    /// <summary>
    /// Extension methods for Control validation
    /// </summary>
    public static class ControlValidationExtensions
    {
        /// <summary>
        /// Validates a TextBox and shows error if invalid
        /// </summary>
        public static bool ValidateAndShowError(this TextBox textBox, Func<string, ValidationResult> validator, Form parentForm)
        {
            var result = validator(textBox.Text);
            if (!result.IsValid)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates a ComboBox and shows error if invalid
        /// </summary>
        public static bool ValidateAndShowError(this ComboBox comboBox, string fieldName, Form parentForm)
        {
            var result = ValidationHelper.ValidateComboBoxSelection(comboBox, fieldName);
            if (!result.IsValid)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox.Focus();
                return false;
            }
            return true;
        }
    }
}
