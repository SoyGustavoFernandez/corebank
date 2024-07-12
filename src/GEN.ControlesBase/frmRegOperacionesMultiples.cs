using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPL.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
namespace GEN.ControlesBase
{
    public partial class frmRegOperacionesMultiples : frmBase
    {
        #region Variables Globales
        DataTable dtKardex;
        clsCNBuscaKardex cnBuscaKardex = new clsCNBuscaKardex();
        clsCNOperacionesMultiples cnOpeMult = new clsCNOperacionesMultiples();
        clsCNInusualSplaft inusual = new clsCNInusualSplaft();
        clsCNDetalleInusual detalleInusual = new clsCNDetalleInusual();

        /* --------------------------------------------------------*/
        DataTable dtPerFisica;
        DataTable dtPerOrdena;
        DataTable dtBeneficia;
        Boolean lEditarFis = false;
        Boolean lEditaOrden = false;

        /* --------------------------------------------------------*/
        Boolean cargar = true;
        int idTipoUmbral = 0;
        public int idKardex = 0;
        int idUmbral;
        int idTipoOperacion;
        int idMonedaOpe;
        int idCuenta;
        int idModulo;
        DateTime dFechaHora;

        /* -----------    ESTADOS    -------------------------------*/
        const string Inicio = "Inicio";
        const string Nuevo = "Nuevo";
        const string Editar = "Editar";
        const string Guardado = "Guardado";
        const string Vacio = "Vacio";
        const string Bloquear = "Bloqueado";
        const string Imprimir = "Imprimir";

        /* -----------    ESTADOS    -------------------------------*/
        string cAccion = Nuevo;
        string cEstadoPerFis;
        string cTitulo = "Registro de Operaciones Multiples SPLAFT";
        #endregion

        #region Constructores
        public frmRegOperacionesMultiples()
        {
            InitializeComponent();
            cargarEstados();

            activarDatosPerFisica(false);
            activarDatosOrdenante(false);
            activarDatosBeneficiaria(false);
            activarDatosOperacion(false);
            activarOperacionesFraccionarias(false);
            inusualActivar(false);
            activarResumen(false);

            ActualizarBotonesFis(Vacio);
            ActualizarBotonesGeneral(Vacio);
            ActualizarBotonesOrden(Vacio);
            tbcDatosRegOpeMult.Enabled = false;
            
        }

        /// <summary>
        /// SE ACTIVA CUANDO A LA CLASE SE LE PASA UN KARDEX
        /// </summary>
        /// <param name="kardex">id del kardex a buscar</param>
        public frmRegOperacionesMultiples(int kardex)
        {
            idKardex = kardex;
            InitializeComponent();            
            cargarEstados();
            activarDatosPerFisica(false);
            activarDatosOrdenante(false);
            activarDatosBeneficiaria(false);
            activarDatosOperacion(false);
            activarOperacionesFraccionarias(false);
            inusualActivar(false);
            activarResumen(false);

            ActualizarBotonesFis(Vacio);
            ActualizarBotonesGeneral(Vacio);
            ActualizarBotonesOrden(Vacio);
            tbcDatosRegOpeMult.Enabled = false;

            cargarOpeMultiPorIdKardex(idKardex);
        }

        private void cargarOpeMultiPorIdKardex(int idKardex)
        {
            //-------------------------------------------------------------------------------------//
            // Valida si la variable esta activo para la agencia si no esta activa no realiza nada
            //-------------------------------------------------------------------------------------//
            if (!Convert.ToBoolean(clsVarApl.dicVarGen["lActivarRegOpeMult"]))
            {
                return;
            }
            
            //-------------------------------------------------------------------------------------//
            // Verifica las veces que ha aparecido el formulario de registro
            //-------------------------------------------------------------------------------------//
            DataTable dtNroOpeMult = cnOpeMult.CNCuentaRegOpeMult(idKardex, clsVarGlobal.nIdAgencia);
            if (Convert.ToInt32(dtNroOpeMult.Rows[0]["nNroRegistros"]) == clsVarApl.dicVarGen["nNroRegOpeMultMensual"])
            {
                return;
            }

            validarUmbral(idKardex);
            if (cargar && idTipoUmbral > 1)
            {                
                tbcDatosRegOpeMult.Enabled = true;
                cargarOperacionesFraccionarias();
                cargarTitularCuenta(idKardex);
                cargarGrupoInusual();

                activarDatosPerFisica(false);
                activarDatosOrdenante(false);
                activarDatosBeneficiaria(false);
                activarDatosOperacion(true);
                activarOperacionesFraccionarias(false);
                inusualActivar(false);
                activarResumen(false);

                //-------------------------------------------------------------------------------------//
                // cargando dataSource a los datagrids
                //-------------------------------------------------------------------------------------//
                DataTable dt = cnOpeMult.CNRecuperarClienteOpeMult(0);
                permitirValoresNulos(ref dt);

                DataTable dtOrd = dt.Clone();
                DataTable dtBen = dt.Clone();

                dtgDatPerFis.DataSource = dt;
                dtgDatOrden.DataSource = dtOrd;
                formatoGridBen(dtgDatPerFis);
                formatoGridBen(dtgDatOrden);

                //-------------------------------------------------------------------------------------//
                // validando que la persona fisica es cliente y es dueño de la cuenta
                //-------------------------------------------------------------------------------------//
                DialogResult dRes = MessageBox.Show("¿La persona que realiza fisicamente la operación es titular de la cuenta?", "Operaciones Multiples", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dRes == DialogResult.Yes)
                {
                    DataTable dtPerFis = cnOpeMult.CNObtCliRealizaOperacion(idKardex);
                    if (dtPerFis.Rows.Count > 0)
                    {
                        dtgDatPerFis.DataSource = dtPerFis;
                        btnEliminar1.Enabled = true;
                    }

                }

                //-------------------------------------------------------------------------------------//
                // cargando dataTable con la estructura
                //-------------------------------------------------------------------------------------//
                dtPerFisica = dt.Clone();
                dtPerOrdena = dt.Clone();
                dtBeneficia = dt.Clone();
                ActualizarBotonesFis(cEstadoPerFis);
                ActualizarBotonesGeneral(Inicio);
                if (this.Visible==true)
                {
                     this.Show();
                }
                else
                {
                    this.ShowDialog();
                }                
            }
            else
            {
                this.Close();
            }
        }
        
        private void permitirValoresNulos(ref DataTable dt)
        {
            foreach (DataColumn column in dt.Columns)
                column.AllowDBNull = true;
        }

        public void EditarOperacionMultiple(int idKardex)
        {
            DataTable dtOpeMultEdit = cnOpeMult.CNRptOperacionMultiple(idKardex);
            if(dtOpeMultEdit.Rows.Count == 0)
            {
                MessageBox.Show("No esta registrado ninguna operacion multiple con el Nro de Kardex : " + idKardex.ToString(), "Operaciones Multiples", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            cargarDatosGenerales(dtOpeMultEdit);
            idTipoUmbral = Convert.ToInt32(dtOpeMultEdit.Rows[0]["nTipoUmbral"]);
            idUmbral = Convert.ToInt32(dtOpeMultEdit.Rows[0]["idUmbral"]);
            

            DataTable dtRPTPerFis = cnOpeMult.CNObtienePersonaRol(idKardex, 1);
            DataTable dtRPTPerOrd = cnOpeMult.CNObtienePersonaRol(idKardex, 2);
            
            permitirValoresNulos(ref dtRPTPerFis);
            permitirValoresNulos(ref dtRPTPerOrd);

            dtgDatPerFis.DataSource = dtRPTPerFis;
            dtgDatOrden.DataSource = dtRPTPerOrd;
            
            formatoGridBen(dtgDatPerFis);
            formatoGridBen(dtgDatOrden);

            cargarOperacionesFraccionarias();
            tbcDatosRegOpeMult.Enabled = true;
            cargarOperacionesFraccionarias();
            cargarTitularCuenta(idKardex);
            cargarGrupoInusual();

            activarDatosPerFisica(false);
            activarDatosOrdenante(false);
            activarDatosBeneficiaria(false);
            activarDatosOperacion(true);
            activarOperacionesFraccionarias(false);
            inusualActivar(false);
            activarResumen(false);

            //-------------------------------------------------------------------------------------//
            // Actualizando datos de la operacion
            //-------------------------------------------------------------------------------------//
            rbtnInusualSi.Checked = Convert.ToBoolean(dtOpeMultEdit.Rows[0]["lInusual"]);
            rbtnInusualNo.Checked = !Convert.ToBoolean(dtOpeMultEdit.Rows[0]["lInusual"]);
            txtObservacionesOpe.Text = Convert.ToString(dtOpeMultEdit.Rows[0]["cObservacion"]);
            if (rbtnInusualSi.Checked) {
                cboInusualGrupo.SelectedValue = Convert.ToInt32((dtOpeMultEdit.Rows[0]["idInusual"] == DBNull.Value) ? -1 : dtOpeMultEdit.Rows[0]["idInusual"]);
                int idDetalleInusualEdit = Convert.ToInt32((dtOpeMultEdit.Rows[0]["idDetalleInusual"] == DBNull.Value) ? -1 : dtOpeMultEdit.Rows[0]["idDetalleInusual"]);
                DataTable dtEdit = ((DataTable)lstDetalleInusual.DataSource);
                for (int i = 0; i < dtEdit.Rows.Count; i++)
			    {
			        if(Convert.ToInt32(dtEdit.Rows[i]["idDetalleInusual"]) ==idDetalleInusualEdit)
                    {
                        lstDetalleInusual.SelectedValue = Convert.ToString(dtEdit.Rows[i]["idCodDetalle"]);
                        break;
                    }
			    }
                
            }

            //-------------------------------------------------------------------------------------//
            // cargando dataTable con la estructura
            //-------------------------------------------------------------------------------------//
            ActualizarBotonesFis(Vacio);
            ActualizarBotonesGeneral(Editar);
            ActualizarBotonesOrden(Vacio);
        }

        public void cargarDatosGenerales(DataTable dt)
        {
            decimal val = Convert.ToDecimal(dt.Rows[0]["nMontoOperacion"]);
            int moneda = Convert.ToInt32(dt.Rows[0]["idMoneda"]);

            txtNumeroKardex.Text = dt.Rows[0]["idKardex"].ToString();
            txtFechaOperacion.Text = Convert.ToDateTime(dt.Rows[0]["dFechaOpe"].ToString()).ToString("dd/MM/yy");
            txtNroCuenta.Text = dt.Rows[0]["idCuenta"].ToString();
            txtTipoOperacion.Text = dt.Rows[0]["cTipoOperacion"].ToString();
            cboMoneda.SelectedValue = Convert.ToInt32(dt.Rows[0]["idMoneda"]);
            txtImporteOperacion.Text = Convert.ToDecimal(dt.Rows[0]["nMontoOperacion"]).ToString("N2");
            idTipoOperacion = Convert.ToInt32(dt.Rows[0]["idTipoOperacion"]);
            idMonedaOpe = Convert.ToInt32(dt.Rows[0]["idMoneda"]);
            idCuenta = Convert.ToInt32(dt.Rows[0]["idCuenta"]);
            idModulo = Convert.ToInt32(dt.Rows[0]["idModulo"]);
            dFechaHora = Convert.ToDateTime(dt.Rows[0]["dFecHoraOpe"]);
        }
        #endregion

        public void inusualActivar(Boolean lBol)
        {
            cboInusualGrupo.Enabled = lBol;
            lstDetalleInusual.Enabled = lBol;
        }
        
        public void cargarEstados()
        {
            cEstadoPerFis = Inicio;
        }

        

        #region Métodos
        public Boolean ExisteOpeMultiple(int idKardex)
        {
            DataTable dtOpeMult = cnOpeMult.CNRptOperacionMultiple(idKardex);
            if (dtOpeMult.Rows.Count > 0)
                return true;
            return false;
        }
        public void validarUmbral(int kardex)
        {
            idKardex = kardex;
            if (ExisteOpeMultiple(kardex) && cAccion == Nuevo)
            {
                MessageBox.Show("Ya existe la operación multiple con el nro de Kardex", "Operaciones Multiples", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cargar = false;
                return;
            }
            dtKardex = cnBuscaKardex.busquedaKardex(kardex);
            
            //---------------------------------------------------------------------------------//
            //  llenado datos Principales                                                        //
            //---------------------------------------------------------------------------------//
            if (dtKardex.Rows.Count == 0)
            {
                MessageBox.Show("No se encontro un kardex con id " + kardex.ToString(), "Operaciones Multiples", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cargar = false;
                return;
            }

            cargarDatosGenerales(dtKardex);
            int idTipoOperacion = Convert.ToInt32(dtKardex.Rows[0]["idTipoOperacion"]);
            //---------------------------------------------------------------------------------//
            //  Fin llenado datos Principales                                                    //
            //---------------------------------------------------------------------------------//
            //OBTENIENDO EL TIPO DE CAMBIO SPLAFT
            clsCNTipoCambioSPL tipoC = new clsCNTipoCambioSPL();
            DataTable dtTipoC = tipoC.ListarTipoCambio(1);
            
            if (dtTipoC.Rows.Count <= 0)
            {
                MessageBox.Show("No se encontró tipo de cambio para el SPLAFT", "Tipo cambio SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cargar = false;
                return;
            }
            decimal nTipoCambioSplaft = Convert.ToDecimal(dtTipoC.Rows[0]["nValor"]);

            //OBTENIENDO EL UMBRAL PARA OPERACIONES MULTIPLES SPLAFT
            clsCNUmbralSPL umbral = new clsCNUmbralSPL();
            DataTable dtUmbral = umbral.CNListarUmbralKardex(2, idKardex); // 2 operaciones multiples mensuales
            decimal umbDia1a3;
            decimal umbMensual;
            if (dtUmbral.Rows.Count == 0)
            {
                MessageBox.Show("No se a asignado un umbral para operaciones multiples mensuales a esta agencia", "Tipo cambio SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                umbMensual = -1;
            }
            else
                umbMensual = Convert.ToDecimal(dtUmbral.Rows[0]["nValor"]);



            DataTable dtUmbral3 = umbral.CNListarUmbralKardex(3, idKardex); //operaiones multiples tramo de 1-3
            if (dtUmbral3.Rows.Count == 0)
            {
                MessageBox.Show("No se a asignado un umbral para operaciones multiples en el tramo de 1-3 días para esta agencia", "Tipo cambio SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                umbDia1a3 = -1;
            }
            else 
                umbDia1a3 = Convert.ToDecimal(dtUmbral3.Rows[0]["nValor"]);


            if (umbMensual == -1 && umbDia1a3 == -1)
            {
                cargar = false;
                return; // se cancela la operación
            }


            //@todo comprobar si puedo registrar a la vez si las operaciones fraccionarias cumplen con los 2 umbrales
            DataTable dtOpeFracMensual = cnOpeMult.CNRetornaSumaMontoDeOperaciones(kardex, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, 2); // umbral mensual
            if (dtOpeFracMensual.Rows.Count == 0)
            {
                cargar = false;
                return;
            }

            if (Convert.ToDecimal(dtOpeFracMensual.Rows[0]["nTotalMonto"]) >= umbMensual*nTipoCambioSplaft)
            {
                DataTable dtRegOMM = cnOpeMult.CNValidaRegOpeMulMesy1_3(idKardex, 2);
                if (Convert.ToInt32(dtRegOMM.Rows[0]["nNroRegistros"]) > 0)
                {
                    cargar = false;
                    return;
                }

                MessageBox.Show("Operaciones Múltiples Superan al Umbral mensual", "Registro Ope. Mult.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                idTipoUmbral = 2;
                idUmbral = Convert.ToInt32(dtOpeFracMensual.Rows[0]["idUmbral"]);
                cargar = true;
                return;
            }


            DataTable dtOpeFrac1A3Dias = cnOpeMult.CNRetornaSumaMontoDeOperaciones(kardex, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, 3); // umbral tramo 1-3
            if (dtOpeFrac1A3Dias.Rows.Count == 0)
            {
                cargar = false;
                return;
            }

            if (Convert.ToDecimal(dtOpeFrac1A3Dias.Rows[0]["nTotalMonto"]) >= umbDia1a3 * nTipoCambioSplaft)
            {
                DataTable dtRegOM13 = cnOpeMult.CNValidaRegOpeMulMesy1_3(idKardex, 3);
                if (Convert.ToInt32(dtRegOM13.Rows[0]["nNroRegistros"]) > 0)
                {
                    cargar = false;
                    return;
                }

                MessageBox.Show("Operaciones Múltiples Superan al Umbral Tramo de 1 - 3 días", "Registro Ope. Mult.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                idTipoUmbral = 3;
                idUmbral = Convert.ToInt32(dtOpeFrac1A3Dias.Rows[0]["idUmbral"]);
                cargar = true;
                return;
            }
            //OBTENIEDNO
        }

        public void cargarTitularCuenta(int idkardex)
        {
            DataTable dtTitular = cnOpeMult.CNRetornaTitular(idKardex);
            dtgDatPerBen.DataSource = dtTitular;
            formatoGridBen(dtgDatPerBen);
        }
        
        public void cargarOperacionesFraccionarias()
        {
            DataTable dtOpeFrac = cnOpeMult.CNCargaOperacionesFraccionarias(idKardex, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, idTipoUmbral);
            dtgOpeFrac.DataSource = dtOpeFrac;
            formatoOpeFrac();
            ContarOperacionesFraccionarias();
        }

        public void ContarOperacionesFraccionarias()
        {
            int nNroOpeFrac = ((DataTable)dtgOpeFrac.DataSource).Rows.Count;
            decimal nSaldoTotalOpeFrac = 0;
            foreach (DataRow item in ((DataTable)dtgOpeFrac.DataSource).Rows)
	        {
                nSaldoTotalOpeFrac += Convert.ToDecimal(item["nMonto"]);
	        }
            txtImporteTotOpeMult.Text = nSaldoTotalOpeFrac.ToString("N2");
            txtNroTotalOpeFrac.Text = nNroOpeFrac.ToString();
            DateTime dFecha = clsVarGlobal.dFecSystem;
            switch (idTipoUmbral)
            { 
                case 2:
                    txtFechaInicioOperaciones.Text = (new DateTime(dFecha.Year, dFecha.Month, 1)).ToString("dd/MM/yyyy")  ;
                    txtFechaFinOperaciones.Text = dFecha.ToString("dd/MM/yyyy");
                    break;
                case 3:
                    txtFechaInicioOperaciones.Text = (dFecha.Day > 3)? dFecha.AddDays(-3).ToString("dd/MM/yyyy"): dFecha.AddDays(-dFecha.Day+1).ToString("dd/MM/yyyy");
                    txtFechaFinOperaciones.Text = dFecha.ToString("dd/MM/yyyy");
                    break;
            }
        }

        public void formatoOpeFrac() 
        {
            dtgOpeFrac.Columns["idCuenta"].Visible = false;
            dtgOpeFrac.Columns["idTipoOperacion"].Visible = false;
            dtgOpeFrac.Columns["idAgeOpera"].Visible = false;
            dtgOpeFrac.Columns["idMoneda"].Visible = false;
            //dtgOpeFrac.Columns[""].Visible = false;
            dtgOpeFrac.Columns["idModulo"].Visible = false;

            dtgOpeFrac.Columns["nMonto"].HeaderText = "Monto S/. ";
            dtgOpeFrac.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            dtgOpeFrac.Columns["dFechaOpe"].HeaderText = "Fecha Operación";
            dtgOpeFrac.Columns["dFecHoraOpe"].HeaderText = "Hora Operación";
            dtgOpeFrac.Columns["cNroDNI"].HeaderText = "Nro DNI";
            dtgOpeFrac.Columns["cNomCliente"].HeaderText = "Apellidos y Nombres";

            dtgOpeFrac.Columns["cNroDNI"].DisplayIndex = 0;
            dtgOpeFrac.Columns["cNomCliente"].DisplayIndex = 1;
            dtgOpeFrac.Columns["nMonto"].DisplayIndex = 6;

            dtgOpeFrac.Columns["dFecHoraOpe"].DefaultCellStyle.Format = "HH:mm:ss";
            dtgOpeFrac.Columns["nMonto"].DefaultCellStyle.Format = "N2";

        }

        public void formatoGridBen(DataGridView dtg)
        {
            dtg.Columns["idKardex"].Visible = false;
            dtg.Columns["idCli"].Visible = false;
            dtg.Columns["idRol"].Visible = false;
            dtg.Columns["idTipoDocumento"].Visible = false;
            dtg.Columns["idTipoPersona"].Visible = false;
            dtg.Columns["lCambioInfo"].Visible = false;

            dtg.Columns["cTipoDocumento"].DisplayIndex = 0;
            dtg.Columns["cDocumentoID"].DisplayIndex = 1;
            dtg.Columns["cNombre"].DisplayIndex = 2;
            dtg.Columns["cTipoPersona"].DisplayIndex = 3;

            dtg.Columns["cTipoDocumento"].HeaderText = "Tipo de Documento";
            dtg.Columns["cDocumentoID"].HeaderText = "Nro de Documento";
            dtg.Columns["cNombre"].HeaderText = "Apellidos y Nombres";
            dtg.Columns["cTipoPersona"].HeaderText = "Tipo de Persona";
        }

       
        /// <summary>
        /// Valida si hay contenido en el datagridview dtg y si no hay datos cambia el foco a grb
        /// </summary>
        /// <param name="dtg">DataGridView el cual se va analizar</param>
        /// <param name="grb">group donde se cambiara el foco cuando no haya elementos en el dtg</param>
        /// <param name="cMensaje">Mensaje a Mostrar cuando no hay elementos en el dtg</param>
        /// <returns>true | false: si hay valores en el dtg retorna true y en caso contrario false</returns>
        public Boolean validarGridContenido(DataGridView dtg, grbBase grb, string cMensaje)
        {
            if (dtg.RowCount == 0)
            {
                MessageBox.Show(cMensaje, "Tipo cambio SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                grb.Focus();
                return false;
            }

            return true;
        }

        public Boolean validarDatosOperacion()
        {
            if (!rbtnInusualNo.Checked && !rbtnInusualSi.Checked)
            {
                MessageBox.Show("Seleccione sí la operación es inusual o no", "Tipo cambio SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblBase14.Focus();
                return false;
            }

            if (rbtnInusualSi.Checked)
            { 
                //if()
            }
            return true;
        }
        public void cargarGrupoInusual()
        {
            DataTable dt = inusual.listarInusual();
            cboInusualGrupo.ValueMember = dt.Columns[0].ToString();
            cboInusualGrupo.DisplayMember = dt.Columns[1].ToString();
            cboInusualGrupo.DataSource = dt;
            cargarListaInusual(Convert.ToInt32(cboInusualGrupo.SelectedValue));
        }
        public void cargarListaInusual(int idInusual)
        {
            DataTable dt2 = detalleInusual.listarDetalleInusual(idInusual);
            lstDetalleInusual.ValueMember = dt2.Columns[0].ToString();
            lstDetalleInusual.DisplayMember = dt2.Columns[1].ToString();
            lstDetalleInusual.DataSource = dt2;
        }
        #endregion

        #region Limpiadores de Formularios
        public void limpiarResumen()
        {
            txtNumeroKardex.Clear();
            txtFechaOperacion.Clear();
            txtNroCuenta.Clear();
            cboMoneda.SelectedIndex = -1;
            txtFechaInicioOperaciones.Clear();
            txtImporteTotOpeMult.Clear();
            txtTipoOperacion.Clear();
            txtImporteOperacion.Clear();
            txtFechaFinOperaciones.Clear();
            txtNroTotalOpeFrac.Clear();
        }
        public void limpiarDatosPerFisica()
        {
            rbtnPerNat.Checked = false;
            rbtnPerJur.Checked = false;
            cboTipoDocumentoPerFis.SelectedIndex = -1;
            txtCBNroDocumentosPerFis.Clear();
            txtCBCNombrePerFis.Clear();
            dtPerFisica = null;
        }
        public void limpiarDatosOrdenante()
        {
            rbtnPerNatOrd.Checked = false;
            rbtnPerJurOrd.Checked = false;
            txtCDatosOrdena.Clear();
            dtPerOrdena = null;
        }
        public void limpiarDatosBeneficiaria()
        {
            rbtnPerNatBen.Checked = false;
            rbtnPerJurBen.Checked = false;
            cboTipoDocumentoBen.SelectedIndex = -1;
            txtCBNroDocumentosBen.Clear();
            txtCNombresBen.Clear();
            dtBeneficia = null;
            ((DataTable)dtgDatPerBen.DataSource).Clear();
        }
        public void limpiarDatosOperacion()
        {
            rbtnInusualSi.Checked = false;
            rbtnInusualNo.Checked = false;
            cboInusualGrupo.SelectedIndex = -1;
            txtObservacionesOpe.Clear();
        }
        public void limpiarOperacionesFraccionarias()
        {
            dtgOpeFrac.DataSource = null;
        }
        #endregion

        #region Activadores de Formularios
        public void activarResumen(Boolean estado)
        {
            txtNumeroKardex.Enabled = estado;
            txtFechaOperacion.Enabled = estado;
            txtNroCuenta.Enabled = estado;
            cboMoneda.Enabled = estado;
            txtFechaInicioOperaciones.Enabled = estado;
            txtImporteTotOpeMult.Enabled = estado;
            txtTipoOperacion.Enabled = estado;
            txtImporteOperacion.Enabled = estado;
            txtFechaFinOperaciones.Enabled = estado;
            txtNroTotalOpeFrac.Enabled = estado;
        }
        public void activarDatosPerFisica(Boolean estado)
        {
            rbtnPerNat.Enabled = estado;
            rbtnPerJur.Enabled = estado;
            cboTipoDocumentoPerFis.Enabled = estado;
            txtCBNroDocumentosPerFis.Enabled = estado;
            txtCBCNombrePerFis.Enabled = estado;
        }
        public void activarDatosOrdenante(Boolean estado)
        {
            rbtnPerNatOrd.Enabled = estado;
            rbtnPerJurOrd.Enabled = estado;
            txtCDatosOrdena.Enabled = estado;
        }
        public void activarDatosBeneficiaria(Boolean estado)
        {
            rbtnPerNatBen.Enabled = estado;
            rbtnPerJurBen.Enabled = estado;
            cboTipoDocumentoBen.Enabled = estado;
            txtCBNroDocumentosBen.Enabled = estado;
            txtCNombresBen.Enabled = estado;
        }
        public void activarDatosOperacion(Boolean estado)
        {
            rbtnInusualSi.Enabled = estado;
            rbtnInusualNo.Enabled = estado;
            cboInusualGrupo.Enabled = estado;
            lstDetalleInusual.Enabled = estado;
            txtObservacionesOpe.Enabled = estado;
        }
        public void activarOperacionesFraccionarias(Boolean estado)
        {
            dtgOpeFrac.Enabled = estado;

        }
        #endregion


        #region Eventos

        private void tbcDatosRegOpeMult_TabIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Evento Cambio de index TAb : " +e.ToString(), "Tipo cambio SPLAFT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cboInusualGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarListaInusual(Convert.ToInt32(cboInusualGrupo.SelectedValue));
        }

        private void btnBusCliente2_Click(object sender, EventArgs e)
        {
            if (cargarDatosDeCliente(dtgDatOrden, "La Persona Ordenante ya esta registrada", ref dtPerOrdena))
            {
                llenarDatosPersonaOrdena();
                activarDatosOrdenante(false);
            }
            ActualizarBotonesOrden(Nuevo);
        }

        private void btnBusCliente1_Click(object sender, EventArgs e)
        {
            if (cargarDatosDeCliente(dtgDatPerFis, "La Persona Física ya esta registrada", ref dtPerFisica))
            {
                llenarDatosPersonaFisica();
                activarDatosPerFisica(false);
            }
            ActualizarBotonesFis(Nuevo);
        }
        private void btnNuevo2_Click(object sender, EventArgs e)
        {
            activarDatosPerFisica(true);
            limpiarDatosPerFisica();
            ActualizarBotonesFis(Nuevo);
        }

        private void btnAceptar2_Click(object sender, EventArgs e)
        {
            if (rbtnPerJur.Checked)
            {
                MessageBox.Show("Una persona jurídica no puede ser persona física", "Persona Física", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!rbtnPerNat.Checked && !rbtnPerJur.Checked)
            {
                MessageBox.Show("Seleccione el tipo de Persona", "Persona Física", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(cboTipoDocumentoPerFis.SelectedIndex) < 0)
            {
                MessageBox.Show("Seleccione un tipo de documento", "Persona Física", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtCBNroDocumentosPerFis.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Inserta el Nro de Documento", "Persona Física", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtCBNroDocumentosPerFis.Text.Length < 8 && Convert.ToInt32(cboTipoDocumentoPerFis.SelectedValue) == 1)
            {
                MessageBox.Show("El Nro de Documento debe tener 8 digitos", "Persona Física", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtCBCNombrePerFis.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Ingrese los apellidos y nombres de la persona física", "Persona Física", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (dtPerFisica != null && !lEditarFis)
            {
                ColumnsReadOnlyDt(ref dtPerFisica, false);
                dtPerFisica.Rows[0]["idKardex"] = idKardex;
                dtPerFisica.Rows[0]["idRol"] = 1; // Fisicamente
                ((DataTable)dtgDatPerFis.DataSource).ImportRow(dtPerFisica.Rows[0]);
            }

            if (dtPerFisica != null && lEditarFis)
            {
                ColumnsReadOnlyDt(ref dtPerFisica, false);
                int indexUbica = ExisteClienteEnGrid(dtgDatPerFis, Convert.ToInt32((dtPerFisica.Rows[0]["idCli"] == DBNull.Value) ? -1 : dtPerFisica.Rows[0]["idCli"]), "Existe el cliente se procedera a actualizar info");
                if (indexUbica < 0)
                {
                    dtPerFisica.Rows[0]["idKardex"] = idKardex;
                    dtPerFisica.Rows[0]["idRol"] = 1; // Fisicamente
                    dtPerFisica.Rows[0]["lCambioInfo"] = 1;
                    dtPerFisica.Rows[0]["idTipoPersona"] = (Convert.ToInt32(dtPerFisica.Rows[0]["idTipoPersona"]) == 1 && rbtnPerNat.Checked == true) ? Convert.ToString(1) : Convert.ToString(dtPerFisica.Rows[0]["idTipoPersona"]);
                    dtPerFisica.Rows[0]["idTipoDocumento"] = cboTipoDocumentoPerFis.SelectedValue.ToString();
                    dtPerFisica.Rows[0]["cDocumentoID"] = txtCBNroDocumentosPerFis.Text;
                    dtPerFisica.Rows[0]["cNombre"] = txtCBCNombrePerFis.Text;
                    ((DataTable)dtgDatPerFis.DataSource).ImportRow(dtPerFisica.Rows[0]);
                }
                else
                {
                    DataTable dtTemp = ((DataTable)dtgDatPerFis.DataSource);
                    ColumnsReadOnlyDt(ref dtTemp, false);
                    dtTemp.Rows[indexUbica]["idKardex"] = idKardex;
                    dtTemp.Rows[indexUbica]["idRol"] = 1; // Fisicamente
                    dtTemp.Rows[indexUbica]["lCambioInfo"] = 1;
                    dtTemp.Rows[indexUbica]["idTipoPersona"] = (Convert.ToInt32(dtPerFisica.Rows[0]["idTipoPersona"]) == 1 && rbtnPerNat.Checked == true) ? Convert.ToString(1) : Convert.ToString(dtPerFisica.Rows[0]["idTipoPersona"]);
                    dtTemp.Rows[indexUbica]["idTipoDocumento"] = cboTipoDocumentoPerFis.SelectedValue.ToString();
                    dtTemp.Rows[indexUbica]["cDocumentoID"] = txtCBNroDocumentosPerFis.Text;
                    dtTemp.Rows[indexUbica]["cNombre"] = txtCBCNombrePerFis.Text;


                }
            }

            if (dtPerFisica == null)
            {
                DataRow dr = ((DataTable)dtgDatPerFis.DataSource).NewRow();
                dr["idKardex"] = idKardex;
                dr["idRol"] = 1; // Fisicamente
                dr["lCambioInfo"] = 0;
                dr["idCli"] = DBNull.Value;
                dr["idTipoPersona"] = (rbtnPerNat.Checked == true) ? Convert.ToString(1) : Convert.ToString(2);
                dr["cTipoPersona"] = (rbtnPerNat.Checked == true) ? "NATURAL" : "JURIDICA CON FINES LUCRO";
                dr["idTipoDocumento"] = cboTipoDocumentoPerFis.SelectedValue.ToString();
                dr["cTipoDocumento"] = ((DataTable)cboTipoDocumentoPerFis.DataSource).Rows[cboTipoDocumentoPerFis.SelectedIndex]["cTipoDocumento"];
                dr["cDocumentoID"] = txtCBNroDocumentosPerFis.Text;
                dr["cNombre"] = txtCBCNombrePerFis.Text;
                ((DataTable)dtgDatPerFis.DataSource).Rows.Add(dr);
                formatoGridBen(dtgDatPerFis);
            }
            //dtPerFisica.Clear();
            ActualizarBotonesFis(Inicio);
            limpiarDatosPerFisica();
            activarDatosPerFisica(false);
            dtPerFisica = null;
            btnEliminar1.Enabled = true;
        }

        private void cboTipoDocumentoPerFis_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarMaxLength(cboTipoDocumentoPerFis, txtCBNroDocumentosPerFis);
        }
        #endregion

        public void llenarDatosPersonaFisica()
        {
            dtPerFisica.AcceptChanges();
            if (dtPerFisica.Rows.Count > 0)
            {
                rbtnPerNat.Checked = (Convert.ToInt32(dtPerFisica.Rows[0]["idTipoPersona"]) == 1) ? true : false;
                rbtnPerJur.Checked = (Convert.ToInt32(dtPerFisica.Rows[0]["idTipoPersona"]) > 1) ? true : false;

                cboTipoDocumentoPerFis.SelectedValue = Convert.ToInt32(dtPerFisica.Rows[0]["idTipoDocumento"]);
                txtCBNroDocumentosPerFis.Text = dtPerFisica.Rows[0]["cDocumentoID"].ToString();
                txtCBCNombrePerFis.Text = dtPerFisica.Rows[0]["cNombre"].ToString();
            }
        }

        public void llenarDatosPersonaOrdena()
        {
            dtPerOrdena.AcceptChanges();
            if (dtPerOrdena.Rows.Count > 0)
            {
                rbtnPerNatOrd.Checked = (Convert.ToInt32(dtPerOrdena.Rows[0]["idTipoPersona"]) == 1) ? true : false;
                rbtnPerJurOrd.Checked = (Convert.ToInt32(dtPerOrdena.Rows[0]["idTipoPersona"]) > 1) ? true : false;
                txtCDatosOrdena.Text = dtPerOrdena.Rows[0]["cNombre"].ToString();
            }
            
        }

        private Boolean cargarDatosDeCliente(DataGridView dtg, string cMensajeExiste, ref DataTable dt)
        {
            FrmBusCli cliente = new FrmBusCli();
            cliente.ShowDialog();
            int idCliObt = (cliente.pcCodCli == null) ? 0 : Convert.ToInt32(cliente.pcCodCli);
            if (idCliObt != 0)
            {
                if (ExisteClienteEnGrid(dtg, idCliObt, cMensajeExiste)>=0)
                    return false;

                dt = cnOpeMult.CNRecuperarClienteOpeMult(idCliObt);
                foreach (DataColumn item in dt.Columns)
                    item.ReadOnly = false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si existe un cliente en un datagrid
        /// </summary>
        /// <param name="dtg">DataGridView donde se va a buscar el cliente</param>
        /// <param name="idCliBuscar">cliente a buscar</param>
        /// <param name="cMensajeExiste">Mensaje a mostrar si el cliente se encuentra en el dtg</param>
        /// <returns>-1 y 0 si encuentra o no el cliente respectivamente este es el index del dtg donde se encuentra</returns>
        private int ExisteClienteEnGrid(DataGridView dtg, int idCliBuscar, string cMensajeExiste)
        {
            int nReturn = -1;
            int idCli;
            foreach (DataRow item in ((DataTable)dtg.DataSource).Rows)
            {
                idCli = (item["idCli"] == DBNull.Value) ? 0 : Convert.ToInt32(item["idCli"]);
                if (idCli == idCliBuscar)
                {
                    MessageBox.Show(cMensajeExiste);
                    nReturn = ((DataTable)dtg.DataSource).Rows.IndexOf(item);
                }
            }
            return nReturn;
        }
       

        private void CambiarMaxLength(cboTipoDocumento cbo, txtCBDNI txt)
        {
            txt.Clear();
            txt.Focus();
            if (Convert.ToInt32(cbo.SelectedValue).In(1, 4, 11))
            {
                txt.lSoloNumeros = false;
            }
            else
            {
                txt.lSoloNumeros = true;
            }

            if (Convert.ToInt32(cbo.SelectedValue).In(1, 11))
            {
                txt.MaxLength = 8;

            }
            else if (Convert.ToInt32(cbo.SelectedValue) == 4)
            {
                txt.MaxLength = 11;
            }
            else
            {
                txt.MaxLength = 15;
            }

        }

        private void dtgDatPerFis_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            dtPerFisica = cnOpeMult.CNRecuperarClienteOpeMult(0);
            dtPerFisica.Columns["idCli"].AllowDBNull = true;
            
            dtPerFisica.ImportRow(((DataTable)dtgDatPerFis.DataSource).Rows[e.RowIndex]);
            llenarDatosPersonaFisica();
            activarDatosPerFisica(false);
            ActualizarBotonesFis(Nuevo);
            btnAceptar2.Enabled = false;
        }
        #region Actualizacion de Botones 
        private void ActualizarBotonesFis(string cEstado)
        {
            switch (cEstado) 
            {
                case Inicio:
                    btnBusCliente1.Enabled = false;
                    btnCancelar2.Enabled = false;
                    btnEditar2.Enabled = false;
                    btnNuevo2.Enabled = true;
                    btnAceptar2.Enabled =false;
                    //-----------------------------------
                    dtgDatPerFis.Enabled = true;
                    //-----------------------------------
                    break;
                case Editar:
                    btnBusCliente1.Enabled = false;
                    btnCancelar2.Enabled = true;
                    btnEditar2.Enabled = false;
                    btnNuevo2.Enabled = false;
                    btnAceptar2.Enabled =true;
                    //-----------------------------------
                    dtgDatPerFis.Enabled = true;
                    //-----------------------------------
                    break;
                case Nuevo:
                    btnBusCliente1.Enabled = true;
                    btnCancelar2.Enabled = true;
                    btnEditar2.Enabled = false;
                    btnNuevo2.Enabled = false;
                    btnAceptar2.Enabled = true;
                    //-----------------------------------
                    dtgDatPerFis.Enabled = true;
                    //-----------------------------------
                    break;
                case Vacio:
                case Guardado:
                    btnBusCliente1.Enabled = false;
                    btnCancelar2.Enabled = false;
                    btnEditar2.Enabled = false;
                    btnNuevo2.Enabled = false;
                    btnAceptar2.Enabled = false;
                    
                    //-----------------------------------
                    dtgDatPerFis.Enabled = false;
                    //-----------------------------------

                    break;
            }
        }

        private void ActualizarBotonesOrden(string cEstado)
        {
            switch (cEstado)
            {
                case Inicio:
                    btnBusCliente2.Enabled = false;
                    btnCancelar3.Enabled = false;
                    btnEditar3.Enabled = false;
                    btnNuevo3.Enabled = true;
                    btnAceptar1.Enabled = false;
                    //-----------------------------------
                    dtgDatOrden.Enabled = true;
                    //-----------------------------------
                    break;
                case Editar:
                    btnBusCliente2.Enabled = false;
                    btnCancelar3.Enabled = true;
                    btnEditar3.Enabled = false;
                    btnNuevo3.Enabled = false;
                    btnAceptar1.Enabled = true;
                    //-----------------------------------
                    dtgDatOrden.Enabled = true;
                    //-----------------------------------
                    break;
                case Nuevo:
                    btnBusCliente2.Enabled = true;
                    btnCancelar3.Enabled = true;
                    btnEditar3.Enabled = true;
                    btnNuevo3.Enabled = false;
                    btnAceptar1.Enabled = true;
                    //-----------------------------------
                    dtgDatOrden.Enabled = true;
                    //-----------------------------------
                    break;
                case Vacio:
                case Guardado:
                    btnBusCliente2.Enabled = false;
                    btnCancelar3.Enabled = false;
                    btnEditar3.Enabled = false;
                    btnNuevo3.Enabled = false;
                    btnAceptar1.Enabled = false;
                    //-----------------------------------
                    dtgDatOrden.Enabled = false;
                    //-----------------------------------
                    break;
            }
        }

        private void ActualizarBotonesGeneral(string cEstado)
        {
            switch (cEstado)
            {
                case Inicio:
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnImprimir2.Enabled = false;
                    btnImprimir1.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnSalir1.Enabled = false;
                    break;
                case Nuevo:
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnImprimir2.Enabled = false;
                    btnImprimir1.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnSalir1.Enabled = false;
                    break;
                case Editar:
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnImprimir2.Enabled = false;
                    btnImprimir1.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnSalir1.Enabled = false;
                    break;
                case Guardado:
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnImprimir2.Enabled = false;
                    btnImprimir1.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnSalir1.Enabled = false;
                    break;
                case Vacio:
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnImprimir2.Enabled = false;
                    btnImprimir1.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnSalir1.Enabled = true;
                    break;
                case Imprimir:
                    btnCancelar1.Enabled = true;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnImprimir2.Enabled = false;
                    btnImprimir1.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnSalir1.Enabled = true;
                    break;
            }
        }
        #endregion

        /// <summary>
        /// Cambia el readonly de todas las columnas
        /// </summary>
        /// <param name="dt">referencia del DataTable del cual el readonly de sus columnas serán cambiadas</param>
        /// <param name="lBol">true | false valor del ReadOnly de la Columna</param>
        private void ColumnsReadOnlyDt(ref DataTable dt, Boolean lBol)
        {
            if (dt != null)
                foreach (DataColumn item in dt.Columns)
                    item.ReadOnly = lBol;
        }

        private void btnEditar2_Click(object sender, EventArgs e)
        {
            if (dtPerFisica == null)
            {
                MessageBox.Show("No se ha seleccionado una persona", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            activarDatosPerFisica(true);
            ActualizarBotonesFis(Editar);
            lEditarFis = true;
        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            activarDatosPerFisica(false);
            limpiarDatosPerFisica();
            ActualizarBotonesFis(Inicio);
        }

        private void tbcDatosRegOpeMult_TabIndexChanged_1(object sender, EventArgs e)
        {
            MessageBox.Show("Evento", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        #region Tab PersonaOrdenante
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            if (((DataTable)dtgDatOrden.DataSource).Rows.Count > 0)
            {
                return;
            }

            var confCli = MessageBox.Show("¿La persona Ordenante es la misma que la persona física?", "SPLAFT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confCli == DialogResult.Yes)
            {
                DataTable dtTemporal  = ((DataTable) dtgDatPerFis.DataSource);
                DataTable dtTemporal2 = dtTemporal.Clone();
                dtTemporal.Columns["idRol"].ReadOnly = false;
                foreach (DataRow item in dtTemporal.Rows)
                {
                    item["idRol"] = 2;
                    dtTemporal2.ImportRow(item);
                    item["idRol"] = 1;
                }
                ((DataTable)dtgDatOrden.DataSource).Clear();
                dtgDatOrden.DataSource = dtTemporal2;
                btnEliminar2.Enabled = true;
            }
            
            activarDatosOrdenante(false);
            ActualizarBotonesOrden(Inicio);
        }

        private void dtgDatOrden_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtPerOrdena = cnOpeMult.CNRecuperarClienteOpeMult(0);
            permitirValoresNulos(ref dtPerOrdena);
            dtPerOrdena.ImportRow(((DataTable)dtgDatOrden.DataSource).Rows[e.RowIndex]);
            llenarDatosPersonaOrdena();
            activarDatosOrdenante(false);
            if (cAccion == Nuevo) 
            {
                ActualizarBotonesOrden(Nuevo);
                btnAceptar1.Enabled = false;
            }
            
        }

        private void btnCancelar3_Click(object sender, EventArgs e)
        {
            activarDatosOrdenante(false);
            limpiarDatosOrdenante();
            ActualizarBotonesOrden(Inicio);
        }

        private void btnEditar3_Click(object sender, EventArgs e)
        {
             if (dtPerOrdena == null)
            {
                MessageBox.Show("No se ha seleccionado una Persona", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            activarDatosOrdenante(true);
            ActualizarBotonesOrden(Editar);
            lEditaOrden = true;  
        }

        private void btnNuevo3_Click(object sender, EventArgs e)
        {
            activarDatosOrdenante(true);
            limpiarDatosOrdenante();
            ActualizarBotonesOrden(Nuevo);
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (!rbtnPerNatOrd.Checked && !rbtnPerJurOrd.Checked)
            {
                MessageBox.Show("Seleccione el tipo de Persona", "Persona Ordenante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtCDatosOrdena.Text.Trim().ToUpper()))
            {
                MessageBox.Show("Ingrese los apellidos y nombres de la persona", "Persona Ordenante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtPerOrdena != null && !lEditaOrden)
            {
                ColumnsReadOnlyDt(ref dtPerOrdena, false);
                dtPerOrdena.Rows[0]["idKardex"] = idKardex;
                dtPerOrdena.Rows[0]["idRol"] = 2; // Ordenante
                ((DataTable)dtgDatOrden.DataSource).ImportRow(dtPerOrdena.Rows[0]);
            }

            if (dtPerOrdena != null && lEditaOrden)
            {
                ColumnsReadOnlyDt(ref dtPerOrdena, false);
                int indexUbica = ExisteClienteEnGrid(dtgDatOrden, Convert.ToInt32((dtPerOrdena.Rows[0]["idCli"] == DBNull.Value) ? -1 : dtPerOrdena.Rows[0]["idCli"]), "Existe el cliente se procedera a actualizar info");
                if (indexUbica < 0)
                {
                    dtPerOrdena.Rows[0]["idKardex"] = idKardex;
                    dtPerOrdena.Rows[0]["idRol"] = 2; // Ordenante
                    dtPerOrdena.Rows[0]["lCambioInfo"] = 1;
                    dtPerOrdena.Rows[0]["idTipoPersona"] = (Convert.ToInt32(dtPerOrdena.Rows[0]["idTipoPersona"]) == 1 && rbtnPerNatOrd.Checked == true) ? Convert.ToString(1) : Convert.ToString(dtPerOrdena.Rows[0]["idTipoPersona"]);
                    dtPerOrdena.Rows[0]["cNombre"] = txtCDatosOrdena.Text;
                    ((DataTable)dtgDatOrden.DataSource).ImportRow(dtPerOrdena.Rows[0]);
                }
                else
                {
                    DataTable dtTemp = ((DataTable)dtgDatOrden.DataSource);
                    ColumnsReadOnlyDt(ref dtTemp, false);
                    dtTemp.Rows[indexUbica]["idKardex"] = idKardex;
                    dtTemp.Rows[indexUbica]["idRol"] = 2; // Ordenante
                    dtTemp.Rows[indexUbica]["lCambioInfo"] = 1;
                    dtTemp.Rows[indexUbica]["idTipoPersona"] = (Convert.ToInt32(dtPerOrdena.Rows[0]["idTipoPersona"]) == 1 && rbtnPerNat.Checked == true) ? Convert.ToString(1) : Convert.ToString(dtPerOrdena.Rows[0]["idTipoPersona"]);
                    dtTemp.Rows[indexUbica]["cNombre"] = txtCDatosOrdena.Text;
                }
            }

            if (dtPerOrdena == null)
            {
                DataRow dr = ((DataTable)dtgDatOrden.DataSource).NewRow();

                dr["idKardex"] = idKardex;
                dr["idRol"] = 2; // Ordenante
                dr["lCambioInfo"] = 0;
                dr["idCli"] = DBNull.Value;
                dr["idTipoPersona"] = (rbtnPerNatOrd.Checked == true) ? Convert.ToString(1) : Convert.ToString(2);
                dr["cTipoPersona"] = (rbtnPerNatOrd.Checked == true) ? "NATURAL" : "JURIDICA CON FINES LUCRO";
                dr["idTipoDocumento"] = DBNull.Value;
                dr["cTipoDocumento"] = DBNull.Value;
                dr["cDocumentoID"] = DBNull.Value;
                dr["cNombre"] = txtCDatosOrdena.Text;
                ((DataTable)dtgDatOrden.DataSource).Rows.Add(dr);
                formatoGridBen(dtgDatOrden);
            }

            ActualizarBotonesOrden(Inicio);
            limpiarDatosOrdenante();
            activarDatosOrdenante(false);
            dtPerOrdena = null;
            btnEliminar2.Enabled = true;
        }
        #endregion

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (dtgDatPerFis.RowCount == 0)
            {
                MessageBox.Show("No se ha ingresado a la persona física", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (dtgDatOrden.RowCount == 0)
            {
                MessageBox.Show("No se ha ingresado a la persona que ordena la operación", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (dtgDatPerBen.RowCount == 0)
            {
                MessageBox.Show("No hay beneficiario registrado", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtgOpeFrac.RowCount == 0)
            {
                MessageBox.Show("No hay operaciones fraccionarias, al menos debe haber una operacion multiple", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (rbtnInusualSi.Checked && lstDetalleInusual.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione un elemento de la lista de la sección inusual", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataSet dsGuardar = new DataSet("dsGuardar");

            DataTable dtPerFisicaG = new DataTable("dtPerFisicaG");
            DataTable dtPerOrdenaG = new DataTable("dtPerOrdenaG");
            DataTable dtPerBenefi = new DataTable("dtPerBenefi");
            DataTable dtOpeFrac = new DataTable("dtOpeFrac");

            dtPerFisicaG = ((DataTable)dtgDatPerFis.DataSource);
            dtPerOrdenaG = ((DataTable)dtgDatOrden.DataSource);
            dtPerBenefi = ((DataTable)dtgDatPerBen.DataSource);
            dtOpeFrac = ((DataTable)dtgOpeFrac.DataSource);

            dsGuardar.Tables.Add(dtPerFisicaG);
            dsGuardar.Tables.Add(dtPerOrdenaG);
            dsGuardar.Tables.Add(dtPerBenefi);
            dsGuardar.Tables.Add(dtOpeFrac);

            Boolean lInusual = rbtnInusualSi.Checked;
            int nGrupoInusual = Convert.ToInt32(cboInusualGrupo.SelectedValue);
            int nInusual = Convert.ToInt32(((DataTable)lstDetalleInusual.DataSource).Rows[Convert.ToInt32(lstDetalleInusual.SelectedIndex)]["idDetalleInusual"]);
            string cObser = txtObservacionesOpe.Text;

            string cDataSet = dsGuardar.GetXml();
            // guardando operacion multiples
            int idInusual = -1;
            int idDetalleInusual = -1;
            if (rbtnInusualSi.Checked)
            {
                idInusual = Convert.ToInt32(cboInusualGrupo.SelectedValue);
                idDetalleInusual = Convert.ToInt32(((DataTable)lstDetalleInusual.DataSource).Rows[lstDetalleInusual.SelectedIndex]["idDetalleInusual"]);
            }

            DataTable dtResultado = cnOpeMult.CNRegistrarOperacionMultiple(cDataSet         , idUmbral                                      , idKardex              , Convert.ToDateTime(txtFechaOperacion.Text)
                , dFechaHora                                        , Convert.ToDecimal(txtImporteOperacion.Text)   , Convert.ToDateTime(txtFechaInicioOperaciones.Text), Convert.ToDateTime(txtFechaFinOperaciones.Text)
                , Convert.ToDecimal(txtImporteTotOpeMult.Text)      , Convert.ToInt32(txtNroTotalOpeFrac.Text)      , idTipoOperacion       , idMonedaOpe       
                , rbtnInusualSi.Checked                             , idInusual
                , idDetalleInusual
                , idCuenta                                          , txtObservacionesOpe.Text                      , idModulo);

            MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
            {
                ActualizarBotonesGeneral(Guardado);
                ActualizarBotonesFis(Vacio);
                ActualizarBotonesOrden(Vacio);

                activarDatosPerFisica(false);
                activarDatosOrdenante(false);
                activarDatosBeneficiaria(false);
                activarDatosOperacion(false);
                btnEliminar1.Enabled = false;
                btnEliminar2.Enabled = false;
            }
        }

        private void rbtnInusualSi_CheckedChanged(object sender, EventArgs e)
        {
            cboInusualGrupo.Enabled = rbtnInusualSi.Checked;
            lstDetalleInusual.Enabled = rbtnInusualSi.Checked;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (idKardex == 0)
            {
                MessageBox.Show("Tiene que asignar un Nro de Kardex", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtRPTOpe = cnOpeMult.CNRptOperacionMultiple(idKardex);
            DataTable dtRPTPerFis = cnOpeMult.CNObtienePersonaRol(idKardex, 1);
            DataTable dtRPTPerOrd = cnOpeMult.CNObtienePersonaRol(idKardex, 2);
            DateTime dFeSis = clsVarGlobal.dFecSystem;


            if (dtRPTOpe.Rows.Count == 0)
            {
                MessageBox.Show("No hay operación multiple registrada con Nro de Kardex: " + idKardex.ToString(), cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string reportpath = "rptRegistroOperacionesMultiples.rdlc";


            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string AgenEmision = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            paramlist.Add(new ReportParameter("cNomEmp", cNomEmp, false));
            paramlist.Add(new ReportParameter("cNombreAge", AgenEmision, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cWinUser, false));
            paramlist.Add(new ReportParameter("cRutaLogo", Convert.ToString(clsVarApl.dicVarGen["CRUTALOGO"]), false));

            dtslist.Add(new ReportDataSource("dsRptOperacionesMultiples", dtRPTOpe));
            dtslist.Add(new ReportDataSource("dsPerFisica", dtRPTPerFis));
            dtslist.Add(new ReportDataSource("dsPerOpera", dtRPTPerOrd));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            ActualizarBotonesGeneral(Imprimir);

        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            txtNumeroKardex.Enabled = true;
            txtNumeroKardex.Clear();
            txtNumeroKardex.Focus();
            cAccion = Nuevo;
        }

        private void txtNumeroKardex_Enter(object sender, EventArgs e)
        {
            if (txtNumeroKardex.Text.Length > 0)
                cargarOpeMultiPorIdKardex(Convert.ToInt32(txtNumeroKardex.Text));
        }

        private void txtNumeroKardex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtNumeroKardex.Text.Length > 0) 
                {
                    idKardex = Convert.ToInt32(txtNumeroKardex.Text);
                    if (cAccion == Nuevo) 
                        cargarOpeMultiPorIdKardex(idKardex);

                    if (cAccion == Editar)
                        EditarOperacionMultiple(idKardex);
                }
            }

            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else 
            {
                e.Handled = true;
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            txtNumeroKardex.Enabled = true;
            txtNumeroKardex.Clear();
            txtNumeroKardex.Focus();
            cAccion = Editar;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            activarDatosBeneficiaria(false);
            activarDatosOperacion(false);
            activarDatosOrdenante(false);

            activarOperacionesFraccionarias(false);
            limpiarDatosBeneficiaria();
            limpiarDatosOperacion();
            limpiarDatosPerFisica();
            limpiarOperacionesFraccionarias();
            limpiarResumen();
            ActualizarBotonesGeneral(Vacio);

            ((DataTable)dtgDatPerFis.DataSource).Clear();
            ((DataTable)dtgDatOrden.DataSource).Clear();
        }

        private void txtCBLetra2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmRegOperacionesMultiples_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            eliminarPersonas(ref dtgDatPerFis);
        }

       

        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            eliminarPersonas(ref dtgDatOrden);
        }

        private void eliminarPersonas(ref dtgBase dtg)
        {
            if (dtg.RowCount == 0)
            {
                MessageBox.Show("No hay personas para eliminar de la tabla", "Registro de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dgRes = MessageBox.Show("Desea Eliminar a: " + dtg.Rows[dtg.SelectedRows[0].Index].Cells["cNombre"].Value.ToString(), "Registro de Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgRes == DialogResult.Yes)
            {
                DataTable dtTemp = ((DataTable)dtg.DataSource);
                dtTemp.Rows.RemoveAt(dtg.SelectedRows[0].Index);
                dtTemp.AcceptChanges();
                dtPerFisica.AcceptChanges();
                dtPerOrdena.AcceptChanges();
                dtg.DataSource = null;
                dtg.DataSource = dtTemp;
                formatoGridBen(dtg);
            }
        }

    }
}
