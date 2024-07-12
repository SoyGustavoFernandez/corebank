namespace CRE.Presentacion
{
    partial class frmRptCreditosGarantias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptCreditosGarantias));
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboGrupoGarantia1 = new GEN.ControlesBase.cboGrupoGarantia(this.components);
            this.cboClaseGarantia = new GEN.ControlesBase.cboClaseGarantia(this.components);
            this.lblBase35 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoGarantia = new GEN.ControlesBase.cboTipoGarantia(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(167, 184);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 6;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(248, 184);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboGrupoGarantia1
            // 
            this.cboGrupoGarantia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoGarantia1.FormattingEnabled = true;
            this.cboGrupoGarantia1.Location = new System.Drawing.Point(140, 55);
            this.cboGrupoGarantia1.Name = "cboGrupoGarantia1";
            this.cboGrupoGarantia1.Size = new System.Drawing.Size(252, 21);
            this.cboGrupoGarantia1.TabIndex = 7;
            this.cboGrupoGarantia1.SelectedIndexChanged += new System.EventHandler(this.cboGrupoGarantia1_SelectedIndexChanged);
            // 
            // cboClaseGarantia
            // 
            this.cboClaseGarantia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClaseGarantia.DropDownWidth = 180;
            this.cboClaseGarantia.FormattingEnabled = true;
            this.cboClaseGarantia.Location = new System.Drawing.Point(140, 85);
            this.cboClaseGarantia.Name = "cboClaseGarantia";
            this.cboClaseGarantia.Size = new System.Drawing.Size(252, 21);
            this.cboClaseGarantia.TabIndex = 8;
            this.cboClaseGarantia.SelectedIndexChanged += new System.EventHandler(this.cboClaseGarantia_SelectedIndexChanged);
            // 
            // lblBase35
            // 
            this.lblBase35.AutoSize = true;
            this.lblBase35.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase35.ForeColor = System.Drawing.Color.Navy;
            this.lblBase35.Location = new System.Drawing.Point(26, 58);
            this.lblBase35.Name = "lblBase35";
            this.lblBase35.Size = new System.Drawing.Size(100, 13);
            this.lblBase35.TabIndex = 10;
            this.lblBase35.Text = "Grupo Garantía:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(26, 88);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(97, 13);
            this.lblBase2.TabIndex = 11;
            this.lblBase2.Text = "Clase Garantía:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(26, 118);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(89, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Tipo Garantía:";
            // 
            // cboTipoGarantia
            // 
            this.cboTipoGarantia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoGarantia.DropDownWidth = 350;
            this.cboTipoGarantia.FormattingEnabled = true;
            this.cboTipoGarantia.Location = new System.Drawing.Point(140, 115);
            this.cboTipoGarantia.Name = "cboTipoGarantia";
            this.cboTipoGarantia.Size = new System.Drawing.Size(252, 21);
            this.cboTipoGarantia.TabIndex = 12;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Controls.Add(this.dtpFecIni);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase35);
            this.grbBase1.Controls.Add(this.cboGrupoGarantia1);
            this.grbBase1.Controls.Add(this.cboTipoGarantia);
            this.grbBase1.Controls.Add(this.cboClaseGarantia);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(429, 154);
            this.grbBase1.TabIndex = 13;
            this.grbBase1.TabStop = false;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(288, 19);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(103, 20);
            this.dtpFecFin.TabIndex = 14;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(155, 19);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(103, 20);
            this.dtpFecIni.TabIndex = 13;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(26, 22);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(123, 13);
            this.lblBase3.TabIndex = 10;
            this.lblBase3.Text = "Desembolsados del:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(262, 22);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(23, 13);
            this.lblBase4.TabIndex = 15;
            this.lblBase4.Text = "Al:";
            // 
            // frmRptCreditosGarantias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 273);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRptCreditosGarantias";
            this.Text = "Reporte de Créditos con Garantías";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.cboGrupoGarantia cboGrupoGarantia1;
        private GEN.ControlesBase.cboClaseGarantia cboClaseGarantia;
        private GEN.ControlesBase.lblBase lblBase35;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboTipoGarantia cboTipoGarantia;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
    }
}

