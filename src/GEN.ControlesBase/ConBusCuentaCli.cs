using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using EntityLayer;
using DEP.CapaNegocio;
using CRE.CapaNegocio;
using ADM.CapaNegocio;
using CAJ.CapaNegocio;
using System.Security.Cryptography;

namespace GEN.ControlesBase
{

    public partial class ConBusCuentaCli : UserControl
    {
        #region Variable Globales

        /// <summary>
        /// Indica que tipo de información se buscará C=>Créditos,S=>Soliciutd de Crédito,D=>Depósitos,F=>Cartas Fianzas
        /// </summary>
        public String cTipoBusqueda = "";
        public bool lFrmProyeCancel = false;//jcasas
        /// <summary>
        /// Indica los estados a buscar, deberán estar entre corchetes y separados por comas ejm: [1,2,3]
        /// </summary>
        public String cEstado = "[5]";
        public Int32 nValBusqueda;
        public new event KeyPressEventHandler MyKey;
        public new event EventHandler MyClic;
        public new event EventHandler ChangeDocumentoID;
        public Int32 nIndNumCuentaSol = 0;
        public Int32 nIdCliente;
        public Int32 nIdCuenta;
        public Nullable<int> nidUserBloqueo;
        public string cUserBloqueo, pcDireccion, pcTelefono;
        public int idTipoDocumento,idTipoPersona;
        public int idAgenciaCred = 0;

        public Int32 nOperacion = 0;
        public int idProducto = 0;

        public int idSolicitudcre = 0;

        clsCNBuscarCli ValidaCliBN = new clsCNBuscarCli();

        public bool lResetBusqueda = false, lTasaBusqueda = false, lTasaBusquedaPos = false, lOperTasa = false;
        #endregion

        public ConBusCuentaCli()
        {
            InitializeComponent();

        }

        private void btnBusCliente1_Click(object sender, EventArgs e)
        {
            FrmBusCli FrmBus = new FrmBusCli();
            FrmBus.ShowDialog();


            if (String.IsNullOrEmpty(FrmBus.pcCodCli))
            {
                MessageBox.Show("No se encontró ningún Registro", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //this.txtNroBusqueda.Clear();
                //this.txtNombreCli.Clear();
                this.txtNroBusqueda.Focus();
                btnBusCliente1.Enabled = true;
            }
            else
            {
                string cEvento = buscarCuentasPorCliente(Convert.ToInt32(FrmBus.pcCodCli));
                switch (cEvento)
                { 
                    case "E": // evento Solo
                        if (MyClic != null)
                            MyClic(sender, e);
                        break;
                    case "EB": // evento Botones
                        if (MyClic != null)
                        {
                            MyClic(sender, e);
                            if (!lResetBusqueda)
                            {
                                btnBusCliente1.Enabled = false;
                                txtNroBusqueda.Enabled = false;
                            }
                        }
                        break;
                }
            }
        }

        public string buscarCuentasPorCliente(int idCli)
        {
            int nIdSolCta;
            string cEvento = "";
            nIdCliente = Convert.ToInt32(idCli);
            this.idProducto = 0;

            switch (this.cTipoBusqueda)
            {
                case "D":
                    DepositoCli(nIdCliente, cEstado);

                    cEvento = "E";
                    break;
                default:

                    if (lTasaBusqueda == true)
                    {
                        clsCNSolicitud cnsolicitud = new clsCNSolicitud();
                        DataTable dtESolTasa = cnsolicitud.CNObtenerEstadoSolicitudTasaNegociable();
                        if (dtESolTasa.Rows.Count > 0)
                        {
                            cEstado = Convert.ToString(dtESolTasa.Rows[0]["cValVar"]);
                        }
                    }

                    clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
                    DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(nIdCliente, cTipoBusqueda, cEstado);
                    if (dtDatosCuentaSolCliente.Rows.Count == 1)
                    {
                        nIdSolCta = Convert.ToInt32(dtDatosCuentaSolCliente.Rows[0][0]);
                        this.idProducto = Convert.ToInt32(dtDatosCuentaSolCliente.Rows[0]["idProducto"]);
                        this.txtNroBusqueda.Text = nIdSolCta.ToString();
                        nValBusqueda = nIdSolCta;
                        if (this.cTipoBusqueda == "C")
                        {
                            clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
                            DataTable dtDatosNumCuenta = RetornaNumCuenta.RetornaNumCuenta(nValBusqueda, cTipoBusqueda, cEstado);
                            if (dtDatosNumCuenta.Rows.Count == 0)
                            {
                                MessageBox.Show("No se encontró Número de Cuenta", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.txtNroBusqueda.Clear();
                            }
                            else
                            {
                                DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(nValBusqueda);
                                nidUserBloqueo = (Nullable<int>)dtEstCuenta.Rows[0][0];
                                if (nidUserBloqueo != 0)
                                {
                                    DataTable dtUsu = new DataTable();
                                    dtUsu = RetornaNumCuenta.BusUsuBlo((int)nidUserBloqueo);
                                    cUserBloqueo = dtUsu.Rows[0][0].ToString();
                                    MessageBox.Show("Cuenta Bloqueada por usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.txtCodIns.Text = "";
                                    this.txtCodAge.Text = "";
                                    this.txtCodMod.Text = "";
                                    this.txtCodMon.Text = "";
                                    this.txtNroBusqueda.Text = "";

                                    this.txtCodCli.Text = "";
                                    this.txtNroDoc.Text = "";
                                    this.txtNombreCli.Text = "";
                                    this.txtEstado.Text = "";

                                    this.txtNroBusqueda.Focus();
                                    nValBusqueda = 0;
                                }
                                else
                                {
                                    btnBusCliente1.Enabled = false;
                                    txtNroBusqueda.Enabled = false;

                                    if (lFrmProyeCancel != true)
                                    {
                                    RetornaNumCuenta.UpdEstCuenta(nValBusqueda, clsVarGlobal.User.idUsuario);
                                    }


                                    this.txtCodIns.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                                    this.txtCodAge.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                                    this.txtCodMod.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(6, 2);
                                    this.txtCodMon.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(8, 1);
                                    this.txtNroBusqueda.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(9);

                                    this.txtCodCli.Text = dtDatosNumCuenta.Rows[0]["cCodCliente"].ToString();
                                    this.txtNroDoc.Text = dtDatosNumCuenta.Rows[0]["cDocumentoID"].ToString();
                                    this.txtNombreCli.Text = dtDatosNumCuenta.Rows[0]["cNombre"].ToString();
                                    this.txtEstado.Text = dtDatosNumCuenta.Rows[0]["cEstado"].ToString();
                                    this.idTipoDocumento = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idTipoDocumento"].ToString());

                                    this.idAgenciaCred = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idAgenciaCred"]);                                   
                                }
                            }
                        }
                        else
                        {

                            clsCNRetornaNumSolicitud RetornaNumSolicitud = new clsCNRetornaNumSolicitud();
                            DataTable dtDatosNumSolicutd = RetornaNumSolicitud.CNRetornaNumSolicitud(nValBusqueda, cTipoBusqueda, cEstado);
                            if (dtDatosNumSolicutd.Rows.Count == 0)
                            {
                                MessageBox.Show("No se Encontró Número de Solicitud", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.txtNroBusqueda.Clear();
                                this.txtNroBusqueda.Focus();
                            }
                            else
                            {
                                
                                DataRow filaEstado;
                                filaEstado = dtDatosNumSolicutd.Rows[0];
                                string cEstadoSolicitud = Convert.ToString(filaEstado["cEstado"]);
                                //if (cEstadoSolicitud != "APROBADO")
                                //{
                                //    string cMensaje = "El estado de la solicitud es: " + cEstadoSolicitud + ".";
                                //    MessageBox.Show(cMensaje, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                //    this.txtNroBusqueda.Clear();
                                //    this.nValBusqueda = -1;
                                //    this.txtNroBusqueda.Focus();
                                //    nValBusqueda = 0;
                                //    break;
                                //}

                                this.txtNroBusqueda.Text = (this.cTipoBusqueda != "F") ? dtDatosNumSolicutd.Rows[0]["idSolicitud"].ToString() : dtDatosNumSolicutd.Rows[0]["idCartaFianza"].ToString();
                                this.txtCodCli.Text = dtDatosNumSolicutd.Rows[0]["cCodCliente"].ToString();
                                this.txtNroDoc.Text = dtDatosNumSolicutd.Rows[0]["cDocumentoID"].ToString();
                                this.txtNombreCli.Text = dtDatosNumSolicutd.Rows[0]["cNombre"].ToString();
                                this.txtEstado.Text = dtDatosNumSolicutd.Rows[0]["cEstado"].ToString();
                                this.idTipoDocumento = Convert.ToInt32(dtDatosNumSolicutd.Rows[0]["idTipoDocumento"].ToString());
                                this.pcDireccion = dtDatosNumSolicutd.Rows[0]["cDireccion"].ToString();
                                this.pcTelefono = dtDatosNumSolicutd.Rows[0]["cTelefono"].ToString();
                                this.idTipoPersona = Convert.ToInt32(dtDatosNumSolicutd.Rows[0]["IdTipoPersona"].ToString());

                                nOperacion = Convert.ToInt32(dtDatosNumSolicutd.Rows[0]["idOperacion"]);
                            }
                        }
                        cEvento = "EB";
                    }

                    else if (dtDatosCuentaSolCliente.Rows.Count > 1)
                    {
                        FrmBuscaCuentaCliente frmBusCuenCli = new FrmBuscaCuentaCliente();
                        frmBusCuenCli.CargarDatos(nIdCliente, this.cTipoBusqueda, this.cEstado);
                        frmBusCuenCli.ShowDialog();
                        nValBusqueda = Convert.ToInt32(frmBusCuenCli.cIdCreSol);

                        this.txtNroBusqueda.Text = frmBusCuenCli.cIdCreSol;
                        this.txtCodCli.Text = frmBusCuenCli.cCodCliente;
                        this.txtNroDoc.Text = frmBusCuenCli.NroDocument;
                        this.txtNombreCli.Text = frmBusCuenCli.cNombre;
                        this.txtEstado.Text = frmBusCuenCli.cEstado;

                        if (this.cTipoBusqueda == "C")
                        {

                            clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
                            DataTable dtDatosNumCuenta = RetornaNumCuenta.RetornaNumCuenta(nValBusqueda, cTipoBusqueda, cEstado);
                            if (dtDatosNumCuenta.Rows.Count == 0)
                            {
                                MessageBox.Show("No se encontró Número de Cuenta", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.txtNroBusqueda.Clear();
                            }
                            else
                            {
                                this.idProducto = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idProducto"]);
                                DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(nValBusqueda);
                                nidUserBloqueo = (Nullable<int>)dtEstCuenta.Rows[0][0];
                                if (nidUserBloqueo != 0)
                                {
                                    DataTable dtUsu = new DataTable();
                                    dtUsu = RetornaNumCuenta.BusUsuBlo((int)nidUserBloqueo);
                                    cUserBloqueo = dtUsu.Rows[0][0].ToString();
                                    MessageBox.Show("Cuenta Bloqueada por usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    this.txtCodIns.Text = "";
                                    this.txtCodAge.Text = "";
                                    this.txtCodMod.Text = "";
                                    this.txtCodMon.Text = "";
                                    this.txtNroBusqueda.Text = "";
                                    this.txtCodCli.Text = "";
                                    this.txtNombreCli.Text = "";
                                    this.txtNroDoc.Text = "";
                                    this.txtEstado.Text = "";
                                    this.txtNroBusqueda.Focus();
                                    nValBusqueda = 0;
                                }
                                else
                                {
                                    btnBusCliente1.Enabled = false;
                                    txtNroBusqueda.Enabled = false;
                                    RetornaNumCuenta.UpdEstCuenta(nValBusqueda, clsVarGlobal.User.idUsuario);

                                    this.txtCodIns.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                                    this.txtCodAge.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                                    this.txtCodMod.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(6, 2);
                                    this.txtCodMon.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(8, 1);
                                    this.txtNroBusqueda.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(9);

                                    this.txtCodCli.Text = dtDatosNumCuenta.Rows[0]["cCodCliente"].ToString();
                                    this.txtNroDoc.Text = dtDatosNumCuenta.Rows[0]["cDocumentoID"].ToString();
                                    this.txtNombreCli.Text = dtDatosNumCuenta.Rows[0]["cNombre"].ToString();
                                    this.txtEstado.Text = dtDatosNumCuenta.Rows[0]["cEstado"].ToString();
                                    this.idTipoDocumento = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idTipoDocumento"].ToString());

                                    this.idAgenciaCred = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idAgenciaCred"]);

                                    cEvento = "E";
                                }
                            }
                        }
                        else
                        {
                            clsCNRetornaNumSolicitud RetornaNumSolicitud = new clsCNRetornaNumSolicitud();
                            DataTable dtDatosNumSolicutd = RetornaNumSolicitud.CNRetornaNumSolicitud(nValBusqueda, cTipoBusqueda, cEstado);
                            if (dtDatosNumSolicutd.Rows.Count == 0)
                            {
                                MessageBox.Show("No se Encontró Número de Solicitud", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.txtNroBusqueda.Clear();
                                this.txtNroBusqueda.Focus();
                            }
                            else
                            {
                                this.txtNroBusqueda.Text = (this.cTipoBusqueda != "F") ? dtDatosNumSolicutd.Rows[0]["idSolicitud"].ToString() : dtDatosNumSolicutd.Rows[0]["idCartaFianza"].ToString();
                                this.txtCodCli.Text = dtDatosNumSolicutd.Rows[0]["cCodCliente"].ToString();
                                this.txtNroDoc.Text = dtDatosNumSolicutd.Rows[0]["cDocumentoID"].ToString();
                                this.txtNombreCli.Text = dtDatosNumSolicutd.Rows[0]["cNombre"].ToString();
                                this.txtEstado.Text = dtDatosNumSolicutd.Rows[0]["cEstado"].ToString();
                                this.idTipoDocumento = Convert.ToInt32(dtDatosNumSolicutd.Rows[0]["idTipoDocumento"].ToString());
                                nOperacion = Convert.ToInt32(dtDatosNumSolicutd.Rows[0]["idOperacion"]);
                                cEvento = "E";
                            }
                        }
                        
                    }
                    else // No se encontro cuentas o solicitudes para el cliente
                    {
                        DataTable dtEstadoBuscado;
                        if (this.cTipoBusqueda == "F")
                        {
                            dtEstadoBuscado = new clsCNEstadoCartaFianza().obtenerEstadosCartaFianza(cEstado);

                            MessageBox.Show("El cliente no tiene cartas fianza en estado: " + dtEstadoBuscado.Rows[0]["cDescri"], "Buscar Carta Fianza Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtNroBusqueda.Clear();
                            nValBusqueda = 0;
                        }
                        else
                        {
                            dtEstadoBuscado = new clsCNEstadoCredito().CNEstadoBusqueda(cEstado);
                            if (this.cTipoBusqueda == "C")
                            {
                                MessageBox.Show("El cliente no tiene cuentas en estado: " + dtEstadoBuscado.Rows[0]["cDescri"], "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                this.txtNroBusqueda.Clear();
                                nValBusqueda = 0;
                            }
                            else
                            {   
                                if (lTasaBusqueda == true) 
                                {
                                    var cEstadosTasa = "";
                                    clsCNSolicitud cnsolicitud = new clsCNSolicitud();
                                    DataTable dtEstadosTasa = cnsolicitud.CNObtenerEstadoTasaNegociable();
                                    foreach (DataRow fila in dtEstadosTasa.Rows)
                                    {
                                        cEstadosTasa = cEstadosTasa + fila["cEstado"].ToString() + ",";
                                    }
                                    MessageBox.Show("La solicitud de crédito del cliente no se encuentra dentro de los estados permitidos[" + cEstadosTasa + "]", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else 
                                {
                                    if (lOperTasa == true)
                                    {
                                        MessageBox.Show("El cliente no tiene Operaciones pendientes para procesar.", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else
                                    {
                                        MessageBox.Show("El cliente no tiene cuentas en estado: " + dtEstadoBuscado.Rows[0]["cDescri"], "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                this.txtNroBusqueda.Clear();
                                nValBusqueda = 0;
                            }
                        }
                        cEvento = "E";
                    }
                    break;
            }
            return cEvento;
        }

        public string buscarCuentasPorClienteRef(int idCli, int cIdCreSol, string cCodCliente, string cNroDocument, string cNombre)
        {

            int nIdSolCta;
            string cEvento = "";
            nIdCliente = Convert.ToInt32(idCli);
            this.idProducto = 0;

            switch (this.cTipoBusqueda)
            {
                case "D":
                    DepositoCli(nIdCliente, cEstado);

                    cEvento = "E";
                    break;
                default:
                    clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
                    DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(nIdCliente, cTipoBusqueda, cEstado);
                    if (dtDatosCuentaSolCliente.Rows.Count == 1)
                    {
                        nIdSolCta = Convert.ToInt32(dtDatosCuentaSolCliente.Rows[0][0]);
                        this.idProducto = Convert.ToInt32(dtDatosCuentaSolCliente.Rows[0]["idProducto"]);
                        this.txtNroBusqueda.Text = nIdSolCta.ToString();
                        nValBusqueda = nIdSolCta;
                        if (this.cTipoBusqueda == "C")
                        {
                            clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
                            DataTable dtDatosNumCuenta = RetornaNumCuenta.RetornaNumCuenta(nValBusqueda, cTipoBusqueda, cEstado);
                            if (dtDatosNumCuenta.Rows.Count == 0)
                            {
                                MessageBox.Show("No se encontró Número de Cuenta", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.txtNroBusqueda.Clear();
                            }
                            else
                            {
                                DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(nValBusqueda);
                                nidUserBloqueo = (Nullable<int>)dtEstCuenta.Rows[0][0];
                                if (nidUserBloqueo != 0)
                                {
                                    DataTable dtUsu = new DataTable();
                                    dtUsu = RetornaNumCuenta.BusUsuBlo((int)nidUserBloqueo);
                                    cUserBloqueo = dtUsu.Rows[0][0].ToString();
                                    MessageBox.Show("Cuenta Bloqueada por usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.txtCodIns.Text = "";
                                    this.txtCodAge.Text = "";
                                    this.txtCodMod.Text = "";
                                    this.txtCodMon.Text = "";
                                    this.txtNroBusqueda.Text = "";

                                    this.txtCodCli.Text = "";
                                    this.txtNroDoc.Text = "";
                                    this.txtNombreCli.Text = "";
                                    this.txtEstado.Text = "";

                                    this.txtNroBusqueda.Focus();
                                    nValBusqueda = 0;
                                }
                                else
                                {
                                    btnBusCliente1.Enabled = false;
                                    txtNroBusqueda.Enabled = false;

                                    if (lFrmProyeCancel != true)
                                    {
                                        RetornaNumCuenta.UpdEstCuenta(nValBusqueda, clsVarGlobal.User.idUsuario);
                                    }


                                    this.txtCodIns.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                                    this.txtCodAge.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                                    this.txtCodMod.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(6, 2);
                                    this.txtCodMon.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(8, 1);
                                    this.txtNroBusqueda.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(9);

                                    this.txtCodCli.Text = dtDatosNumCuenta.Rows[0]["cCodCliente"].ToString();
                                    this.txtNroDoc.Text = dtDatosNumCuenta.Rows[0]["cDocumentoID"].ToString();
                                    this.txtNombreCli.Text = dtDatosNumCuenta.Rows[0]["cNombre"].ToString();
                                    this.txtEstado.Text = dtDatosNumCuenta.Rows[0]["cEstado"].ToString();
                                    this.idTipoDocumento = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idTipoDocumento"].ToString());

                                    this.idAgenciaCred = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idAgenciaCred"]);
                                }
                            }
                        }
                        else
                        {

                            clsCNRetornaNumSolicitud RetornaNumSolicitud = new clsCNRetornaNumSolicitud();
                            DataTable dtDatosNumSolicutd = RetornaNumSolicitud.CNRetornaNumSolicitud(nValBusqueda, cTipoBusqueda, cEstado);
                            if (dtDatosNumSolicutd.Rows.Count == 0)
                            {
                                MessageBox.Show("No se Encontró Número de Solicitud", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.txtNroBusqueda.Clear();
                                this.txtNroBusqueda.Focus();
                            }
                            else
                            {
                                this.txtNroBusqueda.Text = (this.cTipoBusqueda != "F") ? dtDatosNumSolicutd.Rows[0]["idSolicitud"].ToString() : dtDatosNumSolicutd.Rows[0]["idCartaFianza"].ToString();
                                this.txtCodCli.Text = dtDatosNumSolicutd.Rows[0]["cCodCliente"].ToString();
                                this.txtNroDoc.Text = dtDatosNumSolicutd.Rows[0]["cDocumentoID"].ToString();
                                this.txtNombreCli.Text = dtDatosNumSolicutd.Rows[0]["cNombre"].ToString();
                                this.txtEstado.Text = dtDatosNumSolicutd.Rows[0]["cEstado"].ToString();
                                this.idTipoDocumento = Convert.ToInt32(dtDatosNumSolicutd.Rows[0]["idTipoDocumento"].ToString());

                                nOperacion = Convert.ToInt32(dtDatosNumSolicutd.Rows[0]["idOperacion"]);
                            }
                        }
                        cEvento = "EB";
                    }

                    else if (dtDatosCuentaSolCliente.Rows.Count > 1)
                    {
                        //FrmBuscaCuentaCliente frmBusCuenCli = new FrmBuscaCuentaCliente();
                        //frmBusCuenCli.CargarDatos(nIdCliente, this.cTipoBusqueda, this.cEstado);
                        //frmBusCuenCli.ShowDialog();
                        nValBusqueda = cIdCreSol;//Convert.ToInt32(frmBusCuenCli.cIdCreSol);

                        this.txtNroBusqueda.Text = cIdCreSol.ToString(); //frmBusCuenCli.cIdCreSol;
                        this.txtCodCli.Text = cCodCliente;//frmBusCuenCli.cCodCliente;
                        this.txtNroDoc.Text = cNroDocument;//frmBusCuenCli.NroDocument;
                        this.txtNombreCli.Text = cNombre;//frmBusCuenCli.cNombre;
                        this.txtEstado.Text = cEstado;

                        if (this.cTipoBusqueda == "C")
                        {

                            clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
                            DataTable dtDatosNumCuenta = RetornaNumCuenta.RetornaNumCuenta(nValBusqueda, cTipoBusqueda, cEstado);
                            if (dtDatosNumCuenta.Rows.Count == 0)
                            {
                                MessageBox.Show("No se encontró Número de Cuenta", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.txtNroBusqueda.Clear();
                            }
                            else
                            {
                                this.idProducto = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idProducto"]);
                                DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(nValBusqueda);
                                nidUserBloqueo = (Nullable<int>)dtEstCuenta.Rows[0][0];
                                if (nidUserBloqueo != 0)
                                {
                                    DataTable dtUsu = new DataTable();
                                    dtUsu = RetornaNumCuenta.BusUsuBlo((int)nidUserBloqueo);
                                    cUserBloqueo = dtUsu.Rows[0][0].ToString();
                                    MessageBox.Show("Cuenta Bloqueada por usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    this.txtCodIns.Text = "";
                                    this.txtCodAge.Text = "";
                                    this.txtCodMod.Text = "";
                                    this.txtCodMon.Text = "";
                                    this.txtNroBusqueda.Text = "";
                                    this.txtCodCli.Text = "";
                                    this.txtNombreCli.Text = "";
                                    this.txtNroDoc.Text = "";
                                    this.txtEstado.Text = "";
                                    this.txtNroBusqueda.Focus();
                                    nValBusqueda = 0;
                                }
                                else
                                {
                                    btnBusCliente1.Enabled = false;
                                    txtNroBusqueda.Enabled = false;
                                    RetornaNumCuenta.UpdEstCuenta(nValBusqueda, clsVarGlobal.User.idUsuario);

                                    this.txtCodIns.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                                    this.txtCodAge.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                                    this.txtCodMod.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(6, 2);
                                    this.txtCodMon.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(8, 1);
                                    this.txtNroBusqueda.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(9);

                                    this.txtCodCli.Text = dtDatosNumCuenta.Rows[0]["cCodCliente"].ToString();
                                    this.txtNroDoc.Text = dtDatosNumCuenta.Rows[0]["cDocumentoID"].ToString();
                                    this.txtNombreCli.Text = dtDatosNumCuenta.Rows[0]["cNombre"].ToString();
                                    this.txtEstado.Text = dtDatosNumCuenta.Rows[0]["cEstado"].ToString();
                                    this.idTipoDocumento = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idTipoDocumento"].ToString());

                                    this.idAgenciaCred = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idAgenciaCred"]);

                                    cEvento = "E";
                                }
                            }
                        }
                        else
                        {
                            clsCNRetornaNumSolicitud RetornaNumSolicitud = new clsCNRetornaNumSolicitud();
                            DataTable dtDatosNumSolicutd = RetornaNumSolicitud.CNRetornaNumSolicitud(nValBusqueda, cTipoBusqueda, cEstado);
                            if (dtDatosNumSolicutd.Rows.Count == 0)
                            {
                                MessageBox.Show("No se Encontró Número de Solicitud", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.txtNroBusqueda.Clear();
                                this.txtNroBusqueda.Focus();
                            }
                            else
                            {
                                this.txtNroBusqueda.Text = (this.cTipoBusqueda != "F") ? dtDatosNumSolicutd.Rows[0]["idSolicitud"].ToString() : dtDatosNumSolicutd.Rows[0]["idCartaFianza"].ToString();
                                this.txtCodCli.Text = dtDatosNumSolicutd.Rows[0]["cCodCliente"].ToString();
                                this.txtNroDoc.Text = dtDatosNumSolicutd.Rows[0]["cDocumentoID"].ToString();
                                this.txtNombreCli.Text = dtDatosNumSolicutd.Rows[0]["cNombre"].ToString();
                                this.txtEstado.Text = dtDatosNumSolicutd.Rows[0]["cEstado"].ToString();
                                this.idTipoDocumento = Convert.ToInt32(dtDatosNumSolicutd.Rows[0]["idTipoDocumento"].ToString());
                                nOperacion = Convert.ToInt32(dtDatosNumSolicutd.Rows[0]["idOperacion"]);
                                cEvento = "E";
                            }
                        }

                    }
                    else // No se encontro cuentas o solicitudes para el cliente
                    {
                        DataTable dtEstadoBuscado;
                        if (this.cTipoBusqueda == "F")
                        {
                            dtEstadoBuscado = new clsCNEstadoCartaFianza().obtenerEstadosCartaFianza(cEstado);

                            MessageBox.Show("El cliente no tiene cartas fianza en estado: " + dtEstadoBuscado.Rows[0]["cDescri"], "Buscar Carta Fianza Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtNroBusqueda.Clear();
                            nValBusqueda = 0;
                        }
                        else
                        {
                            dtEstadoBuscado = new clsCNEstadoCredito().CNEstadoBusqueda(cEstado);
                            if (this.cTipoBusqueda == "C")
                            {
                                MessageBox.Show("El cliente no tiene cuentas en estado: " + dtEstadoBuscado.Rows[0]["cDescri"], "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.txtNroBusqueda.Clear();
                                nValBusqueda = 0;
                            }
                            else
                            {
                                if (lTasaBusqueda == true)
                                {
                                    var cEstadosTasa = "";
                                    clsCNSolicitud cnsolicitud = new clsCNSolicitud();
                                    DataTable dtEstadosTasa = cnsolicitud.CNObtenerEstadoTasaNegociable();
                                    foreach (DataRow fila in dtEstadosTasa.Rows)
                                    {
                                        cEstadosTasa = cEstadosTasa + fila["cEstado"].ToString() + ",";
                                    }
                                    MessageBox.Show("La solicitud de crédito del cliente no se encuentra dentro de los estados permitidos[" + cEstadosTasa + "]", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    MessageBox.Show("El cliente no tiene solicitudes en estado: " + dtEstadoBuscado.Rows[0]["cDescri"], "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                this.txtNroBusqueda.Clear();
                                nValBusqueda = 0;
                            }
                        }
                        cEvento = "E";
                    }
                    break;
            }
            return cEvento;
        }

        public void txtNroBusqueda_KeyPress(object sender, KeyPressEventArgs e)
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
                var fff = (from L in this.Text.ToString()
                           where L.ToString() == "."
                           select L).Count();

                if (fff > 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    if (e.KeyChar == 13)
                    {
                        Int32 nCifras = this.txtNroBusqueda.TextLength;

                        if (nCifras == 0)
                        {
                            MessageBox.Show("Valor de Búsqueda Incorrecto.", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtNroBusqueda.Focus();
                            return;
                        }

                        else
                        {
                            if (lTasaBusqueda == true || lTasaBusquedaPos == true)
                            {
                                if (EsNumerico(this.txtNroBusqueda.Text.Trim()))
                                {
                                    asignarCuenta(Convert.ToInt32(this.txtNroBusqueda.Text));
                                }
                                else
                                {
                                    MessageBox.Show("Valor de Búsqueda Incorrecto.", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                asignarCuenta(Convert.ToInt32(this.txtNroBusqueda.Text));
                            }
                        }
                    }

                    if (MyKey != null)
                    {
                        MyKey(sender, e);
                    }
                }
            }
        }
        static bool EsNumerico(string texto)
        {
            return texto.All(char.IsNumber);
        }

        public void consultar()
        {
            Int32 nCifras = this.txtNroBusqueda.TextLength;

            if (nCifras == 0)
            {
                MessageBox.Show("Valor de Búsqueda Incorrecto.", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNroBusqueda.Focus();
                return;
            }

            else
            {
                asignarCuenta(Convert.ToInt32(this.txtNroBusqueda.Text));
            }

            if (MyKey != null)
            {
                MyKey(null, null);
            }
        }

        private void grbBase1_Enter(object sender, EventArgs e)
        {

        }

        public void DepositoCli(int idcli, string cestado)
        {
            clsCNDeposito RetornaCuentaCliente = new clsCNDeposito();
            DataTable dtDatosCuentaCliente = RetornaCuentaCliente.CNConsultaDeposito(nIdCliente, cEstado);
            switch (dtDatosCuentaCliente.Rows.Count)
            {
                case 0:
                    MessageBox.Show("No se encontró Datos", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNroBusqueda.Clear();

                    break;
                case 1:
                    int nidValBusca = Convert.ToInt32(dtDatosCuentaCliente.Rows[0][0]);
                    this.txtNroBusqueda.Text = nidValBusca.ToString();

                    if (BloqueoDep(nidValBusca, RetornaCuentaCliente))
                    {
                        RetornaCuentaCliente.CNUpdUsoCuenta(nidValBusca, clsVarGlobal.User.idUsuario);
                        this.txtNroBusqueda.Text = dtDatosCuentaCliente.Rows[0]["idCuenta"].ToString();
                        this.txtCodCli.Text = dtDatosCuentaCliente.Rows[0]["cCodCliente"].ToString();
                        this.txtNroDoc.Text = dtDatosCuentaCliente.Rows[0]["cDocumentoID"].ToString();
                        this.txtNombreCli.Text = dtDatosCuentaCliente.Rows[0]["cNombre"].ToString();
                        this.txtEstado.Text = dtDatosCuentaCliente.Rows[0]["cEstado"].ToString();
                        this.idTipoDocumento = Convert.ToInt32(dtDatosCuentaCliente.Rows[0]["idTipoDocumento"].ToString());
                    }
                    else
                    {
                        this.txtNroBusqueda.Text = "0";
                    }
                    break;
                default:
                    FrmBuscaCuentaCliente frmBusCuenCli = new FrmBuscaCuentaCliente();
                    frmBusCuenCli.CargarDatos(nIdCliente, this.cTipoBusqueda, this.cEstado);
                    frmBusCuenCli.ShowDialog();
                    nValBusqueda = Convert.ToInt32(frmBusCuenCli.cIdCreSol);

                    if (BloqueoDep(nValBusqueda, RetornaCuentaCliente))
                    {
                        RetornaCuentaCliente.CNUpdUsoCuenta(nValBusqueda, clsVarGlobal.User.idUsuario);
                        this.txtNroBusqueda.Text = nValBusqueda.ToString();
                        this.txtCodCli.Text = dtDatosCuentaCliente.Rows[0]["cCodCliente"].ToString();
                        this.txtNroDoc.Text = dtDatosCuentaCliente.Rows[0]["cDocumentoID"].ToString();
                        this.txtNombreCli.Text = dtDatosCuentaCliente.Rows[0]["cNombre"].ToString();
                        this.txtEstado.Text = dtDatosCuentaCliente.Rows[0]["cEstado"].ToString();
                        this.idTipoDocumento = Convert.ToInt32(dtDatosCuentaCliente.Rows[0]["idTipoDocumento"].ToString());
                    }
                    else
                    {
                        this.txtNroBusqueda.Text = "0";
                    }
                    break;
            }
        }

        public void DepositoCta(int idcuenta, string cestado)
        {
            clsCNDeposito RetornaCuenta = new clsCNDeposito();
            DataTable dtDatosCuentaCliente = RetornaCuenta.CNConsultaDatosxidCuenta(idcuenta, cEstado);
            switch (dtDatosCuentaCliente.Rows.Count)
            {
                case 0:
                    MessageBox.Show("No se encontró Datos", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNroBusqueda.Clear();
                    break;
                default:
                    int nidValBusca = Convert.ToInt32(dtDatosCuentaCliente.Rows[0][0]);
                    this.txtNroBusqueda.Text = nidValBusca.ToString();

                    if (BloqueoDep(nidValBusca, RetornaCuenta))
                    {
                        RetornaCuenta.CNUpdUsoCuenta(nidValBusca, clsVarGlobal.User.idUsuario);
                        this.txtNroBusqueda.Text = dtDatosCuentaCliente.Rows[0]["idCuenta"].ToString();
                        this.txtCodCli.Text = dtDatosCuentaCliente.Rows[0]["cCodCliente"].ToString();
                        this.txtNroDoc.Text = dtDatosCuentaCliente.Rows[0]["cDocumentoID"].ToString();
                        this.txtNombreCli.Text = dtDatosCuentaCliente.Rows[0]["cNombre"].ToString();
                        this.txtEstado.Text = dtDatosCuentaCliente.Rows[0]["cEstado"].ToString();
                        this.idTipoDocumento = Convert.ToInt32(dtDatosCuentaCliente.Rows[0]["idTipoDocumento"].ToString());

                    }
                    else
                    {
                        this.txtNroBusqueda.Text = "0";
                    }
                    break;
            }
        }

        Boolean BloqueoDep(int idCuenta, clsCNDeposito RetornaCuentaCliente)
        {
            string cUserBloqueo = RetornaCuentaCliente.CNVerificaBloqueo(idCuenta);
            if (!string.IsNullOrEmpty(cUserBloqueo))
            {
                MessageBox.Show("Cuenta Bloqueada por usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNroBusqueda.Text = "";
                this.txtCodCli.Text = "";
                this.txtNroDoc.Text = "";
                this.txtNombreCli.Text = "";
                this.txtEstado.Text = "";
                return false;
            }
            else
            {
                return true;
            }
        }

        public void LiberarCuenta()
        {
            if (nValBusqueda > 0)
            {
                new clsCNRetornaNumCuenta().UpdEstCuenta(nValBusqueda, 0);
            }
        }

        public void limpiarControles()
        {
            txtCodAge.Clear();
            txtCodCli.Clear();
            txtCodIns.Clear();
            txtCodMod.Clear();
            txtCodMon.Clear();
            txtEstado.Clear();
            txtNombreCli.Clear();
            txtNroBusqueda.Clear();
            txtNroDoc.Clear();
            nValBusqueda = 0;
            nIdCliente = 0;
            nIdCuenta = 0;
            idTipoDocumento = 0;
            idAgenciaCred = 0;
            if (lResetBusqueda)
            {
                btnBusCliente1.Enabled = true;
                txtNroBusqueda.Enabled = true;
            }
        }

        private void txtNroBusqueda_Click(object sender, EventArgs e)
        {
            nValBusqueda = 0;
            txtNroBusqueda.MaxLength = 25;
        }

        public void asignarCuenta(int idCuenta)
        {
            nValBusqueda = idCuenta;

            switch (this.cTipoBusqueda)
            {
                case "D":
                    DepositoCta(nValBusqueda, this.cEstado);
                    break;
                default:

                    if (this.cTipoBusqueda == "C")
                    {
                        clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
                        DataTable dtDatosNumCuenta = RetornaNumCuenta.RetornaNumCuenta(nValBusqueda, cTipoBusqueda, cEstado);
                        if (dtDatosNumCuenta.Rows.Count == 0)
                        {
                            MessageBox.Show("No se encontró Número de Cuenta", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtNroBusqueda.Clear();
                            this.nValBusqueda = -1;
                            this.txtNroBusqueda.Focus();
                            nValBusqueda = 0;
                            nIdCliente = 0;
                        }
                        else
                        {
                            DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(nValBusqueda);
                            nidUserBloqueo = (Nullable<int>)dtEstCuenta.Rows[0][0];
                            if (nidUserBloqueo != 0)
                            {
                                DataTable dtUsu = new DataTable();
                                dtUsu = RetornaNumCuenta.BusUsuBlo((int)nidUserBloqueo);
                                cUserBloqueo = dtUsu.Rows[0][0].ToString();
                                MessageBox.Show("Cuenta Bloqueada por usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.txtCodIns.Text = "";
                                this.txtCodAge.Text = "";
                                this.txtCodMod.Text = "";
                                this.txtCodMon.Text = "";
                                this.txtNroBusqueda.Text = "";

                                this.txtCodCli.Text = "";
                                this.txtNombreCli.Text = "";
                                this.txtNroDoc.Text = "";
                                this.txtEstado.Text = "";
                                this.txtNroBusqueda.Focus();
                                nValBusqueda = 0;
                                nIdCliente = 0;
                            }
                            else
                            {
                                RetornaNumCuenta.UpdEstCuenta(nValBusqueda, clsVarGlobal.User.idUsuario);

                                this.txtCodIns.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                                this.txtCodAge.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                                this.txtCodMod.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(6, 2);
                                this.txtCodMon.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(8, 1);
                                this.txtNroBusqueda.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(9);

                                this.txtCodCli.Text = dtDatosNumCuenta.Rows[0]["cCodCliente"].ToString();
                                this.txtNroDoc.Text = dtDatosNumCuenta.Rows[0]["cDocumentoID"].ToString();
                                this.txtNombreCli.Text = dtDatosNumCuenta.Rows[0]["cNombre"].ToString();
                                this.txtEstado.Text = dtDatosNumCuenta.Rows[0][2].ToString();
                                this.idTipoDocumento = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idTipoDocumento"].ToString());

                                this.idAgenciaCred = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idAgenciaCred"]);

                                btnBusCliente1.Enabled = false;
                                txtNroBusqueda.Enabled = false;

                                nIdCliente = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["cCodCliente"].ToString().Substring(6, 7));

                                idSolicitudcre = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["idSolicitud"].ToString());
                            }
                        }
                    }
                    else
                    {
                        if (lTasaBusqueda == true)
                        {
                            clsCNSolicitud cnsolicitud = new clsCNSolicitud();
                            DataTable dtESolTasa = cnsolicitud.CNObtenerEstadoSolicitudTasaNegociable();
                            if (dtESolTasa.Rows.Count > 0)
                            {
                                cEstado = Convert.ToString(dtESolTasa.Rows[0]["cValVar"]);
                            }
                        }

                        clsCNRetornaNumSolicitud RetornaNumSolicitud = new clsCNRetornaNumSolicitud();
                        DataTable dtDatosNumSolicutd = RetornaNumSolicitud.CNRetornaNumSolicitud(nValBusqueda, cTipoBusqueda, cEstado);
                        if (dtDatosNumSolicutd.Rows.Count == 0)
                        {
                            DataTable dtDatosNumSolicitudApr = RetornaNumSolicitud.CNRetornaNumSolicitudApr(nValBusqueda, cTipoBusqueda, "[5]");

                            string cMensaje = "";
                            if (lTasaBusqueda == true)
                            {
                                if (dtDatosNumSolicitudApr.Rows.Count > 0)
                                {
                                    cMensaje = "Solicitud de crédito ya fue aprobada, no se podrá realizar nueva solicitud de tasa negociable.";
                                }
                                else
                                {
                                    var cEstadosTasa = "";
                                    clsCNSolicitud cnsolicitud = new clsCNSolicitud();
                                    DataTable dtEstadosTasa = cnsolicitud.CNObtenerEstadoTasaNegociable();
                                    int i = 1;
                                    foreach (DataRow fila in dtEstadosTasa.Rows)
                                    {
                                        if (i < dtEstadosTasa.Rows.Count)
                                        {
                                            cEstadosTasa = cEstadosTasa + fila["cEstado"].ToString() + ",";
                                        }
                                        else if(i == dtEstadosTasa.Rows.Count) 
                                        {
                                            cEstadosTasa = cEstadosTasa + fila["cEstado"].ToString();
                                        }
                                        i = i + 1;
                                    }
                                    cMensaje = "Solicitud de crédito del cliente no se encuentra dentro de los estados permitidos [" + cEstadosTasa + "]";
                                }
                            }
                            else 
                            { 
                                cMensaje = "No se encontró número de solicitud";                           
                            }

                            if(this.cTipoBusqueda=="F")
                                cMensaje = "No se encontró número de carta fianza";
                            MessageBox.Show(cMensaje, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtNroBusqueda.Clear();
                            this.nValBusqueda = -1;
                            this.txtNroBusqueda.Focus();
                            nValBusqueda = 0;
                        }
                        else
                        {
                            DataRow filaEstado;
                            filaEstado = dtDatosNumSolicutd.Rows[0];
                            string cEstadoSolicitud = Convert.ToString(filaEstado["cEstado"]);
                            //if (cEstadoSolicitud != "APROBADO")
                            //{
                            //    string cMensaje = "El estado de la solicitud es: " + cEstadoSolicitud +".";
                            //    MessageBox.Show(cMensaje, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //    this.txtNroBusqueda.Clear();
                            //    this.nValBusqueda = -1;
                            //    this.txtNroBusqueda.Focus();
                            //    nValBusqueda = 0;
                            //    return;
                            //}

                            this.txtNroBusqueda.Text = (this.cTipoBusqueda != "F") ? dtDatosNumSolicutd.Rows[0]["idSolicitud"].ToString() : dtDatosNumSolicutd.Rows[0]["idCartaFianza"].ToString();
                            this.txtCodCli.Text = dtDatosNumSolicutd.Rows[0]["cCodCliente"].ToString();
                            this.txtNroDoc.Text = dtDatosNumSolicutd.Rows[0]["cDocumentoID"].ToString();
                            this.txtNombreCli.Text = dtDatosNumSolicutd.Rows[0]["cNombre"].ToString();
                            this.txtEstado.Text = dtDatosNumSolicutd.Rows[0][1].ToString();
                            this.idTipoDocumento = Convert.ToInt32(dtDatosNumSolicutd.Rows[0]["idTipoDocumento"].ToString());
                            btnBusCliente1.Enabled = false;
                            txtNroBusqueda.Enabled = false;
                            nIdCliente = Convert.ToInt32(dtDatosNumSolicutd.Rows[0]["cCodCliente"].ToString().Substring(6, 7));
                            nOperacion = Convert.ToInt32(dtDatosNumSolicutd.Rows[0]["idOperacion"]);
                        }
                    }
                    //--Validar si Cli esta en la Base Negativa
                    if (!string.IsNullOrEmpty(this.txtNroDoc.Text))
                    {
                        if (ValidaCliBN.ValidaCliBaseNegativa(this.txtNroDoc.Text, clsVarGlobal.idModulo, clsVarGlobal.lBaseNegativa))
                        {
                            limpiarControles();
                            return;
                        }
                    }
                    break;
            }
        }

        private void ConBusCuentaCli_Load(object sender, EventArgs e)
        {
            if (this.cTipoBusqueda == "S")
            {
                this.lblNroBuscar.Text = "Código de Solicitud";
            }
            if (this.cTipoBusqueda == "C")
            {
                this.lblNroBuscar.Text = "Nro. de Préstamo";
            }
            if (this.cTipoBusqueda == "D")
            {
                this.lblNroBuscar.Text = "Nro. de Cuenta";
            }
            if (this.cTipoBusqueda == "F")
            {
                this.lblNroBuscar.Text = "Nro. de Carta Fianza";
            }
        }

        private void txtNroDoc_TextChanged(object sender, EventArgs e)
        {
            if (this.ChangeDocumentoID != null)
            {
                this.ChangeDocumentoID(sender, e);
            }

            AlertaCumpleaños(txtNroDoc.Text);
        }

        private void AlertaCumpleaños(string cDocumentoID)
        {
            clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();
            DataTable dtPerfilAlerta = cnExpCliente.PerfilesAlertaCumpleExpCliente(Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

            if (dtPerfilAlerta.Rows.Count == 0)
            {
                return;
            }

            if (Convert.ToBoolean(dtPerfilAlerta.Rows[0]["lVigente"]) == false)
            {
                return;
            }

            DataTable dtAlertaCumple = cnExpCliente.AlertaCumpleExpCliente(cDocumentoID);

            if (dtAlertaCumple.Rows.Count == 0)
            {
                return;
            }

            if (Convert.ToInt32(dtAlertaCumple.Rows[0]["nAlertas"]) < Convert.ToInt32(dtPerfilAlerta.Rows[0]["nAlertasProg"]))
            {
                if (Convert.ToString(dtAlertaCumple.Rows[0]["Alerta"]) == "SI")
                {
                    frmExperienciaClienteAlertaCumple frm = new frmExperienciaClienteAlertaCumple();
                    frm.cDocumentoID = Convert.ToString(dtAlertaCumple.Rows[0]["cDocumentoID"]);
                    frm.cNombreCliente = Convert.ToString(dtAlertaCumple.Rows[0]["Nombres"]);
                    frm.cFechaCumpleaños = Convert.ToString(dtAlertaCumple.Rows[0]["Dia"]);
                    frm.cSegmento = Convert.ToString(dtAlertaCumple.Rows[0]["Segmento"]);
                    frm.ShowDialog();
                }
            }

        }

        private void txtNroBusqueda_TextChanged(object sender, EventArgs e)
        {
            string textoActual = txtNroBusqueda.Text;
            string textoSinEspacios = textoActual.Replace(" ", "");

            if (textoActual != textoSinEspacios)
            {
                txtNroBusqueda.TextChanged -= txtNroBusqueda_TextChanged;
                txtNroBusqueda.Text = textoSinEspacios;
                txtNroBusqueda.TextChanged += txtNroBusqueda_TextChanged;
                txtNroBusqueda.SelectionStart = txtNroBusqueda.Text.Length;
            }
        }

        private void txtNroBusqueda_Leave(object sender, EventArgs e)
        {
            txtNroBusqueda.MaxLength = 9;
        }

    }
}
