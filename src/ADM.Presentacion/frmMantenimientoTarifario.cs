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
using GEN.CapaNegocio;
using RPT.Presentacion;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoTarifario : frmBase
    {
        public DataTable tbTarifas;
        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar

        private Boolean lProducto = false;

        DataTable dtTarifas = new DataTable("dtTarifas");
        DataTable dtTarifasDup = new DataTable("dtTarifasDup");

        public frmMantenimientoTarifario()
        {
            InitializeComponent();

            int nFormaCalculoTasa = clsVarApl.dicVarGen["nFormaCalculoTasa"];
            if (nFormaCalculoTasa == 1)
            {
                //Cálculo de la tasa diaria a partir de la TEA
                lblTasa.Text = "Tasa Efectiva Anual:";
                lblTasaMax.Text = "Tasa Efec. Anual Máxima:";
            }

            if (nFormaCalculoTasa == 2)
            {
                //Cálculo de la tasa diaria a partir de la TEM
                lblTasa.Text = "Tasa Efectiva Mensual:";
                lblTasaMax.Text = "Tasa Efec. Men. Máxima:";
            }

        }

        private void frmMantenimientoTarifario_Load(object sender, EventArgs e)
        {

            cboAgenciaView.AgenciasYTodos();
            cboMonedaView.MonedasYTodos();
            cboTipoPersonaView.TipospersonaYTodos();
            CargarTarifas("P", 0);
            cboModulo.CargarProducto(0);
            LimpiarControles();
            HabilitarControles(false);

            RBFilAgencia.Checked = true;
            CBAplicar.Enabled = false;
            chcVigente.Enabled = false;
            chcNegociable.Enabled = false;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            pcTipOpe = "A";
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;

            this.btnProcesar.Enabled = false;

            this.txtTasaCom.Enabled = true;

            if (Convert.ToInt32(cboModulo.SelectedValue) == 1)
            {
                this.txtTasaMor.Enabled = true;
                this.txtTasaCompMax.Enabled = true;
            }

            this.CBAplicar.Enabled = lProducto;
            chcVigente.Enabled = true;
            chcNegociable.Enabled = true;
            int filaseleccionada = Convert.ToInt32(this.dtgTarifas.CurrentRow.Index);
            dtgTarifas.Rows[filaseleccionada].Cells["lVigente"].Value = true;

            dtgTarifas.ReadOnly = false;
            dtgTarifas.Columns["lAplicar"].ReadOnly = false;
            dtgTarifas.Columns["idTasa"].ReadOnly = true;
            dtgTarifas.Columns["cProducto"].ReadOnly = true;
            dtgTarifas.Columns["nMontoMinimo"].ReadOnly = true;
            dtgTarifas.Columns["nMontoMaximo"].ReadOnly = true;
            dtgTarifas.Columns["cMoneda"].ReadOnly = true;
            dtgTarifas.Columns["cNombreAge"].ReadOnly = true;
            this.btnCancelar.Enabled = true;

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lProducto = false;
            dtTarifas.Rows.Clear();
            pcTipOpe = "N";
            tbTarifas.Rows.Clear();
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnProcesar.Enabled = false;
            LimpiarControles();
            HabilitarControles(true);
            RBFilAgencia.Checked = false;
            RBFilProducto.Checked = false;
            this.CBAplicar.Enabled = false;
            chcVigente.Checked = true;
            this.chcVigente.Enabled = false;
            this.chcNegociable.Enabled = true;
            this.chcNegociable.Checked = false;
            this.establecerVisibilidadDiasExecPenalidad();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
                LimpiarControles();
                HabilitarControles(false);
                tbTarifas.Rows.Clear();

            this.RBFilAgencia.Checked = false;
            this.RBFilProducto.Checked = false;
            this.CBAplicar.Enabled = false;
            this.chcVigente.Enabled = false;
            this.chcNegociable.Enabled = false;

                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnNuevo.Enabled = true;
            this.btnProcesar.Enabled = true;

            dtgTarifas.ReadOnly = true;
            pcTipOpe = "N";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }
            Decimal TasaMor = 0;
            if (txtTasaMor.Text != "")
                TasaMor = Convert.ToDecimal(txtTasaMor.Text);
            Decimal TasaCom = Convert.ToDecimal(txtTasaCom.Text);
            Decimal TasaComMax = 0;
            if (txtTasaCompMax.Text != "")
                TasaComMax = Convert.ToDecimal(txtTasaCompMax.Text);

            clsCNTarifario GuardaTarifas = new clsCNTarifario();

            #region Actualiza Tarifas

            if (pcTipOpe == "A")
            {

                int nNumFilas = dtgTarifas.Rows.Count;
                Boolean Apl = false;
                for (int i = 0; i < nNumFilas; i++)
                {
                    if (Convert.ToBoolean(dtgTarifas.Rows[i].Cells["lAplicar"].Value) == true)
                    {
                        Apl = true;
                    }
                }


                if (Apl == true)
                {

                    DataTable tbTarifasAux = tbTarifas;
                    for (int i = 0; i < nNumFilas; i++)
                    {
                        if (Convert.ToBoolean(dtgTarifas.Rows[i].Cells["lAplicar"].Value) == true)
                        {
                            tbTarifasAux.Rows[i]["nTasaCompensatoria"] = TasaCom;
                            tbTarifasAux.Rows[i]["lVigente"] = chcVigente.Checked;
                            tbTarifasAux.Rows[i]["lNegociable"] = chcVigente.Checked;
                            if (Convert.ToInt32(dtgTarifas.Rows[i].Cells["idModulo"].Value) == 1)
                            {
                                tbTarifasAux.Rows[i]["nTasaCompensatoriaMax"] = TasaComMax;
                                tbTarifasAux.Rows[i]["nTasaMoratoria"] = TasaMor;
                            }

                        }
                    }

                        DataSet ds = new DataSet("dsActTasas");
                    ds.Tables.Add(tbTarifasAux);
                        string XMLActTarif = ds.GetXml();
                    ds.Tables.Clear();
                    XMLActTarif = clsCNFormatoXML.EncodingXML(XMLActTarif);

                    DataTable dtResult = GuardaTarifas.ActualizarTar(XMLActTarif);

                    if (Convert.ToInt32(dtResult.Rows[0]["nResultado"]) != 0)
                    {
                        MessageBox.Show(Convert.ToString(dtResult.Rows[0]["cMensaje"]) +": "+ dtResult.Rows[0]["Total"] + " Registros", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        MessageBox.Show(Convert.ToString(dtResult.Rows[0]["cMensaje"]), "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Buscar();
                    btnGrabar.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnCancelar.Enabled = true;
                }

                if (Apl == false)
                {
                    MessageBox.Show("No Está seleccionada ninguna Tasa para poder ser Modificada", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            #endregion

            else if (pcTipOpe == "N" && (Convert.ToInt32(cboAgenciaView.SelectedValue.ToString().Trim()) == 0 || Convert.ToInt32(cboMonedaView.SelectedValue.ToString().Trim()) == 0 || Convert.ToInt32(cboTipoPersonaView.SelectedValue.ToString().Trim()) == 0 || Convert.ToInt32(cboMontosView.SelectedValue.ToString().Trim()) == 0 || Convert.ToInt32(cboPlazosView.SelectedValue.ToString().Trim()) == 0))
            {
                bool bContinuarCreando = false;
                int idAgencia = Convert.ToInt32(cboAgenciaView.SelectedValue.ToString().Trim());
                int idMoneda = Convert.ToInt32(cboMonedaView.SelectedValue.ToString().Trim());
                int idTipoPersona = Convert.ToInt32(cboTipoPersonaView.SelectedValue.ToString().Trim());
                int idProducto = Convert.ToInt32(cboSubProducto.SelectedValue.ToString().Trim());
                int idMonto = Convert.ToInt32(cboMontosView.SelectedValue.ToString().Trim());
                int idPlazo = Convert.ToInt32(cboPlazosView.SelectedValue.ToString().Trim());
                int idTipoTasaCredito = Convert.ToInt32(cboTipoTasaCredito.SelectedValue.ToString().Trim());
                bool lNegociable = chcNegociable.Checked;
                int idClasificacionInterna = (this.cboClasificacionInterna1.SelectedIndex != -1) ? Convert.ToInt32(cboClasificacionInterna1.SelectedValue.ToString().Trim()) : 0;

                DataTable dtAgencia =(DataTable)cboAgenciaView.DataSource;
                DataTable dtMoneda = (DataTable)cboMonedaView.DataSource;
                DataTable dtTipoPersona = (DataTable)cboTipoPersonaView.DataSource;
                DataTable dtMonto = (DataTable)cboMontosView.DataSource;
                DataTable dtPlazo = (DataTable)cboPlazosView.DataSource;

                cargarEstructuraTarifaDup();
                dtTarifasDup.Rows.Clear();
                for (int i = ((idAgencia == 0) ? 0 : cboAgenciaView.SelectedIndex); i <= ((idAgencia == 0) ? (dtAgencia.Rows.Count - 2) : cboAgenciaView.SelectedIndex); i++)
                {
                    for (int j = ((idMoneda == 0) ? 0 : cboMonedaView.SelectedIndex); j <= ((idMoneda == 0) ? (dtMoneda.Rows.Count - 2) : cboMonedaView.SelectedIndex); j++)
			        {
                        for (int k = ((idTipoPersona == 0) ? 0 : cboTipoPersonaView.SelectedIndex); k <= ((idTipoPersona == 0) ? (dtTipoPersona.Rows.Count - 2) : cboTipoPersonaView.SelectedIndex); k++)
			            {
                            for (int l = ((idMonto == 0) ? 0 : cboMontosView.SelectedIndex); l <= ((idMonto == 0) ? (dtMonto.Rows.Count - 2) : cboMontosView.SelectedIndex); l++)
                            {
                                for (int m = ((idPlazo == 0) ? 0 : cboPlazosView.SelectedIndex); m <= ((idPlazo == 0) ? (dtPlazo.Rows.Count - 2) : cboPlazosView.SelectedIndex); m++)
                                {
                                    DataRow drTarifay = null;
                                    drTarifay = dtTarifasDup.NewRow();
                                    drTarifay["idPlazo"] = Convert.ToInt32(dtPlazo.Rows[m][0]);
                                    drTarifay["idProducto"] = idProducto;
                                    drTarifay["idMonto"] = Convert.ToInt32(dtMonto.Rows[l][0]);
                                    drTarifay["idMoneda"] = Convert.ToInt32(dtMoneda.Rows[j][0]);
                                    drTarifay["idAgencia"] = Convert.ToInt32(dtAgencia.Rows[i][0]);
                                    drTarifay["idTipoPersona"] = Convert.ToInt32(dtTipoPersona.Rows[k][0]);
                                    drTarifay["idTipoTasa"] = idTipoTasaCredito;
                                    drTarifay["lNegociable"] = lNegociable;
                                    drTarifay["idClasificacionInterna"] = idClasificacionInterna;
                                    
                                    if (txtDiasExcPenalidad.Text != "")
                                        drTarifay["nDiasExecPenalidad"] = Convert.ToInt32(txtDiasExcPenalidad.Text);

                                    dtTarifasDup.Rows.Add(drTarifay);
                            }
			            }
			        }
                }
                }

                DataSet dsTarifasDup = new DataSet("dsTarifasDup");
                dsTarifasDup.Tables.Add(dtTarifasDup);
                string xmlTarifasDup = dsTarifasDup.GetXml();
                xmlTarifasDup = clsCNFormatoXML.EncodingXML(xmlTarifasDup);
                dsTarifasDup.Tables.Clear();
                DataTable duplicados = GuardaTarifas.RetornaTarifasDupX(xmlTarifasDup);
                string dup = String.Empty;
                if (duplicados.Rows.Count > 0)
                {
                    foreach (DataRow row in duplicados.Rows)
                    {
                        dup += "-> " + Convert.ToString(row["agencia"]) + "," +
                                        Convert.ToString(row["moneda"]) + "," +
                                         Convert.ToString(row["tipoPersona"]) + "," +
                                         Convert.ToString(row["monto"]) + "," +
                                         Convert.ToString(row["plazo"]) + "\n";
                    }

                    DialogResult drResultado = MessageBox.Show("Se Encontraró(aron) " + duplicados.Rows.Count + " Duplicado(s) : \n" + dup +" \n Desea continuar?", "Mantenimiento de Tarifario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        bContinuarCreando = true;
                    }
                    else
                    {
                        LimpiarControles();
                        HabilitarControles(true);
                        return;
                    }
                }
                else
                {
                    bContinuarCreando = true;
                }
                if (bContinuarCreando)
                {
                    cargarEstructuradtTarifa();
                    int iTotalCreados = 0;
                    dtTarifas.Rows.Clear();
                    for (int i = ((idAgencia == 0) ? 0 : cboAgenciaView.SelectedIndex); i <= ((idAgencia == 0) ? (dtAgencia.Rows.Count - 2) : cboAgenciaView.SelectedIndex); i++)
                    {
                        for (int j = ((idMoneda == 0) ? 0 : cboMonedaView.SelectedIndex); j <= ((idMoneda == 0) ? (dtMoneda.Rows.Count - 2) : cboMonedaView.SelectedIndex); j++)
                        {
                            for (int k = ((idTipoPersona == 0) ? 0 : cboTipoPersonaView.SelectedIndex); k <= ((idTipoPersona == 0) ? (dtTipoPersona.Rows.Count - 2) : cboTipoPersonaView.SelectedIndex); k++)
                            {
                                for (int l = ((idMonto == 0) ? 0 : cboMontosView.SelectedIndex); l <= ((idMonto == 0) ? (dtMonto.Rows.Count - 2) : cboMontosView.SelectedIndex); l++)
                                {
                                    for (int m = ((idPlazo == 0) ? 0 : cboPlazosView.SelectedIndex); m <= ((idPlazo == 0) ? (dtPlazo.Rows.Count - 2) : cboPlazosView.SelectedIndex); m++)
                                    {
                                        DataRow drTarifax = null;
                                        drTarifax = dtTarifas.NewRow();
                                        drTarifax["idPlazo"] = Convert.ToInt32(dtPlazo.Rows[m][0]);
                                        drTarifax["idProducto"] = idProducto;
                                        drTarifax["idMonto"] = Convert.ToInt32(dtMonto.Rows[l][0]);
                                        drTarifax["idMoneda"] = Convert.ToInt32(dtMoneda.Rows[j][0]);
                                        drTarifax["nTasaCompensatoria"] = TasaCom;
                                        drTarifax["nTasaCompensatoriaMax"] = TasaComMax;
                                        drTarifax["nTasaMoratoria"] = TasaMor;
                                        drTarifax["idAgencia"] = Convert.ToInt32(dtAgencia.Rows[i][0]);
                                        drTarifax["idTipoPersona"] = Convert.ToInt32(dtTipoPersona.Rows[k][0]);
                                        drTarifax["idTipoTasa"] = idTipoTasaCredito;
                                        drTarifax["lNegociable"] = lNegociable;
                                        drTarifax["idClasificacionInterna"] = idClasificacionInterna;
                                        
                                        if (txtDiasExcPenalidad.Text != "")
                                            drTarifax["nDiasExecPenalidad"] = Convert.ToInt32(txtDiasExcPenalidad.Text);

                                        dtTarifas.Rows.Add(drTarifax);
                                iTotalCreados++;
                            }
                        }
                    }
                        }
                    }

                    DataSet dsTarifas = new DataSet("dsTarifas");
                    dsTarifas.Tables.Add(dtTarifas);
                    string xmlTarifas = dsTarifas.GetXml();
                    dsTarifas.Tables.Clear();
                    xmlTarifas = clsCNFormatoXML.EncodingXML(xmlTarifas);
                    DataTable dtRpta = GuardaTarifas.GuardarTarifasX(xmlTarifas);

                    if (Convert.ToInt16(dtRpta.Rows[0]["idRpta"].ToString()) == 0)
                    {
                        MessageBox.Show("Se ha(n) Registrado " + iTotalCreados + " Dato(s) Correctamente", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR al insertar vuelva a intentarlo porfavor!\n" + Convert.ToString(dtRpta.Rows[0]["cMensage"]), "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Buscar(Convert.ToInt32(cboSubProducto.SelectedValue));
                    RBFilProducto.Checked = true;
                    this.btnNuevo.Enabled = true;
                    this.btnEditar.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.CBAplicar.Enabled = false;
                    this.chcVigente.Enabled = false;
                    this.chcNegociable.Enabled = false;
                    dtgTarifas.ReadOnly = true;

                }
            }

            else if (pcTipOpe == "N")
            {
                cargarEstructuraTarifaDup();
                dtTarifasDup.Rows.Clear();
                String idProducto = cboSubProducto.SelectedValue.ToString().Trim();
                String idAgencia = cboAgenciaView.SelectedValue.ToString().Trim();
                String idMoneda = cboMonedaView.SelectedValue.ToString().Trim();
                String idTipPersona = cboTipoPersonaView.SelectedValue.ToString().Trim();
                String idMonto = cboMontosView.SelectedValue.ToString().Trim();
                String idPlazo = cboPlazosView.SelectedValue.ToString().Trim();
                String idTipoTasaCredito = cboTipoTasaCredito.SelectedValue.ToString().Trim();
                bool lNegociable = chcNegociable.Checked;

                DataRow drTarifay = null;
                drTarifay = dtTarifasDup.NewRow();
                drTarifay["idPlazo"] = idPlazo;
                drTarifay["idProducto"] = idProducto;
                drTarifay["idMonto"] = idMonto;
                drTarifay["idMoneda"] = idMoneda;
                drTarifay["idAgencia"] = idAgencia;
                drTarifay["idTipoPersona"] = idTipPersona;
                drTarifay["idTipoTasa"] = idTipoTasaCredito;
                drTarifay["lNegociable"] = lNegociable;
                drTarifay["idClasificacionInterna"] = (this.cboClasificacionInterna1.SelectedIndex != -1) ? Convert.ToInt32(cboClasificacionInterna1.SelectedValue.ToString().Trim()) : 0;
                
                if (txtDiasExcPenalidad.Text != "")
                    drTarifay["nDiasExecPenalidad"] = Convert.ToInt32(txtDiasExcPenalidad.Text);

                dtTarifasDup.Rows.Add(drTarifay);

                DataSet dsTarifasDup = new DataSet("dsTarifasDup");
                dsTarifasDup.Tables.Add(dtTarifasDup);
                string xmlTarifasDup = dsTarifasDup.GetXml();
                dsTarifasDup.Tables.Clear();
                xmlTarifasDup = clsCNFormatoXML.EncodingXML(xmlTarifasDup);
                DataTable duplicados = GuardaTarifas.RetornaTarifasDupX(xmlTarifasDup);
                string dup = String.Empty;
                if (duplicados.Rows.Count > 0)
                {

                    foreach (DataRow row in duplicados.Rows)
                    {
                        dup += "-> " + Convert.ToString(row["agencia"]) + "," +
                                        Convert.ToString(row["moneda"]) + "," +
                                         Convert.ToString(row["tipoPersona"]) + "," +
                                         Convert.ToString(row["monto"]) + "," +
                                         Convert.ToString(row["plazo"]) + "\n";
                    }

                    DialogResult drResultado = MessageBox.Show("Se Encontraró(aron) " + duplicados.Rows.Count + " Duplicado(s) : \n" + dup + "\n Desea Continuar?", "Mantenimiento de Tarifario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.btnNuevo.Enabled = true;
                        this.btnEditar.Enabled = true;
                        this.btnGrabar.Enabled = false;
                        this.btnCancelar.Enabled = true;
                        this.CBAplicar.Enabled = false;
                        this.chcVigente.Enabled = false;
                        this.chcNegociable.Enabled = false;

                        registrarTarifariosDT();
                    }
                    else
                    {
                        HabilitarControles(true);
                        return;
                        }
                    }
                else {
                    registrarTarifariosDT();
                }
            }
        }

        private void registrarTarifariosDT()
        {
            cargarEstructuradtTarifa();
            dtTarifas.Rows.Clear();
            Decimal TasaMor = 0;
            if (txtTasaMor.Text != "")
                TasaMor = Convert.ToDecimal(txtTasaMor.Text);
            Decimal TasaCom = Convert.ToDecimal(txtTasaCom.Text);
            Decimal TasaComMax = 0;
            if (txtTasaCompMax.Text != "")
                TasaComMax = Convert.ToDecimal(txtTasaCompMax.Text);

            clsCNTarifario GuardaTarifas = new clsCNTarifario();
            DataRow drTarifax = null;
            drTarifax = dtTarifas.NewRow();
            drTarifax["idPlazo"] = cboPlazosView.SelectedValue.ToString().Trim();
            drTarifax["idProducto"] = cboSubProducto.SelectedValue.ToString().Trim();
            drTarifax["idMonto"] = cboMontosView.SelectedValue.ToString().Trim();
            drTarifax["idMoneda"] = cboMonedaView.SelectedValue.ToString().Trim();
            drTarifax["nTasaCompensatoria"] = TasaCom;
            drTarifax["nTasaCompensatoriaMax"] = TasaComMax;
            drTarifax["nTasaMoratoria"] = TasaMor;
            drTarifax["idAgencia"] = cboAgenciaView.SelectedValue.ToString().Trim();
            drTarifax["idTipoPersona"] = cboTipoPersonaView.SelectedValue.ToString().Trim();
            drTarifax["idTipoTasa"] = cboTipoTasaCredito.SelectedValue.ToString().Trim();
            drTarifax["lNegociable"] = chcNegociable.Checked;
            drTarifax["idClasificacionInterna"] = (this.cboClasificacionInterna1.SelectedIndex != -1) ? Convert.ToInt32(cboClasificacionInterna1.SelectedValue.ToString().Trim()) : 0;
            
            if (txtDiasExcPenalidad.Text != "")
                drTarifax["nDiasExecPenalidad"] = Convert.ToInt32(txtDiasExcPenalidad.Text);

            dtTarifas.Rows.Add(drTarifax);
            int iTotalCreados = 1;
            DataSet dsTarifas = new DataSet("dsTarifas");
            dsTarifas.Tables.Add(dtTarifas);
            string xmlTarifas = dsTarifas.GetXml();
            dsTarifas.Tables.Clear();
            xmlTarifas = clsCNFormatoXML.EncodingXML(xmlTarifas);
            DataTable dtRpta = GuardaTarifas.GuardarTarifasX(xmlTarifas);

            if (Convert.ToInt16(dtRpta.Rows[0]["idRpta"].ToString()) == 0)
                        {
                MessageBox.Show("Se ha(n) Registrado " + iTotalCreados + " Dato(s) Correctamente", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
            else
            {
                MessageBox.Show("ERROR al insertar vuelva a intentarlo porfavor!\n" + Convert.ToString(dtRpta.Rows[0]["cMensage"]), "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int codProd = Convert.ToInt32(cboSubProducto.SelectedValue);
            Buscar(codProd);
                    dtgTarifas.ReadOnly = true;

                }

        private void cargarEstructuradtTarifa()
        {
            dtTarifas.Columns.Clear();
            dtTarifas.Columns.Add("idPlazo", typeof(int));
            dtTarifas.Columns.Add("idProducto", typeof(int));
            dtTarifas.Columns.Add("idMonto", typeof(int));
            dtTarifas.Columns.Add("idMoneda", typeof(int));
            dtTarifas.Columns.Add("nTasaCompensatoria", typeof(decimal));
            dtTarifas.Columns.Add("nTasaCompensatoriaMax", typeof(decimal));
            dtTarifas.Columns.Add("nTasaMoratoria", typeof(decimal));
            dtTarifas.Columns.Add("idAgencia", typeof(int));
            dtTarifas.Columns.Add("idTipoPersona", typeof(int));
            dtTarifas.Columns.Add("idTipoTasa", typeof(int));
            dtTarifas.Columns.Add("lNegociable", typeof(bool));
            dtTarifas.Columns.Add("idClasificacionInterna", typeof(int));
            dtTarifas.Columns.Add("nDiasExecPenalidad", typeof(int));
        }

        private void cargarEstructuraTarifaDup()
        {
            dtTarifasDup.Columns.Clear();
            dtTarifasDup.Columns.Add("idPlazo", typeof(int));
            dtTarifasDup.Columns.Add("idProducto", typeof(int));
            dtTarifasDup.Columns.Add("idMonto", typeof(int));
            dtTarifasDup.Columns.Add("idMoneda", typeof(int));
            dtTarifasDup.Columns.Add("idAgencia", typeof(int));
            dtTarifasDup.Columns.Add("idTipoPersona", typeof(int));
            dtTarifasDup.Columns.Add("idTipoTasa", typeof(int));
            dtTarifasDup.Columns.Add("lNegociable", typeof(bool));
            dtTarifasDup.Columns.Add("idClasificacionInterna", typeof(int));
            dtTarifasDup.Columns.Add("nDiasExecPenalidad", typeof(int));
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (RBFilProducto.Checked==true)
            {
                lProducto = true;
            }

            if ((cboModulo.SelectedIndex > -1 && cboTipo.SelectedIndex > -1 && cboSubTipo.SelectedIndex > -1 && cboProducto.SelectedIndex > -1 && cboSubProducto.SelectedIndex > -1 && cboTipoTasaCredito.SelectedIndex > -1) || cboAgenciaView.SelectedIndex > -1)
            Buscar();
            else
                return;
        }

        private void dtgTarifas_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModulo.SelectedIndex > 0)
            {
                DataTable dtModulo = (DataTable)cboModulo.DataSource;
                this.cboTipoTasaCredito.cargarDatos(Convert.ToInt32(dtModulo.Rows[cboModulo.SelectedIndex]["idModulo"]));
                this.cboTipo.CargarProducto(Convert.ToInt32(cboModulo.SelectedValue));

                if (Convert.ToInt32(cboModulo.SelectedValue) == 1)
                {
                    this.cboMontosView.CargarMontosTodos(1);
                    this.cboPlazosView.CargarPLazosTodos(1);
                    this.cboMontosView.SelectedIndex = -1;
                    this.cboPlazosView.SelectedIndex = -1;
                    this.txtTasaMor.Visible = true;
                    this.lblTasaMora.Visible = true;
                    this.txtTasaCompMax.Visible = true;
                    this.lblTasaMax.Visible = true;
                }
                else
                {
                    this.txtTasaMor.Visible = false;
                    this.lblTasaMora.Visible = false;
                    this.txtTasaCompMax.Visible = false;
                    this.lblTasaMax.Visible = false;
                }
                if (Convert.ToInt32(cboModulo.SelectedValue) > 1)
                {
                    this.cboMontosView.CargarMontosTodos(2);
                    this.cboPlazosView.CargarPLazosTodos(2);
                    this.cboMontosView.SelectedIndex = -1;
                    this.cboPlazosView.SelectedIndex = -1;
                }

                if (Convert.ToInt32(cboModulo.SelectedValue) == 46)
                {
                    //this.lblTasa.Text = "Tasa Efectiva Anual:";
                }

                if (btnNuevo.Enabled == false)
                {
                    if (Convert.ToInt32(cboModulo.SelectedValue) == 1)
                    {
                        this.txtTasaMor.Enabled = true;
                        this.txtTasaCompMax.Enabled = true;
                    }
                    else if (Convert.ToInt32(cboModulo.SelectedValue) != 1)
                    {
                        this.txtTasaMor.Enabled = false;
                        this.txtTasaMor.Clear();
                        this.txtTasaCompMax.Enabled = false;
                        this.txtTasaCompMax.Clear();
                    }
                }
                this.establecerVisibilidadDiasExecPenalidad();
                this.establecerVisibilidadClasificacionInterna();
                this.establecerVisibilidadCheckSiEsNegociable();
            }
            else
            {
                this.cboTipoTasaCredito.cargarDatos(-1);
                this.cboTipo.CargarProducto(-1);
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex > 0)
            {
                this.cboSubTipo.CargarProducto((int)cboTipo.SelectedValue);

            }
            else
            {
                this.cboSubTipo.CargarProducto(-1);
            }
            this.establecerVisibilidadDiasExecPenalidad();
        }

        private void cboSubTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipo.SelectedIndex > 0)
            {
                this.cboProducto.CargarProducto((int)cboSubTipo.SelectedValue);

            }
            else
            {
                this.cboProducto.CargarProducto(-1);
            }
            this.establecerVisibilidadDiasExecPenalidad();
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                this.cboSubProducto.CargarProducto((int)cboProducto.SelectedValue);
                
            }
            else
            {
                this.cboSubProducto.CargarProducto(-1);
            }
            this.establecerVisibilidadDiasExecPenalidad();
        }

        private void RBFilProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (RBFilProducto.Checked)
            {
                this.btnProcesar.Enabled = true;
                this.btnNuevo.Enabled = true;
                HabilitarControles(false);
                cboModulo.Enabled = true;
                cboTipo.Enabled = true;
                cboSubTipo.Enabled = true;
                cboProducto.Enabled = true;
                cboSubProducto.Enabled = true;
            }
        }

        private void RBFilAgencia_CheckedChanged(object sender, EventArgs e)
        {
            if (RBFilAgencia.Checked)
            {
                this.btnProcesar.Enabled = true;
                this.btnNuevo.Enabled = true;
                HabilitarControles(false);
                cboAgenciaView.Enabled = true;
            }
        }

        private void CBAplicar_CheckedChanged(object sender, EventArgs e)
        {

            int nNumFilas = dtgTarifas.Rows.Count;
            if (nNumFilas > 0)
            {
                for (int i = 0; i < nNumFilas; i++)
                {
                    dtgTarifas.Rows[i].Cells["lAplicar"].Value = CBAplicar.Checked;
                }

            }


        }

        private void Buscar(int codigoProducto = 0)
        {
            if (RBFilProducto.Checked)
            {
                lProducto = true;
                if (!String.IsNullOrEmpty(cboSubProducto.SelectedValue.ToString()))
                {
                    int codProd = Convert.ToInt32(cboSubProducto.SelectedValue);
                CargarTarifas("P", codProd);
            }
            }
            else if (RBFilAgencia.Checked)
            {
                lProducto = false;
                int codAgen = Convert.ToInt32(cboAgenciaView.SelectedValue);
                CargarTarifas("A", codAgen);
            }
            else if (codigoProducto != 0)
            {
                lProducto = true;
                CargarTarifas("P", codigoProducto);
            }
            else {
                lProducto = false;
            if (Convert.ToInt32(this.dtgTarifas.Rows.Count) >= 1)
            {
                this.btnEditar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                lblMsj.Text = "";
            }
            if (Convert.ToInt32(this.dtgTarifas.Rows.Count) == 0)
            {
                this.btnEditar.Enabled = false;
                    if (cboModulo.Text.Trim() != "")
                    lblMsj.Text = "No se encontraron Resultados con dichos Parámetros";
            }
            }

            pcTipOpe = "N";
            dtgTarifas.ReadOnly = true;
        }

        private void CargarTarifas(String TipFiltro, int filtro)
        {
            clsCNTarifario ListaTarifario = new clsCNTarifario();
            tbTarifas = ListaTarifario.ListaTarifas(TipFiltro, filtro);
            tbTarifas.Columns.Add("lAplicar", typeof(Boolean));
            dtgTarifas.Columns.Clear();
            dtgTarifas.DataSource = tbTarifas;
            FormatoGridTar();

            int nNumFilas = tbTarifas.Rows.Count;
            if (nNumFilas > 0)
            {
                for (int i = 0; i < nNumFilas; i++)
                {
                    dtgTarifas.Rows[i].Cells["lAplicar"].Value = false;
                }
            }

        }

        private void FormatoGridTar()
        {
            foreach (DataGridViewColumn item in dtgTarifas.Columns)
            {
                item.Visible = false;
            }

            dtgTarifas.Columns["idTasa"].Visible = true;
            //dtgTarifas.Columns["idTasa"].Width = 15;
            dtgTarifas.Columns["idTasa"].HeaderText = "N°";

            dtgTarifas.Columns["cProducto"].Visible = true;
            //dtgTarifas.Columns["cProducto"].Width = 85;
            dtgTarifas.Columns["cProducto"].HeaderText = "Producto";
            dtgTarifas.Columns["cProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgTarifas.Columns["nMontoMinimo"].Visible = true;
            //dtgTarifas.Columns["nMontoMinimo"].Width = 35;
            dtgTarifas.Columns["nMontoMinimo"].HeaderText = "Monto Mínimo";
            dtgTarifas.Columns["nMontoMinimo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgTarifas.Columns["nMontoMinimo"].Visible = true;
            //dtgTarifas.Columns["nMontoMaximo"].Width = 55;
            dtgTarifas.Columns["nMontoMaximo"].HeaderText = "Monto Máximo";
            dtgTarifas.Columns["nMontoMaximo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgTarifas.Columns["cDescripcionTipoTasaCredito"].Visible = true;
            //dtgTarifas.Columns["cDescripcionTipoTasaCredito"].Width = 80;
            dtgTarifas.Columns["cDescripcionTipoTasaCredito"].HeaderText = "Tipo Tasa";

            dtgTarifas.Columns["cMoneda"].Visible = true;
            //dtgTarifas.Columns["cMoneda"].Width = 50;
            dtgTarifas.Columns["cMoneda"].HeaderText = "Moneda";
            dtgTarifas.Columns["cMoneda"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgTarifas.Columns["cNombreAge"].Visible = true;
            //dtgTarifas.Columns["cNombreAge"].Width = 110;
            dtgTarifas.Columns["cNombreAge"].HeaderText = "Agencia";

            //dtgTarifas.Columns["lAplicar"].Width = 25;
            dtgTarifas.Columns["lAplicar"].HeaderText = "Aplicar";
            dtgTarifas.Columns["lAplicar"].Visible = true;

        }

        private void LimpiarControles()
        {

            this.cboModulo.SelectedIndex = -1;
            this.cboTipo.SelectedIndex = -1;
            this.cboSubTipo.SelectedIndex = -1;
            this.cboProducto.SelectedIndex = -1;
            this.cboSubProducto.SelectedIndex = -1;
            this.cboAgenciaView.SelectedIndex = -1;
            this.cboMonedaView.SelectedIndex = -1;
            this.cboTipoPersonaView.SelectedIndex = -1;
            this.cboTipoTasaCredito.SelectedIndex = -1;
            this.cboMontosView.SelectedIndex = -1;
            this.cboPlazosView.SelectedIndex = -1;
            this.txtTasaCom.Clear();
            this.txtTasaMor.Clear();
            this.txtTasaCompMax.Clear();
            this.txtMontoNVig.Clear();
            this.txtMontoNVig.Visible = false;
            this.txtPlazoNVig.Clear();
            this.txtPlazoNVig.Visible = false;
            this.lblEstTasa.Text = "";
            this.cboClasificacionInterna1.SelectedIndex = -1;
            this.txtDiasExcPenalidad.Clear();
        }

        private void HabilitarControles(Boolean val)
        {
            this.cboModulo.Enabled = val;
            this.cboTipo.Enabled = val;
            this.cboSubTipo.Enabled = val;
            this.cboProducto.Enabled = val;
            this.cboSubProducto.Enabled = val;
            this.cboAgenciaView.Enabled = val;
            this.cboMonedaView.Enabled = val;
            this.cboTipoPersonaView.Enabled = val;
            this.cboMontosView.Enabled = val;
            this.cboPlazosView.Enabled = val;
            this.cboTipoTasaCredito.Enabled = val;
            this.txtTasaCom.Enabled = val;
            this.txtTasaCompMax.Enabled = val;
            this.txtTasaMor.Enabled = val;
            this.cboClasificacionInterna1.Enabled = val;
            this.txtDiasExcPenalidad.Enabled = val;

        }

        private string ValidarDatos()
        {
            if (cboModulo.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Tipo de Módulo ", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboModulo.Focus();
                return "ERROR";
            }
            if (cboTipo.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Tipo de Producto ", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipo.Focus();
                return "ERROR";
            }
            if (cboSubTipo.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el SubTipo de Producto ", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSubTipo.Focus();
                return "ERROR";
            }
            if (cboProducto.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Producto ", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProducto.Focus();
                return "ERROR";
            }
            if (cboSubProducto.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el SubProducto ", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSubProducto.Focus();
                return "ERROR";
            }

            DataRowView drv = ((DataRowView)cboSubProducto.SelectedItem);
            bool bClasifiProd = (drv.Row["lTasaClasifInterna"] != DBNull.Value)? Convert.ToBoolean(drv.Row["lTasaClasifInterna"]): false;

            if (bClasifiProd)
            {
                if (cboClasificacionInterna1.Text.Trim() == "")
                {
                    MessageBox.Show("Debe la Clasificación Interna ", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboSubProducto.Focus();
                    return "ERROR";
                }
            }
            if (cboAgenciaView.Text.Trim() == "" || cboAgenciaView.SelectedValue.ToString().Trim() == "-1")
            {
                MessageBox.Show("Debe Seleccionar la Agencia", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgenciaView.Focus();
                return "ERROR";
            }
            if (cboMonedaView.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Tipo de Moneda", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMonedaView.Focus();
                return "ERROR";
            }
            if (cboTipoPersonaView.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar el Tipo de Persona", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoPersonaView.Focus();
                return "ERROR";
            }
            if (pcTipOpe == "N")
            {
                if (cboMontosView.Text.Trim() == "")
                {
                    MessageBox.Show("Debe Seleccionar el Monto Mínimo y Máximo", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMontosView.Focus();
                    return "ERROR";
                }
                if (cboPlazosView.Text.Trim() == "")
                {
                    MessageBox.Show("Debe Seleccionar el Plazo ", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboPlazosView.Focus();
                    return "ERROR";
                }
            }
            if (txtTasaMor.Text.Trim() == "" && Convert.ToInt32(cboModulo.SelectedValue) == 1)
            {
                MessageBox.Show("Debe Indicar la Tasa Moratoria", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaMor.Focus();
                return "ERROR";
            }
            if (txtTasaCom.Text.Trim() == "")
            {
                MessageBox.Show("Debe Indicar la Tasa Compensatoria", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaCom.Focus();
                return "ERROR";
            }
            if (txtTasaCompMax.Text.Trim() == "" && Convert.ToInt32(cboModulo.SelectedValue) == 1)
            {
                MessageBox.Show("Debe Indicar la Tasa Compensatoria Máxima", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaCompMax.Focus();
                return "ERROR";
            }
            DataTable dtModulo = (DataTable)cboModulo.DataSource;
            if (txtTasaCompMax.Visible && Convert.ToDecimal(txtTasaCom.Text.Trim()) > Convert.ToDecimal(txtTasaCompMax.Text.Trim()))
            {
                MessageBox.Show("La tasa no debe superar a la tasa maxima establecida", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaCom.Focus();
                return "ERROR";
            }

            if (txtDiasExcPenalidad.Visible && txtDiasExcPenalidad.Text.Trim() == "")
            {
                MessageBox.Show("Debe indicar los Días de excepción de penalidad", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDiasExcPenalidad.Focus();
                return "ERROR";
            }

            return "OK";
        }

        private void MostrarDatos()
        {

            if (this.dtgTarifas.Rows.Count >= 1)
            {
                HabilitarControles(false);
                if (pcTipOpe == "N")
                {
                    this.btnNuevo.Enabled = true;
                    this.btnEditar.Enabled = true;
                    this.btnProcesar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.CBAplicar.Enabled = false;
                    this.chcVigente.Enabled = false;
                    this.chcNegociable.Enabled = false;
                }
                this.RBFilAgencia.Checked = false;
                this.RBFilProducto.Checked = false;

                int filaseleccionada = Convert.ToInt32(this.dtgTarifas.CurrentRow.Index);

                int idproduc = Convert.ToInt32(this.dtgTarifas.Rows[filaseleccionada].Cells["idProducto"].Value);
                clsCNTarifario DatosTarifario = new clsCNTarifario();
                DataTable tbDatProd = DatosTarifario.RetDatosProducto(idproduc);
                    int cantNiveles = tbDatProd.Rows.Count;
                this.cboModulo.SelectedValue = Convert.ToInt32(tbDatProd.Rows[(cantNiveles - 1)]["IdProducto"]);
                this.cboTipo.SelectedValue = Convert.ToInt32(tbDatProd.Rows[(cantNiveles - 2)]["IdProducto"]);
                this.cboSubTipo.SelectedValue = Convert.ToInt32(tbDatProd.Rows[(cantNiveles - 3)]["IdProducto"]);
                this.cboProducto.SelectedValue = Convert.ToInt32(tbDatProd.Rows[(cantNiveles - 4)]["IdProducto"]);
                if (cantNiveles > 4)
                {
                    this.cboSubProducto.SelectedValue = Convert.ToInt32(tbDatProd.Rows[(cantNiveles - 5)]["IdProducto"]);
                }

                this.cboAgenciaView.SelectedValue = Convert.ToInt32(this.dtgTarifas.Rows[filaseleccionada].Cells["idAgencia"].Value);
                this.cboMonedaView.SelectedValue = Convert.ToInt32(this.dtgTarifas.Rows[filaseleccionada].Cells["idMoneda"].Value);
                this.cboTipoPersonaView.SelectedValue = Convert.ToInt32(this.dtgTarifas.Rows[filaseleccionada].Cells["idTipoPersona"].Value);
                this.cboMontosView.SelectedValue = Convert.ToInt32(this.dtgTarifas.Rows[filaseleccionada].Cells["idMonto"].Value);
                this.cboPlazosView.SelectedValue = Convert.ToInt32(this.dtgTarifas.Rows[filaseleccionada].Cells["idPlazo"].Value);
                this.cboTipoTasaCredito.SelectedValue = Convert.ToInt32(this.dtgTarifas.Rows[filaseleccionada].Cells["idTipoTasa"].Value);
                this.chcVigente.Checked = Convert.ToBoolean(this.dtgTarifas.Rows[filaseleccionada].Cells["lVigente"].Value);
                this.chcNegociable.Checked = Convert.ToBoolean(this.dtgTarifas.Rows[filaseleccionada].Cells["lNegociable"].Value);
                this.txtTasaCom.Text = this.dtgTarifas.Rows[filaseleccionada].Cells["nTasaCompensatoria"].Value + "";
                this.cboClasificacionInterna1.SelectedValue = Convert.ToInt32(this.dtgTarifas.Rows[filaseleccionada].Cells["idClasificacionInterna"].Value);

                if (txtDiasExcPenalidad.Visible)
                    this.txtDiasExcPenalidad.Text = this.dtgTarifas.Rows[filaseleccionada].Cells["nDiasExecPenalidad"].Value.ToString();

                if (Convert.ToInt32(cboModulo.SelectedValue) == 1)
                {
                    this.txtTasaMor.Text = this.dtgTarifas.Rows[filaseleccionada].Cells["nTasaMoratoria"].Value + "";
                    this.txtTasaCompMax.Text = this.dtgTarifas.Rows[filaseleccionada].Cells["nTasaCompensatoriaMax"].Value + "";
                }
                if (Convert.ToInt32(cboModulo.SelectedValue) != 1)
                {
                    this.txtTasaMor.Text = "";
                    this.txtTasaCompMax.Text = "";
                }

                if (Convert.ToBoolean(this.dtgTarifas.Rows[filaseleccionada].Cells["EnUso"].Value) == true)
                {
                    lblEstTasa.Text = "EN USO";
                    this.txtMontoNVig.Text = "";
                    this.txtMontoNVig.Visible = false;
                    this.txtPlazoNVig.Text = "";
                    this.txtPlazoNVig.Visible = false;
                }
                if (Convert.ToBoolean(this.dtgTarifas.Rows[filaseleccionada].Cells["EnUso"].Value) == false)
                {
                    lblEstTasa.Text = "FUERA DE USO";
                    this.txtMontoNVig.Text = this.dtgTarifas.Rows[filaseleccionada].Cells["cMonto"].Value + "";
                    this.txtMontoNVig.Visible = true;
                    this.txtPlazoNVig.Text = this.dtgTarifas.Rows[filaseleccionada].Cells["cPlazo"].Value + "";
                    this.txtPlazoNVig.Visible = true;
                }


                if (pcTipOpe == "A")
                {
                    this.txtTasaCom.Enabled = true;
                    if (Convert.ToInt32(cboModulo.SelectedValue) == 1)
                    {
                        this.txtTasaMor.Enabled = true;
                        this.txtTasaCompMax.Enabled = true;
                    }
                    else if (Convert.ToInt32(cboModulo.SelectedValue) != 1)
                    {
                        this.txtTasaMor.Enabled = false;
                        this.txtTasaCompMax.Enabled = false;
                    }
                    btnProcesar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
            }

        }
        private void txtTasaCom_TextChanged(object sender, EventArgs e)
        {
            if (this.txtTasaCompMax.ReadOnly)
            {
                this.txtTasaCompMax.Text = this.txtTasaCom.Text;
            }
        }

        private void cboTipoTasaCredito_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToInt32(cboTipoTasaCredito.SelectedValue) == 1)
                {
                    this.txtTasaCompMax.ReadOnly = true;
                }
                else
                {
                    this.txtTasaCompMax.ReadOnly = false;
                }
            }
            catch (InvalidCastException ice)
            { }

        }

        private void dtgTarifas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void establecerVisibilidadDiasExecPenalidad()
        {
            //Visible solo para DEPOSITOS - PLAZO FIJO - PLAZO FIJO - PLAZO FIJO
            if (cboModulo.SelectedIndex == 3 && cboTipo.SelectedIndex == 3 && cboSubTipo.SelectedIndex == 2 && cboProducto.SelectedIndex == 1)
            {
                this.txtDiasExcPenalidad.Visible = true;
                this.txtDiasExcPenalidad.Text = "0";
                this.lblDiasExcPenalidad.Visible = true;
            }
            else
            {
                this.txtDiasExcPenalidad.Visible = false;
                this.txtDiasExcPenalidad.Text = "";
                this.lblDiasExcPenalidad.Visible = false;
            }
            
        }

        private void establecerVisibilidadClasificacionInterna()
        {
            //Visible solo para CREDITOS
            if (cboModulo.SelectedIndex == 2)
            {
                this.cboClasificacionInterna1.Visible = true;
                this.lblBase11.Visible = true;
            }
            else
            {
                this.cboClasificacionInterna1.Visible = false;
                this.lblBase11.Visible = false;
            }

        }

        private void establecerVisibilidadCheckSiEsNegociable()
        {
            //Visible solo para CREDITOS
            if (cboModulo.SelectedIndex == 2)
                this.chcNegociable.Visible = true;
            else
                this.chcNegociable.Visible = false;

        }

    }
}
