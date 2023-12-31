using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Exo_CarWash.Models
{
    internal delegate void CarWashAction(Voiture v);
    internal class CarWash
    {
        private CarWashAction _traitement;

        public CarWash()
        {
            #region Exo 1
            //_traitement = Preparer;
            //_traitement += Laver;
            //_traitement += Secher;
            //_traitement += Finaliser; 
            #endregion

            #region Exo 2
            _traitement = delegate (Voiture v) { Console.WriteLine($"Je prépare la voiture : {v.Plaque}"); };
            _traitement += delegate (Voiture v) { Console.WriteLine($"Je lave la voiture : {v.Plaque}"); };
            _traitement += delegate (Voiture v) { Console.WriteLine($"Je sèche la voiture : {v.Plaque}"); };
            _traitement += delegate (Voiture v) { Console.WriteLine($"Je finalise la voiture : {v.Plaque}"); };
            #endregion
            /*    Démo avec cire
            LavageClassique();
            */
        }


        #region Exo 1
        //private void Preparer(Voiture v) {
        //    Console.WriteLine($"Je prépare la voiture : {v.Plaque}");
        //}
        //private void Laver(Voiture v)
        //{
        //    Console.WriteLine($"Je lave la voiture : {v.Plaque}");
        //}
        //private void Secher(Voiture v)
        //{
        //    Console.WriteLine($"Je sèche la voiture : {v.Plaque}");
        //}
        //private void Finaliser(Voiture v)
        //{
        //    Console.WriteLine($"Je finalise la voiture : {v.Plaque}");
        //} 
        #endregion
        public void Traiter(Voiture v)
        {
            if(_traitement != null ) _traitement(v);
            //OU
            //_traitement?.Invoke(v);
        }

        #region Démonstration avec Cire
        //private void Cirer(Voiture v)
        //{
        //    Console.WriteLine($"J'applique de la cire sur la voiture : {v.Plaque}");
        //}

        //public void LavageClassique()
        //{
        //    _traitement = Preparer;
        //    _traitement += Laver;
        //    _traitement += Secher;
        //    _traitement += Finaliser;
        //}
        //public void LavageAvecCire()
        //{
        //    _traitement = Preparer;
        //    _traitement += Laver;
        //    _traitement += Cirer;
        //    _traitement += Secher;
        //    _traitement += Finaliser;
        //} 
        #endregion
    }
}
