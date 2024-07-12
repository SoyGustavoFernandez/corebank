namespace GEN.ControlesBase
{
    partial class frmBuscaCentroCosto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaCentroCosto));
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtBuscar1 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.conTreeCentroCosto1 = new GEN.ControlesBase.conTreeCentroCosto();
            this.SuspendLayout();
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(181, 258);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 2;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(247, 258);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // txtBuscar1
            // 
            this.txtBuscar1.Location = new System.Drawing.Point(81, 12);
            this.txtBuscar1.Name = "txtBuscar1";
            this.txtBuscar1.Size = new System.Drawing.Size(226, 20);
            this.txtBuscar1.TabIndex = 51;
            this.txtBuscar1.TextChanged += new System.EventHandler(this.txtBuscar1_TextChanged);
            this.txtBuscar1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar1_KeyPress);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(16, 14);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(51, 13);
            this.lblBase3.TabIndex = 50;
            this.lblBase3.Text = "Buscar:";
            // 
            // conTreeCentroCosto1
            // 
            this.conTreeCentroCosto1.Location = new System.Drawing.Point(81, 38);
            this.conTreeCentroCosto1.Name = "conTreeCentroCosto1";
            this.conTreeCentroCosto1.Size = new System.Drawing.Size(226, 214);
            this.conTreeCentroCosto1.TabIndex = 52;
            this.conTreeCentroCosto1.Load += new System.EventHandler(this.conTreeCentroCosto1_Load);
            // 
            // frmBuscaCentroCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 340);
            this.Controls.Add(this.conTreeCentroCosto1);
            this.Controls.Add(this.txtBuscar1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar1);
            this.Name = "frmBuscaCentroCosto";
            this.Text = "Selección de Centro de Costos";
            this.Load += new System.EventHandler(this.frmBuscaCentroCosto_Load);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtBuscar1, 0);
            this.Controls.SetChildIndex(this.conTreeCentroCosto1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BotonesBase.BtnAceptar btnAceptar1;
        private BotonesBase.btnSalir btnSalir1;
        private txtBase txtBuscar1;
        private lblBase lblBase3;
        private conTreeCentroCosto conTreeCentroCosto1;
    }
}