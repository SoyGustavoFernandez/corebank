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
    public partial class cboVisitaEscala : cboBase
    {
        clsCNVisita cnVisita;
        public cboVisitaEscala()
        {
            InitializeComponent();
            cnVisita = new clsCNVisita();
        }

        public cboVisitaEscala(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cnVisita = new clsCNVisita();
            cargar(false);
        }
        public void cargar(Boolean lTodos)
        {
            DataTable dt = cnVisita.CNListaVisitaEscala(lTodos);
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }
    }
}
