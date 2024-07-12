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
    public partial class cboTipoExpediente : cboBase
    {
        clsCNControlExp ListaDetExp = new clsCNControlExp();
        DataTable dt;
        public cboTipoExpediente()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboTipoExpediente(IContainer container)
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            container.Add(this);
            InitializeComponent();
            dt = ListaDetExp.CNListaTipoExpediente();
            cboCargarOpcionTodos(false);
        }

        public void cboCargarOpcionTodos(Boolean lBol)
        {
            if (lBol)
            {
                DataRow dr = dt.NewRow();
                dr["idTipoOpeExp"] = 0;
                dr["cDescripcion"] = "**TODOS**";
                dt.Rows.InsertAt(dr, 0);
            }
            this.DataSource = dt;
            this.DisplayMember = "cDescripcion";
            this.ValueMember = "idTipoOpeExp";
        }
    }
}
