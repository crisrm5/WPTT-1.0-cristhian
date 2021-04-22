using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capadatos;

namespace capanegocio
{
   
    public class NLogin
    {
        DLogin login = new DLogin();
        public DLogin informacionLogin(String datos,String conexionBD)
        {
            login.Usuario = datos;
            login.Conexionbd = conexionBD;
            return login;
        }
    }
}
