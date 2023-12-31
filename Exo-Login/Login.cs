using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Login
{
    //internal delegate void LoginEventHandler(string message, bool isSucceed);
    internal class Login
    {
        private string _email;
        private string _password;

        //public event LoginEventHandler LoginEvent = null;
        public event Action<string, bool> LoginEvent = null;

        public Login(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public void CheckLogin(string email, string password)
        {
            if (_email == email && _password == password) LoginEvent?.Invoke("Bienvenu!", true);
            else LoginEvent?.Invoke("L'email et/ou le mot de passe ne correspond pas...", false);
        }
    }
}
