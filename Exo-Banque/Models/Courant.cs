using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo_Banque.Interfaces;

namespace Exo_Banque.Models
{
    internal class Courant : Compte, IBanker
    {
        private double _ligneDeCredit;

        public double LigneDeCredit
        {
            get
            {
                return _ligneDeCredit;
            }
            set
            {
                //_ligneDeCredit = (value >= 0) ? value : throw new InvalidOperationException("La ligne de crédit doit rester positive.");
                if (value < 0) throw new InvalidOperationException("La ligne de crédit doit rester positive.");
                _ligneDeCredit = value;
            }
        }
        public Courant(string numero, Personne titulaire) : base(numero, titulaire)
        {
        }

        public Courant(string numero, Personne titulaire, double solde) : base(numero, titulaire, solde)
        {
        }
        public Courant(string numero, double ligneDeCredit, Personne titulaire) : base(numero, titulaire)
        {
            LigneDeCredit = ligneDeCredit;
        }
        public Courant(string numero, double ligneDeCredit, Personne titulaire, double solde) : base(numero, titulaire, solde)
        {
            LigneDeCredit = ligneDeCredit;
        }


        public override void Retrait(double montant)
        {
            bool passeEnNegatif = Solde >= 0;
            Retrait(montant, LigneDeCredit);
            passeEnNegatif = passeEnNegatif && Solde < 0;
            if (passeEnNegatif) PassageEnNegatifRaise(this);
        }

        protected override double CalculInteret()
        {
            return Solde > 0 ? Solde * 0.03 : Solde * 0.0975;
        }
    }
}
