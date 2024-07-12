using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class ConLimitesOperativos : UserControl
    {
        private int _idUsuario ;
        private int _idAgencia ;

        public int IdUsuario
        {
            get { return _idUsuario; }
            set
            {
                _idUsuario = value;
                CargarLimitesAsesor(_idUsuario, _idAgencia);
            }
        }

        public int IdAgencia
        {
            get { return _idAgencia; }
            set
            {
                _idAgencia = value;
                CargarLimitesAsesor(_idUsuario, _idAgencia);
            }
        }

        public ConLimitesOperativos()
        {
            InitializeComponent();
        }

        private void ConLimitesOperativos_Load(object sender, EventArgs e)
        {
            if ( DesignMode )
                return;

            InitControl();
            IdUsuario = clsVarGlobal.User.idUsuario;
            IdAgencia = clsVarGlobal.nIdAgencia;
        }

        private void CargarLimitesAsesor(int idUsuario, int idAgencia)
        {
            if(_idUsuario == 0 || _idAgencia == 0)
                return;

            flpControles.Controls.Clear();
            DataTable dtData = new clsCNLimiteOperativCred().GetLimitesAsesor(idUsuario, idAgencia);
            foreach (DataRow row in dtData.Rows)
            {
                string cNombre = Convert.ToString(row["cLimiteOperativo"]);
                string cNombreColor = Convert.ToString(row["cColor"]);
                decimal nValor = Convert.ToDecimal(row["nValor"]);
                Color color = Color.FromName(cNombreColor);
                AddControlLimite(cNombre, color, nValor);
            }
        }

        private void AddControlLimite(string cNombreLimite, Color colorSemaforo, decimal nValor)
        {
            ConSemaforoLimOpe semaforo = new ConSemaforoLimOpe(cNombreLimite, colorSemaforo, nValor);

            flpControles.Controls.Add(semaforo);
            flpControles.SetFlowBreak(semaforo, true);
        }

        public void InitControl()
        {
            flpControles.Controls.Clear();
            _idUsuario = 0;
            _idAgencia = 0;
        }
    }
}
