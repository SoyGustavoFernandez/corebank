namespace GEN.ControlesBase
{
    partial class frmListaActivEcoInterna
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaActivEcoInterna));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.dtgActivEcoInt = new GEN.ControlesBase.dtgBase(this.components);
            this.txtBusActivEco = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnMiniBusq1 = new GEN.BotonesBase.btnMiniBusq(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivEcoInt)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(360, 182);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(294, 182);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 4;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // dtgActivEcoInt
            // 
            this.dtgActivEcoInt.AllowUserToAddRows = false;
            this.dtgActivEcoInt.AllowUserToDeleteRows = false;
            this.dtgActivEcoInt.AllowUserToResizeColumns = false;
            this.dtgActivEcoInt.AllowUserToResizeRows = false;
            this.dtgActivEcoInt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgActivEcoInt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActivEcoInt.Location = new System.Drawing.Point(12, 44);
            this.dtgActivEcoInt.MultiSelect = false;
            this.dtgActivEcoInt.Name = "dtgActivEcoInt";
            this.dtgActivEcoInt.ReadOnly = true;
            this.dtgActivEcoInt.RowHeadersVisible = false;
            this.dtgActivEcoInt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActivEcoInt.Size = new System.Drawing.Size(408, 132);
            this.dtgActivEcoInt.TabIndex = 3;
            this.dtgActivEcoInt.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgActivEcoInt_RowEnter);
            this.dtgActivEcoInt.DoubleClick += new System.EventHandler(this.dtgActivEcoInt_DoubleClick);
            this.dtgActivEcoInt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgActivEcoInt_KeyDown);
            this.dtgActivEcoInt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtgActivEcoInt_KeyPress);
            // 
            // txtBusActivEco
            // 
            this.txtBusActivEco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusActivEco.Location = new System.Drawing.Point(144, 14);
            this.txtBusActivEco.Name = "txtBusActivEco";
            this.txtBusActivEco.Size = new System.Drawing.Size(234, 20);
            this.txtBusActivEco.TabIndex = 1;
            this.txtBusActivEco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusActivEco_KeyPress);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(131, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Nombre de Actividad:";
            // 
            // btnMiniBusq1
            // 
            this.btnMiniBusq1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq1.BackgroundImage")));
            this.btnMiniBusq1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq1.Location = new System.Drawing.Point(384, 11);
            this.btnMiniBusq1.Name = "btnMiniBusq1";
            this.btnMiniBusq1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq1.TabIndex = 2;
            this.btnMiniBusq1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq1.UseVisualStyleBackColor = true;
            this.btnMiniBusq1.Click += new System.EventHandler(this.btnMiniBusq1_Click);
            // 
            // frmListaActivEcoInterna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 258);
            this.Controls.Add(this.btnMiniBusq1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtBusActivEco);
            this.Controls.Add(this.dtgActivEcoInt);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmListaActivEcoInterna";
            this.Text = "Actividades económicas ";
            this.Load += new System.EventHandler(this.frmListaActivEcoInterna_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.dtgActivEcoInt, 0);
            this.Controls.SetChildIndex(this.txtBusActivEco, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnMiniBusq1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivEcoInt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.btnSalir btnSalir1;
        private BotonesBase.BtnAceptar btnAceptar1;
        private dtgBase dtgActivEcoInt;
        private txtBase txtBusActivEco;
        private lblBase lblBase1;
        private BotonesBase.btnMiniBusq btnMiniBusq1;
    }
}