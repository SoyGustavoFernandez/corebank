using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DEP.CapaNegocio;
using System.Data;
namespace GEN.ControlesBase
{
    public partial class cboTipoBloqueo : cboBase
    {
        public cboTipoBloqueo()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoBloqueo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dtBloq = new clsCNAperturaCta().RetornaTiposBloqueo();
            this.DataSource = dtBloq;
            this.ValueMember = dtBloq.Columns["idBloqueo"].ToString();
            this.DisplayMember = dtBloq.Columns["cDescripcion"].ToString();
        }
    }
}
