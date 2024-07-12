namespace DEP.Presentacion
{
    partial class frmReporteAperturaCta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteAperturaCta));
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboProducto2 = new GEN.ControlesBase.cboProducto(this.components);
            this.cboProducto1 = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.CBTodo = new System.Windows.Forms.CheckBox();
            this.cboProducto3 = new GEN.ControlesBase.cboProducto(this.components);
            this.dtFecInicio = new System.Windows.Forms.DateTimePicker();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboProducto4 = new GEN.ControlesBase.cboProducto(this.components);
            this.dtFecFin = new System.Windows.Forms.DateTimePicker();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(344, 156);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 33;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(407, 156);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 28;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(281, 156);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 27;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.DropDownWidth = 120;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(317, 42);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(125, 21);
            this.cboAgencia1.TabIndex = 37;
            // 
            // cboProducto2
            // 
            this.cboProducto2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto2.DropDownWidth = 150;
            this.cboProducto2.FormattingEnabled = true;
            this.cboProducto2.Location = new System.Drawing.Point(106, 42);
            this.cboProducto2.Name = "cboProducto2";
            this.cboProducto2.Size = new System.Drawing.Size(120, 21);
            this.cboProducto2.TabIndex = 122;
            this.cboProducto2.SelectedIndexChanged += new System.EventHandler(this.cboProducto2_SelectedIndexChanged);
            // 
            // cboProducto1
            // 
            this.cboProducto1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto1.DropDownWidth = 205;
            this.cboProducto1.FormattingEnabled = true;
            this.cboProducto1.Location = new System.Drawing.Point(106, 16);
            this.cboProducto1.Name = "cboProducto1";
            this.cboProducto1.Size = new System.Drawing.Size(120, 21);
            this.cboProducto1.TabIndex = 121;
            this.cboProducto1.SelectedIndexChanged += new System.EventHandler(this.cboProducto1_SelectedIndexChanged);
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(13, 98);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(89, 13);
            this.lblBase10.TabIndex = 125;
            this.lblBase10.Text = "Sub-Producto:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(252, 45);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 36;
            this.lblBase4.Text = "Agencia:";
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(13, 19);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(36, 13);
            this.lblBase17.TabIndex = 127;
            this.lblBase17.Text = "Tipo:";
            // 
            // CBTodo
            // 
            this.CBTodo.AutoSize = true;
            this.CBTodo.ForeColor = System.Drawing.Color.Navy;
            this.CBTodo.Location = new System.Drawing.Point(106, 120);
            this.CBTodo.Name = "CBTodo";
            this.CBTodo.Size = new System.Drawing.Size(122, 17);
            this.CBTodo.TabIndex = 129;
            this.CBTodo.Text = "Todos los productos";
            this.CBTodo.UseVisualStyleBackColor = true;
            this.CBTodo.CheckedChanged += new System.EventHandler(this.CBTodo_CheckedChanged);
            // 
            // cboProducto3
            // 
            this.cboProducto3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto3.DropDownWidth = 150;
            this.cboProducto3.FormattingEnabled = true;
            this.cboProducto3.Location = new System.Drawing.Point(106, 69);
            this.cboProducto3.Name = "cboProducto3";
            this.cboProducto3.Size = new System.Drawing.Size(120, 21);
            this.cboProducto3.TabIndex = 123;
            this.cboProducto3.SelectedIndexChanged += new System.EventHandler(this.cboProducto3_SelectedIndexChanged);
            // 
            // dtFecInicio
            // 
            this.dtFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecInicio.Location = new System.Drawing.Point(335, 69);
            this.dtFecInicio.Name = "dtFecInicio";
            this.dtFecInicio.Size = new System.Drawing.Size(107, 20);
            this.dtFecInicio.TabIndex = 29;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(13, 45);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(55, 13);
            this.lblBase6.TabIndex = 128;
            this.lblBase6.Text = "Subtipo:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(13, 72);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(62, 13);
            this.lblBase5.TabIndex = 126;
            this.lblBase5.Text = "Producto:";
            // 
            // cboProducto4
            // 
            this.cboProducto4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto4.DropDownWidth = 150;
            this.cboProducto4.FormattingEnabled = true;
            this.cboProducto4.Location = new System.Drawing.Point(106, 95);
            this.cboProducto4.Name = "cboProducto4";
            this.cboProducto4.Size = new System.Drawing.Size(120, 21);
            this.cboProducto4.TabIndex = 124;
            // 
            // dtFecFin
            // 
            this.dtFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecFin.Location = new System.Drawing.Point(337, 95);
            this.dtFecFin.Name = "dtFecFin";
            this.dtFecFin.Size = new System.Drawing.Size(105, 20);
            this.dtFecFin.TabIndex = 30;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(252, 72);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(57, 13);
            this.lblBase7.TabIndex = 35;
            this.lblBase7.Text = "Fech.Ini:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(252, 98);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(58, 13);
            this.lblBase9.TabIndex = 36;
            this.lblBase9.Text = "Fech.Fin:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboZona1);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.dtFecFin);
            this.grbBase1.Controls.Add(this.cboProducto4);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.dtFecInicio);
            this.grbBase1.Controls.Add(this.cboProducto3);
            this.grbBase1.Controls.Add(this.CBTodo);
            this.grbBase1.Controls.Add(this.lblBase17);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase10);
            this.grbBase1.Controls.Add(this.cboProducto1);
            this.grbBase1.Controls.Add(this.cboProducto2);
            this.grbBase1.Controls.Add(this.cboAgencia1);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(7, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(460, 147);
            this.grbBase1.TabIndex = 130;
            this.grbBase1.TabStop = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(252, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 131;
            this.lblBase1.Text = "Región:";
            // 
            // cboZona1
            // 
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(317, 16);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(125, 21);
            this.cboZona1.TabIndex = 130;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged);
            // 
            // frmReporteAperturaCta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 240);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Name = "frmReporteAperturaCta";
            this.Text = "Reporte de Aperturas de Cuentas";
            this.Load += new System.EventHandler(this.frmReporteAperturaCta_Load);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.cboAgencias cboAgencia1;
        private GEN.ControlesBase.cboProducto cboProducto2;
        private GEN.ControlesBase.cboProducto cboProducto1;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase17;
        private System.Windows.Forms.CheckBox CBTodo;
        private GEN.ControlesBase.cboProducto cboProducto3;
        private System.Windows.Forms.DateTimePicker dtFecInicio;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboProducto cboProducto4;
        private System.Windows.Forms.DateTimePicker dtFecFin;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboZona cboZona1;
    }
}