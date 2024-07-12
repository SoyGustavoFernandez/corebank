namespace GEN.ControlesBase
{
    partial class conListInterv
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
            this.grbIntervinientes = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase18 = new GEN.ControlesBase.lblBase();
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtTipInterv = new GEN.ControlesBase.txtBase(this.components);
            this.txtNumDoc = new GEN.ControlesBase.txtBase(this.components);
            this.dtgIntervinientes = new GEN.ControlesBase.dtgBase(this.components);
            this.grbIntervinientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            this.SuspendLayout();
            // 
            // grbIntervinientes
            // 
            this.grbIntervinientes.Controls.Add(this.lblBase8);
            this.grbIntervinientes.Controls.Add(this.lblBase9);
            this.grbIntervinientes.Controls.Add(this.lblBase18);
            this.grbIntervinientes.Controls.Add(this.txtDireccion);
            this.grbIntervinientes.Controls.Add(this.txtTipInterv);
            this.grbIntervinientes.Controls.Add(this.txtNumDoc);
            this.grbIntervinientes.Controls.Add(this.dtgIntervinientes);
            this.grbIntervinientes.Location = new System.Drawing.Point(7, 3);
            this.grbIntervinientes.Name = "grbIntervinientes";
            this.grbIntervinientes.Size = new System.Drawing.Size(535, 146);
            this.grbIntervinientes.TabIndex = 0;
            this.grbIntervinientes.TabStop = false;
            this.grbIntervinientes.Text = "Intervinientes  de la cuenta";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(332, 79);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(65, 13);
            this.lblBase8.TabIndex = 13;
            this.lblBase8.Text = "Dirección:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(332, 48);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(75, 13);
            this.lblBase9.TabIndex = 12;
            this.lblBase9.Text = "Tipo.Interv:";
            // 
            // lblBase18
            // 
            this.lblBase18.AutoSize = true;
            this.lblBase18.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase18.ForeColor = System.Drawing.Color.Navy;
            this.lblBase18.Location = new System.Drawing.Point(332, 22);
            this.lblBase18.Name = "lblBase18";
            this.lblBase18.Size = new System.Drawing.Size(58, 13);
            this.lblBase18.TabIndex = 11;
            this.lblBase18.Text = "Nro.Doc:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.SystemColors.Control;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(335, 105);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(184, 32);
            this.txtDireccion.TabIndex = 10;
            // 
            // txtTipInterv
            // 
            this.txtTipInterv.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipInterv.Enabled = false;
            this.txtTipInterv.Location = new System.Drawing.Point(408, 45);
            this.txtTipInterv.Name = "txtTipInterv";
            this.txtTipInterv.Size = new System.Drawing.Size(111, 20);
            this.txtTipInterv.TabIndex = 9;
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumDoc.Enabled = false;
            this.txtNumDoc.Location = new System.Drawing.Point(408, 19);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(111, 20);
            this.txtNumDoc.TabIndex = 8;
            // 
            // dtgIntervinientes
            // 
            this.dtgIntervinientes.AllowUserToAddRows = false;
            this.dtgIntervinientes.AllowUserToDeleteRows = false;
            this.dtgIntervinientes.AllowUserToResizeColumns = false;
            this.dtgIntervinientes.AllowUserToResizeRows = false;
            this.dtgIntervinientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntervinientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntervinientes.Location = new System.Drawing.Point(6, 19);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(323, 118);
            this.dtgIntervinientes.TabIndex = 7;
            this.dtgIntervinientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIntervinientes_CellContentClick);
            // 
            // conListInterv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbIntervinientes);
            this.Name = "conListInterv";
            this.Size = new System.Drawing.Size(553, 166);
            this.grbIntervinientes.ResumeLayout(false);
            this.grbIntervinientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private grbBase grbIntervinientes;
        private lblBase lblBase8;
        private lblBase lblBase9;
        private lblBase lblBase18;
        public txtBase txtNumDoc;
        public txtBase txtDireccion;
        public txtBase txtTipInterv;
        public dtgBase dtgIntervinientes;
    }
}
