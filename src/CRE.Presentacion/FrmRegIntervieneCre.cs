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
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
using CLI.Servicio;

namespace CRE.Presentacion
{
    public partial class FrmRegIntervieneCre : frmBase
    {
        DataTable dtLisIntervSol = new DataTable();
        clsCNClienteVinculado cnvinculado = new clsCNClienteVinculado();
        GEN.CapaNegocio.clsCNSolicitud cnsolicitud = new clsCNSolicitud();
        int idProducto = 0;
        clsCNValidaReglasDinamicas cnregladinamica = new clsCNValidaReglasDinamicas();

        public FrmRegIntervieneCre()
        {
            InitializeComponent();
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[0,1,13,19]";
            conBusCli1.txtCodCli.Enabled = false;
        }

        private void FrmRegIntervieneCre_Load(object sender, EventArgs e)
        {
            base.activarControlObjetos(this, EventoFormulario.INICIO);
            cboTipoIntervCre1.listarTipoIntervRegCredito();
            cboTipoIntervCre1.SelectedValue = 3;
        }
        public void LimpiarControles()
        {
            conBusCuentaCli1.txtEstado.Clear();
            conBusCuentaCli1.txtNombreCli.Clear();
            conBusCuentaCli1.txtNroBusqueda.Clear();
            conBusCuentaCli1.txtNroDoc.Clear();
            conBusCuentaCli1.txtCodCli.Clear();

            conBusCli1.txtCodCli.Clear();
            conBusCli1.txtNombre.Clear();
            conBusCli1.txtNroDoc.Clear();
            conBusCli1.txtCodInst.Clear();
            conBusCli1.txtCodAge.Clear();
            idProducto = 0;

            cboTipoIntervCre1.SelectedValue = 1;
            if (dtgBase1.Rows.Count>0)
            {
                dtLisIntervSol.Rows.Clear();
            }
        
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            this.CargaDatos();
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            this.CargaDatos();
        }

        private string validarDatos()
        {
            Int32 nContIdIntCon = 0;
            int nIntervConvAval = 0;
            int nCantFiador = 0;
            if (string.IsNullOrEmpty(conBusCli1.txtNombre.Text.Trim()))
            {
                MessageBox.Show("Realice la Búsqueda del Cliente a Registrar", "Registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCli1.btnBusCliente.Focus();
                return "ERROR";
            }
            if ((int)cboTipoIntervCre1.SelectedValue == 1)
            {
                MessageBox.Show("Ya Existe el Titular del Crédito", "Registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoIntervCre1.Focus();
                return "ERROR";
            }
            if (dtgBase1.Rows.Count>=1)
            {
                for (int i = 0; i < dtgBase1.Rows.Count; i++)
                {
                    if(Convert.ToInt32(dtgBase1.Rows[i].Cells["idTipoInterv"].Value) == 2) // CONYUGUE
                    {
                        nContIdIntCon++;
                    }
                    if (Convert.ToInt32(dtgBase1.Rows[i].Cells["idTipoInterv"].Value) == 4) // CONYUGUE DE FIADOR
                    {
                        nIntervConvAval++;
                    }
                    if (Convert.ToInt32(dtgBase1.Rows[i].Cells["idTipoInterv"].Value) == 3) // FIADOR
                    {
                        nCantFiador++;
                    }

                    if (Convert.ToInt32(dtgBase1.Rows[i].Cells["idCli"].Value.ToString().Trim()) == Convert.ToInt32(conBusCli1.txtCodCli.Text.Trim()))
                    {
                        MessageBox.Show("Cliente ya se encuentra en la lista de intervinientes", "Registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conBusCli1.btnBusCliente.Focus();
                        return "ERROR";
                    }

                }

                if ((cboTipoIntervCre1.SelectedValue.ToString() == "2" && nContIdIntCon > 0))// || (cboTipoIntervCre1.SelectedValue.ToString() == "4" && nIntervConvAval > 0))
                {
                    MessageBox.Show("Ya existe un interviniente como cónyuge", "Registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboTipoIntervCre1.Focus();
                    return "ERROR";
                }
                // Valida que cantidad de conyugues de fiador sea menor o = a la cantidad de fiadores
                if ((cboTipoIntervCre1.SelectedValue.ToString() == "4" && nCantFiador < nIntervConvAval + 1))
                {
                    MessageBox.Show("Cantidad de cónyuges de fiador sobrepasa la cantidad de fiadores", "Registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboTipoIntervCre1.Focus();
                    return "ERROR";
                }

            }
            return "OK";


        }

        public void FormatoGrid()
        {
            this.dtgBase1.ReadOnly = false;

            foreach (DataGridViewColumn objColumn in this.dtgBase1.Columns)
            {
                objColumn.Visible = false;
                objColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            this.dtgBase1.Columns["cNombre"].Visible = true;
            this.dtgBase1.Columns["cTipoIntervencion"].Visible = true;
            this.dtgBase1.Columns["cNombre"].Visible = true;
            this.dtgBase1.Columns["lParticipa"].Visible = true;

            this.dtgBase1.Columns["cNombre"].HeaderText = "Cliente";
            this.dtgBase1.Columns["cTipoIntervencion"].HeaderText = "Vínculo";
            this.dtgBase1.Columns["lParticipa"].HeaderText = "Participa?";

            dtgBase1.Columns["cNombre"].ReadOnly = true;
            dtgBase1.Columns["cTipoIntervencion"].ReadOnly = true;

            this.dtgBase1.CellValueChanged -= dtgBase1_CellValueChanged;
            this.dtgBase1.CellValueChanged += dtgBase1_CellValueChanged;

                    }

        private bool validarScoreJornalero()
        {
            if (frmCreJorScoreCliente.esSolicitudJornalero(this.conBusCuentaCli1.nValBusqueda))
            {
                frmCreJorScoreCliente frmscorejornalero = new frmCreJorScoreCliente(
                this.conBusCuentaCli1.nIdCliente,
                this.conBusCuentaCli1.nValBusqueda
                );
                return frmscorejornalero.validar();
            }
            return true;
        }

        private void CargaDatos()
        {

            int nIdSol = conBusCuentaCli1.nValBusqueda;

            if (nIdSol == 0)
            {
                LimpiarControles();
                conBusCuentaCli1.txtNroBusqueda.Focus();
                this.btnGrabar1.Enabled = false;
                this.btnCancelar1.Enabled = false;
                return;
            }
            else
            {
                clsCNIntervCre IntervCre = new clsCNIntervCre();
                dtLisIntervSol = IntervCre.obtenerIntervinienteSolicitud(nIdSol, clsVarGlobal.idModulo, true,true);
                clsCNBuscarCli objBusCli = new clsCNBuscarCli();
                DataTable nidCli = objBusCli.DatosClientexNumSol(nIdSol);
                conBusCuentaCli1.nIdCliente = Convert.ToInt32(nidCli.Rows[0]["idCli"]);

                var dtsolicitud = cnsolicitud.ConsultaSolicitud(nIdSol);
                idProducto = Convert.ToInt32(dtsolicitud.Rows[0]["idProducto"]);

                if (dtLisIntervSol.Rows.Count == 0)
                {
                    DataRow dtRow = dtLisIntervSol.NewRow();
                    dtRow["idIntervCre"] = 0;
                    dtRow["idTipoInterv"] = 1;
                    dtRow["cTipoModif"] = "I";
                    dtRow["idCli"] = conBusCuentaCli1.nIdCliente;
                    dtRow["cNombre"] = conBusCuentaCli1.txtNombreCli.Text.ToString().Trim();
                    dtRow["cTipoIntervencion"] = "TITULAR";
                    dtRow["cDocumentoID"] = conBusCuentaCli1.txtNroDoc.Text;
                    dtRow["lConsulta"] = 0;
                    dtLisIntervSol.Rows.Add(dtRow);
                }

                var dtVinculados = cnvinculado.ListaClienteVinculado(conBusCuentaCli1.nIdCliente);
                var lisConyugue = dtVinculados.AsEnumerable().Where(x => (int)x["idTipoVinculo"] == 1).ToList();

                if (lisConyugue.Count > 0)
                {
                    var idCliConyugue = Convert.ToInt32(lisConyugue[0]["idCliVin"]);
                    DataTable dtRegConyuge = cnvinculado.CNBuscarRegistroConyuge(nIdSol, idCliConyugue);

                    var nYaSeRegistro = dtLisIntervSol.AsEnumerable().Where(x => (int)x["idCli"] == idCliConyugue).Count();


                    if (nYaSeRegistro == 0)
                    {
                        int nValida = Convert.ToInt32(dtRegConyuge.Rows[0]["nIdMsj"]);
                        string cMensaje = Convert.ToString(dtRegConyuge.Rows[0]["cIdMsj"]);

                        if (nValida == 1)
                        {
                            DialogResult cRespuesta = MessageBox.Show("¿Desea incluir de nuevo al cónyuge?" + cMensaje, "Registro de Intervinientes en el Crédito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (cRespuesta.Equals(DialogResult.Yes))
                            {
                                DataRow dtRow = dtLisIntervSol.NewRow();
                                dtRow["idIntervCre"] = 0;
                                dtRow["idTipoInterv"] = 2;
                                dtRow["cTipoModif"] = "I";
                                dtRow["idCli"] = idCliConyugue;
                                dtRow["cNombre"] = lisConyugue[0]["cNombre"].ToString().Trim();
                                dtRow["cTipoIntervencion"] = "CONYUGE";
                                dtRow["cDocumentoID"] = lisConyugue[0]["cDocumentoID"].ToString();
                                dtRow["lConsulta"] = 0;
                                dtLisIntervSol.Rows.Add(dtRow);
                            }
                        }
                        else
                        {
                            DataRow dtRow = dtLisIntervSol.NewRow();
                            dtRow["idIntervCre"] = 0;
                            dtRow["idTipoInterv"] = 2;
                            dtRow["cTipoModif"] = "I";
                            dtRow["idCli"] = idCliConyugue;
                            dtRow["cNombre"] = lisConyugue[0]["cNombre"].ToString().Trim();
                            dtRow["cTipoIntervencion"] = "CONYUGE";
                            dtRow["cDocumentoID"] = lisConyugue[0]["cDocumentoID"].ToString();
                            dtRow["lConsulta"] = 0;
                            dtLisIntervSol.Rows.Add(dtRow);
                        }
                    }


                    //if (nYaSeRegistro == 0)
                    //{
                    //    DataRow dtRow = dtLisIntervSol.NewRow();
                    //    dtRow["idIntervCre"] = 0;
                    //    dtRow["idTipoInterv"] = 2;
                    //    dtRow["cTipoModif"] = "I";
                    //    dtRow["idCli"] = idCliConyugue;
                    //    dtRow["cNombre"] = lisConyugue[0]["cNombre"].ToString().Trim();
                    //    dtRow["cTipoIntervencion"] = "CONYUGE";
                    //    dtRow["cDocumentoID"] = lisConyugue[0]["cDocumentoID"].ToString();
                    //    dtRow["lConsulta"] = 0;
                    //    dtLisIntervSol.Rows.Add(dtRow);
                    //}

                }

                var lisRepresentantes = dtVinculados.AsEnumerable().Where(x => (int)x["idTipoVinculo"] == 2).ToList();

                if (lisRepresentantes.Count > 0)
                {
                    foreach (DataRow item in lisRepresentantes)
                    {
                        var idCliRepresentante = Convert.ToInt32(item["idCliVin"]);
                        var nYaSeRegistro = dtLisIntervSol.AsEnumerable().Where(x => (int)x["idCli"] == idCliRepresentante).Count();
                        if (nYaSeRegistro == 0)
                        {
                            DataRow dtRow = dtLisIntervSol.NewRow();
                            dtRow["idIntervCre"] = 0;
                            dtRow["idTipoInterv"] = 9;
                            dtRow["cTipoModif"] = "I";
                            dtRow["idCli"] = idCliRepresentante;
                            dtRow["cNombre"] = item["cNombre"].ToString().Trim();
                            dtRow["cTipoIntervencion"] = "REPRESENTANTE";
                            dtRow["cDocumentoID"] = item["cDocumentoID"].ToString();
                            dtRow["lConsulta"] = 0;
                            dtLisIntervSol.Rows.Add(dtRow);
                        }
                    }
                }

                dtgBase1.DataSource = dtLisIntervSol;
                FormatoGrid();
                dtgBase1.Focus();
                this.btnGrabar1.Enabled = true;
                this.btnCancelar1.Enabled = true;
                this.btnAgregar1.Enabled = true;
                this.btnQuitar1.Enabled = true;
                this.conBusCli1.txtCodCli.Enabled = true;
                this.conBusCli1.btnBusCliente.Enabled = true;
                this.cboTipoIntervCre1.Enabled = true;
                }

            }

        private string ValidaCliVin()
        {
            clsCNRetDatosCliente xRetDatCli = new clsCNRetDatosCliente();

            string cValidacion = xRetDatCli.RetDatVal(Convert.ToInt32(conBusCli1.txtCodCli.Text.Trim()), "", "E",1);
            string idSexoTit = xRetDatCli.RetDatVal(Convert.ToInt32(conBusCli1.txtCodCli.Text.Trim()), "", "S",1);
            string idSexoVin = xRetDatCli.RetDatVal(Convert.ToInt32(conBusCuentaCli1.nIdCliente), "", "S",1);
            //======================================================================
            //--Validar Duplicidad de Clientes (Documentos Duplicado)
            //======================================================================
            if (cValidacion == "ERROR" && Convert.ToInt32(conBusCli1.nidTipoPersona) == 1)
            {
                MessageBox.Show("El  Cliente Buscado es Menor de Edad, debe ser mayor de 18 Años", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCli1.btnBusCliente.Focus();
                return "ERROR";
            }
            //======================================================================
            //--Validar sexo del conyuge
            //======================================================================

            if (idSexoTit == idSexoVin && cboTipoIntervCre1.SelectedValue.ToString() == "2")
            {
                MessageBox.Show("No se puede vincular como cónyuges a dos personas del mismo sexo", "Registro de INtervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCli1.btnBusCliente.Focus();
                return "ERROR";
            }
            return "OK";
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (validarDatos() == "ERROR")
            {
                return;
            }

            clsCNClienteVinculado ListaClienteVinculado = new clsCNClienteVinculado();
            DataTable dtInterviniente = ListaClienteVinculado.generarIntervinienteNuevo(conBusCli1.idCli, Convert.ToInt32(this.cboTipoIntervCre1.SelectedValue), true);

            if (ValidaCliVin() == "ERROR")
            {
                return;
            }

            foreach (DataRow objRow in dtInterviniente.Rows)
            {
                dtLisIntervSol.Rows.Add(objRow.ItemArray);
            }

            conBusCli1.txtCodCli.Clear();
            conBusCli1.txtNombre.Clear();
            conBusCli1.txtNroDoc.Clear();
            conBusCli1.txtCodInst.Clear();
            conBusCli1.txtCodAge.Clear();
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.txtCodCli.Focus();
        }
        /// <summary>
        /// Se agrego la comprobacion si se puede elimiar al conyugue del titular del credito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            //Validando Que no se Elimine al Titular
            dtLisIntervSol.Columns["cTipoModif"].ReadOnly = false;
            if(dtgBase1.Rows.Count <=1)
            {
                MessageBox.Show("No se puede Eliminar al Titular Del Crédito", "Registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (dtgBase1.SelectedCells.Count==0)
                {
                    MessageBox.Show("Debe Seleccionar el Cliente a Eliminar", "Registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    int nFilaActual = Convert.ToInt32(this.dtgBase1.SelectedCells[0].RowIndex);

                    string cProdQuitaConyugue = clsVarApl.dicVarGen["cProdQuitaConyuque"];
                    var lista = cProdQuitaConyugue.Split(',');
                    var lExisteProd = lista.Where(x => x == idProducto.ToString()).Count();

                    if (dtgBase1.Rows[nFilaActual].Cells["idTipoInterv"].Value.ToString() == "3") // si es fiador solidiario el que se quiere quitar
                    {
                        int idCliFiador = Convert.ToInt32(dtgBase1.Rows[nFilaActual].Cells["idCli"].Value);
                        for (int i = 0; i < dtgBase1.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dtgBase1.Rows[i].Cells["idCliVin"].Value) == idCliFiador)
                            {
                                MessageBox.Show("El interviniente " + dtgBase1.Rows[i].Cells["cTipoIntervencion"].Value.ToString() +
                                " de nombre " + dtgBase1.Rows[i].Cells["cNombre"].Value.ToString() + " también será eliminado.",
                                "Eliminación de Fiador Solidario", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                if (dtgBase1.Rows[i].Cells["cTipoModif"].Value.ToString() == "I")
                                {
                                    dtgBase1.Rows.RemoveAt(i);
                                }
                                else
                                {
                                    dtgBase1.Rows[i].Cells["cTipoModif"].Value = "D";
                                }
                                break;
                            }
                        }
                    }

                    if (dtgBase1.Rows[nFilaActual].Cells["idTipoInterv"].Value.ToString() == "1")
                    {
                        MessageBox.Show("No se puede Eliminar al Titular del Crédito", "Registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (Convert.ToInt32(dtgBase1.Rows[nFilaActual].Cells["idTipoInterv"].Value).In(2,4) && !quitarConyugue() && lExisteProd == 0)
                    {
                        MessageBox.Show("No se permite eliminar al cónyuge del titular o fiador solidario del crédito.", "Registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        if (dtgBase1.Rows[nFilaActual].Cells["cTipoModif"].Value.ToString() == "I")
                        {
                            dtgBase1.Rows.RemoveAt(nFilaActual);
                        }
                        else
                        {
                            dtgBase1.Rows[nFilaActual].Cells["cTipoModif"].Value = "D";
                        }

                        ProcessTabKey(true);
                        this.btnQuitar1.Focus();
                        dtLisIntervSol.DefaultView.RowFilter = ("cTipoModif <> 'D'");
                    }
                }
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtLisIntervSol.Rows.Clear();
            LimpiarControles();
            //  conBusCuentaCli1.Enabled = true;
            this.conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Focus();
            conBusCli1.txtCodCli.Enabled = false;
            conBusCli1.btnBusCliente.Enabled = false;
            conBusCuentaCli1.btnBusCliente1.Enabled = true;
            this.btnGrabar1.Enabled = false;
            this.btnAgregar1.Enabled = false;
            this.btnQuitar1.Enabled = false;
            this.cboTipoIntervCre1.Enabled = false;
            this.btnCancelar1.Enabled = false;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validarReglas() == "NoCumple")
            {
                return;
            }

            consultarReniecIntervinientes();

            string cIdNumSol = conBusCuentaCli1.txtNroBusqueda.Text.Trim();
            string cCodUsu = clsVarGlobal.User.idUsuario.ToString(); ;
            DateTime dFechReg = clsVarGlobal.dFecSystem;
            //metodo de rastreo
            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli1.nIdCliente), 0, "Inicio - Registro de Intervinientes", btnGrabar1);
            DataSet dsIntervCre = new DataSet("dsIntervCred");
            dsIntervCre.Tables.Add(dtLisIntervSol);
            string xmlIntervCre = dsIntervCre.GetXml();
            xmlIntervCre = clsCNFormatoXML.EncodingXML(xmlIntervCre);
            dsIntervCre.Tables.Clear();

            clsCNIntervCre GuardaIntervCre = new clsCNIntervCre();
            DataTable dtResp = GuardaIntervCre.GuardarIntervCre(Convert.ToInt32(cIdNumSol), cCodUsu, dFechReg, xmlIntervCre);

            if (Convert.ToInt32(dtResp.Rows[0]["nResultado"]) > 0)
            {

                MessageBox.Show("Los Datos se guardaron Correctamente", "Registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al intentar guardar los datos", "Registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.btnGrabar1.Enabled=false;
            this.btnAgregar1.Enabled = false;
            this.btnQuitar1.Enabled = false;
            this.cboTipoIntervCre1.Enabled = false;
            this.conBusCli1.txtCodCli.Enabled = false;
            this.conBusCli1.btnBusCliente.Enabled = false;
            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli1.nIdCliente), 0, "Fin - Registro de Intervinientes", btnGrabar1);
           
        }


        /// <summary>
        /// Consultar si el perfil puede o no quitar a conyugue de la lista de intervinientes
        /// </summary>
        /// <returns>Si puede o no quitar conyugue</returns>
        public bool quitarConyugue()
        {
            clsCNIntervCre GuardaIntervCre = new clsCNIntervCre();
            DataTable dtResultadoPermiso = GuardaIntervCre.validaPermisoQuitarConyugue(clsVarGlobal.PerfilUsu.idPerfil);
            if (dtResultadoPermiso.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtResultadoPermiso.Rows[0][0].ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        private DataTable ArmarTablaParametros(int idCli, int idTipoInterv)
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "dniInterv";
            drfila[1] = "'" + conBusCli1.txtNroDoc.Text.Trim() + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliInterv";
            drfila[1] = idCli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoInterv";
            drfila[1] = idTipoInterv;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPerInterv";
            drfila[1] = conBusCli1.nidTipoPersona.ToString();
            dtTablaParametros.Rows.Add(drfila);

            var nIdClasifInterna=conBusCli1.nIdClasifInterna;
            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idClasiInterCliInterv";
            drfila[1] = nIdClasifInterna.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUserPersonal";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

                drfila = dtTablaParametros.NewRow();
                drfila[0] = "dFechaActual";
                drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
                dtTablaParametros.Rows.Add(drfila);
         

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "SubProducto";
            drfila[1] = idProducto.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNomAge";
            drfila[1] = "'" + clsVarGlobal.cNomAge.Trim() + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCanal";
            drfila[1] = clsVarGlobal.idCanal.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nITF";
            drfila[1] = clsVarGlobal.nITF.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfilUsu";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfilUsu.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "lVigente";
            drfila[1] = clsVarGlobal.PerfilUsu.lVigente.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaIngreso";
            drfila[1] = "'" + clsVarGlobal.User.dFechaIngreso.ToString("yyyy-MM-dd") +"'" ;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargo";
            drfila[1] = clsVarGlobal.User.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstado";
            drfila[1] = clsVarGlobal.User.idEstado.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacSol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacSol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacDol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacDol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimIndividual";
            drfila[1] = clsVarApl.dicVarGen["nLimIndividual"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimGlobal";
            drfila[1] = clsVarApl.dicVarGen["nLimGlobal"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nProcentaje";
            drfila[1] = clsVarApl.dicVarGen["nPorcAmpCre"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCapitalSocialYReservas";
            drfila[1] = clsVarApl.dicVarGen["nCapitalSocialYReservas"];
            dtTablaParametros.Rows.Add(drfila);


            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModulo";
            drfila[1] = clsVarGlobal.idModulo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = conBusCuentaCli1.nValBusqueda;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaSistema";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            /*** Agrega idCli Fiadores en una sola cadena ***/
            string cIdCliFiadores = "";

            if (dtgBase1.DataSource != null && dtgBase1.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dtgBase1.Rows)
                {
                    if (Convert.ToInt32(item.Cells[4].Value) == 3 && Convert.ToBoolean(item.Cells[9].Value) == true)
                    {
                        cIdCliFiadores = cIdCliFiadores + "," + item.Cells[2].Value.ToString();
                    }
                }

                if (!String.IsNullOrEmpty(cIdCliFiadores))
                {
                    cIdCliFiadores = cIdCliFiadores.Substring(1);
                }
            }

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cIdCliFiadores";
            drfila[1] = "'" + cIdCliFiadores + "'";
            dtTablaParametros.Rows.Add(drfila);

            /*** Agrega idCli Fiadores y sus cónyuges en una sola cadena ***/
            string cIdCliFiadoresConyuges = "";

            if (dtgBase1.DataSource != null && dtgBase1.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dtgBase1.Rows)
                {
                    if ((Convert.ToInt32(item.Cells[4].Value) == 3 || Convert.ToInt32(item.Cells[4].Value) == 4) && Convert.ToBoolean(item.Cells[9].Value) == true)
                    {
                        cIdCliFiadoresConyuges = cIdCliFiadoresConyuges + "," + item.Cells[2].Value.ToString();
                    }
                }

                if (!String.IsNullOrEmpty(cIdCliFiadoresConyuges))
                {
                    cIdCliFiadoresConyuges = cIdCliFiadoresConyuges.Substring(1);
                }
 
            }

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cIdCliFiadoresConyuges";
            drfila[1] = "'" + cIdCliFiadoresConyuges + "'";
            dtTablaParametros.Rows.Add(drfila);


            return dtTablaParametros;
        }
        private string validarReglas()
        {
            int c = 0;
            string cCumpleReglas = string.Empty;
            for (int i = 0; i < dtgBase1.Rows.Count; i++)
            {
                if (dtgBase1.Rows[i].Cells["idTipoInterv"].Value.ToString() == "3" || dtgBase1.Rows[i].Cells["idTipoInterv"].Value.ToString() == "2")
                {
                    c++;
                    int nNivAuto = 0;
                    cCumpleReglas = cnregladinamica.ValidarReglasCreditos(ArmarTablaParametros(Convert.ToInt32(dtgBase1.Rows[i].Cells["idCli"].Value.ToString()),Convert.ToInt32(dtgBase1.Rows[i].Cells["idTipoInterv"].Value.ToString())), this.Name,
                                                                           clsVarGlobal.nIdAgencia, Convert.ToInt32(dtgBase1.Rows[i].Cells["idCli"].Value.ToString()),
                                                                           1, 1, idProducto, 0, conBusCuentaCli1.nValBusqueda, clsVarGlobal.dFecSystem,
                                                                           2, 1,
                                                                           clsVarGlobal.User.idUsuario, ref nNivAuto,true);

                }

            }
            if (c==0)
            {
                var dtVinculados = cnvinculado.DesactivarReglaFiado(conBusCuentaCli1.nValBusqueda, this.Name);
            }
            return cCumpleReglas;

        }

        private void consultarReniecIntervinientes()
        {
            int lNulos = 0; string dniNulos = "";
            for (int n = 0; n <= 3; n++ )
            {
                lNulos = 0; dniNulos = "";
                for (int i = 0; i < dtgBase1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtgBase1.Rows[i].Cells["lConsulta"].Value) == 0)
                    {
                        clsCliParamEnvioReniec objParam = new clsCliParamEnvioReniec(Convert.ToString(dtgBase1.Rows[i].Cells["cDocumentoID"].Value), clsVarGlobal.User.idUsuario, 1);
                        clsConfReniec objReniec = new clsConfReniec(clsVarApl.dicVarGen["cServicioWCFRen"]);
                        clsReniec obj = new clsReniec(objParam, objReniec);
                        clsProcesaDatosRen objTitular = obj.GetReniec();

                        if (objTitular == null)
                        {
                            lNulos++;
                            if (dniNulos != "")
                                dniNulos = dniNulos + ", ";
                            dniNulos = dniNulos + dtgBase1.Rows[i].Cells["cDocumentoID"].Value;
                        }
                        else
                        {
                            dtgBase1.Rows[i].Cells["cDocumentoID"].Value = 1;
                        }
                    }
                }
                if (lNulos == 0)
                {
                    break;
                }
            }

            if (lNulos > 0)
            {
                MessageBox.Show("Ocurrió un error al intentar consultar a RENIEC los DNI's " + dniNulos + ", favor de consultar con el Dpto. Soporte, Infraestructura y Comunicaciones", "Registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void dtgBase1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string columnName = this.dtgBase1.Columns[e.ColumnIndex].Name;
            int idTipoInterv = Convert.ToInt32(dtgBase1.Rows[e.RowIndex].Cells["idTipoInterv"].Value);

            if (columnName.Equals("lParticipa"))//CONYUGE TITULAR, CONYUGE DE FIADOR SOLIDARIO
            {
                if (!idTipoInterv.In(2, 4))
                {
                    dtgBase1.CellValueChanged -= dtgBase1_CellValueChanged;
                    dtgBase1.Rows[e.RowIndex].Cells["lParticipa"].Value = true;
                    dtgBase1.RefreshEdit();
                    dtgBase1.CellValueChanged += dtgBase1_CellValueChanged;
                }
            }
        }

    }
}
