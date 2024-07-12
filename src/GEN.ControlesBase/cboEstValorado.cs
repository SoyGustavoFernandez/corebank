using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboEstValorado : cboBase
    {
        public cboEstValorado()
        {
            InitializeComponent();
        }

        public cboEstValorado(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            clsCNEstValorado ListaEstValorado = new clsCNEstValorado();
            DataTable dt = ListaEstValorado.CNEstValorado();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idEstadoVal"].ToString();
            this.DisplayMember = dt.Columns["cEstadoVal"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void ListaEstadosOP ()
        {
          
      
            clsCNEstValorado ListaEstValorado = new clsCNEstValorado();
            DataTable dt = ListaEstValorado.CNEstValoradoOP();
         
            DataRow row = dt.NewRow();
            row["idEstadoVal"] = 0;
            row["cEstadoVal"] = "TODOS";
            dt.Rows.Add(row);

            this.DataSource = dt;
            this.ValueMember = dt.Columns["idEstadoVal"].ToString();
            this.DisplayMember = dt.Columns["cEstadoVal"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

    }
}
