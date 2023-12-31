using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_CarWash.Models
{
    internal class Voiture
    {
        public string Plaque { get; private set; }

        public Voiture(string plaque)
        {
            Plaque = plaque;
        }
    }
}
