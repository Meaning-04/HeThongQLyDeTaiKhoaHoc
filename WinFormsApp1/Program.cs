namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Tạo form đăng nhập
            var loginForm = new Form1();

            // Chạy ứng dụng với form đăng nhập làm form chính
            Application.Run(loginForm);
        }
    }
}