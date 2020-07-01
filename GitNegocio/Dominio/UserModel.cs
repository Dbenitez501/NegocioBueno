using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Dominio
{
    public class UserModel
    {
        UserData user = new UserData();

        public string UserLogin(string id, string pass)
        {
            /*Le enviamos al método Login de UserData los valores de los campos de texto
             y a su vez nos regresa si el usuario está activado o no*/
            return user.Login(id, pass);
        }
    }
}
