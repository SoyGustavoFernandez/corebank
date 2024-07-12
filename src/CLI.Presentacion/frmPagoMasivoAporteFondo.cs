using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using CLI.CapaNegocio;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CLI.Presentacion
{
    public partial class frmPagoMasivoAporteFondo : frmBase
    {
        clsCNSocio cnsocio = new clsCNSocio();
        clsCNComprobantes objCpg = new clsCNComprobantes();
//        private DataTable dtDsctoPlanilla = new DataTable();
        clsCNDeposito clsDeposito = new clsCNDeposito();
        private DataTable dtLisCrexAna = new DataTable();

        public frmPagoMasivoAporteFondo()
        {
            InitializeComponent();
            GEN.CapaNegocio.clsCNTipoPago TipoPago = new GEN.CapaNegocio.clsCNTipoPago();
            DataTable dtTipoPago = TipoPago.CNListarTipPagCredito();
            cboConvenio1.SelectedValue = 0;
        }

        private string ValidarCorteFracc()
        {
            string cRpta = "OK";
            string msge = "";
            clsCNControlOpe ValCorFra = new clsCNControlOpe();
            string cCorFra = ValCorFra.ValidaCorteFracc(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, ref msge);
            if (msge == "OK")
            {
                if (cCorFra == "0")
                {
                    MessageBox.Show("Primero debe Realizar su Corte Fraccionario... por Favor..", "Validar Corte Fraccionario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cRpta = "ERROR";
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Validar Corte Fraccionario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cRpta = "ERROR";
            }
            return cRpta;
        }

        public void FormatoGrid()
        {
            dtgPagoCrditosConvenio.Columns["idSocio"].Visible = false;
            dtgPagoCrditosConvenio.Columns["idcli"].Visible = false;
            dtgPagoCrditosConvenio.Columns["idAporte"].Visible = false;
            dtgPagoCrditosConvenio.Columns["idFondo"].Visible = false;

            dtgPagoCrditosConvenio.Columns["cDocumentoID"].Visible = false;
            dtgPagoCrditosConvenio.Columns["cDireccion"].Visible = false;
            dtgPagoCrditosConvenio.Columns["IdTipoPersona"].Visible = false;
            dtgPagoCrditosConvenio.Columns["cCodCliente"].Visible = false;
            dtgPagoCrditosConvenio.Columns["idTipoDocumento"].Visible = false;
            dtgPagoCrditosConvenio.Columns["lIndDatosBasic"].Visible = false;            

            dtgPagoCrditosConvenio.Columns["lPagoSocio"].Width = 40;

            dtgPagoCrditosConvenio.Columns["dFechaAporte"].HeaderText = "Fecha Aporte";
            dtgPagoCrditosConvenio.Columns["dFechaFondo"].HeaderText = "Fecha Fondo";
            dtgPagoCrditosConvenio.Columns["lPagoSocio"].HeaderText = "Sel.";            
            dtgPagoCrditosConvenio.Columns["nDeudaAporte"].HeaderText = "Deuda Aporte";
            dtgPagoCrditosConvenio.Columns["nDeudaFondo"].HeaderText = "Deuda Fondo";
            dtgPagoCrditosConvenio.Columns["cNombre"].HeaderText = "Cliente";
            dtgPagoCrditosConvenio.Columns["nMonPagFondo"].HeaderText = "Pago de Fondo";
            dtgPagoCrditosConvenio.Columns["nMonPagAporte"].HeaderText = "Pago de Aporte";

            dtgPagoCrditosConvenio.Columns["nMonPagAporte"].DefaultCellStyle.BackColor = Color.DarkBlue;
            dtgPagoCrditosConvenio.Columns["nMonPagAporte"].DefaultCellStyle.ForeColor = Color.White;
            dtgPagoCrditosConvenio.Columns["nMonPagFondo"].DefaultCellStyle.BackColor = Color.DarkBlue;
            dtgPagoCrditosConvenio.Columns["nMonPagFondo"].DefaultCellStyle.ForeColor = Color.White;
     
            DataGridViewCellStyle boldStyle = new DataGridViewCellStyle();
            boldStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            boldStyle.BackColor = Color.DarkBlue;
            boldStyle.ForeColor = Color.White;

            dtgPagoCrditosConvenio.Columns["nMonPagAporte"].DefaultCellStyle.Format = "N2";
            dtgPagoCrditosConvenio.Columns["nMonPagAporte"].DefaultCellStyle = boldStyle;
            dtgPagoCrditosConvenio.Columns["nMonPagAporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPagoCrditosConvenio.Columns["nMonPagFondo"].DefaultCellStyle.Format = "N2";
            dtgPagoCrditosConvenio.Columns["nMonPagFondo"].DefaultCellStyle = boldStyle;
            dtgPagoCrditosConvenio.Columns["nMonPagFondo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //Restringir la cantidad de dígitos a 10
            ((DataGridViewTextBoxColumn)dtgPagoCrditosConvenio.Columns["nMonPagAporte"]).MaxInputLength = 9;
            ((DataGridViewTextBoxColumn)dtgPagoCrditosConvenio.Columns["nMonPagFondo"]).MaxInputLength = 9;
        }

        public void HabilitarGrid(Boolean bVal)
        {
            this.dtgPagoCrditosConvenio.ReadOnly = !bVal;
            this.dtgPagoCrditosConvenio.Columns["idSocio"].ReadOnly = bVal;
            this.dtgPagoCrditosConvenio.Columns["idcli"].ReadOnly = bVal;
            this.dtgPagoCrditosConvenio.Columns["cNombre"].ReadOnly = bVal;
            this.dtgPagoCrditosConvenio.Columns["dFechaAporte"].ReadOnly = bVal;
            this.dtgPagoCrditosConvenio.Columns["nDeudaAporte"].ReadOnly = bVal;
            this.dtgPagoCrditosConvenio.Columns["idAporte"].ReadOnly = bVal;
            this.dtgPagoCrditosConvenio.Columns["dFechaFondo"].ReadOnly = bVal;
            this.dtgPagoCrditosConvenio.Columns["nDeudaFondo"].ReadOnly = bVal;
            this.dtgPagoCrditosConvenio.Columns["idFondo"].ReadOnly = bVal;
            this.dtgPagoCrditosConvenio.Columns["lPagoSocio"].ReadOnly = !bVal;
            this.dtgPagoCrditosConvenio.Columns["nMonPagFondo"].ReadOnly = !bVal;
            this.dtgPagoCrditosConvenio.Columns["nMonPagAporte"].ReadOnly = !bVal;
        }

        private void SumaPagos()
        {
            Decimal nTotPagadoAport = 0;
            Decimal nTotPagadoFondo = 0;
            int nNumAprPagados = 0;
            int nNumFonPagados = 0;
            for (int i = 0; i < dtLisCrexAna.Rows.Count; i++)
            {
                bool lSelePagoAport = Convert.ToBoolean(dtLisCrexAna.Rows[i]["lPagoSocio"]);
                if (lSelePagoAport)
                {
                    nTotPagadoAport += Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagAporte"]);
                    if (Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagAporte"]) > 0.00m)
                    {
                        nNumAprPagados++;
                    }
                    nTotPagadoFondo += Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagFondo"]);
                    if (Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagFondo"]) > 0.00m)
                    {
                        nNumFonPagados++;
                    }
                }
            }
            this.txtTotalPagoAporte.Text = nTotPagadoAport.ToString();
            this.txtTotalPagoFondo.Text = nTotPagadoFondo.ToString();
            this.txtTotal.Text = (nTotPagadoAport + nTotPagadoFondo).ToString();
            this.txtNroAportes.Text = nNumAprPagados.ToString();
            this.txtNroFondo.Text = nNumFonPagados.ToString();
        }

        private bool validapago()
        {
            bool lvalida = true;
            Decimal nTotDeudaAportes = 0.00m;
            Decimal nTotDeudaFondos = 0.00m;
            Decimal nPagaDeudaAporte = 0.00m;
            Decimal nPagaDeudaFondo = 0.00m;
           

            if ((this.txtTotalPagoAporte.Text.Trim() == "" || Convert.ToDecimal (this.txtTotalPagoAporte.Text) <= 0)
                && (this.txtTotalPagoFondo.Text.Trim() == "" || Convert.ToDecimal (this.txtTotalPagoFondo.Text) <= 0)
                ) 
            {
                MessageBox.Show("No hay montos a ser pagados", "Pagos Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalida = false;
                return lvalida;
            }
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar la modalidad de Pago", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToInt32(cboModalidad.SelectedValue) == 2)//TRANSFERENCIA A CUENTA
            {
                if (string.IsNullOrEmpty(txtIdCtaAho.Text))
                {
                    MessageBox.Show("Debe seleccionar una cuenta de Ahorro para la transferencia.", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (Convert.ToInt32(cboModalidad.SelectedValue) == 3)//CHEQUE
            {
                if (cboTipoEntidad.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar el Tipo de Entidad Financiera", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (cboEntidad1.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar la Entidad Financiera", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboEntidad1.Focus();
                    return false;
                }
                if (txtNroCuenta.Text.Trim().Length<= 0)
                {
                    MessageBox.Show("Debe INGRESAR Nro de Cuenta.", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCuenta.Focus();
                    return false;
                }
                if (txtNroSerie.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe INGRESAR Nro de Serie Cheque", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCuenta.Focus();
                    return false;
                }
                if (txtNroDocumento.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe INGRESAR Nro de Cheque", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCuenta.Focus();
                    return false;
                }
            }
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 4)//INTERBANCARIO
            {
                if (cboTipoEntidad.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar el Tipo de Entidad Financiera", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (cboEntidad1.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar la Entidad Financiera", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboEntidad1.Focus();
                    return false;
                }
                if (cboCuenta.SelectedIndex<0)
                {
                    MessageBox.Show("Debe seleccionar Nro de Cuenta.", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCuenta.Focus();
                    return false;
                }
                if (txtNroSerie.Text.Trim().Length<=0)
                {
                    MessageBox.Show("Debe INGRESAR Nro de Serie.", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCuenta.Focus();
                    return false;
                }
                if (txtNroDocumento.Text.Trim().Length<=0)
                {
                    MessageBox.Show("Debe INGRESAR Nro de Documento", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCuenta.Focus();
                    return false;
                }
            }


            for (int i = 0; i < dtLisCrexAna.Rows.Count; i++)
            {
                bool lSeleCta = Convert.ToBoolean(dtLisCrexAna.Rows[i]["lPagoSocio"]);
                if (!lSeleCta)
                {
                    continue;
                }
                nTotDeudaAportes = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nDeudaAporte"]);
                nPagaDeudaAporte = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagAporte"]);
                
                if (nPagaDeudaAporte > nTotDeudaAportes)
                {
                    MessageBox.Show("Monto a pagar no puede superar a la deuda de la cuota", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgPagoCrditosConvenio.CurrentCell = dtgPagoCrditosConvenio.Rows[i].Cells["nMonPagAporte"];
                    lvalida = false;
                    break;
                }
                nTotDeudaFondos = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nDeudaFondo"]);
                nPagaDeudaFondo = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagFondo"]);
                if (nPagaDeudaFondo > nTotDeudaFondos)
                {
                    MessageBox.Show("Monto a pagar no puede superar a la deuda de la cuota", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgPagoCrditosConvenio.CurrentCell = dtgPagoCrditosConvenio.Rows[i].Cells["nMonPagFondo"];
                    lvalida = false;
                    break;
                }
            }
            return lvalida;
        }

        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int fila = dtgPagoCrditosConvenio.CurrentRow.Index;
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                
                dtgPagoCrditosConvenio.Rows[fila].Selected = true;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
                
                dtgPagoCrditosConvenio.Rows[fila].Selected = true;
            }
            else
            {
                var fff = (from L in this.Text.ToString()
                           where L.ToString() == "."
                           select L).Count();

                if (fff <= 0 && e.KeyChar.ToString() == ".")
                {
                    
                    e.Handled = false;
                    dtgPagoCrditosConvenio.Rows[fila].Selected = true;
                }
                else
                {
                    e.Handled = true;
                    dtgPagoCrditosConvenio.Rows[fila].Selected = true;
                }
            }
        }

        private void frmCobroCreditosDctoPlanilla_Load(object sender, EventArgs e)
        {
            // Validar Inicio de Operaciones
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            //====================== Cargar Modalidad =================================>
            cboModalidad.SelectedIndexChanged -= new
            EventHandler(cboModalidad_SelectedIndexChanged);

            cboModalidad.DataSource = cnsocio.ListarModalidadPagoAportesFondo(true);
            cboModalidad.ValueMember = "idModPagoAporteFondoSeg";
            cboModalidad.DisplayMember = "cModPagoAporteFondoSeg";

            cboModalidad.SelectedIndexChanged += new
            EventHandler(cboModalidad_SelectedIndexChanged);
            //========================================================================>
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.dtgPagoCrditosConvenio.Enabled = false;
            this.dtgPagoCrditosConvenio.ReadOnly = true;
            this.btnGrabar1.Enabled = false;
            this.btnCancelar1.Enabled = false;
          
            cboConvenio1.Enabled = true;
            cboConvenio1.Enabled = true;
            this.dtgPagoCrditosConvenio.DataSource = "";
            this.txtTotalPagoAporte.Text = "";
            this.txtNroAportes.Text = "";

            this.txtTotalPagoAporte.Visible = true;
            this.txtNroAportes.Visible = true;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataTable dtAporteXPagar = new DataTable("dtAportexPagar");
            DataTable dtFondoXPagar = new DataTable("dtFondoxPagar");
            Decimal nPagaDeudaAporte = 0.00m;
            Decimal nPagaDeudaFondo = 0.00m;
            int nIdAporte = 0;
            int nIdFondo = 0;
            if (!validapago())
            {
                return;
            }
            btnGrabar1.Enabled = false;
            cboConvenio1.Enabled = false;
            /*========================================================================================
           * REGISTRO DE RASTREO
           ========================================================================================*/
            this.registrarRastreo(clsVarGlobal.PerfilUsu.idUsuario, 0, "Inicio-Pago masivo de aporte y fondo de socio", this.btnGrabar1);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            for (int i = 0; i < dtLisCrexAna.Rows.Count; i++)
            {
                bool lSeleCta = Convert.ToBoolean(dtLisCrexAna.Rows[i]["lPagoSocio"]);
                if (!lSeleCta)
                {
                    continue;
                }
                nPagaDeudaAporte = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagAporte"]);
                
                DataSet dsAporte = new DataSet("dsdetalleaporte");
                if ((nPagaDeudaAporte) > 0)
                {
                    nIdAporte= Convert.ToInt32(dtLisCrexAna.Rows[i]["idAporte"]);
                    dtAporteXPagar = cnsocio.listarAporteAPagar(nIdAporte, nPagaDeudaAporte);
                    dsAporte.Tables.Add(dtAporteXPagar);
                }
                string xmlPpgAporte =  dsAporte.GetXml();
              

                nPagaDeudaFondo = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagFondo"]);
               
                DataSet dsFondo = new DataSet("dsdetallefondo");
                if ((nPagaDeudaFondo) > 0)
                {
                    nIdFondo = Convert.ToInt32(dtLisCrexAna.Rows[i]["idFondo"]);
                    dtFondoXPagar = cnsocio.listarFondoAPagar(nIdFondo, nPagaDeudaFondo);
                    dsFondo.Tables.Add(dtFondoXPagar);
                   
                }
                string xmlPpgFondo = dsFondo.GetXml();
                DataSet dsUsuarioPagador = ObtenerDatosPagador(Convert.ToInt32(dtLisCrexAna.Rows[i]["idSocio"]),
                    Convert.ToInt32(dtLisCrexAna.Rows[i]["idcli"]),
                    Convert.ToString(dtLisCrexAna.Rows[0]["cNombre"]),
                    Convert.ToString(dtLisCrexAna.Rows[0]["cDocumentoID"]),
                    Convert.ToString(dtLisCrexAna.Rows[0]["cDireccion"]),
                    Convert.ToInt32(cboModalidad.SelectedValue),
                    Convert.ToInt32(dtLisCrexAna.Rows[0]["IdTipoPersona"])
                    );
                dsUsuarioPagador.DataSetName = "dsUsuarioPagador";

                String xmlUsuarioPagador = dsUsuarioPagador.GetXml();
                xmlUsuarioPagador = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(xmlUsuarioPagador);

                DataTable TablaUpPpg = cnsocio.RegistrarPagoMasivoAporteFondo(xmlPpgAporte, xmlPpgFondo  ,xmlUsuarioPagador, nPagaDeudaAporte,nPagaDeudaFondo);
            }
            MessageBox.Show("Pago de Aporte y Fondo de Seguro en Lote se Realizó Satisfactoriamente", "Pago Masivo de Aporte y Fondo de Seguro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(clsVarGlobal.PerfilUsu.idUsuario, 0, "Fin-Pago de aporte y fondo de socio", this.btnGrabar1);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
        }
        private DataSet ObtenerDatosPagador(int idSocio, int idCliente,string cNombre,string cDocumentoID,string cDireccion, int idModPAgoAporteFondoSeguro, int IdTipoPersona)
        { 
            DataTable dtUsuarioPagador = new DataTable("dtUsuarioPagador");
            dtUsuarioPagador.Columns.Add("idCli", typeof(int));
            dtUsuarioPagador.Columns.Add("cNombre", typeof(string));
            dtUsuarioPagador.Columns.Add("cDocumentoID", typeof(string));
            dtUsuarioPagador.Columns.Add("cDireccion", typeof(string));
            dtUsuarioPagador.Columns.Add("idModPagoAporteFondoSeg", typeof(int));
            dtUsuarioPagador.Columns.Add("idTipoPersona", typeof(int));
            dtUsuarioPagador.Columns.Add("idSocio", typeof(int));
            dtUsuarioPagador.Columns.Add("idEntidad", typeof(int));
            dtUsuarioPagador.Columns.Add("cNroCuenta", typeof(string));
            dtUsuarioPagador.Columns.Add("idCuenta", typeof(int));
            dtUsuarioPagador.Columns.Add("cSerie", typeof(string));
            dtUsuarioPagador.Columns.Add("cNroDocuemto", typeof(string));

            DataRow fila = dtUsuarioPagador.NewRow();
 
            fila["idCli"] = idCliente ;
            fila["cNombre"] = cNombre;
            fila["cDocumentoID"] = cDocumentoID;
            fila["cDireccion"] = cDireccion;
            fila["idModPagoAporteFondoSeg"] = idModPAgoAporteFondoSeguro;
            fila["idTipoPersona"] = IdTipoPersona;
            fila["idSocio"] = idSocio;//Identificador del socio al que está relacionado (por el  que va a pagar)
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)//efectivo
            {
                fila["idCuenta"] = 0;
            }
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 2)//Trasferencia
            {
                fila["idCuenta"] = Convert.ToInt32(txtIdCtaAho.Text);
            }
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 3)//cheque
            {
                fila["idEntidad"] = Convert.ToInt32(cboEntidad1.SelectedValue);
                fila["idCuenta"] = Convert.ToInt32(cboCuenta.SelectedValue);
                fila["cNroCuenta"] = txtNroCuenta.Text;
                fila["cSerie"] = txtNroSerie.Text;
                fila["cNroDocuemto"] = txtNroDocumento.Text;
            }
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 4)//interbancario
            {
                fila["idEntidad"]    = Convert.ToInt32(cboEntidad1.SelectedValue);
                fila["idCuenta"] = Convert.ToInt32(cboCuenta.SelectedValue);
                fila["cNroCuenta"] = txtNroCuenta.Text;
                fila["cSerie"]       = txtNroSerie.Text;
                fila["cNroDocuemto"] = txtNroDocumento.Text;
            }
            dtUsuarioPagador.Rows.Add(fila);

            DataSet dsUsuarioPagador = new DataSet("dsUsuarioPagador");
            dsUsuarioPagador.Tables.Add(dtUsuarioPagador);

            return dsUsuarioPagador;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            
        }

        private void frmCobroCreditosDctoPlanilla_FormClosed(object sender, FormClosedEventArgs e)
        {
      
        }

        private void dtgBase1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgPagoCrditosConvenio.CurrentRow != null)
            {
                int fila = dtgPagoCrditosConvenio.CurrentRow.Index;
                if (dtgPagoCrditosConvenio.Columns[e.ColumnIndex].Name == "lPagoSocio")
                {
                    
                    if (Convert.ToBoolean(dtLisCrexAna.Rows[fila]["lPagoSocio"]))
                    {
                        //Habilitar Celda para pagar
                        dtgPagoCrditosConvenio.CurrentRow.Cells["nMonPagAporte"].ReadOnly = false;
                        dtgPagoCrditosConvenio.CurrentRow.Cells["nMonPagFondo"].ReadOnly = false;
                    }
                    else
                    {
                        dtLisCrexAna.Rows[fila]["nMonPagAporte"] = "0.00";
                        dtLisCrexAna.Rows[fila]["nMonPagFondo"] = "0.00";
                        dtgPagoCrditosConvenio.CurrentCell = dtgPagoCrditosConvenio.Rows[fila].Cells["nMonPagAporte"];

                        dtgPagoCrditosConvenio.CurrentRow.Cells["nMonPagAporte"].ReadOnly = true;
                        dtgPagoCrditosConvenio.CurrentCell = dtgPagoCrditosConvenio.Rows[fila].Cells["nMonPagFondo"];
                        dtgPagoCrditosConvenio.CurrentRow.Cells["nMonPagFondo"].ReadOnly = true;
                        dtgPagoCrditosConvenio.Refresh();
                    }
                }
                if (dtgPagoCrditosConvenio.Columns[e.ColumnIndex].Name == "nMonPagAporte")
                {
                    //valida monto de pago del aporte
                    Decimal nTotDeudaAporte = Convert.ToDecimal (dtLisCrexAna.Rows[fila]["nDeudaAporte"]);
                    if (dtLisCrexAna.Rows[fila]["nMonPagAporte"] == null || dtLisCrexAna.Rows[fila]["nMonPagAporte"] == DBNull.Value || String.IsNullOrWhiteSpace(dtLisCrexAna.Rows[fila]["nMonPagAporte"].ToString()))
                    {
                        MessageBox.Show("Monto de Aporte a pagar debe ser mayor a cero", "Pagos Masivos de Aportes y Fondos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    Decimal nPagaDeudaAporte = Convert.ToDecimal (dtLisCrexAna.Rows[fila]["nMonPagAporte"]);
                    if (nPagaDeudaAporte > nTotDeudaAporte)
                    {
                        dtgPagoCrditosConvenio.CurrentCell = dtgPagoCrditosConvenio.Rows[fila].Cells["nMonPagAporte"];
                        MessageBox.Show("Monto Aporte a pagar no puede superar a la deuda de la cuota", "Pagos Masivos de Aportes y Fondos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                if (dtgPagoCrditosConvenio.Columns[e.ColumnIndex].Name == "nMonPagFondo")
                {
                    //valida monto de pago del fondo
                    Decimal nTotDeudaFondo = Convert.ToDecimal (dtLisCrexAna.Rows[fila]["nDeudaFondo"]);
                    if (dtLisCrexAna.Rows[fila]["nMonPagFondo"] == null || dtLisCrexAna.Rows[fila]["nMonPagFondo"] == DBNull.Value || String.IsNullOrWhiteSpace(dtLisCrexAna.Rows[fila]["nMonPagFondo"].ToString()))
                    {
                        MessageBox.Show("Monto de Fondo de Seguros a pagar debe ser mayor a cero", "Pagos Masivos de Aportes y Fondos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    Decimal nPagaDeudaFondo = Convert.ToDecimal (dtLisCrexAna.Rows[fila]["nMonPagFondo"]);
                    if (nPagaDeudaFondo > nTotDeudaFondo)
                    {
                        dtgPagoCrditosConvenio.CurrentCell = dtgPagoCrditosConvenio.Rows[fila].Cells["nMonPagFondo"];
                        MessageBox.Show("Monto Fondo a pagar no puede superar a la deuda de la cuota", "Pagos Masivos de Aportes y Fondos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                SumaPagos();
            }
        }

        private void dtgBase1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress );
               
            }
            
        }
      
        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
        
            int idConvenio = Convert.ToInt32(cboConvenio1.SelectedValue);

            dtLisCrexAna = cnsocio.retornarDatosSocioConvenio(idConvenio);
            if (dtLisCrexAna.Rows.Count <= 0)
            {
                MessageBox.Show("No existen Aporte, Ni Fondos por Pagar", "Cobros Masivos de Aportes y Fondos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            dtgPagoCrditosConvenio.DataSource = dtLisCrexAna;
            
            dtLisCrexAna.Columns["lPagoSocio"].ReadOnly = false;
            dtLisCrexAna.Columns["nMonPagAporte"].ReadOnly = false;
            dtLisCrexAna.Columns["nMonPagFondo"].ReadOnly = false;
            this.dtgPagoCrditosConvenio.Enabled = true;
            this.dtgPagoCrditosConvenio.ReadOnly = false;
            this.FormatoGrid();
            this.HabilitarGrid(true);
            if (dtLisCrexAna.Rows.Count > 0)
            {
                this.btnGrabar1.Enabled = true;
            }
          
            this.btnCancelar1.Enabled = true;
            dtgPagoCrditosConvenio.Columns["nMonPagAporte"].ReadOnly = true ;
            dtgPagoCrditosConvenio.Columns["nMonPagFondo"].ReadOnly = true;
            cboConvenio1.Enabled = false;
        }

        private void dtgPagoCrditosConvenio_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dtgPagoCrditosConvenio.IsCurrentCellDirty)
                dtgPagoCrditosConvenio.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dtgPagoCrditosConvenio_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null &&
       e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Debe Ingresar Valores correcto para el pago de Aporte y Fondo", "Cobros Masivos de Aportes y Fondos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 0 || Convert.ToInt32(cboModalidad.SelectedValue) == 1)//Sin seleccionar - EFECTIVO 
            {
                grbCuentaAhorro.Enabled = false;
                grbCheInter.Enabled = false;//panel chueque e interbancario
                txtIdCtaAho.Text = "";
                txtCuentaAho.Text = "";

                cboTipoEntidad.SelectedIndex = -1;
                cboEntidad1.SelectedIndex=-1;
                txtNroSerie.Clear();
                txtNroDocumento.Clear();
                txtNroCuenta.Clear();
                cboCuenta.SelectedIndex = -1;
                txtIdCtaAho.Clear();
                txtCuentaAho.Clear();

            }

            //TRANSFERENCIA A CUENTA AHORRO CORRIENTE
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 2)
            {
                grbCuentaAhorro.Enabled = true;
                grbCuentaAhorro.Visible = true;
                
                grbCheInter.Enabled = false;
                grbCheInter.Visible = false;

                txtIdCtaAho.Clear();
                txtCuentaAho.Clear();
            }
            //INTERBANCARIOS
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 4)
            {
                CargarCtasbancosInterbancarios();
                grbCuentaAhorro.Enabled = false;
                grbCuentaAhorro.Visible = false ;
                
                grbCheInter.Enabled = true;
                grbCheInter.Visible = true;
                cboCuenta.Visible = true;
                cboCuenta.Enabled= true;

                txtNroCuenta.Visible = false;
                cboTipoEntidad.SelectedIndex = -1;
                cboTipoEntidad.Enabled = false;
                cboEntidad1.SelectedIndex = -1;
                cboCuenta.SelectedIndex = -1;
                txtNroSerie.Clear();
                txtNroDocumento.Clear();
                txtNroCuenta.Clear();
                txtNroSerie.ReadOnly=false;
                txtNroDocumento.ReadOnly = false;
                txtNroCuenta.ReadOnly = false;

            }
            //PAGO CON CHEQUE
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 3)
            {
                grbCuentaAhorro.Enabled = false;
                grbCuentaAhorro.Visible = false;

                grbCheInter.Enabled = true;
                grbCheInter.Visible = true;
                cboCuenta.Visible = false;
                cboTipoEntidad.Enabled = true;

                cboTipoEntidad.SelectedIndex = -1;
                cboEntidad1.SelectedIndex = -1;
                txtNroSerie.Clear();
                txtNroDocumento.Clear();
                txtNroCuenta.Clear();
                txtNroSerie.ReadOnly = false;
                txtNroDocumento.ReadOnly = false;
                txtNroCuenta.Visible = true;
                txtNroCuenta.ReadOnly = false;
                txtNroCuenta.Enabled = true;
                txtNroDocumento.Enabled = true;
            }
        }
        private void CargarCtasbancosInterbancarios()
        {
            DataTable dtEntidad;
            dtEntidad = clsDeposito.ListarEntidadesConCuenta();
            //--Cheques Externos
            cboEntidad1.DataSource = dtEntidad;
            cboEntidad1.ValueMember = "idEntidad";
            cboEntidad1.DisplayMember = "cNombreCorto";
        }
        private void btnBuscaCtaAho_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cboConvenio1.SelectedValue.ToString()))
            {
                MessageBox.Show("Debe seleccionar el cliente que realiza el pago de los aportes y fondos.", "Validar Cuenta de Ahorro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboConvenio1.Focus();
                return;
            }
            DataTable dtCli=cnsocio.retornarCodCliXConvenio(Convert.ToInt32(cboConvenio1.SelectedValue));
            int idCliBenefic = Convert.ToInt32(dtCli.Rows[0]["idCli"]); ;
            frmBusCtaAho frmCtaAho = new frmBusCtaAho();
            frmCtaAho.idCli = idCliBenefic;
            frmCtaAho.pTipBus = 1;
            frmCtaAho.idMon = 1;//Actualmente el StoreProcedure retorna todas las Cuentas disponibles para retiro (no se tiene en cuenta la moneda) 
            frmCtaAho.nTipOpe = 11; //--Cuentas para Operación de Retiro         

            clsCNDeposito objDeposito = new clsCNDeposito();
            DataTable dtbNumCuentas = objDeposito.CNRetornaCuentasAhorros(idCliBenefic, 1, 1, frmCtaAho.nTipOpe);

            if (dtbNumCuentas.Rows.Count > 0)
            {
                frmCtaAho.ShowDialog();
                txtIdCtaAho.Text = frmCtaAho.pnCta;
                txtCuentaAho.Text = frmCtaAho.pcNroCta;
            }
            else
            {
                MessageBox.Show("NO EXISTE CUENTA DE AHORRO PARA VINCULAR" + "\n" + "Debe aperturar una cuenta de ahorro", "Validar Cuenta de Ahorro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdCtaAho.Text = "";
                txtCuentaAho.Text = "";
                return;
            }
        }

        private void cboTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoEntidad.SelectedIndex > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEntidad.SelectedValue);
                cboEntidad1.CargarEntidades(nTipEnt);
                cboEntidad1.SelectedIndex = -1;

            }
        }

        private void cboEntidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEntidad1.SelectedIndex == -1 || cboEntidad1.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            DataTable dt;
            int idEntidad = Convert.ToInt32(cboEntidad1.SelectedValue);
            dt = objCpg.ListarCuentaXEntidades(idEntidad);
            cboCuenta.DataSource = dt;
            cboCuenta.ValueMember = "idCuentaInstitucion";
            cboCuenta.DisplayMember = "cNumeroCuenta";
            cboCuenta.SelectedIndex = -1;
        }
    }
}
