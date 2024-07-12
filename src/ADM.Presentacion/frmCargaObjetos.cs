using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;

namespace ADM.Presentacion
{
    public partial class frmCargaObjetos : frmBase
    {
        clsCNFormulario objform = new clsCNFormulario();
        clsFormulario form = new clsFormulario();
        clslisControl controles = new clslisControl();
        List<Type> listaForms = new List<Type>();
        List<string> listaReportes = new List<string>();
        Dictionary<string, Form> dictForm = new Dictionary<string, Form>();
        Dictionary<string, UserControl> dictUC = new Dictionary<string, UserControl>();

        public frmCargaObjetos()
        {
            InitializeComponent();
            btnProReportes.BackgroundImage = new GEN.BotonesBase.btnProcesar().BackgroundImage;
            btnFormularios.BackgroundImage = new GEN.BotonesBase.btnProcesar().BackgroundImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnProcesar1_Click(object sender, EventArgs e)
        {            
                        
        }

        //private void insertaControles(Control frmControl,int idModulo)
        //{
        //    controles.Clear();
        //    recorrerControles(frmControl);

        //    form.cFormulario = frmControl.Name;
        //    form.lisControles = controles;
        //    form.idTipoForm = 1;
        //    form.idModulo = idModulo;
            
        //    if (!string.IsNullOrEmpty(frmControl.Name))
        //    {
        //        objform.insertarControles(form);
        //    }            
        //}

        private void insertaControles(Type frmControlType, int idModulo)
        {
            controles.Clear();
            var listFields = frmControlType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            recorrerControles(listFields);

            form.cFormulario = frmControlType.Name;
            form.lisControles = controles;
            form.idTipoForm = 1;
            form.idModulo = idModulo;

            if (!string.IsNullOrEmpty(frmControlType.Name))
            {
                objform.insertarControles(form);
            }
        }

        //private void recorrerControles(Control frmControl)
        //{
        //    foreach (Control c in frmControl.Controls)
        //    {
        //        if (c.Name != "")
        //            controles.Add(new clsControl() { cControl = c.Name, control = c });

        //        if (c.Controls.Count > 0)
        //            recorrerControles(c);
        //    }
        //}

        private void recorrerControles(FieldInfo[] listFields)
        {

            foreach (FieldInfo info in listFields)
            {
                if (info.FieldType.IsSubclassOf(typeof(Control)) && info.FieldType != typeof(frmReporteLocal))
                {
                    //Control instanceControl = Activator.CreateInstance(info.FieldType) as Control;
                    controles.Add(new clsControl() { cControl = info.Name, control = null });
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            clsCNModulo cnmodulo = new clsCNModulo();

            var dtModulo = cnmodulo.LisModulo();

            foreach (DataRow item in dtModulo.Rows)
            {
                procesarControlesModulo(item["cComponente"].ToString(), (int)item["idModulo"]);
            }            
        }

        private void procesarControlesModulo(string cNombreDLL, int idModulo)
        {
            Assembly assembly = null;
            if (!File.Exists(clsVarGlobal.cRutPathApp + @"\" + cNombreDLL))
                return;

            assembly = Assembly.LoadFrom(cNombreDLL);

            listaForms.Clear();
            foreach (var item in assembly.GetTypes().ToList())
            {
                if (item.IsSubclassOf(typeof (frmBase)))
                listaForms.Add(item);
            }

            if (listaForms.Count <= 0)
                return;
            
            foreach (var type in listaForms)
            {
                string formName = type.AssemblyQualifiedName;
                if (!string.IsNullOrEmpty(formName))
                {
                    Type typeForm = Type.GetType(formName.Trim());
                    insertaControles(typeForm, idModulo);
                }
            }
            //for (int i = 0; i <= total; i++)
            //{

                    
            //        //Form frm;
            //        //if (!dictForm.TryGetValue(listaForms[i].FullName, out frm) || frm.IsDisposed)
            //        //{
            //        //    var frm1 = assembly.CreateInstance(listaForms[i].FullName);
            //        //    if (frm1 is Form)
            //        //    {
            //        //        insertaControles((Form)frm1, idModulo);
            //        //        ((Form)frm1).Dispose();
            //        //    }
            //        //}
            //}
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            conLoader1.Visible = false;
            conLoader1.Active = false;
            MessageBox.Show("Se completo la carga de formularios", "Carga de formularios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            btnSalir1.Enabled = true;
            btnProReportes.Enabled = true;
        }

        private void btnProReportes_Click(object sender, EventArgs e)
        {
            conLoader1.Visible = true;
            conLoader1.Active = true;
            btnProReportes.Enabled = false;
            btnSalir1.Enabled = false;
            backgroundWorker2.RunWorkerAsync();
        }

        private void btnFormularios_Click(object sender, EventArgs e)
        {
            conLoader1.Visible = true;
            conLoader1.Active = true;
            btnFormularios.Enabled = false;
            btnSalir1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcesarReportes("RPT.Presentacion.dll", 0);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            conLoader1.Visible = false;
            conLoader1.Active = false;           

            MessageBox.Show("Se completo la carga de reportes", "Carga de Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
      
            btnSalir1.Enabled = true;
        }


        private void ProcesarReportes(string cNombreDLL, int idModulo)
        {
            Assembly assembly = null;
            if (File.Exists(clsVarGlobal.cRutPathApp + @"\" + cNombreDLL))
            {
                assembly = Assembly.LoadFrom(cNombreDLL);
            }
            else
            {
                return;
            }

            foreach (var item in assembly.GetManifestResourceNames().Where(x => x.ToUpper().EndsWith("RDLC")).ToList())
            {
                    listaReportes.Add(item.Replace("RPT.Presentacion.","").Trim());
            }

            if (listaReportes.Count <= 0)
                return;

            int total = listaReportes.Count;

            foreach (var reporte in listaReportes)
            {
                insertaReportes(reporte);
            }
        }

        private void insertaReportes(string cReporte)
        {
            controles.Clear();

            controles.Add(new clsControl() { cControl = "btnImprimir",control=null});
            controles.Add(new clsControl() { cControl = "btnExportar", control = null });

            form.cFormulario = cReporte;
            form.lisControles = controles;
            form.idTipoForm = 2;
            form.idModulo = 0;

            objform.insertarControles(form);
        }

    }
}
