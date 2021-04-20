using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capapresentacion
{
    public partial class FrmTiempos : Form
    {
        public FrmPrincipal frmparent;
        public FrmTiempos()
        {
            InitializeComponent();
            btnEliminarTiempo.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            mostrartiempos();
           // quitarBordes();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmparent.lanzarNuevoProyecto(new FrmDetalleTiempos());
        }

        public void mostrartiempos()
        {
            //this.dataListTiempos.DataSource = NProyecto.mostrarproyectos();
           // this.ocultarcolumnas();
           // this.btnEliminarProyecto.Visible = true;
           // this.lblTotal.Text = "Número de proyectos: " + Convert.ToString(dataListProyectos.Rows.Count);
        }

        private void dataListTiempos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListTiempos.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)dataListTiempos.Rows[e.RowIndex].Cells["Eliminar"];
                chkeliminar.Value = !Convert.ToBoolean(chkeliminar.Value);
            }
        }

        private void dataListTiempos_CellDoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmDetalleProyecto detalleProyecto = new FrmDetalleProyecto();

                detalleProyecto.visualizaDatos(
                    Convert.ToString(this.dataListTiempos.CurrentRow.Cells["id"].Value),
                    Convert.ToString(this.dataListTiempos.CurrentRow.Cells["id_tarea"].Value),
                    Convert.ToString(this.dataListTiempos.CurrentRow.Cells["fecha_inicio"].Value),
                    Convert.ToString(this.dataListTiempos.CurrentRow.Cells["fecha_fin"].Value),
                    Convert.ToString(this.dataListTiempos.CurrentRow.Cells["observaciones"].Value)                    
                    );

                frmparent.lanzarNuevoProyecto(detalleProyecto);

            }
            catch (Exception)
            {
                MessageBox.Show("Error en el evento Double click ", "Error en el evento Double click ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
