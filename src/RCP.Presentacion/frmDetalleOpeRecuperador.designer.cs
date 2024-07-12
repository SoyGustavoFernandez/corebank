namespace RCP.Presentacion
{
    partial class frmDetalleOpeRecuperador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleOpeRecuperador));
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnSalir2 = new GEN.BotonesBase.btnSalir();
            this.dFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.chkRecuperadores = new GEN.ControlesBase.chklbBase(this.components);
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.SuspendLayout();
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(23, 21);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 21;
            this.lblBase3.Text = "Agencia:";
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(109, 18);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(158, 21);
            this.cboAgencia1.TabIndex = 20;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(23, 83);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 18;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(23, 52);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(80, 13);
            this.lblBase1.TabIndex = 17;
            this.lblBase1.Text = "Fecha Inicio:";
            // 
            // dFecFin
            // 
            this.dFecFin.Location = new System.Drawing.Point(109, 76);
            this.dFecFin.Name = "dFecFin";
            this.dFecFin.Size = new System.Drawing.Size(121, 20);
            this.dFecFin.TabIndex = 16;
            // 
            // btnSalir2
            // 
            this.btnSalir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir2.BackgroundImage")));
            this.btnSalir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir2.Location = new System.Drawing.Point(150, 268);
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(60, 50);
            this.btnSalir2.TabIndex = 14;
            this.btnSalir2.Text = "&Salir";
            this.btnSalir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir2.UseVisualStyleBackColor = true;
            // 
            // dFecIni
            // 
            this.dFecIni.Location = new System.Drawing.Point(109, 46);
            this.dFecIni.Name = "dFecIni";
            this.dFecIni.Size = new System.Drawing.Size(121, 20);
            this.dFecIni.TabIndex = 15;
            // 
            // chkRecuperadores
            // 
            this.chkRecuperadores.FormattingEnabled = true;
            this.chkRecuperadores.Location = new System.Drawing.Point(26, 126);
            this.chkRecuperadores.Name = "chkRecuperadores";
            this.chkRecuperadores.Size = new System.Drawing.Size(241, 109);
            this.chkRecuperadores.TabIndex = 41;
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(26, 241);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 40;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(23, 110);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(103, 13);
            this.lblBase5.TabIndex = 39;
            this.lblBase5.Text = "Recuperador(es)";
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(84, 268);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 42;
            this.btnImprimir1.Text = "Detalle";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // frmDetalleOpeRecuperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 357);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.chkRecuperadores);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboAgencia1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dFecFin);
            this.Controls.Add(this.btnSalir2);
            this.Controls.Add(this.dFecIni);
            this.Name = "frmDetalleOpeRecuperador";
            this.Text = "Detalle de Operaciones";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.dFecIni, 0);
            this.Controls.SetChildIndex(this.btnSalir2, 0);
            this.Controls.SetChildIndex(this.dFecFin, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboAgencia1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            this.Controls.SetChildIndex(this.chkRecuperadores, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dFecFin;
        private GEN.BotonesBase.btnSalir btnSalir2;
        private GEN.ControlesBase.dtpCorto dFecIni;
        private GEN.ControlesBase.chklbBase chkRecuperadores;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
    }
}

