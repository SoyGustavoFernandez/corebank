namespace CNT.Presentacion
{
    partial class frmReplicaCtaCtb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReplicaCtaCtb));
            this.cboTipoCredito = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboSubProductoOrigen = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboSubProductoDestino = new GEN.ControlesBase.cboProducto(this.components);
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboModulo1 = new GEN.ControlesBase.cboModulo(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.SuspendLayout();
            // 
            // cboTipoCredito
            // 
            this.cboTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCredito.FormattingEnabled = true;
            this.cboTipoCredito.Location = new System.Drawing.Point(151, 47);
            this.cboTipoCredito.Name = "cboTipoCredito";
            this.cboTipoCredito.Size = new System.Drawing.Size(141, 21);
            this.cboTipoCredito.TabIndex = 2;
            this.cboTipoCredito.SelectedIndexChanged += new System.EventHandler(this.cboTipoCredito_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 51);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(36, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Tipo:";
            // 
            // cboSubProductoOrigen
            // 
            this.cboSubProductoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubProductoOrigen.FormattingEnabled = true;
            this.cboSubProductoOrigen.Location = new System.Drawing.Point(151, 76);
            this.cboSubProductoOrigen.Name = "cboSubProductoOrigen";
            this.cboSubProductoOrigen.Size = new System.Drawing.Size(356, 21);
            this.cboSubProductoOrigen.TabIndex = 4;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 80);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(128, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Sub producto origen:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 109);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(133, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Sub producto destino:";
            // 
            // cboSubProductoDestino
            // 
            this.cboSubProductoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubProductoDestino.FormattingEnabled = true;
            this.cboSubProductoDestino.Location = new System.Drawing.Point(151, 105);
            this.cboSubProductoDestino.Name = "cboSubProductoDestino";
            this.cboSubProductoDestino.Size = new System.Drawing.Size(356, 21);
            this.cboSubProductoDestino.TabIndex = 6;
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(151, 131);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(204, 17);
            this.chcTodos.TabIndex = 8;
            this.chcTodos.Text = "Replicar a TODOS los subproductos?";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(379, 150);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 9;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(447, 150);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 10;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboModulo1
            // 
            this.cboModulo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo1.FormattingEnabled = true;
            this.cboModulo1.Location = new System.Drawing.Point(151, 20);
            this.cboModulo1.Name = "cboModulo1";
            this.cboModulo1.Size = new System.Drawing.Size(121, 21);
            this.cboModulo1.TabIndex = 11;
            this.cboModulo1.SelectedIndexChanged += new System.EventHandler(this.cboModulo1_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 24);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(52, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Módulo:";
            // 
            // frmReplicaCtaCtb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 230);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboModulo1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboSubProductoDestino);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboSubProductoOrigen);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoCredito);
            this.Name = "frmReplicaCtaCtb";
            this.Text = "Replica dinámicas contables";
            this.Load += new System.EventHandler(this.frmReplicaCtaCtb_Load);
            this.Controls.SetChildIndex(this.cboTipoCredito, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboSubProductoOrigen, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboSubProductoDestino, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.cboModulo1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboProducto cboTipoCredito;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboProducto cboSubProductoOrigen;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboProducto cboSubProductoDestino;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboModulo cboModulo1;
        private GEN.ControlesBase.lblBase lblBase4;
    }
}