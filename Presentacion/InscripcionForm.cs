using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

            MtdEstadoFilaSeleccionada(false);
        }

        #region Codigo Consultar
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

        #endregion


        #region Funcionalidades Sistema
        /*  ----- BOTON NUEVO Y CANCELAR -----   */

        // Evento: Valida si hay fila seleccionada del DataGridView
        private void MtdEstadoFilaSeleccionada(bool estado)
        {
            btnEditar.Enabled = estado;
            btnEliminar.Enabled = estado;
            btnCancelar.Enabled = estado;
            btnImprimir.Enabled = estado;
            btnNuevo.Enabled = !estado;
            btnGuardar.Enabled = false;

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


        // Evento: Valida si dieron clic en el boton Nuevo
        private void MtdEstadoBotonNuevo()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;


            txtCodigoInscripcion.Enabled = false;
            cboxCodigoCliente.Enabled = true;
            cboxTipoMembresia.Enabled = true;
            cboxCodigoEntrenador.Enabled = true;
            nudCantidadMeses.Enabled = true;
            dtpFechaInicio.Enabled = true;
            nudCostoMensual.Enabled = true;
            nudCostoTotal.Enabled = true;
            nudDescuento.Enabled = true;
            nudSubtotal.Enabled = true;
            nudImpuesto.Enabled = true;
            nudTotalPagar.Enabled = true;
        }

        // Evento: Limpiar los controles del forms y DataGridView
        private void MtdLimpiarControlesForm()
        {
            txtCodigoInscripcion.Clear();
            cboxCodigoCliente.SelectedIndex = -1;
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

        



        //Boton Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdEstadoBotonNuevo();

            txtCodigoInscripcion.Focus();


        }

        //Boton Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdEstadoFilaSeleccionada(false);

        }

        /*  ----- DATAGRIDVIEW Y SELECCIONAR   ----- */

        // Cargar datos de la fila a los controles del form

        private void MtdCargarDatosFilaEnControlesForm(int filaSeleccionada)
        {
            // ---> CAMBIAR: Nombres por Controles del forms <----- //
            var inscripcion = (GimnasioEntidad)dgvInscripcionGim.Rows[filaSeleccionada].DataBoundItem;

            txtCodigoInscripcion.Text = inscripcion.CodigoInscripcion.ToString();
            cboxCodigoCliente.SelectedItem = inscripcion.CodigoCliente;
            cboxTipoMembresia.SelectedItem = inscripcion.CodigoTipoMembresia;
            cboxCodigoEntrenador.SelectedItem = inscripcion.CodigoEntrenador;
            nudCantidadMeses.Value = inscripcion.Meses;

            dtpFechaInicio.Value = inscripcion.FechaInicio;

            nudCostoMensual.Value = inscripcion.CostoMensual;
            nudCostoTotal.Value = inscripcion.CostoTotal;
            nudDescuento.Value = inscripcion.Descuento;
            nudSubtotal.Value = inscripcion.SubTotal;
            nudImpuesto.Value = inscripcion.Impuesto;
            nudTotalPagar.Value = inscripcion.TotalPagar;

        }

        // Activar fila seleccionada
        private int? filaActiva = null;
        private void MtdActivarFilaSeleccionada(int filaSeleccionada)
        {
           
            if (filaActiva.HasValue)
            {
                dgvInscripcionGim.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvInscripcionGim.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = filaSeleccionada;

            dgvInscripcionGim.Rows[filaSeleccionada].Cells["Seleccionar"].Value = true;
            dgvInscripcionGim.Rows[filaSeleccionada].DefaultCellStyle.BackColor = Color.FromArgb(220, 235, 255);

            MtdCargarDatosFilaEnControlesForm(filaSeleccionada);
            MtdEstadoFilaSeleccionada(true);
        }

        // Desactivar fila seleccionada
        private void MtdDesactivaFilaSeleccionada()
        {
            // ---> CAMBIAR: Nombre del DataGridView <----- //
            if (filaActiva.HasValue)
            {
                dgvInscripcionGim.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvInscripcionGim.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = null;

            MtdLimpiarControlesForm();
            MtdEstadoFilaSeleccionada(false);
        }

        // Evento DataGridView
        private void dgvInscripcionGim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvInscripcionGim.Columns[e.ColumnIndex].Name != "Seleccionar")
                return;

            if (!chkSeleccionar.Checked)
                return;

            bool seleccionado = Convert.ToBoolean(
                dgvInscripcionGim.Rows[e.RowIndex].Cells["Seleccionar"].Value ?? false);

            if (seleccionado)
                MtdDesactivaFilaSeleccionada();
            else
                MtdActivarFilaSeleccionada(e.RowIndex);

        }

        // Evento CheckBox Seleccionar
        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            dgvInscripcionGim.Columns["Seleccionar"].ReadOnly = !chkSeleccionar.Checked;
            btnEditar.Enabled = chkSeleccionar.Checked;

            MtdDesactivaFilaSeleccionada();

        }

        // Ultimo Paso, Agregar MtdEstadoFilaSelecionada en el evento Form. que esta en el inicio
        #endregion


        #region Codigo Agregar
        /*  ----- AGREGAR -----   */

        // Validar que los datos estén correctos
        private bool MtdValidaDatos()
        {
            return true;
        }


        // Boton Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MtdValidaDatos() == false)
                return;

            try
            {



                GimnasioEntidad inscripcion = new GimnasioEntidad
                {
                    //CodigoInscripcion = Convert.ToInt32(txtCodigoInscripcion.Text.Trim()),
                    CodigoCliente = Convert.ToInt32(cboxCodigoCliente.SelectedItem.ToString()),
                    CodigoTipoMembresia = Convert.ToInt32(cboxTipoMembresia.SelectedItem.ToString()),
                    CodigoEntrenador = Convert.ToInt32(cboxCodigoEntrenador.SelectedItem.ToString()),
                    Meses = Convert.ToInt32(nudCantidadMeses.Value),
                    FechaInicio = dtpFechaInicio.Value,

                    

                    CostoMensual = Convert.ToDecimal(nudCostoMensual.Value),
                    CostoTotal = Convert.ToDecimal(nudCostoTotal.Value),
                    Descuento = Convert.ToDecimal(nudDescuento.Value),
                    SubTotal = Convert.ToDecimal(nudSubtotal.Value),
                    Impuesto = Convert.ToDecimal(nudImpuesto.Value),
                    TotalPagar = Convert.ToDecimal(nudTotalPagar.Value),



                };

                gimnasioNegocio.MtdAgregarInscripcion(inscripcion);
                MessageBox.Show("Inscripcion agregada correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarInscripcion();
                MtdEstadoFilaSeleccionada(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        #endregion


        #region Codigo Editar
        /*  ----- EDITAR -----   */

        //Boton Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoInscripcion.Text))
            {
                MessageBox.Show("Seleccione una inscripcion para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            if (MtdValidaDatos() == false)
                return;

            try
            {


                GimnasioEntidad inscripcion = new GimnasioEntidad
                {
                    //Agregar
                    CodigoInscripcion = int.Parse(txtCodigoInscripcion.Text),


                    //Este codigo esta en el boton Guardar
                    CodigoCliente = Convert.ToInt32(cboxCodigoCliente.SelectedItem.ToString()),
                    CodigoTipoMembresia = Convert.ToInt32(cboxTipoMembresia.SelectedItem.ToString()),
                    CodigoEntrenador = Convert.ToInt32(cboxCodigoEntrenador.SelectedItem.ToString()),
                    Meses = Convert.ToInt32(nudCantidadMeses.Value),
                    FechaInicio = dtpFechaInicio.Value,


                    CostoMensual = Convert.ToDecimal(nudCostoMensual.Value),
                    CostoTotal = Convert.ToDecimal(nudCostoTotal.Value),
                    Descuento = Convert.ToDecimal(nudDescuento.Value),
                    SubTotal = Convert.ToDecimal(nudSubtotal.Value),
                    Impuesto = Convert.ToDecimal(nudImpuesto.Value),
                    TotalPagar = Convert.ToDecimal(nudTotalPagar.Value),

                };

                gimnasioNegocio.MtdEditarInscripcion(inscripcion);
                MessageBox.Show("inscripcion editado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarInscripcion();
                MtdEstadoFilaSeleccionada(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        #endregion


        //No contiene nada, al momento lo subira carlos
        #region Codigo Eliminar
        #endregion

        #region Codigo BuscarLimpiar
        /*  ----- BUSCAR / LIMPIAR  ----- */

        //Boton buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int CodigoCliente;

            CodigoCliente = Convert.ToInt32(txtBuscarNombre.Text);

            try
            {
                List<GimnasioEntidad> lista = gimnasioNegocio.MtdBuscarInscripcion(CodigoCliente);

                dgvInscripcionGim.DataSource = lista;

                MtdLimpiarControlesForm();
                MtdEstadoFilaSeleccionada(false);
                MtdActualizarTotalRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //Boton limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            {
                txtBuscarNombre.Clear();
                MtdConsultarInscripcion();

                MtdLimpiarControlesForm();
                MtdEstadoFilaSeleccionada(false);
                MtdActualizarTotalRegistros();
            }



        }



        #endregion


        #region Codigo Imprimir
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font tituloFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 11);
            Brush brush = Brushes.Black;

            float y = 40;
            float margenizquierdo = 50;

            // ---> CAMBIAR: cambiar nombres a controles y titutlo

            e.Graphics.DrawString("DATOS DE LA INSCRIPCION", textFont, brush, margenizquierdo, y); y += 40;


            e.Graphics.DrawString($"CodigoInscripcion: {txtCodigoInscripcion.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"CodigoCliente: {cboxCodigoCliente.SelectedItem}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"CodigoTipoMembresia: {cboxTipoMembresia.SelectedItem}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"CodigoEntrenador: {cboxCodigoEntrenador.SelectedItem}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Meses: {nudCantidadMeses.Value}", textFont, brush, margenizquierdo, y); y += 25;

            e.Graphics.DrawString($"FechaInicio: {dtpFechaInicio.Value:d}", textFont, brush, margenizquierdo, y); y += 25;

            e.Graphics.DrawString($"CostoMensual: {nudCostoMensual.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"CostoTotal: {nudCostoTotal.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Descuento: {nudDescuento.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"SubTotal: {nudSubtotal.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Impuesto: {nudImpuesto.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"TotalPagar: {nudTotalPagar.Value}", textFont, brush, margenizquierdo, y); y += 25; 

        }

        // Boton imprimir

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoInscripcion.Text))
            {
                MessageBox.Show("Seleccione un registro a imprimir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                printDocument1.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);

                int AltoDocumento = 350;
                int AnchoDocumento = 400;

                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Documento", AnchoDocumento, AltoDocumento);

                PrintPreviewDialog preview = new PrintPreviewDialog
                {
                    Document = printDocument1,
                    WindowState = FormWindowState.Maximized
                };

                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



    }//class
}//namespace
