using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboEstadosAprobacion : cboBase
    {
        clsCNEstadosAprobacion cnEstados = new clsCNEstadosAprobacion();
        int TipoOperacion;
        public cboEstadosAprobacion()
        {
            InitializeComponent();
        }

        public cboEstadosAprobacion(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            getEstadosAprobacion(TipoOperacion);
        }

        public void getEstadosAprobacion(int TipoOperacion_)
        {
            TipoOperacion = TipoOperacion_;
            DataTable dt = cnEstados.getEstadosAprobacion(TipoOperacion);
            this.DataSource = dt;
            DataRow dr = dt.NewRow();
            dr["idEstadoAproba"] = 0;
            dr["cEstadoAproba"] = "TODOS";
            //dr["idPerfil"] = 0;
            dt.Rows.Add(dr);
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndex = -1;
        }

        
    }
}
