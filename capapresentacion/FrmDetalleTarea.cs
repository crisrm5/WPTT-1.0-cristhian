using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            //mostrarProyectoCombobox();
        }

        public void mostrarProyectoCombobox()
        {
           // String[] protectos = NTarea.mostrarProyectoCombobox().ToString().ToArray;
            //comboboxProyecto.Items.AddRange(NTarea.mostrarProyectoCombobox().ToArray());
            comboboxProyecto.Items.AddRange(NTarea.mostrarProyectoCombobox().ToArray());
            comboboxProyecto.SelectedIndex = 0;




        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
        public void visualizaDatos(string id,string proyecto,string tarea,string descripcion,string observaciones,string fecha_creacion,string estado)
        {

            txtIdTarea.Text = id;
            txtTituloTarea.Text = tarea;
            comboboxProyecto.Items.Add(proyecto);
            comboboxProyecto.SelectedIndex = 0;
            txtDescripcionTarea.Text = descripcion;
            txtObservacionesTarea.Text = observaciones;
            dtFechaTarea.Text = fecha_creacion;
            comboboxEstado.Items.Add(estado);
            comboboxEstado.SelectedIndex = 0;
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

        private void comboboxProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
