using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Exception_02.Models
{
    internal class Panier
    {
        private Dictionary<string, int> _content;

        public Panier()
        {
            _content = new Dictionary<string, int>();
        }

        public void AddProduct(Produit product)
        {
            if (product is null) throw new ArgumentNullException(nameof(product), "Le produit 'null' n'existe pas...");
            product.SubOne();
            if (_content.ContainsKey(product.Name))
            {
                _content[product.Name]++;
            }
            else
            {
                _content.Add(product.Name, 1);
            }
        }
    }
}
