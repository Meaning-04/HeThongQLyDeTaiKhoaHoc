using DbHelper;
using Models.HandleData;

namespace WinFormsApp1
{
    /// <summary>
    /// Base form class that provides centralized database access through DbContextService
    /// All forms should inherit from this class to ensure proper DbContext resource management
    /// </summary>
    public partial class BaseForm : Form
    {
        /// <summary>
        /// Database context service for performing database operations
        /// </summary>
        protected IDbContextService DbService { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();
            DbService = DbContextServiceFactory.Instance;
        }

        /// <summary>
        /// Constructor with custom DbContextService (for testing or custom configurations)
        /// </summary>
        public BaseForm(IDbContextService dbService)
        {
            InitializeComponent();
            DbService = dbService ?? throw new ArgumentNullException(nameof(dbService));
        }

        /// <summary>
        /// Helper method to execute database operations with error handling
        /// </summary>
        protected async Task<T> ExecuteDbOperationAsync<T>(Func<DAContext, Task<T>> operation, string errorMessage = "Lỗi khi thực hiện thao tác cơ sở dữ liệu")
        {
            try
            {
                return await DbService.ExecuteAsync(operation);
            }
            catch (DatabaseOperationException ex)
            {
                ShowErrorMessage(errorMessage, ex);
                throw;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(errorMessage, ex);
                throw new DatabaseOperationException(errorMessage, ex);
            }
        }

        /// <summary>
        /// Helper method to execute database operations without return value
        /// </summary>
        protected async Task ExecuteDbOperationAsync(Func<DAContext, Task> operation, string errorMessage = "Lỗi khi thực hiện thao tác cơ sở dữ liệu")
        {
            try
            {
                await DbService.ExecuteAsync(operation);
            }
            catch (DatabaseOperationException ex)
            {
                ShowErrorMessage(errorMessage, ex);
                throw;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(errorMessage, ex);
                throw new DatabaseOperationException(errorMessage, ex);
            }
        }

        /// <summary>
        /// Helper method to execute synchronous database operations with error handling
        /// </summary>
        protected T ExecuteDbOperation<T>(Func<DAContext, T> operation, string errorMessage = "Lỗi khi thực hiện thao tác cơ sở dữ liệu")
        {
            try
            {
                return DbService.Execute(operation);
            }
            catch (DatabaseOperationException ex)
            {
                ShowErrorMessage(errorMessage, ex);
                throw;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(errorMessage, ex);
                throw new DatabaseOperationException(errorMessage, ex);
            }
        }

        /// <summary>
        /// Helper method to execute synchronous database operations without return value
        /// </summary>
        protected void ExecuteDbOperation(Action<DAContext> operation, string errorMessage = "Lỗi khi thực hiện thao tác cơ sở dữ liệu")
        {
            try
            {
                DbService.Execute(operation);
            }
            catch (DatabaseOperationException ex)
            {
                ShowErrorMessage(errorMessage, ex);
                throw;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(errorMessage, ex);
                throw new DatabaseOperationException(errorMessage, ex);
            }
        }

        /// <summary>
        /// Show error message to user
        /// </summary>
        protected virtual void ShowErrorMessage(string message, Exception ex)
        {
            string fullMessage = $"{message}\n\nChi tiết lỗi: {ex.Message}";
            MessageBox.Show(fullMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Show success message to user
        /// </summary>
        protected virtual void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Show warning message to user
        /// </summary>
        protected virtual void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Ask user for confirmation
        /// </summary>
        protected virtual bool AskConfirmation(string message, string title = "Xác nhận")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            SuspendLayout();
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "BaseForm";
            Text = "BaseForm";
            ResumeLayout(false);
        }
    }
}
