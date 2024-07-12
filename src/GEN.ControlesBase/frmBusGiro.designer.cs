namespace GEN.ControlesBase
{
    partial class frmBusGiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusGiro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboCriterioBus = new GEN.ControlesBase.cboBase(this.components);
            this.lblCriterio = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.dtgGiros = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtDatBus = new GEN.ControlesBase.txtBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGiros)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboCriterioBus
            // 
            this.cboCriterioBus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterioBus.FormattingEnabled = true;
            this.cboCriterioBus.Location = new System.Drawing.Point(83, 42);
            this.cboCriterioBus.Name = "cboCriterioBus";
            this.cboCriterioBus.Size = new System.Drawing.Size(216, 21);
            this.cboCriterioBus.TabIndex = 5;
            this.cboCriterioBus.SelectedIndexChanged += new System.EventHandler(this.cboCriterioBus_SelectedIndexChanged);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCriterio.ForeColor = System.Drawing.Color.Navy;
            this.lblCriterio.Location = new System.Drawing.Point(399, 43);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(105, 13);
            this.lblCriterio.TabIndex = 42;
            this.lblCriterio.Text = "Nro. Documento:";
            this.lblCriterio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(21, 45);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(55, 13);
            this.lblBase1.TabIndex = 43;
            this.lblBase1.Text = "Criterio:";
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(678, 15);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 45;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // dtgGiros
            // 
            this.dtgGiros.AllowUserToAddRows = false;
            this.dtgGiros.AllowUserToDeleteRows = false;
            this.dtgGiros.AllowUserToResizeColumns = false;
            this.dtgGiros.AllowUserToResizeRows = false;
            this.dtgGiros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgGiros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgGiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgGiros.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgGiros.Location = new System.Drawing.Point(3, 86);
            this.dtgGiros.MultiSelect = false;
            this.dtgGiros.Name = "dtgGiros";
            this.dtgGiros.ReadOnly = true;
            this.dtgGiros.RowHeadersVisible = false;
            this.dtgGiros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGiros.Size = new System.Drawing.Size(747, 181);
            this.dtgGiros.TabIndex = 46;
            this.dtgGiros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGiros_CellContentClick);
            this.dtgGiros.DoubleClick += new System.EventHandler(this.dtgGiros_DoubleClick);
            this.dtgGiros.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgGiros_KeyDown);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(689, 273);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 48;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(623, 273);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 47;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtDatBus);
            this.grbBase2.Controls.Add(this.lblCriterio);
            this.grbBase2.Location = new System.Drawing.Point(2, 2);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(747, 69);
            this.grbBase2.TabIndex = 49;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Búsqueda Personalizada";
            // 
            // txtDatBus
            // 
            this.txtDatBus.Location = new System.Drawing.Point(520, 40);
            this.txtDatBus.Name = "txtDatBus";
            this.txtDatBus.Size = new System.Drawing.Size(150, 20);
            this.txtDatBus.TabIndex = 0;
            this.txtDatBus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBase1_KeyPress);
            // 
            // frmBusGiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 350);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgGiros);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboCriterioBus);
            this.Controls.Add(this.grbBase2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmBusGiro";
            this.Text = "Buscar Giro";
            this.Load += new System.EventHandler(this.frmBusGiro_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.cboCriterioBus, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.dtgGiros, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGiros)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private cboBase cboCriterioBus;
        private lblBase lblCriterio;
        private lblBase lblBase1;
        private BotonesBase.btnProcesar btnProcesar;
        private dtgBase dtgGiros;
        private BotonesBase.btnSalir btnSalir;
        private BotonesBase.BtnAceptar btnAceptar;
        private grbBase grbBase2;
        private txtBase txtDatBus;
    }
}