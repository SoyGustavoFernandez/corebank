using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using CRE.Presentacion;
using GEN.CapaNegocio;
using CLI.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmExpedienteEntrega : frmBase
    {
        clsCNControlExp SolPenExpediente = new clsCNControlExp();
        DataTable dtSolPenExpediente = new DataTable();
        DataTable dtDetalleSolPenExp = new DataTable("dtDetalleSolPenExp");       
        
        public frmExpedienteEntrega()
        {
            InitializeComponent();
            dtSolPenExpediente = SolPenExpediente.CNBuscaSolExpediente(0, 0, 0);
            dtgListaSolExp.DataSource = dtSolPenExpediente;
            CargarPerfilesMotivoExp();
            btnAgregar1.Visible = false;
            btnQuitar1.Visible = false;
            dtFechaEnt.Value = clsVarGlobal.dFecSystem;
        }

        private void CargarPerfilesMotivoExp()
        {
            cboPerfilesExp.DisplayMember = "cPerfil";
            cboPerfilesExp.ValueMember = "idPerfil";
            cboPerfilesExp.DataSource = SolPenExpediente.CNListarPerfilesMotivoSolExp();
        }
        private void BuscaSolExpediente(int idCliente)
        {
            dtSolPenExpediente = SolPenExpediente.CNBuscaSolExpediente(clsVarGlobal.nIdAgencia, idCliente, clsVarGlobal.PerfilUsu.idPerfil);
            dtgListaSolExp.DataSource = dtSolPenExpediente;
            FormatoSolExp();

            if (dtgListaSolExp.RowCount<=0)
	        {
                MessageBox.Show("No hay solicitud pendiente de expediente", "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtgDetalleSolExp.DataSource = "";
                conBusCli1.limpiarControles();

                conBusCli1.txtCodCli.Enabled = true;
                conBusCli1.btnBusCliente.Enabled = true;
                conBusCli1.txtCodCli.Focus();
	        }            
        }

        private void FormatoGridSolExpe()
        {
            foreach (DataGridViewColumn item in dtgListaSolExp.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dtgListaSolExp.Columns["idMovExpediente"].Visible = false;
            this.dtgListaSolExp.Columns["idCli"].Visible = false;
            //this.dtgListaSolExp.Columns["cDescripMotivo"].Visible = false;
            this.dtgListaSolExp.Columns["cCodExpediente"].HeaderText = "N° Exp";
            this.dtgListaSolExp.Columns["cNombre"].HeaderText = "Datos cliente";
            this.dtgListaSolExp.Columns["cWinUser"].HeaderText = "Usuario que solicita";
            this.dtgListaSolExp.Columns["cNombreUsu"].HeaderText = "Colaborador solicitante";
            this.dtgListaSolExp.Columns["dFechaRegistro"].HeaderText = "Fecha reg.";
            this.dtgListaSolExp.Columns["cMotivo"].HeaderText = "Motivo";
            this.dtgListaSolExp.Columns["idMotivoSolicitud"].Visible = false;
            this.dtgListaSolExp.Columns["idTipoOpeExp"].Visible = false;
            this.dtgListaSolExp.Columns["chk"].Width = 10;
            this.dtgListaSolExp.Columns["cCodExpediente"].Width = 30;
            this.dtgListaSolExp.Columns["cNombre"].Width = 50;
            this.dtgListaSolExp.Columns["cWinUser"].Width = 20;
            this.dtgListaSolExp.Columns["cNombreUsu"].Width = 50;
            this.dtgListaSolExp.Columns["dFechaRegistro"].Width = 80;
            this.dtgListaSolExp.Columns["cMotivo"].DisplayIndex = 3;
        }

        private void FormatoSolExp()
        {
            FormatoGridSolExpe();

            dtgDetalleSolExp.DataSource = dtDetalleSolPenExp.DefaultView;
            this.dtgDetalleSolExp.Columns["idDetalleExp"].Visible = false;
            this.dtgDetalleSolExp.Columns["idExpediente"].Visible = true;
            this.dtgDetalleSolExp.Columns["idcli"].Visible = false;
            this.dtgDetalleSolExp.Columns["lVigente"].Visible = false;
            this.dtgDetalleSolExp.Columns["idTipoDocumento"].Visible = false;
            this.dtgDetalleSolExp.Columns["idTipoOpeExp"].Visible = false;
            this.dtgDetalleSolExp.Columns["idDocExp"].Visible = false;
            this.dtgDetalleSolExp.Columns["cDocumento"].HeaderText = "Documento";
//          this.dtgDetalleSolExp.Columns["cContenidoExp"].HeaderText = "Contenido Expediente";
            this.dtgDetalleSolExp.Columns["cDescripCond"].HeaderText = "Condición Expediente";
            this.dtgDetalleSolExp.Columns["cDescripTipoFolio"].HeaderText = "Tipo Folio";
            this.dtgDetalleSolExp.Columns["nNroFolios"].HeaderText = "Nro. Folios";
            this.dtgDetalleSolExp.Columns["cTipoDocumento"].HeaderText = "Tipo Documento";
            this.dtgDetalleSolExp.Columns["idExpediente"].HeaderText = "Cod. Exp.";
//            this.dtgDetalleSolExp.Columns["cContenidoExp"].Width = 80;
            this.dtgDetalleSolExp.Columns["cDescripCond"].Width = 80;
            this.dtgDetalleSolExp.Columns["cDescripTipoFolio"].Width = 80; 
        }

        private void frmEntregaExpediente_Load(object sender, EventArgs e)
        {
            dtDetalleSolPenExp.Columns.Add("idDetalleExp", typeof(int));
            dtDetalleSolPenExp.Columns.Add("idExpediente", typeof(string));
            dtDetalleSolPenExp.Columns.Add("idcli", typeof(int));
            dtDetalleSolPenExp.Columns.Add("cContenidoExp", typeof(string));
            dtDetalleSolPenExp.Columns.Add("cDescripCond", typeof(string));
            dtDetalleSolPenExp.Columns.Add("cDescripTipoFolio", typeof(string));
            dtDetalleSolPenExp.Columns.Add("lVigente", typeof(bool));
            dtDetalleSolPenExp.Columns.Add("nNroFolios", typeof(int));
            dtDetalleSolPenExp.Columns.Add("cTipoDocumento", typeof(string));
            dtDetalleSolPenExp.Columns.Add("idTipoDocumento", typeof(int));
            dtDetalleSolPenExp.Columns.Add("idTipoOpeExp", typeof(int));
            dtDetalleSolPenExp.Columns.Add("idDocExp", typeof(int));
            dtDetalleSolPenExp.Columns.Add("cDocumento", typeof(string));
            BuscaSolExpediente(0);                     
        }

        private void rbBusquedaPerson_CheckedChanged(object sender, EventArgs e)
        {
            dtgListaSolExp.DataSource = "";
            dtgDetalleSolExp.DataSource = "";
            Limpiar();
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.btnBusCliente.Enabled = true;
        }

        private void rbBusqGeneral_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
            BuscaSolExpediente(0);            
            conBusCli1.txtCodCli.Enabled = false;
            conBusCli1.btnBusCliente.Enabled = false;            
        }

        private void dtgListaSolExp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgListaSolExp.RowCount > 0)
            {
                //int filas = dtgListaSolExp.CurrentCell.RowIndex;
                //dtDetalleSolPenExp = SolPenExpediente.CNListDetalleExp(Convert.ToInt32(dtSolPenExpediente.Rows[filas]["idCli"]), Convert.ToInt32(dtSolPenExpediente.Rows[filas]["idTipoOpeExp"]));
                //dtgDetalleSolExp.DataSource = dtDetalleSolPenExp.DefaultView;

                    int filas = dtgListaSolExp.CurrentCell.RowIndex;
                    int TipoOpeExpe = 0;
                    string CodExpediente = Convert.ToString(dtgListaSolExp.Rows[filas].Cells["cCodExpediente"].Value);
                    for (int i = 0; i <= dtSolPenExpediente.Rows.Count; i++)
                    {
                        string cod = dtSolPenExpediente.Rows[i]["cCodExpediente"].ToString();
                        if (CodExpediente.Equals(cod))
                        {
                            TipoOpeExpe = Convert.ToInt32(dtSolPenExpediente.Rows[i]["idTipoOpeExp"]);
                            break;
                        }
                    }

                    int cliente = Convert.ToInt32(dtSolPenExpediente.Rows[filas]["idCli"]);
                    // int TipoOpeExpediente = Convert.ToInt32(dtSolPenExpediente.Rows[filas]["idTipoOpeExp"]);
                    dtDetalleSolPenExp = SolPenExpediente.CNListDetalleExp(cliente, TipoOpeExpe);
                    dtgDetalleSolExp.DataSource = dtDetalleSolPenExp.DefaultView;
                    FormatoSolExp();
            }
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32(string.IsNullOrEmpty(conBusCli1.txtCodCli.Text) ? "-1" : conBusCli1.txtCodCli.Text);
            BuscaSolExpediente(idCliente);

            if (!string.IsNullOrEmpty(conBusCli1.txtCodCli.Text))
            {
                dtDetalleSolPenExp = SolPenExpediente.CNListDetalleExp(idCliente, 0);
                dtgDetalleSolExp.DataSource = dtDetalleSolPenExp.DefaultView;
            }          
            FormatoSolExp();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {            
            conBusCli1.txtCodCli.Text = "";
            conBusCli1.txtCodAge.Text = "";
            conBusCli1.txtCodInst.Text = "";
            conBusCli1.txtDireccion.Text = "";
            conBusCli1.txtNombre.Text = "";
            conBusCli1.txtNroDoc.Text = "";
            txtNroExpEnt.Text = "";
            txtDescripMotivo.Text = "";
            chcTodos.Checked = false;
            cboPerfilesExp.SelectedIndex = 0;
            for (int i = 0; i < dtgListaSolExp.RowCount; i++)
            {
                dtgListaSolExp.Rows[i].Cells[0].Value = false;
            }
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            int filas = dtgListaSolExp.CurrentCell.RowIndex;
            
            frmRegDocExpediente frmRegDocExpediente = new frmRegDocExpediente();            
            frmRegDocExpediente.InsDetalle(Convert.ToInt32(dtSolPenExpediente.Rows[filas]["idCli"]));//, Convert.ToInt32(dtValidaSocio.Rows[0]["idSocio"]));
            frmRegDocExpediente.ShowDialog();
            BuscaSolExpediente(0);                
        }

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (this.dtgDetalleSolExp.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el registro a eliminar", "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgDetalleSolExp.SelectedCells[0].RowIndex);
                if (Convert.ToInt32(dtgDetalleSolExp.Rows[nFilaActual].Cells["idDetalleExp"].Value) == -1)
                {
                    dtgDetalleSolExp.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgDetalleSolExp.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgDetalleSolExp.Focus();
                ProcessTabKey(true);

                DataTable dtDetExpediente = SolPenExpediente.CNListDetalleExp(0, 0);                
                for (int i = 0; i < dtDetalleSolPenExp.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtDetalleSolPenExp.Rows[i]["lVigente"]) == 0)
                    {                        
                        DataRow dr = dtDetExpediente.NewRow();
                        dr["idDetalleExp"]      = dtDetalleSolPenExp.Rows[i]["idDetalleExp"];
                        dr["idcli"]             = dtDetalleSolPenExp.Rows[i]["idcli"];
                        dr["lVigente"]          = dtDetalleSolPenExp.Rows[i]["lVigente"];
                        dr["cContenidoExp"]     = dtDetalleSolPenExp.Rows[i]["cContenidoExp"];
                        dr["cDescripCond"]      = dtDetalleSolPenExp.Rows[i]["cDescripCond"];
                        dr["cDescripTipoFolio"] = dtDetalleSolPenExp.Rows[i]["cDescripTipoFolio"];
                        dtDetExpediente.Rows.Add(dr);
                    }  
                }
                                              
                DialogResult result = DialogResult.None;
                result = MessageBox.Show("Esta seguro(a) de quitar el documento del expediente(s)", "Entrega de expediente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.None || result == DialogResult.Yes)
                {
                    DataSet dsExpediente = new DataSet("dsExpediente");
                    dsExpediente.Tables.Add(dtDetExpediente);
                    string xmlExpediente = clsCNFormatoXML.EncodingXML(dsExpediente.GetXml());
                    dsExpediente.Tables.Clear();
                    DataTable dtRegDetExpediente = SolPenExpediente.CNInsDetalleExpediente(xmlExpediente);

                    MessageBox.Show("El documento fue quitado correctamente", "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                else
                {
                    Limpiar();
                }
                BuscaSolExpediente(0);
            }
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgListaSolExp.RowCount; i++)
            {
                if (chcTodos.Checked)
                {
                    dtgListaSolExp.Rows[i].Cells[0].Value = true;
                }
                else
                {
                    dtgListaSolExp.Rows[i].Cells[0].Value = false;
                }
            }
            NroExpSelec();
        }

        private void dtgListaSolExp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nIndice = dtgListaSolExp.CurrentRow.Index;
            
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dtgListaSolExp.Rows[nIndice].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;

           
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    break;

                case "False":
                    string cCodExpediente = Convert.ToString(dtgListaSolExp.Rows[nIndice].Cells["cCodExpediente"].Value);
                    /* ---------------------VERIFICANDO QUE NO SE HA SELECCIONADO YA A ESTE EXPEDIENTE DEL CLIENTE ----------------------------- */
                    foreach (DataGridViewRow item in dtgListaSolExp.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[0].Value) && Convert.ToString(item.Cells["cCodExpediente"].Value) == cCodExpediente)
                        {
                            MessageBox.Show("No puede seleccionar más de una solicitud del expediente: "
                                + Convert.ToString(dtgListaSolExp.Rows[nIndice].Cells["cCodExpediente"].Value)
                                + " del cliente: "
                                + Convert.ToString(dtgListaSolExp.Rows[nIndice].Cells["cNombre"].Value)
                                , "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        
                    }
                    /* ---------------------FIN VERIFICANDO QUE NO SE HA SELECCIONADO YA A ESTE EXPEDIENTE DEL CLIENTE ------------------------- */
                    ch1.Value = true;

                    break;
            }
            NroExpSelec();
        }

        private void NroExpSelec()
        {
            int NroExp = 0;
            for (int i = 0; i < dtgListaSolExp.RowCount; i++)
            {
                if (Convert.ToBoolean(dtgListaSolExp.Rows[i].Cells[0].Value) == true)
                {
                    NroExp++;
                } 
            }
            txtNroExpEnt.Text = Convert.ToString(NroExp);
        }         

        private void btnEntregado1_Click(object sender, EventArgs e)
        {
            RegistrarEstadoExpedientes("E");
        }

        private Boolean Valida() 
        {
            if (dtFechaEnt.Value<clsVarGlobal.dFecSystem)
	        {
                MessageBox.Show("La fecha de entrega no puede ser menor a la fecha del sistema", "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
	        }
            if (this.txtNroExpEnt.Text=="" || this.txtNroExpEnt.Text =="0" )
            {
                MessageBox.Show("Debe seleccionar al menos un expediente", "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            return true;
        }
        
        private void btnDenegar1_Click(object sender, EventArgs e)
        {
            RegistrarEstadoExpedientes("D");
        }
        
        private void RegistrarEstadoExpedientes(string cEstado)
        { 
            if (!Valida())
            {
                return;
            }
            
            //Verificando si el cliente que confirmar actualizacion
            DialogResult result = DialogResult.None;
            result = MessageBox.Show(retornaMensajeConfirmacionPorEstado(cEstado), "Entrega de expediente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {

                DataTable dtRegExpediente = new DataTable();
                //obteniendo la estructura de la tabla a guardar
                dtRegExpediente = SolPenExpediente.CNBuscaSolExpediente(0, 0, 0);

                for (int i = 0; i < dtgListaSolExp.RowCount; i++)
                {
                    if (Convert.ToBoolean(dtgListaSolExp.Rows[i].Cells[0].Value) == true)
                    {
                        
                        /* --------------------- VALIDANDO SI EL EXPEDIENTE HA SIDO ENTREGADO ----------------------------- */
                        DataTable dtRes = SolPenExpediente.CNBuscaExpeEntreTipoOpe(Convert.ToInt32(this.dtgListaSolExp.Rows[i].Cells["idCli"].Value), Convert.ToInt32(this.dtgListaSolExp.Rows[i].Cells["idTipoOpeExp"].Value));
                        if (dtRes.Rows.Count > 0 && cEstado == "E") 
                        {
                            MessageBox.Show("El expediente del cliente: " + Convert.ToInt32(this.dtgListaSolExp.Rows[i].Cells["idMovExpediente"].Value)  + " - " 
                                + dtgListaSolExp.Rows[i].Cells["cNombre"].Value.ToString() + " ya ha sido entregado al colaborador: "
                                + dtRes.Rows[0]["cNombreColaborador"], "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        /* --------------------- END VALIDANDO -------------------------- */

                        DataRow drfilaExp = dtRegExpediente.NewRow();
                        drfilaExp["cNombre"] = this.dtgListaSolExp.Rows[i].Cells["cNombre"].Value.ToString();
                        drfilaExp["cNombreUsu"] = this.dtgListaSolExp.Rows[i].Cells["cNombreUsu"].Value.ToString();
                        drfilaExp["idMovExpediente"] = Convert.ToInt32(this.dtgListaSolExp.Rows[i].Cells["idMovExpediente"].Value);
                        drfilaExp["idCli"] = Convert.ToInt32(this.dtgListaSolExp.Rows[i].Cells["idCli"].Value);
                        drfilaExp["dFechaRegistro"] = dtFechaEnt.Value;
                        //drfilaExp["cDescripMotivo"] = txtDescripMotivo.Text;
                        drfilaExp["cCodExpediente"] = this.dtgListaSolExp.Rows[i].Cells["cCodExpediente"].Value.ToString();
                        //drfilaExp["idTipoOpeExp"] = Convert.ToInt32(this.dtgListaSolExp.Rows[i].Cells["idTipoOpeExp"].Value);
                        dtRegExpediente.Rows.Add(drfilaExp);
                    }
                }

                DataSet dsExpediente = new DataSet("dsExpediente");
                dsExpediente.Tables.Add(dtRegExpediente);
                string xmlExpediente = clsCNFormatoXML.EncodingXML(dsExpediente.GetXml());

                // solo valida si el cEstado es D
                if (txtDescripMotivo.Text == "" && cEstado == "D") 
                {
                    MessageBox.Show("Debe describir el motivo porque deniega la solicitud del expediente", "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DataTable RegSolExp = SolPenExpediente.CNActEstadoExp(xmlExpediente, cEstado, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.User.idUsuario);
                if (Convert.ToInt32(RegSolExp.Rows[0]["nResultado"]) == 1)
                {
                    MessageBox.Show(retornaMensajeRespuestaPositiva(cEstado), "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chcTodos.Checked = false;
                    dtDetalleSolPenExp.Clear();
                    BuscaSolExpediente(0);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(retornaMensajeRespuestaNegativa(cEstado), "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private void dtgListaSolExp_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgListaSolExp.RowCount > 0)
            {
                int filas = dtgListaSolExp.CurrentCell.RowIndex;
                int TipoOpeExpe = 0;
                string CodExpediente = Convert.ToString(dtgListaSolExp.Rows[filas].Cells["cCodExpediente"].Value);
                for (int i = 0; i <= dtSolPenExpediente.Rows.Count; i++)
                {
                    string cod = dtSolPenExpediente.Rows[i]["cCodExpediente"].ToString();
                    if (CodExpediente.Equals(cod))
                    {
                        TipoOpeExpe = Convert.ToInt32(dtSolPenExpediente.Rows[i]["idTipoOpeExp"]);
                        break;
                    }
                }

                int cliente = Convert.ToInt32(dtSolPenExpediente.Rows[filas]["idCli"]);
               // int TipoOpeExpediente = Convert.ToInt32(dtSolPenExpediente.Rows[filas]["idTipoOpeExp"]);
                dtDetalleSolPenExp = SolPenExpediente.CNListDetalleExp(cliente, TipoOpeExpe);
                dtgDetalleSolExp.DataSource = dtDetalleSolPenExp.DefaultView;
                FormatoSolExp();
            }
        }

        private void cboPerfilesExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtNuevo = dtSolPenExpediente.Clone();
            foreach (DataRow item in dtSolPenExpediente.Rows)
            {
                if (Convert.ToInt32(cboPerfilesExp.SelectedValue) == 0)
                {
                    dtNuevo.ImportRow(item);
                }
                else if (Convert.ToInt32(item["idPerfil"]) == Convert.ToInt32(cboPerfilesExp.SelectedValue))
                {
                    dtNuevo.ImportRow(item);
                }
            }
            dtgListaSolExp.DataSource = null;
            dtgListaSolExp.DataSource = dtNuevo;
            
            FormatoGridSolExpe();
        }

        private string retornaMensajeConfirmacionPorEstado(string cEstado)
        {
            string cRpta = "";
            switch (cEstado)
            {
                case "E":
                    cRpta = "Esta seguro(a) de entregar el expediente(s)";
                    break;
                case "D":
                    cRpta = "Esta seguro(a) de denegar la solicitud del expediente(s)";
                    break;
            }
            return cRpta;
        }

        private string retornaMensajeRespuestaPositiva(string cEstado)
        {
            string cRpta = "";
            switch (cEstado)
            {
                case "E":
                    cRpta = "La entrega Expediente(s) se realizo correctamente";
                    break;
                case "D":
                    cRpta = "El expediente se denego correctamente";
                    break;
            }
            return cRpta;
        }

        private string retornaMensajeRespuestaNegativa(string cEstado)
        {
            string cRpta = "";
            switch (cEstado)
            {
                case "E":
                    cRpta = "Error al entregar expediente(s)";
                    break;
                case "D":
                    cRpta = "Error al denegar expediente(s)";
                    break;
            }
            return cRpta;
        }

    }
}
