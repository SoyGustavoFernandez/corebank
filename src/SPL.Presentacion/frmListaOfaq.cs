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
    public partial class frmListaOfaq : frmBase
    {
        clsCNListaOfaq cnlistaofaq = new clsCNListaOfaq();
        public frmListaOfaq()
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
            if (!File.Exists(this.txtAddOfaq.Text))
            {
                MessageBox.Show("El archivo ADD no existe", "Validación lista ofaq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            lVal = true;
            return lVal;
        }
        
        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                this.Cursor = Cursors.WaitCursor;
                var dtListaOfaq = crearEstructuraLista();
                var dtDirListaOfaq = crearEstructuraDireccion();

                using (StreamReader strLeerListaOfaq = new StreamReader(txtSdnOfaq.Text))
                {
                    string Linea;
                    while ((Linea = strLeerListaOfaq.ReadLine()) != null)
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
                }


                using (StreamReader strLeerDirListaOfaq = new StreamReader(this.txtAddOfaq.Text))
                {
                    string Linea;
                    while ((Linea = strLeerDirListaOfaq.ReadLine()) != null)
                    {
                        string[] campos = Linea.Split('|');

                        if (campos.Length == 6)
                        {
                            dtDirListaOfaq.Rows.Add(Convert.ToInt32(campos[0]), campos[1].Replace(@"""", ""), campos[2].Replace(@"""", ""),
                                campos[3].Replace(@"""", ""), campos[4].Replace(@"""", ""), campos[5].Replace(@"""", ""));
                        }
                    }
                }

                if (dtListaOfaq.Rows.Count > 0)
                {
                    DataSet dsListaOfaq = new DataSet("dsListaOfaq");
                    dsListaOfaq.Tables.Add(dtListaOfaq);
                    string xmlListOfaq = dsListaOfaq.GetXml();

                    DataSet dsDirListaOfaq = new DataSet("dsDirListaOfaq");
                    dsDirListaOfaq.Tables.Add(dtDirListaOfaq);
                    string xmlDirListaOfaq = dsDirListaOfaq.GetXml();

                    cnlistaofaq.InsertarListaOfaq(xmlListOfaq, clsVarGlobal.User.idUsuario);
                    cnlistaofaq.InsertarDireccionListaOfaq(xmlDirListaOfaq, clsVarGlobal.User.idUsuario);

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

        private DataTable crearEstructuraDireccion()
        {
            DataTable dtDirListaOfaq = new DataTable("dtDirListaOfaq");

            dtDirListaOfaq.Columns.Add("idIdentificador", typeof(int));
            dtDirListaOfaq.Columns.Add("idDireccionOfaq", typeof(int));
            dtDirListaOfaq.Columns.Add("cDireccion", typeof(String));
            dtDirListaOfaq.Columns.Add("cCiudad", typeof(String));
            dtDirListaOfaq.Columns.Add("cPais", typeof(String));
            dtDirListaOfaq.Columns.Add("cRemarks", typeof(String));

            return dtDirListaOfaq;
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
                this.txtAddOfaq.Text = filedialog.FileName;
            }
            else
            {
                txtAddOfaq.Text = "";
            }
        }
    }
}
