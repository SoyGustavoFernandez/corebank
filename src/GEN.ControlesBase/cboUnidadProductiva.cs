using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
namespace GEN.ControlesBase
{
    public partial class cboUnidadProductiva : cboBase
    {
        public DataTable dtUnidadProductiva;
        public cboUnidadProductiva()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboUnidadProductiva(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void listarUnidadProductiva()
        {
            dtUnidadProductiva = (new clsCNEvalCred()).listarUnidadProductiva();
            
            this.DataSource = dtUnidadProductiva;
            this.ValueMember = dtUnidadProductiva.Columns["idUnidadProductiva"].ToString();
            this.DisplayMember = dtUnidadProductiva.Columns["cUnidadProductiva"].ToString();
        }
    }
}
