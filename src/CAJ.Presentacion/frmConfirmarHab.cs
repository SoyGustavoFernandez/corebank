using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using GEN.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmConfirmarHab : frmBase
    {
        DataTable tbHabilitaciones;
        int pnCantidad = 0;
        List<clsLimCobertura> lstMontoCoberturHab = new List<clsLimCobertura>();

        public frmConfirmarHab()
        {
            InitializeComponent();

        }

        private void frmConfirmarHab_Load(object sender, EventArgs e)
        {
            DatosUsuario();
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            //if (this.ValidarInicioOpe() != "A")
            //{
            //    this.Dispose();
            //    return;
            //}

            if (ValidaRespCaja() == 0)
            {
                MessageBox.Show("Ud. no es responsable de ventanilla, caja pulmón o bóveda.", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }


            ListaHabPed(1);
            FormatoGridCli();
            this.rbtHabPend.Checked = true;
        }
        //public string ValidarInicioOpeCaj(int idTipResCaj)
        //{
        //    clsCNControlOpe ValidaOpe = new clsCNControlOpe();
        //    string cEstCie = ValidaOpe.ValidaIniOpeCaja(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, idTipResCaj);
        //    // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
        //    //string cRpta = this.ValidarInicioOpe();

        //    switch (cEstCie) // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada  
        //    {
        //        case "F":
        //            switch (idTipResCaj)
        //            {
        //                case 3: MessageBox.Show("Falta realizar el inicio de Operaciones del Responsable de Bóveda \n dirigirse al modulo de caja", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    break;
        //                case 2: MessageBox.Show("Falta realizar el inicio de Operaciones del Responsable de Caja pulmón \n dirigirse al modulo de caja", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    break;
        //                default: MessageBox.Show("Falta realizar el inicio de Operaciones del Responsable de Ventanilla \n dirigirse al modulo de caja", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    break;
        //            }
        //            //this.Dispose();
        //            break;
        //        case "A":
        //            break;
        //        case "C":
        //            MessageBox.Show("El usuario ya cerró sus operaciones", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            //this.Dispose();
        //            break;
        //        default:
        //            MessageBox.Show(cEstCie, "Error al Validar Estado de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            //this.Dispose();
        //            break;
        //    }
        //    return cEstCie;
        //}
        private int ValidaRespCaja()
        {
            clsCNControlOpe ValidaResBov = new clsCNControlOpe();
            int idTipoResCaja = 0;
            //// Si nValUsu es: 0--> usuario no Es Responsable de ventanilla, caja pulmón o Bóveda
            ////                1-->resonsable de ventanilla
            ////                2-->resonsable de caja pulmón
            ////                3-->resonsable de Bóveda
            DataTable dtResBov = ValidaResBov.RetRespBoveda(Convert.ToInt32(this.txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia, idTipoResCaja, clsVarGlobal.dFecSystem);

            pnCantidad = dtResBov.Rows.Count;

            if (pnCantidad == 0)
            {
                return 0;
            }

            return Convert.ToInt32(dtResBov.Rows[0]["idTipResCaj"].ToString());

        }

        private void DatosUsuario()
        {
            dtpFechaSis.Value = clsVarGlobal.dFecSystem;
            txtCodUsu.Text = clsVarGlobal.User.idUsuario.ToString();
            txtUsuario.Text = clsVarGlobal.User.cWinUser;
            int nidCli = Convert.ToInt32(clsVarGlobal.User.idCli);
            clsCNRetDatosCliente RetDatCli = new clsCNRetDatosCliente();
            DataTable DatosCli = RetDatCli.ListarDatosCli(nidCli, "D");
            if (DatosCli.Rows.Count > 0)
            {
                txtNomUsu.Text = DatosCli.Rows[0]["cNombre"].ToString();
            }
            else
            {
                txtNomUsu.Text = "";
            }
        }

        private void ListaHabPed(int nOpc)
        {
            string msge = "";
            int nidUsu = Convert.ToInt32(this.txtCodUsu.Text);
            clsCNControlOpe LisHabPen = new clsCNControlOpe();
            tbHabilitaciones = LisHabPen.ListarHabPen(dtpFechaSis.Value, clsVarGlobal.nIdAgencia, nidUsu, nOpc, ref msge);
            if (msge == "OK")
            {
                this.dtgHabPen.DataSource = tbHabilitaciones;
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de Habilitaciones Pendientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatoGridCli()
        {
            this.dtgHabPen.Columns["idHabilita"].Visible = false;
            this.dtgHabPen.Columns["cSustento"].Visible = false;
            this.dtgHabPen.Columns["idUsuOri"].Visible = false;
            this.dtgHabPen.Columns["idMoneda"].Visible = false;
            this.dtgHabPen.Columns["idTipIngEgr"].Visible = false;
            this.dtgHabPen.Columns["idHabCierre"].Visible = false;
            this.dtgHabPen.Columns["idTipHab"].Visible = false;
            this.dtgHabPen.Columns["idTipResCajOri"].Visible = false;
            this.dtgHabPen.Columns["lReqBilletaje"].Visible = false;
            this.dtgHabPen.Columns["cDescripcion"].Width = 120;
            this.dtgHabPen.Columns["cDescripcion"].HeaderText = "Habilitación Origen";
            this.dtgHabPen.Columns["cMoneda"].Width = 120;
            this.dtgHabPen.Columns["cMoneda"].HeaderText = "Moneda";
            this.dtgHabPen.Columns["nMontoHab"].Width = 80;
            this.dtgHabPen.Columns["nMontoHab"].HeaderText = "Monto";
            this.dtgHabPen.Columns["nMontoHab"].DefaultCellStyle.Format = "N2";
            this.dtgHabPen.Columns["cNombre"].Width = 220;
            this.dtgHabPen.Columns["cNombre"].HeaderText = "Usuario que Realiza Habilitación";
            this.dtgHabPen.Columns["cDescpDestino"].HeaderText = "Habilitación Destino";

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dtgHabPen.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Habilitaciones por Confirmar...", "Confirmar Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Msg = MessageBox.Show("Esta seguro de Confirmar la habilitación?...", "Confirmar Habilitaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            btnAceptar.Enabled = false;

            if (dtgHabPen.Rows.Count > 0)
            {
                clsCNControlOpe ConfirHabPen = new clsCNControlOpe();
                int idHabi = Convert.ToInt32(this.dtgHabPen.Rows[dtgHabPen.SelectedCells[2].RowIndex].Cells["idHabilita"].Value.ToString());
                int idUsuOri = Convert.ToInt32(dtgHabPen.CurrentRow.Cells["idUsuOri"].Value.ToString());
                int idUsuDes = Convert.ToInt32(txtCodUsu.Text);
                int idAgeOri = clsVarGlobal.nIdAgencia;
                int TipMon = Convert.ToInt32(dtgHabPen.CurrentRow.Cells["idMoneda"].Value.ToString());
                Decimal nMonTot = Convert.ToDecimal (dtgHabPen.CurrentRow.Cells["nMontoHab"].Value.ToString());
                bool lReqBilletaje = Convert.ToBoolean(dtgHabPen.CurrentRow.Cells["lReqBilletaje"].Value.ToString());
                int idTipResCajOri = Convert.ToInt32(dtgHabPen.CurrentRow.Cells["idTipResCajOri"].Value.ToString());
                int idTipResCajDes = Convert.ToInt32(dtgHabPen.CurrentRow.Cells["idTipHab"].Value.ToString());

                //if (mostarLimiteCobertura(idTipResCajOri))
                //{
                //    return;
                //}
                if (mostarLimiteCobertura(idTipResCajDes))
                {
                    return;
                }
                //Valida si esta Permitido la ejeccion de la operacion
                if (PermiteOperacion(idTipResCajDes) == false)
                {
                    MessageBox.Show("NO PUEDE REALIZAR OPERACIÓN..." + "\r\n" + "SU SALDO ESTÁ EN LIMITES DE ALTO RIESGO", "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtResul = ConfirHabPen.ConfirmarHab(idHabi, dtpFechaSis.Value, idUsuOri, idUsuDes, clsVarGlobal.nIdAgencia, TipMon, nMonTot, idTipResCajOri, idTipResCajDes);

                if (dtResul.Rows.Count > 0)
                {
                    if((int)dtResul.Rows[0]["cRpta"] == 0)
                    {
                        if (idTipResCajDes == 1)
                            this.objFrmSemaforo.ValidarSaldoSemaforo();

                        if (idTipResCajOri == 1 && idUsuOri == idUsuDes)
                            this.objFrmSemaforo.ValidarSaldoSemaforo();

                        this.objFrmSemaforo.oControlBoveda.comprobarLimiteBoveda();
                    }
                    MessageBox.Show((string)dtResul.Rows[0]["msg"], "Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error desconocido", "Error al Confirmar la Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.rbtHabPend.Checked = true;
            ListaHabPed(1);
            FormatoGridCli();
            this.dtgHabPen.Focus();
            this.dtgHabPen.Select();
        }
        /// <summary>
        /// Carga los montos del limite de cobertura
        /// </summary>
        ///

        private bool mostarLimiteCobertura(int idTipResCaj)
        {
            clsCNPerfilUsu PerfilesHab = new clsCNPerfilUsu();

            lstMontoCoberturHab = PerfilesHab.limiteCobertura(idTipResCaj, clsVarGlobal.nIdAgencia);
            if (lstMontoCoberturHab.Count <= 0)
            {
                MessageBox.Show("Debe asignar el monto del límite de cobertura para " + cTipoRespobsaleCaja(idTipResCaj), "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }
        public string cTipoRespobsaleCaja(int idTipResCaj)
        {
            string cTipResCaj = "";
            switch (idTipResCaj)
            {
                case 1:
                    cTipResCaj = "Ventanilla";
                    break;
                case 2:
                    cTipResCaj = "Caja pulmón";
                    break;
                case 3:
                    cTipResCaj = "Bóveda";
                    break;
            }
            return cTipResCaj;
        }
        public Boolean PermiteOperacion(int idTipResCaj)
        {
            clsCNControlOpe cnSaldo = new clsCNControlOpe();
            DataTable tbSaldo = cnSaldo.RetornaSaldoOperadorAge(clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, idTipResCaj);
            Boolean lPermiteOpe = true;
            decimal nSaldoTotal = (decimal)0.00;
            decimal nSaldoTotalDol = (decimal)0.00;
            if (tbSaldo.Rows.Count > 0)
            {
                if ( lstMontoCoberturHab[0].idControlTipMon  == 1)//se controlo en soles(soles + dolar*tipocambio)
                {
                    nSaldoTotal = Convert.ToDecimal(tbSaldo.Rows[0]["nSaldoOpe"].ToString());
                }
                else if (lstMontoCoberturHab[0].idControlTipMon == 2)//se controlo en dólares(soles/tipocambio +dolar)
                {
                    nSaldoTotal = Convert.ToDecimal(tbSaldo.Rows[0]["nSaldoOpeDol"].ToString());

                }
                else if (lstMontoCoberturHab[0].idControlTipMon == 3)//se controla en las dos monedas
                {
                    nSaldoTotal = Convert.ToDecimal(tbSaldo.Rows[0]["nSalSoles"].ToString());
                    nSaldoTotalDol = Convert.ToDecimal(tbSaldo.Rows[0]["nSalDolar"].ToString());
                }

                if (lstMontoCoberturHab[0].idControlTipMon != 3)
                {
                    if (nSaldoTotal <= lstMontoCoberturHab[0].nMonMaxCobertura)
                    {
                        lPermiteOpe = true;
                    }
                    else
                    {
                        int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lPermiteOpeFueraLimite"]);
                        lPermiteOpe = Convert.ToBoolean(idRes);
                        if (lPermiteOpe == true)
                        {
                            MessageBox.Show("Está fuera de límite de cobertura como " + cTipoRespobsaleCaja(idTipResCaj), "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    if (nSaldoTotal <= lstMontoCoberturHab[0].nMonMaxCobertura && nSaldoTotalDol <= lstMontoCoberturHab[0].nMonMaxCoberturaDol)
                    {
                        lPermiteOpe = true;
                    }
                    else if (nSaldoTotal > lstMontoCoberturHab[0].nMonMaxCobertura)
                    {
                        int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lPermiteOpeFueraLimite"]);
                        lPermiteOpe = Convert.ToBoolean(idRes);
                        if (lPermiteOpe == true)
                        {
                            MessageBox.Show("Está fuera de límite de cobertura en soles como " + cTipoRespobsaleCaja(idTipResCaj), "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else if (nSaldoTotalDol > lstMontoCoberturHab[0].nMonMaxCoberturaDol)
                    {
                        int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lPermiteOpeFueraLimite"]);
                        lPermiteOpe = Convert.ToBoolean(idRes);
                        if (lPermiteOpe == true)
                        {
                            MessageBox.Show("Está fuera de límite de cobertura en dólares como " + cTipoRespobsaleCaja(idTipResCaj), "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lPermiteOpeFueraLimite"]);
                        lPermiteOpe = Convert.ToBoolean(idRes);
                        if (lPermiteOpe == true)
                        {
                            MessageBox.Show("Está fuera de límite de cobertura como " + cTipoRespobsaleCaja(idTipResCaj), "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }

            }



            return lPermiteOpe;
        }

        public bool ActualizarSaldoHab(int idUsuario, int idAgencia, int idTipoMoneda, int IdTipoTransac_I_E, Decimal nMontoOperacion, int idTipResCaj)
        {

            decimal nSaldoAnterio = decimal.Zero;
            decimal nNuevoSaldo = decimal.Zero;

            //Obtener Saldo Anterior
            clsCNControlOpe objSaldos = new clsCNControlOpe();
            DataTable tbSaldo = objSaldos.RetornaSaldoOperadorAge(clsVarGlobal.dFecSystem, idUsuario, clsVarGlobal.nIdAgencia, idTipResCaj);

            if (tbSaldo.Rows.Count <= 0)
                return false;

            nSaldoAnterio = idTipoMoneda == 1 ? tbSaldo.Rows[0].Field<decimal>("nSalSoles") : tbSaldo.Rows[0].Field<decimal>("nSalDolar");
            nNuevoSaldo = (IdTipoTransac_I_E == 1) ? (Convert.ToDecimal(nMontoOperacion) + nSaldoAnterio) : (nSaldoAnterio - Convert.ToDecimal(nMontoOperacion));

            if (nNuevoSaldo < 0 && IdTipoTransac_I_E == 2)
            {
                MessageBox.Show("Efectivo insuficiente de " + idUsuario + " para la Operación...", "Valida Saldo de Operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                DateTime fecha = clsVarGlobal.dFecSystem;
                objSaldos.ActualizarSaldo(idAgencia, idUsuario, fecha, idTipoMoneda, IdTipoTransac_I_E, Convert.ToDecimal(nMontoOperacion), idTipResCaj);
            }
            return true;
        }


        public void EmitirVoucher(DataTable dtDatosIngreso, DataTable dtDatosEgreso, int idKardex)
        {
            string cAgencia = clsVarGlobal.cNomAge;
            string cNombreEmpresa = clsVarApl.dicVarGen["cRUC"];
            string cRucEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cAgencia", cAgencia, false));
            paramlist.Add(new ReportParameter("cNombreEmpresa", cNombreEmpresa, false));
            paramlist.Add(new ReportParameter("cRucEmpresa", cRucEmpresa, false));

            paramlist.Add(new ReportParameter("idKardex", idKardex.ToString(), false));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();


            dtslist.Add(new ReportDataSource("dtsDatIngreso", dtDatosIngreso));
            dtslist.Add(new ReportDataSource("dtsDatEgreso", dtDatosEgreso));
            string reportpath = "rptVoucherHabil.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }
        public void EmitirVoucherBalancin(DataTable dtDatosBalancin, int idHabilitacion)
        {
            string cAgencia = clsVarGlobal.cNomAge;
            //evaluar por esta opcion
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombreAge", cAgencia, false));
            paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("idHabilitacion", idHabilitacion.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsBalancin", dtDatosBalancin));

            string reportpath = "rptBillHab.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }
        private void btnRechazar_Click(object sender, EventArgs e)
        {

            if (this.dtgHabPen.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Habilitaciones por Rechazar...", "Rechazar Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if ((bool)dtgHabPen.CurrentRow.Cells["idHabCierre"].Value)
                {
                    MessageBox.Show("No se puede extornar, La Habilitacion pertenece a un Cierre", "Rechazar Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var Msg = MessageBox.Show("Estas Seguro de Rechazar la habilitación?...", "Rechazar Habilitaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            string cMotRechazo = "";
            ShowInputDialog("Motivo de rechazo", "Motivo de rechazo:", ref cMotRechazo);

            if (cMotRechazo.Trim().Equals(""))
            {
                MessageBox.Show("Debe ingresar el motivo de rechazo...", "Rechazar Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtgHabPen.Rows.Count > 0)
            {

                clsCNControlOpe RechazHabPen = new clsCNControlOpe();
                int idHabi = Convert.ToInt32(this.dtgHabPen.Rows[dtgHabPen.SelectedCells[2].RowIndex].Cells["idHabilita"].Value.ToString());
                int idUsuOri = Convert.ToInt32(dtgHabPen.CurrentRow.Cells["idUsuOri"].Value.ToString());
                int idUsuDes = Convert.ToInt32(txtCodUsu.Text);
                int idAgeOri = clsVarGlobal.nIdAgencia;
                int TipMon = Convert.ToInt32(dtgHabPen.CurrentRow.Cells["idMoneda"].Value.ToString());
                Decimal nMonTot = Convert.ToDecimal (dtgHabPen.CurrentRow.Cells["nMontoHab"].Value.ToString());

                string cRpta = RechazHabPen.RechazarHab(idHabi, cMotRechazo);
                if (cRpta == "OK")
                {

                    MessageBox.Show("El Rechazo de la Habilitación se Realizó Correctamente", "Rechazar Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(cRpta, "Error al Rechazar la Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (this.rbtHabPend.Checked)
                {
                    this.rbtHabPend.Checked = true;
                    ListaHabPed(1);
                }
                else
                {
                    this.rbtHabGeneradas.Checked = true;
                    ListaHabPed(2);
                }
                FormatoGridCli();

                this.dtgHabPen.Focus();
                this.dtgHabPen.Select();
            }
        }

        private void rbtHabPend_CheckedChanged(object sender, EventArgs e)
        {
            ListaHabPed(1);
            //this.btnAceptar.Enabled = true;
            this.btnRechazar.Enabled = true;


        }

        private void rbtHabGeneradas_CheckedChanged(object sender, EventArgs e)
        {
            ListaHabPed(2);
            //this.btnAceptar.Enabled = false;
            this.btnRechazar.Enabled = true;

        }

        public static DialogResult ShowInputDialog(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            //Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            textBox.Multiline = true;
            buttonOk.Text = "Yes";
            //buttonCancel.Text = "No";
            buttonOk.DialogResult = DialogResult.Yes;
            //buttonCancel.DialogResult = DialogResult.No;

            label.SetBounds(9, 5, 372, 13);
            textBox.SetBounds(12, 21, 372, 45);
            buttonOk.SetBounds(220, 72, 75, 23);
            //buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            //form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void dtgHabPen_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgHabPen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgHabPen.RowCount > 0)
            {
                int iFilaOpe = e.RowIndex;
                if (iFilaOpe == -1)
                {
                    return;
                }
                bool lReqBil = Convert.ToBoolean(tbHabilitaciones.Rows[iFilaOpe]["lReqBilletaje"]);
                int idHab = Convert.ToInt32(tbHabilitaciones.Rows[iFilaOpe]["idHabilita"]);
                int idMoneda = Convert.ToInt32(tbHabilitaciones.Rows[iFilaOpe]["idMoneda"]);

                if (lReqBil)
                {
                    frmConsultaBilHab frmConBilHab = new frmConsultaBilHab(dtpFechaSis.Value, idMoneda, idHab);
                    frmConBilHab.ShowDialog();
                }
            }
        }
    }
}
