#region Referencias
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
using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using GEN.BotonesBase;
#endregion
namespace CRE.Presentacion
{
    public partial class frmOfertasClientesExclusivos : frmBase
    {
        #region Variables Globales
        ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();
        List<ClsOfertaClienteExclusivo> listOferta = new List<ClsOfertaClienteExclusivo>();
        ClsOfertaClienteExclusivo objSel;
        public int idCli = 0;
        private bool lCargaSol = false;
        public bool lCargaBoton = false;
        #endregion


        #region Constructores
        public frmOfertasClientesExclusivos()
        {
            InitializeComponent();
        }

        public frmOfertasClientesExclusivos(int _idCli)
        {
            InitializeComponent();
            this.idCli = _idCli;
            this.lCargaSol = true;
        }

        #endregion

        #region Eventos

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli1.idCli == 0)
            {
                MessageBox.Show("No se ha encontrado el cliente buscado.", "Segmentacion de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ControlarObjetos(EventoFormulario.NUEVO);
            CargarOferta(conBusCli1.idCli);
            if (!VerificarInformacionContactado() && listOferta.Count > 0)
            {
                MostrarFormContact();
            }
        }

        private void conBusPersona_ClickBuscar(object sender, EventArgs e)
        {
            ControlarObjetos(EventoFormulario.NUEVO);
            if (conBusPersona.idCliente != 0)
            {
                CargarOferta(conBusPersona.idCliente);
            }
            else
            {
                CargarOferta(Convert.ToString(conBusPersona.txtDocumentoID.Text));
                if (listOferta.Count == 0)
                {
                    MessageBox.Show("La persona no tiene ofertas disponibles.", "Segmentacion de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!VerificarInformacionContactado() && listOferta.Count > 0)
            {
                MostrarFormContact();
            }

        }

        private void frmOfertasClientesExclusivos_Load(object sender, EventArgs e)
        {
            if (this.idCli == 0)
            {
                lCargaBoton = false;
                ControlarObjetos(EventoFormulario.INICIO);
            }
            else
            {
                lCargaBoton = true;
                conBusCli1.CargardatosCli(this.idCli);
                MostrarOferta();

                ControlarObjetos(EventoFormulario.NUEVO);
            }

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {

            ControlarObjetos(EventoFormulario.CANCELAR);
        }

        private void btnOfertaCliente_Click(object sender, EventArgs e)
        {
            Button btnOfertaSeleccionada = sender as Button;
            int idOferta = Convert.ToInt32(btnOfertaSeleccionada.Tag);

            this.objSel = listOferta.FirstOrDefault(item => item.idOferta == idOferta);
            this.Dispose();
        }

        private void flpListaOfertaCliente_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flpListaOfertaCliente.Controls.Count % 4 == 0)
                flpListaOfertaCliente.SetFlowBreak(e.Control as Control, true);
        }

        private void btnRegInfCli_Click(object sender, EventArgs e)
        {
            MostrarFormContact();
        }

        
        #endregion

        #region Metodos
        private void CargarOferta(int _idCli)
        {
            if (!this.TieneOferta(_idCli))
            {
                lblBaseCustom1.Visible = true;
                pnlTieneOferta.Visible = false;
                return;
            }
            MostrarOferta();
        }

        private void CargarOferta(string _cDocumentoID, int _idTipoDocumento = 1)
        {
            if (!this.TieneOferta(_cDocumentoID, _idTipoDocumento))
            {
                lblBaseCustom1.Visible = true;
                pnlTieneOferta.Visible = false;
                return;
            }
            MostrarOferta();
        }

        private void LimpiarFormulario()
        {
            listOferta.Clear();
            conBusCli1.limpiarControles();
            conBusPersona.limpiarControles();
            lblTipoClienteExclusivo.Text = "-";
            lblFrecuencia.Text = "-";

            pnlTieneOferta.Visible = false;
        }

        private void ControlarObjetos(EventoFormulario a)
        {
            switch (a)
            {
                case EventoFormulario.INICIO:
                    LimpiarFormulario();
                    btnCancelar1.Enabled = false;
                    conBusCli1.Enabled = true;
                    break;
                case EventoFormulario.NUEVO:
                    btnCancelar1.Enabled = true;
                    conBusCli1.Enabled = false;
                    conBusPersona.txtDocumentoID.Enabled = false;
                    conBusPersona.btnBuscarCliente.Enabled = false;
                    break;
                case EventoFormulario.CANCELAR:
                    LimpiarFormulario();
                    btnCancelar1.Enabled = false;
                    conBusCli1.Enabled = true;
                    pnlTieneOferta.Visible = false;
                    lblBaseCustom1.Visible = false;
                    flpListaOfertaCliente.Controls.Clear();
                    break;
                default:
                    break;
            }
        }


        public ClsOfertaClienteExclusivo ObtenerClienteSeleccionado()
        {
            return this.objSel;
        }

        public bool TieneOferta(int _idCli)
        {
            
            DataTable dtResultado = objCE.CNObtenerOfertaCliente(_idCli);
            listOferta = MapeaTablaEntidadOfertaClienteExclusivo(dtResultado);

            if (listOferta.Count == 0)
            {
                if (!this.lCargaSol)
                {
                    MessageBox.Show("No se tiene ninguna oferta para el cliente seleccionado.", "Segmentacion de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            return true;

        }

        public bool TieneOferta(string _cDocumentoID, int _idTipoDocumento = 1)
        {
            listOferta = DataTableToList.ConvertTo<ClsOfertaClienteExclusivo>(objCE.CNObterneOfertaPersona(_cDocumentoID, _idTipoDocumento)).ToList<ClsOfertaClienteExclusivo>();

            if (listOferta.Count == 0)
            {
                if (!this.lCargaSol)
                {
                    MessageBox.Show("No se tiene ninguna oferta para el cliente seleccionado.", "Segmentación de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            if(!conBusPersona.lEsCliente)
            {
                conBusPersona.cDocumentoID = listOferta[0].cDocumentoID;
                conBusPersona.cNombreCompleto = listOferta[0].cNombreCliOferta;

                conBusPersona.MostrarDatosNoCliente();
            }

            return true;
        }

        public void MostrarOferta()
        {
            pnlTieneOferta.Visible = true;
            lblTipoClienteExclusivo.Text = listOferta[0].cTipoClienteExclusivo;
            lblFrecuencia.Text = listOferta[0].cPeriodoCred;

            List<Color> lstColores = new List<Color>();

            lstColores.Add(SystemColors.MenuHighlight);
            lstColores.Add(Color.Orange);
            lstColores.Add(Color.ForestGreen);
            lstColores.Add(Color.IndianRed);
            int nContadorColor = 0;
            foreach (ClsOfertaClienteExclusivo objOferta in listOferta)
            {
                flpListaOfertaCliente.Controls.Add(ObtenerGrupoOferta(objOferta, lstColores[nContadorColor % lstColores.Count]));
                nContadorColor++;
            }
        }

        private grbBase ObtenerGrupoOferta(ClsOfertaClienteExclusivo objOfertaCliente, Color objColor)
        {
            grbBase grbOfertaCliente = new grbBase(this.components);
            grbOfertaCliente.SuspendLayout();

            lblBaseCustom lblNMontoOferta = new GEN.ControlesBase.lblBaseCustom(this.components);
            lblBaseCustom lblMontoOferta = new GEN.ControlesBase.lblBaseCustom(this.components);
            lblBaseCustom lblNPlazoOferta = new GEN.ControlesBase.lblBaseCustom(this.components);
            lblBaseCustom lblPlazoOferta = new GEN.ControlesBase.lblBaseCustom(this.components);
            lblBaseCustom lblNDestinoOferta = new GEN.ControlesBase.lblBaseCustom(this.components);
            lblBaseCustom lblDestinoOferta = new GEN.ControlesBase.lblBaseCustom(this.components);
            lblBaseCustom lblNTipoGrupoOferta = new GEN.ControlesBase.lblBaseCustom(this.components);
            lblBaseCustom lblTipoGrupoOferta = new GEN.ControlesBase.lblBaseCustom(this.components);
            Button btnOfertaCliente = new System.Windows.Forms.Button();

            // grbOfertaCliente
            grbOfertaCliente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            grbOfertaCliente.Controls.Add(lblNDestinoOferta);
            grbOfertaCliente.Controls.Add(lblDestinoOferta);
            grbOfertaCliente.Controls.Add(btnOfertaCliente);
            grbOfertaCliente.Controls.Add(lblNPlazoOferta);
            grbOfertaCliente.Controls.Add(lblNMontoOferta);
            grbOfertaCliente.Controls.Add(lblMontoOferta);
            grbOfertaCliente.Controls.Add(lblPlazoOferta);
            grbOfertaCliente.Controls.Add(lblNTipoGrupoOferta);
            grbOfertaCliente.Controls.Add(lblTipoGrupoOferta);
            grbOfertaCliente.Location = new System.Drawing.Point(12, 222);
            grbOfertaCliente.Name = "grbOfertaCliente" + objOfertaCliente.idOferta;
            grbOfertaCliente.Size = new System.Drawing.Size(166, 185);
            grbOfertaCliente.TabIndex = 1;
            grbOfertaCliente.TabStop = false;

            // lblNMontoOferta
            lblNMontoOferta.AutoSize = true;
            lblNMontoOferta.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            lblNMontoOferta.ForeColor = System.Drawing.Color.SlateGray;
            lblNMontoOferta.Location = new System.Drawing.Point(1, 7);
            lblNMontoOferta.Name = "lblNMontoOferta" + objOfertaCliente.idOferta;
            lblNMontoOferta.Size = new System.Drawing.Size(115, 14);
            lblNMontoOferta.TabIndex = 2;
            lblNMontoOferta.Text = "Monto Ofertado:";

            // lblMontoOferta
            lblMontoOferta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            lblMontoOferta.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            lblMontoOferta.ForeColor = objColor;
            lblMontoOferta.Location = new System.Drawing.Point(4, 15);
            lblMontoOferta.Name = "lblMontoOferta" + objOfertaCliente.idOferta;
            lblMontoOferta.Size = new System.Drawing.Size(158, 30);
            lblMontoOferta.TabIndex = 3;
            lblMontoOferta.Text = "S. 0";
            lblMontoOferta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblNPlazoOferta
            lblNPlazoOferta.AutoSize = true;
            lblNPlazoOferta.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            lblNPlazoOferta.ForeColor = System.Drawing.Color.SlateGray;
            lblNPlazoOferta.Location = new System.Drawing.Point(1, 42);
            lblNPlazoOferta.Name = "lblNPlazoOferta" + objOfertaCliente.idOferta;
            lblNPlazoOferta.Size = new System.Drawing.Size(48, 14);
            lblNPlazoOferta.TabIndex = 4;
            lblNPlazoOferta.Text = "Plazo:";

            // lblPlazoOferta
            lblPlazoOferta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            lblPlazoOferta.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            lblPlazoOferta.ForeColor = objColor;
            lblPlazoOferta.Location = new System.Drawing.Point(4, 50);
            lblPlazoOferta.Name = "lblPlazoOferta" + objOfertaCliente.idOferta;
            lblPlazoOferta.Size = new System.Drawing.Size(159, 20);
            lblPlazoOferta.TabIndex = 5;
            lblPlazoOferta.Text = "0 MESES";
            lblPlazoOferta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


            // lblNDestinoOferta
            lblNDestinoOferta.AutoSize = true;
            lblNDestinoOferta.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            lblNDestinoOferta.ForeColor = System.Drawing.Color.SlateGray;
            lblNDestinoOferta.Location = new System.Drawing.Point(1, 67);
            lblNDestinoOferta.Name = "lblNDestinoOferta" + objOfertaCliente.idOferta;
            lblNDestinoOferta.Size = new System.Drawing.Size(62, 14);
            lblNDestinoOferta.TabIndex = 6;
            lblNDestinoOferta.Text = "Destino:";


            // lblDestinoOferta
            lblDestinoOferta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            lblDestinoOferta.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDestinoOferta.ForeColor = objColor;
            lblDestinoOferta.Location = new System.Drawing.Point(4, 75);
            lblDestinoOferta.Name = "lblDestinoOferta" + objOfertaCliente.idOferta;
            lblDestinoOferta.Size = new System.Drawing.Size(159, 20);
            lblDestinoOferta.TabIndex = 7;
            lblDestinoOferta.Text = "NO DEFINIDO";
            lblDestinoOferta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblNTipoGrupoOferta
            lblNTipoGrupoOferta.AutoSize = true;
            lblNTipoGrupoOferta.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            lblNTipoGrupoOferta.ForeColor = System.Drawing.Color.SlateGray;
            lblNTipoGrupoOferta.Location = new System.Drawing.Point(1, 92);
            lblNTipoGrupoOferta.Name = "lblNTipoGrupoOferta" + objOfertaCliente.idOferta;
            lblNTipoGrupoOferta.Size = new System.Drawing.Size(62, 14);
            lblNTipoGrupoOferta.TabIndex = 8;
            lblNTipoGrupoOferta.Text = "Tipo:";


            // lblTipoGrupoOferta
            lblTipoGrupoOferta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            lblTipoGrupoOferta.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTipoGrupoOferta.ForeColor = objColor;
            lblTipoGrupoOferta.Location = new System.Drawing.Point(4, 105);
            lblTipoGrupoOferta.Name = "lblTipoGrupoOferta" + objOfertaCliente.idOferta;
            lblTipoGrupoOferta.AutoSize = false;
            lblTipoGrupoOferta.Size = new System.Drawing.Size(159, 40);
            lblTipoGrupoOferta.MaximumSize = new System.Drawing.Size(160, 55);

            lblTipoGrupoOferta.TabIndex = 9;
            lblTipoGrupoOferta.Text = "NO DEFINIDO";
            lblTipoGrupoOferta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // btnOfertaCliente
            btnOfertaCliente.BackColor = objColor;
            btnOfertaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnOfertaCliente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            btnOfertaCliente.Location = new System.Drawing.Point(6, 150);
            btnOfertaCliente.Name = "btnOfertaCliente" + objOfertaCliente.idOferta; ;
            btnOfertaCliente.Size = new System.Drawing.Size(153, 29);
            btnOfertaCliente.TabIndex = 6;
            btnOfertaCliente.Text = "Seleccionar";
            btnOfertaCliente.UseVisualStyleBackColor = false;
            btnOfertaCliente.Click += new System.EventHandler(this.btnOfertaCliente_Click);
            btnOfertaCliente.Tag = objOfertaCliente.idOferta;


            grbOfertaCliente.ResumeLayout(false);
            grbOfertaCliente.PerformLayout();

            lblMontoOferta.Text = "S/ " + objOfertaCliente.nMontoOferta.ToString("N2");
            lblPlazoOferta.Text = (objOfertaCliente.nPlazo == 0) ? "LIBRE" :  objOfertaCliente.nPlazo.ToString() + " MESES";
            lblDestinoOferta.Text = objOfertaCliente.cDestinoCredito.ToString();
            lblTipoGrupoOferta.Text = objOfertaCliente.cTipoGrupoCamp.ToString() + "\n" + objOfertaCliente.cGrupoProducto;

            if(objOfertaCliente.idDestinoCredito == 0)
            {
                lblNDestinoOferta.Visible = false;
                lblDestinoOferta.Visible = false;
            }

            if(objOfertaCliente.cGrupoProducto.In("COMPRA DE DEUDA 1","COMPRA DE DEUDA 2") )
            {
                lblNPlazoOferta.Visible = false;
                lblPlazoOferta.Visible = false;
            }
            btnOfertaCliente.Visible = lCargaBoton;

            return grbOfertaCliente;
        }

        public void MostrarFormContact()
        {
            int idCliente = 0;
            string cDocumento = "";
            if (tbcOpcionBusqueda.SelectedTab.Name == "tabBusquedaCliente")
            {
                idCliente = conBusCli1.idCli;
                cDocumento = conBusCli1.txtNroDoc.Text;
            }
            else
            {
                idCliente = Convert.ToInt32(String.IsNullOrEmpty(conBusPersona.txtCodigoCliente.Text) ? "0" : conBusPersona.txtCodigoCliente.Text);
                cDocumento = conBusPersona.txtDocumentoID.Text;
            }


            frmRegistroInfClienteOferta frm = new frmRegistroInfClienteOferta(idCliente, cDocumento);
            frm.ShowDialog();
           
        }

        public bool VerificarInformacionContactado()
        {
            int idCliente = 0;
            string cDocumentoID = String.Empty;

            idCliente = (conBusPersona.idCliente != 0) ? conBusPersona.idCliente : (conBusCli1.idCli != 0) ? conBusCli1.idCli : 0 ;
            cDocumentoID = (!String.IsNullOrWhiteSpace(conBusPersona.cDocumentoID)) ? conBusPersona.cDocumentoID : (!String.IsNullOrWhiteSpace(conBusCli1.txtNroDoc.ToString())) ? conBusCli1.txtNroDoc.ToString() : String.Empty;

            if (idCliente != 0 || !String.IsNullOrWhiteSpace(cDocumentoID))
            {
                DataTable dtInfoContacto = objCE.CNVerificarInformacionContacto(idCliente, cDocumentoID);
                if (dtInfoContacto.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private List<ClsOfertaClienteExclusivo> MapeaTablaEntidadOfertaClienteExclusivo(DataTable dtResult)
        {
            List<ClsOfertaClienteExclusivo> lstOfertaClienteExclusivo = new List<ClsOfertaClienteExclusivo>();
            foreach (DataRow row in dtResult.Rows)
            {
                ClsOfertaClienteExclusivo objOfertaClienteExclusivo = new ClsOfertaClienteExclusivo();

                objOfertaClienteExclusivo.idOferta = Convert.ToInt32(row["idOferta"]);
                objOfertaClienteExclusivo.idCli = Convert.ToInt32(row["idCli"]);
                objOfertaClienteExclusivo.nPlazo = Convert.ToInt32(row["nPlazo"]);
                objOfertaClienteExclusivo.nMontoOferta = Convert.ToDecimal(row["nMontoOferta"]);
                objOfertaClienteExclusivo.cGrupoProducto = Convert.ToString(row["cGrupoProducto"]);
                objOfertaClienteExclusivo.cTipoClienteExclusivo = Convert.ToString(row["cTipoClienteExclusivo"]);
                objOfertaClienteExclusivo.cTipoGrupoCamp = Convert.ToString(row["cTipoGrupoCamp"]);
                objOfertaClienteExclusivo.cPeriodoCred = Convert.ToString(row["cPeriodoCred"]);
                objOfertaClienteExclusivo.idGrupoProducto = Convert.ToInt16(row["idGrupoProducto"]);
                objOfertaClienteExclusivo.idTipoClienteExclusivo = Convert.ToInt16(row["idTipoClienteExclusivo"]);
                objOfertaClienteExclusivo.idTipoGrupoCamp = Convert.ToInt16(row["idTipoGrupoCamp"]);
                objOfertaClienteExclusivo.idPeriodoCre = Convert.ToInt16(row["idPeriodoCre"]);
                objOfertaClienteExclusivo.idOperacion = Convert.ToInt16(row["idOperacion"]);
                objOfertaClienteExclusivo.cOperacion = Convert.ToString(row["cOperacion"]);
                objOfertaClienteExclusivo.idModalidadCredito = Convert.ToInt16(row["idModalidadCredito"]);
                objOfertaClienteExclusivo.cModalidadCredito = Convert.ToString(row["cModalidadCredito"]);
                objOfertaClienteExclusivo.nMeses = Convert.ToInt16(row["nMeses"]);
                objOfertaClienteExclusivo.idGrupoCamp = Convert.ToInt16(row["idGrupoCamp"]);
                objOfertaClienteExclusivo.cGrupoCamp = Convert.ToString(row["cGrupoCamp"]);
                objOfertaClienteExclusivo.cDocumentoID = Convert.ToString(row["cDocumentoID"]);
                objOfertaClienteExclusivo.idTipoDocumento = Convert.ToInt16(row["idTipoDocumento"]);
                objOfertaClienteExclusivo.cTipoDocumento = Convert.ToString(row["cTipoDocumento"]);
                objOfertaClienteExclusivo.cNombreCliOferta = Convert.ToString(row["cNombreCliOferta"]);
                objOfertaClienteExclusivo.idDestinoCredito = Convert.ToInt16(row["idDestinoCredito"]);
                objOfertaClienteExclusivo.cDestinoCredito = Convert.ToString(row["cDestinoCredito"]);
                objOfertaClienteExclusivo.lCargaAutomaticoProd = Convert.ToBoolean(row["lCargaAutomaticaProd"]);
                objOfertaClienteExclusivo.idClasifInterna = Convert.ToInt16(row["idClasifInterna"]);

                lstOfertaClienteExclusivo.Add(objOfertaClienteExclusivo);
            }

            return lstOfertaClienteExclusivo;
        }
        
        #endregion

        

       
    }
}