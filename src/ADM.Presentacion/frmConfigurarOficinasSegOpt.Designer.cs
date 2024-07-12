﻿namespace ADM.Presentacion
{
    partial class frmConfigurarOficinasSegOpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurarOficinasSegOpt));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.chbAutorizado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(27, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(36, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Zona";
            // 
            // cboZona1
            // 
            this.cboZona1.AgregarItemTodos = true;
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(66, 20);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(261, 21);
            this.cboZona1.TabIndex = 11;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(5, 50);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(58, 13);
            this.lblBase2.TabIndex = 14;
            this.lblBase2.Text = "Agencias";
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(206, 92);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 15;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(266, 92);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 16;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.AgregarItemTodos = true;
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(66, 48);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(260, 21);
            this.cboAgencias1.TabIndex = 17;
            this.cboAgencias1.SelectedIndexChanged += new System.EventHandler(this.cboAgencias1_SelectedIndexChanged);
            // 
            // chbAutorizado
            // 
            this.chbAutorizado.AutoSize = true;
            this.chbAutorizado.Location = new System.Drawing.Point(66, 75);
            this.chbAutorizado.Name = "chbAutorizado";
            this.chbAutorizado.Size = new System.Drawing.Size(76, 17);
            this.chbAutorizado.TabIndex = 25;
            this.chbAutorizado.Text = "Autorizado";
            this.chbAutorizado.UseVisualStyleBackColor = true;
            this.chbAutorizado.CheckedChanged += new System.EventHandler(this.chbAutorizado_CheckedChanged);
            // 
            // frmAgregarOficinasSegOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 174);
            this.Controls.Add(this.chbAutorizado);
            this.Controls.Add(this.cboAgencias1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboZona1);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmConfigurarOficinasSegOpt";
            this.Text = "Configurar Agencia Seguro Optativo";
            this.Load += new System.EventHandler(this.frmAgregarOficinasSegOpt_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboZona1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.cboAgencias1, 0);
            this.Controls.SetChildIndex(this.chbAutorizado, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboZona cboZona1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private System.Windows.Forms.CheckBox chbAutorizado;

    }
}