namespace GEN.ControlesBase
{
    partial class ConFiltroSupervision
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConFiltroSupervision));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEstabTodos = new System.Windows.Forms.Button();
            this.btnAbrirEstab = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMiniActualizar1 = new GEN.BotonesBase.btnMiniActualizar(this.components);
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtAgencia = new GEN.ControlesBase.txtBase(this.components);
            this.dtpFechaHasta = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaDesde = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboSupervisorOperacion1 = new GEN.ControlesBase.cboSupervisorOperacion(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboEstadoSupervision1 = new GEN.ControlesBase.cboEstadoSupervision(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtTipoSupervision = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(864, 88);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblBase3);
            this.panel1.Controls.Add(this.txtTipoSupervision);
            this.panel1.Controls.Add(this.cboZona1);
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Controls.Add(this.lblBase2);
            this.panel1.Controls.Add(this.txtAgencia);
            this.panel1.Controls.Add(this.btnEstabTodos);
            this.panel1.Controls.Add(this.btnAbrirEstab);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 82);
            this.panel1.TabIndex = 0;
            // 
            // btnEstabTodos
            // 
            this.btnEstabTodos.Location = new System.Drawing.Point(390, 57);
            this.btnEstabTodos.Name = "btnEstabTodos";
            this.btnEstabTodos.Size = new System.Drawing.Size(27, 22);
            this.btnEstabTodos.TabIndex = 45;
            this.btnEstabTodos.Text = "X";
            this.btnEstabTodos.UseVisualStyleBackColor = true;
            this.btnEstabTodos.Click += new System.EventHandler(this.btnEstabTodos_Click);
            // 
            // btnAbrirEstab
            // 
            this.btnAbrirEstab.Location = new System.Drawing.Point(99, 57);
            this.btnAbrirEstab.Name = "btnAbrirEstab";
            this.btnAbrirEstab.Size = new System.Drawing.Size(36, 22);
            this.btnAbrirEstab.TabIndex = 46;
            this.btnAbrirEstab.Text = "...";
            this.btnAbrirEstab.UseVisualStyleBackColor = true;
            this.btnAbrirEstab.Click += new System.EventHandler(this.btnAbrirEstab_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMiniActualizar1);
            this.panel2.Controls.Add(this.dtpFechaHasta);
            this.panel2.Controls.Add(this.dtpFechaDesde);
            this.panel2.Controls.Add(this.lblBase8);
            this.panel2.Controls.Add(this.lblBase6);
            this.panel2.Controls.Add(this.cboSupervisorOperacion1);
            this.panel2.Controls.Add(this.lblBase4);
            this.panel2.Controls.Add(this.cboEstadoSupervision1);
            this.panel2.Controls.Add(this.lblBase5);
            this.panel2.Location = new System.Drawing.Point(435, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 85);
            this.panel2.TabIndex = 1;
            // 
            // btnMiniActualizar1
            // 
            this.btnMiniActualizar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniActualizar1.BackgroundImage")));
            this.btnMiniActualizar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniActualizar1.Location = new System.Drawing.Point(383, 55);
            this.btnMiniActualizar1.Name = "btnMiniActualizar1";
            this.btnMiniActualizar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniActualizar1.TabIndex = 56;
            this.btnMiniActualizar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniActualizar1.UseVisualStyleBackColor = true;
            this.btnMiniActualizar1.Click += new System.EventHandler(this.btnMiniActualizar1_Click);
            // 
            // cboZona1
            // 
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(99, 31);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(318, 21);
            this.cboZona1.TabIndex = 41;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(42, 34);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 42;
            this.lblBase1.Text = "Región:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(5, 62);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(88, 13);
            this.lblBase2.TabIndex = 43;
            this.lblBase2.Text = "Oficina / EOB:";
            // 
            // txtAgencia
            // 
            this.txtAgencia.Location = new System.Drawing.Point(132, 58);
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.ReadOnly = true;
            this.txtAgencia.Size = new System.Drawing.Size(259, 20);
            this.txtAgencia.TabIndex = 44;
            this.txtAgencia.Text = "-* Todos *-";
            this.txtAgencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAgencia.DoubleClick += new System.EventHandler(this.txtAgencia_DoubleClick);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(258, 35);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaHasta.TabIndex = 54;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(101, 35);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaDesde.TabIndex = 55;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(209, 39);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(43, 13);
            this.lblBase8.TabIndex = 52;
            this.lblBase8.Text = "hasta:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(12, 39);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(83, 13);
            this.lblBase6.TabIndex = 53;
            this.lblBase6.Text = "Fecha desde:";
            // 
            // cboSupervisorOperacion1
            // 
            this.cboSupervisorOperacion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupervisorOperacion1.FormattingEnabled = true;
            this.cboSupervisorOperacion1.Location = new System.Drawing.Point(101, 61);
            this.cboSupervisorOperacion1.Name = "cboSupervisorOperacion1";
            this.cboSupervisorOperacion1.Size = new System.Drawing.Size(282, 21);
            this.cboSupervisorOperacion1.TabIndex = 49;
            this.cboSupervisorOperacion1.SelectedIndexChanged += new System.EventHandler(this.cboSupervisorOperacion1_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(21, 64);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(74, 13);
            this.lblBase4.TabIndex = 48;
            this.lblBase4.Text = "Supervisor:";
            // 
            // cboEstadoSupervision1
            // 
            this.cboEstadoSupervision1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoSupervision1.FormattingEnabled = true;
            this.cboEstadoSupervision1.Location = new System.Drawing.Point(101, 8);
            this.cboEstadoSupervision1.Name = "cboEstadoSupervision1";
            this.cboEstadoSupervision1.Size = new System.Drawing.Size(318, 21);
            this.cboEstadoSupervision1.TabIndex = 51;
            this.cboEstadoSupervision1.SelectedIndexChanged += new System.EventHandler(this.cboEstadoSupervision1_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(45, 13);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(50, 13);
            this.lblBase5.TabIndex = 50;
            this.lblBase5.Text = "Estado:";
            // 
            // txtTipoSupervision
            // 
            this.txtTipoSupervision.Location = new System.Drawing.Point(99, 6);
            this.txtTipoSupervision.Name = "txtTipoSupervision";
            this.txtTipoSupervision.ReadOnly = true;
            this.txtTipoSupervision.Size = new System.Drawing.Size(318, 20);
            this.txtTipoSupervision.TabIndex = 47;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(57, 10);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(36, 13);
            this.lblBase3.TabIndex = 48;
            this.lblBase3.Text = "Tipo:";
            // 
            // ConFiltroSupervision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ConFiltroSupervision";
            this.Size = new System.Drawing.Size(864, 88);
            this.Load += new System.EventHandler(this.ConFiltroSupervision_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private cboZona cboZona1;
        private lblBase lblBase1;
        private lblBase lblBase2;
        private txtBase txtAgencia;
        private System.Windows.Forms.Button btnEstabTodos;
        private System.Windows.Forms.Button btnAbrirEstab;
        private System.Windows.Forms.Panel panel2;
        private BotonesBase.btnMiniActualizar btnMiniActualizar1;
        private dtpCorto dtpFechaHasta;
        private dtpCorto dtpFechaDesde;
        private lblBase lblBase8;
        private lblBase lblBase6;
        private cboSupervisorOperacion cboSupervisorOperacion1;
        private lblBase lblBase4;
        private cboEstadoSupervision cboEstadoSupervision1;
        private lblBase lblBase5;
        private lblBase lblBase3;
        private txtBase txtTipoSupervision;
    }
}
