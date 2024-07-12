namespace ADM.Presentacion
{
    partial class frmConfigurarProductosSegOpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurarProductosSegOpt));
            this.chbTodos = new System.Windows.Forms.CheckBox();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.chbAutorizado = new System.Windows.Forms.CheckBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.conProducto1 = new GEN.ControlesBase.conProducto();
            this.SuspendLayout();
            // 
            // chbTodos
            // 
            this.chbTodos.AutoSize = true;
            this.chbTodos.Location = new System.Drawing.Point(98, 17);
            this.chbTodos.Name = "chbTodos";
            this.chbTodos.Size = new System.Drawing.Size(56, 17);
            this.chbTodos.TabIndex = 6;
            this.chbTodos.Text = "Todos";
            this.chbTodos.UseVisualStyleBackColor = true;
            this.chbTodos.CheckedChanged += new System.EventHandler(this.chbTodos_CheckedChanged);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(258, 162);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(198, 161);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 3;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // chbAutorizado
            // 
            this.chbAutorizado.AutoSize = true;
            this.chbAutorizado.Location = new System.Drawing.Point(98, 138);
            this.chbAutorizado.Name = "chbAutorizado";
            this.chbAutorizado.Size = new System.Drawing.Size(76, 17);
            this.chbAutorizado.TabIndex = 8;
            this.chbAutorizado.Text = "Autorizado";
            this.chbAutorizado.UseVisualStyleBackColor = true;
            this.chbAutorizado.CheckedChanged += new System.EventHandler(this.chbAutorizado_CheckedChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Sub Producto";
            // 
            // conProducto1
            // 
            this.conProducto1.AutoSize = true;
            this.conProducto1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conProducto1.lBloquear3Niveles = false;
            this.conProducto1.lMostrarTipoCredito = true;
            this.conProducto1.Location = new System.Drawing.Point(-1, 40);
            this.conProducto1.Name = "conProducto1";
            this.conProducto1.Size = new System.Drawing.Size(322, 92);
            this.conProducto1.TabIndex = 10;
            this.conProducto1.ChangeProducto += new System.EventHandler(this.conProducto1_ChangeProducto);
            // 
            // frmConfigurarProductosSegOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 239);
            this.Controls.Add(this.conProducto1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.chbAutorizado);
            this.Controls.Add(this.chbTodos);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Name = "frmConfigurarProductosSegOpt";
            this.Text = "Configurar Producto Seguro Optativo";
            this.Load += new System.EventHandler(this.frmAgregarProductosSegOpt_Load);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.chbTodos, 0);
            this.Controls.SetChildIndex(this.chbAutorizado, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.conProducto1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.CheckBox chbTodos;
        private System.Windows.Forms.CheckBox chbAutorizado;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.conProducto conProducto1;
    }
}