namespace CLI.Presentacion
{
    partial class FrmRptListadoPer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRptListadoPer));
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboCargoPersonal = new GEN.ControlesBase.cboCargoPersonalcs(this.components);
            this.cboArea1 = new GEN.ControlesBase.cboArea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboEstPer = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(21, 28);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(63, 13);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "Agencias:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(21, 82);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(47, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Cargo:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(90, 25);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(297, 21);
            this.cboAgencias.TabIndex = 7;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectedIndexChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboCargoPersonal);
            this.grbBase1.Controls.Add(this.cboArea1);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.cboEstPer);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(393, 140);
            this.grbBase1.TabIndex = 9;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Elija los parámetros";
            // 
            // cboCargoPersonal
            // 
            this.cboCargoPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCargoPersonal.FormattingEnabled = true;
            this.cboCargoPersonal.Location = new System.Drawing.Point(90, 79);
            this.cboCargoPersonal.Name = "cboCargoPersonal";
            this.cboCargoPersonal.Size = new System.Drawing.Size(297, 21);
            this.cboCargoPersonal.TabIndex = 16;
            // 
            // cboArea1
            // 
            this.cboArea1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArea1.FormattingEnabled = true;
            this.cboArea1.Location = new System.Drawing.Point(90, 52);
            this.cboArea1.Name = "cboArea1";
            this.cboArea1.Size = new System.Drawing.Size(297, 21);
            this.cboArea1.TabIndex = 15;
            this.cboArea1.SelectedIndexChanged += new System.EventHandler(this.cboArea1_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(21, 55);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(39, 13);
            this.lblBase4.TabIndex = 14;
            this.lblBase4.Text = "Área:";
            // 
            // cboEstPer
            // 
            this.cboEstPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstPer.FormattingEnabled = true;
            this.cboEstPer.Location = new System.Drawing.Point(90, 106);
            this.cboEstPer.Name = "cboEstPer";
            this.cboEstPer.Size = new System.Drawing.Size(297, 21);
            this.cboEstPer.TabIndex = 13;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(21, 108);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(50, 13);
            this.lblBase2.TabIndex = 12;
            this.lblBase2.Text = "Estado:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(164, 158);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(230, 158);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // FrmRptListadoPer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 238);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBase1);
            this.Name = "FrmRptListadoPer";
            this.Text = "Reporte de Listado de Personal";
            this.Load += new System.EventHandler(this.FrmRptListadoPer_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboAgencias;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboBase cboEstPer;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboArea cboArea1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboCargoPersonalcs cboCargoPersonal;
    }
}