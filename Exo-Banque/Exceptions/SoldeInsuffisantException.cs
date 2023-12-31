using System.Runtime.Serialization;

namespace Exo_Banque.Exceptions
{
    internal class SoldeInsuffisantException : Exception
    {
        public double Montant { get; private set; }
        public double Solde { get; private set; }
        public double Limite { get; private set; }
        public SoldeInsuffisantException() : this("Votre solde n'est pas suffisant pour enlever un tel montant.")
        {
        }

        public SoldeInsuffisantException(string? message) : base(message)
        {
        }

        public SoldeInsuffisantException(double montant, double solde, double limite = 0) :
            this($"Votre solde de {solde} n'est pas suffisant pour enlever un montant de {montant}. (Avec une limite de {limite})", montant, solde, limite)
        {
        }

        public SoldeInsuffisantException(string message, double montant, double solde, double limite = 0) : this(message)
        {
            Montant = montant;
            Solde = solde;
            Limite = limite;
        }

    }
}