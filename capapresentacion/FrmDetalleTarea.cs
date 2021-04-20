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
            
        bool esnuevo = false;
        bool eseditar = false;
       
        public FrmDetalleTarea()
        {
            InitializeComponent();
            
        }

        public void mostrarProyectoCombobox()
        {
            comboboxProyecto.Items.AddRange(NTarea.mostrarProyectoCombobox().ToArray());
            comboboxProyecto.SelectedIndex = 0;

        }

        public void mostrarEstadoCombobox()
        {
            comboboxEstado.Items.AddRange(NTarea.mostrarEstadoCombobox().ToArray());
            comboboxEstado.SelectedIndex = 0;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            mostrarProyectoCombobox();
            mostrarEstadoCombobox();
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esnuevo = true;
            botones();
            limpiar();
        }

        private void botones()
        {
            if (esnuevo || this.eseditar)
            {
                habilitar(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = false;
            }
        }

        private void limpiar()
        {
            this.txtIdTarea.Text = string.Empty;
            this.txtTituloTarea.Text = string.Empty;
            this.comboboxProyecto.Items.Clear();
            this.comboboxEstado.Items.Clear();
            dtFechaTarea.Text = string.Empty;
            this.txtHoras.Text = string.Empty;
            this.txtDescripcionTarea.Text = string.Empty;
            this.txtObservacionesTarea.Text = string.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            botones();
            limpiar();
            this.Hide();
        }
    }
}
