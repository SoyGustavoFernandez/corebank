using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSG.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboUbicaVisita : cboBase
    {
        clsCNVisita cnVisita;
        public cboUbicaVisita()
        {
            InitializeComponent();
            cnVisita = new clsCNVisita();
        }

        public cboUbicaVisita(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cnVisita = new clsCNVisita();
            cargarUbicaVisita(false);
        }

        public void cargarUbicaVisita(Boolean lTodos)
        {
            DataTable dt = cnVisita.CNListaUbicaVisita(lTodos);
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }
    }
}
