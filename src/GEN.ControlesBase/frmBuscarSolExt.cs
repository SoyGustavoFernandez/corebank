using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class frmBuscarSolExt : frmBase
    {
        public int pidMod, pidKardex,pidSolExt;
        public string pidTipOpe,pcEstKardex;
        public int idKardexExtorno;
        public string cSustento=string.Empty;
        public frmBuscarSolExt()
        {
            InitializeComponent();
            
        }

        private void frmSolExtPendiente_Load(object sender, EventArgs e)
        {
            if (cSustento != "")
            {
                CargarDatosSolExtKardex(pidMod, pidTipOpe, idKardexExtorno);
            }
            else
            {
            CargarDatosSolExt(pidMod, pidTipOpe);  //Parametri 1 --> Id del Modulo, 2--> Tipo Operación del Módulo
            }
         
            FormatoGrid();
        }

        private void CargarDatosSolExt(int idModulo,string cTipOpe)
        { 
            clsCNAprobacion objExt = new clsCNAprobacion();
            DataTable tbApr = objExt.ListarAprobacionExtorno(clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario,
                                                       idModulo, cTipOpe);

            this.dtgSolExt.DataSource = tbApr;
        }

        private void CargarDatosSolExtKardex(int idModulo, string cTipOpe, int idKardexExtorno)
        {
            clsCNAprobacion objExt = new clsCNAprobacion();
            DataTable tbApr = objExt.ListarSolAprobadasExtPorKardex(clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario,
                                                       idModulo, cTipOpe, idKardexExtorno);

            this.dtgSolExt.DataSource = tbApr;
        }

        private void FormatoGrid()
        {
            this.dtgSolExt.Columns["cEstadoKardex"].Visible = false;
            this.dtgSolExt.Columns["idSolAproba"].HeaderText = "Solicitud";
            this.dtgSolExt.Columns["idSolAproba"].Width = 50;
            this.dtgSolExt.Columns["dFecAprSol"].HeaderText = "Fec.Aprobación";
            this.dtgSolExt.Columns["dFecAprSol"].Width = 70;
            this.dtgSolExt.Columns["IdKardex"].HeaderText = "Nro Operación";
            this.dtgSolExt.Columns["IdKardex"].Width = 60;
            this.dtgSolExt.Columns["cMoneda"].HeaderText = "Moneda";
            this.dtgSolExt.Columns["cMoneda"].Width = 60;
            this.dtgSolExt.Columns["nMontoOperacion"].HeaderText = "Monto Operación";
            this.dtgSolExt.Columns["nMontoOperacion"].Width = 60;
            this.dtgSolExt.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            this.dtgSolExt.Columns["cTipoOperacion"].Width = 140;
            
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if(this.dtgSolExt.SelectedRows.Count > 0)
            {
                clsCNAprobacion objExt = new clsCNAprobacion();
                int idSolAprobaAnular = Convert.ToInt32(dtgSolExt.Rows[dtgSolExt.SelectedCells[0].RowIndex].Cells["idSolAproba"].Value.ToString());

                string cOpinionAnulacion = String.Empty;
                bool lValida = false;
                frmAnulaSolAprobacionOpinion frmAnulacion = new frmAnulaSolAprobacionOpinion();
                frmAnulacion.ShowDialog();
                cOpinionAnulacion = frmAnulacion.cComentarioAprobador;
                lValida = frmAnulacion.lValidado;

                if (lValida)
                {
                    DialogResult drResultado = MessageBox.Show("¿Está seguro que desea Anular la solicitud de Extorno?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResultado == DialogResult.No)
                        return;

                    clsCNAprobacion objCNAprobacion = new clsCNAprobacion();
                    DataTable dtResultado = objCNAprobacion.CNAnularSolicitudAprobacion(idSolAprobaAnular, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, cOpinionAnulacion);

                    if (dtResultado.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
                        {
                            MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Anulación Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnAnular.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Anulación Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error durante la Anulación de la Solicitud de Extorno.", "Anulación Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }


                CargarDatosSolExt(pidMod, pidTipOpe);
                FormatoGrid();
            }
        }

        private void dtgSolExt_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgSolExt.SelectedRows.Count > 0)
            {
                clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable.In("lstTipoOpeAnular"));
                List<int> lstTipoOpeAnular = (objVarGen == null) ? new List<int>() : objVarGen.cValVar.Split(',').Select(Int32.Parse).ToList();
                List<int> lstTipoOperacion = pidTipOpe.Split(',').Select(Int32.Parse).ToList();

                if (lstTipoOpeAnular.Any(item => lstTipoOperacion.Contains(item)))
                {
                    btnAnular.Enabled = true;
                    btnAnular.Visible = true;
                }
                else
                {
                    btnAnular.Enabled = false;
                    btnAnular.Visible = false;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dtgSolExt.RowCount > 0)
            {
                pidKardex = Convert.ToInt32(dtgSolExt.Rows[dtgSolExt.SelectedCells[0].RowIndex].Cells["IdKardex"].Value.ToString());
                pidSolExt = Convert.ToInt32(dtgSolExt.Rows[dtgSolExt.SelectedCells[0].RowIndex].Cells["idSolAproba"].Value.ToString());
                pcEstKardex = dtgSolExt.Rows[dtgSolExt.SelectedCells[0].RowIndex].Cells["cEstadoKardex"].Value.ToString();
            }
            else
            {
                pidKardex = 0;
                pidSolExt = 0;
                pcEstKardex="";
            }

            this.Dispose();
        }

        private void dtgSolExt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAceptar.PerformClick();
            }
        }

        private void dtgSolExt_DoubleClick(object sender, EventArgs e)
        {
            this.btnAceptar.PerformClick();
        }
    }
}
