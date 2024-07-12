using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.BotonesBase;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class btnAdministradorFiles : Boton
    {
        public int idSolicitud {get; set;}
        public bool lectura { get; set; }
        public int obligatorios { get; set; }
        public string msgObligatorios { get; set; }
        CRE.CapaNegocio.clsCNAdministracionFiles clsFiles = new CRE.CapaNegocio.clsCNAdministracionFiles();

        public btnAdministradorFiles()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.pdf;
            this.msgObligatorios = "Reportes Central de Riesgo: La Solicitud no tiene cargado todos los Reportes Obligatorios de las Centrales de Riesgo";
        }

        public btnAdministradorFiles(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.Click += btnAdministradorFiles_Click;
            this.BackgroundImage = Properties.Resources.pdf;
            this.msgObligatorios = "Reportes Central de Riesgo: La Solicitud no tiene cargado todos los Reportes Obligatorios de las Centrales de Riesgo";
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "Central Riesgos";
        }


        private void btnAdministradorFiles_Click(object sender, EventArgs e)
        {
            if (idSolicitud != 0)
            {
                frmAdministrarFiles frm = new frmAdministrarFiles(idSolicitud, lectura);
                frm.ShowDialog();
                obligatorios = frm.getObligatorios();
            }
            else
                MessageBox.Show("No hay una solicitud de crédito vinculada", "Carga de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void actualizarDatos()
        {
            DataTable res = clsFiles.ListarTiposDocumentosEvaluacion(idSolicitud);
            obligatorios = 1;
            foreach (DataRow r in res.Rows)
            {
                if(Convert.ToBoolean(r["lEstado"]) && r["cNombreDoc"].ToString() =="")
                    obligatorios = 0;
            }
        }

        public bool obligatoriosCompletos()
        {
            DataTable res = clsFiles.ListarTiposDocumentosEvaluacion(idSolicitud);
            //int obligatorios_ = 1;
            foreach (DataRow r in res.Rows)
            {
                if (Convert.ToBoolean(r["lEstado"]) && r["cNombreDoc"].ToString() == "")
                    //obligatorios_ = 0;
                    return false;
            }
            return true;
        }

    }
}
