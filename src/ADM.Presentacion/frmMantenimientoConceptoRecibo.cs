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
using CAJ.CapaNegocio;
using EntityLayer;
using DEP.CapaNegocio.AhorroWeb;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoConceptoRecibo : frmBase
    {
        DataTable tbConceptoRecib;
        String TipOpe = "N";
        int idConcep;
        string nPerfilMantenimiento = "";
        int nPerfil = clsVarGlobal.PerfilUsu.idPerfil;
        clsCNAWGeneral objGeneral=new clsCNAWGeneral();

        public frmMantenimientoConceptoRecibo()
        {
            InitializeComponent();
        }

        private void frmMantenimientoConceptoRecibo_Load(object sender, EventArgs e)
        {
            obtenerPerfilUsuario();
            activarControlObjetos(this, EventoFormulario.INICIO);
            CargarCbo();
             //PERTENECE GRUPO EJECUTIVO
            if (nPerfilMantenimiento == "GrupoEjecutivo")
            {
                clsAWVariable objVar = objGeneral.obtenerVariable("cConceptosGrupoEjecutivo");
                string cIdConceptosRecibo = objVar.cValVar;
                CargarConcepRecibosEjCorp(0, cIdConceptosRecibo);
            }
            else
            {
                CargarConcepRecibos(0);
            }
          
            cboTipoRecibo.SelectedIndex = -1;            
            HabilitarControles(false);
           
            Limpiar();
        }

        private void CargarCbo() {
            clsCNControlOpe LisTiprec = new clsCNControlOpe();
            DataTable tbTipRec;
            //PERTENECE GRUPO EJECUTIVO
            if (nPerfilMantenimiento == "GrupoEjecutivo")
            {
                clsAWVariable objVar = objGeneral.obtenerVariable("cTipoReciboGrupoEjecutivo");
                string cIdTipoRecibo = objVar.cValVar;
                tbTipRec = LisTiprec.LisTipoRecibosGrupoEjecutivo(cIdTipoRecibo);

                cboTipoRecibo.DataSource = tbTipRec;
               
            }
            else
            {
                tbTipRec = LisTiprec.ListarTipoRecibos();
                cboTipoRecibo.DataSource = tbTipRec;
            }
              
            cboTipoRecibo.ValueMember = tbTipRec.Columns["idTipRecibo"].ToString();
            cboTipoRecibo.DisplayMember = tbTipRec.Columns["cDescripcion"].ToString();
            cboTipoRecibo.SelectedIndex = -1;


            DataTable tb = new DataTable();
            tb.Columns.Add("id");
            tb.Columns.Add("cTipoMonto");

            DataRow row = tb.NewRow();
            row["id"] = 1;
            row["cTipoMonto"] = "FIJO";
            tb.Rows.Add(row);

            row = tb.NewRow();
            row["id"] = 2;
            row["cTipoMonto"] = "VARIABLE";
            tb.Rows.Add(row);

            cboTipoMonto.DataSource = tb;
            cboTipoMonto.ValueMember = Convert.ToString(tb.Columns["id"]);
            cboTipoMonto.DisplayMember = Convert.ToString(tb.Columns["cTipoMonto"]);
            cboTipoMonto.SelectedIndex = -1;

        }
        
        
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            TipOpe = "EA";//Editar un Recibo Antiguo
            HabilitarControles(true);
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;     
        }

      
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            if (TipOpe == "N")
            {//ESTADO NORMAL
                Limpiar();
                tbConceptoRecib.Rows.Clear();
                HabilitarControles(false);
                btnNuevo1.Enabled = false;
                btnEditar1.Enabled = false;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
                cboTipoRecibo.SelectedIndex = -1;
            }

            if (TipOpe == "EN" || TipOpe == "EA")//EDITANDO(MODIFICANDO O CREANDO NUEVO)
            {
                Limpiar();
                HabilitarControles(false);
                btnNuevo1.Enabled = true;
                btnCancelar1.Enabled = true;
                btnGrabar1.Enabled = false;
                if (dtgConcepRecib.SelectedRows.Count > 0)
                    btnEditar1.Enabled = true;
                else
                    btnEditar1.Enabled = false;
            }
            TipOpe = "N";
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {           
            
                if (Validaciones() == "ERROR")
                {
                    return;
                }

                string TipoMonto = "";
                if (Convert.ToInt32(cboTipoMonto.SelectedValue) == 1)
                    TipoMonto = "F";
                if (Convert.ToInt32(cboTipoMonto.SelectedValue) == 2)
                    TipoMonto = "V";

                clsCNMantConcepRec Conceptos = new clsCNMantConcepRec();
                if (TipOpe == "EA")//MODIFICAR CONCEPTO
                {
                    Int32 nFila = Convert.ToInt32(dtgConcepRecib.SelectedCells[0].RowIndex);
                    idConcep = Conceptos.ActualizarConcepRec(Convert.ToInt32(dtgConcepRecib.Rows[nFila].Cells["idConcepto"].Value), "E", Convert.ToInt32(cboTipoRecibo.SelectedValue), Convert.ToString(txtNombConcepto.Text.Trim()),
                                                   TipoMonto, Convert.ToDecimal(txtMonto.Text), Convert.ToInt32(CBAfectaITF.Checked), Convert.ToInt32(CBSoloPersonal.Checked),
                                                   Convert.ToInt32(CBVigente.Checked), chcAfectaCaja.Checked, chbRestringido.Checked);
                    MessageBox.Show("Los datos se Actualizaron Correctamente", "Mantenimiento de Conceptos de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                if (TipOpe == "EN")//REG. CONCEPTO NUEVO
                {
                    idConcep = Conceptos.ActualizarConcepRec(0, "N", Convert.ToInt32(cboTipoRecibo.SelectedValue), Convert.ToString(txtNombConcepto.Text.Trim()),
                                                   TipoMonto, Convert.ToDecimal(txtMonto.Text), Convert.ToInt32(CBAfectaITF.Checked), Convert.ToInt32(CBSoloPersonal.Checked),
                                                   Convert.ToInt32(CBVigente.Checked), chcAfectaCaja.Checked, chbRestringido.Checked);
                    MessageBox.Show("Los datos se Guardaron Correctamente", "Mantenimiento de Conceptos de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

              
                 //PERTENECE GRUPO EJECUTIVO
                if (nPerfilMantenimiento == "GrupoEjecutivo")
                {
                    clsAWVariable objVar = objGeneral.obtenerVariable("cConceptosGrupoEjecutivo");
                    string cIdConceptosRecibo = objVar.cValVar;
                    CargarConcepRecibosEjCorp(Convert.ToInt32(cboTipoRecibo.SelectedValue), cIdConceptosRecibo);
                }
                else
                {
                    CargarConcepRecibos(Convert.ToInt32(cboTipoRecibo.SelectedValue));
                }
                int n = 0;
                foreach (DataGridViewRow fila in dtgConcepRecib.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idConcepto"].Value) == idConcep)
                    {
                        dtgConcepRecib.CurrentCell = dtgConcepRecib.Rows[n - 1].Cells["cConcepto"];
                        MostrarDatos();
                    }
                }
                
            
            TipOpe = "N";
            HabilitarControles(false);
            //PERTENECE GRUPO EJECUTIVO
            if (nPerfilMantenimiento == "GrupoEjecutivo")
            {
                btnNuevo1.Enabled = false;
            }
            else
            {
                btnNuevo1.Enabled = true;
            }
           
            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = false;
            
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            TipOpe = "EN";//Editar un Nuevo Recibo
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            Limpiar();
            HabilitarControles(true);
            CBVigente.Checked = true;
            CBVigente.Enabled = false;  
        }

     
        private void dtgConcepRecib_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos() { 
            if (dtgConcepRecib.SelectedRows.Count > 0)
            {
                int FilaSeleccionada = Convert.ToInt32(dtgConcepRecib.SelectedCells[2].RowIndex);

                txtNombConcepto.Text = Convert.ToString(dtgConcepRecib.Rows[FilaSeleccionada].Cells["cConcepto"].Value);
                if (Convert.ToString(dtgConcepRecib.Rows[FilaSeleccionada].Cells["cTipMonto"].Value)=="F")
                    cboTipoMonto.SelectedValue = 1;
                if (Convert.ToString(dtgConcepRecib.Rows[FilaSeleccionada].Cells["cTipMonto"].Value) == "V")
                    cboTipoMonto.SelectedValue = 2;
                txtMonto.Text = Convert.ToString(dtgConcepRecib.Rows[FilaSeleccionada].Cells["nMontoCon"].Value);
                CBAfectaITF.Checked = Convert.ToBoolean(dtgConcepRecib.Rows[FilaSeleccionada].Cells["nAfectoITF"].Value);
                CBSoloPersonal.Checked = Convert.ToBoolean(dtgConcepRecib.Rows[FilaSeleccionada].Cells["nIndSoloPer"].Value);
                CBVigente.Checked = Convert.ToBoolean(dtgConcepRecib.Rows[FilaSeleccionada].Cells["cEstado"].Value);
                chcAfectaCaja.Checked = Convert.ToBoolean(dtgConcepRecib.Rows[FilaSeleccionada].Cells["lAfectaCaja"].Value);
                chbRestringido.Checked = Convert.ToBoolean(dtgConcepRecib.Rows[FilaSeleccionada].Cells["lRestringido"].Value);
                
                HabilitarControles(false);
                 
                btnNuevo1.Enabled = true;
                btnEditar1.Enabled = true;
                btnCancelar1.Enabled = true;
                btnGrabar1.Enabled = false;

                //PERTENECE GRUPO EJECUTIVO
                if (nPerfilMantenimiento == "GrupoEjecutivo")
                {
                    btnNuevo1.Enabled = false;
                }
            }        
        }
        private void CargarConcepRecibos(int idTipRecibo)
        {
            clsCNMantConcepRec Conceptos = new clsCNMantConcepRec();
            tbConceptoRecib = Conceptos.ListarConcep(idTipRecibo);
         
            if (dtgConcepRecib.ColumnCount > 0)
            {
                dtgConcepRecib.Columns.Remove("Est");
                dtgConcepRecib.Columns.Remove("idConcepto");
                dtgConcepRecib.Columns.Remove("cConcepto");
                dtgConcepRecib.Columns.Remove("cTipMonto");
                dtgConcepRecib.Columns.Remove("nMontoCon");
                dtgConcepRecib.Columns.Remove("nAfectoITF");
                dtgConcepRecib.Columns.Remove("cEstado");
                dtgConcepRecib.Columns.Remove("nIndSoloPer");
                dtgConcepRecib.Columns.Remove("cVigencia");
                dtgConcepRecib.Columns.Remove("lAfectaCaja");
                dtgConcepRecib.Columns.Remove("lRestringido");
            }

        
                dtgConcepRecib.DataSource = tbConceptoRecib.DefaultView;
                FormatoDtgConceptosRec();

        }
        private void CargarConcepRecibosEjCorp(int idTipRecibo,string cIdConceptos)
        {
        
            clsCNMantConcepRec Conceptos = new clsCNMantConcepRec();
            tbConceptoRecib = Conceptos.ListarConcepEjCorp(idTipRecibo, cIdConceptos);

            if (dtgConcepRecib.ColumnCount > 0)
            {
                dtgConcepRecib.Columns.Remove("Est");
                dtgConcepRecib.Columns.Remove("idConcepto");
                dtgConcepRecib.Columns.Remove("cConcepto");
                dtgConcepRecib.Columns.Remove("cTipMonto");
                dtgConcepRecib.Columns.Remove("nMontoCon");
                dtgConcepRecib.Columns.Remove("nAfectoITF");
                dtgConcepRecib.Columns.Remove("cEstado");
                dtgConcepRecib.Columns.Remove("nIndSoloPer");
                dtgConcepRecib.Columns.Remove("cVigencia");
                dtgConcepRecib.Columns.Remove("lAfectaCaja");
                dtgConcepRecib.Columns.Remove("lRestringido");
            }


            dtgConcepRecib.DataSource = tbConceptoRecib.DefaultView;
            FormatoDtgConceptosRec();

        }

        private void FormatoDtgConceptosRec()
        {
            dtgConcepRecib.Columns["Est"].Visible = false;
            dtgConcepRecib.Columns["idConcepto"].Visible = false;
            dtgConcepRecib.Columns["cConcepto"].Width = 110;
            dtgConcepRecib.Columns["cConcepto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgConcepRecib.Columns["cConcepto"].HeaderText = "Concepto del Recibo";
            dtgConcepRecib.Columns["cTipMonto"].Visible = false;
            dtgConcepRecib.Columns["nMontoCon"].Width = 35;
            dtgConcepRecib.Columns["nMontoCon"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgConcepRecib.Columns["nMontoCon"].HeaderText = "Monto";
            dtgConcepRecib.Columns["cVigencia"].Width = 35;
            dtgConcepRecib.Columns["cVigencia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgConcepRecib.Columns["cVigencia"].HeaderText = "Vigencia";
            dtgConcepRecib.Columns["nAfectoITF"].Visible = false;
            dtgConcepRecib.Columns["cEstado"].Visible = false;
            dtgConcepRecib.Columns["nIndSoloPer"].Visible = false;
            dtgConcepRecib.Columns["lAfectaCaja"].Visible = false;
            dtgConcepRecib.Columns["lRestringido"].Visible = false;
        }

        private string Validaciones()
        {
            if (cboTipoRecibo.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de Recibo", "Mantenimiento de Concepto de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoRecibo.Focus();
                return "ERROR";
            }
            if (txtNombConcepto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nombre del Concepto de Recibo", "Mantenimiento de Concepto de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombConcepto.Focus();
                return "ERROR";
            }

            if (cboTipoMonto.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de Monto", "Mantenimiento de Concepto de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoMonto.Focus();
                return "ERROR";
            }
            if (txtMonto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Monto", "Mantenimiento de Concepto de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonto.Focus();
                return "ERROR";
            }
            if (TipOpe == "EA")
            {
                int filaSeleccionada = Convert.ToInt32(dtgConcepRecib.SelectedCells[2].RowIndex);

                for (int i = 0; i <= (dtgConcepRecib.Rows.Count - 1); i++)
                {
                    if (i != filaSeleccionada)
                        if (Convert.ToString(dtgConcepRecib.Rows[i].Cells["cConcepto"].Value).Trim() == txtNombConcepto.Text.Trim())
                        {
                            MessageBox.Show("Ya existe un Recibo con el mismo Nombre", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNombConcepto.Focus();
                            return "ERROR";
                        }
                }

            }
            if (TipOpe == "EN")
            {
                for (int i = 0; i <= (dtgConcepRecib.Rows.Count - 1); i++)
                {
                    if (Convert.ToString(dtgConcepRecib.Rows[i].Cells["cConcepto"].Value).Trim() == txtNombConcepto.Text.Trim())
                    {
                        MessageBox.Show("Ya existe una Recibo con el mismo Nombre", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNombConcepto.Focus();
                        return "ERROR";
                    }
                }
            }


            return "OK";

        }
        private void Limpiar()
        {
            txtNombConcepto.Text = "";
            cboTipoMonto.SelectedIndex = -1;
            txtMonto.Text = "";
            CBAfectaITF.Checked = false;
            CBSoloPersonal.Checked = false;
            CBVigente.Checked = false;
            chcAfectaCaja.Checked = false;
        }
        private void HabilitarControles(Boolean var)
        {
            txtNombConcepto.Enabled = var;
            cboTipoMonto.Enabled = var;
            txtMonto.Enabled = var;
            CBAfectaITF.Enabled = var;
            CBSoloPersonal.Enabled = var;
            CBVigente.Enabled = var;
            chcAfectaCaja.Enabled = var;
            chbRestringido.Enabled = var;
        }

        private void cboTipoRecibo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoRecibo.SelectedIndex) >= 0)
            {                
                //PERTENECE GRUPO EJECUTIVO
                if (nPerfilMantenimiento == "GrupoEjecutivo")
                {
                    clsAWVariable objVar = objGeneral.obtenerVariable("cConceptosGrupoEjecutivo");
                    string cIdConceptosRecibo = objVar.cValVar;
                    CargarConcepRecibosEjCorp(Convert.ToInt32(cboTipoRecibo.SelectedIndex) + 1, cIdConceptosRecibo);
                    btnNuevo1.Enabled = false;
                }
                else
                {
                    CargarConcepRecibos(Convert.ToInt32(cboTipoRecibo.SelectedIndex) + 1);
                    btnNuevo1.Enabled = true;
                }
             
            }
            else
            {
                tbConceptoRecib.Rows.Clear();
                btnNuevo1.Enabled = false;
            }
        }


        private void txtMonto_Validating(object sender, CancelEventArgs e)
        {
            if (txtMonto.Text.Trim() != "")
            {
                if (txtMonto.Text.Trim() == "0")
                    txtMonto.Text = "0.00";
                else
                    txtMonto.Text = (Convert.ToDecimal(txtMonto.Text)).ToString("#.00");
            }
        }

        private List<EPerfil> obtenerListaPerfil()
        {
            List<EPerfil> listaPefil = new List<EPerfil>();
            DataTable dtPerfil = new DataTable();

            clsCNMantenimiento obtenerPerfil = new clsCNMantenimiento();

            dtPerfil = obtenerPerfil.CNObtenerPerfilReporteExtorno("cGrupoEjecutivoMantConceptoRecibo");

            Char[] cSeparadorGrupoPerfil = { ';' };
            Char[] cSeparadorPerfil = { ':' };

            String[] cGrupoPerfil = Convert.ToString(dtPerfil.Rows[0]["cValVar"]).Split(cSeparadorGrupoPerfil);

            for (int i = 0; i < cGrupoPerfil.Length; i++)
            {
                String[] cPerfil = Convert.ToString(cGrupoPerfil[i]).Split(cSeparadorPerfil);
                EPerfil ePerfil = new EPerfil();
                ePerfil.idPerfil = Convert.ToString(cPerfil[1]);
                ePerfil.desRol = Convert.ToString(cPerfil[0]);
                listaPefil.Add(ePerfil);

            }

            return listaPefil;
        }
        private void obtenerPerfilUsuario()
        {
            List<EPerfil> listaPefil = new List<EPerfil>();
            Char[] cSeparadorIdPerfil = { ',' };
            listaPefil = obtenerListaPerfil();
            foreach (EPerfil item in listaPefil)
            {
                String[] nIdPerfil = Convert.ToString(item.idPerfil).Split(cSeparadorIdPerfil);

                foreach (string idPerfil in nIdPerfil)
                {
                    if (idPerfil == Convert.ToString(nPerfil))
                    {
                        nPerfilMantenimiento = item.desRol;
                    }
                }
            }
        }
    }
}
