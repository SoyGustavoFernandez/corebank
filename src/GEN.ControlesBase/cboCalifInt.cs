using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboCalifInt : cboBase
    {
        public cboCalifInt()
        {
            InitializeComponent();
            CargarClasificacion();
        }

        public cboCalifInt(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            CargarClasificacion();
        }

        public void CargarClasificacion()
        {
            DataTable dtData = new clsCNCalifInt().CNGetClasifInt();
            ValueMember = "idClasifInterna";
            DisplayMember = "cClasifInterna";
            DataSource = dtData;
            SelectedIndex = -1;
        }
    }
}
