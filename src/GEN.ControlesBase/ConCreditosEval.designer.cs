namespace GEN.ControlesBase
{
    partial class ConCreditosEval
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConCreditosEval));
            this.btnCargarDeudaRcc = new GEN.BotonesBase.btnBlanco();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.dtgCreInd = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnAgregaTarjetaCre = new GEN.BotonesBase.btnMiniAgregar();
            this.btnQuitaTarjetaCre = new GEN.BotonesBase.btnMiniQuitar();
            this.dtgCre = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreInd)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCre)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCargarDeudaRcc
            // 
            this.btnCargarDeudaRcc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargarDeudaRcc.Location = new System.Drawing.Point(649, 141);
            this.btnCargarDeudaRcc.Name = "btnCargarDeudaRcc";
            this.btnCargarDeudaRcc.Size = new System.Drawing.Size(60, 50);
            this.btnCargarDeudaRcc.TabIndex = 13;
            this.btnCargarDeudaRcc.Text = "Cargar Deudas";
            this.btnCargarDeudaRcc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargarDeudaRcc.UseVisualStyleBackColor = true;
            this.btnCargarDeudaRcc.Click += new System.EventHandler(this.btnCargarDeudaRcc_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnMiniAgregar1);
            this.grbBase2.Controls.Add(this.btnMiniQuitar1);
            this.grbBase2.Controls.Add(this.dtgCreInd);
            this.grbBase2.Location = new System.Drawing.Point(3, 126);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(640, 102);
            this.grbBase2.TabIndex = 18;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Deudas indirectas";
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(598, 15);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 9;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(598, 46);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 10;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // dtgCreInd
            // 
            this.dtgCreInd.AllowUserToAddRows = false;
            this.dtgCreInd.AllowUserToDeleteRows = false;
            this.dtgCreInd.AllowUserToResizeColumns = false;
            this.dtgCreInd.AllowUserToResizeRows = false;
            this.dtgCreInd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgCreInd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreInd.Location = new System.Drawing.Point(5, 15);
            this.dtgCreInd.MultiSelect = false;
            this.dtgCreInd.Name = "dtgCreInd";
            this.dtgCreInd.ReadOnly = true;
            this.dtgCreInd.RowHeadersVisible = false;
            this.dtgCreInd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgCreInd.Size = new System.Drawing.Size(587, 84);
            this.dtgCreInd.TabIndex = 12;
            this.dtgCreInd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCreInd_CellEndEdit);
            this.dtgCreInd.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgCreInd_CurrentCellDirtyStateChanged);
            this.dtgCreInd.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnAgregaTarjetaCre);
            this.grbBase1.Controls.Add(this.btnQuitaTarjetaCre);
            this.grbBase1.Controls.Add(this.dtgCre);
            this.grbBase1.Location = new System.Drawing.Point(3, -1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(906, 127);
            this.grbBase1.TabIndex = 17;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Deudas directas";
            // 
            // btnAgregaTarjetaCre
            // 
            this.btnAgregaTarjetaCre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregaTarjetaCre.BackgroundImage")));
            this.btnAgregaTarjetaCre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregaTarjetaCre.Location = new System.Drawing.Point(864, 15);
            this.btnAgregaTarjetaCre.Name = "btnAgregaTarjetaCre";
            this.btnAgregaTarjetaCre.Size = new System.Drawing.Size(36, 28);
            this.btnAgregaTarjetaCre.TabIndex = 9;
            this.btnAgregaTarjetaCre.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregaTarjetaCre.UseVisualStyleBackColor = true;
            this.btnAgregaTarjetaCre.Click += new System.EventHandler(this.btnAgregaTarjetaCre_Click);
            // 
            // btnQuitaTarjetaCre
            // 
            this.btnQuitaTarjetaCre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitaTarjetaCre.BackgroundImage")));
            this.btnQuitaTarjetaCre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitaTarjetaCre.Location = new System.Drawing.Point(864, 46);
            this.btnQuitaTarjetaCre.Name = "btnQuitaTarjetaCre";
            this.btnQuitaTarjetaCre.Size = new System.Drawing.Size(36, 28);
            this.btnQuitaTarjetaCre.TabIndex = 10;
            this.btnQuitaTarjetaCre.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitaTarjetaCre.UseVisualStyleBackColor = true;
            this.btnQuitaTarjetaCre.Click += new System.EventHandler(this.btnQuitaTarjetaCre_Click);
            // 
            // dtgCre
            // 
            this.dtgCre.AllowUserToAddRows = false;
            this.dtgCre.AllowUserToDeleteRows = false;
            this.dtgCre.AllowUserToResizeColumns = false;
            this.dtgCre.AllowUserToResizeRows = false;
            this.dtgCre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgCre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCre.Location = new System.Drawing.Point(5, 15);
            this.dtgCre.MultiSelect = false;
            this.dtgCre.Name = "dtgCre";
            this.dtgCre.ReadOnly = true;
            this.dtgCre.RowHeadersVisible = false;
            this.dtgCre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgCre.Size = new System.Drawing.Size(853, 108);
            this.dtgCre.TabIndex = 12;
            this.dtgCre.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCre_CellEndEdit);
            this.dtgCre.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCre_CellLeave);
            this.dtgCre.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgCre_CellPainting);
            this.dtgCre.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCre_CellValueChanged);
            this.dtgCre.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgCre_CurrentCellDirtyStateChanged);
            this.dtgCre.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            // 
            // ConCreditosEval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCargarDeudaRcc);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "ConCreditosEval";
            this.Size = new System.Drawing.Size(912, 228);
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreInd)).EndInit();
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private grbBase grbBase1;
        private BotonesBase.btnBlanco btnCargarDeudaRcc;
        private BotonesBase.btnMiniAgregar btnAgregaTarjetaCre;
        private BotonesBase.btnMiniQuitar btnQuitaTarjetaCre;
        private dtgBase dtgCre;
        private grbBase grbBase2;
        private BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private dtgBase dtgCreInd;


    }
}
