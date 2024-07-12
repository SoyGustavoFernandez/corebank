using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class dtgBase :  DataGridView
    {
     
        public dtgBase()
        {
            InitializeComponent();
            ProEsp();
        }

        public dtgBase(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            ProEsp();
        }
        private void ProEsp()
        {
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.MultiSelect = false;
            this.ReadOnly = true;
            this.RowHeadersVisible = false;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
        }
    }
}
