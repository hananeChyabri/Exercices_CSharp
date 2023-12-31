using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_Exception_02.Models;

namespace Demo_Exception_02.Exceptions
{
    internal class OutOfStockException : Exception
    {
        private Produit _pdtOutOfStock;
        public Produit PdtOutOfStock
        {
            get { return _pdtOutOfStock; }
        }

        public OutOfStockException(Produit pdtOutOfStock) : this($"Le stock de {pdtOutOfStock.Name} doit rester positif.")
        {
            _pdtOutOfStock = pdtOutOfStock;
        }
        public OutOfStockException(string message) : base(message) { }

        public OutOfStockException() : base("Le stock doit rester positif.") { }
    }
}
