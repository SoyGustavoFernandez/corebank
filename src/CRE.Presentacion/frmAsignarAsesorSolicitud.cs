using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmAsignarAsesorSolicitud : frmBase
    {
        #region Variable Globales

        clsCNSolicitud cnsolicitud = new clsCNSolicitud();

        #endregion

        public frmAsignarAsesorSolicitud()
        {
            InitializeComponent();
            GEN.BotonesBase.btnSolAprobadas btn = new GEN.BotonesBase.btnSolAprobadas();
            btnAsignar.BackgroundImage = btn.BackgroundImage;
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);

            cargarSolicitudes();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una solicitud de crédito por favor", "Validación solicitus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dtgSolicitudes.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnAsignar.Enabled = true;
            cboPersonalCreditos.Enabled = true;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtgSolicitudes.Enabled = true;
            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnAsignar.Enabled = false;
            cboPersonalCreditos.Enabled = false;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var idSolicitud = Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idSolicitud"].Value);
                var idAsesor = Convert.ToInt32(this.cboPersonalCreditos.SelectedValue);
                var dtResultado = cnsolicitud.CNAsignarAsesorSolicitud(idSolicitud, idAsesor);
                              
                dtgSolicitudes.Enabled = true;
                btnEditar1.Enabled = true;
                btnCancelar1.Enabled = false;
                btnAsignar.Enabled = false;
                cboPersonalCreditos.Enabled = false; 
                cargarSolicitudes();
            }
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;

            if (this.cboPersonalCreditos.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un asesor para la signación", "Validación asesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }
            lValida = true;
            return lValida;
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgSolicitudes.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgSolicitudes.Columns["idMoneda"].Visible = false;

            dtgSolicitudes.Columns["idSolicitud"].HeaderText = "Cod.Solicitud";
            dtgSolicitudes.Columns["idCli"].HeaderText = "Cod.Cliente";
            dtgSolicitudes.Columns["cNombre"].HeaderText = "Nombres";
            dtgSolicitudes.Columns["nCapitalSolicitado"].HeaderText = "Monto";
            dtgSolicitudes.Columns["cMoneda"].HeaderText = "Moneda";
            dtgSolicitudes.Columns["dFechaRegistro"].HeaderText = "Fecha Reg.";
            
            dtgSolicitudes.Columns["idSolicitud"].Width = 100;
            dtgSolicitudes.Columns["idCli"].Width = 90;
            dtgSolicitudes.Columns["cNombre"].Width = 250;
            dtgSolicitudes.Columns["nCapitalSolicitado"].Width = 70;
            dtgSolicitudes.Columns["cMoneda"].Width = 140;
            dtgSolicitudes.Columns["dFechaRegistro"].Width = 80;

            dtgSolicitudes.Columns["nCapitalSolicitado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgSolicitudes.Columns["nCapitalSolicitado"].DefaultCellStyle.Format = "N2";
        }

        private void cargarSolicitudes()
        {
            var dtSolicitudes = cnsolicitud.CNListarSolicitudesSinAsesor(clsVarGlobal.nIdAgencia);

            if (dtSolicitudes.Rows.Count > 0)
            {
                dtgSolicitudes.DataSource = dtSolicitudes;
                formatoGrid();
                btnEditar1.Enabled = true;
            }
            else
            {
                dtgSolicitudes.DataSource = null;
                btnEditar1.Enabled = false;
            }
        }

        #endregion

    }
}
