using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Banque.Models
{
    internal class Banque
    {
        private Dictionary<string, Compte> _comptes = new Dictionary<string, Compte>();
        public string Nom { get; set; }
        public Compte this[string numero]
        {
            get
            {
                if (numero is null) return null;
                if (!_comptes.ContainsKey(numero)) return null;
                return _comptes[numero];
            }
            set
            {
                if (numero is null) return;
                if (value is null) return;
                if (!_comptes.ContainsKey(numero)) return;
                if (numero != value.Numero) return;
                _comptes[numero] = value;
            }
        }

        public void Ajouter(Compte compte)
        {
            if (compte is null) return;
            //Vu que nous sommes dans une class, les champs (variables membres) peuvent être initialisé, donc pas besoin de vérifier avec :
            //if (_comptes is null) _comptes = new Dictionary<string, Courant>();
            // OU encore :
            //_comptes ??= new Dictionary<string, Courant>();
            if (_comptes.ContainsKey(compte.Numero)) return;
            _comptes.Add(compte.Numero, compte);
            compte.PassageEnNegatifEvent += PassageEnNegatifAction;
        }

        public void Supprimer(string numero)
        {
            if (numero is null) return;
            if (!_comptes.ContainsKey(numero)) return;
            _comptes[numero].PassageEnNegatifEvent -= PassageEnNegatifAction;
            _comptes.Remove(numero);
        }

        public double AvoirDesComptes(Personne personne)
        {
            if (personne is null) return -1; //AvoirDesComptes est strictement positif, donc -1 est impossible, on garde -1 pour indiquer une erreur, plus tard utilisation des exceptions
            List<Compte> comptes = new List<Compte>();
            foreach (Compte compte in _comptes.Values)
            {
                if (compte.Titulaire == personne)
                {
                    comptes.Add(compte);
                }
            }
            if (comptes.Count <= 0) return -1; //Gérer les exceptions
            double avoir = 0;
            foreach (Compte compte in comptes)
            {
                avoir += compte;
            }
            return avoir;
        }

        private void PassageEnNegatifAction(Compte c)
        {
            Console.WriteLine($"Le compte {c.Numero} est passé en négatif...");
        }
    }
}
