using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
using System.Globalization;

namespace CAJ.Presentacion
{
    public partial class frmValorizacionCheque : frmBase
    {
       
        private int nIdCuentaInst = 0;
        private int nIdChequeBco = 0;
        private string dFechaValorizacion;
        DataTable dtDetCheque = new DataTable("dtDetCheque");

        public frmValorizacionCheque()
        {
            InitializeComponent();
        }

        private void frmValorizarCheque_Load(object sender, EventArgs e)
        {
            this.txtNroCheque.Enabled = false;
            this.dtpFechaEmision.Enabled = false;
            this.txtBeneficiario.Enabled = false;
            this.cboMotOperacionBco.Enabled = false;
            this.txtDescrMot.Enabled = false;
            this.txtMonto.Enabled = false;
            this.dtpFechaValorizar.Value = clsVarGlobal.dFecSystem;
            this.dtpFechaValorizar.MaxDate = clsVarGlobal.dFecSystem;

            Habilitar(3);
            cboMotOperacionBco.cargarMotivoOperacion(7);
        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            txtNroCheque.DataBindings.Clear();
            txtBeneficiario.DataBindings.Clear();
            cboMotOperacionBco.DataBindings.Clear();
            txtDescrMot.DataBindings.Clear();
            txtMonto.DataBindings.Clear();
            dtpFechaEmision.DataBindings.Clear();

            frmBusquedaCuentaInst frmBuscar = new frmBusquedaCuentaInst();
            frmBuscar.ShowDialog();
            if (frmBuscar.pcNumeroCuenta == null) return;
            nIdCuentaInst = frmBuscar.pidCuentaInstitucion;
            this.cboEntidad.CargarEntidades(frmBuscar.pidTipoEntidad);
            this.cboEntidad.SelectedValue = frmBuscar.pidEntidad;
            this.txtNroCuenta.Text = frmBuscar.pcNumeroCuenta;
            this.cboMoneda.SelectedValue = frmBuscar.pidMoneda;
            this.cboTipoCuentaBco.SelectedValue = frmBuscar.pidTipoCuenta;
            this.txtSalCont.Text = frmBuscar.pcSaldoContable;
            this.txtSalDisp.Text = frmBuscar.pcSaldoDisponible;
            clsCNMovimientoBanco objMov = new clsCNMovimientoBanco();

            DataTable dtTalonarios = objMov.VerificarExisteTalonario(nIdCuentaInst);
            DataView dv = dtTalonarios.DefaultView;
            //dv.RowFilter = "lVigente = 'VIGENTE'";
            dtTalonarios = dv.ToTable();

            if (dtTalonarios.Rows.Count > 0)
            {
                nIdChequeBco = Convert.ToInt32(dtTalonarios.Rows[0]["idChequeBco"]);
            }
            else
            {
                nIdChequeBco = 0;
            }

            LlenarGridViewCheques();
            
            txtNroCheque.DataBindings.Add("Text", dtDetCheque, "cNroCheque");
            txtBeneficiario.DataBindings.Add("Text", dtDetCheque, "cApNomCli");
            dtpFechaEmision.DataBindings.Add("Value", dtDetCheque, "dFechaEmision");
            cboMotOperacionBco.DataBindings.Add("SelectedValue", dtDetCheque, "idMotOperBco");
            txtDescrMot.DataBindings.Add("Text", dtDetCheque, "cDescripcion");
            txtMonto.DataBindings.Add("Text", dtDetCheque, "nMonto");

            Habilitar(1);
            if (dtgListaCheques.Rows.Count <= 0)
            {
                btnGrabar.Enabled = false;
            }
            else
            {
                btnGrabar.Enabled = true;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string cMsje = Validar();
            if (cMsje == "")
            {
                clsCNMovimientoBanco objGrabar = new clsCNMovimientoBanco();
                DataSet dsMovCheque = new DataSet("dsmovbco");
                DataTable dtMovimiento = CrearTablaMovimiento(dtDetCheque.Copy());
                dtMovimiento.TableName = "tabla";
                dsMovCheque.Tables.Add(dtMovimiento);
                string xmlMovCheque = clsCNFormatoXML.EncodingXML(dsMovCheque.GetXml());
                dsMovCheque.Tables.Clear();

                DataSet dsDetCheque = new DataSet("dsDetCheque");
                DataView dv = dtDetCheque.DefaultView;
                dv.RowFilter = ("lValorizar = true");
                dtDetCheque = dv.ToTable();
                dtDetCheque.TableName = "dtDetCheque";
                dsDetCheque.Tables.Add(dtDetCheque);
                dv.RowFilter = "";
                string xmlDetCheque = clsCNFormatoXML.EncodingXML(dsDetCheque.GetXml());
                dsMovCheque.Tables.Clear();

                DataTable result = objGrabar.ValorizarCheque(xmlMovCheque, xmlDetCheque, dtpFechaValorizar.Value, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.nIdAgencia, Convert.ToInt32(cboMoneda.SelectedValue));

                if (result.Rows[0]["idMsje"].ToString() == "0")
                {
                    MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Valorizacion Cheques", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Habilitar(1);
                    LlenarGridViewCheques();
                }
                else
                {
                    MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Valorizacion Cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(cMsje, "Valorizacion Cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNroCheque.DataBindings.Clear();
            txtBeneficiario.DataBindings.Clear();
            cboMotOperacionBco.DataBindings.Clear();
            txtDescrMot.DataBindings.Clear();
            txtMonto.DataBindings.Clear();

            this.txtNroCheque.Text = "";
            this.txtBeneficiario.Text = "";
            this.cboMotOperacionBco.SelectedIndex = -1;
            this.txtDescrMot.Text = "";
            this.txtMonto.Text = "";
            this.dtpFechaValorizar.Value = clsVarGlobal.dFecSystem;

            Habilitar(1);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar(2);
            txtNroCheque.DataBindings.Clear();
            txtBeneficiario.DataBindings.Clear();
            cboMotOperacionBco.DataBindings.Clear();
            txtDescrMot.DataBindings.Clear();
            txtMonto.DataBindings.Clear();

            txtNroCheque.DataBindings.Add("Text", dtDetCheque, "cNroCheque");
            txtBeneficiario.DataBindings.Add("Text", dtDetCheque, "cApNomCli");
            cboMotOperacionBco.DataBindings.Add("SelectedValue", dtDetCheque, "idMotOperBco");
            txtDescrMot.DataBindings.Add("Text", dtDetCheque, "cDescripcion");
            txtMonto.DataBindings.Add("Text", dtDetCheque, "nMonto");

        }

        public DataTable CrearTablaMovimiento(DataTable dtCheque)
        {
            dFechaValorizacion = string.Format("#{0:yyyy-MM-dd}#", Convert.ToDateTime(dtpFechaValorizar.Value.ToString()));
            DataView dv = dtCheque.DefaultView;
            dv.RowFilter = ("lValorizar = true");
            dtCheque = dv.ToTable();

            /************************************************************
              Eliminar columnas que no se usan              
            ************************************************************/
            dtCheque.Columns.Remove("idEmiChequeBco");
            dtCheque.Columns.Remove("cApNomCli");
            dtCheque.Columns.Remove("idEstadoCheque");
            dtCheque.Columns.Remove("lValorizar");

            /************************************************************
              Renombrar columnas de acuerdo al formato del XML              
            ************************************************************/
            dtCheque.Columns["idMotOperBco"].ColumnName = "idMotOpeBanco";
            dtCheque.Columns["nMonto"].ColumnName = "nMontoOpera";
            dtCheque.Columns["cNroCheque"].ColumnName = "cNroDocumento";

            /************************************************************
              Agregar Columnas para el XML              
            ************************************************************/
            DataColumn dcIdMovimiento = new DataColumn("idMovimiento", typeof(Int32));
            DataColumn dcidCuenta = new DataColumn("idCuentaInstitucion", typeof(Int32));
            DataColumn dcidTipOpeMovBco = new DataColumn("idTipOpeMovBco", typeof(Int32));
            DataColumn dcTipoMedPago = new DataColumn("idTipMedPago", typeof(Int32));
            DataColumn dcTipoOpera = new DataColumn("idTipoOpera", typeof(Int32));
            DataColumn dcTipoDestino = new DataColumn("idTipoDestino", typeof(Int32));
            DataColumn dcTipoDocumento = new DataColumn("idTipoDocumento", typeof(Int32));
            DataColumn dcFechaOperacion = new DataColumn("dfechaOpe", typeof(DateTime));
            DataColumn dcVigente = new DataColumn("lVigente", typeof(bool));
            DataColumn dcnTipMovCapInt = new DataColumn("nTipMovCapInt", typeof(Int32));
            DataColumn dcidTipoPago = new DataColumn("idTipoPago", typeof(Int32));

            dcidCuenta.Expression = nIdCuentaInst.ToString();
            dtCheque.Columns.Add(dcidCuenta);

            dcnTipMovCapInt.Expression = "1";
            dtCheque.Columns.Add(dcnTipMovCapInt);

            dcidTipoPago.Expression = "6";
            dtCheque.Columns.Add(dcidTipoPago);

            dcIdMovimiento.Expression = "-1";
            dtCheque.Columns.Add(dcIdMovimiento);

            dcidTipOpeMovBco.Expression = "3";
            dtCheque.Columns.Add(dcidTipOpeMovBco);

            dcTipoMedPago.Expression = "7";
            dtCheque.Columns.Add(dcTipoMedPago);

            dcTipoOpera.Expression = "1";
            dtCheque.Columns.Add(dcTipoOpera);

            dcTipoDestino.Expression = "1";
            dtCheque.Columns.Add(dcTipoDestino);

            dcTipoDocumento.Expression = "2";
            dtCheque.Columns.Add(dcTipoDocumento);

            dcFechaOperacion.Expression = dFechaValorizacion;
            dtCheque.Columns.Add(dcFechaOperacion);

            dcVigente.Expression = "true";
            dtCheque.Columns.Add(dcVigente);

            /************************************************************
              Ordenar columnas de DataTable para el XML             
            ************************************************************/

            dtCheque.Columns["idMovimiento"].SetOrdinal(0);
            dtCheque.Columns["idCuentaInstitucion"].SetOrdinal(1);
            dtCheque.Columns["idMotOpeBanco"].SetOrdinal(2);
            dtCheque.Columns["idTipOpeMovBco"].SetOrdinal(3);
            dtCheque.Columns["idTipMedPago"].SetOrdinal(4);
            dtCheque.Columns["nMontoOpera"].SetOrdinal(5);
            dtCheque.Columns["idTipoOpera"].SetOrdinal(6);
            dtCheque.Columns["idTipoDestino"].SetOrdinal(7);
            dtCheque.Columns["idCliente"].SetOrdinal(8);
            dtCheque.Columns["cDescripcion"].SetOrdinal(9);
            dtCheque.Columns["dfechaOpe"].SetOrdinal(10);
            dtCheque.Columns["idTipoDocumento"].SetOrdinal(11);
            dtCheque.Columns["cNroDocumento"].SetOrdinal(12);
            dtCheque.Columns["nTipMovCapInt"].SetOrdinal(13);
            dtCheque.Columns["idTipoPago"].SetOrdinal(14);

            return dtCheque;
        }

        void LlenarGridViewCheques()
        {
            clsCNMovimientoBanco objMov = new clsCNMovimientoBanco();
            dtDetCheque = objMov.ListarCheques(nIdCuentaInst, 0, 1);
            dtgListaCheques.Columns.Clear();
            dtDetCheque.Columns["lValorizar"].ReadOnly = false;
            dtgListaCheques.DataSource = null;
            dtgListaCheques.DataSource = dtDetCheque;

            FormatoGridView();
            //CalcularTotal();
        }

        void FormatoGridView()
        {
            dtgListaCheques.ReadOnly = false;

            dtgListaCheques.Columns["idEmiChequeBco"].Visible = false;
            dtgListaCheques.Columns["cNroCheque"].Visible = true;
            dtgListaCheques.Columns["dFechaEmision"].Visible = false;
            dtgListaCheques.Columns["idCliente"].Visible = false;
            dtgListaCheques.Columns["cNroDocCli"].Visible = false;
            dtgListaCheques.Columns["cApNomCli"].Visible = true;
            dtgListaCheques.Columns["cDireccionCli"].Visible = false;
            dtgListaCheques.Columns["idMotOperBco"].Visible = false;
            dtgListaCheques.Columns["cDescripcion"].Visible = false;
            dtgListaCheques.Columns["nMonto"].Visible = true;
            dtgListaCheques.Columns["idEstadoCheque"].Visible = false;
            dtgListaCheques.Columns["lValorizar"].Visible = true;
            dtgListaCheques.Columns["cEstado"].Visible = false;

            dtgListaCheques.Columns["lValorizar"].DisplayIndex = 0;
            dtgListaCheques.Columns["cNroCheque"].DisplayIndex = 1;
            dtgListaCheques.Columns["cApNomCli"].DisplayIndex = 2;
            dtgListaCheques.Columns["nMonto"].DisplayIndex = 3;

            dtgListaCheques.Columns["lValorizar"].HeaderText = "";
            dtgListaCheques.Columns["cNroCheque"].HeaderText = "N° Cheque";
            dtgListaCheques.Columns["cApNomCli"].HeaderText = "Cliente";
            dtgListaCheques.Columns["nMonto"].HeaderText = "Monto";
            dtgListaCheques.Columns["idComprobantePago"].HeaderText = "N° Comprobante";


            dtgListaCheques.Columns["lValorizar"].Width = 30;
            dtgListaCheques.Columns["cNroCheque"].Width = 80;
            dtgListaCheques.Columns["cApNomCli"].Width = 250;
            dtgListaCheques.Columns["nMonto"].Width = 60;
            dtgListaCheques.Columns["idComprobantePago"].Width = 100;

            dtgListaCheques.Columns["lValorizar"].ReadOnly = false;
            dtgListaCheques.Columns["cNroCheque"].ReadOnly = true;
            dtgListaCheques.Columns["cApNomCli"].ReadOnly = true;
            dtgListaCheques.Columns["nMonto"].ReadOnly = true;
        }

        void Habilitar(int nOpcion)
        {
            if (nOpcion == 1) //nuevo o editar
            {
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnBuscarCuenta.Enabled = true;
                this.grbDatosEmision.Enabled = false;
                this.grbDatosCuenta.Enabled = true;
                this.grbValorizar.Enabled = false;
            }
            else if (nOpcion == 2)//cancelar o Grabar
            {
                this.btnGrabar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnNuevo.Enabled = false;
                this.btnBuscarCuenta.Enabled = false;
                this.grbDatosEmision.Enabled = true;
                this.grbDatosCuenta.Enabled = false;
                this.grbValorizar.Enabled = true;
            }
            else if (nOpcion == 3)// inicio
            {
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.grbDatosEmision.Enabled = false;
                this.grbValorizar.Enabled = false;
            }

        }

        private void CalcularTotal()
        {
            decimal nTot = 0.00M;
            if (dtgListaCheques.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgListaCheques.Rows)
                {
                    if (Convert.ToInt32(row.Cells["idEstadoCheque"].Value) != 3 && Convert.ToBoolean(row.Cells["lValorizar"].Value) == true)
                    {
                        nTot += Convert.ToDecimal(row.Cells["nMonto"].Value);
                    }
                }
                txtTotMonto.Text = nTot.ToString();
            }
            else
            {
                txtMonto.Text = "0.00";
            }
        }

        string Validar()
        {
            string cMsje = "";

            // SE  COMENTADO SOLO PARA COOP SANTA ROSA

            //if (Convert.ToDecimal(txtTotMonto.Text) >= Convert.ToDecimal(txtSalDisp.Text))
            //{
            //    cMsje += "El Monto de los cheques seleccionados excede el saldo disponible.";
            //}

            return cMsje;
        }

        private void dtgListaCheques_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            // Detecta si se ha seleccionado el header de la grilla
            //
            if (e.RowIndex == -1)
                return;

            if (dtgListaCheques.Columns[e.ColumnIndex].Name == "lValorizar")
            {                
                dtgListaCheques.EndEdit();
                CalcularTotal();
            }
        }

    }
}
