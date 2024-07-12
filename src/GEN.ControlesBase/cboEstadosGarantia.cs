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
    public partial class cboEstadosGarantia : cboBase
    {
        clsCNGarantia objgarantia = new clsCNGarantia();

        public cboEstadosGarantia()
        {
            InitializeComponent();
        }

        public cboEstadosGarantia(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            
            DataTable dt = objgarantia.listarEstadosGarantia();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idEstadoGarantia"].ToString();
            this.DisplayMember = dt.Columns["cEstadoGarantia"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void cargarDatos()
        {
            DataTable dt = objgarantia.listarEstadosGarantia();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idEstadoGarantia"].ToString();
            this.DisplayMember = dt.Columns["cEstadoGarantia"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void cargarTodos()
        {
            DataTable dt = objgarantia.listarEstadosGarantia();
            DataRow dr = dt.NewRow();
            dr["idEstadoGarantia"] = 0;
            dr["cEstadoGarantia"] = "** TODOS **";
            dt.Rows.Add(dr);

            this.DataSource = dt;
            this.ValueMember = dt.Columns["idEstadoGarantia"].ToString();
            this.DisplayMember = dt.Columns["cEstadoGarantia"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
