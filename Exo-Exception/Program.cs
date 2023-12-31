using Demo_Exception_02.Exceptions;
using Demo_Exception_02.Models;

namespace Demo_Exception_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Produit pdt01 = new Produit("Chocolat", 5);
            Produit pdt02 = new Produit("Coockie", 2);
            Produit pdt03 = new Produit("Piñata", 1);

            Panier panierClient = new Panier();

            try
            {
                panierClient.AddProduct(pdt01);
                panierClient.AddProduct(pdt01);
                panierClient.AddProduct(pdt01);
                panierClient.AddProduct(pdt01);
                panierClient.AddProduct(pdt01);
                panierClient.AddProduct(pdt02);
                panierClient.AddProduct(pdt02);
                panierClient.AddProduct(pdt03);
                panierClient.AddProduct(pdt01);
            }
            catch (OutOfStockException outEx)
            {
                Console.WriteLine(outEx.Message);
                Console.WriteLine($"Voulez-vous réapprovisionner le produit {outEx.PdtOutOfStock.Name}?");
                //... suite code
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
