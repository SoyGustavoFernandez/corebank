using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using CRE.CapaNegocio;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class cboPeriodoCredito : cboBase
    {
        public List<clsPeriodoCredito> lstPeriodoCredito = new List<clsPeriodoCredito>();

        public cboPeriodoCredito()
        {
            InitializeComponent();
        }

        public cboPeriodoCredito(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNTipoPeriodo objCNTipoPeriodo = new clsCNTipoPeriodo();
            this.lstPeriodoCredito.Clear();
            this.lstPeriodoCredito.AddRange(objCNTipoPeriodo.listarPeriodoCredito());

            this.DataSource = this.lstPeriodoCredito;
            this.ValueMember = "idPeriodoCredito";
            this.DisplayMember = "cPeriodoCredito";
            this.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        public int idPeriodoCredito
        {
            get
            {
                return Convert.ToInt32(this.SelectedValue);
            }
        }
        public clsPeriodoCredito obtenerSeleccion()
        {
            clsPeriodoCredito objPeriodoCredito = this.lstPeriodoCredito.Find(x => x.idPeriodoCredito == this.idPeriodoCredito);
            return (objPeriodoCredito != null) ? objPeriodoCredito : new clsPeriodoCredito();
        }
    }
}
