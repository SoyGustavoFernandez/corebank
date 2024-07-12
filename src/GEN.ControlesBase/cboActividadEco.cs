using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CLI.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboActividadEco : cboBase
    {
        public cboActividadEco()
        {
            InitializeComponent();
        }

        public cboActividadEco(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            
        }
        public void CargarActivEconomica(Int32 idActivEco)
        {
            clsCNListaActivEco objActEco = new clsCNListaActivEco();
            DataTable dtbActEco = objActEco.ListaActividadEco(idActivEco);
            this.DataSource = dtbActEco;
            this.ValueMember = dtbActEco.Columns[0].ToString();
            this.DisplayMember = "cActividadCompuesto";
        }
    }
}
