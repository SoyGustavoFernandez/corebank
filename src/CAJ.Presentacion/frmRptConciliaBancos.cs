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
using System.IO;
using SPL.CapaNegocio;
using EntityLayer;

namespace SPL.Presentacion
{
    public partial class frmRptConciliaBancos : frmBase
    {
        clsCNListaOfaq cnlistaofaq = new clsCNListaOfaq();
        public frmRptConciliaBancos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EntityLayer.EventoFormulario.INICIO);
        }

        private bool validar()
        {
            bool lVal = false;

            if (!File.Exists(this.txtSdnOfaq.Text))
            {
                MessageBox.Show("El archivo SDN no existe", "Validación lista ofaq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }
            //if (!File.Exists(this.txtAddOfaq.Text))
            //{
            //    MessageBox.Show("El archivo ADD no existe", "Validación lista ofaq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return lVal;
            //}

            lVal = true;
            return lVal;
        }


        private void limpiarControles()
        {

        }

        private void habilitarControles()
        {
            
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                this.Cursor = Cursors.WaitCursor;
                var dtListaOfaq = crearEstructuraLista();

                using (StreamReader Leer = new StreamReader(txtSdnOfaq.Text))
                {
                    string Linea;
                    while ((Linea = Leer.ReadLine()) != null)
                    {
                        string[] campos = Linea.Split('|');

                        if (campos.Length == 12)
                        {
                            dtListaOfaq.Rows.Add(Convert.ToInt32(campos[0]), campos[1].Replace(@"""", ""), campos[2].Replace(@"""", ""),
                                campos[3].Replace(@"""", ""), campos[4].Replace(@"""", ""),
                                campos[5].Replace(@"""", ""), campos[6].Replace(@"""", ""),
                                campos[7].Replace(@"""", ""), campos[8].Replace(@"""", ""),
                                campos[9].Replace(@"""", ""), campos[10].Replace(@"""", ""), campos[11].Replace(@"""", ""));
                        }
                    }

                    if (dtListaOfaq.Rows.Count > 0)
                    {
                        DataSet dsListaOfaq = new DataSet("dsListaOfaq");
                        dsListaOfaq.Tables.Add(dtListaOfaq);
                        string xmlListOfaq = dsListaOfaq.GetXml();
                        cnlistaofaq.InsertarListaOfaq(xmlListOfaq, clsVarGlobal.User.idUsuario);
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Los datos se cargaron correctamente", "Carga de lista OFAQ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Error en la carga de datos", "Carga de lista OFAQ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private DataTable crearEstructuraLista()
        {
            DataTable dtListaOfaq = new DataTable("dtListaOfaq");

            dtListaOfaq.Columns.Add("idIdentificador", typeof(int));
            dtListaOfaq.Columns.Add("cNombre", typeof(String));
            dtListaOfaq.Columns.Add("cTipo", typeof(String));
            dtListaOfaq.Columns.Add("cPrograma", typeof(String));
            dtListaOfaq.Columns.Add("cCargo", typeof(String));
            dtListaOfaq.Columns.Add("cCall_Sign", typeof(String));
            dtListaOfaq.Columns.Add("cVess_type", typeof(String));
            dtListaOfaq.Columns.Add("cTonnage", typeof(String));
            dtListaOfaq.Columns.Add("cGRT", typeof(String));
            dtListaOfaq.Columns.Add("cVess_flag", typeof(String));
            dtListaOfaq.Columns.Add("cVess_owner", typeof(String));
            dtListaOfaq.Columns.Add("cRemarks", typeof(String));

            return dtListaOfaq;
        }

        private void btnCargarSdn_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Filter = "Tipo PIP (*.pip)|*.pip";
            filedialog.Multiselect = false;
            var result=filedialog.ShowDialog();
            if (result== DialogResult.OK)
            {
                txtSdnOfaq.Text = filedialog.FileName;
            }
            else
            {
                txtSdnOfaq.Text = "";
            }
            
        }

        private void btnAddOfaq_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Filter = "Tipo PIP (*.pip)|*.pip";
            filedialog.Multiselect = false;
            var result = filedialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //this.txtAddOfaq.Text = filedialog.FileName;
            }
            else
            {
                //txtAddOfaq.Text = "";
            }
        }
    }
}
