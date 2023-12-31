namespace Exo_Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Login login = new Login("samuel.legrain@bstorm.be", "Test1234=");
            login.LoginEvent += Notify;

            login.CheckLogin("sam@fait.rire", "toto");
            login.CheckLogin("samuel.legrain@bstorm.be", "Test1234=");

        }

        private static void Notify(string message, bool isSucceed)
        {
            if (isSucceed)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine(message);
            Console.ResetColor();
        } 

        private static void NotifySuccess(object sender, EventArgs e) {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bienvenu!");
            Console.ResetColor();
        }

        private static void NotifyFailure (object sender, EventArgs e) {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("L'email et/ou le mot de passe ne correspond pas...");
            Console.ResetColor();
        }
    }
}
