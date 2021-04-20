using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capadatos
{
    class DTiempo
    {
        private int _id;
        private string _id_tarea;
        private DateTime _fecha_inicio;
        private DateTime _fecha_fin;
        private string _observaciones;

        public int Id { get => _id; set => _id = value; }
        public string Id_tarea { get => _id_tarea; set => _id_tarea = value; }
        public DateTime Fecha_inicio { get => _fecha_inicio; set => _fecha_inicio = value; }
        public DateTime Fecha_fin { get => _fecha_fin; set => _fecha_fin = value; }
        public string Observaciones { get => _observaciones; set => _observaciones = value; }

        public DTiempo()
        {

        }
        public DTiempo(int id, string id_tarea, DateTime fecha_inicio, DateTime fecha_fin, string observaciones)
        {
            _id = id;
            _id_tarea = id_tarea;
            _fecha_inicio = fecha_inicio;
            _fecha_fin = fecha_fin;
            _observaciones = observaciones;
        }

        public DataTable mostrartiempo(DTiempo objeto)
        {
            DataTable dtresultado = new DataTable("tiempos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_tiempos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqladap = new SqlDataAdapter(SqlCmd);//es el que se encarga de rellenar nuestra tabla con el procedimiento almacenado
                sqladap.Fill(dtresultado);


            }
            catch (Exception)
            {
                dtresultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }

            return dtresultado;
        }

    }
}
