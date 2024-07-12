using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboCondDomicilio : cboBase
    {
        clsCNCondDomicilio objCondDomicilio = new clsCNCondDomicilio();
        public cboCondDomicilio()
        {
            InitializeComponent();
        }

        public cboCondDomicilio(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dtCondDomicilio = objCondDomicilio.CNListaCondDomicilio();
            this.DataSource = dtCondDomicilio;
            this.ValueMember = dtCondDomicilio.Columns["idCondDomicilio"].ToString();
            this.DisplayMember = dtCondDomicilio.Columns["cCondDomicilio"].ToString();
        }
    }
}
