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
using GEN.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmMoraUbigeoRecuperador : frmBase
    {
        #region Variables Globales

        clsCNPersonal cnpersonal = new clsCNPersonal();
        clsCNTipoDireccion objTipDir = new clsCNTipoDireccion();
        int nSelecciona = 3;

        #endregion

        public frmMoraUbigeoRecuperador()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            txtAtrIni.Text = "-9999";
            txtAtrFin.Text = "9999";
            txtMonIni.Text = "0";
            txtMonFin.Text = "9999";
            cargarTipoDireccion();
            cargarRecuperadores();
            conBusUbig1.cargar();
            conBusUbig1.cboPais.SelectedValue = 173;
            conBusUbig1.cboDepartamento.SelectedValue = 1632;
            conBusUbig1.cboProvincia.SelectedValue = 1633;
        }

        #region Eventos

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkRecuperadores.Items.Count; ++i)
                chkRecuperadores.SetItemChecked(i, chcTodos.Checked);
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();

                string CodRecuperador = "";

                foreach (DataRowView item in this.chkRecuperadores.CheckedItems)
                {
                    CodRecuperador += (item.Row["idUsuario"] + ",");
                }

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                int idTipDir = Convert.ToInt32(cboTipoDireccion.SelectedValue);
                int idUbigeo = Convert.ToInt32(conBusUbig1.cboDistrito.SelectedValue);
                int idTipInter = Convert.ToInt32(cboTipoIntervCre1.SelectedValue);

                var dtMora=new clsRPTCNCredito().MoraUbigeoRecup(Convert.ToInt32(txtAtrIni.Text), Convert.ToInt32(txtAtrFin.Text), Convert.ToDecimal(txtMonIni.Text), Convert.ToDecimal(txtMonFin.Text), CodRecuperador, idTipDir, idUbigeo, idTipInter);
                var dtInterviniente = new clsRPTCNCredito().IntervMoraUbigeoRecup(Convert.ToInt32(txtAtrIni.Text), Convert.ToInt32(txtAtrFin.Text), Convert.ToDecimal(txtMonIni.Text), Convert.ToDecimal(txtMonFin.Text), CodRecuperador, idTipDir, idUbigeo, idTipInter);
                DataTable dtMoraFiltrado = dtMora.Clone();
                DataTable dtInterFiltrado=dtInterviniente.Clone();
                if (dtMora.Rows.Count > 0)
                {
                    if (nSelecciona == 1)
                    {
                        (from item in dtMora.AsEnumerable()
                         where (int)item["nCastigado"] == 1
                         select item).CopyToDataTable(dtMoraFiltrado, LoadOption.OverwriteChanges);
                    }
                    else if ((nSelecciona == 2))
                    {
                        (from item in dtMora.AsEnumerable()
                         where (int)item["nCastigado"] == 0
                         select item).CopyToDataTable(dtMoraFiltrado, LoadOption.OverwriteChanges);
                    }
                    else
                    {
                        dtMoraFiltrado = dtMora;
                    }
                }
                else
                {
                    dtMoraFiltrado = dtMora;
                }

                if (dtInterviniente.Rows.Count > 0)
                {
                    if (nSelecciona == 1)
                    {
                        (from item in dtInterviniente.AsEnumerable()
                         where (int)item["nCastigado"] == 1
                         select item).CopyToDataTable(dtInterFiltrado, LoadOption.OverwriteChanges);
                    }
                    else if ((nSelecciona == 2))
                    {
                        (from item in dtInterviniente.AsEnumerable()
                         where (int)item["nCastigado"] == 0
                         select item).CopyToDataTable(dtInterFiltrado, LoadOption.OverwriteChanges);
                    }
                    else
                    {
                        dtInterFiltrado = dtInterviniente;
                    }
                }
                else
                {
                    dtInterFiltrado = dtInterviniente;
                }
                

                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dtsDetalleMora", dtMoraFiltrado));
                dtslist.Add(new ReportDataSource("dtsInterviniente", dtInterFiltrado));

                paramlist.Add(new ReportParameter("dFecha", clsVarGlobal.dFecSystem.ToString(), false));

                string reportpath = "RptMoraDiaria.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void rbtnCatigados_CheckedChanged(object sender, EventArgs e)
        {
            nSelecciona = 1;
        }

        private void rbtnSinCastigo_CheckedChanged(object sender, EventArgs e)
        {
            nSelecciona = 2;
        }

        private void rbtnTodos_CheckedChanged(object sender, EventArgs e)
        {
            nSelecciona = 3;
        }

        #endregion

        #region Metodos

        private void cargarTipoDireccion()
        {
            DataTable dtbTipDir = objTipDir.ListaTipDireccion();
            cboTipoDireccion.DataSource = dtbTipDir;
            cboTipoDireccion.DisplayMember = dtbTipDir.Columns["cTipoDir"].ToString();
            cboTipoDireccion.ValueMember = dtbTipDir.Columns["idTipoDireccion"].ToString();
        }

        private void cargarRecuperadores()
        {
            DataTable dt = cnpersonal.ListaPersonalCargo("nCargosRecuperadores", 0);
            chkRecuperadores.DataSource = dt;
            chkRecuperadores.ValueMember = dt.Columns[0].ToString();
            chkRecuperadores.DisplayMember = dt.Columns[1].ToString();
        }

        private bool validar()
        {
            bool lVal = false;

            if (Convert.ToDecimal(txtMonFin.Text) < Convert.ToDecimal(txtMonIni.Text))
            {
                MessageBox.Show("Monto Final debe ser que Monto Inicial", "Validación rangos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonFin.Focus();
                return lVal;
            }

            if (Convert.ToInt32(txtAtrFin.Text) < Convert.ToInt32(txtAtrIni.Text))
            {
                MessageBox.Show("Atraso Final debe ser que Atraso Inicial", "Validación rangos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAtrFin.Focus();
                return lVal;
            }

            if (chkRecuperadores.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un recuperador por favor", "Validación recuperadores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkRecuperadores.Focus();
                return lVal;
            }

            if (conBusUbig1.cboDistrito.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione distrito del ubigeo por favor", "Validación ubigeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusUbig1.cboDistrito.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        #endregion

    }
}
