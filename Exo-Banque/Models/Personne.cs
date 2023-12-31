using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Banque.Models
{
    internal class Personne
    {

        /* Equivalant à l'auto-propriété
        private string _nom;

        public string Nom { 
           get { return _nom; } 
           set { _nom = value; } 
        }
        */
        public string Nom { get; private set; }
        public string Prenom { get; private set; }

        public DateTime DateNaiss { get; private set; }
        /// <summary>
        /// Création d'une instance de la class Personne.
        /// </summary>
        /// <param name="nom">Correspond au nom de famille</param>
        /// <param name="prenom">Correspond au prénom</param>
        /// <param name="dateNaiss">Correspond à la date de naissance</param>
        public Personne(string nom, string prenom, DateTime dateNaiss)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaiss = dateNaiss;
        }

    }
}
