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
        private int _id_tarea;
        private DateTime _fecha_inicio;
        private DateTime _fecha_fin;
        private string _observaciones;

        public int Id { get => _id; set => _id = value; }
        
        public int Id_tarea { get => _id_tarea; set => _id_tarea = value; }
        //Posiblemente tenga que cambiar el tipo de datos a string por que desde el combobox me llegará un string
        public DateTime Fecha_inicio { get => _fecha_inicio; set => _fecha_inicio = value; }
        public DateTime Fecha_fin { get => _fecha_fin; set => _fecha_fin = value; }
        public string Observaciones { get => _observaciones; set => _observaciones = value; }

        public DTiempo()
        {

        }
        public DTiempo(int id, int id_tarea, DateTime fecha_inicio, DateTime fecha_fin, string observaciones)
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

        public string insertartiempo(DTiempo tiempo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_tiempo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Definición de atributos

                //id
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId);


                //id_tarea
                SqlParameter ParIdTarea = new SqlParameter();
                ParIdTarea.ParameterName = "@id_tarea";
                ParIdTarea.SqlDbType = SqlDbType.Int;
                ParIdTarea.Value = tiempo.Id_tarea;
                //Posiblemente tenga que cambiar el tipo de datos a string por que desde el combobox me llegará un string
                SqlCmd.Parameters.Add(ParIdTarea);


                //fecha_inicio
                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@fecha_inicio";
                ParFechaInicio.SqlDbType = SqlDbType.SmallDateTime;
                //ParFecha.Size = 1024;
                ParFechaInicio.Value = tiempo.Fecha_inicio;
                SqlCmd.Parameters.Add(ParFechaInicio);


                //fecha_fin
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fecha_fin";
                ParFechaFin.SqlDbType = SqlDbType.SmallDateTime;
                //ParFecha.Size = 1024;
                ParFechaFin.Value = tiempo.Fecha_fin;
                SqlCmd.Parameters.Add(ParFechaFin);

                //observaciones
                SqlParameter ParObservaciones = new SqlParameter();
                ParObservaciones.ParameterName = "@observaciones";
                ParObservaciones.SqlDbType = SqlDbType.NText;
                //ParObservaciones.Size = 1024;
                ParObservaciones.Value = tiempo.Observaciones;
                SqlCmd.Parameters.Add(ParObservaciones);


                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No es posible insertar el Proyecto";

                return rpta;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }
            return rpta;
        }

        //Método editar Tiempo
        public string editartiempo(DTiempo tiempo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_tiempo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Definición de atributos

                //id
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Direction = ParameterDirection.Output;//TODO pendiente verificar si es necesario especificar el parámetro de salida
                SqlCmd.Parameters.Add(ParId);


                //id_tarea
                SqlParameter ParIdTarea = new SqlParameter();
                ParIdTarea.ParameterName = "@id_tarea";
                ParIdTarea.SqlDbType = SqlDbType.Int;
                ParIdTarea.Value = tiempo.Id_tarea;
                //TODO Posiblemente tenga que cambiar el tipo de datos a string por que desde el combobox me llegará un string
                SqlCmd.Parameters.Add(ParIdTarea);


                //fecha_inicio
                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@fecha_inicio";
                ParFechaInicio.SqlDbType = SqlDbType.SmallDateTime;
                //ParFecha.Size = 1024;
                ParFechaInicio.Value = tiempo.Fecha_inicio;
                SqlCmd.Parameters.Add(ParFechaInicio);


                //fecha_fin
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fecha_fin";
                ParFechaFin.SqlDbType = SqlDbType.SmallDateTime;
                //ParFecha.Size = 1024;
                ParFechaFin.Value = tiempo.Fecha_fin;
                SqlCmd.Parameters.Add(ParFechaFin);

                //observaciones
                SqlParameter ParObservaciones = new SqlParameter();
                ParObservaciones.ParameterName = "@observaciones";
                ParObservaciones.SqlDbType = SqlDbType.NText;
                //ParObservaciones.Size = 1024;
                ParObservaciones.Value = tiempo.Observaciones;
                SqlCmd.Parameters.Add(ParObservaciones);


                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No es posible insertar el Proyecto";

                return rpta;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }
            return rpta;
        }

        //Método eliminar proyecto
        public string eliminartiempo(DTiempo tiempo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_tiempo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Definición de atributos

                //id
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = tiempo.Id;
                SqlCmd.Parameters.Add(ParId);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No es posible eliminar el Proyecto";

                return rpta;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }
            return rpta;
        }


        //Método buscar proyecto por codigo
        public DataTable buscarproyecto(DProyecto proyecto)
        {
            DataTable dtresultado = new DataTable("proyecto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proyectos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Buscar proyecto por codigo
                SqlParameter ParTextobuscar = new SqlParameter();
                ParTextobuscar.ParameterName = "@textobuscar";
                ParTextobuscar.SqlDbType = SqlDbType.VarChar;
                ParTextobuscar.Size = 10;
                ParTextobuscar.Value = proyecto.Textobuscar;
                SqlCmd.Parameters.Add(ParTextobuscar);

                SqlDataAdapter sqladap = new SqlDataAdapter(SqlCmd);
                sqladap.Fill(dtresultado);//es el que se encarga de rellenar nuestra tabla con el procedimiento almacenado


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
