using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capanegocio;

namespace capapresentacion
{
    public partial class FrmDetalleTarea : Form
    {

        public FrmDetalleTarea()
        {
            InitializeComponent();
            mostrarProyectoCombobox();
        }

        private void mostrarProyectoCombobox()
        {
            NTarea tarea = new NTarea();
           // tarea.mostrarProyectoCombobox();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
        public void visualizaDatos(string id,string proyecto,string tarea,string descripcion,string observaciones,string fecha_creacion,string estado)
        {

            txtIdTarea.Text = id;
            txtTituloTarea.Text = tarea;
            txtProyecto.Text = proyecto;
            txtDescripcionTarea.Text = descripcion;
            txtObservacionesTarea.Text = observaciones;
            dtFechaTarea.Text = fecha_creacion;
            txtEstado.Text = estado;
            //txtAplicacion.Text = aplicacion;
            //txtObservacionesTarea.Text=o
            //txtHoras.Text=



        }


        private void habilitar(bool valor)
        {
            this.txtIdTarea.ReadOnly = true;
            this.txtTituloTarea.ReadOnly = true;
            //this.txtnombre.ReadOnly = !valor;
            //this.txtapellidos.ReadOnly = !valor;
            //this.txtdocumento.ReadOnly = !valor;
            //this.txtdireccion.ReadOnly = !valor;
            //this.cbosexo.Enabled = valor;
            //this.cbotipodocumento.Enabled = valor;
            //this.dtfechanacimiento.Enabled = valor;

        }

        private void txtAplicacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmDetalleTarea_Load(object sender, EventArgs e)
        {

        }
    }
}
