using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboMotReclasifCli : cboBase
    {
        public cboMotReclasifCli()
        {
            InitializeComponent();
        }

        public cboMotReclasifCli(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DataTable dtResult = new clsCNClasifCli().CNLstMotReclasifCli(); 
            this.DataSource = dtResult;
            this.DisplayMember = "cMotReclasifCli";
            this.ValueMember = "idMotReclasifCli";
        }
    }
}
