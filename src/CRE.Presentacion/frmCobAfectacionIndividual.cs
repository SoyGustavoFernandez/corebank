using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
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
using Microsoft.Reporting.WinForms;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmCobAfectacionIndividual : frmBase
    {
        clsCNCondonacion SolicCondonacion = new clsCNCondonacion();
        clsCNCondonacion cnCondonacion = new clsCNCondonacion();
        CRE.CapaNegocio.clsCNCredito Credito = new CRE.CapaNegocio.clsCNCredito();
        clsFunUtiles objFunciones = new clsFunUtiles();
        public bool lLectura = false;

        private int idMoneda;

        public int idCuenta { get{
            return Convert.ToInt32(conBusCuentaCli.nValBusqueda);
        }}
        public int idTipoAfectacion { get{
            return Convert.ToInt32(cboTipoAfectaciones1.SelectedValue);
        }}

        private int _idGrupoAfectacion;
        public int idGrupoAfectacion { get{return this._idGrupoAfectacion;}}

        private int _idSolicitudAproba;
        public int idSolicitudAproba { get { return this._idSolicitudAproba; } }

        public frmCobAfectacionIndividual()
        {
            InitializeComponent();
        }

        private void frmCobAfectacionIndividual_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli.cTipoBusqueda = "C";
            this.conBusCuentaCli.cEstado = "[5]";
            this.conBusCuentaCli.MyClic += new EventHandler(conBusCuentaCli_MyClic);
            this.conBusCuentaCli.MyKey += new KeyPressEventHandler(conBusCuentaCli_MyKey);
            this.cboTipoAfectaciones1.SelectedIndex = -1;
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            LoadData();
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            int idCuenta = Convert.ToInt32(conBusCuentaCli.nValBusqueda);
            datosCuenta();
            verificarConsolidacion();
        }

        private void verificarConsolidacion()
        {
            if(Convert.ToInt32(conBusCuentaCli.nValBusqueda) != 0){
                DataTable res = cnCondonacion.verificarConsolidacion(Convert.ToInt32(conBusCuentaCli.nValBusqueda));
                lblConsolidado.Text = res.Rows[0]["msg"].ToString();
                cboTipoAfectaciones1.SelectedValue = Convert.ToInt32(res.Rows[0]["estado"]);
                cboTipoAfectaciones1.Enabled = false;
            }
        }

        public void LiberarCuenta()
        {
            this.conBusCuentaCli.LiberarCuenta();
            this.conBusCuentaCli.btnBusCliente1.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Focus();
            this.conBusCuentaCli.nValBusqueda = 0;
        }

        private void cargaCobsIdCuenta(int idCuenta)
        {
            DataTable dtCobs = SolicCondonacion.CNCobsVinculadasACuenta(idCuenta);
            dtCobs.Columns.Add(new DataColumn("idCuenta", typeof(int)));
            dtCobs.Columns.Add(new DataColumn("idTipoAfectacion", typeof(int)));
            dtgCobs.DataSource = dtCobs;
            formatoCobs();
            txtMontoTotalCTA.Text = obtenerSumaCobs().ToString("N2");
            cargaITF();
        }

        private void formatoCobs()
        {
            foreach (DataGridViewColumn item in dtgCobs.Columns)
            {
                item.Visible = false;
            }

            dtgCobs.Columns["idRecibo"].Visible = true;
            dtgCobs.Columns["cMoneda"].Visible = true;
            dtgCobs.Columns["nMontoTot"].Visible = true;
            dtgCobs.Columns["cSustento"].Visible = true;
            dtgCobs.Columns["idCli"].Visible = true;
            dtgCobs.Columns["IdKardex"].Visible = true;
            dtgCobs.Columns["dFechaOpe"].Visible = true;

            dtgCobs.Columns["idRecibo"].HeaderText = "Nro. Recibo";
            dtgCobs.Columns["cMoneda"].HeaderText = "M.";
            dtgCobs.Columns["nMontoTot"].HeaderText = "Monto";
            dtgCobs.Columns["cSustento"].HeaderText = "Sustento";
            dtgCobs.Columns["idCli"].HeaderText = "Cod. Cli";
            dtgCobs.Columns["IdKardex"].HeaderText = "Nro Ope.";
            dtgCobs.Columns["dFechaOpe"].HeaderText = "Fecha";

            dtgCobs.Columns["idRecibo"].DisplayIndex = 1;
            dtgCobs.Columns["cMoneda"].DisplayIndex = 2;
            dtgCobs.Columns["nMontoTot"].DisplayIndex = 3;
            dtgCobs.Columns["cSustento"].DisplayIndex = 6;
            dtgCobs.Columns["idCli"].DisplayIndex = 5;
            dtgCobs.Columns["IdKardex"].DisplayIndex = 0;
            dtgCobs.Columns["dFechaOpe"].DisplayIndex = 4;

            pintarGridCobs();
        }

        private void pintarGridCobs()
        {
            foreach (DataGridViewRow item in dtgCobs.Rows)
            {
                if (!Convert.ToBoolean(item.Cells["lRecVincCreditos"].Value))
                {
                    item.DefaultCellStyle.BackColor = Color.Cyan;
                }
            }
        }

        private decimal obtenerSumaCobs()
        {
            decimal nTotal = 0.00m;
            foreach (DataGridViewRow item in dtgCobs.Rows)
            {
                nTotal = nTotal + Convert.ToDecimal(item.Cells["nMontoTot"].Value);
            }
            return nTotal;
        }

        private string obtenerXmlCobs()
        {
            DataSet ds = new DataSet("CobsDS");
            DataTable dt = (DataTable)(dtgCobs.DataSource);
            if (dt.DataSet != null)
            {
                ds = dt.DataSet;
            }
            else
            {
                ds.Tables.Add(dt);
            }
            return ds.GetXml();
        }

        private void datosCuenta()
        {
            DataTable tbDatosCuenta = Credito.CNSaldoCredito(conBusCuentaCli.nValBusqueda);
            if (tbDatosCuenta.Rows.Count > 0)
            {
                txtMontoDesembolsado.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["nCapitalDesembolso"]));
                txtAgencia.Text = tbDatosCuenta.Rows[0]["cNombreAge"].ToString();
                txtNroCondonaciones.Text = tbDatosCuenta.Rows[0]["nNroCondo"].ToString();

                this.conProducto1.cargarProductos(1, Convert.ToInt32(tbDatosCuenta.Rows[0]["idProducto"]));
                this.txtDiasAtraso.Text = Convert.ToString(tbDatosCuenta.Rows[0]["nAtraso"]);
                this.cboCondicionContNormal.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["idCondContableNormal"]);
                this.cboCondicionContVenc.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["idCondContableVenc"]);
                this.txtAnioCastigo.Text = Convert.ToString(tbDatosCuenta.Rows[0]["nAnioCastigo"]);
                this.cboMoneda1.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["IdMoneda"]);
                idMoneda = Convert.ToInt32(tbDatosCuenta.Rows[0]["IdMoneda"]);

                this._idGrupoAfectacion = Convert.ToInt32(tbDatosCuenta.Rows[0]["idCobAfectacion"]);
                int idsolicitudAproba = Convert.ToInt32(tbDatosCuenta.Rows[0]["idSolicitudAproba"]);
                if (this._idGrupoAfectacion != 0)
                {
                    this.cargaCobsIdSolicitudAproba(idsolicitudAproba);
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    btnAgregaCobsTerceros.Enabled = false;
                    DataTable dtRes = SolicCondonacion.CNCargarAfectacionCob(idsolicitudAproba, idCuenta);
                    cboTipoAfectaciones1.SelectedValue = Convert.ToInt32(dtRes.Rows[0]["idTipoAfectacion"]);
                    txtComentario.Text = dtRes.Rows[0]["cSustento"].ToString();
                    cboTipoAfectaciones1.Enabled = false;
                    txtComentario.Enabled = false;
                    _idSolicitudAproba = Convert.ToInt32(tbDatosCuenta.Rows[0]["idSolicitudAproba"]);

                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    btnAgregaCobsTerceros.Enabled = false;
                    cboTipoAfectaciones1.Enabled = false;
                    txtComentario.Enabled = false;
                    btnEnviar1.Enabled = false;

                }
                else
                {
                    if (!lLectura)
                    {
                        this.cargaCobsIdCuenta(conBusCuentaCli.nValBusqueda);
                        btnAgregar.Enabled = true;
                        btnQuitar.Enabled = true;
                        btnAgregaCobsTerceros.Enabled = true;
                        cboTipoAfectaciones1.Enabled = true;
                        txtComentario.Enabled = true;
                        btnEnviar1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("La cuenta no tiene con Solicitud de Afectación", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        limpiarCancelar();
                    }
                }
                
            }
            cargaITF();
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarCancelar();
        }

        public void limpiarCancelar()
        {
            LiberarCuenta();
            conBusCuentaCli.limpiarControles();
            //this.xmlCoutasCondonadas = null;
            if(dtgCobs.Rows.Count>0)
                ((DataTable)dtgCobs.DataSource).Clear();
            this.conProducto1.limpiar();
            this.cboCondicionContNormal.SelectedIndex = -1;
            this.cboCondicionContVenc.SelectedIndex = -1;
            this.txtDiasAtraso.Clear();
            this.cboMoneda1.SelectedIndex = -1;
            txtAgencia.Clear();
            txtNroCondonaciones.Clear();
            txtMontoDesembolsado.Clear();
            cboTipoAfectaciones1.SelectedIndex = -1;
            cboTipoAfectaciones1.Enabled = true;
            lblConsolidado.Text = "";
            txtComentario.Text = "";
            txtMontoTotalCTA.Text = "0";
            txtITF.Text = "0";
            montoConItf.Text = "0";
            this._idGrupoAfectacion = 0;

            if (this.lLectura)
            {
                btnEnviar1.Enabled = false;
                btnCancelar1.Enabled = false;
                btnSalir1.Enabled = false;
            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
            this.Close();
        }

        private void btnAgregaCobsTerceros_Click(object sender, EventArgs e)
        {
            frmCobsDeTerceros frmCobsTerceros = new frmCobsDeTerceros(idMoneda);
            frmCobsTerceros.ShowDialog();

            if (frmCobsTerceros.drRes != null)
            {
                DataTable dt = (DataTable)dtgCobs.DataSource;
                dt.AcceptChanges();
                if (buscarRepetidos(dt, frmCobsTerceros.drRes))
                {
                    dt.ImportRow(frmCobsTerceros.drRes);
                    dtgCobs.DataSource = null;

                    dtgCobs.DataSource = dt;
                    formatoCobs();
                    txtMontoTotalCTA.Text = this.obtenerSumaCobs().ToString("N2");
                    cargaITF();
                }
            }
        }

        private bool buscarRepetidos(DataTable dt, DataRow dr)
        {
            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToInt32(item["idRecibo"]) == Convert.ToInt32(dr["idRecibo"]))
                {
                    MessageBox.Show("El recibo con Nro de Operación :" + dr["idKardex"].ToString() + ", ya se encuentra vinculado a esta solicitud de condonación", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgCobs.RowCount == 0)
                return;
            if (dtgCobs.SelectedRows == null)
                return;

            int idRecibo = Convert.ToInt32(dtgCobs.SelectedRows[0].Cells["idRecibo"].Value);
            dtgCobs.Rows.RemoveAt(dtgCobs.SelectedRows[0].Index);
            dtgCobs.Update();
            txtMontoTotalCTA.Text = obtenerSumaCobs().ToString("N2");
            cargaITF();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.cargaCobsIdCuenta(conBusCuentaCli.nValBusqueda);
        }

        public string convertXMLFiles(DataTable dt)
        {
            dt.TableName = "cobs";
            DataSet ds = new DataSet();
            if (dt.DataSet != null)
            {
                ds = dt.DataSet;
            }
            else
            {
                ds.Tables.Add(dt);
            }


            return ds.GetXml();
        }

        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                int idCuenta = Convert.ToInt32(conBusCuentaCli.nValBusqueda);
                int idTipoAfectacion = Convert.ToInt32(cboTipoAfectaciones1.SelectedValue);

                for (int i = 0; i < dtgCobs.Rows.Count; i++)
                {
                    dtgCobs.Rows[i].Cells["idCuenta"].Value = idCuenta.ToString();
                    dtgCobs.Rows[i].Cells["idTipoAfectacion"].Value = idTipoAfectacion.ToString();
                }

                string CobsXml = convertXMLFiles((DataTable)dtgCobs.DataSource);
                DataTable res = cnCondonacion.insertarGrupoCobsAfectaciones(CobsXml, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario,TiposGrupoAfectacion.AfectacionIndividual,txtComentario.Text);

                MessageBoxIcon icono = new MessageBoxIcon();
                icono = MessageBoxIcon.Exclamation;
                if (Convert.ToBoolean(res.Rows[0]["lEstadoProc"]))
                    icono = MessageBoxIcon.Information;
                MessageBox.Show(res.Rows[0]["cMensaje"].ToString(), "Registro Grupo de COBs", MessageBoxButtons.OK, icono);
                if (Convert.ToBoolean(res.Rows[0]["lEstadoProc"]))
                    limpiarCancelar();
            }
        }

        private bool Validar()
        {
            clsCNGenVariables RetVar = new clsCNGenVariables();
            string cfecha = RetVar.RetornaVariable("dFechaAct", clsVarGlobal.nIdAgencia).Trim();
            if (clsVarGlobal.dFecSystem != Convert.ToDateTime(cfecha))
            {
                MessageBox.Show("La fecha actual es distinto al del sistema", "Validar el Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dtgCobs.Rows.Count == 0)
            {
                MessageBox.Show("No se tiene ninguna COB vinculada a este Crédito", "Afectación Individual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            if (Convert.ToInt32(cboTipoAfectaciones1.SelectedValue) <= 0)
            {
                MessageBox.Show("Se debe seleccionar el Tipo de Afectación a Realizar", "Afectación Individual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtComentario.Text == "")
            {
                MessageBox.Show("Debe registrar un Comentario, este campo es requerido", "Afectación Individual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            /*DataTable consolidado = cnCondonacion.verificarConsolidacion(Convert.ToInt32(conBusCuentaCli.nValBusqueda));
            if (Convert.ToInt32(cboTipoAfectaciones1.SelectedValue) == 1 && Convert.ToInt32(consolidado.Rows[0]["estado"]) == 1)
            {
                MessageBox.Show(consolidado.Rows[0]["msg"].ToString(), "Afectación Individual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }*/

            DataTable solCond = cnCondonacion.verificarSolicitudCondonacion(Convert.ToInt32(conBusCuentaCli.nValBusqueda));
            if (solCond.Rows.Count > 0)
            {
                MessageBox.Show("Esta Cuenta tiene una Solicitud de "+solCond.Rows[0]["cTipoOperacion"]+" pendiente", "Afectación Individual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void cargaITF()
        {
            decimal nMonPago = Convert.ToDecimal(txtMontoTotalCTA.Text);
            Decimal nITF = objFunciones.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nMonPago, 2, Convert.ToInt32(this.cboMoneda1.SelectedValue));

            if (Math.Round(nITF, 2) > 0)
            {
                this.txtITF.Text = Math.Round(nITF, 2).ToString();
            }
            else
            {
                this.txtITF.Text = "0".ToString();
            }

            montoConItf.Text = (Convert.ToDecimal(txtMontoTotalCTA.Text) - Convert.ToDecimal(txtITF.Text)).ToString();
        }

        private void cargaCobsIdSolicitudAproba(int idSolicitudAproba)
        {
            DataTable dtCobs = SolicCondonacion.CNListaCobsVincSolicitudCondonacion(idSolicitudAproba, idCuenta);
            dtgCobs.DataSource = dtCobs;
            formatoCobs();
            txtMontoTotalCTA.Text = obtenerSumaCobs().ToString("N2");
        }

        private void frmCobAfectacionIndividual_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.LiberarCuenta();
        }
    }
}
