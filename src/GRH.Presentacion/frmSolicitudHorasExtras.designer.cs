namespace GRH.Presentacion
{
    partial class frmSolicitudHorasExtras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudHorasExtras));
            this.conBusColaborador = new GEN.ControlesBase.ConBusCol();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinutos = new GEN.ControlesBase.txtBase(this.components);
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtHoraFin = new GEN.ControlesBase.dtLargoBase(this.components);
            this.dtHoraInicio = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dtFechaFin = new GEN.ControlesBase.dtLargoBase(this.components);
            this.dtFechaInicio = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnEnviar1 = new GEN.BotonesBase.btnEnviar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.txtOpinion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusColaborador
            // 
            this.conBusColaborador.cEstado = "0";
            this.conBusColaborador.Location = new System.Drawing.Point(25, 17);
            this.conBusColaborador.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.conBusColaborador.Name = "conBusColaborador";
            this.conBusColaborador.Size = new System.Drawing.Size(520, 106);
            this.conBusColaborador.TabIndex = 2;
            this.conBusColaborador.BuscarUsuario += new System.EventHandler(this.conBusCol1_BuscarUsuario);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(21, 368);
            this.lblBase1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(685, 17);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Solicitudes Pendientes, aprobadas y rechazadas (sólo las correspondientes al peri" +
    "odo Vigente): ";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.label1);
            this.grbBase1.Controls.Add(this.txtMinutos);
            this.grbBase1.Controls.Add(this.txtDescripcion);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.dtHoraFin);
            this.grbBase1.Controls.Add(this.dtHoraInicio);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.dtFechaFin);
            this.grbBase1.Controls.Add(this.dtFechaInicio);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(25, 133);
            this.grbBase1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbBase1.Size = new System.Drawing.Size(772, 225);
            this.grbBase1.TabIndex = 4;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de la Solicitud";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(37, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 21);
            this.label1.TabIndex = 109;
            this.label1.Text = "Tiempo Extra (Minutos):";
            // 
            // txtMinutos
            // 
            this.txtMinutos.Enabled = false;
            this.txtMinutos.Location = new System.Drawing.Point(219, 94);
            this.txtMinutos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMinutos.Name = "txtMinutos";
            this.txtMinutos.Size = new System.Drawing.Size(155, 22);
            this.txtMinutos.TabIndex = 108;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(41, 149);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescripcion.MaxLength = 200;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(699, 53);
            this.txtDescripcion.TabIndex = 106;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(37, 129);
            this.lblBase6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(147, 17);
            this.lblBase6.TabIndex = 14;
            this.lblBase6.Text = "Actividad Realizada:";
            // 
            // dtHoraFin
            // 
            this.dtHoraFin.CustomFormat = "hh:mm tt";
            this.dtHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHoraFin.Location = new System.Drawing.Point(615, 62);
            this.dtHoraFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtHoraFin.Name = "dtHoraFin";
            this.dtHoraFin.ShowUpDown = true;
            this.dtHoraFin.Size = new System.Drawing.Size(125, 22);
            this.dtHoraFin.TabIndex = 13;
            // 
            // dtHoraInicio
            // 
            this.dtHoraInicio.CustomFormat = "hh:mm tt";
            this.dtHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHoraInicio.Location = new System.Drawing.Point(615, 30);
            this.dtHoraInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtHoraInicio.Name = "dtHoraInicio";
            this.dtHoraInicio.ShowUpDown = true;
            this.dtHoraInicio.Size = new System.Drawing.Size(125, 22);
            this.dtHoraInicio.TabIndex = 12;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(476, 65);
            this.lblBase4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(115, 17);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Hora de Salida:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(476, 33);
            this.lblBase5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(110, 17);
            this.lblBase5.TabIndex = 10;
            this.lblBase5.Text = "Hora de Inicio:";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(219, 62);
            this.dtFechaFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(155, 22);
            this.dtFechaFin.TabIndex = 9;
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(219, 30);
            this.dtFechaInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(155, 22);
            this.dtFechaInicio.TabIndex = 8;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(37, 65);
            this.lblBase3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(122, 17);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Fecha de Salida:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(37, 33);
            this.lblBase2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(117, 17);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Fecha de Inicio:";
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(25, 388);
            this.dtgBase1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase1.Size = new System.Drawing.Size(772, 156);
            this.dtgBase1.TabIndex = 5;
            this.dtgBase1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBase1_RowEnter);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(717, 551);
            this.btnSalir1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Enabled = false;
            this.btnNuevo1.Location = new System.Drawing.Point(465, 551);
            this.btnNuevo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 7;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnEnviar1
            // 
            this.btnEnviar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar1.BackgroundImage")));
            this.btnEnviar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar1.Enabled = false;
            this.btnEnviar1.Location = new System.Drawing.Point(549, 551);
            this.btnEnviar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnviar1.Name = "btnEnviar1";
            this.btnEnviar1.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar1.TabIndex = 8;
            this.btnEnviar1.Text = "&Enviar";
            this.btnEnviar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar1.UseVisualStyleBackColor = true;
            this.btnEnviar1.Click += new System.EventHandler(this.btnEnviar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(633, 551);
            this.btnCancelar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 9;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // txtOpinion
            // 
            this.txtOpinion.Enabled = false;
            this.txtOpinion.Location = new System.Drawing.Point(25, 568);
            this.txtOpinion.Margin = new System.Windows.Forms.Padding(4);
            this.txtOpinion.MaxLength = 200;
            this.txtOpinion.Multiline = true;
            this.txtOpinion.Name = "txtOpinion";
            this.txtOpinion.Size = new System.Drawing.Size(329, 42);
            this.txtOpinion.TabIndex = 108;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(21, 548);
            this.lblBase7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(230, 17);
            this.lblBase7.TabIndex = 107;
            this.lblBase7.Text = "Descripción Opinión del Aprob.:";
            // 
            // frmSolicitudHorasExtras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 645);
            this.Controls.Add(this.txtOpinion);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEnviar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgBase1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.conBusColaborador);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmSolicitudHorasExtras";
            this.Text = "Solicitud de Horas Extras";
            this.Load += new System.EventHandler(this.frmSolicitudHorasExtras_Load);
            this.Controls.SetChildIndex(this.conBusColaborador, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnEnviar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.txtOpinion, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCol conBusColaborador;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtLargoBase dtFechaFin;
        private GEN.ControlesBase.dtLargoBase dtFechaInicio;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgBase1;
        private GEN.ControlesBase.dtLargoBase dtHoraFin;
        private GEN.ControlesBase.dtLargoBase dtHoraInicio;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnEnviar btnEnviar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.txtBase txtMinutos;
        private GEN.ControlesBase.txtBase txtOpinion;
        private GEN.ControlesBase.lblBase lblBase7;
    }
}