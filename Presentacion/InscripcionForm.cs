using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class RentaVehiculosForm : Form
    {
        GimnasioNegocio gimnasioNegocio = new GimnasioNegocio();
        public RentaVehiculosForm()
        {
            InitializeComponent();
        }

        private void RentaVehiculosForm_Load(object sender, EventArgs e)
        {
            MtdConsultarInscripcion();

            MtdFilaSeleccionada(false);
        }

        /*  ----- CONSULTAR -----   */

        // Consultar datos de la tabla e imprimir en DataGridView
        private void MtdConsultarInscripcion()
        {
            try
            {
                dgvInscripcionGim.DataSource = gimnasioNegocio.MtdConsultarInscripcion();
                dgvInscripcionGim.ClearSelection();
                dgvInscripcionGim.CurrentCell = null;
                MtdActualizarTotalRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Contar lineas del DataGridView
        private void MtdActualizarTotalRegistros()
        {
            int total = dgvInscripcionGim.Rows.Count;

            lblTotalRegistros.Text = $"Cantidad registros: {total}";
        }


        /*  ----- BOTON NUEVO Y CANCELAR -----   */

        private void MtdFilaSeleccionada(bool estado)
        {
            btnEditar.Enabled = estado;
            btnEliminar.Enabled = estado;
            btnCancelar.Enabled = estado;
            btnImprimir.Enabled = estado;
            btnNuevo.Enabled = estado;
            btnGuardar.Enabled = estado;

            txtCodigoInscripcion.Enabled = estado;
            cboxCodigoCliente.Enabled = estado;
            cboxTipoMembresia.Enabled = estado;
            cboxCodigoEntrenador.Enabled = estado;
            nudCantidadMeses.Enabled = estado;
            dtpFechaInicio.Enabled = estado;
            nudCostoMensual.Enabled = estado;
            nudCostoTotal.Enabled = estado;
            nudDescuento.Enabled = estado;
            nudSubtotal.Enabled = estado;
            nudImpuesto.Enabled = estado;
            nudTotalPagar.Enabled = estado;

        }



        private void MtdEstadoBotonNuevo()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = false;


            txtCodigoInscripcion.Enabled = false;
            cboxCodigoCliente.Enabled = true;
            cboxTipoMembresia.Enabled = false;
            cboxCodigoEntrenador.Enabled = false;
            nudCantidadMeses.Enabled = false;
            dtpFechaInicio.Enabled = false;
            nudCostoMensual.Enabled = false;
            nudCostoTotal.Enabled = false;
            nudDescuento.Enabled = false;
            nudSubtotal.Enabled = true;
            nudImpuesto.Enabled = true;
            nudTotalPagar.Enabled = true;
        }

        private void MtdLimpiarControlesForm()
        {
            txtCodigoInscripcion.Clear();
            cboxCodigoCliente.Items.Clear();
            cboxTipoMembresia.SelectedIndex = -1;
            cboxCodigoEntrenador.SelectedIndex = -1;
            nudCantidadMeses.Value = 0;

            dtpFechaInicio.Value = DateTime.Today;
            nudCostoMensual.Value = 0;
            nudCostoTotal.Value = 0;
            nudDescuento.Value = 0;
            nudSubtotal.Value = 0;
            nudImpuesto.Value = 0;
            nudTotalPagar.Value = 0;


            dgvInscripcionGim.ClearSelection();
            dgvInscripcionGim.CurrentCell = null;

            foreach (DataGridViewRow row in dgvInscripcionGim.Rows)
            {
                row.Cells["Seleccionar"].Value = false;
                row.DefaultCellStyle.BackColor = Color.White;

            }
        }


        /*  ----- AGREGAR -----   */

        // Validar que los datos estén correctos
        private bool MtdValidaDatos()
        {
            return true;
        }












    }
}
