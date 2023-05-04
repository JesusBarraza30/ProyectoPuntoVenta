using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta
{
    class User
    {
        private string userName;
        private string passWord;

        public User(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }

        public string pUserName
        {
            get { return userName; }
        }

        public string pPassWord
        {
            get { return passWord; }
        }
    }
}
