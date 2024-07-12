namespace RCP.Presentacion
{
    partial class frmMantAgenciaSupervisadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantAgenciaSupervisadas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgAgenciasSupervisados = new GEN.ControlesBase.dtgBase(this.components);
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboUsuarioSupervisorRec1 = new GEN.ControlesBase.cboUsuarioSupervisorRec(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAgenciasSupervisados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgAgenciasSupervisados);
            this.groupBox1.Location = new System.Drawing.Point(13, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 274);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agencias Supervisadas";
            // 
            // dtgAgenciasSupervisados
            // 
            this.dtgAgenciasSupervisados.AllowUserToAddRows = false;
            this.dtgAgenciasSupervisados.AllowUserToDeleteRows = false;
            this.dtgAgenciasSupervisados.AllowUserToResizeColumns = false;
            this.dtgAgenciasSupervisados.AllowUserToResizeRows = false;
            this.dtgAgenciasSupervisados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAgenciasSupervisados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAgenciasSupervisados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgAgenciasSupervisados.Location = new System.Drawing.Point(3, 16);
            this.dtgAgenciasSupervisados.MultiSelect = false;
            this.dtgAgenciasSupervisados.Name = "dtgAgenciasSupervisados";
            this.dtgAgenciasSupervisados.ReadOnly = true;
            this.dtgAgenciasSupervisados.RowHeadersVisible = false;
            this.dtgAgenciasSupervisados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAgenciasSupervisados.Size = new System.Drawing.Size(401, 255);
            this.dtgAgenciasSupervisados.TabIndex = 0;
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(426, 70);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 2;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(426, 104);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 3;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBase1);
            this.groupBox2.Controls.Add(this.cboUsuarioSupervisorRec1);
            this.groupBox2.Location = new System.Drawing.Point(16, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 41);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(22, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(69, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Supervisor";
            // 
            // cboUsuarioSupervisorRec1
            // 
            this.cboUsuarioSupervisorRec1.FormattingEnabled = true;
            this.cboUsuarioSupervisorRec1.Location = new System.Drawing.Point(97, 14);
            this.cboUsuarioSupervisorRec1.Name = "cboUsuarioSupervisorRec1";
            this.cboUsuarioSupervisorRec1.Size = new System.Drawing.Size(333, 21);
            this.cboUsuarioSupervisorRec1.TabIndex = 0;
            this.cboUsuarioSupervisorRec1.SelectedIndexChanged += new System.EventHandler(this.cboUsuarioSupervisorRec1_SelectedIndexChanged);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(426, 275);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmMantAgenciaSupervisadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 366);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnMiniQuitar1);
            this.Controls.Add(this.btnMiniAgregar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMantAgenciaSupervisadas";
            this.Text = "Mantenimiento Usuario Supervisados";
            this.Load += new System.EventHandler(this.frmMantUsuarioSupervisados_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnMiniAgregar1, 0);
            this.Controls.SetChildIndex(this.btnMiniQuitar1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAgenciasSupervisados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.dtgBase dtgAgenciasSupervisados;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboUsuarioSupervisorRec cboUsuarioSupervisorRec1;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}