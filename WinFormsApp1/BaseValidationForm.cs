using DbHelper;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    /// <summary>
    /// Base form for forms that require validation functionality
    /// Inherits from BaseForm and adds validation capabilities
    /// </summary>
    public partial class BaseValidationForm : BaseForm
    {
        /// <summary>
        /// List to store validation rules for the form
        /// </summary>
        protected List<ValidationRule> ValidationRules { get; private set; }

        /// <summary>
        /// Indicates if the form is in edit mode
        /// </summary>
        protected bool IsEditing { get; set; }

        public BaseValidationForm()
        {
            InitializeComponent();
            ValidationRules = new List<ValidationRule>();
            this.Load += BaseValidationForm_Load;
        }

        public BaseValidationForm(IDbContextService dbService) : base(dbService)
        {
            InitializeComponent();
            ValidationRules = new List<ValidationRule>();
            this.Load += BaseValidationForm_Load;
        }

        private void BaseValidationForm_Load(object sender, EventArgs e)
        {
            SetupValidation();
        }

        /// <summary>
        /// Virtual method for derived classes to setup their validation rules
        /// </summary>
        protected virtual void SetupValidation()
        {
            // Override in derived classes to add validation rules
        }

        /// <summary>
        /// Add a validation rule for a TextBox
        /// </summary>
        protected void AddValidationRule(TextBox textBox, Func<string, ValidationResult> validator, string fieldName = "")
        {
            if (textBox == null)
                throw new ArgumentNullException(nameof(textBox));
            if (validator == null)
                throw new ArgumentNullException(nameof(validator));

            ValidationRules.Add(new ValidationRule
            {
                Control = textBox,
                Validator = (control) =>
                {
                    if (control == null)
                        return ValidationResult.Error($"Control {fieldName} không tồn tại");

                    if (control is TextBox tb)
                        return validator(tb.Text);

                    return ValidationResult.Error($"Control {fieldName} không phải là TextBox");
                },
                FieldName = fieldName
            });
        }

        /// <summary>
        /// Add a validation rule for a ComboBox
        /// </summary>
        protected void AddValidationRule(ComboBox comboBox, string fieldName)
        {
            if (comboBox == null)
                throw new ArgumentNullException(nameof(comboBox));
            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentException("Field name cannot be null or empty", nameof(fieldName));

            ValidationRules.Add(new ValidationRule
            {
                Control = comboBox,
                Validator = (control) =>
                {
                    if (control == null)
                        return ValidationResult.Error($"Control {fieldName} không tồn tại");

                    if (control is ComboBox cb)
                        return ValidationHelper.ValidateComboBoxSelection(cb, fieldName);

                    return ValidationResult.Error($"Control {fieldName} không phải là ComboBox");
                },
                FieldName = fieldName
            });
        }

        /// <summary>
        /// Add a custom validation rule
        /// </summary>
        protected void AddValidationRule(Control control, Func<Control, ValidationResult> validator, string fieldName = "")
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));
            if (validator == null)
                throw new ArgumentNullException(nameof(validator));

            ValidationRules.Add(new ValidationRule
            {
                Control = control,
                Validator = (ctrl) =>
                {
                    if (ctrl == null)
                        return ValidationResult.Error($"Control {fieldName} không tồn tại");

                    return validator(ctrl);
                },
                FieldName = fieldName
            });
        }

        /// <summary>
        /// Validates all controls according to their rules
        /// </summary>
        protected virtual bool ValidateForm()
        {
            foreach (var rule in ValidationRules)
            {
                if (rule?.Control == null || rule?.Validator == null)
                {
                    ShowErrorMessage($"Validation rule không hợp lệ cho field: {rule?.FieldName ?? "unknown"}", new Exception());
                    return false;
                }

                var result = rule.Validator(rule.Control);
                if (!result.IsValid)
                {
                    ShowErrorMessage(result.ErrorMessage, new Exception());

                    // Only try to focus if control is not null and can receive focus
                    if (rule.Control != null && rule.Control.CanFocus)
                    {
                        rule.Control.Focus();
                    }
                    return false;
                }
            }

            return ValidateCustomRules();
        }

        /// <summary>
        /// Virtual method for custom validation logic
        /// Override in derived classes for complex validation
        /// </summary>
        protected virtual bool ValidateCustomRules()
        {
            return true;
        }

        /// <summary>
        /// Clear all input controls
        /// </summary>
        protected virtual void ClearInputs()
        {
            foreach (Control control in this.Controls)
            {
                ClearControl(control);
            }
        }

        /// <summary>
        /// Recursively clear controls
        /// </summary>
        private void ClearControl(Control control)
        {
            switch (control)
            {
                case TextBox textBox:
                    textBox.Clear();
                    break;
                case ComboBox comboBox:
                    comboBox.SelectedIndex = -1;
                    break;
                case NumericUpDown numericUpDown:
                    numericUpDown.Value = numericUpDown.Minimum;
                    break;
                case DateTimePicker dateTimePicker:
                    dateTimePicker.Value = DateTime.Now;
                    break;
                case CheckBox checkBox:
                    checkBox.Checked = false;
                    break;
                case RadioButton radioButton:
                    radioButton.Checked = false;
                    break;
                default:
                    // For containers, clear child controls
                    if (control.HasChildren)
                    {
                        foreach (Control child in control.Controls)
                        {
                            ClearControl(child);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Set the enabled state of form controls based on edit mode
        /// </summary>
        protected virtual void SetControlStates(bool editing)
        {
            IsEditing = editing;

            // Override in derived classes to implement specific control state logic
            foreach (Control control in this.Controls)
            {
                SetControlState(control, editing);
            }
        }

        /// <summary>
        /// Recursively set control states
        /// </summary>
        private void SetControlState(Control control, bool editing)
        {
            switch (control)
            {
                case TextBox textBox when !textBox.Name.Contains("Display") && !textBox.Name.Contains("ReadOnly"):
                    textBox.ReadOnly = !editing;
                    break;
                case ComboBox comboBox:
                    comboBox.Enabled = editing;
                    break;
                case NumericUpDown numericUpDown:
                    numericUpDown.Enabled = editing;
                    break;
                case DateTimePicker dateTimePicker:
                    dateTimePicker.Enabled = editing;
                    break;
                case CheckBox checkBox:
                    checkBox.Enabled = editing;
                    break;
                case RadioButton radioButton:
                    radioButton.Enabled = editing;
                    break;
                default:
                    // For containers, set child control states
                    if (control.HasChildren)
                    {
                        foreach (Control child in control.Controls)
                        {
                            SetControlState(child, editing);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Common save operation template method
        /// </summary>
        protected virtual async Task<bool> SaveAsync()
        {
            if (!ValidateForm())
                return false;

            try
            {
                bool result = await PerformSaveOperation();
                if (result)
                {
                    ShowSuccessMessage("Lưu dữ liệu thành công!");
                    await RefreshData();
                    SetControlStates(false);
                }
                return result;
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi lưu dữ liệu", ex);
                return false;
            }
        }

        /// <summary>
        /// Abstract method for derived classes to implement save logic
        /// </summary>
        protected virtual async Task<bool> PerformSaveOperation()
        {
            // Override in derived classes
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Virtual method to refresh data after save
        /// </summary>
        protected virtual async Task RefreshData()
        {
            // Override in derived classes
            await Task.CompletedTask;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseValidationForm));
            SuspendLayout();
            // 
            // BaseValidationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BaseValidationForm";
            Text = "BaseValidationForm";
            ResumeLayout(false);
        }
    }

    /// <summary>
    /// Represents a validation rule for a control
    /// </summary>
    public class ValidationRule
    {
        public required Control Control { get; set; }
        public required Func<Control, ValidationResult> Validator { get; set; }
        public required string FieldName { get; set; }
    }
}
