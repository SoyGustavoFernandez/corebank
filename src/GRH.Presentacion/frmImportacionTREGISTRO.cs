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
    public partial class frmImportacionTREGISTRO : frmBase
    {
        public frmImportacionTREGISTRO()
        {
            InitializeComponent();
        }

        private void frmImportacionTREGISTRO_Load(object sender, EventArgs e)
        {
            clsCNPLAME ListaREGISTROS = new clsCNPLAME();
            DataTable dtLisRegistros = ListaREGISTROS.ListarTREGISTRO();
            dtLisRegistros.Columns.Add("lEstado", typeof(Boolean));

            dtgT_REGISTRO.DataSource = dtLisRegistros;
            if (dtgT_REGISTRO.RowCount == 0)
            {
                btnProcesar.Enabled = false;
            }
            else
            {
                for (int n = 0; n < dtgT_REGISTRO.Rows.Count; n++)
                    dtgT_REGISTRO.Rows[n].Cells["lEstado"].Value = 0;
            }
            FormatoGridCli();

            dtgT_REGISTRO.ReadOnly = false;
            dtgT_REGISTRO.Columns["cNombreRegistro"].ReadOnly = true;
            dtgT_REGISTRO.Columns["lEstado"].ReadOnly = false;
        }
        private void FormatoGridCli()
        {
            dtgT_REGISTRO.Columns["idTRegistro"].Visible = false;
            dtgT_REGISTRO.Columns["cNombreRegistro"].HeaderText = "NOMBRE DEL REGISTRO";
            dtgT_REGISTRO.Columns["cNombreRegistro"].Width = 240;
            dtgT_REGISTRO.Columns["cNombreRegistro"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgT_REGISTRO.Columns["cNombreSP"].Visible = false;
            dtgT_REGISTRO.Columns["cExtension"].Visible = false;
            dtgT_REGISTRO.Columns["lEstado"].HeaderText = "CREAR";
            dtgT_REGISTRO.Columns["lEstado"].Width = 80;
            dtgT_REGISTRO.Columns["lEstado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //VALIDACIONES            
            if (txtRuta.Text == "")
            {
                MessageBox.Show("Debe seleccionar una Ruta", "Importación en T-REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //VALIDACION SI NO EXISTE NINGÚN PROCESO MARCADO
            Boolean lMarcarProceso = false;
            for (int n = 0; n < dtgT_REGISTRO.Rows.Count; n++)
            {
                if (Convert.ToInt32(dtgT_REGISTRO.Rows[n].Cells["lEstado"].Value) == 1)
                    lMarcarProceso = true;
            }
            if (lMarcarProceso == false)
            {
                MessageBox.Show("Debe seleccionar al menos un Registro para Procesar", "Importación en T-REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Int32 nRespuesta = (Int32)MessageBox.Show("¿Estás seguro de procesar?", "Importación en T-REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (nRespuesta != 6)
            {
                return;
            }

            string cNomSp, cCtr = "OK";
            int idPeriodo = Convert.ToInt32(cboPeriodoDeclaracion1.SelectedValue);
            string cRuta = folderBrowserDialog1.SelectedPath;

            string cNomArchivo = "";

            for (int i = 0; i < dtgT_REGISTRO.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgT_REGISTRO.Rows[i].Cells["lEstado"].Value) == true)
                {
                    cNomSp = dtgT_REGISTRO.Rows[i].Cells["cNombreSP"].Value.ToString();

                    clsCNPLAME ListaREGISTROS = new clsCNPLAME();
                    DataTable dtRetornoPro = ListaREGISTROS.ProcesRegistros(cNomSp, idPeriodo);

                    //Crear el Nombre del archivo
                    //-----------------------------------------------------------------------
                    if (i <= 11)
                        cNomArchivo = cRuta + "\\RP_" + clsVarApl.dicVarGen["cRUC"] + dtgT_REGISTRO.Rows[i].Cells["cExtension"].Value.ToString();
                    if (i == 12)
                        cNomArchivo = cRuta + "\\RP_" + clsVarApl.dicVarGen["cRUC"] + (clsVarGlobal.dFecSystem.Date).ToString("ddMMyyyy") + "_ALTA.txt";
                    if (i == 13)
                        cNomArchivo = cRuta + "\\RP_" + clsVarApl.dicVarGen["cRUC"] + (clsVarGlobal.dFecSystem.Date).ToString("ddMMyyyy") + "_BAJA.txt";

                    StreamWriter sr = new StreamWriter(@cNomArchivo);
                    string pcCadena = "";


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
                MessageBox.Show("Los Archivos han sido generados correctamente...", "Importación en T-REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
