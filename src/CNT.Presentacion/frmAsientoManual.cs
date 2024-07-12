using CNT.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.SqlServer.Dts.Runtime;
using RPT.CapaNegocio;

namespace CNT.Presentacion
{
    public partial class frmAsientoManual : frmBase
    {
        DataTable dtAsiento=new DataTable();
            clsCtaContable objctactb;
            int idTipTrx = 1; //1 Inserta 2 Edita
            clsCNBalance objBalance = new clsCNBalance();
            clsCNAsiento clsAsiento = new clsCNAsiento();
            private DataTable dtTipCambio;
            clsCNGenAdmOpe cnTipCambio = new clsCNGenAdmOpe();
            int nVoucher = 0;

        public frmAsientoManual()
        {
            InitializeComponent();
            clsCNMaestroCuenta ListaTipAsiento = new clsCNMaestroCuenta();
            DataTable dt = ListaTipAsiento.CNListaTipoAsiento();
            this.cboTipoAsiento.DataSource = dt;
            dt.Rows.RemoveAt(0);
            this.cboTipoAsiento.ValueMember = dt.Columns[0].ToString();
            this.cboTipoAsiento.DisplayMember = dt.Columns[1].ToString();
            this.cboTipoAsiento.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        public frmAsientoManual(int _nVoucher)
        {
            nVoucher = _nVoucher;
            InitializeComponent();
            clsCNMaestroCuenta ListaTipAsiento = new clsCNMaestroCuenta();
            DataTable dt = ListaTipAsiento.CNListaTipoAsiento();
            dt.Rows.RemoveAt(0);
            this.cboTipoAsiento.DataSource = dt;
            this.cboTipoAsiento.ValueMember = dt.Columns[0].ToString();
            this.cboTipoAsiento.DisplayMember = dt.Columns[1].ToString();
            this.cboTipoAsiento.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void frmAsientoManual_Load(object sender, EventArgs e)
        {

            /*
             * Este procedimiento queda bloqueado por pedido de contabilidad
             * se activará en cuanto ellos lo vulevan a solicitar
             * Guardar hasta entonces
             * 
            //Bloqueo de proceso
            string cFrm = this.Name;

            DataTable dtBloqueo = objBalance.ValidaProcesoEEFF(cFrm, clsVarGlobal.User.idUsuario);
            if (!string.IsNullOrEmpty(dtBloqueo.Rows[0]["cWinUser"].ToString()))
            {
                MessageBox.Show("Ejecutando la opción: " + dtBloqueo.Rows[0]["cMenu"].ToString() + "," + Environment.NewLine +
                             "por el usuario: " + dtBloqueo.Rows[0]["cWinUser"].ToString(), "Valida Proceso EEFF",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }
             * */

            cboMoneda moneda = new cboMoneda();
            idMoneda.ValueMember = "idMoneda";
            idMoneda.DisplayMember = "cMoneda";
            idMoneda.DataSource = moneda.CargaDatosConta();
            

            dtAsiento = clsAsiento.CNConsultaAsiento(0);
            dtAsiento.Columns["cDescripcion"].ReadOnly = false;
            dtAsiento.Columns["cCuentaContable"].ReadOnly = false;
            dtgAsiento.DataSource = dtAsiento;
            dtgAsiento.Enabled = true;
            dtgAsiento.ReadOnly = false;

            FormatoGrid();
            this.dtFecSistema.Value = clsVarGlobal.dFecSystem;
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dtAsiento.Rows.Clear();
            idTipTrx = 1;
            dtgAsiento.Refresh();
            dtgAsiento.Enabled = true;
            dtgAsiento.ReadOnly = false;
            dtAsiento.Columns["cDescripcion"].ReadOnly = false;
            dtAsiento.Columns["cCuentaContable"].ReadOnly = false;

            FormatoGrid();
            HabilitarGrid(true);

            txtGlosa.Clear();
            btnMiniAgregar1.Enabled = true;
            btnMiniQuitar1.Enabled = true;
            btnGrabar.Enabled = true;
            chcAsiReexp.Enabled = true;
            Sumariza();


            txtNumVoucher.Enabled = false;
            txtNumVoucher.Text = "0";
            //cboMoneda1.Enabled = true;
            cboTipoAsiento.Enabled = true;
            cboAgencias1.Enabled = true;
            txtGlosa.Enabled = true;

            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            btnImprimir1.Enabled = false;
            dtFecSistema.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            idTipTrx = 2;
            this.btnNuevo.Enabled = false;
            this.txtNumVoucher.Enabled = true;
            chcAsiReexp.Enabled = true;
            txtNumVoucher.Focus();
            btnEditar.Enabled = false;
            btnImprimir1.Enabled = false;
            btnEliminar.Enabled = false;
        }

        void cargardatos(int pnNumeroVoucher)
        {

            dtAsiento = clsAsiento.CNConsultaAsiento(pnNumeroVoucher);
            if (idTipTrx == 2 && dtAsiento.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos con el Numero de Voucher ingresado", "Editar Asientos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var nCantReexpresado = dtAsiento.AsEnumerable().Where(r => r.Field<int>("idMoneda") == 0).Count();
            var nCantSol = dtAsiento.AsEnumerable().Where(r => r.Field<int>("idMoneda") == 1).Count();
            var nCantDol = dtAsiento.AsEnumerable().Where(r => r.Field<int>("idMoneda") == 2).Count();
            if ((nCantSol + nCantDol) == 0 && nCantReexpresado > 0)
            {
                chcAsiReexp.Checked = true;
                chcAsiReexp.Enabled = false;
            }
            else
            {
                chcAsiReexp.Checked = false;
                chcAsiReexp.Enabled = true;
            }

            dtAsiento.Columns["cDescripcion"].ReadOnly = false;
            dtAsiento.Columns["cCuentaContable"].ReadOnly = false;
            dtgAsiento.DataSource = dtAsiento;
            dtgAsiento.Enabled = true;
            dtgAsiento.ReadOnly = false;
            FormatoGrid();
            HabilitarGrid(true);
            txtNumVoucher.Enabled = false;
            cboTipoAsiento.SelectedValue = Convert.ToInt32(dtAsiento.Rows[0]["idAsiento"]);
            dtFecSistema.Value = Convert.ToDateTime(dtAsiento.Rows[0]["dFecha"]);
            cboAgencias1.SelectedValue = Convert.ToInt32(dtAsiento.Rows[0]["idagencia"]);
            txtGlosa.Text = dtAsiento.Rows[0]["cGlosa"] == null ? "" : dtAsiento.Rows[0]["cGlosa"].ToString();
            txtRP.Text = dtAsiento.Rows[0]["cNombre"].ToString();
            btnMiniAgregar1.Enabled = true;
            btnMiniQuitar1.Enabled = true;
            btnGrabar.Enabled = true;
            btnImprimir1.Enabled = true;
            txtGlosa.Enabled = true;
            Sumariza();
            if (dtAsiento.Rows[0]["cTipGen"].ToString().Equals("A"))
            {
                btnMiniAgregar1.Enabled = false;
                btnMiniQuitar1.Enabled = false;
                dtFecSistema.Enabled = false;
                btnGrabar.Enabled = false;
                dtgAsiento.Columns["cCuentaContable"].ReadOnly = true;
                dtgAsiento.Columns["nDebe"].ReadOnly = true;
                dtgAsiento.Columns["nHaber"].ReadOnly = true;
                dtgAsiento.Columns["idMoneda"].ReadOnly = true;
                txtGlosa.ReadOnly = true;

            }
            if (dtAsiento.AsEnumerable().Where(r => r.Field<string>("cTipGen") == "A").Count() >= 1)
            {
                btnEliminar.Enabled = false;
            }
            else
            {
                btnEliminar.Enabled = true;
            }

        }
        void cargardatosGrabar(int pnNumeroVoucher)
        {

            dtAsiento = clsAsiento.CNConsultaAsiento(pnNumeroVoucher);

            dtgAsiento.DataSource = dtAsiento;
            //dtgAsiento.Enabled = true;
            dtgAsiento.ReadOnly = true;
            FormatoGrid();
            //HabilitarGrid(true);
            dtAsiento.Columns["cDescripcion"].ReadOnly = true;
            dtAsiento.Columns["cCuentaContable"].ReadOnly = true;
            txtNumVoucher.Enabled = false;
            cboTipoAsiento.SelectedValue = Convert.ToInt32(dtAsiento.Rows[0]["idAsiento"]);
            dtFecSistema.Value = Convert.ToDateTime(dtAsiento.Rows[0]["dFecha"]);
            cboAgencias1.SelectedValue = Convert.ToInt32(dtAsiento.Rows[0]["idagencia"]);
            txtGlosa.Text = dtAsiento.Rows[0]["cGlosa"] == null ? "" : dtAsiento.Rows[0]["cGlosa"].ToString();
            txtRP.Text = dtAsiento.Rows[0]["cNombre"].ToString();
            btnMiniAgregar1.Enabled = false;
            btnMiniQuitar1.Enabled = false;
            btnGrabar.Enabled = false;
            btnImprimir1.Enabled = false;
            txtGlosa.Enabled = false;
            Sumariza();
            if (dtAsiento.Rows[0]["cTipGen"].ToString().Equals("A"))
            {
                btnMiniAgregar1.Enabled = false;
                btnMiniQuitar1.Enabled = false;
                dtFecSistema.Enabled = false;
                btnGrabar.Enabled = false;
                dtgAsiento.Columns["cCuentaContable"].ReadOnly = true;
                dtgAsiento.Columns["nDebe"].ReadOnly = true;
                dtgAsiento.Columns["nHaber"].ReadOnly = true;
                dtgAsiento.Columns["idMoneda"].ReadOnly = true;
                txtGlosa.ReadOnly = true;

            }
        }

        private void txtNumVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                int nvoucher;
                bool canConvert = int.TryParse(txtNumVoucher.Text, out nvoucher);
                if (canConvert == false)
                {
                    MessageBox.Show("El numero de voucher debe ser un número", "Asientos Manual", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrEmpty(txtNumVoucher.Text) && Convert.ToInt32(txtNumVoucher.nvalor) > 0)
                {
                    cargardatos(Convert.ToInt32(txtNumVoucher.nvalor));
                }
            }
        }
        void FormatoGrid()
        {
            dtgAsiento.Columns["nDebe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgAsiento.Columns["nHaber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgAsiento.Columns["cTipGen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < dtgAsiento.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgAsiento["idMoneda", i].Value) == 0)
                    dtgAsiento.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.NavajoWhite;
                if (Convert.ToInt32(dtgAsiento["idMoneda", i].Value) == 1)
                    dtgAsiento.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Beige;
                if (Convert.ToInt32(dtgAsiento["idMoneda", i].Value) == 2)
                    dtgAsiento.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            }

        }

        public void HabilitarGrid(Boolean bVal)
        {
            dtgAsiento.ReadOnly = !bVal;
            dtgAsiento.Columns["cCuentaContable"].ReadOnly = !bVal;
            dtgAsiento.Columns["cDescripcion"].ReadOnly = bVal;
            dtgAsiento.Columns["cTipGen"].ReadOnly = bVal;
            dtgAsiento.Columns["nDebe"].ReadOnly = !bVal;
            dtgAsiento.Columns["nHaber"].ReadOnly = !bVal;
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            DataRow dataRow = dtAsiento.NewRow();
            dataRow["cCuentaContable"] = "";
            dataRow["cDescripcion"] = "";
            dataRow["nDebe"] = 0;
            dataRow["nHaber"] = 0;
            if (chcAsiReexp.Checked)
            {
                dataRow["idMoneda"] = 0;
                chcAsiReexp.Enabled = false;
            }
            else
            {
                dataRow["idMoneda"] = 1;
            }
            
            dataRow["idAsiento"] = cboTipoAsiento.SelectedValue;
            dataRow["dFecha"] = dtFecSistema.Value;
            dataRow["idagencia"] = clsVarGlobal.nIdAgencia;
            dataRow["cTipGen"] = "M";
            dataRow["lEditable"] = true;
            dataRow["idItemAsiento"] = 0;
            dataRow["cGlosa"] = txtGlosa.Text;
            dtAsiento.Rows.Add(dataRow);
            //dtgAsiento.Refresh();
            //dtgAsiento.Focus();
        }



        private bool ValidarAsiento()
        {
            //dtAsiento.AcceptChanges();

            dtTipCambio = cnTipCambio.RetornaTiposCambio(dtFecSistema.Value);
            if (dtTipCambio.Rows.Count <= 0)
            {
                return true;
            }
            decimal sumaSolesDb = 0, sumaSolesHb = 0, sumaCnvDolarDb = 0, sumaCnvDolarHb = 0;

            foreach (DataGridViewRow nRow in dtgAsiento.Rows)
            {
                if (nRow.Cells["idMoneda"].Value.Equals(1))
                {
                    sumaSolesHb = sumaSolesHb + (decimal)nRow.Cells["nHaber"].Value;
                    sumaSolesDb = sumaSolesDb + (decimal)nRow.Cells["nDebe"].Value;
                }
                else if (nRow.Cells["idMoneda"].Value.Equals(2))
                {
                    sumaCnvDolarHb = sumaCnvDolarHb + Math.Round((decimal)nRow.Cells["nHaber"].Value * RetornaTpCambio(nRow.Cells["cCuentaContable"].Value.ToString()), 2, MidpointRounding.AwayFromZero);
                    sumaCnvDolarDb = sumaCnvDolarDb + Math.Round((decimal)nRow.Cells["nDebe"].Value * RetornaTpCambio(nRow.Cells["cCuentaContable"].Value.ToString()), 2, MidpointRounding.AwayFromZero);
                }
            }
            if (sumaSolesDb + sumaCnvDolarDb != sumaSolesHb + sumaCnvDolarHb)
            {
                txtDiferencia.Text = ((sumaSolesDb + sumaCnvDolarDb) - (sumaSolesHb + sumaCnvDolarHb)).ToString();
                return true;
            }
            return false;
        }
        private Decimal RetornaTpCambio(string cuentaCtb)
        {
            switch (cuentaCtb.Substring(0, 1))
            {
                case "4":
                    return (decimal)dtTipCambio.Rows[0]["nTipCamProVen"];

                case "5":
                    return (decimal)dtTipCambio.Rows[0]["nTipCamProCom"];
            }
            return (decimal)dtTipCambio.Rows[0]["nTipCamFij"];
        }
        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgAsiento.Rows.Count > 0)
        {
                dtAsiento.Rows.RemoveAt(dtgAsiento.CurrentRow.Index);
                this.dtgAsiento.Refresh();
                Sumariza();
                if (dtAsiento.Rows.Count==0)
                {
            chcAsiReexp.Enabled = true;
        }
        }

            //if (dtgAsiento.Rows.Count > 0)
            //{
            //    dtAsiento.Rows.RemoveAt(dtgAsiento.CurrentCell.RowIndex);
            //    //dtAsiento.AcceptChanges();
            //    dtgAsiento.Refresh();
            //    dtgAsiento.Focus();
            //    dtgAsiento.Select();
            //    Sumariza();
            //}


        }


        private void btnCancelar1_Click(object sender, EventArgs e)
        {

            if (dtAsiento != null)
            {
                dtAsiento.Rows.Clear();
            }
            dtgAsiento.Refresh();
            txtGlosa.Text = "";
            txtTotDebeSol.Text = "0.0000";
            txtTotHabeSol.Text = "0.0000";
            txtTotDebeDol.Text = "0.0000";
            txtTotHabeDol.Text = "0.0000";
            txtTotDebeDolConvert.Text = "0.0000";
            txtTotHabeDolConvert.Text = "0.0000";
            txtNumVoucher.Text = "";
            txtNumVoucher.Enabled = false;
            btnEditar.Enabled = true;
            btnNuevo.Enabled = true;
            btnGrabar.Enabled = false;
            btnMiniAgregar1.Enabled = false;
            btnMiniQuitar1.Enabled = false;
            btnImprimir1.Enabled = false;
            cboTipoAsiento.Enabled = false;
            cboAgencias1.Enabled = false;
            cboTipoAsiento.SelectedValue = 1;
            txtGlosa.Enabled = false;
            cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
            dtFecSistema.Enabled = false;
            btnEliminar.Enabled = false;
            chcAsiReexp.Enabled = false;
            chcAsiReexp.Checked = false;
            txtRP.Clear();
        }

        private void HabilitaObjetos(Boolean lHabilita)
        {
            btnEditar.Enabled = lHabilita;
            btnNuevo.Enabled = lHabilita;
            btnMiniAgregar1.Enabled = lHabilita;
            btnMiniQuitar1.Enabled = lHabilita;
            cboTipoAsiento.Enabled = lHabilita;
            cboAgencias1.Enabled = lHabilita;
            dtgAsiento.ReadOnly = !lHabilita;
            dtFecSistema.Enabled = lHabilita;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                DataSet ds = new DataSet("dsAsiento");
                String XmlAsiento;
                DataTable InsAsiento;
                DateTime dfechaAsiento = this.dtFecSistema.Value;
                switch (idTipTrx)
                {
                    case 1:

                        ds.Tables.Add(dtAsiento);
                        XmlAsiento = ds.GetXml();
                        XmlAsiento = clsCNFormatoXML.EncodingXML(XmlAsiento);

                        InsAsiento = clsAsiento.CNInsertaAsiento(dfechaAsiento, (int)this.cboAgencias1.SelectedValue, (int)this.cboTipoAsiento.SelectedValue, XmlAsiento, txtGlosa.Text, clsVarGlobal.User.idUsuario);
                        if (Convert.ToInt32(InsAsiento.Rows[0]["nNumVoucher"]) > 0)
                        {
                            this.txtNumVoucher.Text = InsAsiento.Rows[0]["nNumVoucher"].ToString();
                            MessageBox.Show("Asiento generado correctamente Nro Voucher: " + this.txtNumVoucher.Text, "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            HabilitaObjetos(false);
                            btnGrabar.Enabled = false;
                            btnImprimir1.Enabled = true;
                            btnEliminar.Enabled = false;
                            txtGlosa.Enabled = false;
                            dtAsiento.Clear();
                            cargardatosGrabar(Convert.ToInt32(txtNumVoucher.nvalor));
                        }
                        else
                        {
                            MessageBox.Show("Error de grabacion", "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        //ds.Tables.Remove(dtAsiento);
                        break;
                    case 2:
                        DataTable dtActualiza;
                        dtActualiza = dtgAsiento.DataSource as DataTable;

                        DataTable dtlst = dtActualiza.AsEnumerable().Where(r => r.Field<int>("idMoneda") != 0).CopyToDataTable();

                        ds.Tables.Add(dtlst);
                        XmlAsiento = ds.GetXml();
                        XmlAsiento = clsCNFormatoXML.EncodingXML(XmlAsiento);
                        string cGlosaAct = txtGlosa.Text;
                        InsAsiento = clsAsiento.CNActualizaAsiento(dfechaAsiento, (int)this.cboAgencias1.SelectedValue, (int)this.cboTipoAsiento.SelectedValue, Convert.ToInt32(this.txtNumVoucher.Text), XmlAsiento, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, cGlosaAct);
                        if (Convert.ToInt32(InsAsiento.Rows[0]["nNumVoucher"]) > 0)
                        {
                            this.txtNumVoucher.Text = InsAsiento.Rows[0]["nNumVoucher"].ToString();
                            MessageBox.Show("Asiento actualizado correctamente, nro Voucher: " + this.txtNumVoucher.Text, "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            HabilitaObjetos(false);
                            btnGrabar.Enabled = false;
                            btnImprimir1.Enabled = true;
                            txtGlosa.Enabled = false;
                            dtAsiento.Clear();
                            btnEliminar.Enabled = false;
                            //dtgAsiento.DataSource = null;

                            cargardatosGrabar(Convert.ToInt32(txtNumVoucher.nvalor));
                        }
                        else
                        {
                            MessageBox.Show("Error de grabacion", "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        ds.Tables.Remove(dtlst);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                return;
            }
        }

        private void btnImprimir1_Click_1(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            DateTime dFecha = this.dtFecSistema.Value;

            string RutaLogo = new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString();

            int idTipAsi = (int)cboTipoAsiento.SelectedValue;

            dtslist.Add(new ReportDataSource("dtsAsientoMan", dtAsiento));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_idVoucher", "1", false));
            paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cAsiento", cboTipoAsiento.Text, false));
            paramlist.Add(new ReportParameter("cAgencia", cboAgencias1.Text, false));
            paramlist.Add(new ReportParameter("cRutaLogo", RutaLogo, false));

            string reportpath = "RptAsientoManual.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private Boolean Validar()
        {
            if (!((int)clsVarApl.dicVarGen["nAnioCNT"] == dtFecSistema.Value.Year && (int)clsVarApl.dicVarGen["nMesCNT"] == dtFecSistema.Value.Month))
            {
                MessageBox.Show("El año y el mes elegido deben pertenecer al periodo contable", "Grabar Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtgAsiento.RowCount <= 0)
            {
                MessageBox.Show("Debe ingresar datos de las cuentas contables", "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToInt32(cboTipoAsiento.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de asiento", "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToInt32(cboAgencias1.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de asiento", "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtGlosa.Text))
            {
                MessageBox.Show("Debe registrar una glosa", "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToDecimal(txtTotDebeSol.Text) == 0 && Convert.ToDecimal(txtTotDebeDol.Text) == 0 && Convert.ToDecimal(txtTotHabeSol.Text) == 0 && Convert.ToDecimal(txtTotHabeDol.Text) == 0 && chcAsiReexp.Checked==false)
            {
                MessageBox.Show("Debe ingresar montos mayores a cero", "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToDecimal(txtTotDebeDolConvert.Text) == 0 && Convert.ToDecimal(txtTotHabeDolConvert.Text) == 0 && chcAsiReexp.Checked == true)
            {
                MessageBox.Show("Debe ingresar montos mayores a cero", "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }



            if (dtgAsiento.RowCount > 0)
            {
                Sumariza();
                for (int i = 0; i < dtAsiento.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dtgAsiento.Rows[i].Cells["cCuentaContable"].Value.ToString()))
                    {
                        dtgAsiento.Rows[i].Cells["cCuentaContable"].Selected = true;
                        MessageBox.Show("Existen cuentas vacias", "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            int NroMonSol = dtAsiento.AsEnumerable().Where(r => r.Field<int>("idMoneda") == 1).Count();
            int NroMonDol = dtAsiento.AsEnumerable().Where(r => r.Field<int>("idMoneda") == 2).Count();
            if ((NroMonSol == 0 && NroMonDol >= 1) || (NroMonSol >= 1 && NroMonDol == 0))
            {

                if (Convert.ToDecimal(this.txtTotDebeSol.Text) + Convert.ToDecimal(txtTotDebeDol.Text) + Convert.ToDecimal(txtTotDebeDolConvert.Text) !=
                       Convert.ToDecimal(this.txtTotHabeSol.Text) + Convert.ToDecimal(txtTotHabeDol.Text) + Convert.ToDecimal(txtTotHabeDolConvert.Text))
                {
                    string cDiferencia = Convert.ToString(Convert.ToDecimal(this.txtTotDebeSol.Text) + Convert.ToDecimal(txtTotDebeDol.Text) - (Convert.ToDecimal(this.txtTotHabeSol.Text)) + Convert.ToDecimal(txtTotHabeDol.Text));
                    MessageBox.Show("Existen diferencias entre Debe y Haber: " + cDiferencia, "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }

            if (ValidarAsiento())
            {
                if (dtTipCambio.Rows.Count <= 0)
                {
                    MessageBox.Show("No existe tipo de cambio para la fecha " + dtFecSistema.Value.ToShortDateString(), "Valida registro asiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                MessageBox.Show("La suma del debe y el haber debe cuadrar", "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void dtgAsiento_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgAsiento.RowCount > 0)
            {

                if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
                {
                    Sumariza();
                }
                }
            }

        private Boolean ValidarCtaCtb(string pcCodCtb)
        {
            objctactb = new clsCNCtaContable().detallectactb(pcCodCtb);
            int iRowIndex = dtgAsiento.CurrentRow.Index;
            if (string.IsNullOrEmpty(objctactb.cDescripcion))
            {
                MessageBox.Show("La cuenta debe existir", "Graba Cuenta Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtgAsiento.Rows[iRowIndex].Cells["cCuentaContable"].Value = "";
                dtgAsiento.Rows[iRowIndex].Cells["cDescripcion"].Value = "";
                return true;
        }

            if (objctactb.nHijos > 0)
            {
                MessageBox.Show("Cuenta debe ser del ultimo nivel", "Graba Cuenta Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtgAsiento.Rows[iRowIndex].Cells["cCuentaContable"].Value = "";
                dtgAsiento.Rows[iRowIndex].Cells["cDescripcion"].Value = "";
                return true;
            }
            dtgAsiento.Rows[iRowIndex].Cells["cCuentaContable"].Value = objctactb.cCuentaContable;
            dtgAsiento.Rows[iRowIndex].Cells["cDescripcion"].Value = objctactb.cDescripcion;
            return false;
        }
        private void dtgAsiento_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.MaxLength = 50;
                txtbox.KeyDown += new KeyEventHandler(txtbox_KeyDown);
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
                txtbox.Select(txtbox.Text.Length, 0);
            }

            ComboBox comboMon = e.Control as ComboBox;
            if (comboMon != null)
            {
                comboMon.SelectedIndexChanged -= new EventHandler(cboMoneda_SelectedIndexChanged);
                comboMon.SelectedIndexChanged += new EventHandler(cboMoneda_SelectedIndexChanged);
            }
        }
        void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MonAnt = Convert.ToInt32(dtgAsiento.Rows[dtgAsiento.CurrentRow.Index].Cells["idMoneda"].Value);

            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedValue != null)
            {
                string idMoneda = cb.SelectedValue.ToString();

                if (!idMoneda.Equals("System.Data.DataRowView"))
                {
                    int nMoneda = Convert.ToInt32(idMoneda);
                    if (nMoneda == 0)
                    {
                        cb.SelectedValue = MonAnt;
                    }
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
                int iRowIndex = dtgAsiento.CurrentRow.Index;
                int iColumnRow = dtgAsiento.CurrentCell.ColumnIndex;
                dtgAsiento.Rows[iRowIndex].Cells[iColumnRow].Value = texto;
                ((TextBox)sender).Select(texto.Length, 0);
            }
        }

        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void Sumariza()
        {
            if (dtAsiento != null)
            {
                //dtAsiento.AcceptChanges();
                var nDebe = dtAsiento.AsEnumerable().Where(r => r.Field<int>("idMoneda") == 1).Sum(x => x.Field<decimal>("nDebe"));
                this.txtTotDebeSol.Text = nDebe.ToString();

                var nHaber = dtAsiento.AsEnumerable().Where(r => r.Field<int>("idMoneda") == 1).Sum(x => x.Field<decimal>("nHaber"));
                this.txtTotHabeSol.Text = nHaber.ToString();

                var nDebeDol = dtAsiento.AsEnumerable().Where(r => r.Field<int>("idMoneda") == 2).Sum(x => x.Field<decimal>("nDebe"));
                this.txtTotDebeDol.Text = nDebeDol.ToString();

                var nHaberDol = dtAsiento.AsEnumerable().Where(r => r.Field<int>("idMoneda") == 2).Sum(x => x.Field<decimal>("nHaber"));
                this.txtTotHabeDol.Text = nHaberDol.ToString();

                var nDebeDolConv = dtAsiento.AsEnumerable().Where(r => r.Field<int>("idMoneda") == 0).Sum(x => x.Field<decimal>("nDebe"));

                this.txtTotDebeDolConvert.Text = nDebeDolConv.ToString();

                var nHabeDolConv = dtAsiento.AsEnumerable().Where(r => r.Field<int>("idMoneda") == 0).Sum(x => x.Field<decimal>("nHaber"));
                this.txtTotHabeDolConvert.Text = nHabeDolConv.ToString();

            }
            else
            {
                this.txtTotDebeSol.Text = "0.00";
                this.txtTotHabeSol.Text = "0.00";
                this.txtTotDebeDol.Text = "0.00";
                this.txtTotHabeDol.Text = "0.00";
                this.txtTotDebeDolConvert.Text = "0.00";
                this.txtTotHabeDolConvert.Text = "0.00";
            }

        }


        private void dtgAsiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgAsiento.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgAsiento.Columns[e.ColumnIndex].DisplayIndex) == 0)
            {
                if (Convert.ToBoolean(dtgAsiento.CurrentRow.Cells["lEditable"].Value) )
                {
                    if (chcAsiReexp.Checked)
                    {
                        frmBuscaCtaCtb frmBscCtaCtb = new frmBuscaCtaCtb();
                        frmBscCtaCtb.ShowDialog();
                        if (!frmBscCtaCtb.lAceptar) return;
                        if (string.IsNullOrEmpty(frmBscCtaCtb.pcCtaCtb)) return;
                        ValidarCtaCtb(frmBscCtaCtb.pcCtaCtb);
                    }
                    if (Convert.ToInt32(dtgAsiento.CurrentRow.Cells["idMoneda"].Value) != 0 )
                    {
                        frmBuscaCtaCtb frmBscCtaCtb = new frmBuscaCtaCtb();
                        frmBscCtaCtb.ShowDialog();
                        if (!frmBscCtaCtb.lAceptar) return;
                        if (string.IsNullOrEmpty(frmBscCtaCtb.pcCtaCtb)) return;
                        ValidarCtaCtb(frmBscCtaCtb.pcCtaCtb);
                    }
                }
            }
        }

        private void dtgAsiento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idMoneda = Convert.ToInt32(dtgAsiento.CurrentRow.Cells["idMoneda"].Value);
            if (idMoneda == 0)
            {
                dtgAsiento.CurrentRow.Cells["idMoneda"].ReadOnly = true;
                if (chcAsiReexp.Checked)
                {
                    dtgAsiento.CurrentRow.Cells[0].ReadOnly = false;
                    dtgAsiento.CurrentRow.Cells["cCuentaContable"].ReadOnly = false;
                    dtgAsiento.CurrentRow.Cells["nDebe"].ReadOnly = false;
                    dtgAsiento.CurrentRow.Cells["nHaber"].ReadOnly = false;

                }
                else {
                    dtgAsiento.CurrentRow.Cells[0].ReadOnly = true;
                    dtgAsiento.CurrentRow.Cells["cCuentaContable"].ReadOnly = true;
                    dtgAsiento.CurrentRow.Cells["nDebe"].ReadOnly = true;
                    dtgAsiento.CurrentRow.Cells["nHaber"].ReadOnly = true;
                }
                
            }

        }

        private void dtgAsiento_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgAsiento.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dtgAsiento.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (dtgAsiento.Columns[dtgAsiento.CurrentCell.ColumnIndex].HeaderText == "Debe" || dtgAsiento.Columns[dtgAsiento.CurrentCell.ColumnIndex].HeaderText == "Haber")
                {
                    txtDiferencia.Clear();
                }
                Sumariza();
            }
        }


        private void dtgAsiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                //Show Error if no cell is selected
                if (dtgAsiento.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Por favor seleccione  la celda", "Pegar cuenta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ValidarCtaCtb(Clipboard.GetText().Trim());
            }


        }

        private void dtgAsiento_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dtgAsiento_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgAsiento.DataSource == null)
            {
                return;
            }
            if (dtgAsiento.RowCount > 0)
            {
                Int32 fila = Convert.ToInt32(this.dtgAsiento.SelectedCells[0].RowIndex);
                if (e.ColumnIndex == 1)
                {
                    dtgAsiento.CurrentCell = dtgAsiento.Rows[fila].Cells["cCuentaContable"];
                    string ccodcta = Convert.ToString(dtgAsiento.Rows[fila].Cells["cCuentaContable"].Value);
                    if (ccodcta.Length > 2)
                    {
                        ccodcta = ccodcta.Substring(0, 2) + "0" + ccodcta.Substring(3, ccodcta.Length - 3);
                    }
                    if (!ccodcta.Equals(""))
                    {
                        ValidarCtaCtb(ccodcta);
                    }


                }
                if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
                {
                    Sumariza();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar?","Registro manual de asientos", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes)
            {
                DataTable DelAsiento;
                string x_cGlosa = txtGlosa.Text;
                DelAsiento = clsAsiento.CNEliminarAsiento(clsVarGlobal.dFecSystem, (int)this.cboAgencias1.SelectedValue, Convert.ToInt32(this.txtNumVoucher.Text), clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia,x_cGlosa);
                if (Convert.ToInt32(DelAsiento.Rows[0]["nNumVoucher"]) > 0)
                {
                    this.txtNumVoucher.Text = DelAsiento.Rows[0]["nNumVoucher"].ToString();
                    MessageBox.Show("Asiento manual eliminado correctamente, nro Voucher: " + this.txtNumVoucher.Text, "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCancelar1_Click(sender, e);

                }
                else
                {
                    if (DelAsiento.Rows.Count == 1)
                    {
                        MessageBox.Show(Convert.ToString(DelAsiento.Rows[0]["cMensaje"]), "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    { 
                        MessageBox.Show("Error al eliminar el asiento Manual", "Graba Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            LiberaProceso();
        }
        private void LiberaProceso()
        {
            objBalance.LiberaProcesoEEFF(this.Name, clsVarGlobal.User.idUsuario);
        }

        private void frmAsientoManual_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberaProceso();
        }
    }
}
