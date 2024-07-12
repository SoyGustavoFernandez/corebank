namespace GEN.ControlesBase
{
    partial class frmBuscaEstablecimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaEstablecimiento));
            this.txtBuscar1 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.conTreeEstablecimiento1 = new GEN.ControlesBase.conTreeCentroCosto();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // txtBuscar1
            // 
            this.txtBuscar1.Location = new System.Drawing.Point(68, 39);
            this.txtBuscar1.Name = "txtBuscar1";
            this.txtBuscar1.Size = new System.Drawing.Size(226, 20);
            this.txtBuscar1.TabIndex = 53;
            this.txtBuscar1.TextChanged += new System.EventHandler(this.txtBuscar1_TextChanged);
            this.txtBuscar1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar1_KeyPress);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(11, 42);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(51, 13);
            this.lblBase3.TabIndex = 52;
            this.lblBase3.Text = "Buscar:";
            // 
            // conTreeEstablecimiento1
            // 
            this.conTreeEstablecimiento1.Location = new System.Drawing.Point(68, 65);
            this.conTreeEstablecimiento1.Name = "conTreeEstablecimiento1";
            this.conTreeEstablecimiento1.Size = new System.Drawing.Size(226, 214);
            this.conTreeEstablecimiento1.TabIndex = 56;
            this.conTreeEstablecimiento1.Load += new System.EventHandler(this.conTreeEstablecimiento1_Load);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(234, 285);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 55;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(168, 285);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 54;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // cboZona1
            // 
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(68, 12);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(226, 21);
            this.cboZona1.TabIndex = 57;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 58;
            this.lblBase1.Text = "Región:";
            // 
            // frmBuscaEstablecimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 364);
            this.Controls.Add(this.cboZona1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.conTreeEstablecimiento1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.txtBuscar1);
            this.Controls.Add(this.lblBase3);
            this.Name = "frmBuscaEstablecimiento";
            this.Text = "Selección de Agencia / Establecimiento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBuscaEstablecimiento_FormClosing);
            this.Load += new System.EventHandler(this.frmBuscaEstablecimiento_Load);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtBuscar1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conTreeEstablecimiento1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboZona1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private txtBase txtBuscar1;
        private lblBase lblBase3;
        private conTreeCentroCosto conTreeEstablecimiento1;
        private BotonesBase.btnSalir btnSalir1;
        private BotonesBase.BtnAceptar btnAceptar1;
        private cboZona cboZona1;
        private lblBase lblBase1;
    }
}