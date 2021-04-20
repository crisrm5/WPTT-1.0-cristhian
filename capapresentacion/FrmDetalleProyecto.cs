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
    public partial class FrmDetalleProyecto : Form
    {
        bool esnuevo = false;
        bool eseditar = false;
        public string idproyecto = "";
        public FrmDetalleProyecto()
        {
            InitializeComponent();
        }
        private void mensajeok(string mensaje)
        {
            MessageBox.Show(mensaje,"Detalle de Proyecto",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }

        private void mensajeerror(string mensaje)
        {
            MessageBox.Show(mensaje, "Detalle de Proyecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //sss
        private void limpiar()
        {
            this.txtIdProyecto.Text = string.Empty;
            this.txtTituloProyecto.Text = string.Empty;
            //this.txtProyecto.Text = string.Empty;
            //this.dtFechaProyecto.Text = string.Empty;
            //this.dtFechaProyecto.ResetText();//TODO pendiente por probar el Reset
            this.txtObservacionesProyecto.Text = string.Empty;
            this.txtDescripcionProyecto.Text = string.Empty;
            this.dtFechaProyecto.Text = string.Empty;
        }

        private void habilitar(bool valor)
        {
            this.txtIdProyecto.ReadOnly = true;
            this.txtTituloProyecto.ReadOnly = !valor;
           // this.txtProyecto.ReadOnly = !valor;
            this.txtObservacionesProyecto.ReadOnly = !valor;
            this.txtDescripcionProyecto.ReadOnly = !valor;
            this.dtFechaProyecto.Enabled = valor;
            
        }
        
        private void botones()
        {
            if(esnuevo || this.eseditar)
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

      
        private void FrmDetalleProyecto_Load(object sender, EventArgs e)
        {
            this.botones();
            this.FormClosed += new FormClosedEventHandler(cerrarX);
        }

        private void cerrarX(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = new FrmPrincipal();
            this.Hide();
            frmPrincipal.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esnuevo = true;
            botones();
            limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if(this.txtTituloProyecto.Text==string.Empty)
                {
                    mensajeerror("Formulario incompleto");
                    this.iconoerror.SetError(this.txtTituloProyecto, "Ingresar Título");
                }
                else
                {
                    if (esnuevo)
                    {
                        rpta = NProyecto.insertarproyecto(this.txtTituloProyecto.Text.Trim().ToUpper(), this.txtDescripcionProyecto.Text.Trim(),this.txtObservacionesProyecto.Text.Trim(),Convert.ToDateTime(this.dtFechaProyecto.Value));
                    }
                    else
                    {

                        rpta = NProyecto.editarproyecto(Convert.ToInt32(this.txtIdProyecto.Text),this.txtTituloProyecto.Text.Trim().ToUpper(), this.txtDescripcionProyecto.Text.Trim(), this.txtObservacionesProyecto.Text.Trim(), Convert.ToDateTime(this.dtFechaProyecto.Value));
                        //rpta = NProyecto.editarproyecto(
                        //    Convert.ToInt32(this.txtIdProyecto.Text),
                        //    this.txtTituloProyecto.Text.Trim().ToUpper(),
                        //    this.txtObservacionesProyecto.Text.Trim(),
                        //    this.dtFechaProyecto.Value);

                    }

                    if (rpta.Equals("OK"))
                    {
                        if (esnuevo)
                        {
                            this.mensajeok("Se ha creado el proyecto satisfactoriamente");
                        }
                        else
                        {
                            this.mensajeok("Se ha editado el proyecto satisfactoriamente");
                        }
                        
                    }
                    else {
                        this.mensajeerror(rpta);
                    }
   
                    this.esnuevo = false;
                    this.eseditar = false;
                    botones();
                    this.limpiar();
                    //FrmPrincipal.mostrarproyectos();
                   
                    //TODO es necesario mostrar los proyectos desde detalleProyecto?

             
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdProyecto.Text.Equals(""))
            {
                this.eseditar = true;
                this.botones();
                MessageBox.Show("Hola cristhian lo he subido desde GitHub");

                
            }
            else
            {
                this.mensajeerror("selleccione el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            botones();
            limpiar();
            this.Hide();
        }

        private void txtIdProyecto_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void visualizaDatos(string id, string proyecto, string descripcion, string observaciones,string fecha_creacion)
        {
            //txtIdProyecto.Text = idproyecto;
            this.txtIdProyecto.Text = id;
           // this.txtProyecto.Text = codigo_proyecto;
            this.txtTituloProyecto.Text = proyecto;
            this.txtObservacionesProyecto.Text = observaciones;
            this.txtDescripcionProyecto.Text = descripcion;
            this.dtFechaProyecto.Text = fecha_creacion;
            
        }

        //public void visualizaDatos()
        //{
        //    this.txtIdProyecto.Text = id;
        //    this.txtProyecto.Text = codigo_proyecto;
        //    this.txtTituloProyecto.Text = titulo;
        //    this.txtObservacionesProyecto.Text = observaciones;
        //    this.dtFechaProyecto.Text = "14/05/2020";
        //}

        private void txtObservacionesProyecto_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtFechaProyecto_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
