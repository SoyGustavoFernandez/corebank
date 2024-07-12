#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;
using System.Xml.Linq;

// CoreBank
using GEN.ControlesBase;
using LOG.CapaNegocio;
using EntityLayer;
#endregion

namespace LOG.Presentacion
{
    public partial class frmCargoEntregaComputadores : frmBase
    {
        #region Variables
        clsCNActivos clscnactivos = new clsCNActivos();
        DataTable dtListaMovimientos;
        int nIdMovimiento;
        const int nIdTipoCargoEntrega = 3;
        int idCargoEntrega = -1;
        DataTable dtCargoEntrega = new DataTable(); // para actualizar
        string cFechaSis = clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy");
        #endregion

        #region Constructor
        public frmCargoEntregaComputadores()
        {
            InitializeComponent();
        }

        public frmCargoEntregaComputadores(int nIdMovimiento)
        {
            InitializeComponent();
            initForm(nIdMovimiento);
        }
        #endregion

        #region Metodos
        public void initForm(int nIdMovimiento)
        {
            this.nIdMovimiento = nIdMovimiento;

            dtListaMovimientos = clscnactivos.CNLisMovActCarEnt(nIdMovimiento);

            txtNombreColaborador.Text = dtListaMovimientos.Rows[0]["cNombre"].ToString();
            txtCargoColaborador.Text = dtListaMovimientos.Rows[0]["cCargo"].ToString();
            txtOficinaColaborador.Text = dtListaMovimientos.Rows[0]["cDocumentoID"].ToString();
            txtDniColaborador.Text = dtListaMovimientos.Rows[0]["cNombreAge"].ToString();

            dtgActivos.DataSource = dtListaMovimientos;

            for (int i = 0; i < dtgActivos.Columns.Count; i++)
            {
                dtgActivos.Columns[i].Visible = false;
            }

            dtgActivos.Columns["cProducto"].Visible = true;
            dtgActivos.Columns["cModelo"].Visible = true;
            dtgActivos.Columns["cMarca"].Visible = true;
            dtgActivos.Columns["cSerie"].Visible = true;

            dtgActivos.ReadOnly = true;

            dtgActivos.Columns["cProducto"].HeaderText = "Producto";
            dtgActivos.Columns["cProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgActivos.Columns["cModelo"].HeaderText = "Modelo";
            dtgActivos.Columns["cMarca"].HeaderText = "Marca";
            dtgActivos.Columns["cSerie"].HeaderText = "Serie";
            dtgActivos.AllowUserToAddRows = false;


            dtCargoEntrega = clscnactivos.CNUltCargoEntrega(nIdMovimiento, 2);
            idCargoEntrega = Convert.ToInt32(dtCargoEntrega.Rows[0]["idCargoEntrega"]);

            // comprobar si ha cambiado el tipo de cargo de entrega 
            if (Convert.ToInt32(dtCargoEntrega.Rows[0]["idTipoCargoEntrega"]) != nIdTipoCargoEntrega && idCargoEntrega != -1)
            {
                idCargoEntrega = -1;
                if (MessageBox.Show("Vas a cambiar el tipo de cargo de entrega, estas seguro?", "Registro en Base de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
                {
                    Load += (s, e) => Close();
                    return;
                }
            }

            if (idCargoEntrega != -1) 
            {
                /**
                 * 
                 * En este caso solo se recupera la fecha del cargo de entrega
                 * 
                 */
                XElement xReporte = XElement.Parse(dtCargoEntrega.Rows[0]["xDetalles"].ToString());
                XElement xListReportParameter = xReporte.Element("ListReportParameter");
                cFechaSis = xListReportParameter.Element("cFechaSis").Value.ToString();
            }
        }
        #endregion

        #region Eventos
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string reportpath = "RptFormatoCEComputador.rdlc";
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("cFechaSis", cFechaSis, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAge", clsVarGlobal.cNomAge, false));

            dtslist.Add(new ReportDataSource("LisMovActCarEnt", dtListaMovimientos));


            // guardar en base de datos
            if (MessageBox.Show("Se guardara una copia en la base de datos, asegurese que todos los campos estan completados, ¿Desea continuar?", "Registro en Base de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            idCargoEntrega = clscnactivos.CNInsertCargoEntrega(
                idCargoEntrega,
                this.nIdMovimiento,
                nIdTipoCargoEntrega,
                clsVarGlobal.User.idUsuario,
                frmCargoEntregaCamionetas.convertirReportAXml(dtslist, reportpath, paramlist).ToString(),
                Convert.ToInt32(dtCargoEntrega.Rows[0]["nVecesImpreso"]) + 1
            );

            if (idCargoEntrega != -1)
            {
                MessageBox.Show("Se guardo una copia en la base de datos, Numero de Cargo de Entrega: " + idCargoEntrega.ToString(), "Registro en Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        #endregion
    }
}
