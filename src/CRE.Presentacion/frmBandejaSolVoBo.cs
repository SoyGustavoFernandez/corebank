using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmBandejaSolVoBo : frmBase
    {
        CRE.CapaNegocio.clsCNCredito Credito = new CRE.CapaNegocio.clsCNCredito();
        int idCuenta = 0;

        public frmBandejaSolVoBo()
        {
            InitializeComponent();
        }

        private void frmBandejaSolVoBo_Load(object sender, EventArgs e)
        {         
            DataTable solicitudes = Credito.CNlistarSolicitudesCondonacion(clsVarGlobal.nIdAgencia);
            foreach (DataColumn item in solicitudes.Columns)
            {
                item.ReadOnly = false;
            }
            if (solicitudes.Rows.Count > 0)
                btnAceptar1.Enabled = true;
            else btnAceptar1.Enabled = false;
            dtgSolicitud.DataSource = solicitudes;
            formatear();
        }

        private void formatear()
        {

            dtgSolicitud.Columns["idSolicitudAproba"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgSolicitud.Columns["idCuenta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgSolicitud.Columns["cDocumentoID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dtgSolicitud.Columns["cNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgSolicitud.Columns["nMontoAPagar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgSolicitud.Columns["cCorrespondencia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dtgSolicitud.Columns["idSolicitudAproba"].Visible = true;
            dtgSolicitud.Columns["idCuenta"].Visible = true;
            dtgSolicitud.Columns["cDocumentoID"].Visible = true;
            dtgSolicitud.Columns["cNombre"].Visible = true;
            dtgSolicitud.Columns["nMontoAPagar"].Visible = true;
            dtgSolicitud.Columns["cCorrespondencia"].Visible = true;

            dtgSolicitud.Columns["idSolicitudAproba"].HeaderText = "Solicitud";
            dtgSolicitud.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgSolicitud.Columns["cDocumentoID"].HeaderText = "D.N.I.";
            dtgSolicitud.Columns["cNombre"].HeaderText = "Nombres y Apellidos";
            dtgSolicitud.Columns["nMontoAPagar"].HeaderText = "Monto";
            dtgSolicitud.Columns["cCorrespondencia"].HeaderText = "Tipo";
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            int rowIndex = dtgSolicitud.CurrentRow.Index;
            if (rowIndex != -1)
            {
                idCuenta = Convert.ToInt32(dtgSolicitud.Rows[rowIndex].Cells["idCuenta"].Value);
                this.Close();
            }
        }

        public int idCuentaSelect()
        {
            return idCuenta;
        }
    }
}
