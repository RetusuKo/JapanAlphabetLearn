namespace JapanRandomHiraganaKatakana
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Alphabet() { ClientSize = new Size(300, 361) });
        }
    }
}