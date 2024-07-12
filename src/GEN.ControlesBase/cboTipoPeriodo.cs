using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoPeriodo : cboBase
    {
        private bool lDatosCargados = false;
        public cboTipoPeriodo()
        {
            InitializeComponent();
        }

        public cboTipoPeriodo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            if (this.lDatosCargados)
                return;

            clsCNTipoPeriodo TipoPerido = new clsCNTipoPeriodo();

            DataTable dt = TipoPerido.dtListaTipoPeriodo();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lDatosCargados = true;
        }
        public void cargarDatos()
        {
            if (this.lDatosCargados)
                return;

            clsCNTipoPeriodo TipoPerido = new clsCNTipoPeriodo();

            DataTable dt = TipoPerido.dtListaTipoPeriodo();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lDatosCargados = true;
        }
    }
}
