using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo_Banque.Exceptions;
using Exo_Banque.Interfaces;

namespace Exo_Banque.Models
{
    //internal delegate void PassageEnNegatifDelegate(Compte c);
    internal abstract class Compte : IBanker //,ICustomer //Pas exclus de mettre les deux interfaces
    {

        public string Numero { get; private set; }
        public double Solde { get; private set; }
        public Personne Titulaire { get; private set; }

        //public event PassageEnNegatifDelegate PassageEnNegatifEvent;
        public event Action<Compte> PassageEnNegatifEvent;
        public Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }

        public Compte(string numero, Personne titulaire, double solde) : this(numero, titulaire)
        {
            Solde = solde;
        }


        public void Depot(double montant)
        {
            if (montant <= 0) throw new ArgumentOutOfRangeException(nameof(montant), "Doit être supérieur à 0.");
            Solde += montant;
        }

        public virtual void Retrait(double montant)
        {
            Retrait(montant, 0);
        }

        protected void Retrait(double montant, double limite)
        {
            if (montant <= 0) throw new ArgumentOutOfRangeException(nameof(montant), "Doit être supérieur à 0.");
            if (montant > Solde + limite) throw new SoldeInsuffisantException(montant, Solde, limite);
            Solde -= montant;
        }
        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            Solde += CalculInteret();
        }

        protected void PassageEnNegatifRaise(Compte c)
        {
            PassageEnNegatifEvent?.Invoke(c);
        }

        public static double operator +(Compte left, Compte right)
        {
            double leftSolde = left.Solde < 0 ? 0 : left.Solde;
            double rightSolde = right.Solde < 0 ? 0 : right.Solde;
            return leftSolde + rightSolde;
        }

        public static double operator +(double left, Compte right)
        {
            left = Math.Max(0, left);
            double rightSolde = Math.Max(0, right.Solde);
            return left + rightSolde;
        }
    }
}
