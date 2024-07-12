using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class cboTasadores : cboBase
    {
        public cboTasadores()
        {
            InitializeComponent();

            //cargarActivos();
        }

        public cboTasadores(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
           
            cargarActivos();
        }

        public void cargarTodos()
        {
            clsCNTasador objtasaddor = new clsCNTasador();
            List<clsTasador> lista = objtasaddor.listarTasador();
            ValueMember = "idTasador";
            DisplayMember = "cTasador";
            DataSource = lista;
        }

        public void cargarActivos()
        {
            clsCNTasador objtasaddor = new clsCNTasador();
            List<clsTasador> lista = objtasaddor.listarTasador();
            ValueMember = "idTasador";
            DisplayMember = "cTasador";
            DataSource = lista.Where(x => x.lVigente).ToList();
        }
    }
}
