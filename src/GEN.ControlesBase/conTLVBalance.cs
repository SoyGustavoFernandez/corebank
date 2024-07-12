using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class conTLVBalance : UserControl
    {
        clsCNBalanceEva objbalance = new clsCNBalanceEva();
        public conTLVBalance()
        {
            InitializeComponent();
        }
        
        void listViewEditable1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private void conTLVBalance_Load(object sender, EventArgs e)
        {
            
        }

        public void cargarPlantilla( int idPlantilla)
        {
            clsBalance balance = objbalance.retornarPlantilla(idPlantilla);
            ListViewItem lvitem;
            this.listViewEditable1.Items.Clear();
            foreach (var item in balance)
            {
                string[] s = new string[4];
                s[0] = item.cDesItem;
                s[1] = "0.00";

                lvitem = new ListViewItem(s);
                if (item.nNivel.In(1,3,6))
                {
                    lvitem.Font = new Font(listViewEditable1.Font, FontStyle.Bold);
                }

                if (item.nNivel.In(3))
                {
                    lvitem.SubItems[0].BackColor = Color.SkyBlue;
                }

                lvitem.Tag = item;

                this.listViewEditable1.Items.Add(lvitem);
            }
        }

        public void cargarBalance(int idBalance)
        {
            clslisDetalleBalance balance = new clsCNBalanceFueIng().retornaDetallBalance(idBalance);
            ListViewItem lvitem;
            this.listViewEditable1.Items.Clear();
            foreach (var item in balance)
            {
                string[] s = new string[4];
                s[0] = item.cDesItem;
                s[1] = item.nMonto.ToString();

                lvitem = new ListViewItem(s);
                if (item.nNivel.In(1, 3, 6))
                {
                    lvitem.Font = new Font(listViewEditable1.Font, FontStyle.Bold);
                }

                if (item.nNivel.In(3))
                {
                    lvitem.SubItems[0].BackColor = Color.Aqua;
                }

                lvitem.Tag = item;

                this.listViewEditable1.Items.Add(lvitem);
            }
        }
    }
}
