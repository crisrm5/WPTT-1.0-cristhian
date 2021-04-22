using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capadatos
{
    public class DLogin
    {
        private string usuario;
        private string conexionbd;

        public DLogin(string usuario, string conexionbd)
        {
            this.usuario = usuario;
            this.conexionbd = conexionbd;
        }

        public DLogin()
        {

        }


        public string Usuario { get => usuario; set => usuario = value; }
        public string Conexionbd { get => conexionbd; set => conexionbd = value; }
    }
}
