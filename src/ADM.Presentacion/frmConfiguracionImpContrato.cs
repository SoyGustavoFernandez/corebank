using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EntityLayer;
using GEN.ControlesBase;
using ADM.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace ADM.Presentacion
{
    public partial class frmConfiguracionImpContrato : frmBase
    {
        #region Variables
        clsCNConfiguracionImpresionContratos clsConfiguracion = new clsCNConfiguracionImpresionContratos();
        #endregion

        #region Metodos
        
        public frmConfiguracionImpContrato()
        {
            InitializeComponent();
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void seleccionarImagen()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog.FileName;

                    Image imagen_ = Image.FromFile(imagen);

                    pictureBox1.Image = resizeImage(imagen_, new Size(280, 70));
                    txtValor.Text = ConvertImageToBase64(imagen_);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido", "Cargado de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dtgFormatear()
        {
            foreach (DataGridViewColumn column in dtgVariables.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgVariables.Columns["idVariable"].HeaderText = "ID";
            dtgVariables.Columns["cLabel"].HeaderText = "VARIABLE";
            dtgVariables.Columns["cValor"].HeaderText = "VALOR";

            dtgVariables.Columns["idVariable"].Visible = true;
	        dtgVariables.Columns["cLabel"].Visible = true;
	        dtgVariables.Columns["cValor"].Visible = true;

            dtgVariables.Columns["idVariable"].FillWeight = 15;
	        dtgVariables.Columns["cLabel"].FillWeight = 60;
	        dtgVariables.Columns["cValor"].FillWeight = 25;

            dtgVariables.Columns["idVariable"].DisplayIndex = 0;
	        dtgVariables.Columns["cLabel"].DisplayIndex = 1;
	        dtgVariables.Columns["cValor"].DisplayIndex = 2;
        }

        private void listarConfiguracion()
        {
            DataTable dtConfiguracion = clsConfiguracion.listarConfiguracion();

            if(dtConfiguracion.Rows.Count > 0)
            {
                dtgVariables.DataSource = dtConfiguracion;
                dtgFormatear();
            }
        }

        private void limpiarControles()
        {
            grbFirma.Visible = false;
            grbVariables.Visible = true;
            btnCargarFile1.Visible = false;
            btnGenerar1.Visible = false;
            txtLabel.Enabled = false;
            txtValor.Enabled = false;
            btnGrabar1.Enabled = false;
            btnEditar1.Visible = true;
        }

        public string ConvertImageToBase64(Image file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.Save(memoryStream, file.RawFormat);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        public Image ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(ms, true);
            }
        }
        #endregion

        #region Funciones       
        private void btnCargarFile1_Click(object sender, EventArgs e)
        {
            seleccionarImagen();
        }

        private void frmConfiguracionImpContrato_Load(object sender, EventArgs e)
        {
            limpiarControles();
            listarConfiguracion();
        }

        private void dtgVariables_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgVariables.SelectedRows.Count > 0)
            {

                txtLabel.Text = dtgVariables.SelectedRows[0].Cells["cLabel"].Value.ToString();
                txtValor.Text = dtgVariables.SelectedRows[0].Cells["cValor"].Value.ToString();

                if (dtgVariables.SelectedRows[0].Cells["cVariable"].Value.ToString() == "cFirmaRepresentante"
                    || dtgVariables.SelectedRows[0].Cells["cVariable"].Value.ToString() == "cFirmaRepresentanteJO")
                {
                    grbFirma.Visible = true;
                    grbVariables.Visible = false;

                    if (dtgVariables.SelectedRows[0].Cells["cValor"].Value.ToString() != "")
                    {
                        Image imagen_ = ConvertBase64ToImage(dtgVariables.CurrentRow.Cells["cValor"].Value.ToString());
                        pictureBox1.Image = resizeImage(imagen_, new Size(280, 70));
                        btnGenerar1.Visible = true;
                    }
                    else
                    {
                        pictureBox1.Image = null;
                        btnGenerar1.Visible = false;
                    }
                }
                else 
                {
                    grbFirma.Visible = false;
                    grbVariables.Visible = true;
                    btnEditar1.Visible = true;
                    btnCargarFile1.Visible = false;
                    btnGenerar1.Visible = false;
                    txtValor.Enabled = false;
                }


            }
            
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            btnGrabar1.Enabled = true;
            if (dtgVariables.SelectedRows[0].Cells["cVariable"].Value.ToString() == "cFirmaRepresentante"
                || dtgVariables.SelectedRows[0].Cells["cVariable"].Value.ToString() == "cFirmaRepresentanteJO")
            {
                btnEditar1.Visible = false;
                btnCargarFile1.Visible = true;
                btnGenerar1.Visible = true;
            }
            else
            {
                btnEditar1.Visible = true;
                btnCargarFile1.Visible = false;
                btnGenerar1.Visible = false;
                txtValor.Enabled = true;
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (dtgVariables.SelectedRows[0].Cells["cVariable"].Value.ToString() != "cFirmaRepresentante"
                && dtgVariables.SelectedRows[0].Cells["cVariable"].Value.ToString() != "cFirmaRepresentanteJO")
            {
                string number = txtValor.Text;
                if (!number.All(char.IsDigit))
                {
                    MessageBox.Show("El valor a registrar debe ser un número entero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DataTable dtRespuesta = clsConfiguracion.actualizarVariableConfiguracion(Convert.ToInt32(dtgVariables.SelectedRows[0].Cells["idVariable"].Value.ToString()), txtValor.Text);
            limpiarControles();
            listarConfiguracion();
        }

        private void btnGenerar1_Click(object sender, EventArgs e)
        {

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            DataTable dtVariable = clsConfiguracion.obtenerVariableConfiguracion();
            foreach (DataColumn col in dtVariable.Columns)
            {
                col.ReadOnly = false;
            }
            dtVariable.Rows[0]["cFirmaRepresentante"] = txtValor.Text;
            DataTable dtIntervinientes = clsConfiguracion.retornaIntervinientesImprimirBlanco(dtVariable, 2);
            DataTable dtFiadores = dtIntervinientes.Clone();

            dtslist.Add(new ReportDataSource("dtIntervinientes", dtIntervinientes));
            dtslist.Add(new ReportDataSource("dtFiadores", dtFiadores));
            dtslist.Add(new ReportDataSource("dtTestigosRuego", clsConfiguracion.retornaTestigosRuego()));
            dtslist.Add(new ReportDataSource("dtVariables", dtVariable));

            paramlist.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idModulo", "2", false));
            paramlist.Add(new ReportParameter("idSolicitud", "0", false));
            paramlist.Add(new ReportParameter("nCodigo", "0", false));
            paramlist.Add(new ReportParameter("dFecha", "Lugar____________________Fecha____________de_______________del 202__", false));

            string reportpath = "rptContratoFirmas.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();           
        }
        #endregion
    }
}
