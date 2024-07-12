namespace CRE.Presentacion
{
    partial class frmCargarMatrizAgricola
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargarMatrizAgricola));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegistrarMatriz = new System.Windows.Forms.Button();
            this.dtgRegistro = new GEN.ControlesBase.dtgBase(this.components);
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblNombreArchivo = new GEN.ControlesBase.lblBase();
            this.btnSeleccionarArchivo = new System.Windows.Forms.Button();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegistro)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnRegistrarMatriz);
            this.panel1.Controls.Add(this.dtgRegistro);
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Controls.Add(this.lblNombreArchivo);
            this.panel1.Controls.Add(this.btnSeleccionarArchivo);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 267);
            this.panel1.TabIndex = 2;
            // 
            // btnRegistrarMatriz
            // 
            this.btnRegistrarMatriz.Location = new System.Drawing.Point(456, 17);
            this.btnRegistrarMatriz.Name = "btnRegistrarMatriz";
            this.btnRegistrarMatriz.Size = new System.Drawing.Size(207, 23);
            this.btnRegistrarMatriz.TabIndex = 10;
            this.btnRegistrarMatriz.Text = "Registrar Matriz Agrícola";
            this.btnRegistrarMatriz.UseVisualStyleBackColor = true;
            this.btnRegistrarMatriz.Click += new System.EventHandler(this.btnRegistrarMatriz_Click);
            // 
            // dtgRegistro
            // 
            this.dtgRegistro.AllowUserToAddRows = false;
            this.dtgRegistro.AllowUserToDeleteRows = false;
            this.dtgRegistro.AllowUserToResizeColumns = false;
            this.dtgRegistro.AllowUserToResizeRows = false;
            this.dtgRegistro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRegistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRegistro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usuario,
            this.agencia,
            this.perfil,
            this.fecha_hora});
            this.dtgRegistro.Location = new System.Drawing.Point(23, 82);
            this.dtgRegistro.MultiSelect = false;
            this.dtgRegistro.Name = "dtgRegistro";
            this.dtgRegistro.ReadOnly = true;
            this.dtgRegistro.RowHeadersVisible = false;
            this.dtgRegistro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRegistro.Size = new System.Drawing.Size(640, 150);
            this.dtgRegistro.TabIndex = 8;
            // 
            // usuario
            // 
            this.usuario.DataPropertyName = "cUsuario";
            this.usuario.FillWeight = 121.8274F;
            this.usuario.HeaderText = "Usuario";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            // 
            // agencia
            // 
            this.agencia.DataPropertyName = "cAgencia";
            this.agencia.HeaderText = "Agencia";
            this.agencia.Name = "agencia";
            this.agencia.ReadOnly = true;
            this.agencia.Visible = false;
            // 
            // perfil
            // 
            this.perfil.DataPropertyName = "cPerfil";
            this.perfil.FillWeight = 105.3466F;
            this.perfil.HeaderText = "Perfil";
            this.perfil.Name = "perfil";
            this.perfil.ReadOnly = true;
            // 
            // fecha_hora
            // 
            this.fecha_hora.DataPropertyName = "dFechaHoraRegistro";
            this.fecha_hora.FillWeight = 72.82603F;
            this.fecha_hora.HeaderText = "Fecha y Hora de Registro";
            this.fecha_hora.Name = "fecha_hora";
            this.fecha_hora.ReadOnly = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(20, 63);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(128, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Historial de Registros";
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNombreArchivo.ForeColor = System.Drawing.Color.Navy;
            this.lblNombreArchivo.Location = new System.Drawing.Point(236, 22);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(120, 13);
            this.lblNombreArchivo.TabIndex = 1;
            this.lblNombreArchivo.Text = "Nombre del Archivo";
            // 
            // btnSeleccionarArchivo
            // 
            this.btnSeleccionarArchivo.Location = new System.Drawing.Point(23, 17);
            this.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            this.btnSeleccionarArchivo.Size = new System.Drawing.Size(207, 23);
            this.btnSeleccionarArchivo.TabIndex = 0;
            this.btnSeleccionarArchivo.Text = "Seleccionar Archivo EXCEL";
            this.btnSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.btnSeleccionarArchivo.Click += new System.EventHandler(this.btnSeleccionarArchivo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(628, 275);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 103;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmCargarMatrizAgricola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 354);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panel1);
            this.Name = "frmCargarMatrizAgricola";
            this.Text = "Cargar Matriz Agrícola";
            this.Load += new System.EventHandler(this.frmCargarMatrizAgricola_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegistro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GEN.ControlesBase.lblBase lblNombreArchivo;
        private System.Windows.Forms.Button btnSeleccionarArchivo;
        private GEN.ControlesBase.dtgBase dtgRegistro;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.Button btnRegistrarMatriz;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn agencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn perfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_hora;
        private GEN.BotonesBase.btnSalir btnSalir;

    }
}