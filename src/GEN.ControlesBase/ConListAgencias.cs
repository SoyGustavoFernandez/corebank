using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class ConListAgencias : UserControl
    {
        public ConListAgencias()
        {
            InitializeComponent();   
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTodos.Checked)
            {
                for (int i = 0; i < chklbAgencia1.Items.Count; i++)
                    chklbAgencia1.SetItemChecked(i, true);                    
            }
            else
            {
                for (int i = 0; i < chklbAgencia1.Items.Count; i++)//comienza en 1 para que al menos quede uno seleccionado
                    chklbAgencia1.SetItemChecked(i, false);
            }
        }

        public DataTable obtenerAgenciasSeleccionados()
        {
            DataTable dtResultado = new DataTable("dtAgencia");
            dtResultado.Columns.Add("idAgencia", typeof(int));

            foreach (DataRowView item in chklbAgencia1.CheckedItems)
            {
                DataRow dr = dtResultado.NewRow();
                dr["idAgencia"] = item["idAgencia"];
                dtResultado.Rows.Add(dr);
            }

            return dtResultado;
        }


    }
}
