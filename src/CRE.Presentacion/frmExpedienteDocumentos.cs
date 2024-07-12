using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using CRE.Presentacion;
using GEN.CapaNegocio;
using CLI.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmExpedienteDocumentos : frmBase
    {
        clsCNControlExp SolPenExpediente = new clsCNControlExp();
        DataTable dtSolPenExpediente = new DataTable();
        DataTable dtDetalleSolPenExp = new DataTable("dtDetalleSolPenExp");
        clsCNCliente clsValidaCliente = new clsCNCliente();
        GEN.CapaNegocio.clsCNCredito clsCredito = new GEN.CapaNegocio.clsCNCredito();
        DataTable dtValidaSocio = new DataTable();

        public frmExpedienteDocumentos()
        {
            InitializeComponent();
            activar(false);
            txtNroFolCre.ReadOnly = true;
            txtNroFolAho.ReadOnly = true;
            txtNroFolVal.ReadOnly = true;
        }
        private void activar(Boolean bol)
        {
            btnAgregar1.Enabled = bol;
            btnQuitar1.Enabled = bol;
            btnImprimir1.Enabled = bol;
            btnImprimir2.Enabled = bol;
            btnImprimir3.Enabled = bol;
            btnImprimir4.Enabled = bol;
        }
        private void FormatoSolExp()
        {
            dtgDetalleSolExp.DataSource = dtDetalleSolPenExp.DefaultView;
            
            this.dtgDetalleSolExp.Columns["idDetalleExp"].Visible = false;
            this.dtgDetalleSolExp.Columns["idcli"].Visible = false;
            this.dtgDetalleSolExp.Columns["lVigente"].Visible = false;
            this.dtgDetalleSolExp.Columns["idTipoDocumento"].Visible = false;
            this.dtgDetalleSolExp.Columns["idTipoOpeExp"].Visible = false;
            this.dtgDetalleSolExp.Columns["idDocExp"].Visible = false;
            this.dtgDetalleSolExp.Columns["cObservacion"].Visible = false;

            this.dtgDetalleSolExp.Columns["idExpediente"].HeaderText = "Cod Exp";
            this.dtgDetalleSolExp.Columns["cDescripCond"].HeaderText = "Condición Expediente";
            this.dtgDetalleSolExp.Columns["cDescripTipoFolio"].HeaderText = "Tipo Folio";
            this.dtgDetalleSolExp.Columns["nNroFolios"].HeaderText = "Nro Folios";
            this.dtgDetalleSolExp.Columns["cTipoDocumento"].HeaderText = "Tipo Documento";
            this.dtgDetalleSolExp.Columns["cDocumento"].HeaderText = "Documento";
            this.dtgDetalleSolExp.Columns["cObservacion"].HeaderText = "Observaciones";

            this.dtgDetalleSolExp.Columns["idExpediente"].Width = 70;
            this.dtgDetalleSolExp.Columns["cObservacion"].Width = 80;
            this.dtgDetalleSolExp.Columns["cDescripCond"].Width = 80;
            this.dtgDetalleSolExp.Columns["cDescripTipoFolio"].Width = 80;
            this.dtgDetalleSolExp.Columns["nNroFolios"].Width = 60;
            this.dtgDetalleSolExp.Columns["cTipoDocumento"].Width = 80;
        }

        private void frmEntregaExpediente_Load(object sender, EventArgs e)
        {
            dtDetalleSolPenExp.Columns.Add("idDetalleExp", typeof(int));
            dtDetalleSolPenExp.Columns.Add("idExpediente", typeof(string));
            dtDetalleSolPenExp.Columns.Add("idcli", typeof(int));
            dtDetalleSolPenExp.Columns.Add("cObservacion", typeof(string));
            dtDetalleSolPenExp.Columns.Add("cDescripCond", typeof(string));
            dtDetalleSolPenExp.Columns.Add("cDescripTipoFolio", typeof(string));
            dtDetalleSolPenExp.Columns.Add("lVigente", typeof(bool));

            dtDetalleSolPenExp.Columns.Add("idTipoOpeExp", typeof(int));
            dtDetalleSolPenExp.Columns.Add("idTipoDocumento", typeof(int));
            dtDetalleSolPenExp.Columns.Add("nNroFolios", typeof(int));
            dtDetalleSolPenExp.Columns.Add("cTipoDocumento", typeof(string));
        }

        private void Limpiar()
        {
            conBusCli1.idCli = 0;
            conBusCli1.txtCodCli.Text = "";
            conBusCli1.txtCodAge.Text = "";
            conBusCli1.txtCodInst.Text = "";
            conBusCli1.txtDireccion.Text = "";
            conBusCli1.txtNombre.Text = "";
            conBusCli1.txtNroDoc.Text = "";
            dtgDetalleSolExp.DataSource = "";
            dtDetalleSolPenExp.Clear();
            conBusCli1.txtCodCli.Enabled = true;
            txtNroFolCre.Text = "";
            txtNroFolAho.Text = "";
            txtNroFolVal.Text = "";
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCli1.txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar datos del cliente", "Valida reporte de arqueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            frmRegDocExpediente frmRegDocExpediente = new frmRegDocExpediente();
            frmRegDocExpediente.InsDetalle(Convert.ToInt32(conBusCli1.idCli));
            frmRegDocExpediente.ShowDialog();
            BuscaDocumentos();
        }

        private void BuscaDocumentos() 
        {            
            if (!string.IsNullOrEmpty(conBusCli1.txtNroDoc.Text))
            {
                // validar si cliente tiene créditos
                int idCli = Convert.ToInt32(conBusCli1.txtCodCli.Text);
                if (!TieneCreditos(idCli) && !TieneAhorros(idCli))
                {
                    MessageBox.Show("El cliente: '" + conBusCli1.txtNombre.Text + "' no tiene ningún crédito o ahorro registrado", "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    activar(false);
                    return;
                }
                // validar si el cliente tiene cuenta de ahorros
                dtDetalleSolPenExp = SolPenExpediente.CNListDetalleExp(Convert.ToInt32(conBusCli1.idCli), 0);
                dtgDetalleSolExp.DataSource = dtDetalleSolPenExp.DefaultView;
                cargarNroFolios();
                FormatoSolExp();
                activar(true);
            }
            else
            {
                dtgDetalleSolExp.DataSource = null;
                activar(false);
                Limpiar();
            }
        }
        private void cargarNroFolios()
        {
            int nNroFolCre = 0;
            int nNroFolAho = 0;
            int nNroFolVal = 0;
            string []  nChar;
            foreach (DataRow item in dtDetalleSolPenExp.Rows)
            {
                nChar = item["idExpediente"].ToString().Split(new Char[]{'_'});
                switch (nChar[1])
                {
                    case "C":
                        nNroFolCre = nNroFolCre +  Convert.ToInt32(item["nNroFolios"]);
                        break;
                    case "A":
                        nNroFolAho = nNroFolAho + Convert.ToInt32(item["nNroFolios"]);
                        break;
                    case "V":
                        nNroFolVal = nNroFolVal + Convert.ToInt32(item["nNroFolios"]);
                        break;
                    default:
                        break;
                }
            }
            txtNroFolCre.Text = nNroFolCre.ToString();
            txtNroFolAho.Text = nNroFolAho.ToString();
            txtNroFolVal.Text = nNroFolVal.ToString();
        }
        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (this.dtgDetalleSolExp.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el registro a eliminar", "Documentos del expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgDetalleSolExp.SelectedCells[0].RowIndex);
                if (Convert.ToInt32(dtgDetalleSolExp.Rows[nFilaActual].Cells["idDetalleExp"].Value) == -1)
                {
                    dtgDetalleSolExp.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgDetalleSolExp.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgDetalleSolExp.Focus();
                ProcessTabKey(true);

                DataTable dtDetExpediente = SolPenExpediente.CNListDetalleExp(0,0);                
                for (int i = 0; i < dtDetalleSolPenExp.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtDetalleSolPenExp.Rows[i]["lVigente"]) == 0)
                    {                        
                        DataRow dr = dtDetExpediente.NewRow();
                        dr["idDetalleExp"]      = dtDetalleSolPenExp.Rows[i]["idDetalleExp"];
                        dr["idcli"]             = dtDetalleSolPenExp.Rows[i]["idcli"];
                        dr["lVigente"]          = dtDetalleSolPenExp.Rows[i]["lVigente"];
                        dr["cObservacion"]      = dtDetalleSolPenExp.Rows[i]["cObservacion"];
                        dr["cDescripCond"]      = dtDetalleSolPenExp.Rows[i]["cDescripCond"];
                        dr["cDescripTipoFolio"] = dtDetalleSolPenExp.Rows[i]["cDescripTipoFolio"];
                        dr["idExpediente"]      = dtDetalleSolPenExp.Rows[i]["idExpediente"];
                        dr["idTipoDocumento"]   = dtDetalleSolPenExp.Rows[i]["idTipoDocumento"];
                        dr["nNroFolios"]        = dtDetalleSolPenExp.Rows[i]["nNroFolios"];
                        dr["idTipoOpeExp"]      = dtDetalleSolPenExp.Rows[i]["idTipoOpeExp"];
                        dr["idTipoDocumento"]   = dtDetalleSolPenExp.Rows[i]["idTipoDocumento"];
                        dtDetExpediente.Rows.Add(dr);
                    }  
                }
                                              
                DialogResult result = DialogResult.None;
                result = MessageBox.Show("Esta seguro(a) de quitar el documento del expediente(s)", "Entrega de expediente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.None || result == DialogResult.Yes)
                {
                    DataSet dsExpediente = new DataSet("dsExpediente");
                    dsExpediente.Tables.Add(dtDetExpediente);
                    string xmlExpediente = clsCNFormatoXML.EncodingXML(dsExpediente.GetXml());
                    dsExpediente.Tables.Clear();
                    DataTable dtRegDetExpediente = SolPenExpediente.CNInsDetalleExpediente(xmlExpediente);

                    MessageBox.Show("El documento fue quitado correctamente", "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BuscaDocumentos();
                }
                //else
                //{
                //    Limpiar();
                //}                
            }
        }       

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            BuscaDocumentos();
        }

        private Boolean TieneCreditos(int idCli)
        {
            DataTable dtResult = clsCredito.CNCreditosCliente(idCli);
            if (dtResult.Rows.Count == 0)
                return false;

            return true;
        }

        private Boolean TieneAhorros(int idCli)
        {
            DataTable dtResult = clsCredito.CNAhorrosCliente(idCli);
            if (dtResult.Rows.Count == 0)
                return false;

            return true;
        }

        private void btnCancelar1_Click_1(object sender, EventArgs e)
        {
            Limpiar();
            activar(false);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            imprimir(0);
        }
        private void imprimir(int idTipoOpeExp)
        {
            if (string.IsNullOrEmpty(conBusCli1.txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar datos del cliente", "Valida reporte de arqueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                clsCNControlExp RptExpedienteCliente = new clsCNControlExp();

                DataTable dtRptExpCliente = RptExpedienteCliente.CNArqueoExpCliente(Convert.ToInt32(conBusCli1.idCli), idTipoOpeExp);
                if (dtRptExpCliente.Rows.Count > 0)
                {
                    int idCliente = Convert.ToInt32(conBusCli1.idCli);

                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    List<ReportParameter> listPar = new List<ReportParameter>();

                    listPar.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    listPar.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    listPar.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                    listPar.Add(new ReportParameter("idCli", idCliente.ToString(), false));
                    listPar.Add(new ReportParameter("idTipoOpeExp", idTipoOpeExp.ToString(), false));

                    string reportpath = "";

                    dtslist.Add(new ReportDataSource("dtsArqueoExpCliente", dtRptExpCliente));
                    reportpath = "rptArqueoExpCliente.rdlc";

                    new frmReporteLocal(dtslist, reportpath, listPar).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existe reporte de expediente para el cliente", "Valida reporte de arqueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }          
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            imprimir(1);
        }

        private void btnImprimir3_Click(object sender, EventArgs e)
        {
            imprimir(2);
        }

        private void btnImprimir4_Click(object sender, EventArgs e)
        {
            imprimir(3);
        }
                
    }
}
