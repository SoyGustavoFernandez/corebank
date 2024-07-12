using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboEstadoVigencia : cboBase
    {
        public cboEstadoVigencia()
        {
            InitializeComponent();
        }

        public cboEstadoVigencia(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Cargar();
        }
        public void Cargar()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            try
            {
                Dictionary<int, string> listEstados = new Dictionary<int, string>();
                listEstados.Add(-1, "TODOS");
                listEstados.Add(1, "ACTIVO");
                listEstados.Add(0, "DESACTIVADO");

                List<KeyValuePair<int, string>> listEstadosList = listEstados.ToList();

                this.DataSource = listEstadosList;
                this.DisplayMember = "Value";
                this.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
    }
}
