using GEN.ControlesBase;
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
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using PRE.CapaNegocio;
using EntityLayer;

namespace PRE.Presentacion
{
    public partial class frmCargarDeExcel : frmBase
    {
        #region Variables globales
        private OpenFileDialog OpenDialog;
        DataTable dtTabla;
        DataTable dtCtas;
        Boolean lCorrecto = true;
        int idPeriodo = 0;
        //int nCantRegPeriActual = 0;
        Color colError = Color.MistyRose;
        clsCNPartidasPres cnpartidaspres = new clsCNPartidasPres();

        Dictionary<string, Dictionary<string, int>> dColumns = new Dictionary<string, Dictionary<string, int>>
            {
                {"cCodigoPresupuestal",	new Dictionary<string, int> { {"Codigo pres.", 1}}},
                {"cNombre",	new Dictionary<string, int> { {"Nombre", 1}}},
                {"cCtasContables",	new Dictionary<string, int> { {"Cuentas Contables", 1}}},                
            };

        #endregion
        public frmCargarDeExcel(int idPeriodo)
        {
            InitializeComponent();
            OpenDialog = new OpenFileDialog();
            formatoTablaCtas();
            this.idPeriodo = idPeriodo;
            //this.nCantRegPeriActual = nCantidadPartidasActual;
        }
        #region Eventos        
        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            OpenDialog.Filter = "Hojas de Excel(*.xls)|*.xls";
            OpenDialog.ShowDialog();
            txtPath.Text = OpenDialog.FileName;

            if (String.IsNullOrEmpty(txtPath.Text))
            {
                return;
            }

            try
            {
                ExcelHandler ex = new ExcelHandler();
                dtTabla = ex.ImportExcelToDataTable(txtPath.Text);
                dtTabla.Columns.Add("cCuentasContables", typeof(string));

                //tabla = renombrarColumnas(tabla);
                if (ValidarHoja(dtTabla))
                {
                    // Verificar formato del excel 
                    //DataSet ds = SepararFilasValidas(tabla);                    
                    dtgPartidas.DataSource = dtTabla;
                    formatoDTGPArtidas();
                    validarFormatoCtasEnDTG();
                    //dtgClientesCargaPep.DataSource = ds.Tables["dtCorrecto"];
                    //formatogrid(dtgClientesCargaPep, 1);

                    //dtgClientesPepError.DataSource = ds.Tables["dtError"];
                    //formatogrid(dtgClientesPepError, 2);
                    //contando registros
                    //lblNroRegError.Text = dtgClientesPepError.RowCount.ToString() + " fila(s)";
                    //lblNroRegBien.Text = dtgClientesCargaPep.RowCount.ToString() + " fila(s)";

                    btnGrabar1.Enabled = false;
                    if (dtgPartidas.Rows.Count > 0)
                    {
                        btnGrabar1.Enabled = true;
                        //btnNuevo1.Enabled = false;
                        btnBusqueda1.Enabled = false;
                    }
                }
            }
            catch 
            {
                MessageBox.Show("No se ha podido cargar la hoja de Excel.", "Carga de Partidas presupuestales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //throw;
                limpiar();
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!this.lCorrecto)
            {
                MessageBox.Show("La tabla tiene campos obligatorios en blanco o con formato incorrecto", "Carga de Partidas presupuestales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnGrabar1.Enabled = false;
                return;
            }
            if (MessageBox.Show("Al guardar las partidas, se remplazaran las existentes en el Periodo ¿Desea continuar guardando?", "Carga de Partidas presupuestales", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DataTable dtVaciar = cnpartidaspres.EliminarPartidasPeriodo(idPeriodo, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                guardarRecur(String.Empty, 0);
                this.Dispose();
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        #endregion
        #region Metodos
        private void formatoDTGPArtidas()
        {
            this.dtgPartidas.Columns["cCodigoPresupuestal"].FillWeight = 10;
            this.dtgPartidas.Columns["cNombre"].FillWeight = 30;
            this.dtgPartidas.Columns["cCtasContables"].FillWeight = 40;
            this.dtgPartidas.Columns["cCuentasContables"].FillWeight = 20;

            this.dtgPartidas.Columns["cCodigoPresupuestal"].HeaderText = "Código";
            this.dtgPartidas.Columns["cNombre"].HeaderText = "Nombre";
            this.dtgPartidas.Columns["cCtasContables"].HeaderText = "Ctas. Contables";
            this.dtgPartidas.Columns["cCuentasContables"].HeaderText = "XML";
        }
        private bool ValidarHoja(DataTable dt)
        {
            string cColumnasFaltantes = "";
            bool lValido = true;
            foreach (KeyValuePair<string, Dictionary<string, int>> item in dColumns)
            {
                if (!dt.Columns.Contains(item.Key))
                {
                    foreach (KeyValuePair<string, int> item2 in item.Value)
                    {
                        cColumnasFaltantes += "\t" + item2.Key + "\n";
                        lValido = false;
                    }

                }
            }

            if (!lValido)
            {
                MessageBox.Show("La tabla no tiene las siguientes columnas:" + cColumnasFaltantes + " ", "Carga de Partidas presupuestales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPath.Text = "";
            }
            //foreach (var item in Columnas)
            //{
            //    if (!dt.Columns.Contains(item))
            //    {
            //        MessageBox.Show("La tabla no tiene la columna " + item + " ", "Carga de Partidas presupuestales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        txtPath.Text = "";
            //        return false;
            //    }
            //}
            return lValido;
        }
        private void formatoTablaCtas()
        {
            dtCtas = new DataTable();
            dtCtas.Columns.Add("idCCPartida", typeof(String));
            dtCtas.Columns.Add("cCuenta", typeof(String));
        }        
        private void validarFormatoCtasEnDTG()
        {
            this.lCorrecto = true;
            for(int i = 0; i<this.dtTabla.Rows.Count; i++)
            {
                dtTabla.Rows[i]["cCuentasContables"] = convertirAXML(dtTabla.Rows[i]["cCtasContables"].ToString());
                if (String.IsNullOrEmpty(dtTabla.Rows[i]["cCodigoPresupuestal"].ToString()))
                {
                    dtgPartidas.Rows[i].Cells["cCodigoPresupuestal"].Style.BackColor = colError;
                    this.lCorrecto = false;                 
                }
                if (String.IsNullOrEmpty(dtTabla.Rows[i]["cNombre"].ToString()))
                {
                    dtgPartidas.Rows[i].Cells["cNombre"].Style.BackColor = colError;
                    this.lCorrecto = false;
                }
                if (dtTabla.Rows[i]["cCodigoPresupuestal"].ToString().Length % 2 != 0)
                {
                    dtgPartidas.Rows[i].Cells["cCodigoPresupuestal"].Style.BackColor = colError;
                    this.lCorrecto = false;
                }
            }                        
        }
        private String convertirAXML(String cCadenaCtas)
        {
            String cCta = String.Empty;
            cCadenaCtas += ",";
            for (int i = 0; i < cCadenaCtas.Length; i++)
            {                
                if (cCadenaCtas[i].ToString() == ",")
                {                    
                    if (!String.IsNullOrEmpty(cCta))
                    {
                        DataRow drCtas = dtCtas.NewRow();
                        drCtas["idCCPartida"] = 0;
                        drCtas["cCuenta"] = cCta;
                        dtCtas.Rows.Add(drCtas);
                        cCta = String.Empty;
                    }
                }
                else
                {
                    cCta += cCadenaCtas[i];
                }
                                
            }                       
            DataSet DSCuentasContables = new DataSet("DSCuentasContables");
            DSCuentasContables.Tables.Add(dtCtas);
            string xmlCuentasConta = DSCuentasContables.GetXml();
            xmlCuentasConta = clsCNFormatoXML.EncodingXML(xmlCuentasConta);
            DSCuentasContables.Tables.Clear();
            dtCtas.Rows.Clear();
            return xmlCuentasConta;
        }
        private void guardarRecur(String cidPadre, int idPadre)
        {
            int nCantCod = cidPadre.Length;
            foreach (DataRow item in this.dtTabla.Rows)
            {
                if (item["cCodigoPresupuestal"].ToString().Length == nCantCod+2) // ubica a los hijos, por lo que deben tener la cantidad de cifras de codigo +2 
                {
                    if (item["cCodigoPresupuestal"].ToString().Substring(0,nCantCod) == cidPadre) // ubicamos a sus hijos directos
                    {
                        DataTable dtResultado = cnpartidaspres.InsertarPartidaPres (0, idPadre, 0, item["cNombre"].ToString(), idPeriodo, 0.00m, false, 0, 100, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, item["cCuentasContables"].ToString(), 2, 1);
                        guardarRecur(item["cCodigoPresupuestal"].ToString(), Convert.ToInt32(dtResultado.Rows[0]["idPartida"].ToString()));
                    }
                }
            }
        }
        private void limpiar()
        {
            txtPath.Clear();
            this.btnBusqueda1.Enabled = true;
            if (((DataTable)dtgPartidas.DataSource) != null)
                ((DataTable)dtgPartidas.DataSource).Clear();
        }
        #endregion        
    }
}
