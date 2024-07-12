namespace DEP.Presentacion
{
    partial class frmReporteExoneracionITF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteExoneracionITF));
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.dtFecFin = new System.Windows.Forms.DateTimePicker();
            this.dtFecInicio = new System.Windows.Forms.DateTimePicker();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.RBPeriodo = new System.Windows.Forms.RadioButton();
            this.RBFecha = new System.Windows.Forms.RadioButton();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtAfeITF = new System.Windows.Forms.RadioButton();
            this.rbtExoItf = new System.Windows.Forms.RadioButton();
            this.grbFecha = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboProducto4 = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.CBTodo = new System.Windows.Forms.CheckBox();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboProducto3 = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.cboProducto1 = new GEN.ControlesBase.cboProducto(this.components);
            this.cboProducto2 = new GEN.ControlesBase.cboProducto(this.components);
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.DropDownWidth = 120;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(321, 54);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(160, 21);
            this.cboAgencia1.TabIndex = 37;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(377, 205);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 33;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // dtFecFin
            // 
            this.dtFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecFin.Location = new System.Drawing.Point(345, 150);
            this.dtFecFin.Name = "dtFecFin";
            this.dtFecFin.Size = new System.Drawing.Size(136, 20);
            this.dtFecFin.TabIndex = 30;
            // 
            // dtFecInicio
            // 
            this.dtFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecInicio.Location = new System.Drawing.Point(345, 124);
            this.dtFecInicio.Name = "dtFecInicio";
            this.dtFecInicio.Size = new System.Drawing.Size(136, 20);
            this.dtFecInicio.TabIndex = 29;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(440, 205);
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
            this.btnImprimir1.Location = new System.Drawing.Point(313, 205);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 27;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // RBPeriodo
            // 
            this.RBPeriodo.AutoSize = true;
            this.RBPeriodo.ForeColor = System.Drawing.Color.Navy;
            this.RBPeriodo.Location = new System.Drawing.Point(126, 15);
            this.RBPeriodo.Name = "RBPeriodo";
            this.RBPeriodo.Size = new System.Drawing.Size(80, 17);
            this.RBPeriodo.TabIndex = 41;
            this.RBPeriodo.Text = "Por Periodo";
            this.RBPeriodo.UseVisualStyleBackColor = true;
            this.RBPeriodo.CheckedChanged += new System.EventHandler(this.RBPeriodo_CheckedChanged);
            // 
            // RBFecha
            // 
            this.RBFecha.AutoSize = true;
            this.RBFecha.Checked = true;
            this.RBFecha.ForeColor = System.Drawing.Color.Navy;
            this.RBFecha.Location = new System.Drawing.Point(6, 15);
            this.RBFecha.Name = "RBFecha";
            this.RBFecha.Size = new System.Drawing.Size(76, 17);
            this.RBFecha.TabIndex = 42;
            this.RBFecha.TabStop = true;
            this.RBFecha.Text = "A la Fecha";
            this.RBFecha.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.grbBase2);
            this.grbBase1.Controls.Add(this.grbFecha);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.cboProducto4);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.CBTodo);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.dtFecInicio);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.dtFecFin);
            this.grbBase1.Controls.Add(this.cboProducto3);
            this.grbBase1.Controls.Add(this.cboAgencia1);
            this.grbBase1.Controls.Add(this.lblBase17);
            this.grbBase1.Controls.Add(this.lblBase10);
            this.grbBase1.Controls.Add(this.cboProducto1);
            this.grbBase1.Controls.Add(this.cboProducto2);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(6, 22);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(494, 177);
            this.grbBase1.TabIndex = 122;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtros de Búsqueda";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.rbtAfeITF);
            this.grbBase2.Controls.Add(this.rbtExoItf);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(246, 9);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(235, 38);
            this.grbBase2.TabIndex = 123;
            this.grbBase2.TabStop = false;
            // 
            // rbtAfeITF
            // 
            this.rbtAfeITF.AutoSize = true;
            this.rbtAfeITF.ForeColor = System.Drawing.Color.Navy;
            this.rbtAfeITF.Location = new System.Drawing.Point(121, 13);
            this.rbtAfeITF.Name = "rbtAfeITF";
            this.rbtAfeITF.Size = new System.Drawing.Size(110, 17);
            this.rbtAfeITF.TabIndex = 122;
            this.rbtAfeITF.Text = "Afectación de ITF";
            this.rbtAfeITF.UseVisualStyleBackColor = true;
            this.rbtAfeITF.CheckedChanged += new System.EventHandler(this.rbtAfeITF_CheckedChanged);
            // 
            // rbtExoItf
            // 
            this.rbtExoItf.AutoSize = true;
            this.rbtExoItf.Checked = true;
            this.rbtExoItf.ForeColor = System.Drawing.Color.Navy;
            this.rbtExoItf.Location = new System.Drawing.Point(4, 13);
            this.rbtExoItf.Name = "rbtExoItf";
            this.rbtExoItf.Size = new System.Drawing.Size(118, 17);
            this.rbtExoItf.TabIndex = 123;
            this.rbtExoItf.TabStop = true;
            this.rbtExoItf.Text = "Exoneración de ITF";
            this.rbtExoItf.UseVisualStyleBackColor = true;
            this.rbtExoItf.CheckedChanged += new System.EventHandler(this.rbtExoItf_CheckedChanged);
            // 
            // grbFecha
            // 
            this.grbFecha.Controls.Add(this.RBFecha);
            this.grbFecha.Controls.Add(this.RBPeriodo);
            this.grbFecha.ForeColor = System.Drawing.Color.Navy;
            this.grbFecha.Location = new System.Drawing.Point(246, 80);
            this.grbFecha.Name = "grbFecha";
            this.grbFecha.Size = new System.Drawing.Size(235, 38);
            this.grbFecha.TabIndex = 124;
            this.grbFecha.TabStop = false;
            this.grbFecha.Text = "Rango de Fechas:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(282, 128);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(57, 13);
            this.lblBase7.TabIndex = 35;
            this.lblBase7.Text = "Fech.Ini:";
            // 
            // cboProducto4
            // 
            this.cboProducto4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto4.DropDownWidth = 150;
            this.cboProducto4.FormattingEnabled = true;
            this.cboProducto4.Location = new System.Drawing.Point(115, 135);
            this.cboProducto4.Name = "cboProducto4";
            this.cboProducto4.Size = new System.Drawing.Size(118, 21);
            this.cboProducto4.TabIndex = 115;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(260, 58);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 51;
            this.lblBase3.Text = "Agencia:";
            // 
            // CBTodo
            // 
            this.CBTodo.AutoSize = true;
            this.CBTodo.ForeColor = System.Drawing.Color.Navy;
            this.CBTodo.Location = new System.Drawing.Point(28, 25);
            this.CBTodo.Name = "CBTodo";
            this.CBTodo.Size = new System.Drawing.Size(122, 17);
            this.CBTodo.TabIndex = 120;
            this.CBTodo.Text = "Todos los productos";
            this.CBTodo.UseVisualStyleBackColor = true;
            this.CBTodo.CheckedChanged += new System.EventHandler(this.CBTodo_CheckedChanged);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(283, 154);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(58, 13);
            this.lblBase9.TabIndex = 36;
            this.lblBase9.Text = "Fech.Fin:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(25, 110);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(62, 13);
            this.lblBase5.TabIndex = 117;
            this.lblBase5.Text = "Producto:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(25, 81);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(55, 13);
            this.lblBase6.TabIndex = 119;
            this.lblBase6.Text = "Subtipo:";
            // 
            // cboProducto3
            // 
            this.cboProducto3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto3.DropDownWidth = 150;
            this.cboProducto3.FormattingEnabled = true;
            this.cboProducto3.Location = new System.Drawing.Point(115, 107);
            this.cboProducto3.Name = "cboProducto3";
            this.cboProducto3.Size = new System.Drawing.Size(118, 21);
            this.cboProducto3.TabIndex = 114;
            this.cboProducto3.SelectedIndexChanged += new System.EventHandler(this.cboProducto3_SelectedIndexChanged);
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(25, 53);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(36, 13);
            this.lblBase17.TabIndex = 118;
            this.lblBase17.Text = "Tipo:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(25, 138);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(89, 13);
            this.lblBase10.TabIndex = 116;
            this.lblBase10.Text = "Sub-Producto:";
            // 
            // cboProducto1
            // 
            this.cboProducto1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto1.DropDownWidth = 205;
            this.cboProducto1.FormattingEnabled = true;
            this.cboProducto1.Location = new System.Drawing.Point(115, 50);
            this.cboProducto1.Name = "cboProducto1";
            this.cboProducto1.Size = new System.Drawing.Size(118, 21);
            this.cboProducto1.TabIndex = 112;
            this.cboProducto1.SelectedIndexChanged += new System.EventHandler(this.cboProducto1_SelectedIndexChanged);
            // 
            // cboProducto2
            // 
            this.cboProducto2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto2.DropDownWidth = 150;
            this.cboProducto2.FormattingEnabled = true;
            this.cboProducto2.Location = new System.Drawing.Point(115, 78);
            this.cboProducto2.Name = "cboProducto2";
            this.cboProducto2.Size = new System.Drawing.Size(118, 21);
            this.cboProducto2.TabIndex = 113;
            this.cboProducto2.SelectedIndexChanged += new System.EventHandler(this.cboProducto2_SelectedIndexChanged);
            // 
            // frmReporteExoneracionITF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 283);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Name = "frmReporteExoneracionITF";
            this.Text = "Reporte de Cuentas Exoneradas de ITF";
            this.Load += new System.EventHandler(this.frmReporteExoneracionITF_Load);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbFecha.ResumeLayout(false);
            this.grbFecha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.DateTimePicker dtFecFin;
        private System.Windows.Forms.DateTimePicker dtFecInicio;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private System.Windows.Forms.RadioButton RBPeriodo;
        private System.Windows.Forms.RadioButton RBFecha;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboProducto cboProducto4;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.CheckBox CBTodo;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboProducto cboProducto3;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.cboProducto cboProducto1;
        private GEN.ControlesBase.cboProducto cboProducto2;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase9;
        private System.Windows.Forms.RadioButton rbtAfeITF;
        private System.Windows.Forms.RadioButton rbtExoItf;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbFecha;
    }
}