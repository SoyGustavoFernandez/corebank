
namespace CNT.Presentacion
{
    partial class frmOperacionCPE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperacionCPE));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.BtnBuscar = new GEN.BotonesBase.btnBusqueda();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.NudNroOperacion = new GEN.ControlesBase.nudBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.TxtEstado = new GEN.ControlesBase.txtBase(this.components);
            this.TxtNumero = new GEN.ControlesBase.txtBase(this.components);
            this.TxtSerie = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.BtnSalir = new GEN.BotonesBase.btnSalir();
            this.BtnCancelar = new GEN.BotonesBase.btnCancelar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudNroOperacion)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.BtnBuscar);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.NudNroOperacion);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(335, 84);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Búsqueda de operación (kardex)";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.BackgroundImage")));
            this.BtnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnBuscar.Location = new System.Drawing.Point(262, 19);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(60, 50);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "&Buscar";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(20, 40);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(110, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Nro de operación:";
            // 
            // NudNroOperacion
            // 
            this.NudNroOperacion.Location = new System.Drawing.Point(135, 37);
            this.NudNroOperacion.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.NudNroOperacion.Name = "NudNroOperacion";
            this.NudNroOperacion.Size = new System.Drawing.Size(120, 20);
            this.NudNroOperacion.TabIndex = 1;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.TxtEstado);
            this.grbBase2.Controls.Add(this.TxtNumero);
            this.grbBase2.Controls.Add(this.TxtSerie);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Location = new System.Drawing.Point(12, 102);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(335, 112);
            this.grbBase2.TabIndex = 2;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del comprobante CPE";
            // 
            // TxtEstado
            // 
            this.TxtEstado.Location = new System.Drawing.Point(89, 75);
            this.TxtEstado.Name = "TxtEstado";
            this.TxtEstado.ReadOnly = true;
            this.TxtEstado.Size = new System.Drawing.Size(233, 20);
            this.TxtEstado.TabIndex = 3;
            // 
            // TxtNumero
            // 
            this.TxtNumero.Location = new System.Drawing.Point(89, 54);
            this.TxtNumero.Name = "TxtNumero";
            this.TxtNumero.ReadOnly = true;
            this.TxtNumero.Size = new System.Drawing.Size(233, 20);
            this.TxtNumero.TabIndex = 2;
            // 
            // TxtSerie
            // 
            this.TxtSerie.Location = new System.Drawing.Point(89, 33);
            this.TxtSerie.Name = "TxtSerie";
            this.TxtSerie.ReadOnly = true;
            this.TxtSerie.Size = new System.Drawing.Size(233, 20);
            this.TxtSerie.TabIndex = 1;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(33, 78);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(50, 13);
            this.lblBase4.TabIndex = 1;
            this.lblBase4.Text = "Estado:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(26, 57);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 1;
            this.lblBase3.Text = "Número:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(41, 36);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(42, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Serie:";
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSalir.BackgroundImage")));
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSalir.Location = new System.Drawing.Point(287, 220);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(60, 50);
            this.BtnSalir.TabIndex = 4;
            this.BtnSalir.Text = "&Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnCancelar.BackgroundImage")));
            this.BtnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnCancelar.Location = new System.Drawing.Point(221, 220);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(60, 50);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // frmOperacionCPE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 302);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmOperacionCPE";
            this.Text = "Búsqueda de comprobante CPE por operación";
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.BtnSalir, 0);
            this.Controls.SetChildIndex(this.BtnCancelar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudNroOperacion)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.nudBase NudNroOperacion;
        private GEN.BotonesBase.btnBusqueda BtnBuscar;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase TxtEstado;
        private GEN.ControlesBase.txtBase TxtNumero;
        private GEN.ControlesBase.txtBase TxtSerie;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnSalir BtnSalir;
        private GEN.BotonesBase.btnCancelar BtnCancelar;
    }
}