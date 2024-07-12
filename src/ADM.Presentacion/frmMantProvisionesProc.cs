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
using ADM.CapaNegocio;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmMantProvisionesProc : frmBase
    {
        clsCNProvisionesProc Provisiones = new clsCNProvisionesProc(); 
        public DataTable dtPeriodos;
        int FilaPeriodoActual=-1;
        public DataTable dtTasa;
        string TipoOpe = "N";
        int Permiso = 0;
        int Permiso2 = 0;

        public frmMantProvisionesProc()
        {
            InitializeComponent();
        }

        private void frmMantProvisionesProc_Load(object sender, EventArgs e)
        {
            CargarCboEstadoPer(); 
            Permiso = 1;                  
            limpiar(); 
            CargarTasas();
            Permiso2 = 1;
            CargarPeriodos();                                                   
            HabilitarControles(false);
                
        }
        private void CargarCboEstadoPer()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("id");
            tb.Columns.Add("cEstPeriodo");

            DataRow row = tb.NewRow();
            row["id"] = 1;
            row["cEstPeriodo"] = "VIGENTE";
            tb.Rows.Add(row);

            row = tb.NewRow();
            row["id"] = 2;
            row["cEstPeriodo"] = "NO VIGENTE";
            tb.Rows.Add(row);


            cboEstPeriodoProv.DataSource = tb;
            cboEstPeriodoProv.ValueMember = Convert.ToString(tb.Columns["id"]);
            cboEstPeriodoProv.DisplayMember = Convert.ToString(tb.Columns["cEstPeriodo"]);

        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (Validaciones() == "ERROR")
                return;

            dtPeriodos.Columns["cFechaInicio"].ReadOnly = false;
            dtPeriodos.Columns["cFechaFin"].ReadOnly = false;
            dtPeriodos.Columns["Estado"].ReadOnly = false;
            dtTasa.Columns["Estado"].ReadOnly = false;
            
            if (FilaPeriodoActual >= 0)   //ACTUALIZAR EL PERIODO VIGENTE
            {
                if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue)==1)
                    dtPeriodos.Rows[FilaPeriodoActual]["lEstadoActivo"] = 1;
                else
                    dtPeriodos.Rows[FilaPeriodoActual]["lEstadoActivo"] = 0;

                dtPeriodos.Rows[FilaPeriodoActual]["idMesInicio"] = Convert.ToInt32(cboMesesInicio.SelectedValue);
                dtPeriodos.Rows[FilaPeriodoActual]["cAnioInicio"] = Convert.ToString(txtAnioInicio.Text);
                dtPeriodos.Rows[FilaPeriodoActual]["idMesfin"] = Convert.ToInt32(cboMesesFin.SelectedValue);
                dtPeriodos.Rows[FilaPeriodoActual]["cAnioFin"] = Convert.ToString(txtAnioFin.Text);
                dtPeriodos.Rows[FilaPeriodoActual]["cFechaInicio"] = Convert.ToString(cboMesesInicio.Text.Trim()) + " - " + Convert.ToString(txtAnioInicio.Text);
                dtPeriodos.Rows[FilaPeriodoActual]["cFechaFin"] = Convert.ToString(cboMesesFin.Text.Trim()) + " - " + Convert.ToString(txtAnioFin.Text);

                if (Convert.ToString(dtPeriodos.Rows[FilaPeriodoActual]["Estado"]) != "N")
                    dtPeriodos.Rows[FilaPeriodoActual]["Estado"] = "A";
            }


            if (FilaPeriodoActual < 0)//CUANDO TODAVIA NO EXISTE UN PERIODO ACTUAL 
            {                
                DataRow dr = dtPeriodos.NewRow();
                dr["idPerioProv"] = 0;
                if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue) == 1)
                    dr["lEstadoActivo"] = 1;
                else
                    dr["lEstadoActivo"] = 0;
                dr["idMesInicio"] = Convert.ToInt32(cboMesesInicio.SelectedValue);
                dr["cAnioInicio"] = txtAnioInicio.Text;
                dr["idMesfin"] = Convert.ToInt32(cboMesesFin.SelectedValue);
                dr["cAnioFin"] = txtAnioFin.Text;
                dr["cFechaInicio"] = Convert.ToString(cboMesesInicio.Text.Trim()) + " - " + Convert.ToString(txtAnioInicio.Text);
                dr["cFechaFin"] = Convert.ToString(cboMesesFin.Text.Trim()) + " - " + Convert.ToString(txtAnioFin.Text);
                dr["lPeriodoActual"] = 1;
                dr["Estado"] = "N";

                dtPeriodos.Rows.Add(dr);
                dtPeriodos.DefaultView.RowFilter = ("lPeriodoActual = False");
                dtgPeriodosProvision.DataSource = dtPeriodos.DefaultView;     
            }


            Int32 nFila = Convert.ToInt32(dtgTasaProvision.SelectedCells[1].RowIndex);
            dtTasa.Rows[nFila]["nTasaMes2"] = txtTasaMes2.Text;
            dtTasa.Rows[nFila]["nTasaMes4"] = txtTasaMes4.Text;
            dtTasa.Rows[nFila]["nTasaMes6"] = txtTasaMes6.Text;
            dtTasa.Rows[nFila]["Estado"] = "A";
                                   
                       
            DataSet dsPeriodo = new DataSet("dsPeriodos");
            dsPeriodo.Tables.Add(dtPeriodos);
            string xmlPeriodo = dsPeriodo.GetXml();
            xmlPeriodo = clsCNFormatoXML.EncodingXML(xmlPeriodo);
            dsPeriodo.Tables.Clear();

            DataSet dsTasa = new DataSet("dsTasa");
            dsTasa.Tables.Add(dtTasa);
            string xmlTasa = dsTasa.GetXml();
            xmlTasa = clsCNFormatoXML.EncodingXML(xmlTasa);
            dsTasa.Tables.Clear();

            //CUANDO TODAVIA NO EXISTE UN PERIODO ACTUAL 
            int idPerProvision = -1;
            if(FilaPeriodoActual>=0)
                idPerProvision = Convert.ToInt32(dtPeriodos.Rows[FilaPeriodoActual]["idPerioProv"]);

            //ESTABLECER EL ID DEL MES, 0 ==> CUANDO ESTÁ NO VIGENTE
            int idMes = 0;
            if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue) == 1)
                idMes = clsVarGlobal.dFecSystem.Month;

            //EXTRAER LA TASA DEL MES, 0 ==> CUANDO ESTÁ NO VIGENTE
            decimal TasaMes =  0;
            if (Convert.ToDecimal(cboEstPeriodoProv.SelectedValue) == 1)
                TasaMes = Convert.ToDecimal(txtTasaMensual.Text.Trim());

            Provisiones.ActualizarProvisiones(xmlPeriodo, xmlTasa, clsVarGlobal.dFecSystem,
                                                clsVarGlobal.PerfilUsu.idUsuario, TasaMes,
                                                idPerProvision, Convert.ToInt32(dtTasa.Rows[nFila]["idTasaProvi"]),
                                                idMes);
            
            MessageBox.Show("Los datos han sido Guardados correctamente", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarPeriodos();
            CargarTasas();
            HabilitarControles(false);
            TipoOpe = "N";

            btnEditar1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
        }

        private void dtgTasaProvision_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatosTasas();
        }

        private void HabilitarControles(Boolean val)
        {
            cboEstPeriodoProv.Enabled = val;
            btnArchivar.Enabled = val;
            cboMesesInicio.Enabled = val;
            txtAnioInicio.Enabled = val;
            cboMesesFin.Enabled = val;
            txtAnioFin.Enabled = val;

            txtTasaMes2.Enabled = val;
            txtTasaMes4.Enabled = val;
            txtTasaMes6.Enabled = val;
            txtTasaMensual.Enabled = val;
        }
        private void limpiar()
        {
            cboEstPeriodoProv.SelectedValue=0;
            cboMesesInicio.SelectedValue = 0;
            txtAnioInicio.Clear();
            cboMesesFin.SelectedValue = 0;
            txtAnioFin.Clear();

            txtTasaMes2.Clear();
            txtTasaMes4.Clear();
            txtTasaMes6.Clear();
            txtTasaMensual.Clear();
        }
        private void MostrarDatosTasas()
        {
            if (dtgTasaProvision.SelectedRows.Count > 0)
            {
                Int32 nFila = Convert.ToInt32(dtgTasaProvision.SelectedCells[1].RowIndex);
                txtTasaMes2.Text = Convert.ToString(dtgTasaProvision.Rows[nFila].Cells["nTasaMes2"].Value);
                txtTasaMes4.Text = Convert.ToString(dtgTasaProvision.Rows[nFila].Cells["nTasaMes4"].Value);
                txtTasaMes6.Text = Convert.ToString(dtgTasaProvision.Rows[nFila].Cells["nTasaMes6"].Value);

                if (Permiso2 == 1)
                {
                    //CUANDO TODAVIA NO EXISTE UN PERIODO ACTUAL 
                    int idPerProvision = -1;
                    if (FilaPeriodoActual >= 0)
                        idPerProvision = Convert.ToInt32(dtPeriodos.Rows[FilaPeriodoActual]["idPerioProv"]);
                    //ESTABLECER EL ID DEL MES, 0 ==> CUANDO ESTÁ NO VIGENTE
                    int idMes = 0;
                    if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue) == 1)
                        idMes = clsVarGlobal.dFecSystem.Month;

                    decimal Tasa = Provisiones.CargarTasaMensual(idPerProvision, Convert.ToInt32(dtTasa.Rows[nFila]["idTasaProvi"]),
                                                                idMes);
                    if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue)==2)//ESTADO: NO VIGENTE
                        txtTasaMensual.Text = "";
                    else
                        txtTasaMensual.Text = Tasa.ToString();
                }
               if (TipoOpe == "N")
                {                
                    HabilitarControles(false);
                    btnEditar1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                 }
            } 
        }

        private void CargarPeriodos()
        {            
            dtPeriodos = Provisiones.ListarPeriodosProv();            
            
            if (dtgPeriodosProvision.ColumnCount > 0)
            {
                dtgPeriodosProvision.Columns.Remove("idPerioProv");
                dtgPeriodosProvision.Columns.Remove("lEstadoActivo");
                dtgPeriodosProvision.Columns.Remove("idMesInicio");
                dtgPeriodosProvision.Columns.Remove("cAnioInicio");
                dtgPeriodosProvision.Columns.Remove("idMesfin");
                dtgPeriodosProvision.Columns.Remove("cAnioFin");

                dtgPeriodosProvision.Columns.Remove("lPeriodoActual");
                dtgPeriodosProvision.Columns.Remove("cFechaInicio");
                dtgPeriodosProvision.Columns.Remove("cFechaFin");
                dtgPeriodosProvision.Columns.Remove("Estado");                
            }

            dtPeriodos.DefaultView.RowFilter = ("lPeriodoActual = False");
            dtgPeriodosProvision.DataSource = dtPeriodos.DefaultView;
            FormatoGridPeriodos();

            //seleccionar la fila del periodo actual
            //------------------------------------------------------
            for (int i = 0; i < dtPeriodos.Rows.Count; i++) 
            {
                if (Convert.ToInt32(dtPeriodos.Rows[i]["lPeriodoActual"]) == 1)               
                    FilaPeriodoActual = i;                 
            }
            

            //mostrar datos del periodo actual
            //------------------------------------------------------
            if (FilaPeriodoActual >= 0)
            {
                if (Convert.ToInt32(dtPeriodos.Rows[FilaPeriodoActual]["lEstadoActivo"]) == 1)
                    cboEstPeriodoProv.SelectedValue = 1;
                else
                    cboEstPeriodoProv.SelectedValue = 2;
            }
            if (FilaPeriodoActual < 0)
            {
                cboEstPeriodoProv.SelectedValue = 2;    
            }
        }
        private void FormatoGridPeriodos()
        {
            dtgPeriodosProvision.Columns["idPerioProv"].Visible = false;
            dtgPeriodosProvision.Columns["lEstadoActivo"].Visible = false;
            dtgPeriodosProvision.Columns["idMesInicio"].Visible = false;
            dtgPeriodosProvision.Columns["cAnioInicio"].Visible = false;
            dtgPeriodosProvision.Columns["idMesfin"].Visible = false;
            dtgPeriodosProvision.Columns["cAnioFin"].Visible = false;
            dtgPeriodosProvision.Columns["lPeriodoActual"].Visible = false;
            dtgPeriodosProvision.Columns["cFechaInicio"].HeaderText = "Fec. Inicio";
            dtgPeriodosProvision.Columns["cFechaInicio"].Width = 50;
            dtgPeriodosProvision.Columns["cFechaInicio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgPeriodosProvision.Columns["cFechaFin"].HeaderText = "Fec. Fin";
            dtgPeriodosProvision.Columns["cFechaFin"].Width = 50;
            dtgPeriodosProvision.Columns["cFechaFin"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgPeriodosProvision.Columns["Estado"].Visible = false;

            dtgPeriodosProvision.Columns["cFechaInicio"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgPeriodosProvision.Columns["cFechaFin"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void CargarTasas()
        {            
            dtTasa = Provisiones.ListarTasasProv();            

            if (dtgTasaProvision.ColumnCount > 0)
            {
                dtgTasaProvision.Columns.Remove("idTasaProvi");
                dtgTasaProvision.Columns.Remove("cTipoCredito");
                dtgTasaProvision.Columns.Remove("nTasaMes2");
                dtgTasaProvision.Columns.Remove("nTasaMes4");
                dtgTasaProvision.Columns.Remove("nTasaMes6");
                dtgTasaProvision.Columns.Remove("Estado");
            }
                        
            dtgTasaProvision.DataSource = dtTasa.DefaultView;
            FormatoGridTasas();            
        }

        private void FormatoGridTasas()
        {
            dtgTasaProvision.Columns["idTasaProvi"].HeaderText = "Nro";
            dtgTasaProvision.Columns["idTasaProvi"].Width = 20;
            dtgTasaProvision.Columns["idTasaProvi"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgTasaProvision.Columns["cTipoCredito"].HeaderText = "Tipo de Crédito";
            dtgTasaProvision.Columns["cTipoCredito"].Width = 120;
            dtgTasaProvision.Columns["cTipoCredito"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgTasaProvision.Columns["nTasaMes2"].Visible = false;
            dtgTasaProvision.Columns["nTasaMes4"].Visible = false;
            dtgTasaProvision.Columns["nTasaMes6"].Visible = false;
            dtgTasaProvision.Columns["Estado"].Visible = false;

            dtgTasaProvision.Columns["idTasaProvi"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgTasaProvision.Columns["cTipoCredito"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private String Validaciones()
        {
            if (cboEstPeriodoProv.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Estado del periodo actual de las Provisiones Procíclicas ", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEstPeriodoProv.Focus();
                return "ERROR";
            }

            if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue) == 1)
            {
                if (cboMesesInicio.Text.Trim() == "")
                {
                    MessageBox.Show("Seleccione el Mes del inicio del periodo", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMesesInicio.Focus();
                    return "ERROR";
                }
                if (txtAnioInicio.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Año del inicio del periodo", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAnioInicio.Focus();
                    return "ERROR";
                }
                if (Convert.ToInt32(txtAnioInicio.Text.Trim()) < 1900 || Convert.ToInt32(txtAnioInicio.Text.Trim()) > 2100)
                {
                    MessageBox.Show("El Año del inicio del periodo se encuentra fuera de los parámetros (1900-2100)", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAnioInicio.Focus();
                    return "ERROR";
                }
                if (cboMesesFin.Text.Trim() == "")
                {
                    MessageBox.Show("Seleccione el Mes del fin del periodo", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMesesFin.Focus();
                    return "ERROR";
                }
                if (txtAnioFin.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Año del fin del periodo ", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAnioFin.Focus();
                    return "ERROR";
                }
                if (Convert.ToInt32(txtAnioFin.Text.Trim()) < 1900 || Convert.ToInt32(txtAnioFin.Text.Trim()) > 2100)
                {
                    MessageBox.Show("El Año del fin del periodo se encuentra fuera de los parámetros (1900-2100)", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAnioFin.Focus();
                    return "ERROR";
                }
                if (Convert.ToInt32(txtAnioFin.Text.Trim()) < Convert.ToInt32(txtAnioInicio.Text.Trim()))
                {
                    MessageBox.Show("El año de Inicio del Periodo no puede ser mayor al año del Final de éste", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAnioFin.Focus();
                    return "ERROR";
                }
                if ((txtAnioInicio.Text.Trim() == txtAnioFin.Text.Trim()) && (Convert.ToInt32(cboMesesInicio.SelectedValue) >= Convert.ToInt32(cboMesesFin.SelectedValue)))
                {
                    MessageBox.Show("El mes del Inicio del Periodo no puede ser mayor al mes del Final de éste", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMesesInicio.Focus();
                    return "ERROR";
                }
                if (Convert.ToInt32(txtAnioFin.Text.Trim()) - Convert.ToInt32(txtAnioInicio.Text.Trim()) >= 2)
                {
                    MessageBox.Show("El periodo no puede exceder los 12 meses", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMesesInicio.Focus();
                    return "ERROR";
                }
                if (Convert.ToInt32(txtAnioFin.Text.Trim()) - Convert.ToInt32(txtAnioInicio.Text.Trim()) == 1 && (Convert.ToInt32(cboMesesInicio.SelectedValue) <= Convert.ToInt32(cboMesesFin.SelectedValue)))
                {
                    MessageBox.Show("El periodo no puede exceder los 12 meses", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMesesInicio.Focus();
                    return "ERROR";
                }

            }

            if (txtTasaMes2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Tasa del Mes 2", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaMes2.Focus();
                return "ERROR";
            }
            if (txtTasaMes4.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Tasa del Mes 4", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaMes4.Focus();
                return "ERROR";
            }
            if (txtTasaMes6.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Tasa del Mes 6", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaMes6.Focus();
                return "ERROR";
            }
           

            if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue) == 1)
            {               
                int CatMesTranscurrido = (Convert.ToInt32(clsVarGlobal.dFecSystem.Month) - Convert.ToInt32(cboMesesInicio.SelectedValue) + 1);
                
                if (txtTasaMensual.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese la Tasa del Mes", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTasaMensual.Focus();
                    return "ERROR";
                }
                if ((CatMesTranscurrido == 2 || CatMesTranscurrido == 3) && Convert.ToDecimal(txtTasaMensual.Text.Trim()) < Convert.ToDecimal(txtTasaMes2.Text.Trim()))
                {
                    MessageBox.Show("El monto de la Tasa del Mes debe ser mayor o igual a: " + txtTasaMes2.Text.Trim(), "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTasaMensual.Focus();
                    return "ERROR";
                }
                if ((CatMesTranscurrido == 4 || CatMesTranscurrido == 5) && Convert.ToDecimal(txtTasaMensual.Text.Trim()) < Convert.ToDecimal(txtTasaMes4.Text.Trim()))
                {
                    MessageBox.Show("El monto de la Tasa del Mes debe ser mayor o igual a: " + txtTasaMes4.Text.Trim(), "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTasaMensual.Focus();
                    return "ERROR";
                }
                if ((CatMesTranscurrido >= 6) && Convert.ToDecimal(txtTasaMensual.Text.Trim()) < Convert.ToDecimal(txtTasaMes6.Text.Trim()))
                {
                    MessageBox.Show("El monto de la Tasa del Mes debe ser mayor o igual a: " + txtTasaMes6.Text.Trim(), "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTasaMensual.Focus();
                    return "ERROR";
                }
            }
            return "OK";
        }

        private void cboEstPeriodoProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Permiso == 1)
            {
                if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue) == 1)//ESTADO: VIGENTE
                {
                    Int32 nFila = Convert.ToInt32(dtgTasaProvision.SelectedCells[1].RowIndex);
                    if (FilaPeriodoActual >= 0) //EXISTE UN PERIODO ACTUAL
                    {                        
                        cboMesesInicio.SelectedValue = Convert.ToInt32(dtPeriodos.Rows[FilaPeriodoActual]["idMesInicio"]);
                        txtAnioInicio.Text = Convert.ToString(dtPeriodos.Rows[FilaPeriodoActual]["cAnioInicio"]);
                        cboMesesFin.SelectedValue = Convert.ToInt32(dtPeriodos.Rows[FilaPeriodoActual]["idMesfin"]);
                        txtAnioFin.Text = Convert.ToString(dtPeriodos.Rows[FilaPeriodoActual]["cAnioFin"]);
                        

                        if (Permiso2 == 1)
                        {
                            txtTasaMensual.Text = Convert.ToString(Provisiones.CargarTasaMensual(Convert.ToInt32(dtPeriodos.Rows[FilaPeriodoActual]["idPerioProv"]),
                                                           Convert.ToInt32(dtTasa.Rows[nFila]["idTasaProvi"]),
                                                           clsVarGlobal.dFecSystem.Month));
                        }
                    }
                    else if (FilaPeriodoActual < 0) //NO EXISTE UN PERIODO ACTUAL
                    {                        
                        cboMesesInicio.SelectedValue = 0;
                        txtAnioInicio.Text = "";
                        cboMesesFin.SelectedValue = 0;
                        txtAnioFin.Text = "";
                        txtTasaMensual.Text = "";
                    }
                    
                    cboMesesInicio.Enabled = true;
                    txtAnioInicio.Enabled = true;
                    cboMesesFin.Enabled = true;
                    txtAnioFin.Enabled = true;
                    btnArchivar.Enabled = true;
                    txtTasaMensual.Enabled = true;
                }
                if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue) == 2)//ESTADO: NO VIGENTE
                {
                    cboMesesInicio.SelectedValue = 0;
                    txtAnioInicio.Text = "";
                    cboMesesFin.SelectedValue = 0;
                    txtAnioFin.Text = "";
                    txtTasaMensual.Text = "";
                   
                    cboMesesInicio.Enabled = false;
                    txtAnioInicio.Enabled = false;
                    cboMesesFin.Enabled = false;
                    txtAnioFin.Enabled = false;
                    btnArchivar.Enabled = false;
                    txtTasaMensual.Enabled = false;
                }
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {   
            TipoOpe = "A";
            HabilitarControles(true);
            if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue) == 1)
            {
                int AnioInicio = Convert.ToInt32(txtAnioInicio.Text.Trim());
                int AnioActual = Convert.ToInt32(clsVarGlobal.dFecSystem.Year);

                if ((AnioInicio < AnioActual) || ((AnioInicio == AnioActual) && (Convert.ToInt32(cboMesesInicio.SelectedValue) <= clsVarGlobal.dFecSystem.Month)))
                {
                    cboEstPeriodoProv.Enabled = false;
                    cboMesesInicio.Enabled = false;
                    txtAnioInicio.Enabled = false;
                }
                else
                {
                    cboEstPeriodoProv.Enabled = true;
                    cboMesesInicio.Enabled = true;
                    txtAnioInicio.Enabled = true;                
                }
                
                cboMesesFin.Enabled = true;
                txtAnioFin.Enabled = true;
                btnArchivar.Enabled = true;
                txtTasaMensual.Enabled = true;
            }
            if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue) == 2)
            {
                cboMesesInicio.Enabled = false;
                txtAnioInicio.Enabled = false;
                cboMesesFin.Enabled = false;
                txtAnioFin.Enabled = false;
                btnArchivar.Enabled = false;
                txtTasaMensual.Enabled = false;
            }
            btnEditar1.Enabled = false;
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
            
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            TipoOpe = "N";
            limpiar();
            CargarPeriodos();
            CargarTasas();
            HabilitarControles(false);

            btnEditar1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
        }
        private void btnArchivar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue) == 1)
            {
                if (cboMesesInicio.Text.Trim() == "")
                {
                    MessageBox.Show("Seleccione el Mes del inicio del periodo", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMesesInicio.Focus();
                    return;
                }
                if (txtAnioInicio.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Año del inicio del periodo", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAnioInicio.Focus();
                    return;
                }
                if (Convert.ToInt32(txtAnioInicio.Text.Trim()) < 1900 || Convert.ToInt32(txtAnioInicio.Text.Trim()) > 2100)
                {
                    MessageBox.Show("El Año del inicio del periodo se encuentra fuera de los parámetros (1900-2100)", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAnioInicio.Focus();
                    return;
                }
                if (cboMesesFin.Text.Trim() == "")
                {
                    MessageBox.Show("Seleccione el Mes del fin del periodo", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMesesFin.Focus();
                    return;
                }
                if (txtAnioFin.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Año del fin del periodo ", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAnioFin.Focus();
                    return;
                }
                if (Convert.ToInt32(txtAnioFin.Text.Trim()) < 1900 || Convert.ToInt32(txtAnioFin.Text.Trim()) > 2100)
                {
                    MessageBox.Show("El Año del fin del periodo se encuentra fuera de los parámetros (1900-2100)", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAnioFin.Focus();
                    return;
                }
                if (Convert.ToInt32(txtAnioFin.Text.Trim()) < Convert.ToInt32(txtAnioInicio.Text.Trim()) )
                {
                    MessageBox.Show("El año de Inicio del Periodo no puede ser mayor al año del Final de éste", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAnioFin.Focus();
                    return;
                }
                if ((txtAnioInicio.Text.Trim() == txtAnioFin.Text.Trim()) && (Convert.ToInt32(cboMesesInicio.SelectedValue) >= Convert.ToInt32(cboMesesFin.SelectedValue)))
                {
                    MessageBox.Show("El mes del Inicio del Periodo no puede ser mayor al mes del Final de éste", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMesesInicio.Focus();
                    return;
                }
                if (Convert.ToInt32(txtAnioFin.Text.Trim()) - Convert.ToInt32(txtAnioInicio.Text.Trim()) >= 2)
                {
                    MessageBox.Show("El periodo no puede exceder los 12 meses", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMesesInicio.Focus();
                    return;
                }
                if (Convert.ToInt32(txtAnioFin.Text.Trim()) - Convert.ToInt32(txtAnioInicio.Text.Trim()) == 1 && (Convert.ToInt32(cboMesesInicio.SelectedValue) <= Convert.ToInt32(cboMesesFin.SelectedValue)))
                {
                    MessageBox.Show("El periodo no puede exceder los 12 meses", "Mantenimiento de Provisiones Procíclicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMesesInicio.Focus();
                    return;
                }
              
            }
            dtPeriodos.Columns["cFechaInicio"].ReadOnly = false;
            dtPeriodos.Columns["cFechaFin"].ReadOnly = false;
            dtPeriodos.Columns["Estado"].ReadOnly = false;

            if (FilaPeriodoActual >= 0) //SI YA ESTABA REGISTRADO ANTERIORMENTE UN PERIODO
            {
                    if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue) == 1)
                        dtPeriodos.Rows[FilaPeriodoActual]["lEstadoActivo"] = 1;
                    else
                        dtPeriodos.Rows[FilaPeriodoActual]["lEstadoActivo"] = 0;
                    dtPeriodos.Rows[FilaPeriodoActual]["idMesInicio"] = Convert.ToInt32(cboMesesInicio.SelectedValue);
                    dtPeriodos.Rows[FilaPeriodoActual]["cAnioInicio"] = Convert.ToString(txtAnioInicio.Text);
                    dtPeriodos.Rows[FilaPeriodoActual]["idMesfin"] = Convert.ToInt32(cboMesesFin.SelectedValue);
                    dtPeriodos.Rows[FilaPeriodoActual]["cAnioFin"] = Convert.ToString(txtAnioFin.Text);
                    dtPeriodos.Rows[FilaPeriodoActual]["cFechaInicio"] = Convert.ToString(cboMesesInicio.Text.Trim()) + " - " + Convert.ToString(txtAnioInicio.Text);
                    dtPeriodos.Rows[FilaPeriodoActual]["cFechaFin"] = Convert.ToString(cboMesesFin.Text.Trim()) + " - " + Convert.ToString(txtAnioFin.Text);
                    dtPeriodos.Rows[FilaPeriodoActual]["lPeriodoActual"] = 0;                    
                    dtPeriodos.Rows[FilaPeriodoActual]["Estado"] = "A";               
            }

            if (FilaPeriodoActual < 0)//CUANDO SE REGISTRE POR PRIMERA VEZ UN PERIODO
            {                  
                DataRow dr = dtPeriodos.NewRow();
                dr["idPerioProv"] = 0;
                if (Convert.ToInt32(cboEstPeriodoProv.SelectedValue) == 1)
                    dr["lEstadoActivo"] = 1;
                else
                    dr["lEstadoActivo"] = 0;
                dr["idMesInicio"] = Convert.ToInt32(cboMesesInicio.SelectedValue);
                dr["cAnioInicio"] = txtAnioInicio.Text;
                dr["idMesfin"] = Convert.ToInt32(cboMesesFin.SelectedValue);
                dr["cAnioFin"] = txtAnioFin.Text;
                dr["cFechaInicio"] = Convert.ToString(cboMesesInicio.Text.Trim()) + " - " + Convert.ToString(txtAnioInicio.Text);
                dr["cFechaFin"] = Convert.ToString(cboMesesFin.Text.Trim()) + " - " + Convert.ToString(txtAnioFin.Text);
                dr["lPeriodoActual"] = 0;
                dr["Estado"] = "N";

                dtPeriodos.Rows.Add(dr);
                dtPeriodos.DefaultView.RowFilter = ("lPeriodoActual = False");
                dtgPeriodosProvision.DataSource = dtPeriodos.DefaultView;                
            }
            FilaPeriodoActual = -1;            
            cboEstPeriodoProv.SelectedValue = 2;
            cboEstPeriodoProv.Enabled = true;
        }

        private void cboMesesInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Permiso == 1) {
                if (cboMesesInicio.Text.Trim() != "")
                    lblDescMes.Text = clsVarGlobal.dFecSystem.ToString("MMMM") + ", Mes N° " + (Convert.ToInt32(clsVarGlobal.dFecSystem.Month) - Convert.ToInt32(cboMesesInicio.SelectedValue) + 1) + " del periodo:";
                else
                    lblDescMes.Text = clsVarGlobal.dFecSystem.ToString("MMMM") + ", Periodo No Vigente";
            }
        }

        private void grbBase2_Enter(object sender, EventArgs e)
        {

        }

    }
}
