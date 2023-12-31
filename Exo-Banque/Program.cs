using Exo_Banque.Exceptions;
using Exo_Banque.Interfaces;
using Exo_Banque.Models;

namespace Exo_Banque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.OutputEncoding = System.Text.Encoding.Unicode;
                Personne p1 = new Personne("Legrain", "Samuel", new DateTime(1987, 9, 27));

                Courant compte1 = new Courant("BE55 1234 1234 1234", 100, p1);
                Courant compte2 = new Courant("BE54 1234 1234 1234", 200, p1);

                Banque banque1 = new Banque();
                banque1.Nom = "LeBonIntérêt!";
                banque1.Ajouter(compte1);
                banque1.Ajouter(compte2);

                compte1.Retrait(50);
                Console.WriteLine($"Sur le compte {compte1.Numero}, le solde est de : {compte1.Solde} €");


                compte2.Depot(50_000);
                Console.WriteLine($"Sur le compte {compte2.Numero}, le solde est de : {compte2.Solde} €");

                //Personne user = new Personne() { Nom = "Legrain", Prenom = "Samuel", DateNaiss = new DateTime(1987,9,27)};

                Console.WriteLine($"Le titulaire {p1.Nom} {p1.Prenom} à comme avoirs : {banque1.AvoirDesComptes(p1)} €");

                Epargne compte3 = new Epargne("BE75 1234 1234 1234", p1);
                compte3.Depot(10_000);
                Console.WriteLine($"Sur le compte {compte3.Numero}, le solde est de : {compte3.Solde} €");
                compte3.Retrait(500);
                Console.WriteLine($"Sur le compte {compte3.Numero}, le solde est de : {compte3.Solde} €.\nLe dernier retrait a été effectué le {compte3.DateDernierRetrait}");

                banque1.Ajouter(compte3);

                IBanker compteExemple = banque1["BE55 1234 1234 1234"];

                Console.WriteLine($"Le titulaire {compteExemple.Titulaire.Nom} {compteExemple.Titulaire.Prenom} à comme avoirs : {banque1.AvoirDesComptes(compteExemple.Titulaire)} €");

                compte1.AppliquerInteret();
                Console.WriteLine($"Sur le compte {compte1.Numero}, le solde est de : {compte1.Solde} €");
                compte2.AppliquerInteret();
                Console.WriteLine($"Sur le compte {compte2.Numero}, le solde est de : {compte2.Solde} €");
                compte3.AppliquerInteret();
                Console.WriteLine($"Sur le compte {compte3.Numero}, le solde est de : {compte3.Solde} €");


                compte1.Depot(100);
                banque1.Supprimer(compte1.Numero);
                compte1.Retrait(100);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Console.BackgroundColor = ConsoleColor.Yellow;
                //Console.ForegroundColor = ConsoleColor.Black;
                //Console.WriteLine(ex.Message);
                //Console.ResetColor();
                EcrireMessageErreur(ConsoleColor.Yellow, ConsoleColor.Black, ex);
            }
            catch (SoldeInsuffisantException ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Solde : {ex.Solde}");
                Console.WriteLine($"Limite : {ex.Limite}");
                Console.WriteLine($"Montant : {ex.Montant}");
                Console.WriteLine($"Dépassement : {ex.Solde + ex.Limite - ex.Montant}");
                Console.ResetColor();
            }
            catch (InvalidOperationException ex)
            {
                //Console.BackgroundColor = ConsoleColor.Red;
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine(ex.Message);
                //Console.ResetColor();
                EcrireMessageErreur(ConsoleColor.Red, ConsoleColor.White, ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            
        }

        static void EcrireMessageErreur(ConsoleColor fond, ConsoleColor texte, Exception error)
        {
            Console.BackgroundColor = fond;
            Console.ForegroundColor = texte;
            Console.WriteLine(error.Message);
            Console.ResetColor();
        }
    }
}