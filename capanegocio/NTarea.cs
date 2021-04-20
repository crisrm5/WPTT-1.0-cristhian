using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capadatos;

namespace capanegocio
{
    public class NTarea
    {
        public static DataTable buscartareaTitulo(String textobuscar)
        {
            DTarea objeto = new DTarea();
            objeto.Textobuscar = textobuscar;
            return objeto.buscartareaTitulo(objeto);
        }

        public static DataTable buscartareaTecnico(String textobuscar)
        {
            DTarea objeto = new DTarea();
            objeto.Textobuscar = textobuscar;
            return objeto.buscartareaTecnico(objeto);
        }
        public static DataTable buscartareaProyecto(String textobuscar)
        {
            DTarea objeto = new DTarea();
            objeto.Textobuscar = textobuscar;
            return objeto.buscartareaProyecto(objeto);
        }
        public static DataTable buscartareaObservaciones(String textobuscar)
        {
            DTarea objeto = new DTarea();
            objeto.Textobuscar = textobuscar;
            return objeto.buscartareaObservaciones(objeto);
        }
        public static DataTable buscartareaFechaCreacion(String textobuscar)
        {
            DTarea objeto = new DTarea();
            objeto.Textobuscar = textobuscar;
            return objeto.buscartareaFechaCreacion(objeto);
        }
        public static DataTable buscartareaEstados(String textobuscar)
        {
            DTarea objeto = new DTarea();
            objeto.Textobuscar = textobuscar;
            return objeto.buscartareaEstados(objeto);
        }

        public static DataTable buscartareaDescripcion(String textobuscar)
        {
            DTarea objeto = new DTarea();
            objeto.Textobuscar = textobuscar;
            return objeto.buscartareaDescripcion(objeto);
        }
        public static DataTable mostrartareas()
        {
            DTarea objeto = new DTarea();
            return objeto.mostrartarea(objeto);
        }

        public static string eliminarTarea(int id)
        {
            DTarea objeto = new DTarea();
            objeto.Id = id;

            return objeto.eliminarTarea(objeto);
        }

        public static string editarTarea(int id, string titulo,string proyecto,string descripcion, string observaciones, string estado,DateTime fecha)
        {
            DTarea objeto = new DTarea();
            objeto.Id = id;
            objeto.Titulo = titulo;
            objeto.Proyecto = proyecto;
            objeto.Descripcion = descripcion;
            objeto.Observaciones = observaciones;
            objeto.Estado = estado;
            objeto.Fecha = fecha;

            return objeto.editarTarea(objeto);
        }


        public static String mostrarProyectoCombobox()
        {
            DTarea objeto = new DTarea();
            return objeto.mostrarProyectoCombobox(objeto);
        }
    }
}
