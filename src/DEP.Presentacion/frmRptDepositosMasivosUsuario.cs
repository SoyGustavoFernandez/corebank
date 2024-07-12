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
using GEN.BotonesBase;
using GEN.ControlesBase;
using DEP.CapaNegocio;
using GEN.LibreriaOffice;
using System.Xml.Linq;
using EntityLayer;

#endregion

namespace DEP.Presentacion
{
    public partial class frmRptDepositosMasivosUsuario : frmBase
    {

        #region Variables

        clsCNDeposito objCNDeposito = new clsCNDeposito();
        DataTable dtOperacionesUsu = new DataTable();
        DataTable dtUsuariosTH;

        #endregion

        public frmRptDepositosMasivosUsuario()
        {
            InitializeComponent();
            cboTipoCargaMasivaAho.cargarDatos(0);
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
        }

        #region Eventos

        private void frmRptDepositosMasivosUsuario_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarLista();
        }

        private void chcSelec_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcSelec.Checked)
            {
                seleccionarUsuario();
            }
            else
            {
                deseleccionarUsuario();
            }
        }

        private void chklbDatPcUsu_Click(object sender, EventArgs e)
        {
            bool a = this.chklbDatUsu.CheckOnClick = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            if (dtpFechaInicio.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha del coreBank.", "Reporte depósitos masivos por usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpFechaFin.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha final no puede ser mayor a la fecha del coreBank.", "Reporte depósitos masivos por usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToDateTime(dtpFechaInicio.Value.ToString("yyyy-MM-dd")) > Convert.ToDateTime(dtpFechaFin.Value.ToString("yyyy-MM-dd")))
            {
                MessageBox.Show("La fecha inicial debe ser menor a la fecha final.", "Reporte depósitos masivos por usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.chklbDatUsu.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un item.", "Reporte depósitos masivos por usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<clsUsuario> lisDato = new List<clsUsuario>();
            foreach (DataRowView item in this.chklbDatUsu.CheckedItems)
            {
                lisDato.Add(new clsUsuario() { idUsuario = int.Parse(item.Row["idUsuario"].ToString()) });
            }

            var xDatosUsuarioTH = new XElement("DatosUsuario", from dato in lisDato
                                                               select new XElement("Data",
                                                                   new XAttribute("idUsuario", dato.idUsuario)
                                                                   ));

            string xmlUsuariosTH = "<?xml version='1.0' encoding='ISO-8859-1' standalone='no' ?>" + xDatosUsuarioTH.ToString();
            xmlUsuariosTH = xmlUsuariosTH.Replace("\r\n", "").Replace(Environment.NewLine, "");
            
            dtOperacionesUsu = objCNDeposito.CNListarOperacionesUsuarioTH(xmlUsuariosTH, (int)cboTipoCargaMasivaAho.SelectedValue, this.dtpFechaInicio.Value, this.dtpFechaFin.Value);

            if (dtOperacionesUsu.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                if ((int)cboTipoCargaMasivaAho.SelectedValue == 0){
                    paramlist.Add(new ReportParameter("cTipoCarga", "", false));
                }else{
                    paramlist.Add(new ReportParameter("cTipoCarga", "TIPO: " + cboTipoCargaMasivaAho.tbTipoCargaMasiva.Rows[(int)cboTipoCargaMasivaAho.SelectedValue]["cTipCarga"].ToString(), false));
                    
                }
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dsListarOperacionUsuarioTH", dtOperacionesUsu));
                string reportpath = "rptListarOperacionUsuario.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Reporte depósitos masivos por usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        
        #endregion

        #region Metodos

        private void cargarLista()
        {
            dtUsuariosTH = objCNDeposito.CNListarUsuariosTalentoHumano();

            if (dtUsuariosTH.Rows.Count > 0)
            {
                this.chklbDatUsu.DataSource = dtUsuariosTH;
                this.chklbDatUsu.ValueMember = dtUsuariosTH.Columns["idUsuario"].ToString();
                this.chklbDatUsu.DisplayMember = dtUsuariosTH.Columns["cNombre"].ToString();
            }
            else
            {
                this.chklbDatUsu.DataSource = null;
                chcSelec.Checked = false;
            }

            chklbDatUsu.Focus();
        }

        private void seleccionarUsuario()
        {
            for (int i = 0; i < this.chklbDatUsu.Items.Count; i++)
            {
                this.chklbDatUsu.SetItemChecked(i, true);
            }
        }

        private void deseleccionarUsuario()
        {
            for (int i = 0; i < this.chklbDatUsu.Items.Count; i++)
            {
                this.chklbDatUsu.SetItemChecked(i, false);
            }
        }

        #endregion

    }
}
