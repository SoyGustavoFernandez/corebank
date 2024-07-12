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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPT.Presentacion
{
    public partial class frmAnexo16BConting : frmBase
    {
        DataTable dtAnexo16B, dtAnexo16BME;
        DataSet dsAnexo16B;
        decimal PEMN, PEME;
        public frmAnexo16BConting()
        {
            InitializeComponent();
            clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            DataRow dataRow = dtAnexo16B.NewRow();
            dataRow["cDescripcion"] = "";
            dataRow["c30MN"] = 0;
            dataRow["c60MN"] = 0;
            dataRow["c90MN"] = 0;
            dataRow["c120MN"] = 0;
            dataRow["c150MN"] = 0;
            dataRow["c180MN"] = 0;
            dataRow["c270MN"] = 0;
            dataRow["c360MN"] = 0;
            dataRow["c1AMN"] = 0;
            dataRow["cTotalMN"] = 0;
            dataRow["nNivel"] = 0;
            dataRow["nOrden"] = 0;
            dataRow["nFlag"] = 1;
            dtAnexo16B.Rows.Add(dataRow);
            //dataRow
            //dtgAnexo16B.CurrentRow.ReadOnly = false;

            CalculoSoles(dtAnexo16B);
        }

        private void CalculoSoles(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal nAcumula = 0;
                if (Convert.ToInt32(dt.Rows[i]["nFlag"]) == 1)
                {
                    for (int j = 1; j < dt.Columns.Count - 4; j++)
                    {
                        nAcumula = nAcumula + Convert.ToDecimal(dt.Rows[i][j]);
                    }
                    dt.Rows[i]["cTotalMN"] = nAcumula;
                }
            }

            for (int i = dt.Rows.Count - 1; i > 0; i--)
            {
                int nValor = Convert.ToInt32(dt.Rows[i]["nFlag"]);

                if (nValor == 2 || nValor == 3 || nValor == 4)
                {
                    dt.Rows.RemoveAt(i);
                }
            }

            var dr = dt.NewRow();
            dr = dt.NewRow();
            dr["cDescripcion"] = "Brecha total (I) - (II) + (IV)";
            dr["c30MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c30MN"]);
            dr["c60MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c60MN"]);
            dr["c90MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c90MN"]);
            dr["c120MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c120MN"]);
            dr["c150MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c150MN"]);
            dr["c180MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c180MN"]);
            dr["c270MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c270MN"]);
            dr["c360MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c360MN"]);
            dr["c1AMN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c1AMN"]);
            dr["cTotalMN"] = 0;
            dr["nNivel"] = 0;
            dr["nOrden"] = 44;
            dr["nflag"] = 2;
            dt.Rows.Add(dr);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal nAcumula = 0;
                if (Convert.ToInt32(dt.Rows[i]["nFlag"]) == 2)
                {
                    for (int j = 1; j < dt.Columns.Count - 4; j++)
                    {
                        nAcumula = nAcumula + Convert.ToDecimal(dt.Rows[i][j]);
                    }
                    dt.Rows[i]["cTotalMN"] = nAcumula;
                }
            }

            dtgAnexo16B.CurrentRow.DefaultCellStyle.BackColor = Color.AntiqueWhite;

            var query = dt.AsEnumerable().Where(y => (int)y["nflag"] == 2).ToList();

            dr = dt.NewRow();
            dr["cDescripcion"] = "Nueva brecha acumulada  (V)";
            for (int i = 1; i < dt.Columns.Count - 3; i++)
            {
                if (i == 1)
                {
                    dr[i] = (decimal)query[0][i];
                }
                else
                {
                    dr[i] = (decimal)query[0][i] + (decimal)dr[i - 1];
                }
            }
            dr["nNivel"] = 0;
            dr["nOrden"] = 45;
            dr["nflag"] = 3;
            dt.Rows.Add(dr);

            var drAc = dt.NewRow();
            drAc = dt.NewRow();
            drAc["cDescripcion"] = "Nueva brecha acumulada (V) / Patrimonio efectivo (21)";
            drAc["c30MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c30MN"]) / PEMN;
            drAc["c60MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c60MN"]) / PEMN;
            drAc["c90MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c90MN"]) / PEMN;
            drAc["c120MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c120MN"]) / PEMN;
            drAc["c150MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c150MN"]) / PEMN;
            drAc["c180MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c180MN"]) / PEMN;
            drAc["c270MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c270MN"]) / PEMN;
            drAc["c360MN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c360MN"]) / PEMN;
            drAc["c1AMN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c1AMN"]) / PEMN;
            drAc["cTotalMN"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["cTotalMN"]) / PEMN;
            drAc["nNivel"] = 0;
            drAc["nOrden"] = 46;
            drAc["nflag"] = 4;
            dt.Rows.Add(drAc);

            foreach (DataGridViewRow row in dtgAnexo16B.Rows)
            {
                foreach (DataGridViewColumn col in dtgAnexo16B.Columns)
                {
                    if (Convert.ToInt32(col.Index) > 0)
                    {
                        if (Convert.ToDecimal(dtgAnexo16B[col.Index, row.Index].Value) < 0)
                        {
                            dtgAnexo16B[col.Index, row.Index].Style.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void CalculoDolares(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal nAcumula = 0;
                if (Convert.ToInt32(dt.Rows[i]["nFlag"]) == 1)
                {
                    for (int j = 1; j < dt.Columns.Count - 4; j++)
                    {
                        nAcumula = nAcumula + Convert.ToDecimal(dt.Rows[i][j]);
                    }
                    dt.Rows[i]["cTotalME"] = nAcumula;
                }
            }

            for (int i = dt.Rows.Count - 1; i > 0; i--)
            {
                int nValor = Convert.ToInt32(dt.Rows[i]["nFlag"]);

                if (nValor == 2 || nValor == 3 || nValor == 4)
                {
                    dt.Rows.RemoveAt(i);
                }
            }

            var dr = dt.NewRow();
            dr = dt.NewRow();
            dr["cDescripcion"] = "Brecha total (I) - (II) + (IV)";
            dr["c30ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c30ME"]);
            dr["c60ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c60ME"]);
            dr["c90ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c90ME"]);
            dr["c120ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c120ME"]);
            dr["c150ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c150ME"]);
            dr["c180ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c180ME"]);
            dr["c270ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c270ME"]);
            dr["c360ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c360ME"]);
            dr["c1AME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 1).Sum(x => (decimal)x["c1AME"]);
            dr["cTotalME"] = 0;
            dr["nNivel"] = 0;
            dr["nOrden"] = 44;
            dr["nflag"] = 2;
            dt.Rows.Add(dr);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal nAcumula = 0;
                if (Convert.ToInt32(dt.Rows[i]["nFlag"]) == 2)
                {
                    for (int j = 1; j < dt.Columns.Count - 4; j++)
                    {
                        nAcumula = nAcumula + Convert.ToDecimal(dt.Rows[i][j]);
                    }
                    dt.Rows[i]["cTotalME"] = nAcumula;
                }
            }

            dtgME.CurrentRow.DefaultCellStyle.BackColor = Color.AntiqueWhite;

            var query = dt.AsEnumerable().Where(y => (int)y["nflag"] == 2).ToList();

            dr = dt.NewRow();
            dr["cDescripcion"] = "Nueva brecha acumulada  (V)";
            for (int i = 1; i < dt.Columns.Count - 3; i++)
            {
                if (i == 1)
                {
                    dr[i] = (decimal)query[0][i];
                }
                else
                {
                    dr[i] = (decimal)query[0][i] + (decimal)dr[i - 1];
                }
            }
            dr["nNivel"] = 0;
            dr["nOrden"] = 45;
            dr["nflag"] = 3;
            dt.Rows.Add(dr);

            var drAc = dt.NewRow();
            drAc = dt.NewRow();
            drAc["cDescripcion"] = "Nueva brecha acumulada (V) / Patrimonio efectivo (21)";
            drAc["c30ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c30ME"]) / PEME;
            drAc["c60ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c60ME"]) / PEME;
            drAc["c90ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c90ME"]) / PEME;
            drAc["c120ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c120ME"]) / PEME;
            drAc["c150ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c150ME"]) / PEME;
            drAc["c180ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c180ME"]) / PEME;
            drAc["c270ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c270ME"]) / PEME;
            drAc["c360ME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c360ME"]) / PEME;
            drAc["c1AME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["c1AME"]) / PEME;
            drAc["cTotalME"] = dt.AsEnumerable().Where(y => (int)y["nflag"] == 3).Sum(x => (decimal)x["cTotalME"]) / PEME;
            drAc["nNivel"] = 0;
            drAc["nOrden"] = 46;
            drAc["nflag"] = 4;
            dt.Rows.Add(drAc);

            foreach (DataGridViewRow row in dtgME.Rows)
            {
                foreach (DataGridViewColumn col in dtgME.Columns)
                {
                    if (Convert.ToInt32(col.Index) > 0)
                    {
                        if (Convert.ToDecimal(dtgME[col.Index, row.Index].Value) < 0)
                        {
                            dtgME[col.Index, row.Index].Style.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }
        int columnTxt = 0;
        private void dtgAnexo16B_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            columnTxt = dtgAnexo16B.CurrentCell.ColumnIndex;
            
            if (txtbox != null)
            {
                if (columnTxt != 0)
                {
                    txtbox.MaxLength = 50;
                    txtbox.KeyDown += new KeyEventHandler(txtbox_KeyDown);
                    txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
                    txtbox.Select(txtbox.Text.Length, 0);
                }
            }
            
        }
        void txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                //Get the clipboard value
                string texto = Clipboard.GetText().Trim();
                ((TextBox)sender).Text = texto;
                int iRowIndex = dtgAnexo16B.CurrentRow.Index;
                int iColumnRow = dtgAnexo16B.CurrentCell.ColumnIndex;
                dtgAnexo16B.Rows[iRowIndex].Cells[iColumnRow].Value = texto;
                ((TextBox)sender).Select(texto.Length, 0);
            }
        }

        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (columnTxt==0)
            {
                return;
            }
            string texto = ((DataGridViewTextBoxEditingControl)sender).Text.ToString();
            if (((DataGridViewTextBoxEditingControl)sender).SelectionLength > 0)
            {
                e.Handled = false;
                valNum2(e, texto, sender);
                return;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            valNum(e, texto);

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

        private void dtgAnexo16B_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtAnexo16B != null)
            {
                CalculoSoles(dtAnexo16B);
            }
        }

        private void btnConsultar1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFecha.Value;
            DataTable dtPE = new clsRPTCNCredito().CNConsultaPE(dFecha);

            if (dtPE.Rows.Count == 0)
            {
                MessageBox.Show("No existe patrimonio Efectivo para el proceso", "Anexo 16B Contingencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            PEMN = Convert.ToDecimal(dtPE.Rows[0]["nPatrimonioMN"]);
            PEME = Convert.ToDecimal(dtPE.Rows[0]["nPatrimonioME"]);

            dsAnexo16B = new clsRPTCNCredito().CNDatosContingenciaAnexo16B(dFecha);
            ConsultaSupuestos();
            btnGrabar1.Enabled = true;
            CalculoSoles(dtAnexo16B);
            CalculoDolares(dtAnexo16BME);
        }

        private void ConsultaSupuestos()
        {
            if (dsAnexo16B == null)
            {
                return;
            }
            dtAnexo16B = dsAnexo16B.Tables[0];

            if (dtAnexo16B.Rows.Count == 0)
            {
                MessageBox.Show("No existe datos para el reporte", "Anexo 16B Contingencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnMiniAgregar1.Enabled = false;
                btnMiniQuitar1.Enabled = false;
                btnGrabar1.Enabled = false;
                return;
            }
            else
            {
                btnMiniAgregar1.Enabled = true;
                btnMiniQuitar1.Enabled = true;
                btnGrabar1.Enabled = true;
            }

            dtgAnexo16B.DataSource = dtAnexo16B;
            dtgAnexo16B.ReadOnly = false;
           
            // SOLES
            foreach (DataGridViewRow row in dtgAnexo16B.Rows)
            {
                row.ReadOnly = true;
                int nFila = Convert.ToInt32(row.Cells[11].Value);
                int nOrden = Convert.ToInt32(row.Cells[12].Value);
                int nFlag = Convert.ToInt32(row.Cells[13].Value);
                if (nOrden != 39 && nFlag == 1)
                {
                    row.ReadOnly = false;
                }
                switch (nFila)
                {
                    case 2:
                        row.DefaultCellStyle.BackColor = Color.AliceBlue;
                        break;

                    case 4:
                        row.DefaultCellStyle.BackColor = Color.SkyBlue;
                        break;
                }
            }

            foreach (DataGridViewRow row in dtgAnexo16B.Rows)
            {
                foreach (DataGridViewColumn col in dtgAnexo16B.Columns)
                {
                    if (Convert.ToInt32(col.Index) > 0)
                    {
                        if (Convert.ToDecimal(dtgAnexo16B[col.Index, row.Index].Value) < 0)
                        {
                            dtgAnexo16B[col.Index, row.Index].Style.ForeColor = Color.Red;
                        }
                    }
                }
            }
            // Dólares
            dtAnexo16BME = dsAnexo16B.Tables[1];
            dtgME.DataSource = dtAnexo16BME;
            dtgME.ReadOnly = false;
            foreach (DataGridViewRow row2 in dtgME.Rows)
            {
                int nFila2 = Convert.ToInt32(row2.Cells[11].Value);
                int nOrden2 = Convert.ToInt32(row2.Cells[12].Value);
                int nFlag2 = Convert.ToInt32(row2.Cells[13].Value);
                if (nOrden2 != 39 && nFlag2 == 1)
                {
                    row2.ReadOnly = false;
                }
                switch (nFila2)
                {
                    case 2:
                        row2.DefaultCellStyle.BackColor = Color.AliceBlue;
                        break;
                    case 4:
                        row2.DefaultCellStyle.BackColor = Color.SkyBlue;
                        break;
                }
            }

            foreach (DataGridViewRow row1 in dtgME.Rows)
            {
                foreach (DataGridViewColumn col1 in dtgME.Columns)
                {
                    if (Convert.ToInt32(col1.Index) > 0)
                    {
                        if (Convert.ToDecimal(dtgME[col1.Index, row1.Index].Value) < 0)
                        {
                            dtgME[col1.Index, row1.Index].Style.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DateTime dFec = dtpFecha.Value;
            if (validar())
            {
                dsAnexo16B.Tables.Remove(dsAnexo16B.Tables[0]);

                DataSet ds = new DataSet("dsAnexo16BMN");
                String XmlMN;
                ds.Tables.Add(dtAnexo16B);
                XmlMN = ds.GetXml();
                XmlMN = clsCNFormatoXML.EncodingXML(XmlMN);

                dsAnexo16B.Tables.Remove(dsAnexo16B.Tables[0]);
                DataSet dsME = new DataSet("dsAnexo16BME");
                String XmlME;
                dsME.Tables.Add(dtAnexo16BME);
                XmlME = dsME.GetXml();
                XmlME = clsCNFormatoXML.EncodingXML(XmlME);

                DataTable dtResulta = new clsRPTCNCredito().CNInsertaConting(dFec, XmlMN, XmlME);
                if (Convert.ToInt32(dtResulta.Rows[0]["nResulta"]) == 1)
                {
                    MessageBox.Show("Registro correcto", "Anexo 16B Contingencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error de registro", "Anexo 16B Contingencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            btnGrabar1.Enabled = false;
        }

        private Boolean validar()
        {
            if (dtgAnexo16B.RowCount > 0)
            {
                for (int i = 0; i < dtAnexo16B.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dtgAnexo16B.Rows[i].Cells["cDescripcion"].Value.ToString()))
                    {
                        dtgAnexo16B.Rows[i].Cells["cDescripcion"].Selected = true;
                        MessageBox.Show("Existen descripciones vacias", "Graba anexo 16B - Contingencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgAnexo16B.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtAnexo16B.Rows[dtgAnexo16B.CurrentRow.Index]["nFlag"]) == 1 && Convert.ToDecimal(dtAnexo16B.Rows[dtgAnexo16B.CurrentRow.Index]["nOrden"])!= 39)
                {
                    dtAnexo16B.Rows.RemoveAt(dtgAnexo16B.CurrentRow.Index);
                    this.dtgAnexo16B.Refresh();
                    CalculoSoles(dtAnexo16B);
                }
            }
        }

        private void Anexo16B_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultaSupuestos();
        }

        private void btnMiniAgregar2_Click(object sender, EventArgs e)
        {
            DataRow dataRow = dtAnexo16BME.NewRow();
            dataRow["cDescripcion"] = "";
            dataRow["c30ME"] = 0;
            dataRow["c60ME"] = 0;
            dataRow["c90ME"] = 0;
            dataRow["c120ME"] = 0;
            dataRow["c150ME"] = 0;
            dataRow["c180ME"] = 0;
            dataRow["c270ME"] = 0;
            dataRow["c360ME"] = 0;
            dataRow["c1AME"] = 0;
            dataRow["cTotalME"] = 0;
            dataRow["nNivel"] = 0;
            dataRow["nOrden"] = 0;
            dataRow["nFlag"] = 1;
            dtAnexo16BME.Rows.Add(dataRow);
            dtgME.CurrentRow.ReadOnly = false;

            CalculoDolares(dtAnexo16BME);
        }

        private void dtgME_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            int columnTxt = dtgME.CurrentCell.ColumnIndex;
            if (columnTxt != 0 && txtbox != null)
            {
                txtbox.MaxLength = 50;
                txtbox.KeyDown += new KeyEventHandler(txtbox_KeyDown);
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
                txtbox.Select(txtbox.Text.Length, 0);
            }
        }

        private void dtgME_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtAnexo16BME != null)
            {
                CalculoDolares(dtAnexo16BME);
            }
        }

        private void btnMiniQuitar2_Click(object sender, EventArgs e)
        {
            if (dtgME.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtAnexo16BME.Rows[dtgME.CurrentRow.Index]["nFlag"]) == 1 && Convert.ToDecimal(dtAnexo16BME.Rows[dtgME.CurrentRow.Index]["nOrden"]) != 39)
                {
                    dtAnexo16B.Rows.RemoveAt(dtgME.CurrentRow.Index);
                    this.dtgME.Refresh();
                    CalculoDolares(dtAnexo16BME);
                }
            }

        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            int nDato;
        }
    }
}
