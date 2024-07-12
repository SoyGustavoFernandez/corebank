namespace CRE.Presentacion
{
    partial class frmModificarMonto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificarMonto));
            this.nudMonto = new GEN.ControlesBase.nudBase(this.components);
            this.lblMonto = new GEN.ControlesBase.lblBase();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblMontoMaximo = new GEN.ControlesBase.lblBaseCustom(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Location = new System.Drawing.Point(64, 38);
            this.nudMonto.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(125, 20);
            this.nudMonto.TabIndex = 5;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMonto.ForeColor = System.Drawing.Color.Navy;
            this.lblMonto.Location = new System.Drawing.Point(12, 40);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(46, 13);
            this.lblMonto.TabIndex = 4;
            this.lblMonto.Text = "Monto:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(47, 76);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(113, 76);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblMontoMaximo
            // 
            this.lblMontoMaximo.AutoSize = true;
            this.lblMontoMaximo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblMontoMaximo.ForeColor = System.Drawing.Color.Navy;
            this.lblMontoMaximo.Location = new System.Drawing.Point(14, 10);
            this.lblMontoMaximo.Name = "lblMontoMaximo";
            this.lblMontoMaximo.Size = new System.Drawing.Size(100, 13);
            this.lblMontoMaximo.TabIndex = 8;
            this.lblMontoMaximo.Text = "Monto Máximo";
            // 
            // frmModificarMonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 157);
            this.Controls.Add(this.lblMontoMaximo);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.nudMonto);
            this.Controls.Add(this.lblMonto);
            this.Name = "frmModificarMonto";
            this.Text = "Modificar Monto";
            this.Controls.SetChildIndex(this.lblMonto, 0);
            this.Controls.SetChildIndex(this.nudMonto, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.lblMontoMaximo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.nudBase nudMonto;
        private GEN.ControlesBase.lblBase lblMonto;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBaseCustom lblMontoMaximo;
    }
}