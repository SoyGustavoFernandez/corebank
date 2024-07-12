using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CRE.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboModDesemb : cboBase
    {
        public cboModDesemb()
        {
            InitializeComponent();
        }

        public cboModDesemb(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNModDesembolso ListaModaDese = new clsCNModDesembolso();

            DataTable tbModDes = ListaModaDese.ListaModDesem();
            this.DataSource = tbModDes;
            this.ValueMember = tbModDes.Columns[0].ToString();
            this.DisplayMember = tbModDes.Columns[1].ToString();
        }
    }
}
