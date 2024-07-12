namespace GRH.Presentacion
{
    partial class frmSeleccionPersonalPlanilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionPersonalPlanilla));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtNroSelec = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroNoSelec = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnQuitarTodos = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregarTodos = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dtgSeleccionados = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgtxtIdUsuarioSelec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdRelacionLabSelec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtNombreSelec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgNoSeleccionados = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgtxtIdUsuarioNoSelec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdRelacionLabNoSelec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtNombreNoSelec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSeleccionados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNoSeleccionados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(455, 399);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(521, 399);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblBase2);
            this.panel1.Controls.Add(this.txtNroSelec);
            this.panel1.Controls.Add(this.txtNroNoSelec);
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Controls.Add(this.btnQuitarTodos);
            this.panel1.Controls.Add(this.btnQuitar);
            this.panel1.Controls.Add(this.btnAgregarTodos);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.dtgSeleccionados);
            this.panel1.Controls.Add(this.dtgNoSeleccionados);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 385);
            this.panel1.TabIndex = 14;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(319, 362);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(142, 13);
            this.lblBase2.TabIndex = 23;
            this.lblBase2.Text = "Número Seleccionados:";
            // 
            // txtNroSelec
            // 
            this.txtNroSelec.Enabled = false;
            this.txtNroSelec.Location = new System.Drawing.Point(482, 358);
            this.txtNroSelec.Name = "txtNroSelec";
            this.txtNroSelec.Size = new System.Drawing.Size(90, 20);
            this.txtNroSelec.TabIndex = 22;
            // 
            // txtNroNoSelec
            // 
            this.txtNroNoSelec.Enabled = false;
            this.txtNroNoSelec.Location = new System.Drawing.Point(165, 358);
            this.txtNroNoSelec.Name = "txtNroNoSelec";
            this.txtNroNoSelec.Size = new System.Drawing.Size(90, 20);
            this.txtNroNoSelec.TabIndex = 21;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(2, 362);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(161, 13);
            this.lblBase1.TabIndex = 20;
            this.lblBase1.Text = "Número No Seleccionados:";
            // 
            // btnQuitarTodos
            // 
            this.btnQuitarTodos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitarTodos.Location = new System.Drawing.Point(258, 253);
            this.btnQuitarTodos.Name = "btnQuitarTodos";
            this.btnQuitarTodos.Size = new System.Drawing.Size(60, 50);
            this.btnQuitarTodos.TabIndex = 19;
            this.btnQuitarTodos.Text = "Quitar Todos";
            this.btnQuitarTodos.UseVisualStyleBackColor = true;
            this.btnQuitarTodos.Click += new System.EventHandler(this.btnQuitarTodos_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Location = new System.Drawing.Point(258, 195);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar.TabIndex = 18;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregarTodos
            // 
            this.btnAgregarTodos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarTodos.Location = new System.Drawing.Point(258, 79);
            this.btnAgregarTodos.Name = "btnAgregarTodos";
            this.btnAgregarTodos.Size = new System.Drawing.Size(60, 50);
            this.btnAgregarTodos.TabIndex = 17;
            this.btnAgregarTodos.Text = "Agregar Todos";
            this.btnAgregarTodos.UseVisualStyleBackColor = true;
            this.btnAgregarTodos.Click += new System.EventHandler(this.btnAgregarTodos_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Location = new System.Drawing.Point(258, 137);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar.TabIndex = 16;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dtgSeleccionados
            // 
            this.dtgSeleccionados.AllowUserToAddRows = false;
            this.dtgSeleccionados.AllowUserToDeleteRows = false;
            this.dtgSeleccionados.AllowUserToResizeColumns = false;
            this.dtgSeleccionados.AllowUserToResizeRows = false;
            this.dtgSeleccionados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSeleccionados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSeleccionados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdUsuarioSelec,
            this.dtgtxtIdRelacionLabSelec,
            this.dtgtxtNombreSelec});
            this.dtgSeleccionados.Location = new System.Drawing.Point(322, 5);
            this.dtgSeleccionados.MultiSelect = false;
            this.dtgSeleccionados.Name = "dtgSeleccionados";
            this.dtgSeleccionados.ReadOnly = true;
            this.dtgSeleccionados.RowHeadersVisible = false;
            this.dtgSeleccionados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSeleccionados.Size = new System.Drawing.Size(250, 350);
            this.dtgSeleccionados.TabIndex = 15;
            // 
            // dtgtxtIdUsuarioSelec
            // 
            this.dtgtxtIdUsuarioSelec.DataPropertyName = "idUsuario";
            this.dtgtxtIdUsuarioSelec.HeaderText = "idUsuario";
            this.dtgtxtIdUsuarioSelec.Name = "dtgtxtIdUsuarioSelec";
            this.dtgtxtIdUsuarioSelec.ReadOnly = true;
            this.dtgtxtIdUsuarioSelec.Visible = false;
            // 
            // dtgtxtIdRelacionLabSelec
            // 
            this.dtgtxtIdRelacionLabSelec.DataPropertyName = "idRelacionLab";
            this.dtgtxtIdRelacionLabSelec.HeaderText = "idRelacionLab";
            this.dtgtxtIdRelacionLabSelec.Name = "dtgtxtIdRelacionLabSelec";
            this.dtgtxtIdRelacionLabSelec.ReadOnly = true;
            this.dtgtxtIdRelacionLabSelec.Visible = false;
            // 
            // dtgtxtNombreSelec
            // 
            this.dtgtxtNombreSelec.DataPropertyName = "cNombre";
            this.dtgtxtNombreSelec.HeaderText = "Seleccionados";
            this.dtgtxtNombreSelec.Name = "dtgtxtNombreSelec";
            this.dtgtxtNombreSelec.ReadOnly = true;
            // 
            // dtgNoSeleccionados
            // 
            this.dtgNoSeleccionados.AllowUserToAddRows = false;
            this.dtgNoSeleccionados.AllowUserToDeleteRows = false;
            this.dtgNoSeleccionados.AllowUserToResizeColumns = false;
            this.dtgNoSeleccionados.AllowUserToResizeRows = false;
            this.dtgNoSeleccionados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgNoSeleccionados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgNoSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNoSeleccionados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdUsuarioNoSelec,
            this.dtgtxtIdRelacionLabNoSelec,
            this.dtgtxtNombreNoSelec});
            this.dtgNoSeleccionados.Location = new System.Drawing.Point(5, 5);
            this.dtgNoSeleccionados.MultiSelect = false;
            this.dtgNoSeleccionados.Name = "dtgNoSeleccionados";
            this.dtgNoSeleccionados.ReadOnly = true;
            this.dtgNoSeleccionados.RowHeadersVisible = false;
            this.dtgNoSeleccionados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNoSeleccionados.Size = new System.Drawing.Size(250, 350);
            this.dtgNoSeleccionados.TabIndex = 14;
            // 
            // dtgtxtIdUsuarioNoSelec
            // 
            this.dtgtxtIdUsuarioNoSelec.DataPropertyName = "idUsuario";
            this.dtgtxtIdUsuarioNoSelec.HeaderText = "idUsuario";
            this.dtgtxtIdUsuarioNoSelec.Name = "dtgtxtIdUsuarioNoSelec";
            this.dtgtxtIdUsuarioNoSelec.ReadOnly = true;
            this.dtgtxtIdUsuarioNoSelec.Visible = false;
            // 
            // dtgtxtIdRelacionLabNoSelec
            // 
            this.dtgtxtIdRelacionLabNoSelec.DataPropertyName = "idRelacionLab";
            this.dtgtxtIdRelacionLabNoSelec.HeaderText = "idRelacionLab";
            this.dtgtxtIdRelacionLabNoSelec.Name = "dtgtxtIdRelacionLabNoSelec";
            this.dtgtxtIdRelacionLabNoSelec.ReadOnly = true;
            this.dtgtxtIdRelacionLabNoSelec.Visible = false;
            // 
            // dtgtxtNombreNoSelec
            // 
            this.dtgtxtNombreNoSelec.DataPropertyName = "cNombre";
            this.dtgtxtNombreNoSelec.HeaderText = "No Seleccionados";
            this.dtgtxtNombreNoSelec.Name = "dtgtxtNombreNoSelec";
            this.dtgtxtNombreNoSelec.ReadOnly = true;
            // 
            // frmSeleccionPersonalPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 476);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MinimizeBox = true;
            this.Name = "frmSeleccionPersonalPlanilla";
            this.Text = "Selección de Personal";
            this.Load += new System.EventHandler(this.frmSeleccionPersonalPlanilla_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSeleccionados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNoSeleccionados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtNroSelec;
        private GEN.ControlesBase.txtBase txtNroNoSelec;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.Button btnQuitarTodos;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregarTodos;
        private System.Windows.Forms.Button btnAgregar;
        private GEN.ControlesBase.dtgBase dtgSeleccionados;
        private GEN.ControlesBase.dtgBase dtgNoSeleccionados;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdUsuarioSelec;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdRelacionLabSelec;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtNombreSelec;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdUsuarioNoSelec;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdRelacionLabNoSelec;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtNombreNoSelec;
    }
}

