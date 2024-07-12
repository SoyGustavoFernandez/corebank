using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using RSG.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmEvaluaSobreendeuda : frmBase
    {
        #region Varibles globales
        int idCli = 0;       
        clsCNSobreendeuda sobreendeuda = new clsCNSobreendeuda();
        DataTable dtCuentas;
        DataTable dtResultados;

        #endregion
        public frmEvaluaSobreendeuda(int idCli)
        {
            this.idCli = idCli;            
            InitializeComponent();
            //evaluarSobreendeuda();
        }
        #region Eventos
        private void frmEvaluaSobreendeuda_Load(object sender, EventArgs e)
        {
           // evaluarSobreendeuda();
        }
       
        #endregion

        #region Metodos
        public void evaluarSobreendeuda()
        {
            DataSet dsEvaluacion = sobreendeuda.obtieneResultadosEvaluacion(this.idCli, clsVarGlobal.dFecSystem);

            dtResultados = dsEvaluacion.Tables[0];

            
            Boolean lSobredeuda = false;
            foreach (DataRow item in dtResultados.Rows)
            {
                if (!String.IsNullOrEmpty(item["nVariacion"].ToString()))
                {
                    item["lCumpleSigno"] = comparaVariacionSiCumple(item["cSigno"].ToString(), Convert.ToDecimal(item["nConstanteBase"].ToString()), Convert.ToDecimal(item["nVariacion"].ToString()));
                    if (Convert.ToBoolean(item["lCumpleSigno"]))
                    {
                        lSobredeuda = true;
                    }
                    else
                    {
                        DataRow drFila = item;
                        drFila.Delete();
                    }
                }
                else
                {
                    DataRow drFila = item;
                    drFila.Delete();
                }
            }
            dtResultados.AcceptChanges();            

            if (lSobredeuda)
            {
                dtCuentas = dsEvaluacion.Tables[1];
                guardarSobreendeuda();
                cargarEvaluacion(dtResultados);
                if (MessageBox.Show("El cliente presenta riesgo de sobreendeudamiento, Pulse ACEPTAR para ver detalles.", "Validación de Sobreendeudamiento", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    this.ShowDialog();      
                }                                                               
            }
            else
            {                
            }           
        }
        public void cargarEvaluacion(DataTable dtResultadoLocal)
        {
            this.dtgEvaluacion.DataSource = dtResultadoLocal;
            formatoDTGEvaluacion();
        }
        private void guardarSobreendeuda()
        {
            DataSet dsCuentasSobreE = new DataSet("DSCuentas");
            String xmlCuentasSobreE = String.Empty;
            DataTable dtCuentasLocal = dtCuentas.Copy();

            DataSet dsResultados = new DataSet("DSResultados");
            String xmlResultados = String.Empty;
            DataTable dtResultadosLocal = dtResultados.Copy();

            if (dtCuentasLocal.Rows.Count > 0 && dtResultadosLocal.Rows.Count > 0)
            {
                dsCuentasSobreE.Tables.Add(dtCuentasLocal);
                xmlCuentasSobreE = dsCuentasSobreE.GetXml();
                xmlCuentasSobreE = clsCNFormatoXML.EncodingXML(xmlCuentasSobreE);
                dsCuentasSobreE.Tables.Clear();

                dsResultados.Tables.Add(dtResultadosLocal);
                xmlResultados = dsResultados.GetXml();
                xmlResultados = clsCNFormatoXML.EncodingXML(xmlResultados);
                dsResultados.Tables.Clear();

                DataTable guardado = sobreendeuda.guardaSaldosSobredeuda(idCli, clsVarGlobal.User.idUsuario , clsVarGlobal.dFecSystem, xmlCuentasSobreE, xmlResultados);
                if (Convert.ToInt32(guardado.Rows[0]["idError"].ToString()) == 1)
                {
                    MessageBox.Show(guardado.Rows[0]["cMensaje"].ToString(), "Validación de Sobreendeudamiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }            
        }

        private void formatoDTGEvaluacion()
        {                      
            foreach (DataGridViewColumn item in this.dtgEvaluacion.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }
           
            this.dtgEvaluacion.Columns["cParametro"].Visible = true;
            this.dtgEvaluacion.Columns["cDescripcion"].Visible = true;
            this.dtgEvaluacion.Columns["cDetalleFormula"].Visible = true;
            //this.dtgEvaluacion.Columns["nVariacion"].Visible = true;
            //this.dtgEvaluacion.Columns["cSigno"].Visible = true;
            //this.dtgEvaluacion.Columns["nConstanteBase"].Visible = true;
            //this.dtgEvaluacion.Columns["cSimbolo"].Visible = true;

            this.dtgEvaluacion.Columns["cParametro"].FillWeight = 60;
            //this.dtgEvaluacion.Columns["cDescripcion"].FillWeight = 50;
            this.dtgEvaluacion.Columns["cDetalleFormula"].FillWeight = 130;
            this.dtgEvaluacion.Columns["nVariacion"].FillWeight = 25;
            this.dtgEvaluacion.Columns["cSigno"].FillWeight = 10;
            this.dtgEvaluacion.Columns["nConstanteBase"].FillWeight = 25;
            this.dtgEvaluacion.Columns["cSimbolo"].FillWeight = 10;

            this.dtgEvaluacion.Columns["cParametro"].HeaderText = "Parámetro";
            this.dtgEvaluacion.Columns["cDescripcion"].HeaderText = "Descripción";
            this.dtgEvaluacion.Columns["cDetalleFormula"].HeaderText = "Formula";
            this.dtgEvaluacion.Columns["nVariacion"].HeaderText = "Variación";
            this.dtgEvaluacion.Columns["cSigno"].HeaderText = "";
            this.dtgEvaluacion.Columns["nConstanteBase"].HeaderText = "Límite";
            //this.dtgEvaluacion.Columns["cSimbolo"].HeaderText = "";

            //foreach (DataGridViewRow item in this.dtgEvaluacion.Rows)
            //{
            //    item.Cells["nVariacion"].Value = item.Cells["nVariacion"].Value + "" + item.Cells["cSimbolo"].Value;
            //}
        }
        private Boolean comparaVariacionSiCumple(String cSigno, Decimal nKonstante, Decimal nEnEvaluacion)
        {
            Boolean lRpt = false;
            switch (cSigno)
            {
                case (">"):
                    if (nEnEvaluacion > nKonstante)
                    {
                        lRpt = true;
                    }
                    break;
                case (">="):
                    if (nEnEvaluacion >= nKonstante)
                    {
                        lRpt = true;
                    }
                    break;
                case ("="):
                    if (nEnEvaluacion == nKonstante)
                    {
                        lRpt = true;
                    }
                    break;
                case ("<="):
                    if (nEnEvaluacion <= nKonstante)
                    {
                        lRpt = true;
                    }
                    break;
                case ("<"):
                    if (nEnEvaluacion < nKonstante)
                    {
                        lRpt = true;
                    }
                    break;
            }
            return lRpt;
        }      
        
        #endregion


    }
}

