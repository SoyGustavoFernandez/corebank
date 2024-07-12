using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboCalificacion : cboBase
    {
        clsCNCalificacion cncalificacion = new clsCNCalificacion();

        public cboCalificacion()
        {
            InitializeComponent();
        }

        public cboCalificacion(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cboCalifica();            
        }

        public void cboCalifica()
        {
            DataTable dtcalificacion = cncalificacion.listarCalificacion();
            this.DataSource = dtcalificacion;
            this.ValueMember = dtcalificacion.Columns[0].ToString();
            this.DisplayMember = dtcalificacion.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void cboCalificaTodos()
        {
            DataTable dtcalificacion = cncalificacion.listarCalificacion();
            DataRow dr1 = dtcalificacion.NewRow();

            dr1["idCalificacion"]       = -1;
            dr1["cCalificacion"]        = "-- TODOS --";
            dr1["lVigente"]             = 1;
            dr1["cCodigoCalificacion"]  = "9";

            dtcalificacion.Rows.InsertAt(dr1, 0);

            this.DataSource = dtcalificacion;
            this.ValueMember = dtcalificacion.Columns[0].ToString();
            this.DisplayMember = dtcalificacion.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

    }
}
