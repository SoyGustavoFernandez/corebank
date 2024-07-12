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
using CAJ.CapaNegocio;
using EntityLayer;
using Excel = Microsoft.Office.Interop.Excel;
using GEN.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmCargaExcelWesternUnion : frmBase
    {
        #region variables
        public DataTable dtgExcelContent;
        private string xmlLisOpWesternUnion = string.Empty;
        #endregion

        public frmCargaExcelWesternUnion(DataTable dtgDataGrid)
        {
            this.dtgExcelContent = dtgDataGrid; 
            InitializeComponent();
        } 
        
        #region Eventos
        private void frmCargaExcelWesternUnion_Load(object sender, EventArgs e)
        {
            this.dtgExcelWesternUnion.DataSource = this.dtgExcelContent;
            this.dtgExcelWesternUnion.Update();
            this.formatearDataGridView();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
             DialogResult dialogResult = MessageBox.Show("¿Está seguro de procesar el archivo?", "Carga de archivo Excel a Servidor", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
             if (dialogResult == DialogResult.Yes)
             {
                 DataTable dtOperacionesWestern = this.dtgExcelContent;
                 DataSet dsLisOpWU = new DataSet("dtOperacionesWestern");
                 dsLisOpWU.Tables.Add(dtOperacionesWestern.Copy());
                 this.xmlLisOpWesternUnion = dsLisOpWU.GetXml();
                 
                 clsCNControlOpe app = new clsCNControlOpe();
                 DataTable dtResult = new DataTable();
                 try
                 {                     
                     dtResult = app.GuardarOperacionesWesternUnion(
                             clsCNFormatoXML.EncodingXML(this.xmlLisOpWesternUnion),
                             clsVarGlobal.User.idUsuario,
                             clsVarGlobal.nIdAgencia,
                             clsVarGlobal.PerfilUsu.idPerfil,
                             clsVarGlobal.dFecSystem
                         );
                     if (dtResult.Rows.Count > 0)
                     {
                         this.DialogResult = DialogResult.OK;
                         this.Dispose();
                     }

                     else
                     {
                         MessageBox.Show("No se pudo cargar el archivo, verifique el correcto llenado de su archivo Excel.", "Error de procesamiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }                 
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Se produjo un error al cargar el archivo, verifique el correcto formato de su archivo Excel.", "Error de procesamiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 } 
             }
        }  
        #endregion

        #region Métodos
        public void formatearDataGridView()
        {
            foreach (DataGridViewColumn objCol in this.dtgExcelWesternUnion.Columns)
            {
                objCol.Visible = true;
            }

            this.dtgExcelWesternUnion.Columns["nLote"].HeaderText = "Lote";
            this.dtgExcelWesternUnion.Columns["nSecuencia"].HeaderText = "Secuencia";
            this.dtgExcelWesternUnion.Columns["cEntidad"].HeaderText = "Entidad";
            this.dtgExcelWesternUnion.Columns["cCuenta"].HeaderText = "Cuenta";
            this.dtgExcelWesternUnion.Columns["dFecha"].HeaderText = "Fecha";
            this.dtgExcelWesternUnion.Columns["dHora"].HeaderText = "Hora";
            this.dtgExcelWesternUnion.Columns["cFirma"].HeaderText = "Firma";
            this.dtgExcelWesternUnion.Columns["cOperador"].HeaderText = "Operador";
            this.dtgExcelWesternUnion.Columns["nImporte"].HeaderText = "Importe";
            this.dtgExcelWesternUnion.Columns["cMoneda"].HeaderText = "Moneda";
        }
        #endregion
    }
}
