namespace RCP.Presentacion
{
    partial class frmAprobacionSolRecupera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprobacionSolRecupera));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.dtgSolicitudes = new GEN.ControlesBase.dtgBase(this.components);
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnAprobar1 = new GEN.BotonesBase.btnAprobar();
            this.btnDenegar1 = new GEN.BotonesBase.btnDenegar();
            this.btnActualizar1 = new GEN.BotonesBase.btnActualizar();
            this.btnImprimirActa = new GEN.BotonesBase.btnImprimir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboPersonalCargo1 = new GEN.ControlesBase.cboPersonalCargo(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnBlanco();
            this.btnBlanco1 = new GEN.BotonesBase.btnBlanco();
            this.lblOficina = new GEN.ControlesBase.lblBase();
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(682, 300);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(616, 300);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 10;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // dtgSolicitudes
            // 
            this.dtgSolicitudes.AllowUserToAddRows = false;
            this.dtgSolicitudes.AllowUserToDeleteRows = false;
            this.dtgSolicitudes.AllowUserToResizeColumns = false;
            this.dtgSolicitudes.AllowUserToResizeRows = false;
            this.dtgSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitudes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgSolicitudes.Location = new System.Drawing.Point(12, 56);
            this.dtgSolicitudes.MultiSelect = false;
            this.dtgSolicitudes.Name = "dtgSolicitudes";
            this.dtgSolicitudes.ReadOnly = true;
            this.dtgSolicitudes.RowHeadersVisible = false;
            this.dtgSolicitudes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dtgSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitudes.Size = new System.Drawing.Size(730, 227);
            this.dtgSolicitudes.TabIndex = 2;
            this.dtgSolicitudes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSolicitudes_CellContentClick);
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Location = new System.Drawing.Point(12, 289);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 3;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            this.chcTodos.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 40);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(130, 13);
            this.lblBase1.TabIndex = 10;
            this.lblBase1.Text = "Solitudes pendientes:";
            // 
            // btnAprobar1
            // 
            this.btnAprobar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAprobar1.BackgroundImage")));
            this.btnAprobar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAprobar1.Location = new System.Drawing.Point(550, 300);
            this.btnAprobar1.Name = "btnAprobar1";
            this.btnAprobar1.Size = new System.Drawing.Size(60, 50);
            this.btnAprobar1.TabIndex = 9;
            this.btnAprobar1.Text = "&Aprobar";
            this.btnAprobar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobar1.UseVisualStyleBackColor = true;
            this.btnAprobar1.Click += new System.EventHandler(this.btnAprobar1_Click);
            // 
            // btnDenegar1
            // 
            this.btnDenegar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDenegar1.BackgroundImage")));
            this.btnDenegar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDenegar1.Location = new System.Drawing.Point(484, 300);
            this.btnDenegar1.Name = "btnDenegar1";
            this.btnDenegar1.Size = new System.Drawing.Size(60, 50);
            this.btnDenegar1.TabIndex = 8;
            this.btnDenegar1.Text = "&Denegar";
            this.btnDenegar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDenegar1.UseVisualStyleBackColor = true;
            this.btnDenegar1.Click += new System.EventHandler(this.btnDenegar1_Click);
            // 
            // btnActualizar1
            // 
            this.btnActualizar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar1.BackgroundImage")));
            this.btnActualizar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActualizar1.Location = new System.Drawing.Point(418, 300);
            this.btnActualizar1.Name = "btnActualizar1";
            this.btnActualizar1.Size = new System.Drawing.Size(60, 50);
            this.btnActualizar1.TabIndex = 7;
            this.btnActualizar1.Text = "Actualiza";
            this.btnActualizar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar1.texto = "Actualiza";
            this.btnActualizar1.UseVisualStyleBackColor = true;
            this.btnActualizar1.Click += new System.EventHandler(this.btnActualizar1_Click);
            // 
            // btnImprimirActa
            // 
            this.btnImprimirActa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirActa.BackgroundImage")));
            this.btnImprimirActa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirActa.Enabled = false;
            this.btnImprimirActa.Location = new System.Drawing.Point(352, 300);
            this.btnImprimirActa.Name = "btnImprimirActa";
            this.btnImprimirActa.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirActa.TabIndex = 6;
            this.btnImprimirActa.Text = "Acta";
            this.btnImprimirActa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirActa.UseVisualStyleBackColor = true;
            this.btnImprimirActa.Click += new System.EventHandler(this.btnImprimirActa_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(312, 14);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(85, 13);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "Recuperador:";
            // 
            // cboPersonalCargo1
            // 
            this.cboPersonalCargo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonalCargo1.FormattingEnabled = true;
            this.cboPersonalCargo1.Location = new System.Drawing.Point(403, 11);
            this.cboPersonalCargo1.Name = "cboPersonalCargo1";
            this.cboPersonalCargo1.Size = new System.Drawing.Size(339, 21);
            this.cboPersonalCargo1.TabIndex = 1;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(286, 300);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Posición integral";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnBlanco1_Click);
            // 
            // btnBlanco1
            // 
            this.btnBlanco1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBlanco1.Location = new System.Drawing.Point(220, 300);
            this.btnBlanco1.Name = "btnBlanco1";
            this.btnBlanco1.Size = new System.Drawing.Size(60, 50);
            this.btnBlanco1.TabIndex = 4;
            this.btnBlanco1.Text = "Historial de recuperaciones";
            this.btnBlanco1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBlanco1.UseVisualStyleBackColor = true;
            this.btnBlanco1.Click += new System.EventHandler(this.btnBlanco1_Click_1);
            // 
            // lblOficina
            // 
            this.lblOficina.AutoSize = true;
            this.lblOficina.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblOficina.ForeColor = System.Drawing.Color.Navy;
            this.lblOficina.Location = new System.Drawing.Point(15, 14);
            this.lblOficina.Name = "lblOficina";
            this.lblOficina.Size = new System.Drawing.Size(51, 13);
            this.lblOficina.TabIndex = 19;
            this.lblOficina.Text = "Oficina:";
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(72, 11);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(234, 21);
            this.cboAgencia1.TabIndex = 0;
            this.cboAgencia1.SelectedIndexChanged += new System.EventHandler(this.cboAgencia1_SelectedIndexChanged);
            // 
            // frmAprobacionSolRecupera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 377);
            this.Controls.Add(this.cboAgencia1);
            this.Controls.Add(this.lblOficina);
            this.Controls.Add(this.btnBlanco1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboPersonalCargo1);
            this.Controls.Add(this.btnImprimirActa);
            this.Controls.Add(this.btnActualizar1);
            this.Controls.Add(this.btnDenegar1);
            this.Controls.Add(this.btnAprobar1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.dtgSolicitudes);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmAprobacionSolRecupera";
            this.Text = "Aprobación de Solicitud de Recuperación";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.dtgSolicitudes, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnAprobar1, 0);
            this.Controls.SetChildIndex(this.btnDenegar1, 0);
            this.Controls.SetChildIndex(this.btnActualizar1, 0);
            this.Controls.SetChildIndex(this.btnImprimirActa, 0);
            this.Controls.SetChildIndex(this.cboPersonalCargo1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnBlanco1, 0);
            this.Controls.SetChildIndex(this.lblOficina, 0);
            this.Controls.SetChildIndex(this.cboAgencia1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.dtgBase dtgSolicitudes;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnAprobar btnAprobar1;
        private GEN.BotonesBase.btnDenegar btnDenegar1;
        private GEN.BotonesBase.btnActualizar btnActualizar1;
        private GEN.BotonesBase.btnImprimir btnImprimirActa;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboPersonalCargo cboPersonalCargo1;
        private GEN.BotonesBase.btnBlanco btnImprimir;
        private GEN.BotonesBase.btnBlanco btnBlanco1;
        private GEN.ControlesBase.lblBase lblOficina;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
    }
}

