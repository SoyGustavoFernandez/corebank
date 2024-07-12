using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;


namespace GEN.ControlesBase
{
    public partial class frmSolCreProducto : frmBase
    {
        public int idSolicitud { get; set; }
        public int idProducto { get; set; }
        public string cProductoCompleto { get; set; }
        public int idOperacion { get; set; }
        public string cIDsTipEvalCred { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public clsProductoCredSimp objProductoCredSimp;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<clsProductoCredSimp> lstProducto { get; set; }

        public clsCNSolicitud objCNSolicitud { get; set; }
        public frmSolCreProducto()
        {
            InitializeComponent();

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            conProducto.lBloquear3Niveles = true;
            conProducto.Invalidate();
            idSolicitud = 0;
            idProducto = 0;
            cProductoCompleto = String.Empty;
            idOperacion = 0;
            objProductoCredSimp = new clsProductoCredSimp();
            lstProducto = new List<clsProductoCredSimp>();
            objCNSolicitud = new clsCNSolicitud();
        }

        public void CargarDatos(int _idSolicitud, int _idProducto, clsProductoCredSimp _objProductoSol, string _cIDsTipEvalCred, int _idOperacion=0)
        {
            this.idSolicitud = _idSolicitud;
            this.idProducto = _idProducto;
            this.objProductoCredSimp = _objProductoSol;
            this.cIDsTipEvalCred = _cIDsTipEvalCred;
            this.idOperacion = _idOperacion;

            this.lstProducto = objCNSolicitud.CNRecuperarProductoSimpTipEval(cIDsTipEvalCred);
        }

        public void CargarDatosDefecto()
        {
            objProductoCredSimp = new clsProductoCredSimp();
            lstProducto = new List<clsProductoCredSimp>();
        }

        private bool Validar()
        {
            bool lValida = true;

            if(!conProducto.validarSeleccion())
            {
                lValida = false;
            }

            if(!lstProducto.Any(item => item.idSubProducto == conProducto.idSubproducto()) )
            {
                MessageBox.Show("El Producto seleccionado no esta permitido para este tipo de Evaluación", "Validación de Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lValida = false;
            }
            return lValida;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            
            List<clsProductoCredSimp> lstFiltro = lstProducto.Where(item => item.idSubProducto == conProducto.idSubproducto()).ToList();
            objProductoCredSimp = (lstFiltro.Count > 0) ? lstFiltro[0] : new clsProductoCredSimp();
            if(objProductoCredSimp.idSubProducto != 0)
            {
                idProducto = conProducto.idSubproducto();
                this.Dispose();
            }
        }

        private void frmSolCreProducto_Load(object sender, EventArgs e)
        {
            //CargarDatosDefecto();
            conProducto.lBloquear3Niveles = false;
            conProducto.lNivel = true;
            conProducto.cIDsTipEvalCred = cIDsTipEvalCred;
            conProducto.conProductoNivelTipEvalCred(1);
            conProducto.cargarProductos(1, idProducto, idOperacion);
        }
    }
}
