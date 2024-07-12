using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using System.Drawing;
using System.Linq;

namespace CRE.Presentacion
{
    public partial class frmRegistroSolCapturaCre : frmBase
    {
        #region Variables

        DataTable dtCredito = new DataTable("dtCredito");
        clsCNCredito Credito = new clsCNCredito();
        bool lPermitirEditar = false;//permite editar  los campos  justificación y Tasa moratoria en caso sea una nueva solicitud
        public int nfilaseleccionada = 0;
        int idCliente = 0;
        string cEstadoSolicitud="";
        clsCNCondonacion SolicCondonacion = new clsCNCondonacion();

        #endregion

        public frmRegistroSolCapturaCre()
        {
            InitializeComponent();
            //Grupo txtJustificacion
            txtJustificacion.Enabled = false;
        }

        #region Eventos

        private void frmRegistroSolCapturaCre_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            conBusCli.txtCodCli.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            conBusCli.limpiarControles();
            if (txtJustificacion.DataBindings.Count != 0)
            {
                txtJustificacion.DataBindings.Remove(txtJustificacion.DataBindings["Text"]);
            }
            lPermitirEditar = false;
            btnGrabar.Enabled = false;
            txtJustificacion.Text = "";
            conBusCli.Enabled = true;
            conBusCli.txtCodCli.Enabled = true;
            conBusCli.txtCodCli.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //Valida existencia de cliente seleccionado
            if (conBusCli.idCli == 0)
            {
                btnGrabar.Enabled = false;
                return;
            }

            //VALIDA QUE SE HAYA SELECCIONADO CUENTAS DE CLIENTE PARA CAPTURA
            //Calcular el numero de cuentas que tienen el check de aplica seleccionado
            int nNumCuentasAplica = 0;
            for (int i = 0; i < dtCredito.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtCredito.Rows[i]["lAplica"]) == true)
                {
                    nNumCuentasAplica++;
                    //Valida que exita justificación para captura del crédito
                    if (string.IsNullOrEmpty(dtCredito.Rows[i]["cJustificacion"].ToString().Trim()))
                    {
                        MessageBox.Show("La cuenta Nro. " + dtCredito.Rows[i]["cNroCuenta"].ToString() + " no tiene justificación para CAPTURA DE CRÉDITO.", "Solicitud Captura Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            if (nNumCuentasAplica == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna cuenta.", "Solicitud Captura Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtCredito.AsEnumerable().Any(x => x.Field<bool>("lAplica") && x.Field<decimal>("nMonSalIntFec") < 0))
            {
                MessageBox.Show("No se pueden capturar cuentas con intereses pagados por adelantado.", "Solicitud Captura Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataSet ds = new DataSet("dsCapturaCredito");

            //Agregar la Tabla de Cuentas selecionadas de acuerdo al estado de la solicitud  
            dtCredito.TableName = "TablaCuentas";
            ds.Tables.Add(dtCredito);
            string XmlSoli = ds.GetXml();
            XmlSoli = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(XmlSoli);
            ds.Tables.Clear();

            //Inserta una nueva Solicitud de captura de Credito
            DataTable dtCapturaCre = Credito.InsSolicitudCapturaCredito(XmlSoli, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, idCliente);

            if (dtCapturaCre.Rows.Count > 0)
            {
                int nTipoOperacion = 50;//Definir el tipo de  Operación: CAPTURA A JUDICIALES
                //Inserta una nueva Solicitud de Aprobación para la 'solicitud de Captura de Crédito'
                GEN.CapaNegocio.clsCNValidaReglasDinamicas GuardaSolicitudAprobac = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();
                DataTable dtRptaSolAprobacion = GuardaSolicitudAprobac.GuardarSolicitudAprobac(clsVarGlobal.nIdAgencia, idCliente, nTipoOperacion,
                                                                    1, Convert.ToInt32(dtCredito.Rows[0]["IdMoneda"].ToString()), Convert.ToInt32(dtCredito.Rows[0]["idProducto"].ToString()),
                                                                    Decimal.Parse(txtTotalSaldoCapital.Text), Convert.ToInt32(dtCapturaCre.Rows[0][0].ToString()), clsVarGlobal.dFecSystem,
                                                                    2, "Solicitud aprobación de captura de créditos", 1,
                                                                    clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario,false);

                MessageBox.Show(dtRptaSolAprobacion.Rows[0]["cMensaje"].ToString(), "Solicitud Captura Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(idCliente, Convert.ToInt32(dtCredito.Rows[0]["idCuenta"]), "Solicitud de captura de crédito completada", btnGrabar);

            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/


            //Congelar vista
            dtgCuentas.Enabled = false;
            txtJustificacion.Enabled = false;
            btnGrabar.Enabled = false;
            conBusCli.Enabled = false;

            //dar color al grid
            dtgCuentas.ForeColor = Color.Gray;
        }

        private void dtgCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtCredito.Rows.Count > 0)
            {
                nfilaseleccionada = Convert.ToInt32(this.dtgCuentas.CurrentRow.Index);
                MostrarDetallesCredito(nfilaseleccionada);
            }
        }

        private void MostrarDetallesCredito(int nfilaseleccionada)
        {
            //LLenar información detalles de crédito
            txtSaldoCapital.Text = Convert.ToDecimal(dtCredito.Rows[nfilaseleccionada]["nMonSalCapital"]).ToString("#,0.00");
            txtSaldoInteres.Text = Convert.ToDecimal(dtCredito.Rows[nfilaseleccionada]["nMonSalIntFec"]).ToString("#,0.00");
            txtSaldoIntComp.Text = Convert.ToDecimal(dtCredito.Rows[nfilaseleccionada]["nMonSalIntComp"]).ToString("#,0.00");
            txtSaldoMora.Text = Convert.ToDecimal(dtCredito.Rows[nfilaseleccionada]["nMonSalMora"]).ToString("#,0.00");
            txtSaldoOtros.Text = Convert.ToDecimal(dtCredito.Rows[nfilaseleccionada]["nMonSalOtros"]).ToString("#,0.00");
            txtTotalDeuda.Text = (Convert.ToDecimal(txtSaldoCapital.Text) + 
                                    Convert.ToDecimal(txtSaldoInteres.Text) +
                                    Convert.ToDecimal(txtSaldoIntComp.Text) + 
                                    Convert.ToDecimal(txtSaldoMora.Text) +
                                    Convert.ToDecimal(txtSaldoOtros.Text)).ToString("#,0.00");

            txtTasaInteres.Text = Convert.ToDecimal(dtCredito.Rows[nfilaseleccionada]["nTasaCompensatoria"]).ToString("#,0.0000");
            txtTasaMoratoria.Text = Convert.ToDecimal(dtCredito.Rows[nfilaseleccionada]["nTasaMoratoria"]).ToString("#,0.0000");
            txtDiasAtraso.Text = dtCredito.Rows[nfilaseleccionada]["nAtraso"].ToString();
            txtEstadoCredito.Text = dtCredito.Rows[nfilaseleccionada]["cEstado"].ToString();

            //Dando alineamiento
            txtSaldoCapital.TextAlign = HorizontalAlignment.Right;
            txtSaldoInteres.TextAlign = HorizontalAlignment.Right;
            txtSaldoIntComp.TextAlign = HorizontalAlignment.Right;
            txtSaldoMora.TextAlign = HorizontalAlignment.Right;
            txtSaldoOtros.TextAlign = HorizontalAlignment.Right;
            txtTotalDeuda.TextAlign = HorizontalAlignment.Right;

            txtTasaInteres.TextAlign = HorizontalAlignment.Right;
            txtTasaMoratoria.TextAlign = HorizontalAlignment.Right;
            txtDiasAtraso.TextAlign = HorizontalAlignment.Right;
            txtEstadoCredito.TextAlign = HorizontalAlignment.Right;

            //Permitir Insertardo de Justificado para captura de crédito
            if (Convert.ToBoolean(dtCredito.Rows[nfilaseleccionada]["lAplica"]) == true && lPermitirEditar == true)
            {
                txtJustificacion.Enabled = true;
            }
            else
            {
                txtJustificacion.Enabled = false;
            }
        }

        private void dtgCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Obtener la columna columna actual seleccionada de la fila 
            if (dtgCuentas.CurrentCell.OwningColumn.Name.Equals("lAplica") && lPermitirEditar == true)
            {
                int nfilaseleccionada = Convert.ToInt32(this.dtgCuentas.CurrentRow.Index);
                if (Convert.ToBoolean(dtCredito.Rows[nfilaseleccionada]["lAplica"]) == false)//Va cambiar de 'No Check' a 'check'
                {
                    dtCredito.Rows[nfilaseleccionada]["lAplica"] = true;//Actualiza la fila
                    //Validar que no exista una solicitud pendiente o aprobada

                    DataTable SolicDuplicada = SolicCondonacion.DatosSolicCond(this.conBusCli.idCli, Convert.ToInt32(dtCredito.Rows[nfilaseleccionada]["idcuenta"]));
                    if (SolicDuplicada.Rows.Count > 0)
                    {
                        MessageBox.Show("Existe una solicitud vigente de condonación Enviada por:\n \n \tUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                                        "\n \tAgencia:   " + SolicDuplicada.Rows[0]["cNombreAge"] + "\n \tFecha:   " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        dtCredito.Rows[nfilaseleccionada]["lAplica"] = false;
                        btnCancelar.Enabled = true;
                        return;
                    }
                    dtgCuentas.Rows[nfilaseleccionada].Cells["lAplica"].Value = true;//Actualiza el gridView
                    MostrarDetallesCredito(nfilaseleccionada);
                }
                else
                {
                    dtCredito.Rows[nfilaseleccionada]["lAplica"] = false;
                    dtgCuentas.Rows[nfilaseleccionada].Cells["lAplica"].Value = false;//Actualiza el gridView
                    MostrarDetallesCredito(nfilaseleccionada);
                }
            }
            CalcularTotalSaldoCapital();
        }

        private void dtgCuentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)//Tecla Flecha Abajo
            {
                nfilaseleccionada = Convert.ToInt32(this.dtgCuentas.CurrentRow.Index);

                if (nfilaseleccionada < dtgCuentas.Rows.Count)
                {
                    nfilaseleccionada = nfilaseleccionada + 1;
                    if (nfilaseleccionada < dtgCuentas.Rows.Count)
                    {
                        MostrarDetallesCredito(nfilaseleccionada);
                        return;
                    }
                }
            }
            if (e.KeyCode == Keys.Up)//Tecla Flecha Arriba
            {
                nfilaseleccionada = Convert.ToInt32(this.dtgCuentas.CurrentRow.Index);

                if (nfilaseleccionada != 0)
                {
                    nfilaseleccionada = nfilaseleccionada - 1;
                    MostrarDetallesCredito(nfilaseleccionada);
                    return;
                }
                else
                {
                    MostrarDetallesCredito(nfilaseleccionada);
                    return;
                }
            }
        }
        
        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli.idCli == 0)
            {
                return;
            }
            idCliente = conBusCli.idCli;

            LimpiarDatos();
            lPermitirEditar = false;

            BuscarCreditosCliente();
        }

        #endregion

        #region Metodos

        private void DarFormatoGridCuentas()
        {
            foreach (DataGridViewColumn column in dtgCuentas.Columns)
            {
                column.Visible = false;
            }

            dtgCuentas.Columns["lAplica"].Visible = true;
            dtgCuentas.Columns["cNroCuenta"].Visible = true;
            dtgCuentas.Columns["cMoneda"].Visible = true;
            dtgCuentas.Columns["cProducto"].Visible = true;
            dtgCuentas.Columns["nCuotas"].Visible = true;

            dtgCuentas.Columns["lAplica"].HeaderText = "Aplicar";
            dtgCuentas.Columns["cNroCuenta"].HeaderText = "Número de Cuenta";
            dtgCuentas.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCuentas.Columns["cProducto"].HeaderText = "Producto";
            dtgCuentas.Columns["nCuotas"].HeaderText = "Cuotas";

            dtgCuentas.Columns["lAplica"].Width = 45;
            dtgCuentas.Columns["cNroCuenta"].Width = 125;
            dtgCuentas.Columns["nCuotas"].Width = 45;

            dtgCuentas.Columns["lAplica"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgCuentas.Columns["cNroCuenta"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgCuentas.Columns["cMoneda"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgCuentas.Columns["cProducto"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgCuentas.Columns["nCuotas"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void LimpiarDatos()
        {
            //Datos del cliente
            //conBusCli1.limpiarControles();

            //justificacion
            txtJustificacion.Enabled = false;

            //Grupo Detalles Credito
            txtSaldoCapital.Text = "";
            txtSaldoInteres.Text = "";
            txtSaldoIntComp.Text = "";
            txtSaldoMora.Text = "";
            txtSaldoOtros.Text = "";
            txtTotalDeuda.Text = "";

            //Grupo Otros
            txtTasaInteres.Text = "";
            txtTasaMoratoria.Text = "";
            txtDiasAtraso.Text = "";
            txtEstadoCredito.Text = "";

            txtTotalSaldoCapital.Text = "";

            //Grid de cuentas del cliente
            dtgCuentas.DataSource = null;
            dtgCuentas.Enabled = true;
            dtgCuentas.ForeColor = Color.Black;

            if (txtJustificacion.DataBindings.Count != 0)
            {
                txtJustificacion.DataBindings.Remove(txtJustificacion.DataBindings["Text"]);
            }
        }

        private void CalcularTotalSaldoCapital()
        {
            Decimal nTotalSaldoCapital = 0;
            for (int i = 0; i < dtCredito.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtCredito.Rows[i]["lAplica"]))
                {
                    nTotalSaldoCapital = nTotalSaldoCapital + Convert.ToDecimal(dtCredito.Rows[i]["nMonSalCapital"]);
                }
            }
            txtTotalSaldoCapital.Text = nTotalSaldoCapital.ToString("#,0.00");
            txtTotalSaldoCapital.TextAlign = HorizontalAlignment.Right;
        }

        private void BuscarCreditosCliente()
        {
            dtCredito = Credito.BuscarCreditosCliente(idCliente);//Lista todos los créditos(cuentas) y si ya fueron solicitados para captura 
            if (dtCredito.Rows.Count == 0)
            {
                MessageBox.Show("El cliente no tiene CUENTAS ACTIVAS para solicitar CAPTURA A JUDICIALES", "Solicitud Captura Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnGrabar.Enabled = false;
                conBusCli.Enabled = true;
                conBusCli.txtCodCli.Enabled = true;
                conBusCli.txtCodCli.Focus();
                return;
            }

            //Identificar Filas que tengan con check el lAplica 
            Boolean lTieneCuentas = false;
            for (int i = 0; i < dtCredito.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtCredito.Rows[i]["lAplica"]))
                {
                    lTieneCuentas = true;
                    cEstadoSolicitud = dtCredito.Rows[i]["cEstadoSol"].ToString().ToUpper();
                    break;
                }
            }

            if (lTieneCuentas)//si tiene cuentas registradas para captura ('SOLICITUD CAPTURA DE CRÉDITO'), consultar en que estado está la 'SOLICITUD DE APROBACIÓN'
            {
                if (string.IsNullOrEmpty(cEstadoSolicitud))//No hay cuentas seleccionadas que se hayan incluido en la solicitud de captura
                {
                    //Dar permiso a la tabla de para poder asignar valores
                    foreach (DataColumn dcColumna in dtCredito.Columns)
                    {
                        dcColumna.ReadOnly = dcColumna.ColumnName.Equals("lAplica") ||
                                             dcColumna.ColumnName.Equals("cJustificacion")? false: true;
                    }

                    this.dtgCuentas.DataSource = dtCredito;
                    DarFormatoGridCuentas();
                    //Asignando DataBinding
                    txtJustificacion.DataBindings.Add("Text", dtCredito, "cJustificacion");
                    lPermitirEditar = true;
                }

                if (cEstadoSolicitud.Equals("SOLICITADO"))
                {
                    this.dtgCuentas.DataSource = dtCredito;
                    DarFormatoGridCuentas();
                    //Asignando DataBinding
                    txtJustificacion.DataBindings.Add("Text", dtCredito, "cJustificacion");
                    MessageBox.Show("La solicitud captura de crédito se encuentra a la espera de APROBACIÓN", "Solicitud Captura Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lPermitirEditar = false;
                }

                if (cEstadoSolicitud.Equals("APROBADO"))
                {
                    this.dtgCuentas.DataSource = dtCredito;
                    DarFormatoGridCuentas();
                    //Asignando DataBinding
                    txtJustificacion.DataBindings.Add("Text", dtCredito, "cJustificacion");
                    MessageBox.Show("Se ha APROBADO la solicitud de captura de crédito, pero aún no se ha capturado las cuentas", "Solicitud Captura Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lPermitirEditar = false;
                }
                nfilaseleccionada = 0;
                MostrarDetallesCredito(nfilaseleccionada);
                CalcularTotalSaldoCapital();
                dtgCuentas.Focus();
            }
            else//Tiene cuentas, pero ninguna se seleccionó para captura
            {
                //Dar permiso a la tabla de para poder asignar valores
                foreach (DataColumn dcColumna in dtCredito.Columns)
                {
                    if (dcColumna.ColumnName.Equals("lAplica") || dcColumna.ColumnName.Equals("cJustificacion"))
                    {
                        dcColumna.ReadOnly = false;
                    }
                    else
                    {
                        dcColumna.ReadOnly = true;
                    }
                }
                this.dtgCuentas.DataSource = dtCredito;
                DarFormatoGridCuentas();
                //Asignando DataBinding
                txtJustificacion.DataBindings.Add("Text", dtCredito, "cJustificacion");

                lPermitirEditar = true;
                btnGrabar.Enabled = true;
                nfilaseleccionada = 0;
                MostrarDetallesCredito(nfilaseleccionada);
                CalcularTotalSaldoCapital();
                dtgCuentas.Focus();
            }
        }

        #endregion

    }
}
