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
    public partial class cboTipoFolioExpediente : cboBase
    {
        clsCNControlExp CondicionExp = new clsCNControlExp();

        public cboTipoFolioExpediente()
        {
            InitializeComponent();
        }

        public cboTipoFolioExpediente(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DataSource = CondicionExp.CNTipoFolioExpediente();
            this.ValueMember = "idTipoFolioExp";
            this.DisplayMember = "cDescripTipoFolio";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
