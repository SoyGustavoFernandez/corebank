#region referecias
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
    public partial class frmCargoEntregaMoviles : frmBase
    {
        #region Variables
        clsCNActivos clscnactivos = new clsCNActivos();
        DataTable dtListaMovimientos;
        int nIdMovimiento;
        const int nIdTipoCargoEntrega = 2;
        string cFechaSis = clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy");
        int idCargoEntrega = -1;
        DataTable dtCargoEntrega = new DataTable(); // para actualizar
        #endregion

        #region Constructor
        public frmCargoEntregaMoviles()
        {
            InitializeComponent();
        }

        public frmCargoEntregaMoviles(int nIdMovimiento)
        {
            InitializeComponent();
            initForm(nIdMovimiento);
            
        }
        #endregion

        #region Metodos
        /**
        * 
        * Inicializacion del formulario
        * 
        */
        public void initForm(int nIdMovimiento)
        {
            this.nIdMovimiento = nIdMovimiento;
            dtListaMovimientos = clscnactivos.CNLisMovActCarEnt(nIdMovimiento);
            // el ultimo cargo de entrega
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

            txtNombreColaborador.Text = dtListaMovimientos.Rows[0]["cNombre"].ToString();
            txtCargoColaborador.Text = dtListaMovimientos.Rows[0]["cCargo"].ToString();
            txtOficinaColaborador.Text = dtListaMovimientos.Rows[0]["cDocumentoID"].ToString();
            txtDniColaborador.Text = dtListaMovimientos.Rows[0]["cNombreAge"].ToString();

            txtCaracteristicas.Text = "";
            txtCaracteristicas.Text += " - " + dtListaMovimientos.Rows[0]["cProducto"].ToString() + Environment.NewLine;
            txtCaracteristicas.Text += " - " + dtListaMovimientos.Rows[0]["cColor"].ToString() + Environment.NewLine;
            txtCaracteristicas.Text += " - " + dtListaMovimientos.Rows[0]["cRubro"].ToString() + Environment.NewLine;
            txtCaracteristicas.Text += " - " + dtListaMovimientos.Rows[0]["cMarca"].ToString() + Environment.NewLine;
            txtCaracteristicas.Text += " - " + dtListaMovimientos.Rows[0]["cSerie"].ToString() + Environment.NewLine;
            txtCaracteristicas.Text += " - " + dtListaMovimientos.Rows[0]["cModelo"].ToString() + Environment.NewLine;

            txtValorActivo.Text = dtListaMovimientos.Rows[0]["nValorActual"].ToString();
        }
        #endregion

        #region Eventos
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string reportpath = "RptFormatoCEMovil.rdlc";
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("cCaracteristicas", txtCaracteristicas.Text, false));
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
