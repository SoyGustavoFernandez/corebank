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
using GEN.CapaNegocio;
using GEN.ControlesBase;
using EntityLayer;
using System.Linq;
namespace GEN.ControlesBase
{
    public partial class frmBuscarDocsRiesgos : frmBase
    {
        DataTable dtDocumentos = new DataTable();//Contendrá los datos de los documentos que se adjuntarán al Informe(No se muestra al cliente)
        DataTable dtAuxDocs = new DataTable();//Tabla para mostrar los documentos que se van adjuntando(Se muestra al usuario - gridview)

        int nIdInformeRiesgos = 0; //Identificador del INFORME DE RIESGOS
        private string cDirectorioRiesgos = "riesgos";

        clsCNInformeRiesgos InformeRiesgos = new clsCNInformeRiesgos();


        public frmBuscarDocsRiesgos()
        {
            InitializeComponent();
        }
        
        public frmBuscarDocsRiesgos(int idInfRiesgos)
        {
            InitializeComponent();
            this.nIdInformeRiesgos = idInfRiesgos;
            dtDocumentos.Columns.Add("idDocInfRiesgo", typeof(int));
            dtDocumentos.Columns.Add("cNombreArchivo", typeof(string));
            dtDocumentos.Columns.Add("bArchivo", typeof(object));
            dtDocumentos.Columns.Add("lLeido", typeof(bool));


            dtAuxDocs.Columns.Add("idDocInfRiesgo", typeof(int));
            //dtAuxDocs.Columns.Add("IconoArchivo", typeof(Image));
            dtAuxDocs.Columns.Add("cNombreArchivo", typeof(string));
            dtAuxDocs.Columns.Add("cDireccionArchivo", typeof(string));
            dtAuxDocs.Columns.Add("lvigente", typeof(bool));
            //dtAuxDocs.Columns.Add("lLeido", typeof(bool));

            dtgDocumentos.DataSource = dtAuxDocs;
            dtgDocumentos.Columns["cNombreArchivo"].HeaderText = "Nombre del Archivo";

            
            MostrarInformeRiesgos();



        }
        
        private void MostrarInformeRiesgos()
        {
            LimpiarCampos();
 
            //Listado de documentos para mostrarlos en pantalla
            DataTable dtInfRiesgosDocumento = InformeRiesgos.BuscarDocInformeRiesgo(nIdInformeRiesgos);
            for (int i = 0; i < dtInfRiesgosDocumento.Rows.Count; i++)
            {
                //Verificar que el informe tenga documentos aduntados
                if (String.IsNullOrEmpty(dtInfRiesgosDocumento.Rows[i]["idDocInfRiesgo"].ToString()) == false)
                {
                    DataRow drAuxDoc = dtAuxDocs.NewRow();
                    drAuxDoc["cNombreArchivo"] = dtInfRiesgosDocumento.Rows[i]["cNombreArchivo"];
                    drAuxDoc["idDocInfRiesgo"] = dtInfRiesgosDocumento.Rows[i]["idDocInfRiesgo"];
                   // drAuxDoc["lLeido"] = dtInfRiesgosDocumento.Rows[i]["lLeido"];
                    dtAuxDocs.Rows.Add(drAuxDoc);

                    //Cargando la tabla que contendrá los archivos recuperados de la búsqueda
                    DataRow drDoc = this.dtDocumentos.NewRow();
                    drDoc["idDocInfRiesgo"] = dtInfRiesgosDocumento.Rows[i]["idDocInfRiesgo"];
                    drDoc["cNombreArchivo"] = dtInfRiesgosDocumento.Rows[i]["cNombreArchivo"];
                    drDoc["bArchivo"] = dtInfRiesgosDocumento.Rows[i]["bArchivo"];
                    //drDoc["lLeido"] = dtInfRiesgosDocumento.Rows[i]["lLeido"];
                    dtDocumentos.Rows.Add(drDoc);
                    
                }
            }

            dtgDocumentos.DataSource = dtAuxDocs;
            FormatoGridLectura();
            //Setear los campos como no vigentes
            for (int i = 0; i < dtAuxDocs.Rows.Count; i++)
            {
                dtAuxDocs.Rows[i]["lvigente"] = 1;
            }



            dtgDocumentos.ForeColor = Color.Gray;


            if (dtAuxDocs.Rows.Count > 0)
            {
                //Hacer que el sistema selecciona la primera fila : seleccionaremos  la celda de columna=1 fila=0 (visible en el dataGridView)
                dtgDocumentos.CurrentCell = dtgDocumentos[1, 0];
                //Hacer que en la pantalla se muestre seleccionado la primera columna
                dtgDocumentos.Rows[0].Selected = true;
            }
            
        }
    
  
        private void LimpiarCampos()
        {
            dtgDocumentos.DataSource = null;
            dtgDocumentos.Enabled = true;
            dtgDocumentos.ForeColor = Color.Black;

            dtAuxDocs.Clear();

            //DataTable para enviar datos a Base de Datos
            dtDocumentos.Clear();

            dtgDocumentos.DataSource = dtAuxDocs;

        }
        private void FormatoGridLectura()
        {
            foreach (DataGridViewColumn column in dtgDocumentos.Columns)
            {
                column.Visible = false;
            }

            //dtgDocumentos.Columns["IconoArchivo"].Visible = true;
            dtgDocumentos.Columns["idDocInfRiesgo"].Visible = true;
            dtgDocumentos.Columns["cNombreArchivo"].Visible = true;
            // dtgDocumentos.Columns["boton"].Visible = true;

            dtgDocumentos.Columns["idDocInfRiesgo"].HeaderText = "N° de Documento";
            dtgDocumentos.Columns["cNombreArchivo"].HeaderText = "Nombre del Archivo";
            //dtgDocumentos.Columns["boton"].HeaderText = "";

            //dtgDocumentos.Columns["idDocInfRiesgo"].Width = 50;
            //dtgDocumentos.Columns["cNombreArchivo"].Width = 50;


           // dtgDocumentos.Columns["boton"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Inmovilizar la clasificación del Grid
            //dtgDocumentos.Columns["cNombreArchivo"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }


        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (dtAuxDocs.Rows.Count > 0 && nIdInformeRiesgos != 0)
            {
                //Verificar que se estée haciendo click en el boton "Registrar Informe riesgo"
               // if (dtgDocumentos.CurrentCell.OwningColumn.Name.Equals("boton"))
               // {
                    int nfilaseleccionada = Convert.ToInt32(this.dtgDocumentos.CurrentRow.Index);
                    int nIdDocInfRiesgo = Convert.ToInt32(dtDocumentos.Rows[nfilaseleccionada]["idDocInfRiesgo"]);
                    if (nIdDocInfRiesgo == 0)
                    {
                        MessageBox.Show("El archivo todavía no se ha guardado", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    string[] cExtensionArchivo = dtAuxDocs.Rows[nfilaseleccionada]["cNombreArchivo"].ToString().Split('.');
                    string cExtencion = cExtensionArchivo[cExtensionArchivo.Length - 1].ToUpper();

                    if (Convert.ToInt32(dtAuxDocs.Rows[nfilaseleccionada]["idDocInfRiesgo"]) == nIdDocInfRiesgo)
                    {
                        string cDirectorio = String.Format("{0}\\{1}", clsVarGlobal.cRutPathApp, cDirectorioRiesgos);
                        string cNombreArchivo = dtAuxDocs.Rows[nfilaseleccionada]["cNombreArchivo"].ToString();
                        if (!Directory.Exists(cDirectorio))
                        {
                            Directory.CreateDirectory(cDirectorio);
                        }

                        string ruta = String.Format("{0}\\{1}", cDirectorio, cNombreArchivo);
                        FileInfo fileInfo = new FileInfo(ruta);
                        File.WriteAllBytes(ruta, (byte[])(this.dtDocumentos.Rows[nfilaseleccionada]["bArchivo"]));
                        frmVisualisarDocRiesgos frmVerDoc = new frmVisualisarDocRiesgos(cDirectorio, fileInfo.Name, fileInfo.Extension);
                        frmVerDoc.ShowDialog();
                        //Dispose();
                    }
                //}
            }
        }



       



    }
}
