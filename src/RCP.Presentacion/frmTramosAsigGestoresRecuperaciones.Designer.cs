namespace RCP.Presentacion
{
    partial class frmTramosAsigGestoresRecuperaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTramosAsigGestoresRecuperaciones));
            this.cboPeriodo1 = new GEN.ControlesBase.cboPeriodo(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFecha = new GEN.ControlesBase.DatePicker();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.chbInicioMeta = new System.Windows.Forms.CheckBox();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboListaPerfil1 = new GEN.ControlesBase.cboListaPerfil(this.components);
            this.SuspendLayout();
            // 
            // cboPeriodo1
            // 
            this.cboPeriodo1.FormattingEnabled = true;
            this.cboPeriodo1.Location = new System.Drawing.Point(82, 12);
            this.cboPeriodo1.Name = "cboPeriodo1";
            this.cboPeriodo1.Size = new System.Drawing.Size(200, 21);
            this.cboPeriodo1.TabIndex = 0;
            this.cboPeriodo1.SelectedIndexChanged += new System.EventHandler(this.cboPeriodo1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(21, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(59, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Periodo: ";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(31, 42);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(45, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(82, 39);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 1;
            this.dtpFecha.Value = new System.DateTime(2015, 8, 26, 12, 54, 59, 834);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(156, 139);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 4;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(222, 139);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // chbInicioMeta
            // 
            this.chbInicioMeta.AutoSize = true;
            this.chbInicioMeta.Location = new System.Drawing.Point(82, 65);
            this.chbInicioMeta.Name = "chbInicioMeta";
            this.chbInicioMeta.Size = new System.Drawing.Size(147, 17);
            this.chbInicioMeta.TabIndex = 2;
            this.chbInicioMeta.Text = "Inicio de meta del periodo";
            this.chbInicioMeta.UseVisualStyleBackColor = true;
            this.chbInicioMeta.CheckedChanged += new System.EventHandler(this.chbInicioMeta_CheckedChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(35, 91);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(41, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Perfil:";
            // 
            // cboListaPerfil1
            // 
            this.cboListaPerfil1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaPerfil1.FormattingEnabled = true;
            this.cboListaPerfil1.Location = new System.Drawing.Point(82, 88);
            this.cboListaPerfil1.Name = "cboListaPerfil1";
            this.cboListaPerfil1.Size = new System.Drawing.Size(200, 21);
            this.cboListaPerfil1.TabIndex = 3;
            // 
            // frmTramosAsigGestoresRecuperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 228);
            this.Controls.Add(this.cboListaPerfil1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.chbInicioMeta);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboPeriodo1);
            this.Name = "frmTramosAsigGestoresRecuperaciones";
            this.Text = "Tramos Asignados a Gestores de Recuperaciones";
            this.Load += new System.EventHandler(this.frmTramosAsigGestoresRecuperaciones_Load);
            this.Controls.SetChildIndex(this.cboPeriodo1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.chbInicioMeta, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboListaPerfil1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboPeriodo cboPeriodo1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.DatePicker dtpFecha;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.CheckBox chbInicioMeta;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboListaPerfil cboListaPerfil1;
    }
}