using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class ListViewEditable : ListView
    {
        #region Variables
        private ListViewItem li;
        private int X = 0;
        private int Y = 0;
        private string subItemText;
        private int subItemSelected = 0;
        private txtNumRea editBox = new txtNumRea();
        private TextBox editBox1 = new TextBox();
        public ComboBox cmbBox= new ComboBox();
        private decimal nActivo = 0.00M;
        private decimal nPasivo = 0.00M;
        private decimal nPatrimonio = 0.00M;
        private Point pLisview;
        private bool mCreating;
        private bool mReadOnly;
        #endregion 

        public ListViewEditable()
        {
            InitializeComponent();            

            cmbBox.Size = new System.Drawing.Size(0, 0);
            cmbBox.Location = new System.Drawing.Point(0, 0);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.cmbBox });
            cmbBox.SelectedIndexChanged += new System.EventHandler(this.CmbSelected);
            cmbBox.LostFocus += new System.EventHandler(this.CmbFocusOver);
            cmbBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbKeyPress);
            cmbBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            cmbBox.BackColor = Color.SkyBlue;
            cmbBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBox.Hide();

            
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.FullRowSelect = true;
            this.Name = "listView1";
            this.Size = new System.Drawing.Size(0, 0);
            this.TabIndex = 0;
            this.View = System.Windows.Forms.View.Details;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LisMouseDown);
            this.DoubleClick += new System.EventHandler(this.LisDoubleClick);
            this.GridLines = true;
            this.MouseUp += ListViewEditable_MouseUp;
            // 
            // columnHeader1
            // 
            

            editBox.Size = new System.Drawing.Size(0, 0);
            editBox.Location = new System.Drawing.Point(0, 0);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.editBox });
            editBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditOver);
            editBox.LostFocus += new System.EventHandler(this.FocusOver);
            editBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            editBox.BackColor = Color.LightYellow;
            editBox.BorderStyle = BorderStyle.Fixed3D;
            editBox.Hide();
            editBox.Text = "";
            editBox.nNumDecimales = 2;

            editBox1.Size = new System.Drawing.Size(0, 0);
            editBox1.Location = new System.Drawing.Point(0, 0);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.editBox1 });
            editBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditOver1);
            editBox1.LostFocus += new System.EventHandler(this.FocusOver1);
            editBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            editBox1.BackColor = Color.LightYellow;
            editBox1.BorderStyle = BorderStyle.Fixed3D;
            editBox1.Hide();
            editBox1.Text = "";           
        }

        #region Eventos
        private void FocusOver1(object sender, EventArgs e)
        {

            li.SubItems[subItemSelected].Text ="".PadLeft(((clsItemBalance)li.Tag).nNivel*2,' ') + editBox1.Text;
			clsItemBalance item = (clsItemBalance)li.Tag;
            item.cDesItem = editBox1.Text;
            li.Tag = item;

            editBox1.Hide();
        }

        private void EditOver1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                li.SubItems[subItemSelected].Text = "".PadLeft(((clsItemBalance)li.Tag).nNivel*2, ' ') +  editBox1.Text;
                editBox1.Hide();
            }

            if (e.KeyChar == 27)
            {
                editBox1.Hide();
            }
        }        

        private void ListViewEditable_MouseUp(object sender, MouseEventArgs e)
        {
            if (ReadOnly) return;
            switch (e.Button)
            {

                // Right mouse click
                case MouseButtons.Right:

                    pLisview = e.Location;
                    ContextMenu myContextMenu = new ContextMenu();

                    MenuItem menuQuitar = new MenuItem("Quitar");
                    MenuItem menuAgregar = new MenuItem("Agregar");


                    // Clear all previously added MenuItems.
                    myContextMenu.MenuItems.Clear();

                    myContextMenu.MenuItems.Add(menuQuitar);
                    myContextMenu.MenuItems.Add(menuAgregar);

                    if (this.SelectedItems.Count > 0)
                    {

                        foreach (ListViewItem item in this.SelectedItems)
                        {
                            myContextMenu.MenuItems[1].Visible = true;
                            myContextMenu.MenuItems[0].Visible = true;
                        }

                    }

                    myContextMenu.Show(this, this.PointToClient(Cursor.Position), LeftRightAlignment.Right);



                    menuQuitar.Click += new System.EventHandler(this.menuQuitar_Click);
                    menuAgregar.Click += new System.EventHandler(menuAgregar_Click);

                    break;

            }
        }

        private void menuAgregar_Click(object sender, EventArgs e)
        {
            List<ListViewItem> lisItems = new List<ListViewItem>();
            List<ListViewItem> lisItemsNext = new List<ListViewItem>();

            clsItemBalance itemblc = new clsItemBalance();
            ListViewItem lvselect = this.SelectedItems[0];
            clsItemBalance item = (clsItemBalance)lvselect.Tag;
            itemblc.idItemPadre = item.idItemPadre;
            itemblc.nNivel = item.nNivel;
            itemblc.lVigente = item.lVigente;
            itemblc.nMonto = 0.00M;

            if (itemblc.nNivel <= 6)
                return;

            int indexSel = lvselect.Index;

            if (indexSel>0)
            {
                for (int i = 0; i < indexSel+1; i++)
                {
                    lisItems.Add(this.Items[i]);
                }
            }
            for (int i = indexSel+1; i < this.Items.Count; i++)
            {
                lisItemsNext.Add(this.Items[i]);
            }
			ListViewItem lvitem = new ListViewItem();
            // lvitem1 =(ListViewItem)lvselect.Clone();

            itemblc.idItem = this.Items.Count + 10;
            itemblc.cDesItem = "";
            itemblc.nOrden = item.nOrden + 1;

            lvitem.SubItems.Add("");

            lvitem.SubItems[0].Text="";
            lvitem.SubItems[1].Text = "0.00";
            
            lvitem.Tag = itemblc;

            this.Items.Clear();
            this.Items.AddRange(lisItems.ToArray());
            this.Items.Add(lvitem);
            this.Items.AddRange(lisItemsNext.ToArray());
            this.Refresh();
            
        }

        private void menuQuitar_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.GetItemAt(pLisview.X, pLisview.Y);
            int idItem = ((clsItemBalance)item.Tag).idItemPadre;

            if (((clsItemBalance)item.Tag).nNivel <= 6)
                return;


            DialogResult result = MessageBox.Show("Desea eliminar el item?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result== DialogResult.OK)
            {
				((clsItemBalance)item.Tag).lVigente = 0;
                this.Items.Remove(item);
                this.Refresh();
                sumarItemPadre(idItem);
                TotalizarBalance();
                this.Refresh();
            }
            
        }
        
        private void CmbKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 27)
            {
                cmbBox.Hide();
            }
        }

        private void CmbSelected(object sender, EventArgs e)
        {
            int sel = cmbBox.SelectedIndex;
            if (sel >= 0)
            {
                string itemSel = cmbBox.Items[sel].ToString();
                li.SubItems[subItemSelected].Text = itemSel;
            }
        }

        private void CmbFocusOver(object sender, EventArgs e)
        {
            cmbBox.Hide();
        }

        private void EditOver(object sender, KeyPressEventArgs e)
        {
            if (editBox.SelectionLength > 0)
            {
                e.Handled = false;
                valNum2(e);
                return;
            }

            if (e.KeyChar == 8)
            {

                e.Handled = false;
                return;

            }
            valNum(e);             
        }

        private void FocusOver(object sender, EventArgs e)
        {
			if (!string.IsNullOrEmpty(editBox.Text))
            {
                decimal nMonto = Convert.ToDecimal(editBox.Text);
                li.SubItems[subItemSelected].Text = nMonto.ToString("##,##0.00");
            }
            else
            {
                li.SubItems[subItemSelected].Text = "0.00";
            }
            if (((clsItemBalance)li.Tag).idItem > 40)
            {
                ((clsItemBalance)li.Tag).nMonto = Convert.ToDecimal(editBox.Text);
            }

            editBox.Hide();
            int idItemPadre = ((clsItemBalance)li.Tag).idItemPadre;
            sumarItemPadre(idItemPadre);
            TotalizarBalance();
        }

        public void LisDoubleClick(object sender, EventArgs e)
        {
            if (ReadOnly)return;
            ListViewItem lvitem = this.SelectedItems[0];
            clsItemBalance itembalance = (clsItemBalance)lvitem.Tag;
            bool lIndHijos = false;

            foreach (ListViewItem item in this.Items)
            {
                if (((clsItemBalance)item.Tag).idItemPadre == itembalance.idItem)
                {
                    lIndHijos = true;
                    break;
                }
            }

            // Check the subitem clicked .
            int nStart = X;
            int spos = 0;
            int epos = this.Columns[0].Width;
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (nStart > spos && nStart < epos)
                {
                    subItemSelected = i;
                    break;
                }

                spos = epos;
                epos += this.Columns[i].Width;
            }

           // Console.WriteLine("SUB ITEM SELECTED = " + li.SubItems[subItemSelected].Text);
            subItemText = li.SubItems[subItemSelected].Text;

            string colName = this.Columns[subItemSelected].Text;

            #region Para combobox
            ////if (colName == "Continent")
            ////{
            ////    Rectangle r = new Rectangle(spos, li.Bounds.Y, epos, li.Bounds.Bottom);
            ////    cmbBox.Size = new System.Drawing.Size(epos - spos, li.Bounds.Bottom - li.Bounds.Top);
            ////    cmbBox.Location = new System.Drawing.Point(spos, li.Bounds.Y);
            ////    cmbBox.Show();
            ////    cmbBox.Text = subItemText;
            ////    cmbBox.SelectAll();
            ////    cmbBox.Focus();
            ////}
            #endregion

            if (colName == "Monto" && !lIndHijos && subItemText!="")
            {
                Rectangle r = new Rectangle(spos, li.Bounds.Y, epos, li.Bounds.Bottom);
                editBox.Size = new System.Drawing.Size(epos - spos, li.Bounds.Bottom - li.Bounds.Top);
                editBox.Location = new System.Drawing.Point(spos, li.Bounds.Y);
                editBox.Show();
                editBox.Text = subItemText;
                editBox.SelectAll();
                editBox.Focus();
            }
            if (colName == "Descripción" && !lIndHijos && subItemText == "")
            {
                Rectangle r = new Rectangle(spos, li.Bounds.Y, epos, li.Bounds.Bottom);
                editBox1.Size = new System.Drawing.Size(epos - spos, li.Bounds.Bottom - li.Bounds.Top);
                editBox1.Location = new System.Drawing.Point(spos, li.Bounds.Y);
                editBox1.Show();
                editBox1.Text = subItemText;
                editBox1.SelectAll();
                editBox1.Focus();
            }
        }

        public void LisMouseDown(object sender, MouseEventArgs e)
        {
            li = this.GetItemAt(e.X, e.Y);
            X = e.X;
            Y = e.Y;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            mCreating = true;
            base.OnHandleCreated(e);
            mCreating = false;
        }

        public bool ReadOnly
        {
            get { return mReadOnly; }
            set { mReadOnly = value; }
        }

        protected override void OnItemCheck(ItemCheckEventArgs e)
        {
            if (!mCreating && mReadOnly) e.NewValue = e.CurrentValue;
            base.OnItemCheck(e);
        }

        #endregion

        #region Metodos

        private void valNum(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                li.SubItems[subItemSelected].Text = editBox.Text;
                editBox.Hide();
            }

            if (e.KeyChar == 27)
            {
                editBox.Hide();
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {

                if (this.Text.IndexOf('.') > -1 && this.Text.Substring(this.Text.IndexOf(".")).Length > editBox.nNumDecimales)

                    e.Handled = true;

                else
                    e.Handled = false;
            }

            else
            {

                var fff = (from L in editBox.Text.ToString()

                           where L.ToString() == "."
                           select L).Count();
                if (fff <= 0 && e.KeyChar.ToString() == ".")

                    e.Handled = false;
                else

                    e.Handled = true;
            }
        }

        private void valNum2(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                li.SubItems[subItemSelected].Text = editBox.Text;
                editBox.Hide();
                editBox1.Hide();
            }

            if (e.KeyChar == 27)
            {
                editBox.Hide();
                editBox1.Hide();
            }
            if (e.KeyChar == 8)
            {

                e.Handled = false;
                return;

            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }

            else
            {

                var fff = (from L in editBox.Text.ToString()

                           where L.ToString() == "."
                           select L).Count();
                if (fff <= 0 && e.KeyChar.ToString() == ".")

                    e.Handled = false;
                else

                    e.Handled = true;
            }
        }

        public void sumarItemPadre(int idItemPadre)
        {
            ListViewItem itemPadre = null;

            foreach (ListViewItem item in this.Items)
            {
                if (((clsItemBalance)item.Tag).idItem == idItemPadre)
                {
                    itemPadre = item;
                }
            }

            if (itemPadre == null)
            {
                return;
            }
            itemPadre.SubItems[1].Text = "0.00";
            foreach (ListViewItem item in this.Items)
            {
                if (((clsItemBalance)itemPadre.Tag).idItem == ((clsItemBalance)item.Tag).idItemPadre)
                {
                    
                        itemPadre.SubItems[1].Text = (Convert.ToDecimal(itemPadre.SubItems[1].Text) +
                                                    Convert.ToDecimal(item.SubItems[1].Text)).ToString();
                    
                    sumarItemPadre(((clsItemBalance)itemPadre.Tag).idItemPadre);
                }
                clsItemBalance itemBal = (clsItemBalance)item.Tag;
                if (((clsItemBalance)item.Tag).idItem == 2)
                {
                    nActivo = Convert.ToDecimal(item.SubItems[1].Text);
                }

                if (((clsItemBalance)item.Tag).idItem == 22)
                {
                    nPasivo = Convert.ToDecimal(item.SubItems[1].Text);
                }

                if (((clsItemBalance)item.Tag).idItem == 37)
                {
                    nPatrimonio = Convert.ToDecimal(item.SubItems[1].Text);
                }
            }

            
        }

        public void TotalizarBalance()
        {
            foreach (ListViewItem item in this.Items)
            {
                if (((clsItemBalance)item.Tag).idItem == 1)
                {
                    item.SubItems[1].Text = (nActivo - nPasivo - nPatrimonio).ToString();
                    break;
                }
            }
        }

        #endregion

    }
}
