using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;
using System.Text.RegularExpressions;
using System.Drawing;

namespace SolIntEls
{
    public partial class frmReglasDinamicas : frmBase
    {
        #region Variables Globales

        clsCNValidaReglasDinamicas ReglasDinamicas = new clsCNValidaReglasDinamicas();
        clsCNMenu cnmenu = new clsCNMenu();
        DataTable dtFunciones = new DataTable("dtFunciones");
        DataTable dtReglas = new DataTable("dtReglas");
        DataTable dtListaOpciones = new DataTable("dtListaOpciones");
        int nIndicaFoco = 0;//Se utilizará para validar donde insertar las funciones
        int nIdRegla = 0;//Servirá cuando se edite
        int nIdTipoOperacion = 0;
        int nNumOrden = 0; //contiene el orden de ejecución de la regla
        int nfilaActualSeleccionada = 0;//Es la fila actual del grid de Reglas
        Transaccion eAccion = Transaccion.Selecciona;
        
        #endregion
   
        public frmReglasDinamicas()
        {
            InitializeComponent();
            CargarCombos();

        }

        #region Eventos

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (grbDetallesRegla.Enabled == true)//Se está insertando una nueva Regla, puede haber o no nuevas funciones(inserción ó actualización de funciones)
            {
                if (txtMensajeError.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Debe ingresar un Mensaje de Error para la REGLA DINÁMICA", "Validar Regla Dinámica:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMensajeError.Focus();
                    return;
                }
                if (txtCaracteristica.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Debe ingresar la Característica para la REGLA DINÁMICA", "Validar Regla Dinámica:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCaracteristica.Focus();
                    return;
                }

                //Validar que la característica esté entre paréntesis si es diferente a 1
                if (txtCaracteristica.Text.Trim().Equals("1") == false)
                {
                    string cadenaCaracteristica = txtCaracteristica.Text.Trim();
                    if (cadenaCaracteristica[0].Equals('(') == false)
                    {
                        MessageBox.Show("Si la carcterística es diferente a 1, entonces:" +Environment.NewLine +"Debe comenzar con (", "Validar sintaxis Característica:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCaracteristica.Focus();
                        return;
                    }
                    if (cadenaCaracteristica[cadenaCaracteristica.Length - 1].Equals(')') == false)
                    {
                        MessageBox.Show("Si la carcterística es diferente a 1, entonces:" + Environment.NewLine + "Debe terminar con )", "Validar sintaxis Característica:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCaracteristica.Focus();
                        return;
                    }
                }
                                               

                if (txtRegla.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Debe ingresar la REGLA DINÁMICA", "Validar Regla Dinámica:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRegla.Focus();
                    return;
                }

                {
                    //Validar que la regla esté entre paréntesis
                    string cadenaRegla = txtRegla.Text.Trim();
                    if (cadenaRegla[0].Equals('(') == false)
                    {
                        MessageBox.Show("La regla debe comnezar con (", "Validar sintaxis Regla:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRegla.Focus();
                        return;
                    }
                    if (cadenaRegla[cadenaRegla.Length - 1].Equals(')') == false)
                    {
                        MessageBox.Show("La regla debe terminar con )", "Validar sintaxis Regla:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRegla.Focus();
                        return;
                    }

                    //Validar que la cantidad de paréntesis de apertura sea igual a la cantidad de paréntesis de cierre
                    int nCantAbreParentesis     = new System.Text.RegularExpressions.Regex("[(]").Matches(txtRegla.Text).Count;
                    int nCantCierreParentesis   = new System.Text.RegularExpressions.Regex("[)]").Matches(txtRegla.Text).Count;

                    if (nCantAbreParentesis != nCantCierreParentesis)
                    {
                        MessageBox.Show("La cantidad de paréntesis de apertura no coincide con la cantidad de paréntesis de cierre en el campo REGLA.", "Validar sintaxis Regla:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRegla.Focus();
                        return;
                    }

                    nCantAbreParentesis = new System.Text.RegularExpressions.Regex("[(]").Matches(txtCaracteristica.Text).Count;
                    nCantCierreParentesis = new System.Text.RegularExpressions.Regex("[)]").Matches(txtCaracteristica.Text).Count;

                    if (nCantAbreParentesis != nCantCierreParentesis)
                    {
                        MessageBox.Show("La cantidad de paréntesis de apertura no coincide con la cantidad de paréntesis de cierre en el campo CARACTERÍSTICA.", "Validar sintaxis Regla:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCaracteristica.Focus();
                        return;
                    }

        #region  InsertaActualizaReglaConExcepcion
                    if (chcExcepcion.Checked == true)//Se va insertar una Regla con Excepción
                    {
                        if (Convert.ToUInt32(cboTipoOperacion1.SelectedValue) <= 0)
                        {
                            MessageBox.Show("Debe Seleccionar el TIPO DE OPERACIÓN EXCEPCIÓN para la REGLA DINÁMICA", "Validar Regla Dinámica:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        
                        if (txtCampoExcepcionar.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Debe ingresar el CAMPO a EXCEPCIONAR en la REGLA DINÁMICA", "Validar sintaxis Regla Dinámica:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCampoExcepcionar.Focus();
                            return;
                        }

                        //Validar que el campo a excepcionar sea una parte de la Regla
                        int nExcepcionParteDeRegla = txtRegla.Text.ToUpper().IndexOf(txtCampoExcepcionar.Text.ToUpper());
                        if (nExcepcionParteDeRegla < 0)
                        {
                            MessageBox.Show("La EXCEPCIÓN ingresada no forma parte de la REGLA.", "Validar Regla Dinámica:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCampoExcepcionar.Focus();
                            return;
                        }

                        //Validar sintaxis del Nombre de las funciones
                        //true: Existen Errores de sinatxis
                        //False:No Existen Errores de sinatxis
                        Boolean lExistenErrores = ValidaSintaxisFunciones();
                        if (lExistenErrores == true)
                        {
                            return;
                        }

                        if (EsIgualLaCantParentesisEnFunciones() == false)
                        {
                            return;
                        } 

                        //Verificar las Funciones que se hayan editado, actualiza sus campos y su estado lActualiza
                        VerificarFuncionesModificadas();

                        //Validar que las funciones a eliminar no se estéen usando actualmente en las Reglas para la opción Seleccionada
                        //true: Existen errores 
                        //false:No existen errores
                        lExistenErrores = ValidarEliminacionFunciones();
                        if (lExistenErrores)
                        {
                            btnQuitar1.Enabled = true;
                            return;
                        }

                        //Si no se realizado ninguna modificación, no se debe permitir guardar
                        if (BuscarCambios() == false)//No se encontró cambios
                        {
                            MessageBox.Show("No ha realizado ningún cambio que pueda Guardarse", "Guardar Reglas Dinámicas:.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        ValidarConsistenciaReglas();
                        
                        DataSet ds = new DataSet("dsReglasDinamicas");
                        dtFunciones.TableName = "dtFunciones";
                        ds.Tables.Add(ArmarNuevaRegla(eAccion));
                        ds.Tables.Add(dtFunciones);
                        string XmlRegla = ds.GetXml();
                        XmlRegla = clsCNFormatoXML.EncodingXML(XmlRegla);

                        DataTable dtResultado = ReglasDinamicas.InsReglaDinamica(XmlRegla);
                        MessageBox.Show("El guardado se realizó satisfactoriamente", "Guardar Reglas Dinámicas:.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DeshabilitarBotones();
                        grbExcepcion.Enabled = false;
                    }
        #endregion
        #region  InsertaActualizaReglaSinExcepcion
                    else //Se va insertar una Reglas sin excepciones
                    {
                        //Validar sintaxis del Nombre de las funciones
                        //true: Existen Errores de sinatxis
                        //False:No Existen Errores de sinatxis
                        Boolean lExistenErrores = ValidaSintaxisFunciones();
                        if (lExistenErrores == true)
                        {
                            return;
                        }

                        if (EsIgualLaCantParentesisEnFunciones() == false)
                        {
                            return;
                        } 

                        //Verificar las Funciones que se hayan editado, actualiza sus campos y su estado lActualiza
                        VerificarFuncionesModificadas();

                        //Validar que las funciones a eliminar no se estéen usando actualmente en las Reglas para la opción Seleccionada
                        //true: Existen errores 
                        //false:No existen errores
                        lExistenErrores = ValidarEliminacionFunciones();
                        if (lExistenErrores)
                        {
                            btnQuitar1.Enabled = true;
                            return;
                        }

                        //Si no se realizado ninguna modificación, no se debe permitir guardar
                        if (BuscarCambios() == false)//No se encontró cambios
                        {
                            MessageBox.Show("No ha realizado ningún cambio que pueda Guardarse", "Guardar Reglas Dinámicas:.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        ValidarConsistenciaReglas();
                        
                        DataSet ds = new DataSet("dsReglasDinamicas");
                        dtFunciones.TableName = "dtFunciones";
                        ds.Tables.Add(ArmarNuevaRegla(eAccion));
                        ds.Tables.Add(dtFunciones);
                        string XmlRegla = ds.GetXml();
                        XmlRegla = clsCNFormatoXML.EncodingXML(XmlRegla);

                        DataTable dtResultado = ReglasDinamicas.InsReglaDinamica(XmlRegla);
                        MessageBox.Show("El guardado se realizó satisfactoriamente", "Guardar Reglas Dinámicas:.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DeshabilitarBotones();
                    }
        #endregion
                }
            }
            else//Sólo se está insertando Funciones (Actualización o inserción) -- Y actualizando estado de Reglas (cambia su estado Vigente o no vigente, también puede cambiar el orden de validación).
            {
                //Validar sintaxis del Nombre de las funciones
                //true: Existen Errores de sintxais
                //False:No Existen Errores de sintaxis
                Boolean lExistenErrores = ValidaSintaxisFunciones();
                if (lExistenErrores)
                {
                    return;
                }

                if (EsIgualLaCantParentesisEnFunciones() == false)
                {
                    return;
                } 

                //Verificar las Funciones que se hayan editado, actualiza sus campos y su estado lActualiza
                VerificarFuncionesModificadas();

                //Validar que las funciones a eliminar no se estéen usando actualmente en las Reglas para la opción Seleccionada
                //true: Existen errores 
                //false:No existen errores
                lExistenErrores = ValidarEliminacionFunciones();
                if (lExistenErrores)
                {
                    btnQuitar1.Enabled = true;
                    return;
                }

                ValidarConsistenciaReglas();

                DataSet dsReglasDinamicas = new DataSet("dsReglasDinamicas");
                dtFunciones.TableName = "dtFunciones";
                dtReglas.TableName="dtNuevaRegla";
                dsReglasDinamicas.Tables.Add(dtReglas);
                dsReglasDinamicas.Tables.Add(dtFunciones);
                string XmlRegla = dsReglasDinamicas.GetXml();
                XmlRegla = clsCNFormatoXML.EncodingXML(XmlRegla);

                DataTable dtResultado = ReglasDinamicas.InsReglaDinamica(XmlRegla);
                MessageBox.Show("El guardado se realizó satisfactoriamente", "Guardar Reglas Dinámicas:.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DeshabilitarBotones();

                cboModulo1.Enabled      = false;
                this.cboMenu1.Enabled = false;
            }
        }
        
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            eAccion = Transaccion.Selecciona; //  1:    Inserción
                            //  2:    Edición

            string cOpcion = "";
            if (cboMenu1.SelectedNode!= null)
            {
                cOpcion = cboMenu1.SelectedNode.Text;
            }            
            LimpiarControles();
            cboModulo1_SelectedIndexChanged(sender, e);
            cboMenu1.SelectedNode = cboMenu1.Nodes.Find(cOpcion, StringComparison.Ordinal, true);

            validaNuevo();
        }

        private void validaNuevo()
        {
            if (cboMenu1.SelectedNode == null)
            {
                btnNuevo1.Enabled = false;
            }
            else
            {
                if (cboMenu1.SelectedNode.Name == "")
                {
                    btnNuevo1.Enabled = false;
                }
                else
                {
                    btnNuevo1.Enabled = true;
                }
            }
        }

        private void cboModulo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModulo1.SelectedIndex > -1)
            {
                int nIdModulo = Convert.ToInt32(cboModulo1.SelectedValue);
                if (nIdModulo > 0)
                {
                    cboTipoOperacion1.LisTipoOperacModulo(Convert.ToInt32(cboModulo1.SelectedValue));

                    var dtMenu = cnmenu.listarMenuVigentes(nIdModulo);
                    cargarOpcionesMenu(dtMenu);
                }
                else
                {
                    var dtMenu = cnmenu.listarMenuVigentes(0);
                    cargarOpcionesMenu(dtMenu);
                    this.cboMenu1.Enabled = false;
                }

                validaNuevo();
            }
        }

        private void frmReglasDinamicas_Load(object sender, EventArgs e)
        {
            btnInsFuncEnRegla.Enabled = false;
            //Botón Editar
            if (dtReglas.Rows.Count == 0)
            {
                btnEditar1.Enabled = false;
            }
            if (dtReglas.Rows.Count > 0)
            {
                btnEditar1.Enabled = true;
            }
            //Botón Quitar
            if (dtFunciones.Rows.Count == 0)
            {
                btnQuitar1.Enabled = false;
            }
            if (dtFunciones.Rows.Count > 0)
            {
                btnQuitar1.Enabled = true;
            }

            dtgReglas.Columns["nNumOrden"].Width = 30;
            dtgReglas.Columns["lVigente"].Width = 50;
            dtgReglas.Columns["nIdRegla"].Width = 60;

            if (dtReglas.Rows.Count>0)
            {
                //Hacer que el sistema selecciona la primera fila : seleccionaremos  la celda de columna=4 fila=0 (visible en el dataGridView)
                dtgReglas.CurrentCell = dtgReglas[4, 0];
                //Hacer que en la pantalla se muestre seleccionado la primera columna
                dtgReglas.Rows[0].Selected = true;

                //Cargar los detalles de la regla
                int nfilaseleccionada = Convert.ToInt32(this.dtgReglas.CurrentRow.Index);
                CargarDetalleRegla(nfilaseleccionada);
            }

            if (dtFunciones.Rows.Count>0)
            {
                //Hacer que el sistema selecciona la primera fila : seleccionaremos  la celda de columna=2 fila=0 (visible en el dataGridView)
                dtgFunc.CurrentCell = dtgFunc[2, 0];
                //Hacer que en la pantalla se muestre seleccionado la primera columna
                dtgFunc.Rows[0].Selected = true;
            }
            dtgFunc.Columns["nIdFuncion"].Visible = false;
            dtgFunc.Columns["lVigente"].Width = 50;
            DarColorGridReglas();            
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            eAccion = Transaccion.Nuevo; //  1:    Inserción
                            //  2:    Edición

            nIdRegla = 0;
            nIdTipoOperacion = 0;
            chcExcepcion.Checked = false;
            grbExcepcion.Enabled = false;
            
            //dar color grid Reglas
            dtgReglas.Enabled = false;
            dtgReglas.ForeColor = Color.Gray;

            //Deshabilitar otros Botones
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            cboModulo1.Enabled = false;
            this.cboMenu1.Enabled = false;

            //Habilitar grupo detalle Regla
            grbDetallesRegla.Enabled = true;
            chcAplEstad.Enabled = true;
            chcNoExcepcion.Enabled = true;

            if (dtFunciones.Rows.Count > 0)
            {
                btnInsFuncEnRegla.Enabled = true;
            }

            //Detalle Regla
            txtCaracteristica.Text = "";
            txtRegla.Text = "";
            txtMensajeError.Text = "";
            txtCampoExcepcionar.Text = "";
            cboTipoOperacion1.SelectedValue = -1;
            chcExcepcion.Checked = false;

            btnInsFuncEnRegla.Enabled = true;

            txtMensajeError.Focus();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            //Verificar que se haya seleccionado una Regla
            if (dtReglas.Rows.Count>0)
            {
                btnEditar1.Enabled = true;
            }

            //dar color grid Reglas
            dtgReglas.Enabled = false;
            dtgReglas.ForeColor = Color.Gray;

            //Cargar Datos para editar
            int nfilaseleccionada = Convert.ToInt32(this.dtgReglas.CurrentRow.Index);

            txtCaracteristica.Text = dtgReglas.Rows[nfilaseleccionada].Cells["cCaracteristica"].Value.ToString();
            txtRegla.Text = dtgReglas.Rows[nfilaseleccionada].Cells["cReglaNegocio"].Value.ToString();
            txtMensajeError.Text = dtgReglas.Rows[nfilaseleccionada].Cells["cMensajeError"].Value.ToString();
            txtCampoExcepcionar.Text = dtgReglas.Rows[nfilaseleccionada].Cells["cCampoExcepcion"].Value.ToString();

            nIdRegla = Convert.ToInt32(dtgReglas.Rows[nfilaseleccionada].Cells["nIdRegla"].Value);

            if (dtgReglas.Rows[nfilaseleccionada].Cells["idTipoOperacion"].Value ==System.DBNull.Value)
            {
                nIdTipoOperacion = 0;
            }
            else
            {
                nIdTipoOperacion = Convert.ToInt32(dtgReglas.Rows[nfilaseleccionada].Cells["idTipoOperacion"].Value);
            }

            nNumOrden = Convert.ToInt32(dtgReglas.Rows[nfilaseleccionada].Cells["nNumOrden"].Value);

            if (Convert.ToBoolean(dtgReglas.Rows[nfilaseleccionada].Cells["lIndExcepcion"].Value))
            {
                chcExcepcion.Checked = true;
                grbExcepcion.Enabled = true;
            }
            else
            {
                chcExcepcion.Checked = false;
                grbExcepcion.Enabled = false;
            }

            //Habilitar Grupo Detalles Regla
            grbDetallesRegla.Enabled = true;
            chcAplEstad.Enabled = true;
            chcNoExcepcion.Enabled = true;

            //Deshabilitar otros Botones
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            cboModulo1.Enabled = false;
            this.cboMenu1.Enabled = false;

            if (dtFunciones.Rows.Count > 0)
            {
                btnInsFuncEnRegla.Enabled = true;
            }

            eAccion = Transaccion.Edita; //  1:    Inserción
                            //  2:    Edición
        }

        private void chcExcepcion_CheckedChanged(object sender, EventArgs e)
        {
            if (chcExcepcion.Checked==true && this.grbDetallesRegla.Enabled==true)
            {
                //Habilitar caja de texto para ingresar el campo a excepcionar de la regla dinámica
                grbExcepcion.Enabled = true;
            }
            else
            {
                grbExcepcion.Enabled = false;
            }
            chcExcepcion.Focus();
        }

        private void dtgReglas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtReglas.Rows.Count>0)
            {
                nfilaActualSeleccionada = Convert.ToInt32(this.dtgReglas.CurrentRow.Index);
                CargarDetalleRegla(nfilaActualSeleccionada);
            }         
        }

        private void CargarDetalleRegla(Int32 nfilaseleccionada)
        {
            txtCaracteristica.Text      = dtgReglas.Rows[nfilaseleccionada].Cells["cCaracteristica"].Value.ToString();
            txtRegla.Text               = dtgReglas.Rows[nfilaseleccionada].Cells["cReglaNegocio"].Value.ToString();
            txtMensajeError.Text        = dtgReglas.Rows[nfilaseleccionada].Cells["cMensajeError"].Value.ToString();
            txtCampoExcepcionar.Text    = dtgReglas.Rows[nfilaseleccionada].Cells["cCampoExcepcion"].Value.ToString();

            chcAplEstad.Checked = Convert.ToBoolean(dtgReglas.Rows[nfilaseleccionada].Cells["lAplicaEstad"].Value);
            chcNoExcepcion.Checked = Convert.ToBoolean(dtgReglas.Rows[nfilaseleccionada].Cells["lNoExcepcion"].Value);

            if (Convert.ToBoolean(dtgReglas.Rows[nfilaseleccionada].Cells["lIndExcepcion"].Value) == true)
            {
                chcExcepcion.Checked = true;
                //================= VALIDAR EXISTENCIA DE TIPO DE OPERACIÓN ============================
                if (dtReglas.Rows[nfilaseleccionada]["idTipoOperacion"].ToString().Trim().Length != 0)//Validar que exista un valor para buscar el tipo de operacion correspondiente
                {
                    int nCantItemsTipoOperac = 0;
                    //Ubicar al tipo de Operación (Excepción) para la regla
                    //Item del combo: idTipoOperacion, cTipoOperacion
                    DataTable dtTipoOperacion = (DataTable)cboTipoOperacion1.DataSource;
                    for (int i = 0; i < dtTipoOperacion.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dtTipoOperacion.Rows[i]["idTipoOperacion"]) == Convert.ToInt32(dtReglas.Rows[nfilaseleccionada]["idTipoOperacion"]))
                        {
                            cboTipoOperacion1.SelectedValue = Convert.ToInt32(dtTipoOperacion.Rows[i]["idTipoOperacion"]);
                            break;
                        }
                        else
                        {
                            nCantItemsTipoOperac++;
                        }
                    }
                    //No ha encontrado el tipo de Operación ('Puede ser que el tipo de operación no esté en estado vigente o no exista')
                    if (nCantItemsTipoOperac == dtTipoOperacion.Rows.Count)
                    {
                        cboTipoOperacion1.SelectedValue = 0;
                        MessageBox.Show("No se ha encontrado el tipo de Operación (Es posible que no exista o no se encuentre vigente).", "Validar Tipo de Operación Excepción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //btnEditar1.Enabled = false;
                        //btnGrabar1.Enabled = false;
                    }
                }
                else
                {
                    //No se debe de seleccionar ningún tipo de operración
                    cboTipoOperacion1.SelectedValue = 0;
                    MessageBox.Show("No se ha encontrado el tipo de Operación de Excepción (Es posible que no exista o no se encuentre vigente).", "Validar Tipo de Operación Excepción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //btnEditar1.Enabled = false;
                    //btnGrabar1.Enabled = false;
                }
                //=========================================================================================
            }
            else
            {
                chcExcepcion.Checked = false;
                //================= VALIDAR EXISTENCIA DE TIPO DE OPERACIÓN ============================
                if (dtReglas.Rows[nfilaseleccionada]["idTipoOperacion"].ToString().Trim().Length != 0)//Validar que exista un valor para buscar el tipo de operacion correspondiente
                {
                    int nCantItemsTipoOperac = 0;
                    //Ubicar al tipo de Operación (Excepción) para la regla
                    //Item del combo: idTipoOperacion, cTipoOperacion
                    DataTable dtTipoOperacion = (DataTable)cboTipoOperacion1.DataSource;
                    for (int i = 0; i < dtTipoOperacion.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dtTipoOperacion.Rows[i]["idTipoOperacion"]) == Convert.ToInt32(dtReglas.Rows[nfilaseleccionada]["idTipoOperacion"]))
                        {
                            cboTipoOperacion1.SelectedValue = Convert.ToInt32(dtTipoOperacion.Rows[i]["idTipoOperacion"]);
                            break;
                        }
                        else
                        {
                            nCantItemsTipoOperac++;
                        }
                    }
                    //No ha encontrado el tipo de Operación ('Puede ser que el tipo de operación no esté en estado vigente o no exista')
                    if (nCantItemsTipoOperac == dtTipoOperacion.Rows.Count)
                    {
                        cboTipoOperacion1.SelectedValue = 0;
                    }
                }
                else
                {
                    //No se debe de seleccionar ningún tipo de operración
                    cboTipoOperacion1.SelectedValue = 0;
                }
                //=========================================================================================
            }
        }

        private void dtgReglas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)//Tecla Flecha Abajo
            {
                nfilaActualSeleccionada = Convert.ToInt32(this.dtgReglas.CurrentRow.Index);

                if (nfilaActualSeleccionada < dtgReglas.Rows.Count)
                {
                    nfilaActualSeleccionada = nfilaActualSeleccionada + 1;
                    if (nfilaActualSeleccionada < dtgReglas.Rows.Count)
                    {
                        CargarDetalleRegla(nfilaActualSeleccionada);
                        return;
                    }
                }
            }
            if (e.KeyCode == Keys.Up)//Tecla Flecha Arriba
            {
                nfilaActualSeleccionada = Convert.ToInt32(this.dtgReglas.CurrentRow.Index);

                if (nfilaActualSeleccionada != 0)
                {
                    nfilaActualSeleccionada = nfilaActualSeleccionada - 1;
                    CargarDetalleRegla(nfilaActualSeleccionada);
                    return;
                }
                else
                {
                    CargarDetalleRegla(nfilaActualSeleccionada);
                    return;
                }
            }
        }

        private void txtMensajeError_Enter(object sender, EventArgs e)
        {
            nIndicaFoco = 1;
        }

        private void txtCaracteristica_Enter(object sender, EventArgs e)
        {
            nIndicaFoco = 2;
        }

        private void txtRegla_Enter(object sender, EventArgs e)
        {
            nIndicaFoco = 3;
        }

        private void txtCampoExcepcionar_Enter(object sender, EventArgs e)
        {
            nIndicaFoco = 4;
        }

        private void btnAgregaFunc_Click(object sender, EventArgs e)
        {
            //Cuando es nuevo sólo se agrega una nueva Fila, para que el usuario la ingrese la función
            DataRow dr = this.dtFunciones.NewRow();
            dr["nIdFuncion"] = 0;
            dr["nIdOpcion"] = Convert.ToInt32(this.cboMenu1.SelectedNode.Tag);
            dr["cFuncion"] = "Ingrese la nueva función aqui";
            dr["cFunRemplazado"] ="";
            dr["cValorFun"] ="";
            dr["lVigente"] = System.DBNull.Value;
            this.dtFunciones.Rows.InsertAt(dr,0);

            btnQuitar1.Enabled = true;            
            //Una vez añadido la nueva fila, seleccionarla
            dtgFunc.Rows[0].Selected = true;           
        }

        private void btnInsFuncEnRegla_Click(object sender, EventArgs e)
        {
            if (dtFunciones.Rows.Count == 0)
            {
                MessageBox.Show("No existen funciones para agregar en la REGLA actual", "Insertar Función en Regla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int nFilaFuncion = Convert.ToInt32(this.dtgFunc.CurrentRow.Index);

                //Validar que la igual de cantidad de paréntesis:
                int nCantAbreParentesis     = new System.Text.RegularExpressions.Regex("[(]").Matches(dtFunciones.Rows[nFilaFuncion]["cFuncion"].ToString()).Count;
                int nCantCierreParentesis   = new System.Text.RegularExpressions.Regex("[)]").Matches(dtFunciones.Rows[nFilaFuncion]["cFuncion"].ToString()).Count;
                if (nCantAbreParentesis != nCantCierreParentesis)
                {
                    MessageBox.Show("La cantidad de paréntesis de apertura no coincide con la cantidad de paréntesis de cierre de ésta función. Debe corregir la función de acuerdo la sintaxis.", "Validar sintaxis Función:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                if (nIndicaFoco == 1)
                {   //la caja de texto mensaje Error tiene el foco, pero no se debe insertar una función aquí
                    lblMensajeGuia.Visible = true;                  
                }
                else if (nIndicaFoco == 2)
                {
                    txtCaracteristica.Text = txtCaracteristica.Text.Insert(txtCaracteristica.SelectionStart, " ("+ dtFunciones.Rows[nFilaFuncion]["cFuncion"].ToString() + ") ");
                    txtCaracteristica.Focus();
                }
                else if (nIndicaFoco == 3)
                {
                    txtRegla.Text = txtRegla.Text.Insert(txtRegla.SelectionStart, " (" + dtFunciones.Rows[nFilaFuncion]["cFuncion"].ToString() + ") ");
                    txtRegla.Focus();
                }
                else if (nIndicaFoco == 4)
                {
                    txtCampoExcepcionar.Text = txtCampoExcepcionar.Text.Insert(txtCampoExcepcionar.SelectionStart, " (" + dtFunciones.Rows[nFilaFuncion]["cFuncion"].ToString() + ") ");
                    txtCampoExcepcionar.Focus();
                }
                else
                {//Otro elemento tiene el foco, por lo tanto no se debe permitir adicionar el texto (la fucnion escogida)
                    lblMensajeGuia.Visible = true;   
                }

            }
        }

        private void dtgFunc_Click(object sender, EventArgs e)
        {
            //Cuando se elija una función determinada se seleccione el texto para modificar
            if (dtFunciones.Rows.Count>0)
            {
                Boolean lEsVibleMinimoUnaFila = false;
                //Verificar que por lo menos se cuente con 1 fila visible de la Tabla de funciones
                for (int i = 0; i < dtgFunc.RowCount; i++)
                {
                    if (dtgFunc.Rows[i].Visible==true)
                    {
                        lEsVibleMinimoUnaFila = true;
                    }
                }
                if (lEsVibleMinimoUnaFila==true)
                {
                    if (this.dtgFunc.CurrentCell == dtgFunc.CurrentRow.Cells["cFuncion"])
                    {
                        this.dtgFunc.CurrentCell = dtgFunc.CurrentRow.Cells["cFuncion"];
                    }

                    if (this.dtgFunc.CurrentCell.OwningColumn.Name.Equals("lVigente"))
                    {
                        //Cambiar estado
                        dtFunciones.Rows[Convert.ToInt32(this.dtgFunc.CurrentRow.Index)]["lActualizar"] = true;
                    }
                }   
            }
        }

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if ( dtFunciones.Rows.Count> 0)
            {            
                //Me ubico en la fila actual de la Función seleccionada y la oculto(si proviene de base de datos,
                //si la función está siendo actualmente creada se elimina del DatataTable de Funciones)
                int nFilaFuncion = UbicarFilaSeleccionada();

                if (Convert.ToInt32(dtFunciones.Rows[nFilaFuncion]["nIdFuncion"]) == 0)//Cuando es creado actualmente (no existe aún en Base de Datos)
                {
                    //Eliminar del DataTable
                    dtFunciones.Rows.RemoveAt(nFilaFuncion);
                    if (CantFuncionesVisibles() > 0)
                    {
                        //Posicionar en la primera fila
                        dtgFunc.Rows[0].Selected = true;
                    }
                    else
                    {
                        btnQuitar1.Enabled = false;
                    }
                }
                else//Cuando fué traido de Base de Datos
                {
                    //actualizando su estado lvigente=0               
                    dtFunciones.Rows[nFilaFuncion]["lVigente"] = 0;
                    dtFunciones.Rows[nFilaFuncion]["lActualizar"] = true;
                }
            }
        }//Fin método Botón Quitar

        private void btnInsFuncEnRegla_MouseLeave(object sender, EventArgs e)
        {
            lblMensajeGuia.Visible = false;
        }

        private void dtgReglas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgReglas.Rows.Count > 0)
            {
                if (dtgReglas.CurrentCell.OwningColumn.Name.Equals("lVigente"))
                {
                    ValidarParticipacionDeFuncionesEnReglas();
                }
            } 
        }

        private void dtgReglas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgReglas.Rows.Count>0)
            {
                if (dtgReglas.CurrentCell.OwningColumn.Name.Equals("lVigente"))
                {
                    ValidarParticipacionDeFuncionesEnReglas();
                }
            } 
        }

        private void lblBase11_Click(object sender, EventArgs e)
        {
            if (grbSintaxis.Visible == true)
            {
                grbSintaxis.Visible = false;
            }
            else
            {
                grbSintaxis.Visible = true;
                grbSintaxis.Size = new Size(415, 243); 
                grbSintaxis.Location = new Point(235, 23);
            }
        }

        private void cboMenu1_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (cboMenu1.SelectedNode == null)
            {
                return;
            }
            int idOpcion = Convert.ToInt32(cboMenu1.SelectedNode.Tag);

            //Cargar Tablas Reglas y Funciones
            CargarFuncionesYReglas(idOpcion);

            //Habilitar boton Editar si la Tabla de Reglas cuenta con elementos
            if (dtReglas.Rows.Count == 0)
            {
                btnEditar1.Enabled = false;
                //Limpiar el detalle de Reglas
                txtMensajeError.Text = "";
                txtCaracteristica.Text = "";
                txtRegla.Text = "";
                txtCampoExcepcionar.Text = "";
                chcExcepcion.Checked = false;
                cboTipoOperacion1.SelectedValue = -1;
                dtgReglas.Columns["lVigente"].Width = 50;
                dtgReglas.Columns["nIdRegla"].Width = 60;
            }
            if (dtReglas.Rows.Count > 0)
            {
                btnEditar1.Enabled = true;
                int nfilaseleccionada = Convert.ToInt32(this.dtgReglas.CurrentRow.Index);
                CargarDetalleRegla(nfilaseleccionada);
                grbExcepcion.Enabled = false;
                dtgReglas.Columns["lVigente"].Width = 50;
                dtgReglas.Columns["nIdRegla"].Width = 60;
            }
            //Habilitar boton Quitar si la Tabla de Funciones cuenta con elementos
            if (dtFunciones.Rows.Count == 0)
            {
                btnQuitar1.Enabled = false;
            }
            if (dtFunciones.Rows.Count > 0)
            {
                btnQuitar1.Enabled = true;
            }

            btnAgregaFunc.Enabled = true;
            dtgFunc.Enabled = true;
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = true;

            dtgFunc.ForeColor = Color.Black;
            dtgReglas.ForeColor = Color.Black;

            DarColorGridReglas();

            validaNuevo();
        }

        #endregion

        #region Métodos

        private void CargarCombos()
        {
            int nIdPrimerModulo = 0;
            //Ubicar primer elemento del combo Modulo
            if (cboModulo1.dtModulo.Rows.Count == 0)
            {
                MessageBox.Show("No se ha podido cargar los Modulos", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                nIdPrimerModulo = Convert.ToInt32(cboModulo1.dtModulo.Rows[0]["idModulo"]);
            }            

            CargarFuncionesYReglas(0);//Carga las funciones y reglas de acuerdo al Identificador

            //Grupo detalles Regla
            grbDetallesRegla.Enabled = false;
            chcAplEstad.Enabled = false;
            chcNoExcepcion.Enabled = false;
            grbExcepcion.Enabled = false;

            //Grupo Funciones
            dtgFunc.Enabled = true;
            dtgFunc.ForeColor = Color.Black;
            btnAgregaFunc.Enabled = true;
            {
                if (CantFuncionesVisibles() > 0)
                {
                    btnQuitar1.Enabled = true;
                }
                else
                {
                    btnQuitar1.Enabled = false;
                }
            }

            //Cargar combo de Tipos de Operacion por modulo
            cboTipoOperacion1.LisTipoOperacModulo(Convert.ToInt32(cboModulo1.SelectedValue));
        }

        private void CargarFuncionesYReglas(int idOpcionFormulario)
        {
            //FUNCIONES
            dtgFunc.ReadOnly = false;
            dtFunciones = ReglasDinamicas.ObtenerFuncionesDeReglasDinamicas(idOpcionFormulario);
            dtgFunc.DataSource = dtFunciones;

            dtgFunc.Columns["nIdFuncion"].Visible = false;
            dtgFunc.Columns["nIdOpcion"].Visible = false;
            dtgFunc.Columns["cFunRemplazado"].Visible = false;
            dtgFunc.Columns["cValorFun"].Visible = false;

            dtgFunc.Columns["cFuncion"].HeaderText = "Función";
            dtgFunc.Columns["cFuncion"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgFunc.Columns["lVigente"].HeaderText = "Vigente";
            //Añadir una columna para identificar si se hace cambios para actualizarlos
            dtFunciones.Columns.Add("lActualizar", typeof(bool));
            for (int i = 0; i < dtFunciones.Rows.Count; i++)
            {
                dtFunciones.Rows[i]["lActualizar"] = false;
            }
            dtgFunc.Columns["lActualizar"].Visible = false;


            if (dtFunciones.Rows.Count > 0)//Habilitar botones agregar/quitar
            {
                btnQuitar1.Enabled = true;
            }
            else
            {
                btnQuitar1.Enabled = false;
            }

            //REGLAS
            dtgReglas.ReadOnly = false;
            //Recuperar sólo reglas de negocio
            dtReglas = ReglasDinamicas.ObtenerReglasPorOpcion(idOpcionFormulario);

            dtgReglas.DataSource = dtReglas;

            dtgReglas.Columns["nIdRegla"].Visible = true;
            dtgReglas.Columns["nIdOpcion"].Visible = false;
            dtgReglas.Columns["idUsuRegist"].Visible = false;
            dtgReglas.Columns["dFecRegist"].Visible = false;
            dtgReglas.Columns["lResul"].Visible = false;
            dtgReglas.Columns["idTipoOperacion"].Visible = false;
            dtgReglas.Columns["cReglaRemplazado"].Visible = false;
            dtgReglas.Columns["cCampoExcepcionReemplazado"].Visible = false;
            dtgReglas.Columns["cCaracteristica"].Visible = false;
            dtgReglas.Columns["cReglaNegocio"].Visible = false;
            dtgReglas.Columns["cMensajeError"].HeaderText = "Regla";
            dtgReglas.Columns["lIndExcepcion"].Visible = false;
            dtgReglas.Columns["cCampoExcepcion"].Visible = false;
            dtgReglas.Columns["cTipoOperacion"].Visible = false;
            dtgReglas.Columns["lVigente"].HeaderText = "Vigente";
            dtgReglas.Columns["cMensajeError"].ReadOnly = true;
            dtgReglas.Columns["nNumOrden"].HeaderText = "Orden";
            dtgReglas.Columns["lAlertaRiesgo"].Visible = false;
            dtgReglas.Columns["nIdRegla"].HeaderText = "Nro";

            dtgReglas.Columns["nNumOrden"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgReglas.Columns["cMensajeError"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dtgReglas.Columns["lAplicaEstad"].Visible = false;
            dtgReglas.Columns["lNoExcepcion"].Visible = false;

        }

        private void DarColorGridReglas()//Pintará las reglas no excepcionables de un color diferente
        {
            if (dtReglas.Rows.Count > 0)
            {
                for (int i = 0; i < dtReglas.Rows.Count; i++)
                {
                    if (Convert.ToUInt32(dtReglas.Rows[i]["lIndExcepcion"]) == 0)//NO EXCEPCIONABLES
                    {
                        dtgReglas.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                    }
                    if (Convert.ToUInt32(dtReglas.Rows[i]["lIndExcepcion"]) == 1)//EXCEPCIONABLES
                    {
                        dtgReglas.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightSteelBlue;
                    }
                }
            }
        }

        private Boolean EsIgualLaCantParentesisEnFunciones()
        {
            int nCantAbreParentesis = 0;
            int nCantCierreParentesis = 0;

            for (int i = 0; i < dtFunciones.Rows.Count; i++)
            {
                nCantAbreParentesis = new System.Text.RegularExpressions.Regex("[(]").Matches(dtFunciones.Rows[i]["cFuncion"].ToString()).Count;
                nCantCierreParentesis = new System.Text.RegularExpressions.Regex("[)]").Matches(dtFunciones.Rows[i]["cFuncion"].ToString()).Count;

                if (nCantAbreParentesis != nCantCierreParentesis)
                {
                    MessageBox.Show("La cantidad de paréntesis de apertura no coincide con la cantidad de paréntesis de cierre de la Función: " + dtFunciones.Rows[i]["cFuncion"].ToString() + ". Debe Corregir ésta función de acuerdo a la sintaxis.", "Validar sintaxis Funciones:.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void ValidarConsistenciaReglas()
        {
            //Validar que las reglas tengan todas las funciones que participan en ellas,
            //De lo contrario la regla se desactivará
            int nCantReglasADesactivar = 0;
            for (int r = 0; r < dtReglas.Rows.Count; r++)
            {
                if (Convert.ToBoolean(dtReglas.Rows[r]["lVigente"]))
                {
                    //Hallar la cantidad de funciones que tiene la regla
                    int nNumFunciones = new System.Text.RegularExpressions.Regex("DBO.").Matches(Convert.ToString(dtReglas.Rows[r]["cReglaNegocio"]).Trim().ToUpper()).Count;
                    nNumFunciones = nNumFunciones + new System.Text.RegularExpressions.Regex("DBO.").Matches(Convert.ToString(dtReglas.Rows[r]["cCaracteristica"]).Trim().ToUpper()).Count;
                    int nCantFunc = 0;

                    int nCantFuncRep = 0;//Cantidad de veces que repite una función en una regla (Por que puede haber una regla que utilice una función varias veces en su estructura)
                    string cadReglaNegocio, cadFuncion, cadCaracteristica;
                    //Hallar la cantidad de funciones que están en la Regla
                    for (int p = 0; p < dtFunciones.Rows.Count; p++)
                    {
                        if (Convert.ToInt32(dtFunciones.Rows[p]["nIdFuncion"]) != 0)//que sea una función que es traida de BD, no una que recien se esté creando
                        {
                            cadReglaNegocio = Convert.ToString(dtReglas.Rows[r]["cReglaNegocio"]).ToUpper();
                            cadCaracteristica = Convert.ToString(dtReglas.Rows[r]["cCaracteristica"]).ToUpper();
                            cadFuncion = Convert.ToString(dtFunciones.Rows[p]["cFuncion"]).ToUpper();

                            //Verificar que la función esté en presente en la regla
                            if (cadReglaNegocio.Trim().Contains(cadFuncion.Trim()))
                            {
                                //Hallando al cantidad de funciones repetidas en la regla
                                int ultimaPos = -1;
                                while ((ultimaPos = cadReglaNegocio.IndexOf(cadFuncion, ultimaPos + 1)) >= 0) nCantFuncRep++;
                                /**/

                                nCantFunc = nCantFunc + nCantFuncRep;
                                nCantFuncRep = 0;
                            }

                            //Verificar que la función esté en presente en la Carcaterística de regla
                            if (cadCaracteristica.Trim().Contains(cadFuncion.Trim()))
                            {
                                //Hallando al cantidad de funciones repetidas en la regla
                                int ultimaPos = -1;
                                while ((ultimaPos = cadCaracteristica.IndexOf(cadFuncion, ultimaPos + 1)) >= 0) nCantFuncRep++;
                                /**/

                                nCantFunc = nCantFunc + nCantFuncRep;
                                nCantFuncRep = 0;
                            }
                        }
                    }

                    if (nNumFunciones != nCantFunc)
                    {
                        dtReglas.Rows[r]["lVigente"] = 0;
                        nCantReglasADesactivar++;
                    }

                }//fin if                       
            }

            if (nCantReglasADesactivar > 0)
            {
                MessageBox.Show("Se desactivarán " + (nCantReglasADesactivar) + " Reglas debido a que no se encuentran sus funciones definidas. Verifique la existencia de las funciones incluidas en la REGLA en la LISTA DE FUNCIONES.", "Validar Activar Regla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Boolean BuscarCambios()
        {
            Boolean lCambios = false;
            //Verifica cambios en DataTable dtReglas
            for (int i = 0; i < dtReglas.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtReglas.Rows[i]["lVigente"]) == false)
                {
                    lCambios = true;
                    break;
                }
            }

            if (lCambios)
            {
                return lCambios;
            }

            //Verificar Cambios en DataTable dtFunciones
            for (int j = 0; j < dtFunciones.Rows.Count; j++)
            {
                if (Convert.ToInt32(dtFunciones.Rows[j]["nIdFuncion"]) == 0)//Las nuevas Funciones
                {
                    lCambios = true;
                    break;
                }
                else
                {
                    if (Convert.ToBoolean(dtFunciones.Rows[j]["lActualizar"]) == true)
                    {
                        lCambios = true;
                        break;
                    }
                }
            }

            if (lCambios)
            {
                return lCambios;
            }

            //Verificar si se está editando una Regla o insertando una nueva Regla
            if (grbDetallesRegla.Enabled == true)
            {
                lCambios = true;
                return lCambios;
            }

            return lCambios;
        }

        private Boolean ValidarEliminacionFunciones()
        {
            int nCantFuncionesNoCumplen = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dtReglas.Rows.Count; i++)
            {
                for (int j = 0; j < dtFunciones.Rows.Count; j++)
                {
                    if (Convert.ToBoolean(dtReglas.Rows[i]["lVigente"]) == true)//Trabajar sólo con reglas que van estar vigentes
                    {
                        if (Convert.ToInt32(dtFunciones.Rows[j]["nIdFuncion"]) > 0 && Convert.ToBoolean(dtFunciones.Rows[j]["lVigente"]) == false && Convert.ToBoolean(dtFunciones.Rows[j]["lActualizar"]) == true)//Para las funciones que fueron traidas de Base de Datos que se van a eliminar
                        {
                            //Identifica que la función pertenezca a alguna Regla(con check) de la 'Opción' seleccionada
                            int nExisteFuncionEnRegla = dtReglas.Rows[i]["cReglaNegocio"].ToString().ToUpper().IndexOf(dtFunciones.Rows[j]["cFuncion"].ToString().ToUpper());
                            nExisteFuncionEnRegla = nExisteFuncionEnRegla + dtReglas.Rows[i]["cCaracteristica"].ToString().ToUpper().IndexOf(dtFunciones.Rows[j]["cFuncion"].ToString().ToUpper());

                            if (nExisteFuncionEnRegla >= 0)
                            {
                                sb.Append("-" + dtFunciones.Rows[j]["cFuncion"].ToString() + Environment.NewLine);
                                nCantFuncionesNoCumplen++;
                                dtFunciones.Rows[j]["lVigente"] = true;
                                dtFunciones.Rows[j]["lActualizar"] = false;
                                dtgFunc.Rows[j].Visible = true;
                            }
                        }
                    }
                }
            }
            if (nCantFuncionesNoCumplen > 0)
            {
                MessageBox.Show("No se pueden desactivar las siguientes " + nCantFuncionesNoCumplen + " FUNCION(ES) porque están siendo usando en otras reglas:" + Environment.NewLine +
                                sb.ToString(), "Validación eliminar Funciones:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void VerificarFuncionesModificadas()
        {
            for (int i = 0; i < dtFunciones.Rows.Count; i++)
            {
                Boolean lSonIguales = dtFunciones.Rows[i]["cFuncion"].ToString().Equals(dtFunciones.Rows[i]["cFunRemplazado"].ToString());
                if (lSonIguales == false)
                {
                    if (Convert.ToInt32(dtFunciones.Rows[i]["nIdFuncion"]) == 0)//Para las funciones que se están creando
                    {
                        dtFunciones.Rows[i]["cFunRemplazado"] = dtFunciones.Rows[i]["cFuncion"];
                    }
                    else//Para las funciones que fueron taridas de Base de datos y que hansido modificadas
                    {
                        dtFunciones.Rows[i]["cFunRemplazado"] = dtFunciones.Rows[i]["cFuncion"];
                        dtFunciones.Rows[i]["lActualizar"] = true;
                    }
                }
            }
        }

        private Boolean ValidaSintaxisFunciones()//Retorna true en caso exista errores en sintaxis, false de lo contrario
        {
            if (dtFunciones.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                Boolean lIdentificaError = false;
                for (int i = 0; i < dtFunciones.Rows.Count; i++)
                {
                    /*if (Convert.ToInt32(dtFunciones.Rows[i]["nIdFuncion"])==0)//Las que fueron añadidas
                    {*/
                    string cadena = dtFunciones.Rows[i]["cFuncion"].ToString().Trim();//Solo de los costados, el resto se valida a continuación

                    //Validando estructura básica: Nombres y paréntesis
                    Regex patronEstructuraNombreFuncion = new Regex("^(dbo.)([a-zA-Z_]+)[(]([a-zA-Z,_0-9]+)[)]");
                    Match match = patronEstructuraNombreFuncion.Match(cadena);
                    if (match.Success == true)
                    {
                        //Validando parámetros y comas de la función

                        //Calculando cantidad de comas
                        int nCantComas = 0;
                        for (int e = 0; e < cadena.Length; e++)
                        {
                            if (cadena[e] == ',')
                            {
                                nCantComas++;
                            }
                        }

                        //Calulando cantidad de parámetros
                        cadena = cadena.Replace("(", " ");//reemplazar (
                        cadena = cadena.Replace(",", " ");//reemplazar ,
                        cadena = cadena.Replace(")", " ");//reemplazar )
                        cadena = Regex.Replace(cadena, @"\s+", " ");//reemplazar espacios en blanco consecutivos po uno solo
                        cadena = cadena.Trim();//Elimina los espacios en blanco de los costados
                        string[] cParametros = cadena.Split(' ');
                        int nCantParametros = (cParametros.Length - 1);//-1 por que es el nombre de la fución

                        if ((nCantComas + 1) != nCantParametros)
                        {
                            lIdentificaError = true;
                            sb.Append("-" + dtFunciones.Rows[i]["cFuncion"] + Environment.NewLine);
                        }
                    }
                    else
                    {
                        lIdentificaError = true;
                        sb.Append("-" + dtFunciones.Rows[i]["cFuncion"] + Environment.NewLine);
                    }
                    //}
                }
                if (lIdentificaError == true)
                {
                    MessageBox.Show("Error de sintaxis en las funciones:" + Environment.NewLine + sb.ToString(), "Validación de sintaxis de Funciones:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private DataTable ArmarNuevaRegla(Transaccion eAccion)
        {
            DataTable dtNuevaRegla = new DataTable("dtNuevaRegla");
            dtNuevaRegla.Columns.Add("nIdOpcion", typeof(int));
            dtNuevaRegla.Columns.Add("nIdRegla", typeof(int));
            dtNuevaRegla.Columns.Add("cCaracteristica", typeof(string));
            dtNuevaRegla.Columns.Add("cReglaNegocio", typeof(string));
            dtNuevaRegla.Columns.Add("cMensajeError", typeof(string));
            dtNuevaRegla.Columns.Add("idUsuRegist", typeof(int));
            dtNuevaRegla.Columns.Add("lVigente", typeof(bool));
            dtNuevaRegla.Columns.Add("nNumOrden", typeof(int));

            dtNuevaRegla.Columns.Add("lIndExcepcion", typeof(bool));
            dtNuevaRegla.Columns.Add("idTipoOperacion", typeof(int));
            dtNuevaRegla.Columns.Add("cCampoExcepcion", typeof(string));
            dtNuevaRegla.Columns.Add("lAplicaEstad", typeof(string));
            dtNuevaRegla.Columns.Add("lNoExcepcion", typeof(string));

            DataRow drfila = dtNuevaRegla.NewRow();
            drfila["nIdOpcion"] = Convert.ToInt32(this.cboMenu1.SelectedNode.Tag);
            drfila["nIdRegla"] = nIdRegla;
            drfila["cCaracteristica"] = txtCaracteristica.Text;
            drfila["cReglaNegocio"] = txtRegla.Text;
            drfila["cMensajeError"] = txtMensajeError.Text;
            drfila["idUsuRegist"] = clsVarGlobal.User.idUsuario;

            drfila["lAplicaEstad"] = chcAplEstad.Checked;
            drfila["lNoExcepcion"] = chcNoExcepcion.Checked;

            if (eAccion == Transaccion.Nuevo)//  1:    Inserción,   2:    Edición
            {
                drfila["lVigente"] = true;
            }
            else
            {
                nfilaActualSeleccionada = Convert.ToInt32(this.dtgReglas.CurrentRow.Index);
                drfila["lVigente"] = this.dtReglas.Rows[nfilaActualSeleccionada]["lVigente"];
            }


            drfila["nNumOrden"] = nNumOrden;

            drfila["lIndExcepcion"] = chcExcepcion.Checked;

            //Cuando se va Insertar una regla CON EXCEPCIÓN
            if (chcExcepcion.Checked == true)
            {
                drfila["idTipoOperacion"] = cboTipoOperacion1.SelectedValue;
                drfila["cCampoExcepcion"] = txtCampoExcepcionar.Text;
            }//Cuando se va Insertar una regla SIN EXCEPCIÓN
            else
            {
                if (nIdRegla == 0)//La regla se está insertando por primera vez
                {
                    drfila["idTipoOperacion"] = System.DBNull.Value;
                    drfila["cCampoExcepcion"] = System.DBNull.Value;
                }
                else//La regla se está editando(Se está cambiando si permite o no excepción)
                {
                    drfila["idTipoOperacion"] = this.dtReglas.Rows[nfilaActualSeleccionada]["idTipoOperacion"];
                    drfila["cCampoExcepcion"] = txtCampoExcepcionar.Text;
                }
            }

            dtNuevaRegla.Rows.Add(drfila);
            return dtNuevaRegla;
        }

        private void DeshabilitarBotones()
        {
            btnGrabar1.Enabled = false;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            grbDetallesRegla.Enabled = false;
            chcAplEstad.Enabled = false;
            chcNoExcepcion.Enabled = false;

            //Grupo Funciones
            dtgFunc.Enabled = false;
            dtgFunc.ForeColor = Color.Gray;
            btnAgregaFunc.Enabled = false;
            btnQuitar1.Enabled = false;

            dtgReglas.Enabled = false;
            dtgReglas.ForeColor = Color.Gray;
        }

        private void LimpiarControles()
        {
            //Detalle Regla
            txtCaracteristica.Text = "";
            txtRegla.Text = "";
            txtMensajeError.Text = "";
            txtCampoExcepcionar.Text = "";
            cboTipoOperacion1.SelectedValue = -1;
            chcExcepcion.Checked = false;

            //Botones
            btnEditar1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = true;

            //Habilitar combos
            cboModulo1.Enabled = true;
            this.cboMenu1.Enabled = true;

            //Recargar Combos
            CargarCombos();

            //Dar color a grid reglas
            dtgReglas.ForeColor = Color.Black;
            dtgReglas.Enabled = true;

            btnInsFuncEnRegla.Enabled = false;

            chcExcepcion.Checked = false;
            grbExcepcion.Enabled = false;
        }

        private int UbicarFilaSeleccionada()
        {//Ubica el indice la Fila Seleccionada Actual
            int nFila = 0;
            for (int i = 0; i < dtgFunc.RowCount; i++)
            {
                if (dtgFunc.Rows[i].Selected == true)
                {
                    nFila = i;
                }
            }
            return nFila;
        }

        private int CantFuncionesVisibles()
        {
            int nCantidad = 0;
            for (int i = 0; i < dtgFunc.RowCount; i++)
            {
                if (dtgFunc.Rows[i].Visible == true)
                {
                    nCantidad++;
                }
            }
            return nCantidad;
        }
        
        //Si se va desactivar la regla, entonces todas las funciones que participan sólo en esta regla se desactivarán
        //Si se va activar la regla, validar que tenga todas las funciones definidas que participan en ésta regla
        private void ValidarParticipacionDeFuncionesEnReglas()
        {

            int nfilaseleccionada = Convert.ToInt32(this.dtgReglas.CurrentRow.Index);
            //Si una regla se activa deben de activarse todas las funciones que participan en ella
            if (Convert.ToInt32(dtReglas.Rows[nfilaseleccionada]["lVigente"]) == 0)//está pasando de no check a check
            {
                //Hallar la cantidad de funciones que tiene la regla
                int nNumFunciones = new System.Text.RegularExpressions.Regex("DBO.").Matches(Convert.ToString(dtReglas.Rows[nfilaseleccionada]["cReglaNegocio"]).Trim().ToUpper()).Count;
                int nCantFunc = 0;
                int nCantFuncRep = 0;//Cantidad de veces que repite una función en una regla (Por que puede haber una regla que utilice una función varias veces en su estructura)

                string cadReglaNegocio, cadFuncion, cadCaracteristicaRegla;//-->
                //Hallar la cantidad de funciones que están en la Regla
                for (int p = 0; p < dtFunciones.Rows.Count; p++)
                {
                    if (Convert.ToInt32(dtFunciones.Rows[p]["nIdFuncion"]) != 0)//que sea una función que es traida de BD, no una que recien se esté creando
                    {
                        cadReglaNegocio = Convert.ToString(dtReglas.Rows[nfilaseleccionada]["cReglaNegocio"]).ToUpper();
                        cadCaracteristicaRegla = Convert.ToString(dtReglas.Rows[nfilaseleccionada]["cCaracteristica"]).ToUpper();//-->

                        cadFuncion = Convert.ToString(dtFunciones.Rows[p]["cFuncion"]).ToUpper();

                        //Verificar que la función esté en presente en la regla
                        if (cadReglaNegocio.Trim().Contains(cadFuncion.Trim()))
                        {
                            //Hallando al cantidad de funciones repetidas en la regla
                            int ultimaPos = -1;
                            while ((ultimaPos = cadReglaNegocio.IndexOf(cadFuncion, ultimaPos + 1)) >= 0) nCantFuncRep++;
                            /**/

                            nCantFunc = nCantFunc + nCantFuncRep;
                            nCantFuncRep = 0;
                        }
                        //Verificar que la función esté en presente en la Característica
                        if (cadCaracteristicaRegla.Trim().Contains(cadFuncion.Trim()))
                        {
                            //Hallando al cantidad de funciones repetidas en la Característica
                            int ultimaPos = -1;
                            while ((ultimaPos = cadReglaNegocio.IndexOf(cadFuncion, ultimaPos + 1)) >= 0) nCantFuncRep++;
                            /**/

                            nCantFunc = nCantFunc + nCantFuncRep;
                            nCantFuncRep = 0;
                        }
                    }
                }
                if (nNumFunciones != nCantFunc)
                {
                    MessageBox.Show("No se puede activar la regla debido a que no se han definido " + (nNumFunciones - nCantFunc) + " funcion(es). Verifique la existencia de las funciones en la LISTA DE FUNCIONES.", "Validar Activar Regla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtReglas.Rows[nfilaseleccionada]["lVigente"] = 0;
                    return;
                }

                for (int p = 0; p < dtFunciones.Rows.Count; p++)
                {
                    if (Convert.ToInt32(dtFunciones.Rows[p]["nIdFuncion"]) != 0)//que sea una función que es traida de BD, no una que recien se esté creando
                    {
                        //Verificar que la función esté en presente en la regla
                        if (Convert.ToString(dtReglas.Rows[nfilaseleccionada]["cReglaNegocio"]).Trim().ToUpper().Contains(Convert.ToString(dtFunciones.Rows[p]["cFuncion"]).Trim().ToUpper()) ||
                            Convert.ToString(dtReglas.Rows[nfilaseleccionada]["cCaracteristica"]).Trim().ToUpper().Contains(Convert.ToString(dtFunciones.Rows[p]["cFuncion"]).Trim().ToUpper())
                            )
                        {
                            //Activar la Funcion
                            dtFunciones.Rows[p]["lVigente"] = 1;
                            dtFunciones.Rows[p]["lActualizar"] = 1;
                        }
                    }
                }
                dtReglas.Rows[nfilaseleccionada]["lVigente"] = 1;
            }
            else//Esta pasando de check a no check
            {
                //Desactivar todas las funciones que participan en la regla Actual ó Característica
                for (int p = 0; p < dtFunciones.Rows.Count; p++)
                {
                    if (Convert.ToInt32(dtFunciones.Rows[p]["nIdFuncion"]) != 0)//que sea una función que es traida de BD, no una que recien se esté creando
                    {
                        //Verificar que la función esté en presente en la regla
                        if (Convert.ToString(dtReglas.Rows[nfilaseleccionada]["cReglaNegocio"]).Trim().ToUpper().Contains(Convert.ToString(dtFunciones.Rows[p]["cFuncion"]).Trim().ToUpper()))
                        {
                            //Activar la Funcion
                            dtFunciones.Rows[p]["lVigente"] = 0;
                            dtFunciones.Rows[p]["lActualizar"] = 1;
                        }

                        //Verificar que la función esté en presente en la Característica
                        if (Convert.ToString(dtReglas.Rows[nfilaseleccionada]["cCaracteristica"]).Trim().ToUpper().Contains(Convert.ToString(dtFunciones.Rows[p]["cFuncion"]).Trim().ToUpper()))
                        {
                            //Activar la Funcion
                            dtFunciones.Rows[p]["lVigente"] = 0;
                            dtFunciones.Rows[p]["lActualizar"] = 1;
                        }
                    }
                }

                //Activar las Funciones que participan en otras Reglas activas (Reglas y Carcaterística)
                for (int i = 0; i < dtReglas.Rows.Count; i++)
                {
                    if ((Convert.ToInt32(dtReglas.Rows[nfilaseleccionada]["nIdRegla"]) != Convert.ToInt32(dtReglas.Rows[i]["nIdRegla"])) &&
                            Convert.ToBoolean(dtReglas.Rows[i]["lVigente"]) == true
                        )
                    {
                        for (int p = 0; p < dtFunciones.Rows.Count; p++)
                        {
                            if (Convert.ToInt32(dtFunciones.Rows[p]["nIdFuncion"]) != 0)//que sea una función que es traida de BD, no una que recien se esté creando
                            {
                                //Verificar que la función esté en presente en la regla
                                if (Convert.ToString(dtReglas.Rows[i]["cReglaNegocio"]).Trim().ToUpper().Contains(Convert.ToString(dtFunciones.Rows[p]["cFuncion"]).Trim().ToUpper()))
                                {
                                    //Activar la Funcion
                                    dtFunciones.Rows[p]["lVigente"] = 1;
                                    dtFunciones.Rows[p]["lActualizar"] = 1;
                                }

                                //Verificar que la función esté en presente en la Característica
                                if (Convert.ToString(dtReglas.Rows[i]["cCaracteristica"]).Trim().ToUpper().Contains(Convert.ToString(dtFunciones.Rows[p]["cFuncion"]).Trim().ToUpper()))
                                {
                                    //Activar la Funcion
                                    dtFunciones.Rows[p]["lVigente"] = 1;
                                    dtFunciones.Rows[p]["lActualizar"] = 1;
                                }
                            }
                        }//fin for
                    }
                }//fin for
                dtReglas.Rows[nfilaseleccionada]["lVigente"] = 0;
            }//fin else       
        }
        
        private void cargarOpcionesMenu(DataTable dt)
        {
            //cboMenu1.Nodes.Add("1", "Creditos");

            //cboMenu1.Nodes.Add("2", "ahorros");
            //cboMenu1.Nodes[0].Nodes.Add("11", "Registro de solicitud");

            //cboMenu1.Nodes[1].Nodes.Add("11", "apertura de ahorros");

            cboMenu1.Nodes.Clear();
            cboMenu1.Font=new Font("Comic Sans", 8F, System.Drawing.FontStyle.Regular);
            clsComboTreeNode padre;
            clsComboTreeNode hijo;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hijo = new clsComboTreeNode();
                    hijo.Name = dt.Rows[i]["cFormMenu"].ToString();
                    hijo.Text = dt.Rows[i]["cMenu"].ToString();
                    hijo.Tag = dt.Rows[i]["idMenu"].ToString();
                    if (dt.Rows[i]["idTipoMenu"].ToString() == "2")
                    {
                        hijo.ImageIndex = 4;
                        hijo.Text = hijo.Text.ToUpper();
                       // hijo.NodeFont = new Font("Comic Sans", 7F, System.Drawing.FontStyle.Bold);
                    }
                   // hijo.ToolTipText = dt.Rows[i]["cMenu"].ToString();
                    padre = FindParent(dt.Rows[i]["idMenuPadre"].ToString(), cboMenu1.Nodes);
                    if (padre == null)
                        this.cboMenu1.Nodes.Add(hijo);
                    else
                        padre.Nodes.Add(hijo);
                    padre = null;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private clsComboTreeNode FindParent(string NodoBusqueda, clsComboTreeNodeCollection nodos)
        {
            clsComboTreeNode padre = null;
            bool encontrado = false;
            int contador = 0;

            while (encontrado == false && contador < nodos.Count)
            {
                if (Convert.ToInt32(nodos[contador].Tag) == Convert.ToInt32(NodoBusqueda))
                {
                    encontrado = true;
                    padre = nodos[contador];
                }
                else
                {
                    if (nodos[contador].Nodes.Count > 0)
                    {
                        padre = FindParent(NodoBusqueda, nodos[contador].Nodes);
                        if (padre != null)
                        {
                            encontrado = true;
                        }
                    }
                }
                contador++;
            }
            return padre;
        }

        #endregion

    }
}
