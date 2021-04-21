﻿using System;
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
            
            botonesVisible(false);
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
            this.txtObservacionesProyecto.Text = string.Empty;
            this.txtDescripcionProyecto.Text = string.Empty;
            this.dtFechaProyecto.Text = string.Empty;

        }

        private void habilitar(bool valor)
        {
            this.txtIdProyecto.ReadOnly = true;
            this.txtTituloProyecto.ReadOnly = !valor;
            this.txtObservacionesProyecto.ReadOnly = !valor;
            this.txtDescripcionProyecto.ReadOnly = !valor;
            this.dtFechaProyecto.Enabled = valor;
            
        }
        
        private void botonesVisible(bool estado)
        {
            btnGuardar.Visible = estado;
            btnCancelar.Visible = estado;
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
            botonesVisible(true);
            setModo("CREACIÓN");
            botones();
            limpiar();
        }
        public void setModo(String modo)
        {
            lEdicion.Text = "[MODO " + modo + "]";
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
   
                    botonesVisible(false);
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
                setModo("EDICIÓN");
                //this.txtDescripcionProyecto.Visible = true;
                botonesVisible(true);

            }
            else
            {
                this.mensajeerror("selleccione el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            esnuevo = false;
            this.eseditar = false;
            botones();
            botonesVisible(false);
            //limpiar();
            //this.Hide();
            setModo("LECTURA");
        }

        private void txtIdProyecto_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void visualizaDatos(string id, string proyecto, string descripcion, string observaciones,string fecha_creacion)
        {
            
            this.txtIdProyecto.Text = id;
            this.txtTituloProyecto.Text = proyecto;
            this.txtObservacionesProyecto.Text = observaciones;

            this.txtDescripcionProyecto.Text = descripcion;
            //this.txtDescripcionProyecto.Visible = true;



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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcionProyecto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTituloProyecto_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblObservaciones_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTituloProyecto_Click(object sender, EventArgs e)
        {

        }

        private void lbl_idproyecto_Click(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
           /* Console.WriteLine("estamos detrno xabales");
            int cont = 0;
            string[] array =NProyecto.siguienteInforme(txtIdProyecto.Text);
           // NProyecto.siguienteInforme(txtIdProyecto.Text);
            foreach (string dato in array)
            {
                Console.WriteLine(array.Length);
                Console.WriteLine(dato);
                Console.WriteLine(cont);
                cont++;
            }*/
        }

        private void btnEliminarProyecto_Click(object sender, EventArgs e)
        {
            
            if (!lEdicion.Text.Equals(""))
            {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Desea continuar?", "Eliminar Proyecto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    int aux = 0;
                    int id;
                    string rpta = "";

                    rpta = NProyecto.eliminarproyecto(Convert.ToInt32(txtIdProyecto.Text));

                    if (rpta.Equals("OK"))
                    {
                        this.mensajeok("Registro eliminado");
                    }
                    else
                    {
                        this.mensajeerror("¡Ups!, Al parecer tienes tareas asignadas a este proyecto...");
                        this.mensajeerror(rpta);
                    }
                }

                /*if (aux < 1)
                {
                    MessageBox.Show("No haz seleccionado ningún proyecto", "Eliminar Proyecto", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                this.mostrarproyectos();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            }

        }

    }
}
