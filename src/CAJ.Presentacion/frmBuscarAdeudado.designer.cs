namespace CAJ.Presentacion
{
    partial class frmBuscarAdeudado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarAdeudado));
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.cboEstado = new GEN.ControlesBase.cboBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtDesccripcionLinea = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase27 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboTipoEntidad = new GEN.ControlesBase.cboTipoEntidad(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.dtgListaAdeudados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaAdeudados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(351, 41);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(50, 13);
            this.lblBase15.TabIndex = 7;
            this.lblBase15.Text = "Estado:";
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(419, 38);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(179, 21);
            this.cboEstado.TabIndex = 8;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(417, 63);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(112, 21);
            this.cboMoneda.TabIndex = 10;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(350, 67);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(56, 13);
            this.lblBase9.TabIndex = 9;
            this.lblBase9.Text = "Moneda:";
            // 
            // txtDesccripcionLinea
            // 
            this.txtDesccripcionLinea.Location = new System.Drawing.Point(101, 91);
            this.txtDesccripcionLinea.Name = "txtDesccripcionLinea";
            this.txtDesccripcionLinea.Size = new System.Drawing.Size(428, 20);
            this.txtDesccripcionLinea.TabIndex = 6;
            // 
            // lblBase27
            // 
            this.lblBase27.AutoSize = true;
            this.lblBase27.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase27.ForeColor = System.Drawing.Color.Navy;
            this.lblBase27.Location = new System.Drawing.Point(12, 91);
            this.lblBase27.Name = "lblBase27";
            this.lblBase27.Size = new System.Drawing.Size(78, 13);
            this.lblBase27.TabIndex = 5;
            this.lblBase27.Text = "Descripción:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 67);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(54, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Entidad:";
            // 
            // cboTipoEntidad
            // 
            this.cboTipoEntidad.FormattingEnabled = true;
            this.cboTipoEntidad.Location = new System.Drawing.Point(101, 38);
            this.cboTipoEntidad.Name = "cboTipoEntidad";
            this.cboTipoEntidad.Size = new System.Drawing.Size(215, 21);
            this.cboTipoEntidad.TabIndex = 2;
            this.cboTipoEntidad.SelectedIndexChanged += new System.EventHandler(this.cboTipoEntidad_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 40);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(82, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Tipo Entidad:";
            // 
            // cboEntidad
            // 
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.Location = new System.Drawing.Point(101, 64);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(215, 21);
            this.cboEntidad.TabIndex = 4;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(472, 287);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(538, 287);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 14;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(538, 61);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 11;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.Location = new System.Drawing.Point(12, 9);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(216, 17);
            this.chcBase1.TabIndex = 0;
            this.chcBase1.Text = "MOSTRAR TODOS LOS ADEUDADOS";
            this.chcBase1.UseVisualStyleBackColor = true;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            // 
            // dtgListaAdeudados
            // 
            this.dtgListaAdeudados.AllowUserToAddRows = false;
            this.dtgListaAdeudados.AllowUserToDeleteRows = false;
            this.dtgListaAdeudados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaAdeudados.Location = new System.Drawing.Point(12, 117);
            this.dtgListaAdeudados.MultiSelect = false;
            this.dtgListaAdeudados.Name = "dtgListaAdeudados";
            this.dtgListaAdeudados.ReadOnly = true;
            this.dtgListaAdeudados.RowHeadersVisible = false;
            this.dtgListaAdeudados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgListaAdeudados.RowTemplate.Height = 18;
            this.dtgListaAdeudados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaAdeudados.Size = new System.Drawing.Size(586, 164);
            this.dtgListaAdeudados.TabIndex = 12;
            // 
            // frmBuscarAdeudado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 362);
            this.Controls.Add(this.dtgListaAdeudados);
            this.Controls.Add(this.chcBase1);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblBase15);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.txtDesccripcionLinea);
            this.Controls.Add(this.lblBase27);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboTipoEntidad);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboEntidad);
            this.Name = "frmBuscarAdeudado";
            this.Text = "Buscar Adeudado";
            this.Load += new System.EventHandler(this.frmBuscarAdeudado_Load);
            this.Controls.SetChildIndex(this.cboEntidad, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboTipoEntidad, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase27, 0);
            this.Controls.SetChildIndex(this.txtDesccripcionLinea, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.cboEstado, 0);
            this.Controls.SetChildIndex(this.lblBase15, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.chcBase1, 0);
            this.Controls.SetChildIndex(this.dtgListaAdeudados, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaAdeudados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.cboBase cboEstado;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtDesccripcionLinea;
        private GEN.ControlesBase.lblBase lblBase27;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboTipoEntidad cboTipoEntidad;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboEntidad cboEntidad;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.chcBase chcBase1;
        private System.Windows.Forms.DataGridView dtgListaAdeudados;
    }
}