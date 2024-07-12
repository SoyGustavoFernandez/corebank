using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoDocumentoSustento : cboBase
    {
        public cboTipoDocumentoSustento()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboTipoDocumentoSustento(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargaDatos();
        }

        public void cargaDatos()
        {
            clsCNTipoDocumentoSustento clsTipoDoc = new clsCNTipoDocumentoSustento();
            DataTable dt = clsTipoDoc.listarTipoDocumentoSustento();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
