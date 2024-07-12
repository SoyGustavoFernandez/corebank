using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmConsulPosiClient : frmBase
    {
        DataTable dtLisHistorico = new DataTable();
        clsCNIntervCre cninterviniente = new clsCNIntervCre();
        clsApiCentralRsgExterno cnApi = new clsApiCentralRsgExterno();
        List<ResulSentinel> listResulSentinel = new List<ResulSentinel>();
        int nIdTipoDoc;
        public frmConsulPosiClient()
        {
            InitializeComponent();
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            dtLisHistorico.Clear();
            if (conBusCli.idCli != 0)
            {
                GEN.CapaNegocio.clsCNBuscarCli listarCli = new GEN.CapaNegocio.clsCNBuscarCli();
                DataTable tablaCli = listarCli.ListarclixIdCli(Convert.ToInt32(this.conBusCli.txtCodCli.Text));

                conBusCli.nidTipoDocumento = tablaCli.Rows[0]["idTipoDocumento"].ToString();

                CargarHistorial(Convert.ToInt32(conBusCli.nidTipoDocumento));
                conBusCli.btnBusCliente.Enabled = false;
            }

        }

        private void frmConsulPosiClient_Load(object sender, EventArgs e)
        {

        }

        public void CargarHistorial(int nIdTipoDocumento)
        {

            dtLisHistorico = cninterviniente.CNdtLstRastreoIntyPost(conBusCli.txtNroDoc.Text);
            if (dtLisHistorico.Rows.Count > 0)
            {
                for (int i = 0; i < dtLisHistorico.Rows.Count; i++)
                {
                    ResulSentinel objModelSentinel = new ResulSentinel();
                    objModelSentinel.cNomUsu = dtLisHistorico.Rows[i]["cNomUsu"].ToString();
                    objModelSentinel.cNombreAge = dtLisHistorico.Rows[i]["cNombreAge"].ToString();
                    objModelSentinel.dFechaSis = dtLisHistorico.Rows[i]["dFechaSis"].ToString();
                    objModelSentinel.Grupo = dtLisHistorico.Rows[i]["Grupo"].ToString();
                    objModelSentinel.nVeces = Convert.ToInt32(dtLisHistorico.Rows[i]["nVeces"]);
                    listResulSentinel.Add(objModelSentinel);
                }
            }

            if (nIdTipoDocumento == 1) //PERSONA NATURAL
            {
                nIdTipoDoc = 11;
            }
            if (nIdTipoDocumento == 4)//PERSONA JURIDICA
            {
                nIdTipoDoc = 12;
            }

            var Resultado = cnApi.ConsultaUsuario(nIdTipoDoc, conBusCli.txtNroDoc.Text);//Informe de consultas Sentinel
            if (Resultado.Data.Count > 0)
            {
                for (int y = 0; y < Resultado.Data.Count; y++)
                {
                    ResulSentinel objModelSentinel = new ResulSentinel();
                    var dataUsuario = cninterviniente.CNADdevuelveDatosUsuario(Convert.ToInt32(Resultado.Data[y].IdUsuarioRegistro));

                    objModelSentinel.cNomUsu = dataUsuario.Rows[0]["cNomUsu"].ToString();
                    objModelSentinel.cNombreAge = dataUsuario.Rows[0]["cAgencia"].ToString();
                    objModelSentinel.dFechaSis = Convert.ToDateTime(Resultado.Data[y].dFechaUltimaConsulta).ToString("dd/MM/yyyy");
                    objModelSentinel.Grupo = "Sentinel";
                    objModelSentinel.nVeces = Convert.ToInt32(Resultado.Data[y].nCantidadConsultas);
                    listResulSentinel.Add(objModelSentinel);

                }
            }
            if (listResulSentinel.Count > 0)
            {
                var dataTable = ToDataTable(listResulSentinel);
                var dtResultado = dataTable.AsEnumerable().OrderByDescending(r => Convert.ToDateTime(r.Field<string>("dFechaSis"))).CopyToDataTable();

                dtgCPosCliente.DataSource = dtResultado;

                FormatoGridConsultaPosicionCliente();
            }


            this.btnCancelar.Enabled = true;
            this.btnImprimir1.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
            this.btnCancelar.Enabled = false;
            this.btnImprimir1.Enabled = false;
            conBusCli.btnBusCliente.Enabled = true;
        }

        private void LimpiarControles()
        {
            dtgCPosCliente.DataSource = "";


            this.conBusCli.txtCodCli.Text = "";
            this.conBusCli.txtNombre.Text = "";
            this.conBusCli.txtNroDoc.Text = "";
            this.conBusCli.txtCodAge.Text = "";
            this.conBusCli.txtCodInst.Text = "";
            this.conBusCli.txtDireccion.Text = "";
            this.conBusCli.txtCodCli.Enabled = true;
            this.conBusCli.txtCodCli.Focus();

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            nuevoReporte(conBusCli.txtNroDoc.Text);
        }

        public void nuevoReporte(string cNroDocumento)
        {
            List<ReportParameter> listPar = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            listPar.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            listPar.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            listPar.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            listPar.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            if (listResulSentinel.Count > 0)
            {
                var dataTable = ToDataTable(listResulSentinel);
                var dtResultado = dataTable.AsEnumerable().OrderByDescending(r => Convert.ToDateTime(r.Field<string>("dFechaSis"))).CopyToDataTable();

                dtslist.Add(new ReportDataSource("DataSet1", dtResultado));

                string reportpath = "RptDetConsultaPosCliente.rdlc";
                frmReporteLocal objfrmReporteador = new frmReporteLocal(dtslist, reportpath, listPar);
                objfrmReporteador.rpvReporteLocal.ShowPrintButton = false;

                objfrmReporteador.ShowDialog();
            }



        }
        private void FormatoGridConsultaPosicionCliente()
        {
            foreach (DataGridViewColumn item in dtgCPosCliente.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            dtgCPosCliente.Columns["cNomUsu"].HeaderText = "Nombre de Usuario";
            dtgCPosCliente.Columns["cNomUsu"].Width = 180;
            dtgCPosCliente.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgCPosCliente.Columns["cNombreAge"].Width = 150;
            dtgCPosCliente.Columns["dFechaSis"].HeaderText = "Fecha de Rastreo";
            dtgCPosCliente.Columns["nVeces"].HeaderText = "Nro. de Veces";

        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties      
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names        
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows               
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable        
            return dataTable;
        }
    }
}
public class ResulSentinel { 

    public string cNomUsu { get; set; }
    public string cNombreAge { get; set; }                                                                                                                                               
    public string dFechaSis { get; set; }
    public string Grupo { get; set; }
    public int nVeces { get; set; }
  
}
