using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.Funciones;
using System.Drawing;

namespace GEN.ControlesBase
{
    public partial class frmBusEvalCli : frmBase
    {
        #region Variables Globales
        public clsEvalCredComite ObjEvalCred
        {
            get
            {
                if (LstEvalCredComites == null || !LstEvalCredComites.Any())
                {
                    return null;
                }
                return LstEvalCredComites.First();
            }
        }

        public List<clsEvalCredComite> LstEvalCredComites;
        private const string cTituloMsjes = "Busqueda de evaluaciones.";
        public bool MultiSeleccion;
        //public bool PermiteDevolver;

        private int nAccion = 0;
        private int nModo = 0;
        private int idCanalAproCred = 1;
        public string cCanalAproCred = "";

        public const int AGREGAR_EVAL = 1;
        public const int DEVOLVER_EVAL = 2;

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            FormatoGrid();
            dtpFecIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
            txtMontoIni.Text = "0.00";
            txtMontoFin.Text = "999999.99";
            dtgEvalCli.ReadOnly = false;

            foreach (DataGridViewColumn column in dtgEvalCli.Columns)
            {
                column.ReadOnly = true;
            }

            lSeleccion.ReadOnly = false;

            chcBusCli.Checked = true;

            conBusCli.Focus();
            conBusCli.txtCodCli.Focus();
            conBusCli.txtCodCli.Select();
            if (this.nModo == 1 || this.nModo == 2)
            {
                this.btnAceptar.Visible = true;
                this.btnDevolver.Visible = false;
                //this.grbCanalAproCred.Visible = true;
                this.BusquedaEvalsDerivadas();
            }
            else
            {
                //this.grbCanalAproCred.Visible = false;
                BusquedaTodos();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            if (chcBusCli.Checked)
            {
                Buscar();
            }

        }

        private void chcBusCli_CheckedChanged(object sender, EventArgs e)
        {
            conBusCli.Enabled = chcBusCli.Checked;

            chcBusFecSol.CheckedChanged -= chcBusFecSol_CheckedChanged;
            chcBusMonto.CheckedChanged -= chcBusMonto_CheckedChanged;

            chcBusFecSol.Enabled = !chcBusCli.Checked;
            chcBusMonto.Enabled = !chcBusCli.Checked;
            chcBusFecSol.Checked = false;
            chcBusMonto.Checked = false;

            grbBusFecSol.Enabled = false;
            grbBusMontoSol.Enabled = false;

            chcBusFecSol.CheckedChanged += chcBusFecSol_CheckedChanged;
            chcBusMonto.CheckedChanged += chcBusMonto_CheckedChanged;

        }

        private void chcBusFecSol_CheckedChanged(object sender, EventArgs e)
        {
            grbBusFecSol.Enabled = chcBusFecSol.Checked;
        }

        private void chcBusMonto_CheckedChanged(object sender, EventArgs e)
        {
            grbBusMontoSol.Enabled = chcBusMonto.Checked;
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox == null)
                return;

            decimal nMonto = 0M;
            decimal.TryParse(txtBox.Text.Trim(), out nMonto);
            txtBox.Text = nMonto.ToString("#,0.00");
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dtgEvalCli.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se a seleccionado ningun registro.", cTituloMsjes, MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                return;
            }
            string xmlCredDevolver = String.Empty;
            if (MultiSeleccion)
            {
                var lstSeleccionados = dtgEvalCli.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["lSeleccion"].Value)).ToList();
                if (!lstSeleccionados.Any())
                {
                    MessageBox.Show("No se a seleccionado ningun registro", cTituloMsjes, MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                LstEvalCredComites = new List<clsEvalCredComite>();
                foreach (var row in lstSeleccionados)
                {
                    LstEvalCredComites.Add((clsEvalCredComite)row.DataBoundItem);
                }
            }
            else
            {
                if (dtgEvalCli.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No se a seleccionado ningun registro", cTituloMsjes, MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                LstEvalCredComites = new List<clsEvalCredComite>();
                LstEvalCredComites.Add((clsEvalCredComite)dtgEvalCli.SelectedRows[0].DataBoundItem);
            }

            xmlCredDevolver = LstEvalCredComites.GetXml();
            clsDBResp objDbResp = new clsCNEvalCred().CNDevolverEvalCred(xmlCredDevolver);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            BusquedaTodos();
        }

        #endregion

        #region Metodos

        public frmBusEvalCli()
        {
            MultiSeleccion = false;
            InitializeComponent();

            conBusCli.BorderStyle = BorderStyle.None;
            nAccion = AGREGAR_EVAL;
        }

        public frmBusEvalCli(int _nAccion, int nModo = 0)
        {
            MultiSeleccion = false;
            InitializeComponent();

            conBusCli.BorderStyle = BorderStyle.None;
            nAccion = _nAccion;
            this.nModo = nModo;

            if (this.nModo == 1 || this.nModo == 2)
            {
                this.grbBase1.Visible = false;
            }
            else
            {
               // this.grbCanalAproCred.Visible = false;
            }

            if (nAccion == frmBusEvalCli.AGREGAR_EVAL)
            {
                btnDevolver.Visible = false;
                btnAceptar.Visible = true;
            }
            else
            {
                btnDevolver.Visible = true;
                btnAceptar.Visible = false;
            }
        }

        private void Aceptar()
        {
            if (MultiSeleccion)
            {
                var lstSeleccionados = dtgEvalCli.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["lSeleccion"].Value)).ToList();
                if (!lstSeleccionados.Any())
                {
                    MessageBox.Show("No se a seleccionado ningun registro", cTituloMsjes, MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                LstEvalCredComites = new List<clsEvalCredComite>();
                foreach (var row in lstSeleccionados)
                {
                    LstEvalCredComites.Add((clsEvalCredComite)row.DataBoundItem);
                }
            }
            else
            {
                if (dtgEvalCli.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No se a seleccionado ningun registro", cTituloMsjes, MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                LstEvalCredComites = new List<clsEvalCredComite>();
                LstEvalCredComites.Add((clsEvalCredComite)dtgEvalCli.SelectedRows[0].DataBoundItem);
            }

            this.Dispose();
        }

        private void Buscar()
        {
            int idCli = 0;
            decimal nMontoIni = 0M;
            decimal nMontoFin = 0M;
            int idMoneda = 0;

            if (!chcBusCli.Checked && !chcBusFecSol.Checked && !chcBusMonto.Checked)
            {
                MessageBox.Show("Seleccione una opción de búsqueda.", cTituloMsjes,
                                                                    MessageBoxButtons.OK,
                                                                    MessageBoxIcon.Warning);
                return;
            }

            if (chcBusCli.Checked && conBusCli.idCli == 0)
            {
                MessageBox.Show("Seleccione un cliente.", cTituloMsjes,
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Warning);
                return;
            }

            if (chcBusFecSol.Checked && (dtpFecIni.Value > dtpFecFin.Value))
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha final.", cTituloMsjes,
                                                                                        MessageBoxButtons.OK,
                                                                                        MessageBoxIcon.Warning);
                return;
            }

            if (chcBusMonto.Checked && !(decimal.TryParse(txtMontoIni.Text.Trim(), out nMontoIni) &&
                                            decimal.TryParse(txtMontoFin.Text.Trim(), out nMontoFin)))
            {
                MessageBox.Show("Ingrese montos válidos.", cTituloMsjes,
                                                            MessageBoxButtons.OK,
                                                            MessageBoxIcon.Warning);
                return;
            }

            idCli = chcBusCli.Checked ? conBusCli.idCli : 0;
            DateTime dFecIni = chcBusFecSol.Checked ? dtpFecIni.Value.Date : (DateTime)SqlDateTime.MinValue;
            DateTime dFecFin = chcBusFecSol.Checked ? dtpFecFin.Value.Date : (DateTime)SqlDateTime.MaxValue;

            nMontoIni = chcBusMonto.Checked ? nMontoIni : 0;
            nMontoFin = chcBusMonto.Checked ? nMontoFin : 999999.99M;


            List<clsEvalCredComite> lstEvalCred = new clsCNEvalCred().CNGetEvalCredCli(idCli: idCli,
                                                                                        dFecIni: dFecIni,
                                                                                        dFecFin: dFecFin,
                                                                                        nMontoMin: nMontoIni,
                                                                                        nMontoMax: nMontoFin,
                                                                                        idMoneda: 0,
                                                                                        idAgencia: clsVarGlobal.nIdAgencia,
                                                                                        idPerfil: clsVarGlobal.PerfilUsu.idPerfil,
                                                                                        idUsuario: clsVarGlobal.User.idUsuario,
                                                                                        nModo: this.nModo);
            dtgEvalCli.DataSource = lstEvalCred.ToList();

        }

        private void BusquedaTodos()
        {
            int idCli = 0;
            DateTime dFecIni = (DateTime)SqlDateTime.MinValue;
            DateTime dFecFin = (DateTime)SqlDateTime.MaxValue;

            decimal nMontoIni = 0;
            decimal nMontoFin = 999999.99M;

            List<clsEvalCredComite> lstEvalCred = new clsCNEvalCred().CNGetEvalCredCli(idCli: idCli,
                                                                                        dFecIni: dFecIni,
                                                                                        dFecFin: dFecFin,
                                                                                        nMontoMin: nMontoIni,
                                                                                        nMontoMax: nMontoFin,
                                                                                        idMoneda: 0,
                                                                                        idAgencia: clsVarGlobal.nIdAgencia,
                                                                                        idPerfil: clsVarGlobal.PerfilUsu.idPerfil,
                                                                                        idUsuario: clsVarGlobal.User.idUsuario);
            dtgEvalCli.DataSource = lstEvalCred.ToList();
        }

        private void BusquedaEvalsDerivadas()
        {
            int idCli = 0;
            DateTime dFecIni = (DateTime)SqlDateTime.MinValue;
            DateTime dFecFin = (DateTime)SqlDateTime.MaxValue;
            this.idCanalAproCred = Convert.ToInt32(this.cboCanalAproCred.SelectedValue);
            this.cCanalAproCred = this.cboCanalAproCred.Text;


            decimal nMontoIni = 0;
            decimal nMontoFin = 999999.99M;

            List<clsEvalCredComite> lstEvalCred = new clsCNEvalCred().CNGetEvalCredCli(idCli: idCli,
                                                                                        dFecIni: dFecIni,
                                                                                        dFecFin: dFecFin,
                                                                                        nMontoMin: nMontoIni,
                                                                                        nMontoMax: nMontoFin,
                                                                                        idMoneda: 0,
                                                                                        idAgencia: clsVarGlobal.nIdAgencia,
                                                                                        idPerfil: clsVarGlobal.PerfilUsu.idPerfil,
                                                                                        idUsuario: clsVarGlobal.User.idUsuario,
                                                                                        nModo: this.nModo,
                                                                                        idCanalAproCred: this.idCanalAproCred);

            dtgEvalCli.DataSource = lstEvalCred.ToList();
        }

        private void FormatoGrid()
        {
            dtgEvalCli.AutoGenerateColumns = false;
            dtgEvalCli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            lSeleccion.Visible = MultiSeleccion;
            lSeleccion.Width = 20;
            idEval.Width = 50;
            idSolicitud.Width = 50;
            cNombre.Width = 200;
            cAsesor.Width = 200;
            nMontoSol.Width = 80;
            cMoneda.Width = 120;
            cEstSol.Width = 150;
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn();
            {
                btnDetail.Name = "btnVerMotDevol";
                btnDetail.HeaderText = "Mot. Devol";
                btnDetail.Text = "VER";
                btnDetail.UseColumnTextForButtonValue = true;
                btnDetail.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDetail.FlatStyle = FlatStyle.Standard;
                btnDetail.CellTemplate.Style.BackColor = Color.Honeydew;
                btnDetail.DisplayIndex = 5;
                //btnAdd.Visible = !readOnly;
                dtgEvalCli.Columns.Add(btnDetail);
            }
        }

        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.LstEvalCredComites = null;
            this.Close();
        }

        private void btnBuscarPorCanal_Click(object sender, EventArgs e)
        {
            BusquedaEvalsDerivadas();
        }

        private void dtgEvalCli_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numero = dtgEvalCli.Columns["btnVerMotDevol"].Index;
            if (dtgEvalCli.CurrentCell.ColumnIndex.Equals(numero))
            {
                int IdSolicitud = Convert.ToInt32(dtgEvalCli.Rows[e.RowIndex].Cells[3].Value);
                frmDevSolicitud FrmDevolverSolicitud = new frmDevSolicitud(IdSolicitud);
                FrmDevolverSolicitud.lLectura = true;
                FrmDevolverSolicitud.lDevolucion = false;
                FrmDevolverSolicitud.ShowDialog();

            }
        }

    }
}

