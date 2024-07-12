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
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmAsigProcJud : frmBase
    {
        DataTable dtLstProcAbogOri;
        DataTable dtLstProcAbogDest;
        DataTable dtReasigProcJud ;
        clsCNProcJud objProcJud = new clsCNProcJud();
        private bool lFlagValidar = true;

        public frmAsigProcJud()
        {
            InitializeComponent();
        }

        private void frmAsigProcJud_Load(object sender, EventArgs e)
        {
            Habilitar(1);
        }

        private void Habilitar(int nOpcion)
        {
            if (nOpcion == 1)
            {
                cboAbogOrig.SelectedIndex = -1;
                cboAbogDest.SelectedIndex = -1;
                cboAbogOrig.Enabled = true;
                cboAbogDest.Enabled = true;
                dtgProcJudAbogOrig.DataSource = null;
                dtgProcJudAbogDest.DataSource = null;
                chcProcNoVinc.Checked = false;
                chcProcNoVinc.Enabled = true;
                btnCancelar.Enabled = true;
                btnProcesar.Enabled = true;
            }
            else if (nOpcion == 2)
            {
                cboAbogOrig.Enabled = false;
                cboAbogDest.Enabled = false;
                dtgProcJudAbogOrig.ReadOnly = true;
                dtgProcJudAbogDest.ReadOnly = true;
                chcProcNoVinc.Enabled = false;
                btnCancelar.Enabled = true;
                btnProcesar.Enabled = false;
            }
        }

        private void cboAbogOrig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAbogOrig.SelectedIndex != -1)
            {
                if(Convert.ToInt16(cboAbogDest.SelectedValue) != Convert.ToInt16(cboAbogOrig.SelectedValue))
                {
                    dtgProcJudAbogOrig.Columns.Clear();
                    DataGridViewCheckBoxColumn chcReasignar = new DataGridViewCheckBoxColumn();
                    chcReasignar.Name = "chcReasignar";

                    dtgProcJudAbogOrig.Columns.Add(chcReasignar);

                    dtgProcJudAbogOrig.DataSource = null;
                    dtLstProcAbogOri = objProcJud.BusLstProcJudAsigAbog(Convert.ToInt32(cboAbogOrig.SelectedValue));
                    dtgProcJudAbogOrig.DataSource = dtLstProcAbogOri;
                    FormatearGridViewAbogOrig();
                }
                else
                {
                    MessageBox.Show("El Abogado origen no puede ser el mismo que el abogado de destino.", "Reasignacion de Procesos Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboAbogOrig.SelectedIndex = -1;
                    dtgProcJudAbogOrig.DataSource = null;
                }
            }
        }

        private void cboAbogDest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAbogDest.SelectedIndex != -1)
            {
                if (!chcProcNoVinc.Checked)
                {
                    if (Convert.ToInt16(cboAbogDest.SelectedValue) != Convert.ToInt16(cboAbogOrig.SelectedValue))
                    {
                        dtgProcJudAbogDest.DataSource = null;
                        dtLstProcAbogDest = objProcJud.BusLstProcJudAsigAbog(Convert.ToInt32(cboAbogDest.SelectedValue));
                        dtgProcJudAbogDest.DataSource = dtLstProcAbogDest;
                        FormatearGridViewAbogDest();
                    }
                    else
                    {
                        MessageBox.Show("El Abogado destino no puede ser el mismo que el abogado de origen.", "Reasignacion de Procesos Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboAbogDest.SelectedIndex = -1;
                        dtgProcJudAbogDest.DataSource = null;
                    }
                }
                else
                {
                    dtgProcJudAbogDest.DataSource = null;
                    dtLstProcAbogDest = objProcJud.BusLstProcJudAsigAbog(Convert.ToInt32(cboAbogDest.SelectedValue));
                    dtgProcJudAbogDest.DataSource = dtLstProcAbogDest;
                    FormatearGridViewAbogDest();
                }
            }
        
        }

        private void FormatearGridViewAbogOrig()
        {
            dtgProcJudAbogOrig.ReadOnly = false;

            dtgProcJudAbogOrig.Columns["idProcJudicial"].Visible = true;
            dtgProcJudAbogOrig.Columns["cNroExpediente"].Visible = false;
            dtgProcJudAbogOrig.Columns["cNombre"].Visible = true;
            dtgProcJudAbogOrig.Columns["idEstado"].Visible = false;
            dtgProcJudAbogOrig.Columns["lIndTerceria"].Visible = false;

            dtgProcJudAbogOrig.Columns["chcReasignar"].ReadOnly = false;
            dtgProcJudAbogOrig.Columns["idProcJudicial"].ReadOnly = true;
            dtgProcJudAbogOrig.Columns["cNombre"].ReadOnly = true;

            dtgProcJudAbogOrig.Columns["chcReasignar"].HeaderText = "Reasig.";
            dtgProcJudAbogOrig.Columns["idProcJudicial"].HeaderText = "Proc. Jud.";
            dtgProcJudAbogOrig.Columns["cNombre"].HeaderText = "Cliente";

            dtgProcJudAbogOrig.Columns["chcReasignar"].FillWeight = 45;
            dtgProcJudAbogOrig.Columns["idProcJudicial"].FillWeight = 40;
            dtgProcJudAbogOrig.Columns["cNombre"].FillWeight = 150;
        }

        private void FormatearGridViewAbogDest()
        {
            dtgProcJudAbogDest.ReadOnly = true;

            dtgProcJudAbogDest.Columns["idProcJudicial"].Visible = true;
            dtgProcJudAbogDest.Columns["cNroExpediente"].Visible = false;
            dtgProcJudAbogDest.Columns["cNombre"].Visible = true;
            dtgProcJudAbogDest.Columns["idEstado"].Visible = false;
            dtgProcJudAbogDest.Columns["lIndTerceria"].Visible = false;

            dtgProcJudAbogDest.Columns["idProcJudicial"].HeaderText = "Proc. Jud.";
            dtgProcJudAbogDest.Columns["cNombre"].HeaderText = "Cliente";

            dtgProcJudAbogDest.Columns["idProcJudicial"].FillWeight = 40;
            dtgProcJudAbogDest.Columns["cNombre"].FillWeight = 180;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            Validar();
            if (!lFlagValidar) return;

            FillDataTableToSave();
            DataSet dsReasigProcJud = new DataSet("dsReasigProcJud");
            dsReasigProcJud.Tables.Add(dtReasigProcJud);
            string xmlReasigProcJud = dsReasigProcJud.GetXml();

            dsReasigProcJud.Tables.Clear();

            DataTable result = objProcJud.ReasignarProcJud(xmlReasigProcJud);
            if (result.Rows[0]["idMsje"].ToString() == "0")
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro de Procesos Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (chcProcNoVinc.Checked)
                {
                    dtgProcJudAbogOrig.DataSource = null;
                    dtLstProcAbogOri = objProcJud.BusLstProcJudAsigAbog(0);
                    dtgProcJudAbogOrig.DataSource = dtLstProcAbogOri;
                    FormatearGridViewAbogOrig();
                }
                else
                {
                    dtgProcJudAbogOrig.DataSource = null;
                    dtLstProcAbogOri = objProcJud.BusLstProcJudAsigAbog(Convert.ToInt16(cboAbogOrig.SelectedValue));
                    dtgProcJudAbogOrig.DataSource = dtLstProcAbogOri;
                    FormatearGridViewAbogOrig();
                }
                dtgProcJudAbogDest.DataSource = null;
                dtLstProcAbogDest = objProcJud.BusLstProcJudAsigAbog(Convert.ToInt16(cboAbogDest.SelectedValue));
                dtgProcJudAbogDest.DataSource = dtLstProcAbogDest;
                FormatearGridViewAbogDest();

                Habilitar(2);
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro de Procesos Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FillDataTableToSave()
        {
            dtReasigProcJud = null;
            dtReasigProcJud = new DataTable();
            dtReasigProcJud.TableName = "dtReasigProcJud";
            dtReasigProcJud.Columns.Clear();
            dtReasigProcJud.Columns.Add("idProcJudicial",typeof(Int32));
            dtReasigProcJud.Columns.Add("idAbogOrig",typeof(Int32));
            dtReasigProcJud.Columns.Add("idAbogDest",typeof(Int32));
            dtReasigProcJud.Columns.Add("idUsuRegMod",typeof(Int32));
            dtReasigProcJud.Columns.Add("dFecRegMod",typeof(DateTime));


            foreach (DataGridViewRow row in dtgProcJudAbogOrig.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chcReasignar"].Value) == true)
                {
                    DataRow Fila = dtReasigProcJud.NewRow();
                    Fila["idProcJudicial"] = Convert.ToInt32(row.Cells["idProcJudicial"].Value);
                    if (!chcProcNoVinc.Checked)
                    {
                        Fila["idAbogOrig"] = Convert.ToInt16(cboAbogOrig.SelectedValue).ToString();
                    }
                    Fila["idAbogDest"] = Convert.ToInt16(cboAbogDest.SelectedValue).ToString();
                    Fila["idUsuRegMod"] = clsVarGlobal.User.idUsuario;
                    Fila["dFecRegMod"] = clsVarGlobal.dFecSystem.Date;
                    dtReasigProcJud.Rows.Add(Fila);
                }
            }		   

        }

        private void chcProcNoVinc_CheckedChanged(object sender, EventArgs e)
        {
            if (chcProcNoVinc.Checked)
            {
                lblAbogOrig.Visible = false;
                cboAbogOrig.Visible = false;

                
                dtgProcJudAbogOrig.DataSource = null;

                dtgProcJudAbogOrig.Columns.Clear();
                DataGridViewCheckBoxColumn chcReasignar = new DataGridViewCheckBoxColumn();
                chcReasignar.Name = "chcReasignar";

                dtgProcJudAbogOrig.Columns.Add(chcReasignar);

                dtLstProcAbogOri = objProcJud.BusLstProcJudAsigAbog(0);
                dtgProcJudAbogOrig.DataSource = dtLstProcAbogOri;
                FormatearGridViewAbogOrig();
            }
            else
            {
                lblAbogOrig.Visible = true;
                cboAbogOrig.Visible = true;
                cboAbogOrig.SelectedIndex = -1;
                dtgProcJudAbogOrig.DataSource = null;
                dtgProcJudAbogOrig.Columns.Clear();
            }
        }

        private void Validar()
        {
            string Msje = "";
            lFlagValidar = true;
            int cont = 0;

            if (!chcProcNoVinc.Checked)
            {
                if (cboAbogOrig.SelectedIndex == -1)
                {
                    Msje += "Seleccione el abogado de origen.\n";
                    lFlagValidar = false;
                    cboAbogOrig.Focus();
                }
            }

            if (cboAbogDest.SelectedIndex == -1)
            {
                Msje += "Seleccione el abogado de destino.\n";
                lFlagValidar = false;
                cboAbogDest.Focus();
            }

            if (dtgProcJudAbogOrig.RowCount ==0)
            {
                Msje += "No existen procesos para reasignar.\n";
                lFlagValidar = false;
                cboAbogDest.Focus();
            }

            foreach (DataGridViewRow row in dtgProcJudAbogOrig.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chcReasignar"].Value) == true)
                {
                    cont++;
                }
            }

            if (cont == 0)
            {
                Msje += "Selecciones al menos un proceso a reasignar.\n";
                lFlagValidar = false;
                cboAbogDest.Focus();
            }
            
            if (!string.IsNullOrEmpty(Msje.Trim()))
            {
                MessageBox.Show(Msje, "Asignacion Proceso Judicial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lFlagValidar = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Habilitar(1);
        }       

    }
}
