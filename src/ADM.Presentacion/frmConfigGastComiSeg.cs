using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using ADM.CapaNegocio;
using EntityLayer;
using System.Diagnostics;

namespace ADM.Presentacion
{
    public partial class frmConfigGastComiSeg : frmBase
    {
        private Int32 CodPro = 1;
        Int32 idAgencia = clsVarGlobal.nIdAgencia;
        private DataSet dsConfigGastComiSeg = new DataSet("dsConfigGastComiSeg");

        //Tabla que contendrá el resultado de la Búsqueda de las configuraciones, servirá también para Insertar una nueva Configuración
        private DataTable dtConfigGastComiSeg = new DataTable("dtConfigGastComiSeg");
        
        clsCNConfigGastComiSeg ConfigGastComiSeg = new clsCNConfigGastComiSeg();
        private Int32 nNuevoActualizar = 0; //Variable que permite Guardar ó Actualizar una nueva Configuración de Gastos
                                            //1: NUEVA CONFIGURACIÓN
                                            //2: ACTUALIZAR CONFIGURACIÓN

        //Tabla que contendrá las configuraciones que se van a cambiar
        DataTable dtAuxActualizaConfig = new DataTable("dtAuxActualizaConfig");

        public frmConfigGastComiSeg()
        {
            InitializeComponent();          

            BuscarConfiguracionGastoComisionSeguro(0, 0, 0, 0);//recuperar la estructura del DataTable dtConfigGastComiSeg
            CargarCombos();                                

            cboFuenteRecurso.SelectedValue = 0;
            lblPorcentaje.Visible = false;    
            chcTodoTipo.Enabled=true;
            chcSubTipo.Enabled=false;
            chcTodoProducto.Enabled = false;

            dtAuxActualizaConfig.Columns.Add("idConfigGastComiSeg", typeof(int));
            dtAuxActualizaConfig.Columns.Add("lEstado", typeof(bool));
        }

        private void CargarCombos()
        {
            //cargar combo Productos
            cboTipoCredito.CargarProducto(CodPro);
            //cargar combo Tipo de Moneda
            DataTable dtMoneda = new clsCNMoneda().listarMoneda();
            for (int i = 0; i < dtMoneda.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtMoneda.Rows[i]["idMoneda"])<=0)
                {
                    dtMoneda.Rows[i].Delete();
                }
            }
            DataRow drMoneda = dtMoneda.NewRow();
            drMoneda["idMoneda"] = 0;
            drMoneda["cMoneda"] = "TODOS";
            dtMoneda.Rows.InsertAt(drMoneda, 0);
            this.cboMoneda1.DataSource = dtMoneda;
            this.cboMoneda1.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.cboMoneda1.DisplayMember = dtMoneda.Columns["cMoneda"].ToString();
            
            //cargar combo Tipo Persona
            DataTable dtPersona = new clsCNTipoPersona().listarTipoPersona();
            DataRow drPersona = dtPersona.NewRow();
            drPersona["idTipoPersona"] = 0;
            drPersona["cTipoPersona"] = "TODOS";
            dtPersona.Rows.InsertAt(drPersona, 0);
            this.cboTipoPersona.DataSource = dtPersona;
            this.cboTipoPersona.ValueMember = dtPersona.Columns["idTipoPersona"].ToString();
            this.cboTipoPersona.DisplayMember = dtPersona.Columns["cTipoPersona"].ToString();

            //Cargar combo canal
            DataTable dtCanal = new clsCNCanal().ListaCanal();
            DataRow drCanal = dtCanal.NewRow();
            drCanal["idCanal"] = 0;
            drCanal["cCanal"] = "TODOS";
            dtCanal.Rows.InsertAt(drCanal, 0);
            this.cboCanal.DataSource = dtCanal;
            this.cboCanal.ValueMember = dtCanal.Columns["idCanal"].ToString();
            this.cboCanal.DisplayMember = dtCanal.Columns["cCanal"].ToString();

            //cargar combo Grupo Gasto
            //quitar evento al cargar combo
            cboGrupoGasto.SelectedIndexChanged -= new
            EventHandler(cboGrupoGasto_SelectedIndexChanged);
                        
            cboGrupoGasto.DataSource = ConfigGastComiSeg.CargarGrupoGasto();
            cboGrupoGasto.DisplayMember = "cGrupoConcepto";
            cboGrupoGasto.ValueMember = "idGrupoConcepto";

            //añadir evento al caragar combo
            cboGrupoGasto.SelectedIndexChanged += new
            EventHandler(cboGrupoGasto_SelectedIndexChanged);         

            //cargar combo Aplica Concepto
            cboAplicaConcepto.DataSource = ConfigGastComiSeg.CargarAplicaConcepto();
            cboAplicaConcepto.ValueMember = "idAplicaConc";
            cboAplicaConcepto.DisplayMember = "cAplicaConc";

            //Cargar combo Aplica Cuota
            cboAplicaCuota.DataSource = ConfigGastComiSeg.CargarAplicarCuota();
            cboAplicaCuota.ValueMember = "idAplicaCuota";
            cboAplicaCuota.DisplayMember = "cAplicaCuota";

            //cargar combo Tipo Deuda
            cboTipoDeuda.DataSource = ConfigGastComiSeg.CargarTipoDeuda(1);
            cboTipoDeuda.DisplayMember = "cDescripcion";
            cboTipoDeuda.ValueMember = "idTipoDeuda";

            //cargar combo Tipo Entidad
            //se envía 1 para recuperar los tipos de entidades con indicador de fondeo 1
            cboTipoEntidad.cargarTipoDeEntidad("1");
            this.cboTipoEntidad.SelectedIndex = 0;

            //Cargar combo Entidad
            //se envía 1 para recuperar las entidades con indicador de fondeo 1
            cboEntidad.CargarEntidadesFondeo(Convert.ToInt32(this.cboTipoEntidad.SelectedValue), "1");
          
            //COMBOS DE BÚSQUEDA
            //Combo Gasto
            cboBuscarGrupoGasto.DataSource = ConfigGastComiSeg.CargarGrupoGasto();
            cboBuscarGrupoGasto.DisplayMember = "cGrupoConcepto";
            cboBuscarGrupoGasto.ValueMember = "idGrupoConcepto";
            cboMontos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboPlazos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboTipoDeuda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboTipoValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {           
            if (nNuevoActualizar==1)//Se va comportar para INSERTAR una NUEVA CONFIGURACIÓN
            {
                if (validaConfiguracion()==false)//true: si es correcto los campos,  false: si algún campo falta 
                {
                    return;
                }

                InsertarNuevaConfiguracion();
                grbFormulario.Enabled = false; 
            }
            if (nNuevoActualizar == 2)//Se va comportar para ACTUALIZAR las CONFIGURACIONES
            {
                ActualizarConfiguracion();               
            }
            btnGrabar1.Enabled = false;
        }

        private void ActualizarConfiguracion()
        {
            String XmlConfigGastComiSeg = "";
            dsConfigGastComiSeg.Tables.Add(dtAuxActualizaConfig);
            XmlConfigGastComiSeg = dsConfigGastComiSeg.GetXml();
            XmlConfigGastComiSeg = clsCNFormatoXML.EncodingXML(XmlConfigGastComiSeg);

            DataTable dtRespuesta = ConfigGastComiSeg.ActualizaConfigGastComiSeg(XmlConfigGastComiSeg);
            dtAuxActualizaConfig.Clear();
            dsConfigGastComiSeg.Clear();
            //Limpiar el DataSet
            dsConfigGastComiSeg.Clear();
            for (int i = 0; i < dsConfigGastComiSeg.Tables.Count; i++)
            {
                dsConfigGastComiSeg.Tables.RemoveAt(0);
            }
            MessageBox.Show("Se ha actualizado con éxito las Configuraciones", "Actualización de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }


        private void ArmarDataTable(ref DataTable dtTabla, String cNombreColumna,ref ComboBox cboComboSeleccion)
        {
            if (Convert.ToInt32(cboComboSeleccion.SelectedValue) == 0)//elije la opcion 'TODOS' del combo
            {
                foreach (var item in cboComboSeleccion.Items)
                {
                    DataRowView drvItem = item as DataRowView;
                    if (!drvItem[cNombreColumna].ToString().Equals("0"))
                    {
                        DataRow dr = dtTabla.NewRow();
                        dr[cNombreColumna] = drvItem[cNombreColumna];
                        dtTabla.Rows.Add(dr);
                    }
                }
            }
            else//elije un item específico
            {
                DataRow dr = dtTabla.NewRow();
                dr[cNombreColumna] = cboComboSeleccion.SelectedValue;
                dtTabla.Rows.Add(dr);
            }            
        }


        private void InsertarNuevaConfiguracion()
        {
            int nIndicadorNivelProducto = 0;   
            //{0,1,2,3,4}	Si es   4:Significa que se escogió un SubProducto específico
            //					    3:Significa que se escogerá todos los SubProductos para el 'Producto' seleccionado
            //					    2:Significa que se escogerá todos los SubProductos para el 'Subtipo'  seleccionado
            //					    1:
            //                          Si chcTodoTipo se ha seleccionado 
            //                              -se escogerá todos los SubProductos para el 'Módulo' seleccionado
            //                          Si chcSubTipo se ha seleccionado                  
            //                             -se escogerá todos los SubProductos para el 'Tipo de Crédito' seleccionado ó
            //					    0:Significa que escogió un Modulo diferente de DEPOSITOS ó CREDITO, por lo tanto no se tendrá en cuenta los SUB-PRODUCTOS

            //Definir los DataTables que contendrán las elecciones hechas para las combinaciones

            //****************************** Agencia ******************************           
            DataTable dtAgencia = new DataTable("dtAgencia");

            dtAgencia.Columns.Add("idAgencia", typeof(int));
            ComboBox cboAuxAgencia = cboAgencia;
            ArmarDataTable(ref dtAgencia, "idAgencia", ref cboAuxAgencia);


            //******************************  Moneda ******************************
            DataTable dtMoneda = new DataTable("dtMoneda");

            dtMoneda.Columns.Add("idMoneda", typeof(int));
            ComboBox cboAuxMoneda = cboMoneda1;
            ArmarDataTable(ref dtMoneda, "idMoneda", ref cboAuxMoneda);


            //******************************  Tipo Persona ******************************
            DataTable dtPersona = new DataTable("dtPersona");

            dtPersona.Columns.Add("idTipopersona", typeof(int));
            ComboBox cboAuxPersona = cboTipoPersona;
            ArmarDataTable(ref dtPersona, "idTipopersona", ref cboAuxPersona);


            //******************************  Modulo ******************************
            DataTable dtModulo = new DataTable("dtModulo");

            dtModulo.Columns.Add("idModulo", typeof(int));
            ComboBox cboAuxModulo = cboModulo;
            ArmarDataTable(ref dtModulo, "idModulo", ref cboAuxModulo);

            DataTable dtProducto = new DataTable("dtProducto");
            dtProducto.Columns.Add("idProducto", typeof(string));

            string cModulo = cboModulo.GetItemText(cboModulo.SelectedItem);
            if (cModulo.Equals("CREDITOS") || cModulo.Equals("DEPOSITOS"))
            {
                //******************************  Producto ******************************                                 
                if (chcTodoTipo.Checked)
                {
                    nIndicadorNivelProducto = 1;
                    DataRow dr = dtProducto.NewRow();
                    dr["idProducto"] = "%";
                    dtProducto.Rows.Add(dr);
                }
                else if (chcSubTipo.Checked)
                {
                    nIndicadorNivelProducto = 1;
                    DataRow dr = dtProducto.NewRow();
                    dr["idProducto"] = cboTipoCredito.SelectedValue;
                    dtProducto.Rows.Add(dr);
                }
                else if (chcTodoProducto.Checked)
                {
                    nIndicadorNivelProducto = 2;
                    DataRow dr = dtProducto.NewRow();
                    dr["idProducto"] = cboSubTipoCredito.SelectedValue;
                    dtProducto.Rows.Add(dr);
                }
                else if (chcTodoSubProducto.Checked)
                {
                    nIndicadorNivelProducto = 3;
                    DataRow dr = dtProducto.NewRow();
                    dr["idProducto"] = cboProducto.SelectedValue;
                    dtProducto.Rows.Add(dr);
                }
                else
                {
                    nIndicadorNivelProducto = 4;
                    DataRow dr = dtProducto.NewRow();
                    dr["idProducto"] = cboSubProducto.SelectedValue;
                    dtProducto.Rows.Add(dr);
                }
            }
            else
            {
                nIndicadorNivelProducto = 0;
                DataRow dr = dtProducto.NewRow();
                dr["idProducto"] = System.DBNull.Value;
                dtProducto.Rows.Add(dr);
            }

            DataTable dtTipoDeuda, dtEntidad;

            if (cModulo.Equals("CREDITOS"))
            {
                //******************************  Fuente de Recurso ******************************
                /*
                DataTable dtRecurso = new DataTable("dtRecurso");
                dtRecurso.Columns.Add("idFuenteRecurso", typeof(int));
                ComboBox cboAuxRecurso = cboFuenteRecurso;
                ArmarDataTable(ref dtRecurso, "idFuenteRecurso", ref cboAuxRecurso);
                */

                //******************************  Tipo de Deuda ******************************
                //Contendrá todas las combinaciones de fuente de recursos y TipoDeuda
                dtTipoDeuda = new DataTable("dtTipoDeuda");
                dtTipoDeuda.Columns.Add("idFuenteRecurso", typeof(int));
                dtTipoDeuda.Columns.Add("idTipoDeuda", typeof(int));

                //******************************  Tipo Entidad ******************************
                dtEntidad = new DataTable("dtEntidad");
                dtEntidad.Columns.Add("idFuenteRecurso", typeof(int));
                dtEntidad.Columns.Add("idTipoEntidad", typeof(int));              

                int idFuenteRecurso = Convert.ToInt32(cboFuenteRecurso.SelectedValue);            
                if (idFuenteRecurso == 0)//TODOS
                {
                    //Recorrer el Combo Recursos para obtener el ID para: PROPIOS y Externos
                    int nIdRecursosPropios  = 0;
                    int nIdRecursosExternos = 0;
                    DataTable dtFuenteRecurso   = (DataTable)cboFuenteRecurso.DataSource;
                    for (int c = 0; c < dtFuenteRecurso.Rows.Count; c++)
                    {
                        if (Convert.ToInt32(dtFuenteRecurso.Rows[c]["idFuenteRecurso"]) != 0)//Diferente de TODOS
                        {
                            if (Convert.ToBoolean(dtFuenteRecurso.Rows[c]["lEsRecursoPropio"]))//PROPIOS
                            {
                                nIdRecursosPropios = Convert.ToInt32(dtFuenteRecurso.Rows[c]["idFuenteRecurso"]);
                            }
                            else//EXTERNOS
                            {
                                nIdRecursosExternos = Convert.ToInt32(dtFuenteRecurso.Rows[c]["idFuenteRecurso"]);                                
                            }
                        }                       
                    }

                    //todos los -- Tipos Deuda
                    DataRow drTipoDeuda = dtTipoDeuda.NewRow();
                    drTipoDeuda["idFuenteRecurso"] = nIdRecursosPropios;
                    drTipoDeuda["idTipoDeuda"] = System.DBNull.Value;
                    dtTipoDeuda.Rows.Add(drTipoDeuda);

                    foreach (var itemTipoDeuda in cboTipoDeuda.Items)
                    {
                        DataRowView drvItemTipoDeuda = itemTipoDeuda as DataRowView;
                        if (drvItemTipoDeuda != null)
                        {
                            DataRow drTipoDeuda1 = dtTipoDeuda.NewRow();
                            drTipoDeuda1["idFuenteRecurso"] = nIdRecursosExternos;
                            drTipoDeuda1["idTipoDeuda"] = Convert.ToInt32(drvItemTipoDeuda["idTipoDeuda"].ToString());
                            dtTipoDeuda.Rows.Add(drTipoDeuda1);
                        }
                    }

                    //Todos las entidades
                    DataRow drEntidad = dtEntidad.NewRow();
                    drEntidad["idFuenteRecurso"] = nIdRecursosPropios;
                    drEntidad["idTipoEntidad"] = System.DBNull.Value;
                    dtEntidad.Rows.Add(drEntidad);

                    foreach (var itemTipoEntidad in cboTipoEntidad.Items)
                    {
                        DataRowView drvItemTipoEntidad = itemTipoEntidad as DataRowView;
                        if (drvItemTipoEntidad != null)
                        {
                            cboEntidad.CargarEntidadesFondeo(Convert.ToInt32(drvItemTipoEntidad["idTipoEntidad"].ToString()), "1");
                            foreach (var itemEntidad in cboEntidad.Items)
                            {
                                DataRowView drvItemEntidad = itemEntidad as DataRowView;
                                if (drvItemEntidad != null)
                                {
                                    DataRow drEntidad2 = dtEntidad.NewRow();
                                    drEntidad2["idFuenteRecurso"] = nIdRecursosExternos;
                                    drEntidad2["idTipoEntidad"] = Convert.ToInt32(drvItemEntidad["idEntidad"].ToString());
                                    dtEntidad.Rows.Add(drEntidad2);
                                }
                            }
                        }
                    }
                }
                else//UN RECURSO ESPECÍFICO
                {
                    DataTable dtFuenteRecurso = (DataTable)cboFuenteRecurso.DataSource;
                    Boolean lEsRecursoPropio = false;

                    for (int c = 0; c < dtFuenteRecurso.Rows.Count; c++)
                    {
                        if (idFuenteRecurso == Convert.ToInt32(dtFuenteRecurso.Rows[c]["idFuenteRecurso"]))
                        {
                            lEsRecursoPropio = Convert.ToBoolean(dtFuenteRecurso.Rows[c]["lEsRecursoPropio"]);
                        }
                    }

                    if (lEsRecursoPropio)//PROPIOS
                    {
                        //Tipo Deuda -- nulo
                        DataRow drTipoDeuda = dtTipoDeuda.NewRow();
                        drTipoDeuda["idFuenteRecurso"] = cboFuenteRecurso.SelectedValue;
                        drTipoDeuda["idTipoDeuda"] = System.DBNull.Value;
                        dtTipoDeuda.Rows.Add(drTipoDeuda);

                        //Entidad -- nulo
                        DataRow drEntidad = dtEntidad.NewRow();
                        drEntidad["idFuenteRecurso"] = cboFuenteRecurso.SelectedValue;
                        drEntidad["idTipoEntidad"] = System.DBNull.Value;
                        dtEntidad.Rows.Add(drEntidad);
                    }
                    else//NO PROPIOS
                    {
                        //Tipo Deuda
                        DataRow drTipoDeuda = dtTipoDeuda.NewRow();
                        drTipoDeuda["idFuenteRecurso"] = cboFuenteRecurso.SelectedValue;
                        drTipoDeuda["idTipoDeuda"] = cboTipoDeuda.SelectedValue;
                        dtTipoDeuda.Rows.Add(drTipoDeuda);

                        //Entidad
                        DataRow drEntidad = dtEntidad.NewRow();
                        drEntidad["idFuenteRecurso"] = cboFuenteRecurso.SelectedValue;
                        drEntidad["idTipoEntidad"] = cboEntidad.SelectedValue;
                        dtEntidad.Rows.Add(drEntidad);
                    }
                }
            }//Fin cModulo.Equals("CREDITOS"))
            else
            {//No se consideran: FuenteRecursos - TipoDeuda - Entidad

                //******************************  Tipo de Deuda ******************************
                //Contendrá todas las combinaciones de fuente de recursos y TipoDeuda
                dtTipoDeuda = new DataTable("dtTipoDeuda");
                dtTipoDeuda.Columns.Add("idFuenteRecurso", typeof(int));
                dtTipoDeuda.Columns.Add("idTipoDeuda", typeof(int));

                DataRow drTipoDeuda = dtTipoDeuda.NewRow();
                drTipoDeuda["idFuenteRecurso"]  = 0;
                drTipoDeuda["idTipoDeuda"]      = System.DBNull.Value;
                dtTipoDeuda.Rows.Add(drTipoDeuda);

                dtEntidad = new DataTable("dtEntidad");
                dtEntidad.Columns.Add("idFuenteRecurso", typeof(int));
                dtEntidad.Columns.Add("idTipoEntidad", typeof(int));

                DataRow drEntidad = dtEntidad.NewRow();
                drEntidad["idFuenteRecurso"]    = 0;
                drEntidad["idTipoEntidad"]      = System.DBNull.Value;
                dtEntidad.Rows.Add(drEntidad);
            }

            //******************************  Canal ******************************
            DataTable dtCanal = new DataTable("dtCanal");
            dtCanal.Columns.Add("idCanal", typeof(int));
            ComboBox cboAuxCanal = cboCanal;
            ArmarDataTable(ref dtCanal, "idCanal", ref cboAuxCanal);

            //******************************  Campos Fijos ******************************
            dtConfigGastComiSeg.TableName = "dtConfigGastComiSeg";
            DataRow drConfigGastComiSeg = dtConfigGastComiSeg.NewRow();

            //TipoOperacion
            dtConfigGastComiSeg.Columns.Add("idTipoOperacion",typeof(int));
            drConfigGastComiSeg["idTipoOperacion"] = 0;

            String cadModulo = cboModulo.GetItemText(cboModulo.SelectedItem);
            cadModulo = cModulo.Trim().ToUpper();
            if (cadModulo.Equals("CREDITOS") || cadModulo.Equals("DEPOSITOS"))
            {
                drConfigGastComiSeg["idTipoOperacion"] = cboTipoOperacion.SelectedValue;
            } 
            
            dtConfigGastComiSeg.Columns.Add("idConcepto", typeof(int));
            drConfigGastComiSeg["idConcepto"] = cboTipoGasto.SelectedValue;

            dtConfigGastComiSeg.Columns.Add("idTipoValor", typeof(int));
            drConfigGastComiSeg["idTipoValor"] = cboTipoValor.SelectedValue;

             drConfigGastComiSeg["nValorAplica"] = txtValorAplica.Text;
 
            drConfigGastComiSeg["idMonto"] = cboMontos.SelectedValue;

            drConfigGastComiSeg["idContable"] = System.DBNull.Value;
            if (cadModulo.Equals("CREDITOS") || cadModulo.Equals("DEPOSITOS"))
            {
                drConfigGastComiSeg["idContable"] = cboCondicionContable1.SelectedValue;
            }            

            drConfigGastComiSeg["cDescripcion"] = txtDescripcion.Text;
            drConfigGastComiSeg["idPlazo"] = cboPlazos.SelectedValue;

            drConfigGastComiSeg["lEstado"] = Convert.ToInt32(chcEstadoGasto.Checked);
            dtConfigGastComiSeg.Columns.Add("idAplicaConc", typeof(int));
            drConfigGastComiSeg["idAplicaConc"] =   (cboAplicaConcepto.SelectedValue == null) ? 0 : cboAplicaConcepto.SelectedValue;

            drConfigGastComiSeg["idAplicaCuota"]    = (cboAplicaCuota.SelectedValue == null) ? 0 : cboAplicaCuota.SelectedValue;
            drConfigGastComiSeg["lAplicaImpreOpe"]  = Convert.ToInt32(chcAplicaImpreOpe.Checked);
            drConfigGastComiSeg["lObligatorio"]     = Convert.ToInt32(chcGastoObligatorio.Checked);
            drConfigGastComiSeg["lAplicaContable"]  = Convert.ToInt32(chcConfigAsientosContables.Checked);

            drConfigGastComiSeg["cConcepto"] = "";

            //dtConfigGastComiSeg.Columns.Add("idTipoPago", typeof(int));
            drConfigGastComiSeg["idTipoPago"] = cboTipoPago.SelectedValue;
            dtConfigGastComiSeg.Rows.Add(drConfigGastComiSeg);

            String XmlConfigGastComiSeg = "";

            dsConfigGastComiSeg.Tables.Add(dtAgencia);
            dsConfigGastComiSeg.Tables.Add(dtMoneda);
            dsConfigGastComiSeg.Tables.Add(dtPersona);
            dsConfigGastComiSeg.Tables.Add(dtModulo);
            dsConfigGastComiSeg.Tables.Add(dtProducto);
            //dsConfigGastComiSeg.Tables.Add(dtRecurso);
            dsConfigGastComiSeg.Tables.Add(dtTipoDeuda);
            dsConfigGastComiSeg.Tables.Add(dtEntidad);
            dsConfigGastComiSeg.Tables.Add(dtCanal);
            dsConfigGastComiSeg.Tables.Add(dtConfigGastComiSeg);

            XmlConfigGastComiSeg = dsConfigGastComiSeg.GetXml();
            XmlConfigGastComiSeg = clsCNFormatoXML.EncodingXML(XmlConfigGastComiSeg);

            int idDetalleGasto = cboDetalleGasto1.SelectedIndex >= 0 ? Convert.ToInt32(cboDetalleGasto1.SelectedValue) : 0;
            int nResultado = ConfigGastComiSeg.InsertaActualizaConfigGastComiSeg(XmlConfigGastComiSeg, nIndicadorNivelProducto, idDetalleGasto);
            //nResultado {-1,n} -1: en caso haya ocurrido un error al insertar las filas
            //                   n: la cantidad de configuraciones registradas
            //                  n=0: no existen SUB-PRODUCTOS existentes para aplicar la Configuración

            if (nResultado == 0)
            {
                MessageBox.Show("No existen SUB-Productos al cual aplicar las configuraciones" + System.Environment.NewLine
                                + "Elija OTRO SUB-PRODUCTO.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (nResultado == -1)
            {
                MessageBox.Show("Se produjo un ERROR AL GUARDAR la configuración.", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnGrabar1.Enabled = false;
            }
            if (nResultado > 0)
            {
                MessageBox.Show("La Configuración se ha guardado satisfactoriamente.", "Guardar Nueva Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGrabar1.Enabled = false;
            }
            dsConfigGastComiSeg.Clear();
            dsConfigGastComiSeg.Tables.Remove(dtAgencia);
            dsConfigGastComiSeg.Tables.Remove(dtMoneda);
            dsConfigGastComiSeg.Tables.Remove(dtPersona);
            dsConfigGastComiSeg.Tables.Remove(dtModulo);
            dsConfigGastComiSeg.Tables.Remove(dtProducto);
            //dsConfigGastComiSeg.Tables.Remove(dtRecurso);
            dsConfigGastComiSeg.Tables.Remove(dtTipoDeuda);
            dsConfigGastComiSeg.Tables.Remove(dtEntidad);
            dsConfigGastComiSeg.Tables.Remove(dtCanal);
            dsConfigGastComiSeg.Tables.Remove(dtConfigGastComiSeg); 
        }

#region validaConfiguracion
        private Boolean validaConfiguracion()
        {
            if (Convert.ToInt32(cboAgencia.SelectedValue) < 0)
            {
                MessageBox.Show("Debe seleccionar una agencia ó las agencias a las que afectará la configuración de gastos.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToInt32(cboMoneda1.SelectedValue) < 0)
            {
                MessageBox.Show("Debe seleccionar la moneda o monedas para la configuración.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToInt32(cboTipoPersona.SelectedValue) < 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de persona.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }                     
            
            //Validación de Productos en función al Módulo
            String cModulo = cboModulo.GetItemText(cboModulo.SelectedItem).Trim().ToUpper();

            if (cModulo.Equals(""))
            {
                MessageBox.Show("Debe seleccionar un Módulo.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cModulo.Equals("CREDITOS") || cModulo.Equals("DEPOSITOS"))
            {
                Boolean lEstaSeleccionadoAlgunCheck = false;

                //Verfificar que tenga seleccionado algún check,ó un SUBPRODUCTO específico seleccionado
                if (chcTodoTipo.Checked) { lEstaSeleccionadoAlgunCheck = true; }
                if (chcSubTipo.Checked) { lEstaSeleccionadoAlgunCheck = true; }
                if (chcTodoProducto.Checked) { lEstaSeleccionadoAlgunCheck = true; }
                if (chcTodoSubProducto.Checked) { lEstaSeleccionadoAlgunCheck = true; }

                if (lEstaSeleccionadoAlgunCheck==false)
                {
                    if (Convert.ToInt32(cboSubProducto.SelectedValue)==0)
                    {
                        MessageBox.Show("Debe seleccionar un TIPO, SUBTIPO, PRODUCTO ó SUB-PRODUCTO.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }                    
                }
            }

            if (cModulo.Equals("CREDITOS"))
            {
                //Validación para el combo Entidad        
                String cEntidad = cboEntidad.GetItemText(cboEntidad.SelectedItem);

                //--------------------------------Identificar si la fuente de recursos NO SON PROPIOS ------------------------------>
                int idFuenteRecurso         = Convert.ToInt32(cboFuenteRecurso.SelectedValue);
                DataTable dtFuenteRecurso   = (DataTable)cboFuenteRecurso.DataSource;
                Boolean lEsRecursoPropio    = false;
                for (int c = 0; c < dtFuenteRecurso.Rows.Count; c++)
                {
                    if (idFuenteRecurso == Convert.ToInt32(dtFuenteRecurso.Rows[c]["idFuenteRecurso"]))
                    {
                        lEsRecursoPropio = Convert.ToBoolean(dtFuenteRecurso.Rows[c]["lEsRecursoPropio"]);
                    }
                }
                //----------------------------------------------------------------------------------------------------------------->

                if (cEntidad.Equals("") && idFuenteRecurso!=0 && lEsRecursoPropio == false)
                {
                    MessageBox.Show("Configuración no tiene una Entidad asignada.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }               
            }
      
            String cTipoGasto = cboTipoGasto.GetItemText(cboTipoGasto.SelectedItem);
            if (cTipoGasto.Trim().Equals(""))
            {
                MessageBox.Show("Configuración no tiene un TIPO DE GASTO asignado.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            String cTipoValor = cboTipoValor.GetItemText(cboTipoValor.SelectedItem).Trim().ToUpper();
            if (cTipoValor.Equals("FIJO") == false)
            {
                //Validar la afectación
                if (cboAplicaConcepto.SelectedIndex < 0)//Tiene que tener seleccionado un concepto válido
                {
                    MessageBox.Show("Debe seleccionar el Concepto al que se afectará.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                //validacion del valor que se aplicará
                if (string.IsNullOrEmpty(txtValorAplica.Text))
                {
                    MessageBox.Show("Registre el valor con que se aplicará la configuración.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (txtValorAplica.Text.Equals("."))
                {
                    txtValorAplica.Text = "0.0000";
                }

                if (Convert.ToDecimal (txtValorAplica.Text) > 100.0000m)
                {
                    MessageBox.Show("El Valor Porcentual no puede ser > 100.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtValorAplica.Focus();
                    return false;
                }
            }

            if (Convert.ToInt32(cboMontos.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe seleccionar los Montos.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToInt32(cboPlazos.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe seleccionar los Plazos.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //validacion del valor que se aplicará
            if (string.IsNullOrEmpty(txtValorAplica.Text))
            {
                MessageBox.Show("Registre el valor con que se aplicará la configuración.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtValorAplica.Text.Equals("."))
            {
                txtValorAplica.Text = "0.0000";
            }

            //validacion del valor que se aplicará
            if (Convert.ToDecimal(txtValorAplica.Text) == 0)
            {
                MessageBox.Show("El valor a aplicar debe ser mayor que 0.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValorAplica.Focus();
                return false;
            }            

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Registre una DESCRIPCIÓN para la configuración.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion.Focus();
                return false;
            }

            return true;//Si todo es correcto
        }
#endregion

#region Cargar Combos

        private void cboTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCredito.SelectedIndex > 0)
            {
                CodPro = Convert.ToInt32(cboTipoCredito.SelectedValue);
                cboSubTipoCredito.CargarProducto(CodPro);
                chcTodoTipo.Enabled = true;
            }
            else
            {
                cboTipoCredito.SelectedIndex = 0;
                cboSubTipoCredito.CargarProducto(999);
                chcTodoTipo.Enabled = false;
            }
        }
        private void cboSubTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipoCredito.SelectedIndex > 0)
            {

                CodPro = Convert.ToInt32(cboSubTipoCredito.SelectedValue);
                cboProducto.CargarProducto(CodPro);
                chcTodoTipo.Enabled = false;
                chcSubTipo.Enabled = true;
                chcTodoProducto.Enabled = false;
                chcTodoSubProducto.Enabled = false;
            }
            else
            {
                cboSubTipoCredito.SelectedIndex = 0;
                cboProducto.CargarProducto(999);
                chcSubTipo.Enabled = false;
                chcTodoSubProducto.Enabled = false;
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                CodPro = Convert.ToInt32(cboProducto.SelectedValue);
                cboSubProducto.CargarProducto(CodPro);
                chcSubTipo.Enabled = false;
                chcTodoProducto.Enabled = true;
                chcTodoSubProducto.Enabled = false;
            }
            else
            {
                cboProducto.SelectedIndex = 0;
                cboSubProducto.CargarProducto(999);
                chcSubTipo.Enabled = false;
                chcTodoProducto.Enabled = false;
                chcTodoSubProducto.Enabled = false;
            }
        }

#endregion

#region BuscarConfiguracionCredito
        private void BuscarConfiguracionGastoComisionSeguro(Int32 IdModulo, Int32 IdAgencia, Int32 IdMoneda, Int32 IdGrupoGasto)
        {
            dtConfigGastComiSeg = ConfigGastComiSeg.BuscarConfigGastoComisionSeguro(IdModulo,IdAgencia,IdMoneda,IdGrupoGasto);

            if (dtConfigGastComiSeg.Rows.Count > 0)
            {
                this.dtgConfigGastComiSeg.DataSource = dtConfigGastComiSeg;                          
            }
        }
#endregion

        private void cboFuenteRecurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idFuenteRecurso = Convert.ToInt32(cboFuenteRecurso.SelectedValue);
            if (idFuenteRecurso!=0)
            {
                //--------------------------------Identificar si la fuente de recursos NO SON PROPIOS ------------------------------>
                DataTable dtFuenteRecurso = (DataTable)cboFuenteRecurso.DataSource;
                Boolean lEsRecursoPropio = false;
                for (int c = 0; c < dtFuenteRecurso.Rows.Count; c++)
                {
                    if (idFuenteRecurso == Convert.ToInt32(dtFuenteRecurso.Rows[c]["idFuenteRecurso"]))
                    {
                        lEsRecursoPropio = Convert.ToBoolean(dtFuenteRecurso.Rows[c]["lEsRecursoPropio"]);
                    }
                }
                //----------------------------------------------------------------------------------------------------------------->

                if (lEsRecursoPropio == false)
                {
                    cboTipoDeuda.Enabled = true;
                    cboTipoEntidad.Enabled = true;
                    cboEntidad.Enabled = true;
                }
                else
                {
                    cboTipoDeuda.Enabled = false;
                    cboTipoEntidad.Enabled = false;
                    cboEntidad.Enabled = false;
                }
            }
            else
            {
                cboTipoDeuda.Enabled    = false;
                cboTipoEntidad.Enabled  = false;
                cboEntidad.Enabled      = false;
            }
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (cboBuscarModulo.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un Módulo para realizar la búsqueda.", "Búsqueda Configuración Gastos Comisiones y Seguros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grbFormulario.Enabled = false;

            LimpiarDatos();
            grbFormulario.Enabled = false;
            dtConfigGastComiSeg         = ConfigGastComiSeg.BuscarConfigGastoComisionSeguro(Convert.ToInt32(cboBuscarModulo.SelectedValue), Convert.ToInt32(cboBuscarAgencia.SelectedValue), Convert.ToInt32(cboBuscarMoneda.SelectedValue), Convert.ToInt32(cboBuscarGrupoGasto.SelectedValue));
            LblTotalRegistros.Visible   = true;
            LblTotalRegistros.Text      = "Total de registros : " + dtConfigGastComiSeg.Rows.Count.ToString();
            dtgConfigGastComiSeg.Enabled = true;

            nNuevoActualizar=2;//Se va comportar para ACTUALIZAR CONFIGURACIÓN
            
            //Dar permiso a la tabla de para poder hacer check
            foreach (DataColumn dcColumna in dtConfigGastComiSeg.Columns)
            {
                if (dcColumna.ColumnName.Equals("lEstado"))
                {
                    dcColumna.ReadOnly = false;
                }
                else
                {
                    dcColumna.ReadOnly = true;
                }
            }

            this.dtgConfigGastComiSeg.DataSource = dtConfigGastComiSeg;
            dtgConfigGastComiSeg.ReadOnly = false;

            for (int i = 0; i < dtgConfigGastComiSeg.Columns.Count; i++)
            {
                this.dtgConfigGastComiSeg.Columns[i].Visible = false;
                if (dtgConfigGastComiSeg.Columns[i].Name.Equals("lEstado"))
                {
                    dtgConfigGastComiSeg.Columns[i].ReadOnly = false;
                }
                else
	            {
                    dtgConfigGastComiSeg.Columns[i].ReadOnly = true;
	            }
            }

            this.dtgConfigGastComiSeg.Columns["idConfigGastComiSeg"].Visible = false;

            this.dtgConfigGastComiSeg.Columns["cTipopersona"].Visible = true;
            this.dtgConfigGastComiSeg.Columns["cTipopersona"].HeaderText = "Tipo Persona";

            this.dtgConfigGastComiSeg.Columns["cProducto"].Visible = true;
            this.dtgConfigGastComiSeg.Columns["cProducto"].HeaderText = "Producto";

            this.dtgConfigGastComiSeg.Columns["nValorAplica"].Visible = true;
            this.dtgConfigGastComiSeg.Columns["nValorAplica"].HeaderText = "Valor Aplica";

            this.dtgConfigGastComiSeg.Columns["cTipoOperacion"].Visible = true;
            this.dtgConfigGastComiSeg.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";

            this.dtgConfigGastComiSeg.Columns["cConcepto"].Visible = true;
            this.dtgConfigGastComiSeg.Columns["cConcepto"].HeaderText = "Concepto";

            this.dtgConfigGastComiSeg.Columns["cCanal"].Visible = true;
            this.dtgConfigGastComiSeg.Columns["cCanal"].HeaderText = "Canal";

            this.dtgConfigGastComiSeg.Columns["lEstado"].Visible = true;
            this.dtgConfigGastComiSeg.Columns["lEstado"].HeaderText = "Vigente";

            this.dtgConfigGastComiSeg.Columns["cTipoValor"].Visible = true;
            this.dtgConfigGastComiSeg.Columns["cTipoValor"].HeaderText = "Tipo Valor";

            this.dtgConfigGastComiSeg.Columns["cAplicaConc"].Visible = true;
            this.dtgConfigGastComiSeg.Columns["cAplicaConc"].HeaderText = "Aplicar a";

            dtgConfigGastComiSeg.Columns["cProducto"].Width = 100;
            dtgConfigGastComiSeg.Columns["cConcepto"].Width = 120;
            dtgConfigGastComiSeg.Columns["cTipoValor"].Width = 100;
            dtgConfigGastComiSeg.Columns["nValorAplica"].Width = 88;
            dtgConfigGastComiSeg.Columns["cAplicaConc"].Width = 100;
            dtgConfigGastComiSeg.Columns["cTipopersona"].Width = 95;
            dtgConfigGastComiSeg.Columns["cCanal"].Width = 90;       
            dtgConfigGastComiSeg.Columns["cTipoOperacion"].Width = 120;  
        }

        private void cboTipoValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            String cTipoValor = cboTipoValor.GetItemText(cboTipoValor.SelectedItem).Trim().ToUpper();

            if (cTipoValor.Equals("FIJO"))
            {
                lblPorcentaje.Visible       = false;
                cboAplicaConcepto.Enabled   = false;
                cboAplicaConcepto.SelectedIndex = -1;
            }
            else
            {
                lblPorcentaje.Visible = true;
                cboAplicaConcepto.Enabled = true;
            }
        }

#region Eventos_Checked_paraProductos
        private void chcTodoTipoCreAho_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTodoTipo.Checked)
            {
                cboSubTipoCredito.Enabled = false;
                cboTipoCredito.Enabled = false;
                cboProducto.Enabled = false;
                cboSubProducto.Enabled = false;              
            }
            else
            {
                cboTipoCredito.Enabled = true;
                cboSubTipoCredito.Enabled = true;
                cboProducto.Enabled = true;
                cboSubProducto.Enabled = true;
            }
        }

        private void chcSubTipoCreAho_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSubTipo.Checked)
            {               
                cboTipoCredito.Enabled = false;
                cboSubTipoCredito.Enabled = false;
                cboProducto.Enabled = false;
                cboSubProducto.Enabled = false;
            }
            else
            {
                cboTipoCredito.Enabled = true;
                cboSubTipoCredito.Enabled = true;
                cboProducto.Enabled = true;
                cboSubProducto.Enabled = true;            
            }
        }

        private void chcTodoProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTodoProducto.Checked)
            {
                cboTipoCredito.Enabled = false;
                cboSubTipoCredito.Enabled = false;
                cboProducto.Enabled = false;
                cboSubProducto.Enabled = false;
            }
            else
            {
                cboTipoCredito.Enabled = true;
                cboSubTipoCredito.Enabled = true;
                cboProducto.Enabled = true;
                cboSubProducto.Enabled = true;
            }
        }
#endregion

        private void cboSubProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubProducto.SelectedIndex > 0)
            {
                chcTodoTipo.Enabled = false;
                chcSubTipo.Enabled = false;
                chcTodoProducto.Enabled = false;
                chcTodoSubProducto.Enabled = true;
            }
            else
            {
                chcTodoTipo.Enabled = false;
                chcSubTipo.Enabled = false;
                chcTodoProducto.Enabled = false;
                chcTodoSubProducto.Enabled = false;
            }
        }

        private void cboGrupoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIdGrupoGasto = Convert.ToInt32(cboGrupoGasto.SelectedValue.ToString());
            if (nIdGrupoGasto > 0)
            {
                cboTipoGasto.DataSource = ConfigGastComiSeg.CargarConcepto(nIdGrupoGasto);
                cboTipoGasto.DisplayMember = "cConcepto";
                cboTipoGasto.ValueMember = "idConcepto";
                if (cboGrupoGasto.GetItemText(cboGrupoGasto.SelectedItem).Trim().ToUpper().Equals("PORTES"))
                {
                    cboTipoGasto.Enabled = false;
                }
                else
                {
                    cboTipoGasto.Enabled        = true;
                }                
            }
        }

        private void cboTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboEntidad.CargarEntidadesFondeo(Convert.ToInt32(this.cboTipoEntidad.SelectedValue), "1"); 
        }

        private void chcTodoSubProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTodoSubProducto.Checked)
            {
                cboTipoCredito.Enabled = false;
                cboSubTipoCredito.Enabled = false;
                cboProducto.Enabled = false;
                cboSubProducto.Enabled = false;
            }
            else
            {
                cboTipoCredito.Enabled = true;
                cboSubTipoCredito.Enabled = true;
                cboProducto.Enabled = true;
                cboSubProducto.Enabled = true;
            }
        }

        private void frmConfigGastComiSeg_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cboModulo.CargarProducto(0);
            cboBuscarModulo.CargarProducto(0);
            dtgConfigGastComiSeg.Enabled = false;
            nNuevoActualizar = 1;//Se va comportar para insertar NUEVA CONFIGURACIÓN

            cboMontos.CargarMontos(0);
            cboPlazos.CargarPLazos(0);

            //Cargar Tipo de Gastos
            int nIdGrupoGasto = Convert.ToInt32(cboGrupoGasto.SelectedValue.ToString());
            if (nIdGrupoGasto > 0)
            {
                cboTipoGasto.DataSource = ConfigGastComiSeg.CargarConcepto(nIdGrupoGasto);
                cboTipoGasto.DisplayMember = "cConcepto";
                cboTipoGasto.ValueMember = "idConcepto";
            }
            else
            {
                MessageBox.Show("No hay elementos en el GRUPO DE GASTOS.", "Configuración de Gastos Comisiones Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Habilitar AFECTACIÓN
            int nIdTipoValor = Convert.ToInt32(cboTipoValor.SelectedValue.ToString());
            if (nIdTipoValor > 0)
            {
                if (cboTipoValor.GetItemText(cboTipoValor.SelectedItem).Trim().ToUpper().Equals("FIJO"))
                {
                    cboAplicaConcepto.Enabled=false;
                    cboAplicaConcepto.SelectedIndex = -1;
                }
                else
                {
                    cboAplicaConcepto.Enabled=true;
                }
            }

            cboModulo_SelectedIndexChanged(sender, e);
            
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            LblTotalRegistros.Visible = false;
            BuscarConfiguracionGastoComisionSeguro(0, 0, 0, 0);//recuperar la estructura del DataTable dtConfigGastComiSeg
            cboModulo.SelectedIndex = 0;
            chcTodoTipo.Enabled = false;
            nNuevoActualizar = 1;//El botón GUARDAR se va comportar para guardar una nueva confgiguración
        }

        private void LimpiarDatos()
        {
            cboAgencia.SelectedIndex        = 0;
            cboMoneda1.SelectedIndex        = 0;
            cboTipoPersona.SelectedIndex    = 0;
            cboModulo.SelectedIndex         = 0;

            //descheckear
            chcTodoTipo.Checked         = false;
            chcSubTipo.Checked          = false;
            chcTodoProducto.Checked     = false;
            chcTodoSubProducto.Checked  = false;
            
            //inhabilitar checks productos
            chcTodoTipo.Enabled         = false;
            chcSubTipo.Enabled          = false;
            chcTodoProducto.Enabled     = false;
            chcTodoSubProducto.Enabled = false;
            
            cboTipoCredito.CargarProducto(-1);

            cboFuenteRecurso.SelectedIndex = 0;
            cboTipoOperacion.LisTiposOperacProducto(-1);

            cboGrupoGasto.SelectedIndex = 0;
            cboTipoValor.SelectedIndex = 0;

            cboMontos.CargarMontos(1);
            cboMontos.SelectedIndex = -1;
            cboPlazos.CargarPLazos(1);
            cboPlazos.SelectedIndex = -1;

            txtValorAplica.Text = "0.0000";
            cboAplicaCuota.SelectedIndex = 0;
            txtDescripcion.Text = "";
            cboCanal.SelectedIndex = 0;

            cboCondicionContable1.Enabled = false;
            cboCondicionContable1.ListarCondicionContablexProducto(-1);

            chcEstadoGasto.Checked              = false;
            chcAplicaImpreOpe.Checked           = false;
            chcGastoObligatorio.Checked         = false;
            chcConfigAsientosContables.Checked  = false;

            //Limpiar el DataSet
            dsConfigGastComiSeg.Clear();
            for (int i = 0; i < dsConfigGastComiSeg.Tables.Count; i++)
            {
                dsConfigGastComiSeg.Tables.RemoveAt(0);
            }

            dtgConfigGastComiSeg.DataSource = null;

            dtConfigGastComiSeg.Clear();
            dtConfigGastComiSeg = null;
            dtAuxActualizaConfig.Clear();

            nNuevoActualizar = 0;
            dtgConfigGastComiSeg.Enabled = false;
            grbFormulario.Enabled = true;
            btnGrabar1.Enabled = true;
        }


        private void dtgConfigGastComiSeg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Obtener la columna columna actual seleccionada de la fila 
            if (dtgConfigGastComiSeg.CurrentCell.OwningColumn.Name.Equals("lEstado"))
            {
                int nfilaseleccionada = Convert.ToInt32(this.dtgConfigGastComiSeg.CurrentRow.Index);
                int nIdConfigGasto = Convert.ToInt32(dtConfigGastComiSeg.Rows[nfilaseleccionada]["idConfigGastComiSeg"]);

                if (Convert.ToBoolean(dtConfigGastComiSeg.Rows[nfilaseleccionada]["lEstado"]) == false)//Va cambiar de 'No Check' a 'check'
                {
                    dtConfigGastComiSeg.Rows[nfilaseleccionada]["lEstado"] = true;
                    ModificarConfiguracion(nIdConfigGasto, true);
                }
                else
                {
                    dtConfigGastComiSeg.Rows[nfilaseleccionada]["lEstado"] = false;
                    ModificarConfiguracion(nIdConfigGasto, false);
                }  
            }
        }
        private void ModificarConfiguracion(Int32 nIdConfigGasto, bool lEstado)
        {
            Boolean lRepiteElemento = false;

	        //Verificar que no se esté repitiendo la inserción
            int nCantidadFilas = dtAuxActualizaConfig.Rows.Count;
            for (int i = 0; i < nCantidadFilas; i++)
            {
                if (Convert.ToInt32(dtAuxActualizaConfig.Rows[i]["idConfigGastComiSeg"]) == nIdConfigGasto)
                {
                    lRepiteElemento = true;
                    //Actualizar
                    dtAuxActualizaConfig.Rows[i]["lEstado"] = lEstado;
                    break;
                }
            }

            if (lRepiteElemento == false)
            {   //Insertar
                DataRow fila = dtAuxActualizaConfig.NewRow();
                fila["idConfigGastComiSeg"] = nIdConfigGasto;
                fila["lEstado"] = lEstado;
                dtAuxActualizaConfig.Rows.Add(fila);
            }
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTipoOperacion.Enabled = false;

            String cModulo  =   cboModulo.GetItemText(cboModulo.SelectedItem);
            cModulo         =   cModulo.Trim().ToUpper();

            if (cModulo.Equals("CREDITOS"))
            {
                chcTodoTipo.Text = "Tipo Crédito:";
                cboTipoCredito.Enabled = true;
                cboTipoCredito.CargarProducto(Convert.ToInt32(cboModulo.SelectedValue));
                cboSubTipoCredito.Enabled = true;
                cboProducto.Enabled = true;
                cboSubProducto.Enabled = true;

                if (chcTodoTipo.Checked)
                {
                    chcTodoTipo.Enabled = true;
                    chcTodoTipoCreAho_CheckedChanged(sender, e);
                }
                if (chcSubTipo.Checked)
                {
                    chcSubTipo.Enabled = true;
                    chcSubTipoCreAho_CheckedChanged(sender, e);
                }
                if (chcTodoProducto.Checked)
                {
                    chcTodoProducto.Enabled = true;
                    chcTodoProducto_CheckedChanged(sender, e);
                }

                cboCondicionContable1.Enabled = true;
                cboCondicionContable1.ListarCondicionContablexProducto(Convert.ToInt32(cboModulo.SelectedValue));
                cboTipoOperacion.Enabled = true;
                if (Convert.ToInt32(cboFuenteRecurso.SelectedValue) == 0)
                {
                    cboTipoDeuda.Enabled    = false;
                    cboTipoEntidad.Enabled  = false;
                    cboEntidad.Enabled      = false;
                }
                else
                {
                    cboTipoDeuda.Enabled    = true;
                    cboTipoEntidad.Enabled  = true;
                    cboEntidad.Enabled      = true;
                }

                cboTipoOperacion.LisTiposOperacProducto(Convert.ToInt32(cboModulo.SelectedValue));
                chcTodoTipo.Enabled = true;//-->

                cboMontos.CargarMontos(1);
                cboPlazos.CargarPLazos(1);

                //AplicarCuota
                cboAplicaCuota.SelectedIndex = 0;
                cboAplicaCuota.Enabled = true;

                //llamar evento
                cboFuenteRecurso.Enabled = true;
                cboFuenteRecurso_SelectedIndexChanged(sender, e);
            }
            else if (cModulo.Equals("DEPOSITOS"))
            {
                chcTodoTipo.Text = "Tipo:";
                cboTipoCredito.Enabled = true;
                cboTipoCredito.CargarProducto(Convert.ToInt32(cboModulo.SelectedValue));
                cboSubTipoCredito.Enabled = true;
                cboProducto.Enabled = true;
                cboSubProducto.Enabled = true;
                if (chcTodoTipo.Checked)
                {
                    chcTodoTipo.Enabled = true;
                    chcTodoTipoCreAho_CheckedChanged(sender, e);
                }
                if (chcSubTipo.Checked)
                {
                    chcSubTipo.Enabled = true;
                    chcSubTipoCreAho_CheckedChanged(sender, e);
                }
                if (chcTodoProducto.Checked)
                {
                    chcTodoProducto.Enabled = true;
                    chcTodoProducto_CheckedChanged(sender, e);
                }

                cboCondicionContable1.Enabled = true;
                cboCondicionContable1.ListarCondicionContablexProducto(Convert.ToInt32(cboModulo.SelectedValue));
                cboTipoOperacion.Enabled = true;
                cboTipoOperacion.LisTiposOperacProducto(Convert.ToInt32(cboModulo.SelectedValue));
                chcTodoTipo.Enabled = true;//-->

                cboMontos.CargarMontos(2);
                cboPlazos.CargarPLazos(2);

                //AplicarCuota
                cboAplicaCuota.SelectedIndex = -1;
                cboAplicaCuota.Enabled = false;

                //No cargar FuenteRecursos-TipoDuda-TipoEntidad-Entidad
                cboFuenteRecurso.Enabled = false;
                cboTipoDeuda.Enabled = false;
                cboTipoEntidad.Enabled = false;
                cboEntidad.Enabled = false;
            }
            else
            {
                if (cModulo.Equals("CAJA"))
                {
                    cboMontos.CargarMontos(3);
                    cboPlazos.CargarPLazos(3);
                }

                if (cModulo.Equals("SERVICIOS"))
                {
                    cboMontos.CargarMontos(9);
                    cboPlazos.CargarPLazos(9);
                }
                
                //Deshabilitar los checks
                chcTodoTipo.Enabled         =   false;
                chcSubTipo.Enabled          =   false;
                chcTodoProducto.Enabled     =   false;
                chcTodoSubProducto.Enabled  =   false;

                //Descheckear
                chcTodoTipo.Checked         = false;
                chcSubTipo.Checked          = false;
                chcTodoProducto.Checked     = false;
                chcTodoSubProducto.Checked  = false;
                
                
                //Deshabilitar los combos de productos
                cboTipoCredito.Enabled      = false;
                cboSubTipoCredito.Enabled   = false;
                cboProducto.Enabled         = false;
                cboSubProducto.Enabled      = false;

                //No cargar Condición contable
                cboCondicionContable1.Enabled = false;
                cboCondicionContable1.ListarCondicionContablexProducto(-1);

                //No cargar tipo de operación
                cboTipoOperacion.Enabled = false;
                cboTipoOperacion.LisTiposOperacProducto(-1);
        
                //No cargar productos
                cboTipoCredito.CargarProducto(-1);
                cboSubTipoCredito.CargarProducto(-1);
                cboProducto.CargarProducto(-1);
                cboSubProducto.CargarProducto(-1);

                //No cargar FuenteRecursos-TipoDuda-TipoEntidad-Entidad
                cboFuenteRecurso.Enabled    =false;
                cboTipoDeuda.Enabled        =false;
                cboTipoEntidad.Enabled      =false;
                cboEntidad.Enabled          =false;

                //AplicarCuota
                cboAplicaCuota.SelectedIndex = -1;
                cboAplicaCuota.Enabled = false;
            }
        }

        private void cboTipoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoGasto.SelectedIndex != -1)
            {
                cboDetalleGasto1.listarDetalleTipoGasto(Convert.ToInt32((cboTipoGasto.SelectedItem as DataRowView).Row["idConcepto"]));
            }
            
        }
    }
}