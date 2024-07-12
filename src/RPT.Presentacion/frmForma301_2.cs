using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPT.Presentacion
{
    public partial class frmForma301_2 : frmBase
    {
        DataTable dtBalance, dtParteII, dtParteV, dtParteVI;
        DataSet dsBalance;
        public frmForma301_2()
        {
            InitializeComponent();
            dtpFecProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnGenerar1_Click(object sender, EventArgs e)
        {
            DateTime dFecha;
            dFecha = dtpFecProceso.Value.Date;

            dsBalance = new clsRPTCNContabilidad().CNConsultaForma301(dFecha,"02");
            dtBalance = dsBalance.Tables[0];
            if (dtBalance.Rows.Count>0)
            {
                if (MessageBox.Show("Existen datos generados ¿Esta seguro de sobreescribirlos?", "Formato 301", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    dsBalance = null;
                    dsBalance = new clsRPTCNContabilidad().CNForma301_2(dFecha);
                }
            }
            else
            {
                dsBalance = null;
                dsBalance = new clsRPTCNContabilidad().CNForma301_2(dFecha);
            }

            dtBalance = dsBalance.Tables[0];
            dtgForma301.DataSource = dtBalance;

            dtParteII = dsBalance.Tables[1];
            dtgParteII.DataSource = dtParteII;

            dtParteV = dsBalance.Tables[2];
            dtgV.DataSource = dtParteV;

            dtParteVI = dsBalance.Tables[3];
            dtgVI.DataSource = dtParteVI;

            btnGrabar1.Enabled = true;
            btnImprimir1.Enabled = false;
            btnExportar1.Enabled = false;
            FormatoGrid();
        }

        private void FormatoGrid()
        {
            //foreach (System.Data.DataColumn col in dtBalance.Columns)
            //    col.ReadOnly = false;
            dtgForma301.ReadOnly = false;

            foreach (DataGridViewRow row in dtgForma301.Rows)
            {
                foreach (DataGridViewColumn col in dtgForma301.Columns)
                {
                    dtgForma301[col.Index, row.Index].ReadOnly = true;
                }
            }

            foreach (DataGridViewRow row in dtgForma301.Rows)
            {
                if (Convert.ToBoolean(dtgForma301[6, row.Index].Value))
                {
                    dtgForma301[10, row.Index].ReadOnly = false;
                    dtgForma301[12, row.Index].ReadOnly = false;
                    dtgForma301[14, row.Index].ReadOnly = false;
                    dtgForma301[10, row.Index].Style.BackColor = System.Drawing.Color.LightGreen;
                    dtgForma301[12, row.Index].Style.BackColor = System.Drawing.Color.LightGreen;
                    dtgForma301[14, row.Index].Style.BackColor = System.Drawing.Color.LightGreen;
                }
            }
            dtgV.ReadOnly = false;
            foreach (DataGridViewRow row in dtgV.Rows)
            {
                foreach (DataGridViewColumn col in dtgV.Columns)
                {
                    dtgV[col.Index, row.Index].ReadOnly = true;
                }
            }

            foreach (DataGridViewRow row in dtgV.Rows)
            {
                if (Convert.ToBoolean(dtgV[5, row.Index].Value))
                {
                    dtgV[7, row.Index].ReadOnly = false;
                    dtgV[8, row.Index].ReadOnly = false;
                    dtgV[9, row.Index].ReadOnly = false;
                    dtgV[7, row.Index].Style.BackColor = System.Drawing.Color.LightGreen;
                    dtgV[8, row.Index].Style.BackColor = System.Drawing.Color.LightGreen;
                    dtgV[9, row.Index].Style.BackColor = System.Drawing.Color.LightGreen;
                }
            }

            dtgVI.ReadOnly = false;
            foreach (DataGridViewRow row in dtgVI.Rows)
            {
                foreach (DataGridViewColumn col in dtgVI.Columns)
                {
                    dtgVI[col.Index, row.Index].ReadOnly = true;
                }
            }

            foreach (DataGridViewRow row in dtgVI.Rows)
            {
                if (Convert.ToBoolean(dtgVI[5, row.Index].Value))
                {
                    dtgVI[8, row.Index].ReadOnly = false;
                    dtgVI[10, row.Index].ReadOnly = false;
                    dtgVI[12, row.Index].ReadOnly = false;
                    dtgVI[8, row.Index].Style.BackColor = System.Drawing.Color.LightGreen;
                    dtgVI[10, row.Index].Style.BackColor = System.Drawing.Color.LightGreen;
                    dtgVI[12, row.Index].Style.BackColor = System.Drawing.Color.LightGreen;
                }
            }
        }

        private void CalculaVariacion(DataTable dtFormaA) 
        {
            //Colocaciones Brutas
            var dr = dtFormaA.NewRow();
            dr = dtFormaA.NewRow();
            dr["nOrden"] = 0;
            dr["cFila"] = "";
            dr["idAcumula"] = 0;
            dr["nNivel"] = 0;
            dr["idGrupo"] = 0;
            dr["lEscritura"] = false;
            dr["nAnioAnt"] = 0;
            dr["nAnioBas"] = 0;
            dr["vAnioBas"] = 0;
            dr["nProA1"] = dtFormaA.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 6).Sum(x => (double)x["nProA1"]);
            dr["vProA1"] = 0;
            dr["nProA2"] = dtFormaA.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 6).Sum(x => (double)x["nProA2"]);
            dr["vProA2"] = 0;
            dr["nProA3"] = dtFormaA.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 6).Sum(x => (double)x["nProA3"]);
            dr["vProA3"] = 0;

            dtFormaA.Rows[4][9] = dr["nProA1"];
            dtFormaA.Rows[4][11] = dr["nProA2"];
            dtFormaA.Rows[4][13] = dr["nProA3"];

            //Provisiones para colocaciones
            var drProv = dtFormaA.NewRow();
            drProv = dtFormaA.NewRow();
            drProv["nOrden"] = 0;
            drProv["cFila"] = "";
            drProv["idAcumula"] = 0;
            drProv["nNivel"] = 0;
            drProv["idGrupo"] = 0;
            drProv["lEscritura"] = false;
            drProv["nAnioAnt"] = 0;
            drProv["nAnioBas"] = 0;
            drProv["vAnioBas"] = 0;
            drProv["nProA1"] = dtFormaA.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 8).Sum(x => (double)x["nProA1"]);
            drProv["vProA1"] = 0;
            drProv["nProA2"] = dtFormaA.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 8).Sum(x => (double)x["nProA2"]);
            drProv["vProA2"] = 0;
            drProv["nProA3"] = dtFormaA.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 8).Sum(x => (double)x["nProA3"]);
            drProv["vProA3"] = 0;

            dtFormaA.Rows[13][9] = drProv["nProA1"];
            dtFormaA.Rows[13][11] = drProv["nProA2"];
            dtFormaA.Rows[13][13] = drProv["nProA3"];

            // Variación anual
            for (int i = 0; i < dtFormaA.Columns.Count; i++)
            {
                if (i == 10)
                {
                    for (int j = 0; j < dtFormaA.Rows.Count; j++)
                    {
                        /*t+1*/
                        dtFormaA.Rows[j][10] = Convert.ToInt32(dtFormaA.Rows[j][7]) == 0 ? 0 :
                                                Math.Round(((Convert.ToDouble(dtFormaA.Rows[j][9]) / Convert.ToDouble(dtFormaA.Rows[j][7])) - 1) * 100.00, 5, MidpointRounding.AwayFromZero);
                        /*t+2*/
                        dtFormaA.Rows[j][12] = Convert.ToInt32(dtFormaA.Rows[j][9]) == 0 ? 0 :
                                                Math.Round(((Convert.ToDouble(dtFormaA.Rows[j][11]) / Convert.ToDouble(dtFormaA.Rows[j][9])) - 1) * 100.00, 5, MidpointRounding.AwayFromZero);
                        /*t+3*/
                        dtFormaA.Rows[j][14] = Convert.ToInt32(dtFormaA.Rows[j][11]) == 0 ? 0 :
                                                Math.Round(((Convert.ToDouble(dtFormaA.Rows[j][13]) / Convert.ToDouble(dtFormaA.Rows[j][11])) - 1) * 100.00, 5, MidpointRounding.AwayFromZero);

                        /*Datos Riesgo crediticio*/
                        if (j > 0 && j < 4)
                        {
                            dtParteII.Rows[j][7] = Math.Round(Convert.ToDouble(dtFormaA.Rows[j][9]) / 10.00, 2, MidpointRounding.AwayFromZero);
                            dtParteII.Rows[j][8] = Math.Round(Convert.ToDouble(dtFormaA.Rows[j][11]) / 10.00, 2, MidpointRounding.AwayFromZero);
                            dtParteII.Rows[j][9] = Math.Round(Convert.ToDouble(dtFormaA.Rows[j][13]) / 10.00, 2, MidpointRounding.AwayFromZero);
                        }
                    }
                }
            }

            //Indicadores
            double nCarteraPromedio = 0;
            double nPatrimoniPromedio = 0;
            nCarteraPromedio =
                (Convert.ToDouble(dtFormaA.Rows[4][7]) +
                Convert.ToDouble(dtFormaA.Rows[4][9]) +
                Convert.ToDouble(dtFormaA.Rows[4][11]) +
                Convert.ToDouble(dtFormaA.Rows[4][13])) / 4;

            nPatrimoniPromedio =
                (Convert.ToDouble(dtFormaA.Rows[27][7]) +
                    Convert.ToDouble(dtFormaA.Rows[27][9]) +
                    Convert.ToDouble(dtFormaA.Rows[27][11]) +
                    Convert.ToDouble(dtFormaA.Rows[27][13])) / 4;

            for (int i = 0; i < dtFormaA.Columns.Count; i++)
            {
                if (i==8 || i == 10 || i == 12 || i == 14)
                {
                    double nCarteraBruta = Convert.ToDouble(dtFormaA.Rows[4][i-1]);
                    double nCarAtrasada = Convert.ToDouble(dtFormaA.Rows[22][i - 1]);
                    double nCAR = Convert.ToDouble(dtFormaA.Rows[23][i - 1]);
                    double nProvision = Convert.ToDouble(dtFormaA.Rows[13][i - 1]);
                    double nGastoProv = Convert.ToDouble(dtFormaA.Rows[31][i - 1]);
                    double nUtiNeta = Convert.ToDouble(dtFormaA.Rows[34][i - 1]);

                    dtFormaA.Rows[35][i] = nCarteraBruta == 0 ? 0 : Math.Round(100 * (nCarAtrasada / nCarteraBruta), 5, MidpointRounding.AwayFromZero);
                    dtFormaA.Rows[36][i] = nCarteraBruta == 0 ? 0 : Math.Round(100 * (nCAR / nCarteraBruta), 5, MidpointRounding.AwayFromZero);
                    dtFormaA.Rows[37][i] = nCarAtrasada == 0 ? 0 : Math.Round(100 * (nProvision / nCarAtrasada), 5, MidpointRounding.AwayFromZero);
                    dtFormaA.Rows[38][i] = nCAR == 0 ? 0 : Math.Round(100 * (nProvision / nCAR), 5, MidpointRounding.AwayFromZero);
                    dtFormaA.Rows[39][i] = nCarteraPromedio == 0 ? 0 : Math.Round(100 * (nGastoProv / nCarteraPromedio), 5, MidpointRounding.AwayFromZero);
                    dtFormaA.Rows[40][i] = nPatrimoniPromedio == 0 ? 0 : Math.Round(100 * (nUtiNeta / nPatrimoniPromedio), 5, MidpointRounding.AwayFromZero);
                }
            }
        }
        private Boolean Valida()
        {
            int t = 1;
            for (int i = 0; i < dtBalance.Columns.Count; i++)
            {
              if (i == 9 || i == 11 || i == 13)
                {

                    decimal nActivo = Convert.ToDecimal(dtBalance.Rows[0][i]);
                    decimal nPasivo = Convert.ToDecimal(dtBalance.Rows[24][i]);
                    decimal nPatrimonio = Convert.ToDecimal(dtBalance.Rows[27][i]);

                    if (nActivo != nPasivo + nPatrimonio)
                    {
                        MessageBox.Show("Activo difiere de Pasivo más Patrimonio en (t+" + t.ToString() + "), \n\r" +
                                        "Activo = " + nActivo.ToString() + "\n\r" +
                                        "Pasivo + Patrimonio = " + (nPasivo + nPatrimonio).ToString() + "\n\r" +
                                        "Diferencia = " + (nActivo-(nPasivo+nPatrimonio)).ToString(), "Validación Formato 301", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return true;
                        btnGrabar1.Enabled = true;
                    }
                    t = t + 1;
                }
            }
            return false;
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (Valida())
            {
                return;
            }
            DateTime dFecha = dtpFecProceso.Value.Date;
            dsBalance.Tables.Remove(dsBalance.Tables[0]);

            DataSet dsPI = new DataSet("dsParteI");
            String XmlParteI;
            dsPI.Tables.Add(dtBalance);
            XmlParteI = dsPI.GetXml();
            XmlParteI = clsCNFormatoXML.EncodingXML(XmlParteI);

            dsBalance.Tables.Remove(dsBalance.Tables[0]);

            DataSet dsII = new DataSet("dsParteII");
            String XmlParteII;
            dsII.Tables.Add(dtParteII);
            XmlParteII = dsII.GetXml();
            XmlParteII = clsCNFormatoXML.EncodingXML(XmlParteII);

            dsBalance.Tables.Remove(dsBalance.Tables[0]);

            DataSet dsV = new DataSet("dsParteV");
            String XmlParteV;
            dsV.Tables.Add(dtParteV);
            XmlParteV = dsV.GetXml();
            XmlParteV = clsCNFormatoXML.EncodingXML(XmlParteV);

            dsBalance.Tables.Remove(dsBalance.Tables[0]);

            DataSet dsVI = new DataSet("dsParteVI");
            String XmlParteVI;
            dsVI.Tables.Add(dtParteVI);
            XmlParteVI = dsVI.GetXml();
            XmlParteVI = clsCNFormatoXML.EncodingXML(XmlParteVI);

            DataTable dtResulta = new clsRPTCNContabilidad().CNAlmacenaForma301_2(dFecha, XmlParteI, XmlParteII, XmlParteV, XmlParteVI);
            if (Convert.ToInt16(dtResulta.Rows[0][0]) == 0)
            {
                MessageBox.Show("Error actualización de Formato 301-Anexo 02", "Formato 301", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Actualización correcta-Anexo 02", "Formato 301", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGrabar1.Enabled = false;
                btnImprimir1.Enabled = true;
                btnExportar1.Enabled = true;
            }
        }

        void txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                //Get the clipboard value
                string texto = Clipboard.GetText().Trim();
                ((TextBox)sender).Text = texto;
                int iRowIndex = dtgForma301.CurrentRow.Index;
                int iColumnRow = dtgForma301.CurrentCell.ColumnIndex;
                dtgForma301.Rows[iRowIndex].Cells[iColumnRow].Value = texto;
                ((TextBox)sender).Select(texto.Length, 0);
            }
        }

        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)
                && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if (txt.SelectionLength != txt.TextLength)
            {
                if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == '-') && (txt.Text.Length > 0))
                {
                    e.Handled = true;
                }
            }


        }

        private void valNum(KeyPressEventArgs e, string texto)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (texto.IndexOf('.') > -1 && texto.Substring(texto.IndexOf(".")).Length > 2)

                    e.Handled = true;

                else
                    e.Handled = false;
            }
            else
            {
                var fff = (from L in texto
                           where L.ToString() == "."
                           select L).Count();

                if (fff <= 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void valNum2(KeyPressEventArgs e, string texto, object sender)
        {
            if (e.KeyChar == 8)
            {

                e.Handled = false;
                return;

            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            //e.Control && e.KeyCode == Keys.V
            else
            {

                var fff = (from L in texto.ToString()

                           where L.ToString() == "."
                           select L).Count();
                if (fff <= 0 && e.KeyChar.ToString() == ".")

                    e.Handled = false;
                else

                    e.Handled = true;
            }
        }

        private void tbcEEFF_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormatoGrid();
            CalculaVariacion(dtBalance);
        }

        private void dtgForma301_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dtBalance != null)
            {
                CalculaVariacion(dtBalance);
                CalculaVariacionII();
                CalculaVariacionV();
                CalculaVariacionVI();
            }
        }

        private void dtgForma301_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.MaxLength = 50;
                txtbox.KeyDown += new KeyEventHandler(txtbox_KeyDown);
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
                txtbox.Select(txtbox.Text.Length, 0);
            }
        }

        private void dtgParteII_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void CalculaVariacionII()
        {
            //Requerimiento de patrimonio efectivo Pilar 1
            var dr =dtParteII.NewRow();
            dr = dtParteII.NewRow();
            dr["nOrden"] = 0;
            dr["cFila"] = "";
            dr["idAcumula"] = 0;
            dr["nNivel"] = 0;
            dr["idGrupo"] = 0;
            dr["lEscritura"] = false;
            dr["vAnioBas"] = 0;
            dr["vProA1"] = dtParteII.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 30).Sum(x => (double)x["vProA1"]);
            dr["vProA2"] = dtParteII.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 30).Sum(x => (double)x["vProA2"]);
            dr["vProA3"] = dtParteII.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 30).Sum(x => (double)x["vProA3"]); 

            dtParteII.Rows[0][7] = dr["vProA1"];
            dtParteII.Rows[0][8] = dr["vProA2"];
            dtParteII.Rows[0][9] = dr["vProA3"];

            /*Agregación de necesidades de capital - plazo de adecuación*/
            int nTmp = 10;
            for (int i = 0; i < dtParteII.Columns.Count; i++)
            {
                for (int j = 0; j < dtParteII.Rows.Count; j++)
                {
                    if (i>6 && j>4 && j < 15)
                    {
                        double nVarActivo = Convert.ToDouble(dtBalance.Rows[0][nTmp]);
                        double nValor = Convert.ToDouble(dtParteII.Rows[j][i - 1]);
                        dtParteII.Rows[j][i] = Math.Round(nValor * (1 + nVarActivo / 100.00), 2, MidpointRounding.AwayFromZero);
                    }
                }
                if (i>6)
                {
                    nTmp = nTmp + 2;
                }
            }
            //Requerimiento de patrimonio efectivo adicional 
            var drProv = dtParteII.NewRow();
            drProv = dtParteII.NewRow();
            drProv["nOrden"] = 0;
            drProv["cFila"] = "";
            drProv["idAcumula"] = 0;
            drProv["nNivel"] = 0;
            drProv["idGrupo"] = 0;
            drProv["lEscritura"] = false;
            drProv["vAnioBas"] = 0;
            drProv["vProA1"] = dtParteII.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 34).Sum(x => (double)x["vProA1"]);
            drProv["vProA2"] = dtParteII.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 34).Sum(x => (double)x["vProA2"]);
            drProv["vProA3"] = dtParteII.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 34).Sum(x => (double)x["vProA3"]);

            dtParteII.Rows[4][7] = drProv["vProA1"];
            dtParteII.Rows[4][8] = drProv["vProA2"];
            dtParteII.Rows[4][9] = drProv["vProA3"];

            //Agregación de necesidades de capital-plazo de adecuación
            var drAgr = dtParteII.NewRow();
            drAgr = dtParteII.NewRow();
            drAgr["nOrden"] = 0;
            drAgr["cFila"] = "";
            drAgr["idAcumula"] = 0;
            drAgr["nNivel"] = 0;
            drAgr["idGrupo"] = 0;
            drAgr["lEscritura"] = false;
            drAgr["vAnioBas"] = 0;
            drAgr["vProA1"] = dtParteII.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 44).Sum(x => (double)x["vProA1"]);
            drAgr["vProA2"] = dtParteII.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 44).Sum(x => (double)x["vProA2"]);
            drAgr["vProA3"] = dtParteII.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 44).Sum(x => (double)x["vProA3"]);

            dtParteII.Rows[14][7] = drAgr["vProA1"];
            dtParteII.Rows[14][8] = drAgr["vProA2"];
            dtParteII.Rows[14][9] = drAgr["vProA3"];

            for (int i = 0; i < dtParteII.Columns.Count; i++)
            {
                if (i > 6)
                {
                    double nPatEfe = Convert.ToDouble(dtParteII.Rows[0][i]);
                    double nPatEfeAdi = Convert.ToDouble(dtParteII.Rows[4][i]);
                    double nPorAdi = Convert.ToDouble(dtParteII.Rows[15][i]);
                    dtParteII.Rows[16][i] = Math.Round(nPatEfe + nPatEfeAdi * nPorAdi / 100.00, 2, MidpointRounding.AwayFromZero);
                }
            }
        }

        private void CalculaVariacionV()
        {
            int nTmp = 0;
            for (int i = 0; i < dtParteV.Columns.Count; i++)
            {
                if (i > 6)
                {
                    double nPorCap = Convert.ToDouble(dtParteV.Rows[1][i]);
                    double nUtiNet = Convert.ToDouble(dtBalance.Rows[34][i + 2 + nTmp]);
                    dtParteV.Rows[0][i] = Math.Round(nPorCap * nUtiNet / 100.00, 2, MidpointRounding.AwayFromZero);
                    nTmp = nTmp + 1;
                }
            }
            //Total fuentes de fortalecimiento patrimonial 
            var drForPat = dtParteV.NewRow();
            drForPat = dtParteV.NewRow();
            drForPat["nOrden"] = 0;
            drForPat["cFila"] = "";
            drForPat["idAcumula"] = 0;
            drForPat["nNivel"] = 0;
            drForPat["idGrupo"] = 0;
            drForPat["lEscritura"] = false;
            drForPat["vAnioBas"] = 0;
            drForPat["vProA1"] = dtParteV.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 67).Sum(x => (double)x["vProA1"]);
            drForPat["vProA2"] = dtParteV.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 67).Sum(x => (double)x["vProA2"]);
            drForPat["vProA3"] = dtParteV.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 67).Sum(x => (double)x["vProA3"]);

            dtParteV.Rows[7][7] = drForPat["vProA1"];
            dtParteV.Rows[7][8] = drForPat["vProA2"];
            dtParteV.Rows[7][9] = drForPat["vProA3"];
        }

        private void CalculaVariacionVI()
        {
            //Utilidades con acuerdo de capitalización 
            int ntmp = 1;
            for (int i = 0; i < dtParteV.Columns.Count; i++)
            {
                if (i > 6)
                {
                    dtParteVI.Rows[3][i + ntmp] = dtParteV.Rows[0][i];
                    ntmp = ntmp + 1;
                }
            }
            //Patrimonio básico o patrimonio de nivel 1
            var drPat = dtParteVI.NewRow();
            drPat = dtParteVI.NewRow();
            drPat["nOrden"] = 0;
            drPat["cFila"] = "";
            drPat["idAcumula"] = 0;
            drPat["nNivel"] = 0;
            drPat["idGrupo"] = 0;
            drPat["lEscritura"] = false;
            drPat["nAnioBas"] = 0;
            drPat["vAnioBas"] = 0;
            drPat["nProA1"] = dtParteVI.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 70).Sum(x => (double)x["nProA1"]);
            drPat["vProA1"] = 0;
            drPat["nProA2"] = dtParteVI.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 70).Sum(x => (double)x["nProA2"]);
            drPat["vProA2"] = 0;
            drPat["nProA3"] = dtParteVI.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 70).Sum(x => (double)x["nProA3"]);
            drPat["vProA3"] = 0;

            dtParteVI.Rows[1][8] = drPat["nProA1"];
            dtParteVI.Rows[1][10] = drPat["nProA2"];
            dtParteVI.Rows[1][12] = drPat["nProA3"];

            //Patrimonio suplementario
            var drPatSup = dtParteVI.NewRow();
            drPatSup = dtParteVI.NewRow();
            drPatSup["nOrden"] = 0;
            drPatSup["cFila"] = "";
            drPatSup["idAcumula"] = 0;
            drPatSup["nNivel"] = 0;
            drPatSup["idGrupo"] = 0;
            drPatSup["lEscritura"] = false;
            drPatSup["nAnioBas"] = 0;
            drPatSup["vAnioBas"] = 0;
            drPatSup["nProA1"] = dtParteVI.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 76).Sum(x => (double)x["nProA1"]);
            drPatSup["vProA1"] = 0;
            drPatSup["nProA2"] = dtParteVI.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 76).Sum(x => (double)x["nProA2"]);
            drPatSup["vProA2"] = 0;
            drPatSup["nProA3"] = dtParteVI.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 76).Sum(x => (double)x["nProA3"]);
            drPatSup["vProA3"] = 0;

            dtParteVI.Rows[7][8] = drPatSup["nProA1"];
            dtParteVI.Rows[7][10] = drPatSup["nProA2"];
            dtParteVI.Rows[7][12] = drPatSup["nProA3"];

            //Patrimonio efectivo total
            var drPatEfe = dtParteVI.NewRow();
            drPatEfe = dtParteVI.NewRow();
            drPatEfe["nOrden"] = 0;
            drPatEfe["cFila"] = "";
            drPatEfe["idAcumula"] = 0;
            drPatEfe["nNivel"] = 0;
            drPatEfe["idGrupo"] = 0;
            drPatEfe["lEscritura"] = false;
            drPatEfe["nAnioBas"] = 0;
            drPatEfe["vAnioBas"] = 0;
            drPatEfe["nProA1"] = dtParteVI.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 69).Sum(x => (double)x["nProA1"]);
            drPatEfe["vProA1"] = 0;
            drPatEfe["nProA2"] = dtParteVI.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 69).Sum(x => (double)x["nProA2"]);
            drPatEfe["vProA2"] = 0;
            drPatEfe["nProA3"] = dtParteVI.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 69).Sum(x => (double)x["nProA3"]);
            drPatEfe["vProA3"] = 0;

            dtParteVI.Rows[0][8] = drPatEfe["nProA1"];
            dtParteVI.Rows[0][10] = drPatEfe["nProA2"];
            dtParteVI.Rows[0][12] = drPatEfe["nProA3"];

            for (int i = 0; i < dtParteVI.Columns.Count; i++)
            {
                if (i == 9 || i == 11 || i == 13)
                {
                    double nPatEfeTot = Convert.ToDouble(dtParteVI.Rows[0][i - 1]);
                    for (int j = 0; j < dtParteVI.Rows.Count; j++)
                    {
                        double nValor = Convert.ToDouble(dtParteVI.Rows[j][i - 1]);
                        dtParteVI.Rows[j][i] = nPatEfeTot == 0 ? 0 : Math.Round((nValor / nPatEfeTot) * 100.00, 5, MidpointRounding.AwayFromZero);
                    }
                }
            }

            var drProv = dtBalance.NewRow();//Agregación de activos ponderados por riesgo
            drProv = dtBalance.NewRow();
            drProv["nOrden"] = 0;
            drProv["cFila"] = "";
            drProv["idAcumula"] = 0;
            drProv["nNivel"] = 0;
            drProv["idGrupo"] = 0;
            drProv["lEscritura"] = false;
            drProv["nAnioAnt"] = 0;
            drProv["nAnioBas"] = 0;
            drProv["vAnioBas"] = 0;
            drProv["nProA1"] = dtBalance.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 99).Sum(x => (double)x["nProA1"]);
            drProv["vProA1"] = 0;
            drProv["nProA2"] = dtBalance.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 99).Sum(x => (double)x["nProA2"]);
            drProv["vProA2"] = 0;
            drProv["nProA3"] = dtBalance.AsEnumerable().Where(y => (decimal)y["idAcumula"] == 99).Sum(x => (double)x["nProA3"]);
            drProv["vProA3"] = 0;

            double nProA1 = Convert.ToDouble(drProv["nProA1"]);
            double nProA2 = Convert.ToDouble(drProv["nProA2"]);
            double nProA3 = Convert.ToDouble(drProv["nProA3"]);

            dtParteVI.Rows[13][9] = nProA1 == 0 ? 0 : Math.Round((Convert.ToDouble(dtParteVI.Rows[0][8]) / nProA1) * 100.00, 5, MidpointRounding.AwayFromZero);
            dtParteVI.Rows[13][11] = nProA2 == 0 ? 0 : Math.Round((Convert.ToDouble(dtParteVI.Rows[0][10]) / nProA2) * 100.00, 5, MidpointRounding.AwayFromZero);
            dtParteVI.Rows[13][13] = nProA3 == 0 ? 0 : Math.Round((Convert.ToDouble(dtParteVI.Rows[0][12]) / nProA3) * 100.00, 5, MidpointRounding.AwayFromZero);
        }

        private void dtgParteII_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.MaxLength = 50;
                txtbox.KeyDown += new KeyEventHandler(txtbox_KeyDown);
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
                txtbox.Select(txtbox.Text.Length, 0);
            }
        }

        private void dtgV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.MaxLength = 50;
                txtbox.KeyDown += new KeyEventHandler(txtbox_KeyDown);
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
                txtbox.Select(txtbox.Text.Length, 0);
            }
        }

        private void dtgV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculaVariacionV();
            CalculaVariacionVI();
        }

        private void dtgVI_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.MaxLength = 50;
                txtbox.KeyDown += new KeyEventHandler(txtbox_KeyDown);
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
                txtbox.Select(txtbox.Text.Length, 0);
            }
        }

        private void dtgVI_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculaVariacionVI();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFecProceso.Value.Date;
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString(), false));
            paramlist.Add(new ReportParameter("x_cEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dtsParteI", dtBalance));
            dtslist.Add(new ReportDataSource("dtsParteII", dtParteII));
            dtslist.Add(new ReportDataSource("dtsParteV", dtParteV));
            dtslist.Add(new ReportDataSource("dtsParteVI", dtParteVI));

            string reportpath = "RptFormato301B.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnExportar1_Click(object sender, EventArgs e)
        {
            Anexo16B(dtpFecProceso.Value.Date, "0301", "02");
        }

        private void Anexo16B(DateTime dFechaProceso, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsAnexos = DatoSucaveAnexo16B(dFechaProceso, cReporteSBS, cAnexoSbs);

            string cNomArc = "\\" + cAnexoSbs + dFechaProceso.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
            StreamWriter Archivo;
            Archivo = GeneraArchivoSucave(cNomArc);
            if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFechaProceso, 6))
            {
                CierreArchivo(Archivo, cNomArc);
            }
        }
        private DataSet DatoSucaveAnexo16B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            DataSet dsForma301 = new clsRPTCNContabilidad().CNSUCAVEForma301(dtpFecProceso.Value.Date, cReporteSBS, cAnexoSbs);
            DataTable T1 = dsForma301.Tables[0];
            T1.TableName = "Tab101";
            dsForma301.Tables.Remove(T1);

            DataSet dsAnexos = new DataSet();
            dsAnexos.Tables.AddRange(new DataTable[] { T1 });
            return dsAnexos;
        }

        private StreamWriter GeneraArchivoSucave(string cNomArc)
        {
            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cRuta;
            StreamWriter sr;
            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + cNomArc;
                sr = new StreamWriter(@cNomArc);
            }
            else
            {
                sr = null;
            }
            return sr;
        }
        private Boolean CargaDatosArchivo(string cReporteSBS, string cAnexoSbs, StreamWriter swArchivo, DataSet dsAnexo, Boolean lRegCero, DateTime dFecha, int nRegCodigoFila)
        {
            if (swArchivo == null)
            {
                return false;
            }
            string pcCadena;
            DataTable dtDato;
            pcCadena = cReporteSBS + cAnexoSbs + clsVarApl.dicVarGen["cCodInst"] + dFecha.ToString("yyyyMMdd") + "012";
            swArchivo.WriteLine(pcCadena);

            for (int i = 0; i < dsAnexo.Tables.Count; i++)
            {
                dtDato = dsAnexo.Tables[i];
                for (int j = 0; j < dtDato.Rows.Count; j++)
                {
                    pcCadena = (Convert.ToInt32((Convert.ToDecimal(dtDato.Rows[j]["nOrden"]) * 100)).ToString()).PadLeft(nRegCodigoFila, ' ') + dtDato.Rows[j]["cTexto"].ToString();
                    swArchivo.WriteLine(pcCadena);
                }
            }
            return true;
        }
        private void CierreArchivo(StreamWriter Archivo, string cNombreArchivo)
        {
            Archivo.Flush();
            Archivo.Close();
            MessageBox.Show("El archivo " + cNombreArchivo + " se genero correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
