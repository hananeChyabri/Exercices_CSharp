using Exo_CarWash.Models;

namespace Exo_CarWash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarWash cw = new CarWash();
            Voiture v1 = new Voiture("1-ABC-123");
            Voiture v2 = new Voiture("1-DEF-456");
            Voiture v3 = new Voiture("1-GHI-789");

            cw.Traiter(v1);
            cw.Traiter(v2);
            cw.Traiter(v3);
        }
    }
}
