using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo_Banque.Models;

namespace Exo_Banque.Interfaces
{
    internal interface IBanker : ICustomer
    {
        string Numero { get; }
        Personne Titulaire { get; }
        void AppliquerInteret();
    }
}
