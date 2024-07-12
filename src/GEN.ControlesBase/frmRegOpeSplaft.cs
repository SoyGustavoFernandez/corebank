using GEN.ControlesBase;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using CLI.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CLI.Presentacion;

namespace GEN.ControlesBase
{
    public partial class frmRegOpeSplaft : frmBase
    {
        #region Variables Globales

        EventoFormulario tAccion = EventoFormulario.INICIO;
        public int idKardex { get; set; }                                       //recibe el id de kardex
        public int idModulo { get; set; }                                       //recibe el id del modulo
        public int idTipoOperacion;
        public int idProducto;
        public int idTipoPago;
        bool estadoReimprimir;
        bool mboxTabF;                                                          //estadoTab* ayuda a saber si es la primera vez que se ingresa al tab
        bool mboxTabO;
        bool mboxTabB;
        clsPersonaSplaft personaF;                                              //persona* guarda informacion de la persona que esta actualmente en uso
        clsPersonaSplaft personaO;
        clsPersonaSplaft personaB;
        clsListaPersonaSplaft ListaPersonaF = new clsListaPersonaSplaft();      //persona* almacena una lista de personas por rol (fisica, ordenante, benediciaria)
        clsListaPersonaSplaft ListaPersonaO = new clsListaPersonaSplaft();
        clsListaPersonaSplaft ListaPersonaB = new clsListaPersonaSplaft();
        clsListaPersonaSplaft ListaPersonas = new clsListaPersonaSplaft();      //junta todas las personas que participan en la transaccion 
        clsCNBuscaKardex busKardex = new clsCNBuscaKardex();
        DataTable datosKardex = new DataTable();
        bool cargar = false;
        bool estadoNuevo;
        int nCodPeru = 173;
        int lOpcion=0;
        clsCNRegistroOperacion cnRegOpe = new clsCNRegistroOperacion();
        clsCNPersonaSplaft cnpersonasplaft = new clsCNPersonaSplaft();
        clsCNInusualSplaft cninusualsplaft = new clsCNInusualSplaft();
        clsCNDetalleInusual cndetalleinusual = new clsCNDetalleInusual();
        bool lSilencioso = false;
        frmSustentoArchivoSplaft frm = new frmSustentoArchivoSplaft();
        bool lGuardadoSustento = false;
        bool lPersonaFisicaTitular = false;
        bool lPersonaOrdenanteTitular = false;
        bool lPersonaJuridica = false;

        #endregion

        /// <summary>
        /// USADO PARA MODO LECTURA Y EDICION DEL REGISTRO DE OPERACION
        /// </summary>     
        public frmRegOpeSplaft()
        {
            InitializeComponent();
            mboxTabF = false;
            mboxTabO = false;
            mboxTabB = false;
            estadoReimprimir = true;
            estadoNuevo = true;
            cargar = true;
            lOpcion = 0;
        }

        /// <summary>
        /// SE ACTIVA CUANDO A LA CLASE SE LE PASA UN KARDEX Y UN MODULO PARA HACER EL REGISTRO DE OPERACION
        /// </summary>
        /// <param name="kardex"></param>
        /// <param name="modulo"></param>
        public frmRegOpeSplaft(int kardex, int modulo)
        {
            InitializeComponent();
            estadoReimprimir = false;
            lOpcion = 1;
            btnGrabarGen.Enabled = true;
            clsSeguimSilencioSPLAFT seguimientosilencioso = new clsSeguimSilencioSPLAFT(kardex);
            validarUmbral(kardex, modulo);
        }

        #region Eventos

        private void frmRegistroOperaciones_Load(object sender, EventArgs e)
        {
            if (!cargar)
            {
                this.Dispose();
            }
            if (!estadoReimprimir)
            {
                if (lSilencioso)
                {
                    busKardex.CNRegistroSilenciosoSplaft(idKardex);
                    this.Dispose();
                }
                else
                {
                    datosKardex = busKardex.busquedaKardex(idKardex);
                    cargarDatosKardex();
                    InicializarTabFisica();
                    //cargarPersonaBeneficiariaOpe(idTipoOperacion, idKardex, idModulo);    // Conflicto con carga manual P. Benef
                    btnSalir1.Enabled = false;
                    clsCNInusualSplaft inusual = new clsCNInusualSplaft();
                    DataTable dt = inusual.listarInusual();
                    cboGrupoInusual.DataSource = dt;
                    cboGrupoInusual.ValueMember = dt.Columns[0].ToString();
                    cboGrupoInusual.DisplayMember = dt.Columns[1].ToString();

                    frm = new frmSustentoArchivoSplaft(idKardex);
                    btnBlanco1.Visible = frm.obtenerMostrarBoton();
                    CargarDatosOrigenDestinoFondos();
                }

            }
            else
            {
                controlesModoLectura();
                CargarDatosOrigenDestinoFondos();

                clsCNInusualSplaft inusual = new clsCNInusualSplaft();
                DataTable dt = inusual.listarInusual();
                cboGrupoInusual.DataSource = dt;
                cboGrupoInusual.ValueMember = dt.Columns[0].ToString();
                cboGrupoInusual.DisplayMember = dt.Columns[1].ToString();

                conBusPersonSplaft1.habilitarControles(false);
                conBusPersonSplaft2.habilitarControles(false);
                conBusPersonSplaft3.habilitarControles(false);
                if (lOpcion==1)
                {
                    btnGrabarGen.Enabled = true;
                }
            }
            conBusPersonSplaft1.rbtnPjuridica.Visible = false;
        }

        //-------------------------------------------BOTONES BUSCAR CLIENTE---------------------------------------------------------
        private void btnBusCliente1_Click(object sender, EventArgs e)
        {
            FrmBusCli cliente = new FrmBusCli();
            cliente.ShowDialog();
            string cadena = cliente.pcCodCli;

            if (!String.IsNullOrEmpty( cadena))
            {
                foreach (var item in ListaPersonaF)
                {
                    if (item.nCodCli==Convert.ToInt32(cadena))
                    {
                        MessageBox.Show("Este cliente ya existe en la lista de personas presentes físicamente");
                        return;
                    }
                }
                clsPersonaSplaft pe = new clsPersonaSplaft();
                pe = cnpersonasplaft.buscarPersonaSplaft(Convert.ToInt32(cliente.pcCodCli));
                pe.nTipoPersona = convertirTipoP(pe);

                if (pe.nTipoPersona == 3)
                {
                    MessageBox.Show("No se puede elegir a una persona jurídica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.conBusPersonSplaft1.limpiarControles();
                    this.conBusPersonSplaft1.EsCliente = true;
                    pe.nTipoRelacion = 1;
                    this.conBusPersonSplaft1.cargar(pe);
                    this.conBusPersonSplaft1.conBusUB.cargarUbigeo(pe.NIdUbigeo);
                    this.btnBusClientePerFis.Enabled = true;
                    this.btnAgregarPerFis.Enabled = true;
                    this.btnEditarPerFis.Enabled = false;
                    this.btnNuevoPerFis.Enabled = true;
                    conBusPersonSplaft1.conNegocio(true);
                }
            }
        }

        private void btnBusCliente2_Click(object sender, EventArgs e)
        {
            FrmBusCli cliente = new FrmBusCli();
            cliente.ShowDialog();
            string cadena = cliente.pcCodCli;

            if (!String.IsNullOrEmpty(cadena))
            {
                foreach (var item in ListaPersonaO)
                {
                    if (item.nCodCli == Convert.ToInt32(cadena))
                    {
                        MessageBox.Show("Este cliente ya existe en la lista de personas ordenantes");
                        return;
                    }
                }

                clsPersonaSplaft pe = new clsPersonaSplaft();
                pe = cnpersonasplaft.buscarPersonaSplaft(Convert.ToInt32(cliente.pcCodCli));
                this.conBusPersonSplaft2.limpiarControles();
                this.conBusPersonSplaft2.EsCliente = true;
                this.conBusPersonSplaft2.RolCliente = 2;
                pe.nTipoRelacion = 1;
                pe.nTipoPersona = convertirTipoP(pe);

                this.conBusPersonSplaft2.cargar(pe);
                this.conBusPersonSplaft2.conBusUB.cargarUbigeo(pe.NIdUbigeo);
                this.btnBusClientePerOrd.Enabled = true;
                this.btnAgregarPerOrd.Enabled = true;
                this.btnEditarPerOrd.Enabled = false;
                conBusPersonSplaft2.conNegocio(true);
                this.conBusPersonSplaft2.Enabled = true;
            }
        }

        private void btnBusCliente3_Click(object sender, EventArgs e)
        {
            FrmBusCli cliente = new FrmBusCli();
            cliente.ShowDialog();
            string cadena = cliente.pcCodCli;

            if (!String.IsNullOrEmpty(cadena))
            {
                foreach (var item in ListaPersonaB)
                {
                    if (item.nCodCli == Convert.ToInt32(cadena))
                    {
                        MessageBox.Show("Este cliente ya existe en la lista de personas beneficiarias");
                        return;
                    }
                }

                clsPersonaSplaft pe = new clsPersonaSplaft();
                pe = cnpersonasplaft.buscarPersonaSplaft(Convert.ToInt32(cliente.pcCodCli));
                this.conBusPersonSplaft3.limpiarControles();
                this.conBusPersonSplaft3.EsCliente = true;
                this.conBusPersonSplaft3.RolCliente = 3;
                pe.nTipoRelacion = 1;
                pe.nTipoPersona = convertirTipoP(pe);

                this.conBusPersonSplaft3.cargar(pe);
                this.conBusPersonSplaft3.conBusUB.cargarUbigeo(pe.NIdUbigeo);
                this.btnBusClientePerBen.Enabled = false;
                this.btnAgregarPerBen.Enabled = true;
                this.btnEditarPerBen.Enabled = false;
                conBusPersonSplaft3.conNegocio(true);
                this.conBusPersonSplaft3.Enabled = true;
            }
        }

        //-------------------------------------------BOTONES AGREGAR---------------------------------------------------------------
        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (conBusPersonSplaft1.validar())
            {
                clsPersonaSplaft pers = new clsPersonaSplaft();
                pers = conBusPersonSplaft1.obtenerPersona();
                pers.bPresencia = true;
                pers.idLista = dtgPFisica.RowCount;
                conBusPersonSplaft1.idT = dtgPFisica.RowCount;
                ListaPersonaF.Add(pers);

                this.dtgPFisica.DataSource = null;
                this.dtgPFisica.DataSource = ListaPersonaF;
                columnas_visible(dtgPFisica);
                this.dtgPFisica.Refresh();
                this.btnAgregarPerFis.Enabled = false;
                this.btnBusClientePerFis.Enabled = true;
                this.btnEditarPerFis.Enabled = true;
                this.conBusPersonSplaft1.habilitarControles(false);
                this.btnNuevoPerFis.Enabled = true;

                btnEliminarFis.Enabled = true;
                lPersonaFisicaTitular = false;
            }
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            if (conBusPersonSplaft2.validar())
            {
                clsPersonaSplaft pers = new clsPersonaSplaft();
                pers = conBusPersonSplaft2.obtenerPersona();
                pers.bPresencia = true;
                pers.idLista = dtgPOrdenante.RowCount;
                conBusPersonSplaft2.idT = dtgPOrdenante.RowCount;
                ListaPersonaO.Add(pers);

                this.dtgPOrdenante.DataSource = null;
                this.dtgPOrdenante.DataSource = ListaPersonaO;
                columnas_visible(dtgPOrdenante);
                this.dtgPOrdenante.Refresh();

                this.btnAgregarPerOrd.Enabled = false;
                this.btnBusClientePerOrd.Enabled = true;
                this.btnEditarPerOrd.Enabled = true;
                this.conBusPersonSplaft2.habilitarControles(false);
                btnNuevoPerOrd.Enabled = true;

                btnEliminarOrd.Enabled = true;
                lPersonaOrdenanteTitular = false;
            }
        }

        private void btnAgregar3_Click(object sender, EventArgs e)
        {
            if (conBusPersonSplaft3.validar(true))
            {
                clsPersonaSplaft pers = new clsPersonaSplaft();
                pers = conBusPersonSplaft3.obtenerPersona();
                pers.bPresencia = true;
                pers.idLista = dtgPBeneficiaria.RowCount;
                conBusPersonSplaft3.idT = dtgPBeneficiaria.RowCount;
                ListaPersonaB.Add(pers);
                this.dtgPBeneficiaria.DataSource = null;
                this.dtgPBeneficiaria.DataSource = ListaPersonaB;
                columnas_visible(dtgPBeneficiaria);
                this.dtgPBeneficiaria.Refresh();
                this.btnAgregarPerBen.Enabled = false;
                this.btnBusClientePerBen.Enabled = true;
                this.btnEditarPerBen.Enabled = true;
                this.conBusPersonSplaft3.habilitarControles(false);
                this.btnNuevoPerBen.Enabled = true;
                btnEliminarBen.Enabled = true;
            }
        }

        //-------------------------------------------BOTONES NUEVO---------------------------------------------------------------
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            conBusPersonSplaft1.limpiarControles();
            conBusPersonSplaft1.EsCliente = false;
            conBusPersonSplaft1.conNegocio(true);
            conBusPersonSplaft1.Enabled = true;
            btnBusClientePerFis.Enabled = true;
            btnAgregarPerFis.Enabled = true;
            btnEditarPerFis.Enabled = false;
            cotrolesBotonesPerFis(Transaccion.Nuevo);
            conBusPersonSplaft1.conBusUB.cboPais.SelectedValue = nCodPeru;
        }

        private void btnNuevo2_Click(object sender, EventArgs e)
        {
            var rpta=MessageBox.Show("¿El nuevo registro es un cliente de la empresa?", "Registro de Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.Yes)
            {
                conBusPersonSplaft2.limpiarControles();
                conBusPersonSplaft2.conNegocio(true);
                btnBusClientePerOrd.Enabled = true;
                btnAgregarPerOrd.Enabled = true;
                btnEditarPerOrd.Enabled = false;
                btnBusClientePerOrd.PerformClick();
                btnCancelarOrd.Enabled = true;
                conBusPersonSplaft2.EsCliente = true;
            }
            else
            {

                conBusPersonSplaft2.limpiarControles();
                conBusPersonSplaft2.EsCliente = false;
                conBusPersonSplaft2.conNegocio(true);
                conBusPersonSplaft2.Enabled = true;
                btnBusClientePerOrd.Enabled = true;
                btnAgregarPerOrd.Enabled = true;
                btnEditarPerOrd.Enabled = false;
                btnCancelarOrd.Enabled = true;

                cotrolesBotonesPerOrd(Transaccion.Nuevo);
            }
        }

        private void btnNuevo3_Click(object sender, EventArgs e)
        {
            var rpta=MessageBox.Show("¿El nuevo registro es un cliente de la empresa?", "Registro de Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.Yes)
            {
                conBusPersonSplaft3.limpiarControles();
                conBusPersonSplaft3.conNegocio(true);
                conBusPersonSplaft3.habilitarControles(true);
                btnBusClientePerBen.Enabled = true;
                btnAgregarPerBen.Enabled = true;
                btnEditarPerBen.Enabled = false;
                btnBusClientePerBen.PerformClick();
                btnCancelarBen.Enabled = true;
                conBusPersonSplaft3.EsCliente = true;
            }
            else
            {
                conBusPersonSplaft3.limpiarControles();
                conBusPersonSplaft3.EsCliente = false;
                conBusPersonSplaft3.Enabled = true;
                conBusPersonSplaft3.conNegocio(true);
                btnBusClientePerBen.Enabled = true;
                btnAgregarPerBen.Enabled = true;
                btnEditarPerBen.Enabled = false;
                btnCancelarBen.Enabled = true;
                cotrolesBotonesPerBen(Transaccion.Nuevo);
            }
        }

        //-------------------------------------------BOTONES GRABAR CAMBIOS--------------------------------------------------------
        private void btnGrabar2_Click(object sender, EventArgs e)
        {
            if (estadoReimprimir)
            {
                if (conBusPersonSplaft1.validar())
                {
                    clsListaPersonaSplaft tempo = new clsListaPersonaSplaft();
                    tempo.Add(conBusPersonSplaft1.obtenerPersonaModificada());
                    clsCNPersonaSplaft pe = new clsCNPersonaSplaft();
                    pe.actualizarPersonaSPL(tempo, idKardex);
                    this.btnGrabarPerFis.Visible = false;
                    this.btnEditarPerFis.Visible = true;
                    this.btnEditarPerFis.Location = this.btnGrabarPerFis.Location;
                    conBusPersonSplaft1.habilitarControles(false);
                }
            }
            else
            {
                if (conBusPersonSplaft1.validar())
                {
                    GrabarDatosPersonaFisica();
                }
            }
        }

        private void GrabarDatosPersonaFisica()
        {
            clsPersonaSplaft pers = new clsPersonaSplaft();
            pers = conBusPersonSplaft1.obtenerPersona();
            pers.bPresencia = true;

            ListaPersonaF[ObtenerIndiceLista(ListaPersonaF, pers.nCodCli)] = pers;
            this.dtgPFisica.DataSource = null;
            this.dtgPFisica.DataSource = ListaPersonaF;
            columnas_visible(dtgPFisica);
            this.dtgPFisica.Refresh();
            this.btnNuevoPerFis.Enabled = true;
            this.btnGrabarPerFis.Visible = false;
            this.btnEditarPerFis.Visible = true;
            this.btnEditarPerFis.Location = this.btnGrabarPerFis.Location;
            this.conBusPersonSplaft1.habilitarControles(false);
        }

        private int ObtenerIndiceLista(clsListaPersonaSplaft lLista, int idCli)
        {
            int nIndice = 0;
            foreach (clsPersonaSplaft item in lLista)
            {
                if (item.nCodCli == idCli)
                {
                    nIndice = lLista.IndexOf(item);
                }
            }
            return nIndice;
        }

        private void btnGrabar3_Click_1(object sender, EventArgs e)
        {
            if (estadoReimprimir)
            {
                if (conBusPersonSplaft2.validar())
                {
                    clsListaPersonaSplaft tempo = new clsListaPersonaSplaft();
                    tempo.Add(conBusPersonSplaft2.obtenerPersonaModificada());
                    clsCNPersonaSplaft pe = new clsCNPersonaSplaft();
                    pe.actualizarPersonaSPL(tempo, idKardex);
                    this.btnGrabarPerOrd.Visible = false;
                    this.btnEditarPerOrd.Visible = true;
                    this.btnEditarPerOrd.Location = this.btnGrabarPerOrd.Location;
                    conBusPersonSplaft2.habilitarControles(false);
                }
            }
            else
            {
                if (conBusPersonSplaft2.validar())
                {
                    GrabarDatosPersonaOrdenante();
                }
            }
        }

        private void GrabarDatosPersonaOrdenante()
        {
            clsPersonaSplaft pers = new clsPersonaSplaft();
            pers = conBusPersonSplaft2.obtenerPersona();
            pers.bPresencia = true;
            ListaPersonaO[ObtenerIndiceLista(ListaPersonaO, pers.nCodCli)] = pers;
            this.dtgPOrdenante.DataSource = null;
            this.dtgPOrdenante.DataSource = ListaPersonaO;
            columnas_visible(dtgPOrdenante);
            this.dtgPOrdenante.Refresh();
            this.btnNuevoPerOrd.Enabled = true;
            this.btnGrabarPerOrd.Visible = false;
            this.btnEditarPerOrd.Visible = true;
            this.btnEditarPerOrd.Location = this.btnGrabarPerOrd.Location;
            this.conBusPersonSplaft2.habilitarControles(false);
        }

        private void btnGrabar4_Click_1(object sender, EventArgs e)
        {
            if (estadoReimprimir)
            {
                if (conBusPersonSplaft3.validar(true))
                {
                    clsListaPersonaSplaft tempo = new clsListaPersonaSplaft();
                    tempo.Add(conBusPersonSplaft3.obtenerPersonaModificada());
                    clsCNPersonaSplaft pe = new clsCNPersonaSplaft();
                    pe.actualizarPersonaSPL(tempo, idKardex);
                    this.btnGrabarPerBen.Visible = false;
                    this.btnEditarPerBen.Visible = true;
                    this.btnEditarPerBen.Location = this.btnGrabarPerFis.Location;
                    conBusPersonSplaft3.habilitarControles(false);
                }
            }
            else
            {
                if (conBusPersonSplaft3.validar(true))
                {
                    clsPersonaSplaft pers = new clsPersonaSplaft();
                    pers = conBusPersonSplaft3.obtenerPersona();
                    pers.bPresencia = true;
                    ListaPersonaB[ObtenerIndiceLista(ListaPersonaB, pers.nCodCli)] = pers;
                    this.dtgPBeneficiaria.DataSource = null;
                    this.dtgPBeneficiaria.DataSource = ListaPersonaB;
                    columnas_visible(dtgPBeneficiaria);
                    this.dtgPBeneficiaria.Refresh();
                    this.btnNuevoPerBen.Enabled = true;
                    this.btnGrabarPerBen.Visible = false;
                    this.btnEditarPerBen.Visible = true;
                    this.btnEditarPerBen.Location = this.btnGrabarPerFis.Location;
                    this.conBusPersonSplaft3.habilitarControles(false);
                }
            }
        }

        //-------------------------------------------BOTON EDITAR-------------------------------------------------------------------
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            this.conBusPersonSplaft1.activarEspeciales(true);
            conBusPersonSplaft1.conNegocio(true);
            this.btnEditarPerFis.Visible = false;
            this.btnGrabarPerFis.Visible = true;
            this.btnGrabarPerFis.Enabled = true;
            cotrolesBotonesPerFis(Transaccion.Edita);
        }

        private void btnEditar2_Click_1(object sender, EventArgs e)
        {
            this.btnGrabarPerOrd.Location = this.btnEditarPerOrd.Location;
            this.conBusPersonSplaft2.activarEspeciales(true);
            this.btnEditarPerOrd.Visible = false;
            this.btnGrabarPerOrd.Visible = true;
            cotrolesBotonesPerOrd(Transaccion.Edita);
        }

        private void btnEditar3_Click_1(object sender, EventArgs e)
        {
            this.btnGrabarPerBen.Location = this.btnEditarPerBen.Location;
            this.conBusPersonSplaft3.activarEspeciales(true);
            this.btnEditarPerBen.Visible = false;
            this.btnGrabarPerBen.Visible = true;
            cotrolesBotonesPerBen(Transaccion.Edita);
        }

        //-------------------------------------------BOTON GRABAR TOTAL-------------------------------------------------------------
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (frm.obtenerMostrarBoton())
            {
                if (!this.lGuardadoSustento)
                {
                    MessageBox.Show("No se ha registrado el sustento de la operación", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbcRegOpe.SelectedIndex = 3;
                    btnBlanco1.Focus();
                    return;
                }
            }
            if (validarTexto())
            {
                return;
            }
            if (estadoReimprimir)
            {
                clsRegistroOperacion regTempo = new clsRegistroOperacion();
                regTempo.cdescripcion = txtDescripcionOperacion.Text;
                regTempo.corigen = txtOrigen.Text == "" ? cboOrigenFondos.Text : cboOrigenFondos.Text + " " + txtOrigen.Text;
                regTempo.cdestino = txtDestino.Text == "" ? cboDestinoFondos.Text : cboDestinoFondos.Text + " " + txtDestino.Text;
                if (rbtInusualY.Checked)
                {
                    regTempo.idInusual = cboGrupoInusual.SelectedIndex + 1;
                    regTempo.idDetalleInusual = lstDetalleInusual.SelectedIndex + 1;
                }
                else
                {
                    regTempo.idInusual = 0;
                    regTempo.idDetalleInusual = 0;
                }
                regTempo.nidKardex = idKardex;

                cnRegOpe.ActualizarRegOpe(regTempo);

                MessageBox.Show("El Registro de Operacion se ha actualizado correctamente", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);

                controlesModoLectura();

            }
            else
            {
                clsRegistroOperacion registro = new clsRegistroOperacion();

                registro.nidKardex = idKardex;
                registro.dfechaOperacion = Convert.ToDateTime(txtFechaO.Text).Date;
                registro.dhoraOperacion = Convert.ToDateTime(datosKardex.Rows[0]["dFecHoraOpe"]);
                registro.ncodEmpresa = Convert.ToInt32(clsVarApl.dicVarGen["cCodInstFin"]);
                registro.cdescripcion = txtDescripcionOperacion.Text;
                registro.nidModalidad = 1;
                registro.nidDetalleRO = 2;
                registro.corigen = txtOrigen.Text == "" ? cboOrigenFondos.Text : cboOrigenFondos.Text + " " + txtOrigen.Text;
                registro.cdestino = txtDestino.Text == "" ? cboDestinoFondos.Text : cboDestinoFondos.Text + " " + txtDestino.Text;
                registro.dMontoOperacion=Convert.ToDecimal(datosKardex.Rows[0]["nMontoOperacion"]);
                registro.nCuenta = Convert.ToInt32(datosKardex.Rows[0]["idCuenta"]);
                registro.nModulo=idModulo;
                registro.nCodMoneda = Convert.ToInt32(datosKardex.Rows[0]["idMoneda"]);
                registro.idTipoOperacion = (datosKardex.Rows[0]["idTipoOperacion"] == DBNull.Value) ? 0 : Convert.ToInt32(datosKardex.Rows[0]["idTipoOperacion"]);
                registro.idTipoPago = (datosKardex.Rows[0]["idTipoPago"] == DBNull.Value) ? 0 : Convert.ToInt32(datosKardex.Rows[0]["idTipoPago"]);
                registro.idSplaftDetOrdenPago = Convert.ToInt32(cboDetalleOrdenPago1.SelectedValue);
                registro.cSplaftDetOrdenPago = (Convert.ToInt32(cboDetalleOrdenPago1.SelectedValue) == 6) ? txtCBOtrosDescOrdPag.Text : cboDetalleOrdenPago1.Text;

                if (rbtInusualY.Checked)
                {
                    registro.idInusual = cboGrupoInusual.SelectedIndex + 1;
                    registro.idDetalleInusual = lstDetalleInusual.SelectedIndex + 1;
                }
                else
                {
                    registro.idInusual = 0;
                    registro.idDetalleInusual = 0;
                }

                foreach (var item in ListaPersonaF)
                {
                    if (item.bPresencia)
                    {
                        item.nTipoRol = 1;
                        ListaPersonas.Add(item);
                    }
                }


                foreach (var item in ListaPersonaO)
                {
                    if (item.bPresencia)
                    {
                        item.nTipoRol = 2;
                        ListaPersonas.Add(item);
                    }
                }


                foreach (var item in ListaPersonaB)
                {
                    if (item.bPresencia)
                    {
                        item.nTipoRol = 3;
                        ListaPersonas.Add(item);
                    }
                }

                registro.detalle = ListaPersonas;
                clsCNRegistroOperacion regope = new clsCNRegistroOperacion();
                regope.insertarRegOpeDetalle(registro);

                MessageBox.Show("Se han guardado los datos correctamente. \n A continuación por favor imprima el registro de operaciones", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);

                controlesModoLectura();

                btnImprimir1.Enabled = true;
                btnrReImprimir.Enabled = false;
                btnSalir1.Enabled = false;
            }
        }

        //-------------------------------------------CUANDO ENTRAS AL TAB ------------------------------------------------------
        private void tabPage5_Enter(object sender, EventArgs e)
        {
            if (btnGrabarPerOrd.Visible)
            {
                MessageBox.Show("Aun no ha guardado los cambios en Persona Operante", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 1;
            }
            else if (btnGrabarPerBen.Visible)
            {
                MessageBox.Show("Aun no ha guardado los cambios en Persona Beneficiaria", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 2;
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            if (!validarPersona(conBusPersonSplaft1, ListaPersonaF, "física", 1))
            {
                MessageBox.Show("Aun no ha aceptado los cambios en Persona Física", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 0;
            }
            else if (btnGrabarPerFis.Visible)
            {
                MessageBox.Show("Aun no ha aceptado los cambios en Persona Física", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 0;
            }
            else if (btnAgregarPerFis.Enabled)
            {
                MessageBox.Show("Aun se esta agregando una persona física", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 0;
            }
            else
            {
                InicializarTabOrdenante();
                conBusPersonSplaft2.Focus();
            }
        }

        private bool validarPersona(conBusPersonSplaft conBus, List<clsPersonaSplaft> listaPersona, string cTipRolPersona, int nRolCli)
        {
            bool lResultado = true;
            if (!conBus.validarListaPersonas(listaPersona, cTipRolPersona, nRolCli))
            {
                lResultado = false;
            }
            return lResultado;
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            if (btnAgregarPerOrd.Enabled)
            {
                MessageBox.Show("Aun se esta agregando a una persona ordenante", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 1;
            }
            else if (btnGrabarPerOrd.Visible)
            {
                MessageBox.Show("Aun no ha aceptado los cambios en Persona Ordenante", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 1;
            }
            else if (!validarPersona(conBusPersonSplaft2, ListaPersonaO, "ordenante", 2))
            {
                MessageBox.Show("Aun no ha guardado los cambios en Persona Ordenante", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 1;
            }
            else if (!validarPersona(conBusPersonSplaft1, ListaPersonaF, "física", 1))
            {
                MessageBox.Show("Aun no ha guardado los cambios en Persona Física", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 0;
            }
            else
            {
                if (estadoReimprimir || conBusPersonSplaft2.validar())
                {
                    InicializarTabBeneficiario();
                    this.conBusPersonSplaft3.Focus();
                }
                else
                {
                    tbcRegOpe.SelectedIndex = 1;
                    this.btnGrabarPerOrd.Location = this.btnEditarPerOrd.Location;
                    this.conBusPersonSplaft2.activarEspeciales(true);
                    this.btnEditarPerOrd.Visible = false;
                    this.btnGrabarPerOrd.Visible = true;
                    cotrolesBotonesPerOrd(Transaccion.Edita);
                }

            }
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            if (btnAgregarPerBen.Enabled)
            {
                MessageBox.Show("Aun se esta agregando a una persona beneficiaria", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 2;
            }
            else if (btnGrabarPerBen.Visible || !validarPersona(conBusPersonSplaft3, ListaPersonaB, "beneficiaria", 3))
            {
                MessageBox.Show("Aun no ha guardado los cambios en Persona Beneficiaria", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 2;
            }
            else if (!validarPersona(conBusPersonSplaft2, ListaPersonaO, "ordenante", 2))
            {
                MessageBox.Show("Aun no ha guardado los cambios en Persona Operante", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 1;
            }
            else if (!validarPersona(conBusPersonSplaft1, ListaPersonaF, "física", 1))
            {
                MessageBox.Show("Aun no ha guardado los cambios en Persona Física", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcRegOpe.SelectedIndex = 0;
            }
            else
            {

                if (estadoReimprimir || conBusPersonSplaft3.validar())
                {
                    txtOrigen.Focus();

                    frm = new frmSustentoArchivoSplaft(idKardex);
                    btnBlanco1.Visible = frm.obtenerMostrarBoton();

                    if (estadoReimprimir)
                    {
                        cboGrupoInusual.Enabled = false;
                        lstDetalleInusual.Enabled = false;
                    }
                }
                else
                {
                    tbcRegOpe.SelectedIndex = 2;
                    this.btnGrabarPerBen.Location = this.btnEditarPerBen.Location;
                    this.conBusPersonSplaft3.activarEspeciales(true);
                    this.btnEditarPerBen.Visible = false;
                    this.btnGrabarPerBen.Visible = true;
                    cotrolesBotonesPerBen(Transaccion.Edita);
                }

            }
        }

        #region PARA EL ULTIMO TAB

        private void cboGrupoInusual_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsCNDetalleInusual detalleInusual = new clsCNDetalleInusual();
            DataTable dt = detalleInusual.listarDetalleInusual(cboGrupoInusual.SelectedIndex + 1);
            lstDetalleInusual.DataSource = dt;
            lstDetalleInusual.ValueMember = dt.Columns[0].ToString();
            lstDetalleInusual.DisplayMember = dt.Columns[1].ToString();
        }

        private void rbtInusualY_CheckedChanged(object sender, EventArgs e)
        {
            grbInusual.Enabled = true;
            lstDetalleInusual.Enabled = true;
            cboGrupoInusual.Enabled = true;
        }

        private void rbtnInusualN_CheckedChanged(object sender, EventArgs e)
        {
            grbInusual.Enabled = false;
        }

        private void btnEliminarBen_Click(object sender, EventArgs e)
        {
            if (dtgPBeneficiaria.RowCount == 0)
            {
                MessageBox.Show("No hay personas beneficiarias para eliminar de la tabla", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dgRes = MessageBox.Show("Desea Eliminar a: " + dtgPBeneficiaria.Rows[dtgPBeneficiaria.SelectedRows[0].Index].Cells[0].Value.ToString(), "Registro de Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgRes == DialogResult.Yes)
            {
                ListaPersonaB.RemoveAt(dtgPBeneficiaria.SelectedRows[0].Index);
                this.dtgPBeneficiaria.DataSource = null;
                this.dtgPBeneficiaria.DataSource = ListaPersonaB;
                columnas_visible(dtgPBeneficiaria);
                this.dtgPBeneficiaria.Refresh();
                conBusPersonSplaft3.limpiarControles();
                cotrolesBotonesPerBen(Transaccion.Elimina);

                if (dtgPBeneficiaria.RowCount > 0)
                {
                    dtgPBeneficiaria.FirstDisplayedScrollingRowIndex = 0;
                    dtgPBeneficiaria.Rows[0].Selected = true;
                    dtgPBeneficiaria.CurrentCell = dtgPBeneficiaria.Rows[0].Cells[0];
                    cargarRowaFormulario(ref conBusPersonSplaft3, ref personaB, ref dtgPBeneficiaria, ref btnGrabarPerBen, 1, 0);
                }
            }

        }

        private void btnEliminarFis_Click(object sender, EventArgs e)
        {
            if (dtgPFisica.RowCount == 0)
            {
                MessageBox.Show("No hay personas físicas para eliminar de la tabla", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dgRes = MessageBox.Show("Desea Eliminar a: " + dtgPFisica.Rows[dtgPFisica.SelectedRows[0].Index].Cells[0].Value.ToString(), "Registro de Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgRes == DialogResult.Yes)
            {
                ListaPersonaF.RemoveAt(dtgPFisica.SelectedRows[0].Index);
                this.dtgPFisica.DataSource = null;
                this.dtgPFisica.DataSource = ListaPersonaF;
                columnas_visible(dtgPFisica);
                this.dtgPFisica.Refresh();
                conBusPersonSplaft1.limpiarControles();
                cotrolesBotonesPerFis(Transaccion.Elimina);
                lPersonaFisicaTitular = false;

                if (dtgPFisica.RowCount > 0)
                {
                    dtgPFisica.FirstDisplayedScrollingRowIndex = 0;
                    dtgPFisica.Rows[0].Selected = true;
                    dtgPFisica.CurrentCell = dtgPFisica.Rows[0].Cells[0];
                    cargarRowaFormulario(ref conBusPersonSplaft1, ref personaF, ref dtgPFisica, ref btnGrabarPerFis, 1, 0);
                }
            }
        }

        private void btnEliminarOrd_Click(object sender, EventArgs e)
        {
            if (dtgPOrdenante.RowCount == 0)
            {
                MessageBox.Show("No hay personas ordenantes para eliminar de la tabla", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dgRes = MessageBox.Show("Desea Eliminar a: " + dtgPOrdenante.Rows[dtgPOrdenante.SelectedRows[0].Index].Cells[0].Value.ToString(), "Registro de Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgRes == DialogResult.Yes)
            {
                ListaPersonaO.RemoveAt(dtgPOrdenante.SelectedRows[0].Index);
                conBusPersonSplaft2.limpiarControles();
                this.dtgPOrdenante.DataSource = null;
                this.dtgPOrdenante.DataSource = ListaPersonaO;
                columnas_visible(dtgPOrdenante);
                this.dtgPOrdenante.Refresh();
                cotrolesBotonesPerOrd(Transaccion.Elimina);
                lPersonaOrdenanteTitular = false;

                if (dtgPOrdenante.RowCount > 0)
                {
                    dtgPOrdenante.FirstDisplayedScrollingRowIndex = 0;
                    dtgPOrdenante.Rows[0].Selected = true;
                    dtgPOrdenante.CurrentCell = dtgPOrdenante.Rows[0].Cells[0];
                    cargarRowaFormulario(ref conBusPersonSplaft2, ref personaO, ref dtgPOrdenante, ref btnGrabarPerOrd, 1, 0);
                }

            }
        }

        #endregion

        /// <summary>
        /// BOTON REIMPRIMIR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnrReImprimir_Click(object sender, EventArgs e)
        {
            tAccion = EventoFormulario.IMPRIMIR;

            estadoNuevo = false;
            estadoReimprimir = true;
            txtIdKardex.Enabled = true;
            txtIdKardex.Focus();
            btnEditarGen.Enabled = false;
            btnNuevoGen.Enabled = false;
            btnrReImprimir.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabarGen.Enabled = false;

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            List<ReportParameter> listPar = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dtsRegOpe", new clsCNRegistroOperacion().DevolverRegOpeDataTable(idKardex)));
            dtslist.Add(new ReportDataSource("dtsListarPersonaSPL", new clsCNPersonaSplaft().DevolverPersonaDT(idKardex)));
            dtslist.Add(new ReportDataSource("dtsAgencia", new clsRPTCNAgencia().CNAgenciaUsuario(clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario)));

            string reportpath = "rptSplaftCliente.rdlc";
            listPar.Add(new ReportParameter("nNumAgencia", clsVarGlobal.nIdAgencia.ToString()));
            listPar.Add(new ReportParameter("nNumUsuario", clsVarGlobal.User.idUsuario.ToString()));
            listPar.Add(new ReportParameter("nIdKardex", Convert.ToString(idKardex)));
            listPar.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString()));

            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, listPar);
            frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmreporte.ShowDialog();

            this.btnSalir1.Enabled = true;
        }

        private void txtIdKardex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (estadoReimprimir)
                {
                    reimprimir();
                }

                if (estadoNuevo)
                {
                    if (String.IsNullOrEmpty(txtIdKardex.Text))
                    {
                        MessageBox.Show("Ingrese un Nro. de Kardex", "Titulo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    idKardex = Convert.ToInt32(txtIdKardex.Text);
                    clsCNRegistroOperacion reTempo = new clsCNRegistroOperacion();
                    if (reTempo.ExisteRegistro(idKardex))
                    {
                        MessageBox.Show("El Registro de operación con el Nro. Kardex ingresado ya existe", "Titulo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtIdKardex.Text = "";
                        txtIdKardex.Enabled = false;
                        btnSalir1.Enabled = true;
                        btnNuevoGen.Enabled = true;
                        btnEditarGen.Enabled = true;
                        btnrReImprimir.Enabled = true;
                        btnImprimir1.Enabled = false;
                        btnCancelar1.Enabled = false;
                        btnGrabarGen.Enabled = false;
                        return;
                    }
                    else
                    {
                        datosKardex = busKardex.busquedaKardex(idKardex);
                        if (datosKardex.Rows.Count > 0)
                        {
                            idTipoOperacion = Convert.ToInt32(datosKardex.Rows[0]["idTipoOperacion"]);
                            idModulo = Convert.ToInt32(datosKardex.Rows[0]["idModulo"]);
                            idProducto = Convert.ToInt32(datosKardex.Rows[0]["idProducto"]);
                        }
                        else
                        {
                            MessageBox.Show("No existen registros con el Id Kardex ingresado", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtIdKardex.Text = "";
                            txtIdKardex.Enabled = false;
                            btnSalir1.Enabled = true;
                            btnNuevoGen.Enabled = true;
                            btnEditarGen.Enabled = true;
                            btnrReImprimir.Enabled = true;
                            btnImprimir1.Enabled = false;
                            btnCancelar1.Enabled = false;
                            btnGrabarGen.Enabled = false;
                            return;
                        }

                        validarUmbral(idKardex, idModulo);

                        if (!cargar)
                        {
                            MessageBox.Show("El registro no cumple con los requerimientos del Registro de Operaciones", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtIdKardex.Text = "";
                            txtIdKardex.Enabled = false;
                            btnSalir1.Enabled = true;
                            btnNuevoGen.Enabled = true;
                            btnEditarGen.Enabled = true;
                            btnrReImprimir.Enabled = true;
                            btnImprimir1.Enabled = false;
                            btnCancelar1.Enabled = false;
                            return;
                        }
                        else
                        {
                            mboxTabF = false;
                            mboxTabO = false;
                            mboxTabB = false;

                            lPersonaFisicaTitular = false;
                            lPersonaOrdenanteTitular = false;
                            lPersonaJuridica = false;
                            cboOrigenFondos.Enabled = true;
                            cboDestinoFondos.Enabled = true;
                            cboOrigenFondos.SelectedIndex = 22;
                            cboDestinoFondos.SelectedIndex = 11;

                            rbtInusualY.Enabled = true;
                            rbtnInusualN.Enabled = true;
                            txtDescripcionOperacion.Enabled = true;
                            lstDetalleInusual.Enabled = true;
                            cboGrupoInusual.Enabled = true;
                            cargarDatosKardex();
                            tbcRegOpe.SelectedIndex = 0;
                            InicializarTabFisica();
                            cargarPersonaBeneficiariaOpe(idTipoOperacion, idKardex, idModulo);
                            btnSalir1.Enabled = true;
                            txtIdKardex.Enabled = false;
                        }
                    }
                }

            }
        }

        private void btnNuevo4_Click(object sender, EventArgs e)
        {
            tAccion = EventoFormulario.NUEVO;
            estadoNuevo = true;
            estadoReimprimir = false;
            txtIdKardex.Enabled = true;
            txtIdKardex.Focus();
            estadoNuevo = true;
            estadoReimprimir = false;
            btnNuevoGen.Enabled = false;
            btnSalir1.Enabled = true;
            btnrReImprimir.Enabled = false;
            btnEditarGen.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabarGen.Enabled = true;
        }

        private void btnEditar4_Click(object sender, EventArgs e)
        {
            tAccion = EventoFormulario.EDITAR;
            estadoNuevo = false;
            estadoReimprimir = true;

            txtIdKardex.Enabled = true;
            txtIdKardex.Focus();
            btnNuevoGen.Enabled = false;
            btnrReImprimir.Enabled = false;

            cboOrigenFondos.Enabled = true;
            cboDestinoFondos.Enabled = true;

            txtOrigen.Enabled = true;
            txtDestino.Enabled = true;

            txtDescripcionOperacion.Enabled = true;

            if (rbtInusualY.Checked)
            {
                cboGrupoInusual.Enabled = true;
                lstDetalleInusual.Enabled = true;
            }
            else
            {
                rbtInusualY.Enabled = true;
                rbtnInusualN.Enabled = true;
            }
            btnGrabarGen.Enabled = true;
            btnEditarGen.Enabled = false;
            btnCancelar1.Enabled = true;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            tAccion = EventoFormulario.CANCELAR;
            txtIdKardex.Enabled = false;
            txtIdKardex.Clear();
            btnNuevoGen.Enabled = true;
            btnrReImprimir.Enabled = true;
            btnEditarGen.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabarGen.Enabled = false;
            btnImprimir1.Enabled = false;
            tbcRegOpe.SelectedIndex = 0;
            cboDetalleOrdenPago1.SelectedIndex = -1;
            txtCBOtrosDescOrdPag.Clear();
            panel1.Visible = false;
            this.lGuardadoSustento = false;
            asignarEstadoInicial();
        }

        private void dtgPFisica_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            cargarRowaFormulario(ref conBusPersonSplaft1, ref personaF, ref dtgPFisica, ref btnGrabarPerFis, e.ColumnIndex, 1);
        }

        private void dtgPOrdenante_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            cargarRowaFormulario(ref conBusPersonSplaft2, ref personaO, ref dtgPOrdenante, ref btnGrabarPerOrd, e.ColumnIndex, 2);
        }

        private void dtgPBeneficiaria_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            cargarRowaFormulario(ref conBusPersonSplaft3, ref personaB, ref dtgPBeneficiaria, ref btnGrabarPerBen, e.ColumnIndex, 3);
        }

        private void btnCancelarBen_Click(object sender, EventArgs e)
        {
            conBusPersonSplaft3.limpiarControles();
            conBusPersonSplaft3.conNegocio(true);
            cotrolesBotonesPerBen(Transaccion.Selecciona);
        }

        private void btnCancelarOrd_Click(object sender, EventArgs e)
        {
            conBusPersonSplaft2.limpiarControles();
            conBusPersonSplaft2.conNegocio(true);
            cotrolesBotonesPerOrd(Transaccion.Selecciona);
        }

        private void btnCancelarFis_Click(object sender, EventArgs e)
        {
            conBusPersonSplaft1.EsCliente = false;
            conBusPersonSplaft1.limpiarControles();
            conBusPersonSplaft1.conNegocio(true);
            cotrolesBotonesPerFis(Transaccion.Selecciona);
        }

        #endregion

        #region Métodos

        private bool validarTexto()
        {
            if (tAccion == EventoFormulario.NUEVO || tAccion == EventoFormulario.EDITAR || tAccion == EventoFormulario.INICIO)
            {
                if (dtgPFisica.RowCount < 1)
                {
                    MessageBox.Show("Debe registrar al menos 1 persona física", "Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtgPFisica.Focus();
                    return true;
                }

                if (btnAgregarPerFis.Enabled)
                {
                    MessageBox.Show("Aún se esta agregando a una persona física", "Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbcRegOpe.SelectedIndex = 0;
                    return true;
                }

                if (dtgPOrdenante.RowCount < 1)
                {
                    MessageBox.Show("Debe registrar al menos 1 persona ordenante", "Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtgPOrdenante.Focus();
                    return true;
                }

                if (btnAgregarPerOrd.Enabled)
                {
                    MessageBox.Show("Aún se esta agregando a una persona ordenante", "Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbcRegOpe.SelectedIndex = 1;
                    return true;
                }

                if (dtgPBeneficiaria.RowCount < 1)
                {
                    MessageBox.Show("Debe registrar al menos 1 persona beneficiaria", "Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtgPBeneficiaria.Focus();
                    return true;
                }

                if (btnAgregarPerBen.Enabled)
                {
                    MessageBox.Show("Aún se esta agregando a una persona beneficiaria", "Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbcRegOpe.SelectedIndex = 2;
                    return true;
                }


                if (cboOrigenFondos.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe seleccionar el origen dentro de los DATOS DE OPERACIÓN", "Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }

                if (cboOrigenFondos.SelectedIndex == 0 && txtOrigen.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe ingresar el detalle de origen dentro de los DATOS DE OPERACIÓN", "Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOrigen.Focus();
                    return true;
                }

                if (cboDestinoFondos.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe seleccionar el destino dentro de los DATOS DE OPERACIÓN", "Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }

                if (cboDestinoFondos.SelectedIndex == 11 && txtDestino.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe ingresar el detalle de destino dentro de los DATOS DE OPERACIÓN", "Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDestino.Focus();
                    return true;
                }

                if (txtDescripcionOperacion.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe ingresar la observación dentro de los DATOS DE OPERACIÓN", "Splaft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescripcionOperacion.Focus();
                    return true;
                }
                return false;
            }
            return true;
        }

        private void asignarEstadoInicial()
        {
            conBusPersonSplaft1.limpiarControles();
            conBusPersonSplaft2.limpiarControles();
            conBusPersonSplaft3.limpiarControles();
            dtgPFisica.DataSource = null;
            dtgPBeneficiaria.DataSource = null;
            dtgPOrdenante.DataSource = null;
            txtCuenta.Clear();
            txtOperacion.Clear();
            txtMonto.Clear();
            txtFechaO.Clear();
            txtOrigen.Clear();
            txtDestino.Clear();
            txtDescripcionOperacion.Clear();

            conBusPersonSplaft1.habilitarControles(false);
            conBusPersonSplaft2.habilitarControles(false);
            conBusPersonSplaft3.habilitarControles(false);

            rbtnInusualN.Checked = true;
            rbtInusualY.Checked = false;

            ListaPersonaO.Clear();
            ListaPersonaB.Clear();
            ListaPersonaF.Clear();
            ListaPersonas.Clear();

            btnGrabarPerFis.Visible = false;
            btnGrabarPerBen.Visible = false;
            btnGrabarPerOrd.Visible = false;
            mboxTabO = true;
            mboxTabB = true;
            mboxTabF = true;

            btnAgregarPerFis.Visible = false;
            btnBusClientePerFis.Visible = false;
            btnGrabarPerFis.Visible = false;
            btnEditarPerFis.Visible = false;

            btnAgregarPerBen.Visible = false;
            btnBusClientePerBen.Visible = false;
            btnGrabarPerBen.Visible = false;
            btnEditarPerBen.Visible = false;

            btnAgregarPerOrd.Visible = false;
            btnBusClientePerOrd.Visible = false;
            btnGrabarPerOrd.Visible = false;
            btnEditarPerOrd.Visible = false;

            txtOrigen.Enabled = false;
            txtDestino.Enabled = false;
            txtDescripcionOperacion.Enabled = false;
            rbtInusualY.Enabled = false;
            rbtnInusualN.Enabled = false;

            cboOrigenFondos.SelectedItem = null;
            cboDestinoFondos.SelectedItem = null;
            cboDestinoFondos.Enabled = false;
            cboOrigenFondos.Enabled = false;
        }

        private void validarUmbral(int kardex, int modulo)
        {
            datosKardex = busKardex.busquedaKardex(kardex);
            decimal val = Convert.ToDecimal(datosKardex.Rows[0]["nMontoOperacion"]);
            int moneda = Convert.ToInt32(datosKardex.Rows[0]["idMoneda"]);
            idTipoPago = Convert.ToInt32(datosKardex.Rows[0]["idTipoPago"]);

            //OBTENIENDO EL TIPO DE CAMBIO SPLAFT
            clsCNTipoCambioSPL tipoC = new clsCNTipoCambioSPL();
            DataTable dsTipoC = tipoC.ListarTipoCambio(1);

            if (dsTipoC.Rows.Count <= 0)
            {
                MessageBox.Show("No se encontró tipo de cambio para el SPLAFT", "Tipo cambio SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cargar = false;
                return;
            }

            decimal tiC = Convert.ToDecimal(dsTipoC.Rows[0]["nValor"]);
            idTipoOperacion = Convert.ToInt32(datosKardex.Rows[0]["idTipoOperacion"]);

            //OBTENIENDO EL UMBRAL PARA OPERACIONES UNICAS SPLAFT
            clsCNUmbralSPL umbral = new clsCNUmbralSPL();
            DataTable dsUmbral = umbral.CNListarUmbralKardex(1, kardex);

            if (dsUmbral.Rows.Count == 0)
            {
                MessageBox.Show("No se configuro los umbrales para las operaciones únicas para la agencia: " + clsVarGlobal.cNomAge.ToString(), "Umbral", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cargar = false;
                return;
            }
            decimal umb = Convert.ToDecimal(dsUmbral.Rows[0]["nValor"]);
            lSilencioso = Convert.ToBoolean(dsUmbral.Rows[0]["lSilencioso"]);
            //VALIDANDO SI EL MONTO AL TIPO DE CAMBIO SPLAFT HA SUPERADO EL UMBRAL
            if (moneda == 1)
            {
                if ((val / tiC) >= umb)
                {
                    idKardex = kardex;
                    idModulo = Convert.ToInt32(datosKardex.Rows[0]["idModulo"]);
                    mboxTabF = false;
                    mboxTabO = false;
                    mboxTabB = false;
                    cargar = true;
                    if (!this.Visible)
                    {
                        this.ShowDialog();
                    }

                }
                else
                {
                    cargar = false;
                }
            }
            else
            {
                if (val >= umb)
                {
                    idKardex = kardex;
                    idModulo = Convert.ToInt32(datosKardex.Rows[0]["idModulo"]);
                    mboxTabF = false;
                    mboxTabO = false;
                    mboxTabB = false;
                    cargar = true;
                    if (!this.Visible)
                    {
                        this.ShowDialog();
                    }
                }
                else
                {
                    cargar = false;
                }
            }
        }

        /// <summary>
        /// HABILITA EL MODO DE LECTURA O EDICION
        /// </summary>
        public void controlesModoLectura()
        {
            //DESACTIVANDO LOS CONTROLES DE LOS CONBUSPERSONSPLAFT
            conBusPersonSplaft1.habilitarControles(false);
            conBusPersonSplaft2.habilitarControles(false);
            conBusPersonSplaft3.habilitarControles(false);

            txtIdKardex.Enabled = false;

            btnEditarPerFis.Visible = false;
            btnEditarPerOrd.Visible = false;
            btnEditarPerBen.Visible = false;

            btnAgregarPerFis.Visible = false;
            btnAgregarPerOrd.Visible = false;
            btnAgregarPerBen.Visible = false;

            btnBusClientePerFis.Visible = false;
            btnBusClientePerOrd.Visible = false;
            btnBusClientePerBen.Visible = false;

            btnNuevoPerFis.Visible = false;
            btnNuevoPerOrd.Visible = false;
            btnNuevoPerBen.Visible = false;

            btnGrabarGen.Enabled = false;
            btnGrabarPerFis.Enabled = false;
            btnGrabarPerFis.Visible = false;
            btnGrabarPerOrd.Enabled = false;
            btnGrabarPerOrd.Visible = false;
            btnGrabarPerBen.Enabled = false;
            btnGrabarPerBen.Visible = false;
            btnImprimir1.Enabled = false;
            btnEditarPerFis.Enabled = false;
            btnEditarPerOrd.Enabled = false;
            btnEditarPerBen.Enabled = false;
            btnAgregarPerFis.Enabled = false;
            btnAgregarPerOrd.Enabled = false;
            btnAgregarPerBen.Enabled = false;
            btnNuevoPerFis.Enabled = false;
            btnNuevoPerOrd.Enabled = false;
            btnNuevoPerBen.Enabled = false;

            //DESACTIVANDO LOS MENSAJES DE TEXTO AL INICIO DE CADA TABPANE
            mboxTabF = true;
            mboxTabO = true;
            mboxTabB = true;

            //ACTIVANDO LOS DATAGRIDVIEW
            dtgPFisica.Enabled = true;
            dtgPOrdenante.Enabled = true;
            dtgPBeneficiaria.Enabled = true;

            //DESABILITANDO LOS CAMPOS QUE SERAN DE SOLO LECTURA
            txtMonto.Enabled = false;
            txtFechaO.Enabled = false;
            txtOperacion.Enabled = false;
            txtCuenta.Enabled = false;
            txtDestino.Enabled = false;
            txtOperacion.Enabled = false;
            txtDescripcionOperacion.Enabled = false;
            txtOrigen.Enabled = false;
            rbtInusualY.Enabled = false;
            rbtnInusualN.Enabled = false;
            cboGrupoInusual.Enabled = false;
            lstDetalleInusual.Enabled = false;
            btnrReImprimir.Enabled = true;

            cboGrupoInusual.Enabled = false;
            lstDetalleInusual.Enabled = false;

            btnEliminarOrd.Enabled = false;
            btnEliminarFis.Enabled = false;
            btnEliminarBen.Enabled = false;

            btnCancelarOrd.Enabled = false;

            cboDestinoFondos.Enabled = false;
            cboOrigenFondos.Enabled = false;
        }

        #region Control de Botones

        private void cotrolesBotonesPerFis(Transaccion trans)
        {
            switch (trans)
            {
                case Transaccion.Selecciona:
                    btnEliminarFis.Enabled = true;
                    btnCancelarFis.Enabled = false;
                    btnEditarPerFis.Enabled = true;
                    btnEditarPerFis.Visible = true;
                    btnGrabarPerFis.Enabled = false;
                    btnGrabarPerFis.Visible = false;
                    btnBusClientePerFis.Enabled = true;
                    btnNuevoPerFis.Enabled = true;
                    btnAgregarPerFis.Enabled = false;
                    break;
                case Transaccion.Nuevo:
                    btnEliminarFis.Enabled = false;
                    btnCancelarFis.Enabled = true;
                    btnEditarPerFis.Enabled = false;
                    btnGrabarPerFis.Enabled = false;
                    btnBusClientePerFis.Enabled = false;
                    btnNuevoPerFis.Enabled = false;
                    btnAgregarPerFis.Enabled = true;
                    break;
                case Transaccion.Edita:
                    btnEliminarFis.Enabled = false;
                    btnCancelarFis.Enabled = true;
                    btnEditarPerFis.Enabled = false;
                    btnGrabarPerFis.Enabled = true;
                    btnBusClientePerFis.Enabled = true;
                    btnNuevoPerFis.Enabled = true;
                    btnAgregarPerFis.Enabled = false;
                    btnEditarPerFis.Visible = false;
                    btnGrabarPerFis.Visible = true;
                    btnGrabarPerFis.Location = btnEditarPerFis.Location;
                    break;
                case Transaccion.Elimina:
                    btnEliminarFis.Enabled = true;
                    btnCancelarFis.Enabled = false;
                    btnEditarPerFis.Enabled = false;
                    btnGrabarPerFis.Enabled = false;
                    btnBusClientePerFis.Enabled = true;
                    btnNuevoPerFis.Enabled = true;
                    btnAgregarPerFis.Enabled = false;
                    btnGrabarPerFis.Visible = false;
                    btnEditarPerFis.Location = btnGrabarPerFis.Location;
                    break;
            }
        }

        private void cotrolesBotonesPerOrd(Transaccion trans)
        {
            switch (trans)
            {
                case Transaccion.Selecciona:
                    btnEliminarOrd.Enabled = true;
                    btnCancelarOrd.Enabled = false;
                    btnEditarPerOrd.Enabled = true;
                    btnEditarPerOrd.Visible = true;
                    btnGrabarPerOrd.Enabled = false;
                    btnGrabarPerOrd.Visible = false;
                    btnBusClientePerOrd.Enabled = true;
                    btnNuevoPerOrd.Enabled = true;
                    btnAgregarPerOrd.Enabled = false;
                    break;
                case Transaccion.Nuevo:
                    btnEliminarOrd.Enabled = false;
                    btnCancelarOrd.Enabled = true;
                    btnEditarPerOrd.Enabled = false;
                    btnGrabarPerOrd.Enabled = false;
                    btnBusClientePerOrd.Enabled = false;
                    btnNuevoPerOrd.Enabled = false;
                    btnAgregarPerOrd.Enabled = true;
                    break;
                case Transaccion.Edita:
                    btnEliminarOrd.Enabled = false;
                    btnCancelarOrd.Enabled = true;
                    btnEditarPerOrd.Enabled = false;
                    btnGrabarPerOrd.Enabled = true;
                    btnBusClientePerOrd.Enabled = true;
                    btnNuevoPerOrd.Enabled = true;
                    btnAgregarPerOrd.Enabled = false;
                    btnEditarPerOrd.Visible = false;
                    btnGrabarPerOrd.Visible = true;
                    btnGrabarPerOrd.Location = btnEditarPerOrd.Location;
                    break;
                case Transaccion.Elimina:
                    btnEliminarOrd.Enabled = true;
                    btnCancelarOrd.Enabled = false;
                    btnEditarPerOrd.Enabled = false;
                    btnGrabarPerOrd.Enabled = false;
                    btnBusClientePerOrd.Enabled = true;
                    btnNuevoPerOrd.Enabled = true;
                    btnAgregarPerOrd.Enabled = false;
                    btnGrabarPerOrd.Visible = false;
                    btnEditarPerOrd.Location = btnGrabarPerOrd.Location;
                    break;
            }
        }

        private void cotrolesBotonesPerBen(Transaccion trans)
        {
            switch (trans)
            {
                case Transaccion.Selecciona:
                    btnEliminarBen.Enabled = true;
                    btnCancelarBen.Enabled = false;
                    btnEditarPerBen.Enabled = true;
                    btnGrabarPerBen.Visible = false;
                    btnEditarPerBen.Visible = true;
                    btnGrabarPerBen.Enabled = false;
                    btnBusClientePerBen.Enabled = true;
                    btnNuevoPerBen.Enabled = true;
                    btnAgregarPerBen.Enabled = false;
                    break;
                case Transaccion.Nuevo:
                    btnEliminarBen.Enabled = false;
                    btnCancelarBen.Enabled = true;
                    btnEditarPerBen.Enabled = false;
                    btnGrabarPerBen.Enabled = false;
                    btnBusClientePerBen.Enabled = false;
                    btnNuevoPerBen.Enabled = false;
                    btnAgregarPerBen.Enabled = true;
                    break;
                case Transaccion.Edita:
                    btnEliminarBen.Enabled = false;
                    btnCancelarBen.Enabled = true;
                    btnEditarPerBen.Enabled = false;
                    btnGrabarPerBen.Enabled = true;
                    btnBusClientePerBen.Enabled = true;
                    btnNuevoPerBen.Enabled = true;
                    btnAgregarPerBen.Enabled = false;
                    btnEditarPerBen.Visible = false;
                    btnGrabarPerBen.Visible = true;
                    btnGrabarPerBen.Location = btnEditarPerBen.Location;
                    break;
                case Transaccion.Elimina:
                    btnEliminarBen.Enabled = true;
                    btnCancelarBen.Enabled = false;
                    btnEditarPerBen.Enabled = false;
                    btnGrabarPerBen.Enabled = false;
                    btnBusClientePerBen.Enabled = true;
                    btnNuevoPerBen.Enabled = true;
                    btnAgregarPerBen.Enabled = false;
                    btnGrabarPerBen.Visible = false;
                    btnEditarPerBen.Location = btnGrabarPerBen.Location;
                    break;
            }
        }
        #endregion
        private void botones_Nuevo()
        {
            btnGrabarPerFis.Enabled = true;
            btnGrabarPerOrd.Enabled = true;

            btnEditarPerFis.Visible = true;
            btnEditarPerOrd.Visible = true;
            btnEditarPerBen.Visible = true;

            btnAgregarPerFis.Visible = true;
            btnAgregarPerOrd.Visible = true;
            btnAgregarPerBen.Visible = true;

            btnBusClientePerFis.Visible = true;
            btnBusClientePerOrd.Visible = true;
            btnBusClientePerBen.Visible = true;

            btnNuevoPerFis.Visible = true;
            btnNuevoPerOrd.Visible = true;
            btnNuevoPerBen.Visible = true;
        }

        /// <summary>
        /// PERMITE OCULTAR COLUMNAS PARA MOSTRAR LOS DATOS DE UNA PERSONA NATURAL O JURIDICA
        /// </summary>
        /// <param name="gr">RECIBE EL GRID AL CUAL SE LE HARAN VISIBLES LAS FILAS</param>
        private void columnas_visible(dtgBase gr)
        {
            if (gr.ColumnCount > 0)
            {
                for (int i = 0; i < gr.ColumnCount; i++)
                {
                    gr.Columns[i].Visible = false;
                }
                gr.Columns[0].Visible = true;
                gr.Columns[22].Visible = true;
                gr.Columns[33].Visible = true;
                gr.Columns[0].HeaderText = "Nombres/Razón Social";
                gr.Columns[22].HeaderText = "Dirección";
                gr.Columns[33].HeaderText = "Presente";
            }
        }

        /// <summary>
        /// CARGA LOS DATOS DEL INDEX EN LA CABECERA DE LA APLICACION
        /// </summary>
        public void cargarDatosKardex()
        {
            txtIdKardex.Text = datosKardex.Rows[0]["IdKardex"].ToString();
            txtFechaO.Text = datosKardex.Rows[0]["dFechaOpe"].ToString();
            txtOperacion.Text = datosKardex.Rows[0]["cTipoOperacion"].ToString();
            txtMonto.Text = datosKardex.Rows[0]["nMontoOperacion"].ToString();
            txtCuenta.Text = datosKardex.Rows[0]["idCuenta"].ToString();
            cboMoneda1.SelectedValue = (int)datosKardex.Rows[0]["idMoneda"];
            this.lGuardadoSustento = (bool)datosKardex.Rows[0]["lTieneSustento"];

            if (Convert.ToInt32(datosKardex.Rows[0]["idTipoOperacion"]).In(9, 10, 11, 12) && Convert.ToInt32(datosKardex.Rows[0]["idTipoPago"]).In(5))
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void reimprimir()
        {
            var objDatRegOpe = cnRegOpe.DevolverRegOpe(Convert.ToInt32(txtIdKardex.Text));
            if (objDatRegOpe == null)
            {
                MessageBox.Show("No existen registros con el Nro. de Kardex ingresado", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtIdKardex.Text = "";
                txtIdKardex.Enabled = false;
                btnSalir1.Enabled = true;

                btnNuevoGen.Enabled = true;
                btnEditarGen.Enabled = true;
                btnrReImprimir.Enabled = true;
                btnImprimir1.Enabled = false;
                btnCancelar1.Enabled = false;
                btnGrabarGen.Enabled = false;
                return;
            }

            conBusPersonSplaft1.conBusUB.cargar();
            conBusPersonSplaft2.conBusUB.cargar();
            conBusPersonSplaft3.conBusUB.cargar();

            btnEditarPerFis.Enabled = true;
            btnEditarPerOrd.Enabled = true;
            btnEditarPerBen.Enabled = true;

            if (tAccion == EventoFormulario.IMPRIMIR)
            {
                btnImprimir1.Enabled = true;
            }


            DataTable dt = cninusualsplaft.listarInusual();
            cboGrupoInusual.DataSource = dt;
            cboGrupoInusual.ValueMember = dt.Columns[0].ToString();
            cboGrupoInusual.DisplayMember = dt.Columns[1].ToString();


            DataTable dt2 = cndetalleinusual.listarDetalleInusual(cboGrupoInusual.SelectedIndex + 1);
            lstDetalleInusual.DataSource = dt2;
            lstDetalleInusual.ValueMember = dt2.Columns[0].ToString();
            lstDetalleInusual.DisplayMember = dt2.Columns[1].ToString();

            clsListaPersonaSplaft temporal = new clsListaPersonaSplaft();
            clsListaPersonaSplaft temporalF = new clsListaPersonaSplaft();
            clsListaPersonaSplaft temporalO = new clsListaPersonaSplaft();
            clsListaPersonaSplaft temporalB = new clsListaPersonaSplaft();

            int idlistaF = -1;
            int idlistaB = -1;
            int idlistaO = -1;
            idKardex = Convert.ToInt32(txtIdKardex.Text);
            temporal = cnpersonasplaft.DevolverPersona(idKardex);

            try
            {
                foreach (var item in temporal)
                {
                    item.bPresencia = true;

                    if (item.nTipoRol == 1)
                    {
                        idlistaF += 1;
                        item.idLista = idlistaF;
                        temporalF.Add(item);
                    }
                    if (item.nTipoRol == 2)
                    {
                        idlistaO += 1;
                        item.idLista = idlistaO;
                        temporalO.Add(item);
                    }
                    if (item.nTipoRol == 3)
                    {
                        idlistaB += 1;
                        item.idLista = idlistaB;
                        temporalB.Add(item);
                    }
                }

                ListaPersonaF = temporalF;
                ListaPersonaB = temporalB;
                ListaPersonaO = temporalO;

                dtgPFisica.DataSource = temporalF;
                dtgPOrdenante.DataSource = temporalO;
                dtgPBeneficiaria.DataSource = temporalB;

                dtgPFisica.Enabled = false;
                dtgPOrdenante.Enabled = false;
                dtgPBeneficiaria.Enabled = false;

                columnas_visible(dtgPFisica);
                columnas_visible(dtgPOrdenante);
                columnas_visible(dtgPBeneficiaria);

                datosKardex = busKardex.busquedaKardex(idKardex);
                cargarDatosKardex();

                string strOrigen = objDatRegOpe.corigen;
                string strDestino = objDatRegOpe.cdestino;

                string strOrigen0 = strOrigen.Substring(0, strOrigen.IndexOf(":") + 1).Length == 0 ? strOrigen.Substring(0, strOrigen.IndexOf(".") + 1) : strOrigen.Substring(0, strOrigen.IndexOf(":") + 1);
                string strOrigen1 = strOrigen.Substring(0, strOrigen.IndexOf(":") + 1).Length == 0 ? "" : strOrigen.Substring(strOrigen.LastIndexOf(":") + 2);

                string strDestino0 = strDestino.Substring(0, strDestino.IndexOf(":") + 1).Length == 0 ? strDestino.Substring(0, strDestino.IndexOf(".") + 1) : strDestino.Substring(0, strDestino.IndexOf(":") + 1);
                string strDestino1 = strDestino.Substring(0, strDestino.IndexOf(":") + 1).Length == 0 ? "" : strDestino.Substring(strDestino.LastIndexOf(":") + 2);

                cboOrigenFondos.SelectedIndex = cboOrigenFondos.FindStringExact(strOrigen0);
                cboDestinoFondos.SelectedIndex = cboDestinoFondos.FindStringExact(strDestino0);

                if (cboDestinoFondos.Text.Trim().Length <= 0)
                    txtOrigen.Text = objDatRegOpe.corigen;
                else
                    txtOrigen.Text = strOrigen1;

                if (cboDestinoFondos.Text.Trim().Length <= 0)
                    txtDestino.Text = objDatRegOpe.cdestino;
                else
                    txtDestino.Text = strDestino1;

                if (tAccion != EventoFormulario.IMPRIMIR)
                {
                    HabilitaDetalleOrigen();
                    HabilitaDetalleDestino();
                }
                else
                {
                    txtOrigen.Enabled = false;
                    txtDestino.Enabled = false;
                }

                txtDescripcionOperacion.Text = objDatRegOpe.cdescripcion;

                cboGrupoInusual.Enabled = false;
                lstDetalleInusual.Enabled = false;
                rbtInusualY.Enabled = false;
                rbtnInusualN.Enabled = false;

                if (objDatRegOpe.idInusual == 0)
                {
                    rbtnInusualN.Checked = true;
                }
                else
                {
                    cboGrupoInusual.SelectedIndex = Convert.ToInt32(objDatRegOpe.idInusual) - 1;
                    lstDetalleInusual.SelectedIndex = Convert.ToInt32(objDatRegOpe.idDetalleInusual) - 1;
                    rbtInusualY.Checked = true;
                }

                if (objDatRegOpe.idTipoOperacion.In(9, 10, 11, 12) && objDatRegOpe.idTipoPago.In(5))
                {
                    panel1.Visible = true;
                    cboDetalleOrdenPago1.SelectedValue = objDatRegOpe.idSplaftDetOrdenPago;
                    if (Convert.ToInt32(cboDetalleOrdenPago1.SelectedValue) == 6)
                    {
                        txtCBOtrosDescOrdPag.Text = objDatRegOpe.cSplaftDetOrdenPago;
                    }
                }
                else
                {
                    panel1.Visible = false;
                }

                txtIdKardex.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("No existen registros con el Id Kardex ingresado.", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdKardex.Text = "";
                txtIdKardex.Focus();
                btnSalir1.Enabled = true;
                return;
                throw;
            }

            if (tAccion == EventoFormulario.EDITAR)
            {
                tbcRegOpe.SelectedIndex = 3;
            }
        }

        /// <summary>
        /// PERMITE INICIALIZAR EL TAB DE LA PERSONA FISICA
        /// </summary>
        private void InicializarTabFisica()
        {
            if (!mboxTabF)
            {
                if (!estadoNuevo)
                {
                    MessageBox.Show("El monto de la operación es superior al umbral splaft, se procederá a realizar el registro de operación", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnNuevoGen.Enabled = false;
                    btnEditarGen.Enabled = false;
                }
                else
                {
                    btnAgregarPerFis.Visible = true;
                    btnNuevoPerFis.Visible = true;
                    btnBusClientePerFis.Visible = true;
                    btnGrabarPerFis.Visible = true;
                    btnGrabarPerFis.Enabled = true;
                }

                //var confCli = MessageBox.Show("¿La persona que SOLICITA O FÍSICAMENTE REALIZA LA OPERACIÓN, es cliente?", "SPLAFT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                bool EstadoTipoOper = true;

                if (idTipoOperacion.In(20, 21, 13, 14))
                {
                    MessageBox.Show("REGISTRAR A LA PERSONA EN VENTANILLA.", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EstadoTipoOper = false;
                }

                if (EstadoTipoOper)
                {
                    var confTitular = MessageBox.Show("¿LA(S) PERSONA(S) EN VENTANILLA, ES (SON) TITULAR(ES) DE LA CUENTA?", "SPLAFT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confTitular == DialogResult.Yes)
                    {
                        //------------------------CARGANDO LOS DATOS DEL TITULAR-------------------------------------//                        
                        ListaPersonaF = cnpersonasplaft.listarPersonaSplaft(idKardex, idModulo);
                        lPersonaJuridica = ListaPersonaF.Exists(x => x.nTipoPersona.In(2, 3));
                        if (lPersonaJuridica)
                        {
                            ListaPersonaF = cnpersonasplaft.listarRepresentanteSplaft(ListaPersonaF.Select(x => x.nCodCli).FirstOrDefault());
                        }

                        if (ListaPersonaF.Count() == 0)
                        {
                            MessageBox.Show("La persona física no esta registrada como cliente", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            habilitarBusquedaCliFisManual();
                            return;
                        }

                        //------------------------ELIMINANDO A LAS PERSONA JURÍDICAS-------------------------------------//    
                        ListaPersonaF.RemoveAll(x => !x.nTipoPersona.In(1));
                        if (ListaPersonaF.Count() == 0)
                        {
                            MessageBox.Show("La persona física no puede ser persona jurídica", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            habilitarBusquedaCliFisManual();
                            return;
                        }

                        for (int i = 0; i < ListaPersonaF.Count; i++)
                        {
                            ListaPersonaF[i].nTipoPersona = convertirTipoP(ListaPersonaF[i]);
                        }

                        dtgPFisica.DataSource = ListaPersonaF;

                        personaF = (clsPersonaSplaft)this.dtgPFisica.Rows[0].DataBoundItem;
                        columnas_visible(dtgPFisica);

                        conBusPersonSplaft1.EsCliente = personaF.nCodCli == 0 ? false : true;
                        conBusPersonSplaft1.conBusUB.cargar();
                        conBusPersonSplaft1.cargar(personaF);
                        conBusPersonSplaft1.conNegocio(true);
                        btnAgregarPerFis.Enabled = false;
                        conBusPersonSplaft1.JuridicoHabilitado = true;
                        btnEliminarFis.Enabled = true;

                        if(!lPersonaJuridica)
                            lPersonaFisicaTitular = true;

                        if ( idTipoOperacion.In(1, 9, 2, 10, 34) )   //  Para Op. Apertura, Desembolsos, Depósitos, Pago de Préstamos y Cancelación por Ampliación
                        {
                            GrabarDatosPersonaFisica();
                        }
                    }
                    else
                    {
                        habilitarBusquedaCliFis();
                    }
                }
                else
                {
                    habilitarBusquedaCliFisManual();
                }
                mboxTabF = true;
            }
        }

        private void habilitarBusquedaCliFis()
        {
            //------------------------HABILITANDO OPCIONES DE BUSQUEDA DE CLIENTES------------------------//                        
            conBusPersonSplaft1.EsCliente = true;
            conBusPersonSplaft1.JuridicoHabilitado = true;
            conBusPersonSplaft1.cargar();
            btnAgregarPerFis.Enabled = true;
            btnBusClientePerFis.Enabled = true;
            btnGrabarPerFis.Visible = false;
            btnEditarPerFis.Visible = true;
            btnEditarPerFis.Enabled = false;
            btnEditarPerFis.Location = this.btnGrabarPerFis.Location;
            btnNuevoPerFis.Enabled = false;
            conBusPersonSplaft1.conBusUB.cboPais.SelectedValue = nCodPeru;
        }

        private void habilitarBusquedaCliFisManual()
        {
            //------------------------HABILITANDO INGRESO MANUAL---------------------------------------------//                        
            conBusPersonSplaft1.EsCliente = false;

            conBusPersonSplaft1.JuridicoHabilitado = true;
            conBusPersonSplaft1.habilitarControles(true);
            conBusPersonSplaft1.cargar();
            btnBusClientePerFis.Enabled = true;
            btnAgregarPerFis.Enabled = true;
            btnNuevoPerFis.Enabled = false;
            btnGrabarPerFis.Enabled = false;
            btnAgregarPerFis.Enabled = true;
            btnGrabarPerFis.Visible = false;
            btnEditarPerFis.Visible = true;
            btnEditarPerFis.Location = this.btnGrabarPerFis.Location;
            btnEditarPerFis.Enabled = false;
            btnAgregarPerFis.Enabled = true;
            conBusPersonSplaft1.conBusUB.cargar();
            conBusPersonSplaft1.conBusUB.cboPais.SelectedValue = nCodPeru;
        }
        /// <summary>
        /// PERMITE INICIALIZAR EL TAB DE LA PERSONA ORDENANTE
        /// </summary>
        private void InicializarTabOrdenante()
        {
            if (!mboxTabO)
            {
                mboxTabO = true;
                if (estadoNuevo)
                {
                    btnNuevoPerOrd.Visible = true;
                    btnAgregarPerOrd.Visible = true;
                    btnBusClientePerOrd.Visible = true;
                    btnEditarPerOrd.Visible = true;
                }

                if (idTipoOperacion.In(20, 21))
                {
                    MessageBox.Show("PARA OPERACIONES DE COMPRA Y VENTA DE DÓLARES SE GUARDA LA PERSONA FÍSICA AUTOMÁTICAMENTE.", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClonarPersonaFisicaOrdenande();
                }
                else
                {
                    if (idTipoOperacion.In(13, 14))
                    {
                        MessageBox.Show("REGISTRAR A LA PERSONA QUE ENVÍA EL GIRO.", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LlenarManualmentePersonaOrdenante();
                    }
                    else
                    {
                        if (idTipoOperacion.In(1, 9, 2, 10, 34))   //  Para Op. Apertura, Desembolsos, Depósitos, Pago de Préstamos y Cancelación por Ampliación
                        {
                            if (lPersonaFisicaTitular && !lPersonaJuridica)
                            {
                                ClonarPersonaFisicaOrdenande();
                            }
                            else
                            {
                                ObtenerTitularPersonaOrdenante();
                            }
                            GrabarDatosPersonaOrdenante();
                            MessageBox.Show("PARA ESTE TIPO DE OPERACIONES SE GUARDA CON EL(LOS) TITULAR(ES) EN PERSONA ORDENANTE AUTOMÁTICAMENTE.", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            var isSame = MessageBox.Show("¿LA PERSONA QUE ORDENA LA OPERACIÓN, ES TITULAR DE LA CUENTA?", "SPLAFT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (isSame == DialogResult.Yes)
                            {
                                if (lPersonaFisicaTitular)
                                {
                                    ClonarPersonaFisicaOrdenande();
                                }
                                else
                                {
                                    ObtenerTitularPersonaOrdenante();
                                }
                            }
                            else
                            {
                                LlenarManualmentePersonaOrdenante();
                            }
                        }
                    }
                }
            }
        }

        private void ObtenerTitularPersonaOrdenante()
        {
            mboxTabO = true;
            //------------------------CARGANDO LOS DATOS DEL TITULAR-------------------------------------//      
            ListaPersonaO = cnpersonasplaft.listarPersonaSplaft(idKardex, idModulo);
            if (ListaPersonaO.Count() == 0)
            {
                MessageBox.Show("La persona ordenante no esta registrada como cliente", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lPersonaOrdenanteTitular = true;
                LlenarManualmentePersonaOrdenante();
                return;
            }

            for (int i = 0; i < ListaPersonaO.Count; i++)
            {
                ListaPersonaO[i].nTipoPersona = convertirTipoP(ListaPersonaO[i]);
            }

            dtgPOrdenante.DataSource = ListaPersonaO;

            personaO = (clsPersonaSplaft)this.dtgPOrdenante.Rows[0].DataBoundItem;
            columnas_visible(dtgPOrdenante);
            this.conBusPersonSplaft2.EsCliente = true;
            this.conBusPersonSplaft2.RolCliente = 2;
            this.conBusPersonSplaft2.conBusUB.cargar();
            this.conBusPersonSplaft2.cargar(personaO);
            this.conBusPersonSplaft2.Enabled = true;
            btnNuevoPerOrd.Enabled = true;
            btnBusClientePerOrd.Enabled = true;
            this.btnAgregarPerOrd.Enabled = false;
            this.conBusPersonSplaft2.habilitarControles(false);
            conBusPersonSplaft2.conBusUB.cboPais.SelectedValue = nCodPeru;
            btnEliminarOrd.Enabled = true;
            lPersonaOrdenanteTitular = true;
            lPersonaJuridica = ListaPersonaO.Exists(x => x.nTipoPersona.In(2, 3));
        }

        private void ClonarPersonaFisicaOrdenande()
        {
            if (dtgPFisica.DataSource == null)
            {
                mboxTabO = false;
                MessageBox.Show("No se ha asignado a ninguna persona que solicita o físicamente a realizado la operación", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                mboxTabO = true;
                ListaPersonaO = (clsListaPersonaSplaft)ListaPersonaF.Clone();
                dtgPOrdenante.DataSource = ListaPersonaO;
                personaO = (clsPersonaSplaft)this.dtgPOrdenante.Rows[0].DataBoundItem;
                columnas_visible(dtgPOrdenante);
                this.conBusPersonSplaft2.EsCliente = true;
                this.conBusPersonSplaft2.RolCliente = 2;
                this.conBusPersonSplaft2.conBusUB.cargar();
                this.conBusPersonSplaft2.cargar(personaO);
                this.conBusPersonSplaft2.Enabled = true;
                btnNuevoPerOrd.Enabled = true;
                btnBusClientePerOrd.Enabled = true;
                this.btnAgregarPerOrd.Enabled = false;
                this.conBusPersonSplaft2.habilitarControles(false);
                conBusPersonSplaft2.conBusUB.cboPais.SelectedValue = nCodPeru;
                btnEliminarOrd.Enabled = true;
            }
        }

        private void LlenarManualmentePersonaOrdenante()
        {
            this.conBusPersonSplaft2.EsCliente = false;
            this.conBusPersonSplaft2.RolCliente = 2;
            this.conBusPersonSplaft2.habilitarControles(false);
            this.conBusPersonSplaft2.cargar();
            this.btnBusClientePerOrd.Enabled = true;
            this.btnAgregarPerOrd.Enabled = true;
            this.btnEditarPerOrd.Enabled = false;
            this.btnNuevoPerOrd.Enabled = false;
            conBusPersonSplaft2.conBusUB.cboPais.SelectedValue = nCodPeru;
        }

        /// <summary>
        /// PERMITE INICIALIZAR EL TAB DE LA PERSONA BENEFICIARIA
        /// </summary>
        private void InicializarTabBeneficiario()
        {
            if (!mboxTabB)
            {
                mboxTabB = true;

                if (estadoNuevo)
                {
                    btnNuevoPerBen.Visible = true;
                    btnAgregarPerBen.Visible = true;
                    btnBusClientePerBen.Visible = true;
                    btnEditarPerBen.Visible = true;
                }

                if (idTipoOperacion.In(20, 21))
                {
                    MessageBox.Show("PARA OPERACIONES DE COMPRA Y VENTA DE DÓLARES SE GUARDA LA PERSONA FÍSICA AUTOMÁTICAMENTE.", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClonarPersonaFisicaBeneficiaria();
                }
                else
                {
                    if (idTipoOperacion.In(13, 14))
                    {
                        MessageBox.Show("REGISTRAR A LA PERSONA QUE RECIBE EL GIRO.", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.conBusPersonSplaft3.cargar(false);
                        if (dtgPBeneficiaria.RowCount > 0)
                        {
                            cotrolesBotonesPerBen(Transaccion.Edita);
                            this.conBusPersonSplaft3.habilitarControles(true);
                        }
                        else
                        {
                            cotrolesBotonesPerBen(Transaccion.Elimina);
                            this.conBusPersonSplaft3.habilitarControles(false);
                        }
                    }
                    else
                    {
                        if (idTipoOperacion.In(1, 9, 2, 10, 34))  //  Para Op. Apertura, Desembolsos, Depósitos, Pago de Préstamos y Cancelación por Ampliación
                        {
                            if (ListaPersonaO.Exists(x => x.nTipoPersona.In(2, 3)))
                            {
                                if (lPersonaFisicaTitular)
                                {
                                    ClonarPersonaFisicaBeneficiaria();
                                }
                                else
                                {
                                    ObtenerRepresentantePeronaBeneficiaria();
                                }
                            }
                            else
                            {
                                ClonarPersonaOrdenanteBeneficiaria();
                            }
                            MessageBox.Show("PARA ESTE TIPO DE OPERACIONES SE GUARDA CON EL(LOS) TITULAR(ES) EN PERSONA BENEFICIARIA AUTOMÁTICAMENTE.", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (idTipoOperacion == 11 && idTipoPago == 5)
                        {
                            ClonarPersonaFisicaBeneficiaria();
                            MessageBox.Show("PARA ESTE TIPO DE OPERACIONES DE RETIRO CON ORDEN DE PAGO SE GUARDA CON LA PERSONA FÍSICA EN PERSONA BENEFICIARIA AUTOMÁTICAMENTE.", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            var isSame = MessageBox.Show("¿EL TITULAR DE LA CUENTA, ES EL BENEFICIARIO DE LA OPERACIÓN?", "SPLAFT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (isSame == DialogResult.Yes)
                            {
                                if (dtgPFisica.DataSource == null)
                                {
                                    MessageBox.Show("No se ha asignado a ninguna persona que solicita o físicamente a realizado la operación", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    if ((lPersonaFisicaTitular == true || lPersonaOrdenanteTitular == true) && (lPersonaJuridica != true))
                                    {
                                        if (lPersonaFisicaTitular == true)
                                            ClonarPersonaFisicaBeneficiaria();
                                        else
                                            ClonarPersonaOrdenanteBeneficiaria();
                                    }
                                    else
                                    {
                                        ObtenerTitularPersonaBeneficiaria();
                                    }

                                }
                            }
                            else
                            {
                                LlenarManualmentePersonaBeneficiaria();
                            }
                        }
                    }
                }
            }
        }

        private void ObtenerTitularPersonaBeneficiaria()
        {
            mboxTabB = true;
            //------------------------CARGANDO LOS DATOS DEL TITULAR-------------------------------------//      
            ListaPersonaB = cnpersonasplaft.listarPersonaSplaft(idKardex, idModulo);
            lPersonaJuridica = ListaPersonaB.Exists(x => x.nTipoPersona.In(2, 3));
            if (lPersonaJuridica)
            {
                ListaPersonaB = cnpersonasplaft.listarRepresentanteSplaft(ListaPersonaB.Select(x => x.nCodCli).FirstOrDefault());
            }

            if (ListaPersonaB.Count() == 0)
            {
                MessageBox.Show("La persona beneficiaria no esta registrada como cliente", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarManualmentePersonaBeneficiaria();
                return;
            }

            //------------------------ELIMINANDO A LAS PERSONA JURÍDICAS-------------------------------------//    
            ListaPersonaB.RemoveAll(x => !x.nTipoPersona.In(1));
            if (ListaPersonaB.Count() == 0)
            {
                MessageBox.Show("La persona beneficiaria no puede ser persona jurídica", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarManualmentePersonaBeneficiaria();
                return;
            }

            for (int i = 0; i < ListaPersonaB.Count; i++)
            {
                ListaPersonaB[i].nTipoPersona = convertirTipoP(ListaPersonaB[i]);
            }

            dtgPBeneficiaria.DataSource = ListaPersonaB;

            personaB = (clsPersonaSplaft)this.dtgPBeneficiaria.Rows[0].DataBoundItem;
            columnas_visible(dtgPBeneficiaria);
            this.conBusPersonSplaft3.EsCliente = true;
            this.conBusPersonSplaft3.RolCliente = 3;
            this.conBusPersonSplaft3.conBusUB.cargar();
            this.conBusPersonSplaft3.cargar(personaB);
            this.conBusPersonSplaft3.Enabled = true;
            this.btnAgregarPerBen.Enabled = false;
            this.conBusPersonSplaft3.habilitarControles(false);
            conBusPersonSplaft3.conBusUB.cboPais.SelectedValue = nCodPeru;
            btnEliminarBen.Enabled = true;
            btnNuevoPerBen.Enabled = true;
        }

        private void ObtenerRepresentantePeronaBeneficiaria()
        {
            mboxTabB = true;
            //------------------------CARGANDO LOS DATOS DEL TITULAR-------------------------------------//      
            ListaPersonaB = cnpersonasplaft.listarPersonaSplaft(idKardex, idModulo);
            lPersonaJuridica = ListaPersonaB.Exists(x => x.nTipoPersona.In(2, 3));
            if (lPersonaJuridica)
            {
                ListaPersonaB = cnpersonasplaft.listarRepresentanteSplaft(ListaPersonaB.Select(x => x.nCodCli).FirstOrDefault());
            }

            if (ListaPersonaB.Count() == 0)
            {
                MessageBox.Show("La persona beneficiaría no esta registrada como cliente", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarManualmentePersonaBeneficiaria();
                return;
            }

            //------------------------ELIMINANDO A LAS PERSONA JURÍDICAS-------------------------------------//    
            ListaPersonaB.RemoveAll(x => !x.nTipoPersona.In(1));
            if (ListaPersonaB.Count() == 0)
            {
                MessageBox.Show("La persona beneficiaría no puede ser persona jurídica", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarManualmentePersonaBeneficiaria();
                return;
            }

            if (ListaPersonaB.Count() == 0)
            {
                MessageBox.Show("La persona beneficiaria no esta registrada como cliente", "SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarManualmentePersonaBeneficiaria();
                return;
            }

            for (int i = 0; i < ListaPersonaB.Count; i++)
            {
                ListaPersonaB[i].nTipoPersona = convertirTipoP(ListaPersonaB[i]);
            }

            dtgPBeneficiaria.DataSource = ListaPersonaB;

            personaB = (clsPersonaSplaft)this.dtgPBeneficiaria.Rows[0].DataBoundItem;
            columnas_visible(dtgPBeneficiaria);
            this.conBusPersonSplaft3.EsCliente = true;
            this.conBusPersonSplaft3.RolCliente = 3;
            this.conBusPersonSplaft3.conBusUB.cargar();
            this.conBusPersonSplaft3.cargar(personaB);
            this.conBusPersonSplaft3.Enabled = true;
            this.btnAgregarPerBen.Enabled = false;
            this.conBusPersonSplaft3.habilitarControles(false);
            conBusPersonSplaft3.conBusUB.cboPais.SelectedValue = nCodPeru;
            btnEliminarBen.Enabled = true;
            btnNuevoPerBen.Enabled = true;
        }

        private void ClonarPersonaFisicaBeneficiaria()
        {
            mboxTabB = true;
            ListaPersonaB = (clsListaPersonaSplaft)ListaPersonaF.Clone();
            dtgPBeneficiaria.DataSource = ListaPersonaB;
            personaB = (clsPersonaSplaft)this.dtgPBeneficiaria.Rows[0].DataBoundItem;
            columnas_visible(dtgPBeneficiaria);
            this.conBusPersonSplaft3.EsCliente = true;
            this.conBusPersonSplaft3.RolCliente = 3;
            this.conBusPersonSplaft3.conBusUB.cargar();
            this.conBusPersonSplaft3.cargar(personaB);
            this.conBusPersonSplaft3.Enabled = true;
            this.btnAgregarPerBen.Enabled = false;
            this.conBusPersonSplaft3.habilitarControles(false);
            conBusPersonSplaft3.conBusUB.cboPais.SelectedValue = nCodPeru;
            btnEliminarBen.Enabled = true;
            btnNuevoPerBen.Enabled = true;
        }

        private void ClonarPersonaOrdenanteBeneficiaria()
        {
            mboxTabB = true;
            ListaPersonaB = (clsListaPersonaSplaft)ListaPersonaO.Clone();
            dtgPBeneficiaria.DataSource = ListaPersonaB;
            personaB = (clsPersonaSplaft)this.dtgPBeneficiaria.Rows[0].DataBoundItem;
            columnas_visible(dtgPBeneficiaria);
            this.conBusPersonSplaft3.EsCliente = true;
            this.conBusPersonSplaft3.RolCliente = 3;
            this.conBusPersonSplaft3.conBusUB.cargar();
            this.conBusPersonSplaft3.cargar(personaB);
            this.conBusPersonSplaft3.Enabled = true;
            this.btnAgregarPerBen.Enabled = false;
            this.conBusPersonSplaft3.habilitarControles(false);
            conBusPersonSplaft3.conBusUB.cboPais.SelectedValue = nCodPeru;
            btnEliminarBen.Enabled = true;
            btnNuevoPerBen.Enabled = true;
        }

        private void LlenarManualmentePersonaBeneficiaria()
        {
            this.conBusPersonSplaft3.EsCliente = false;
            this.conBusPersonSplaft3.RolCliente = 3;
            this.conBusPersonSplaft3.habilitarControles(false);
            this.conBusPersonSplaft3.cargar();
            this.btnBusClientePerBen.Enabled = true;
            this.btnAgregarPerBen.Enabled = true;
            this.btnEditarPerBen.Enabled = false;
            this.btnNuevoPerBen.Enabled = false;
            conBusPersonSplaft3.conBusUB.cboPais.SelectedValue = nCodPeru;
        }

        public int convertirTipoP(clsPersonaSplaft person)
        {
            return person.nTipoPersona;
        }

        private void cargarPersonaBeneficiariaOpe(int idTipoOpe, int idKardex, int idModulo)
        {
            if (idTipoOpe.In(9, 10, 12, 2))
            {
                CargarTitularesBenef(idKardex, idModulo);
            }
        }

        private void CargarTitularesBenef(int idKardex, int idModulo)
        {
            //------------------------CARGANDO LOS DATOS DEL TITULAR-------------------------------------//                        
            ListaPersonaB = cnpersonasplaft.listarPersonaSplaft(idKardex, idModulo);
            if (ListaPersonaB.Count() == 0)
            {
                return;
            }



            for (int i = 0; i < ListaPersonaB.Count; i++)
            {
                ListaPersonaB[i].nTipoPersona = convertirTipoP(ListaPersonaB[i]);
            }

            dtgPBeneficiaria.DataSource = ListaPersonaB;

            personaB = (clsPersonaSplaft)this.dtgPBeneficiaria.Rows[0].DataBoundItem;
            columnas_visible(dtgPBeneficiaria);

            conBusPersonSplaft3.EsCliente = personaB.nCodCli == 0 ? false : true;
            conBusPersonSplaft3.conBusUB.cargar();
            conBusPersonSplaft3.cargar(personaB);
            conBusPersonSplaft3.conNegocio(true);
            btnAgregarPerBen.Enabled = false;
            conBusPersonSplaft3.JuridicoHabilitado = true;
            btnEliminarBen.Enabled = true;
        }

        #endregion

        public void cargarRowaFormulario(ref conBusPersonSplaft con, ref clsPersonaSplaft nPersona, ref dtgBase dtg, ref GEN.BotonesBase.BtnAceptar btn, int nColumna, int nPer)
        {
            if (!btn.Visible)
            {
                nPersona = (clsPersonaSplaft)dtg.CurrentRow.DataBoundItem;
                columnas_visible(dtg);

                con.EsCliente = nPersona.nCodCli == 0 ? false : true;
                con.cargar(nPersona);
                con.activarEspeciales(false);
                switch (nPer)
                {
                    case 1:
                        cotrolesBotonesPerFis(Transaccion.Selecciona);
                        break;
                    case 2:
                        cotrolesBotonesPerOrd(Transaccion.Selecciona);
                        break;
                    case 3:
                        cotrolesBotonesPerBen(Transaccion.Selecciona);
                        break;
                }

                if (!estadoReimprimir)
                {
                    if (nColumna == 31)
                    {
                        if (nPersona.bPresencia)
                        { nPersona.bPresencia = false; }
                        else
                        { nPersona.bPresencia = true; }
                    }
                }
            }
        }

        private void cboDetalleOrdenPago1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nValor = Convert.ToInt32(cboDetalleOrdenPago1.SelectedValue);
            if (nValor == 6)
            {
                txtCBOtrosDescOrdPag.Enabled = true;
            }
            else
            {
                txtCBOtrosDescOrdPag.Enabled = false;
            }
        }

        public string obtenerTitulo()
        {
            //string cTitulo
            switch (idTipoOperacion)
            {
                case 13:
                    return "Remitente";
                case 14:
                    return "Remitente";
                default:
                    return "Titular";
            }
        }

        private void btnBlanco1_Click(object sender, EventArgs e)
        {
            frm = new frmSustentoArchivoSplaft(this.idKardex);
            frm.ShowDialog();
            this.lGuardadoSustento = frm.obtenerGuardado();
        }


        public void CargarDatosOrigenDestinoFondos()
        {
            clsCNListaTipoFondos Origen = new clsCNListaTipoFondos();
            DataTable dtOrigen = Origen.ListaTipoFondos(false);
            cboOrigenFondos.DataSource = dtOrigen;
            cboOrigenFondos.ValueMember = dtOrigen.Columns[0].ToString();
            cboOrigenFondos.DisplayMember = dtOrigen.Columns[2].ToString();

            clsCNListaTipoFondos Destino = new clsCNListaTipoFondos();
            DataTable dtDestino = Destino.ListaTipoFondos(true);
            cboDestinoFondos.DataSource = dtDestino;
            cboDestinoFondos.ValueMember = dtDestino.Columns[0].ToString();
            cboDestinoFondos.DisplayMember = dtDestino.Columns[2].ToString();

            cboOrigenFondos.SelectedIndex = 22;
            cboDestinoFondos.SelectedIndex = 11;
        }

        private void cboOrigenFondos_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitaDetalleOrigen();
            txtOrigen.Text = "";
        }

        private void cboDestinoFondos_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitaDetalleDestino();
            txtDestino.Text = "";
        }

        private void HabilitaDetalleOrigen()
        {
            if (cboOrigenFondos.SelectedIndex == 0 || cboOrigenFondos.SelectedIndex == 17 || cboOrigenFondos.SelectedIndex == 18 || cboOrigenFondos.SelectedIndex == 22)
            {
                txtOrigen.Enabled = true;
            }
            else
            {
                txtOrigen.Enabled = false;
            }
        }

        private void HabilitaDetalleDestino()
        {
            if (cboDestinoFondos.SelectedIndex == 11)
            {
                txtDestino.Enabled = true;
            }
            else
            {
                txtDestino.Enabled = false;
            }
        }

    }
}
