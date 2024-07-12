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
    public partial class cboOperacionCredito : cboBase
    {
        clsCNOperacionCredito OperCred = new clsCNOperacionCredito();
        public bool lDatosCargados = false;

        public int nValorSeleccionado
        {
            get
            {
                if (this.SelectedIndex >-1 && this.lDatosCargados)
                {
                    return Convert.ToInt32(this.SelectedValue);
                }
                return 0;
            }
        }

        public cboOperacionCredito()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboOperacionCredito(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ListarOperacionCredito(string cIdsOperacion = "0")
        {
            if (!this.lDatosCargados)
            {
                DataTable dtOperacion = OperCred.CNListarOperacionCredito(cIdsOperacion);
                this.DataSource = dtOperacion;
                this.ValueMember = dtOperacion.Columns["idOperacion"].ToString();
                this.DisplayMember = dtOperacion.Columns["cOperacion"].ToString();
                this.lDatosCargados = true;
            }
        }
    }
}
