using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using GRH.CapaNegocio;
using EntityLayer;
using System.IO;
using System.Threading.Tasks;


namespace GRH.Presentacion
{
    public partial class frmPlanillaMensualPLAME : frmBase
    {
        public frmPlanillaMensualPLAME()
        {
            InitializeComponent();
        }

        private void frmPlanillaMensualPLAME_Load(object sender, EventArgs e)
        {
            clsCNPLAME ListaPLAME = new clsCNPLAME();
            DataTable dtLisPlanillas = ListaPLAME.ListarPLAME();
            dtLisPlanillas.Columns.Add("lEstado", typeof(Boolean));

            dtgPlanillas.DataSource = dtLisPlanillas;
            if (dtgPlanillas.RowCount == 0)
            {
                btnProcesar.Enabled = false;
            }
            else
            {
                for (int n = 0; n < dtgPlanillas.Rows.Count; n++)
                    dtgPlanillas.Rows[n].Cells["lEstado"].Value = 0;
            }
            FormatoGridCli();

            dtgPlanillas.ReadOnly = false;
            dtgPlanillas.Columns["cNombrePlame"].ReadOnly = true;
            dtgPlanillas.Columns["lEstado"].ReadOnly = false;
        }
        private void FormatoGridCli()
        {
            dtgPlanillas.Columns["idPLAME"].Visible = false;
            dtgPlanillas.Columns["cNombrePlame"].HeaderText = "NOMBRE DE LA PLANTILLA";
            dtgPlanillas.Columns["cNombrePlame"].Width = 240;
            dtgPlanillas.Columns["cNombrePlame"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgPlanillas.Columns["cNombreSP"].Visible = false;
            dtgPlanillas.Columns["cExtension"].Visible = false;
            dtgPlanillas.Columns["lEstado"].HeaderText = "CREAR";
            dtgPlanillas.Columns["lEstado"].Width = 80;
            dtgPlanillas.Columns["lEstado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //VALIDACIONES
            if (cboPeriodoDeclaracion1.Text=="")
            {
                MessageBox.Show("Debe seleccionar el Periodo de Pago", "Planilla Mensual - PLAME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtRuta.Text == "")
            {
                MessageBox.Show("Debe seleccionar una Ruta", "Planilla Mensual - PLAME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboPeriodoDeclaracion1.Text.ToString().Length!=7)
            {
                MessageBox.Show("El Formato del periódo no es válido (Formato: yyyy-mm)", "Planilla Mensual - PLAME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //VALIDACION SI NO EXISTE NINGÚN PROCESO MARCADO
            Boolean lMarcarProceso = false;
            for (int n = 0; n < dtgPlanillas.Rows.Count; n++)
            {
                if (Convert.ToInt32(dtgPlanillas.Rows[n].Cells["lEstado"].Value) == 1)
                    lMarcarProceso = true;
            }
            if (lMarcarProceso == false)
            {
                MessageBox.Show("Debe seleccionar al menos una Planilla para Procesar", "Planilla Mensual - PLAME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            Int32 nRespuesta = (Int32)MessageBox.Show("¿Estás seguro de procesar?", "Planilla Mensual - PLAME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (nRespuesta != 6)
            {
                return;
            }

            string cNomSp, cCtr = "OK";
            int idPeriodo = Convert.ToInt32(cboPeriodoDeclaracion1.SelectedValue);
            string cRuta = folderBrowserDialog1.SelectedPath;

            string cNomArc;

            for (int i = 0; i < dtgPlanillas.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgPlanillas.Rows[i].Cells["lEstado"].Value) == true)
                {                    
                    cNomSp = dtgPlanillas.Rows[i].Cells["cNombreSP"].Value.ToString();
                    
                    clsCNPLAME ListaPLAME = new clsCNPLAME();
                    DataTable dtRetornoPro = ListaPLAME.ProcesPlanillas(cNomSp, idPeriodo);

                   
                    //Crear el Nombre del archivo
                    //-----------------------------------------------------------------------
                    cNomArc = cRuta + "\\0601" +
                                cboPeriodoDeclaracion1.Text.ToString().Substring(0, 4) +
                                cboPeriodoDeclaracion1.Text.ToString().Substring(5, 2) +
                                clsVarApl.dicVarGen["cRUC"] + dtgPlanillas.Rows[i].Cells["cExtension"].Value.ToString();

                    StreamWriter sr = new StreamWriter(@cNomArc);
                    string pcCadena="";


                    //Añadir el contenido al archivo
                    //-----------------------------------------------------------------------
                    for (int j = 0; j < dtRetornoPro.Rows.Count; j++)
                    {
                        pcCadena = (Convert.ToString(dtRetornoPro.Rows[j]["FilaDatos"]));
                        sr.WriteLine(pcCadena);
                    }
                    sr.Close();
                }

            }

            if (cCtr == "OK")
            {
                MessageBox.Show("Los Archivos han sido generados correctamente...", "Planilla Mensual - PLAME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnProcesar.Enabled = true;
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtRuta.Text = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                txtRuta.Text = "";
            }
        }
    }
}
