namespace CRE.Presentacion
{
    partial class frmDetalleMora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleMora));
            this.txtAtrIni = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtAtrFin = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMonIni = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtMonFin = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.chklAsesores = new GEN.ControlesBase.chklAsesores(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.SuspendLayout();
            // 
            // txtAtrIni
            // 
            this.txtAtrIni.Location = new System.Drawing.Point(157, 19);
            this.txtAtrIni.Name = "txtAtrIni";
            this.txtAtrIni.Size = new System.Drawing.Size(54, 20);
            this.txtAtrIni.TabIndex = 0;
            // 
            // txtAtrFin
            // 
            this.txtAtrFin.Location = new System.Drawing.Point(231, 19);
            this.txtAtrFin.Name = "txtAtrFin";
            this.txtAtrFin.Size = new System.Drawing.Size(62, 20);
            this.txtAtrFin.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(34, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(120, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Rango de Atraso de";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(213, 23);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(14, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "a";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(213, 49);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(14, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "a";
            // 
            // txtMonIni
            // 
            this.txtMonIni.Location = new System.Drawing.Point(157, 45);
            this.txtMonIni.Name = "txtMonIni";
            this.txtMonIni.Size = new System.Drawing.Size(54, 20);
            this.txtMonIni.TabIndex = 2;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(34, 49);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(123, 13);
            this.lblBase4.TabIndex = 8;
            this.lblBase4.Text = "Rango de Montos de";
            // 
            // txtMonFin
            // 
            this.txtMonFin.Location = new System.Drawing.Point(231, 45);
            this.txtMonFin.Name = "txtMonFin";
            this.txtMonFin.Size = new System.Drawing.Size(62, 20);
            this.txtMonFin.TabIndex = 3;
            // 
            // chklAsesores
            // 
            this.chklAsesores.FormattingEnabled = true;
            this.chklAsesores.Location = new System.Drawing.Point(109, 73);
            this.chklAsesores.Name = "chklAsesores";
            this.chklAsesores.Size = new System.Drawing.Size(184, 94);
            this.chklAsesores.Sorted = true;
            this.chklAsesores.TabIndex = 4;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(34, 73);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(69, 13);
            this.lblBase5.TabIndex = 11;
            this.lblBase5.Text = "Asesor(es)";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(180, 203);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(109, 203);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 6;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(109, 174);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 5;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // frmDetalleMora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 286);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.chklAsesores);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtMonIni);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.txtMonFin);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtAtrIni);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtAtrFin);
            this.Name = "frmDetalleMora";
            this.Text = "Detalle de Mora";
            this.Controls.SetChildIndex(this.txtAtrFin, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtAtrIni, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtMonFin, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.txtMonIni, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.chklAsesores, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtCBNumerosEnteros txtAtrIni;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAtrFin;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtCBNumerosEnteros txtMonIni;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtCBNumerosEnteros txtMonFin;
        private GEN.ControlesBase.chklAsesores chklAsesores;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.chcBase chcTodos;
    }
}