namespace ADM.Presentacion
{
    partial class frmRptPerfilPorUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptPerfilPorUsuario));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.dtpFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.conBusCol1 = new GEN.ControlesBase.ConBusCol();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.rbtnVigentes = new GEN.ControlesBase.rbtnBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtnTodos = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnNoVigentes = new GEN.ControlesBase.rbtnBase(this.components);
            this.conBusCol1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(197, 228);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(131, 228);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 3;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(216, 111);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(106, 20);
            this.dtpFin.TabIndex = 4;
            // 
            // dtpIni
            // 
            this.dtpIni.Location = new System.Drawing.Point(71, 110);
            this.dtpIni.Name = "dtpIni";
            this.dtpIni.Size = new System.Drawing.Size(106, 20);
            this.dtpIni.TabIndex = 5;
            // 
            // conBusCol1
            // 
            this.conBusCol1.Controls.Add(this.grbBase1);
            this.conBusCol1.Location = new System.Drawing.Point(12, 12);
            this.conBusCol1.Name = "conBusCol1";
            this.conBusCol1.Size = new System.Drawing.Size(394, 86);
            this.conBusCol1.TabIndex = 7;
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase1.Location = new System.Drawing.Point(0, 0);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(387, 86);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Colaborador";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 114);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(31, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Del:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(187, 114);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(23, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Al:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 175);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(50, 13);
            this.lblBase3.TabIndex = 10;
            this.lblBase3.Text = "Estado:";
            // 
            // rbtnVigentes
            // 
            this.rbtnVigentes.AutoSize = true;
            this.rbtnVigentes.Checked = true;
            this.rbtnVigentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnVigentes.Location = new System.Drawing.Point(6, 15);
            this.rbtnVigentes.Name = "rbtnVigentes";
            this.rbtnVigentes.Size = new System.Drawing.Size(66, 17);
            this.rbtnVigentes.TabIndex = 11;
            this.rbtnVigentes.TabStop = true;
            this.rbtnVigentes.Text = "Vigentes";
            this.rbtnVigentes.UseVisualStyleBackColor = true;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.rbtnTodos);
            this.grbBase2.Controls.Add(this.rbtnNoVigentes);
            this.grbBase2.Controls.Add(this.rbtnVigentes);
            this.grbBase2.Location = new System.Drawing.Point(71, 137);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(106, 85);
            this.grbBase2.TabIndex = 12;
            this.grbBase2.TabStop = false;
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnTodos.Location = new System.Drawing.Point(6, 61);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 13;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            // 
            // rbtnNoVigentes
            // 
            this.rbtnNoVigentes.AutoSize = true;
            this.rbtnNoVigentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnNoVigentes.Location = new System.Drawing.Point(6, 38);
            this.rbtnNoVigentes.Name = "rbtnNoVigentes";
            this.rbtnNoVigentes.Size = new System.Drawing.Size(83, 17);
            this.rbtnNoVigentes.TabIndex = 12;
            this.rbtnNoVigentes.Text = "No Vigentes";
            this.rbtnNoVigentes.UseVisualStyleBackColor = true;
            // 
            // frmRptPerfilPorUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 309);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.conBusCol1);
            this.Controls.Add(this.dtpIni);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRptPerfilPorUsuario";
            this.Text = "Reporte Perfiles por Usuario";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.dtpFin, 0);
            this.Controls.SetChildIndex(this.dtpIni, 0);
            this.Controls.SetChildIndex(this.conBusCol1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.conBusCol1.ResumeLayout(false);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.dtpCorto dtpFin;
        private GEN.ControlesBase.dtpCorto dtpIni;
        internal GEN.ControlesBase.ConBusCol conBusCol1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.rbtnBase rbtnVigentes;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.rbtnBase rbtnTodos;
        private GEN.ControlesBase.rbtnBase rbtnNoVigentes;
    }
}

