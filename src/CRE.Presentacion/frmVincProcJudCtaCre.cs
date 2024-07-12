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
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmVincProcJudCtaCre : frmBase
    {
        DataTable dtLstProcJud;
        DataTable dtCtasCredito;
        DataTable dtCtaProcJud;
        clsCNProcJud objProcJud = new clsCNProcJud();
        clsCNCredito Credito = new clsCNCredito();
        private bool lFlagValidar = true;

        public frmVincProcJudCtaCre()
        {
            InitializeComponent();
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCli.txtCodCli.Text))
            {
                MessageBox.Show("Elija un cliente primero", "Registro de Procesos Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataGridViewCheckBoxColumn chcVincular = new DataGridViewCheckBoxColumn();
            chcVincular.Name = "chcVincular";
            chcVincular.FalseValue = false;
            chcVincular.TrueValue = true;
            dtgCtaCred.Columns.Add(chcVincular);

            dtLstProcJud = objProcJud.BusLstProcJud(Convert.ToInt32(conBusCli.txtCodCli.Text));
            dtLstProcJud.DefaultView.RowFilter = ("lVinculado is null");
            dtCtasCredito = objProcJud.BusCtasCliente(Convert.ToInt32(conBusCli.txtCodCli.Text));
            dtgProcJud.DataSource = dtLstProcJud;
            dtgCtaCred.DataSource = dtCtasCredito;
            FormatoDataGridView();
            FormatoGridViewCtas();

            btn_Vincular.Enabled = true;
            btnCancelar.Enabled = true;
            conBusCli.btnBusCliente.Enabled = false;
        }

        private void FormatoDataGridView()
        {
            dtgProcJud.Columns["idProcJudicial"].Visible = true;
            dtgProcJud.Columns["cNroExpediente"].Visible = true;
            dtgProcJud.Columns["cJuzgado"].Visible = true;
            dtgProcJud.Columns["cNomJuez"].Visible = false;
            dtgProcJud.Columns["cNomSecretario"].Visible = false;
            dtgProcJud.Columns["cNomAbogIFI"].Visible = true;
            dtgProcJud.Columns["cTipoProcJud"].Visible = false;
            dtgProcJud.Columns["cTipoMedJud"].Visible = false;
            dtgProcJud.Columns["dFecRegExp"].Visible = false;
            dtgProcJud.Columns["dFecEntrAsesor"].Visible = false;
            dtgProcJud.Columns["lIndTerceria"].Visible = true;
            dtgProcJud.Columns["cApeNomDeman"].Visible = true;
            dtgProcJud.Columns["lVinculado"].Visible = false;
            dtgProcJud.Columns["lVigente"].Visible = false;

            dtgProcJud.Columns["idProcJudicial"].HeaderText = "Nro. Proceso";
            dtgProcJud.Columns["cNroExpediente"].HeaderText = "Nro. Expendiente";
            dtgProcJud.Columns["cJuzgado"].HeaderText = "Juzgado";
            dtgProcJud.Columns["cNomAbogIFI"].HeaderText = "Abogado";
            dtgProcJud.Columns["lIndTerceria"].HeaderText = "Es Terceria?";
            dtgProcJud.Columns["cApeNomDeman"].HeaderText = "Demandante";

            dtgProcJud.Columns["idProcJudicial"].FillWeight = 20;
            dtgProcJud.Columns["cNroExpediente"].FillWeight = 60;
            dtgProcJud.Columns["cJuzgado"].FillWeight = 40;
            dtgProcJud.Columns["cNomAbogIFI"].FillWeight = 60;
            dtgProcJud.Columns["lIndTerceria"].FillWeight = 20;
            dtgProcJud.Columns["cApeNomDeman"].FillWeight = 50;

            dtgProcJud.Columns["idProcJudicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void FormatoGridViewCtas()
        {
            dtgCtaCred.ReadOnly=false;

            dtgCtaCred.Columns["chcVincular"].ReadOnly = false;
            dtgCtaCred.Columns["idCuenta"].ReadOnly = true;
            dtgCtaCred.Columns["idSolCapturaCre"].ReadOnly = true;

            dtgCtaCred.Columns["chcVincular"].HeaderText = "Vincular?";
            dtgCtaCred.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgCtaCred.Columns["idSolCapturaCre"].HeaderText = "Nro. Solicitud";

            dtgCtaCred.Columns["chcVincular"].FillWeight = 20;
            dtgCtaCred.Columns["idCuenta"].FillWeight = 40;
            dtgCtaCred.Columns["idSolCapturaCre"].FillWeight = 40;          
        }

        private void dtgCtaCred_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCtaCred.CurrentCell is DataGridViewCheckBoxCell)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtgCtaCred.CurrentCell;

                bool flag = Convert.ToBoolean(checkbox.EditedFormattedValue);
                int idSol = Convert.ToInt32(dtgCtaCred.CurrentRow.Cells["idSolCapturaCre"].Value);

                foreach (DataGridViewRow Row in dtgCtaCred.Rows)
                {
                    if (Convert.ToInt32(Row.Cells["idSolCapturaCre"].Value) == idSol)
                    {
                        Row.Cells["chcVincular"].Value = flag;
                    }
                }

            }
        }

        private void btn_Vincular_Click(object sender, EventArgs e)
        {
            Validar();
            if (!lFlagValidar) return;

            FillDataTableToSave();
            DataSet dsCtaProcJud = new DataSet("dsCtaProcJud");
            dsCtaProcJud.Tables.Add(dtCtaProcJud);
            string xmlCtaProcJud = dsCtaProcJud.GetXml();

            dsCtaProcJud.Tables.Clear();

            DataTable result = objProcJud.VincProcJudCtaCred(xmlCtaProcJud);

            if (result.Rows[0]["idMsje"].ToString() == "0")
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Vincular Proceso Judicial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Vincular.Enabled = false;
                dtgCtaCred.ReadOnly = true;
                dtgProcJud.ReadOnly = true;
                btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Vincular Proceso Judicial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FillDataTableToSave()
        {
            int idProcJud = 0;
            idProcJud = Convert.ToInt32(dtgProcJud.SelectedRows[0].Cells["idProcJudicial"].Value);
            dtCtaProcJud = null;
            dtCtaProcJud = new DataTable();
            dtCtaProcJud.Columns.Add("idCtaCred",typeof(Int32));
            dtCtaProcJud.Columns.Add("idProcJudicial",typeof(Int32));
            dtCtaProcJud.Columns.Add("lVigente",typeof(Int32));
            
            foreach(DataGridViewRow Row in dtgCtaCred.Rows)
            {
                if(Convert.ToBoolean(Row.Cells["chcVincular"].Value))
                {
                    DataRow row = dtCtaProcJud.NewRow();
                    row["idCtaCred"] = Row.Cells["idCuenta"].Value;
                    row["lVigente"] = 1;
                    dtCtaProcJud.Rows.Add(row);
                }
            }

            dtCtaProcJud.Columns["idProcJudicial"].Expression = idProcJud.ToString();

            dtCtaProcJud.TableName = "dtCtaProcJud";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {      
            conBusCli.txtCodAge.Text = "";
            conBusCli.txtCodInst.Text = "";
            conBusCli.txtCodCli.Text = "";
            conBusCli.txtNroDoc.Text = "";
            conBusCli.txtNombre.Text = "";
            conBusCli.txtDireccion.Text = "";

            conBusCli.txtCodCli.Enabled = true;

            dtgProcJud.DataSource = null;
            dtgCtaCred.DataSource = null;

            dtgCtaCred.Columns.Clear();

            btn_Vincular.Enabled = false;
            btnCancelar.Enabled = false;
            conBusCli.btnBusCliente.Enabled = true;

        }

        private void frmVincProcJudCtaCre_Load(object sender, EventArgs e)
        {
            conBusCli.txtCodAge.Text = "";
            conBusCli.txtCodInst.Text = "";
            conBusCli.txtCodCli.Text = "";
            conBusCli.txtNroDoc.Text = "";
            conBusCli.txtNombre.Text = "";
            conBusCli.txtDireccion.Text = "";

            conBusCli.txtCodCli.Enabled = true;

            dtgProcJud.DataSource = null;
            dtgCtaCred.DataSource = null;

            btn_Vincular.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void Validar()
        {
            string Msje = "";
            lFlagValidar = true;
            int contador=0;
            
            if (dtgProcJud.SelectedRows.Count==0)
            {
                Msje += "Seleccione un proceso judicial para vincular.\n";
                lFlagValidar = false;
                dtgProcJud.Focus();
            }

            foreach (DataGridViewRow Row in dtgCtaCred.Rows)
            {
                if (Convert.ToBoolean(Row.Cells["chcVincular"].Value) == true)
                {
                    contador++;
                }
            }

            if (contador == 0)
            {
                Msje += "Seleccione al menos una cuenta para vincular.\n";
                lFlagValidar = false;
                dtgCtaCred.Focus();
            }

            if (!string.IsNullOrEmpty(Msje.Trim()))
            {
                MessageBox.Show(Msje, "Vincular Proceso Judicial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lFlagValidar = false;
            }
        }

    }
}
