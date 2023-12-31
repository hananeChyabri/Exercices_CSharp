using Demo_Exception_02.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Exception_02.Models
{
    internal class Produit
    {
        private int _stock;
        public string Name { get; private set; }
        public int Stock
        {
            get
            { return _stock; }
            private set
            {
                if (value < 0) throw new OutOfStockException(this);   //new ArgumentOutOfRangeException(nameof(Stock),"Le stock doit rester positif.");
                _stock = value;
            }
        }
        public Produit(string name, int stock)
        {
            Name = name;
            Stock = stock;
        }

        public void SubOne()
        {
            Stock--;
        }
    }
}
