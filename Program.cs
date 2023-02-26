namespace JapanRandomHiraganaKatakana
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Alphabet() { ClientSize = new Size(300, 361) });
        }
    }
}