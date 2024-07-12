using System.Windows.Forms;
namespace CLI.Presentacion
{
    partial class frmProgFidelizacionClie
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProgFidelizacionClie));
            this.tbcCliente = new GEN.ControlesBase.tbcBase(this.components);
            this.tabReferidos = new System.Windows.Forms.TabPage();
            this.dtgReferidos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAgregar = new GEN.BotonesBase.btnAgregar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.conBusCliente = new GEN.ControlesBase.ConBusCli();
            this.conSplaf1 = new GEN.ControlesBase.conSplaf();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtAgencia = new GEN.ControlesBase.txtBase(this.components);
            this.txtAsesor = new GEN.ControlesBase.txtBase(this.components);
            this.txtEstado = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtCalificacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase30 = new GEN.ControlesBase.lblBase();
            this.tbcCliente.SuspendLayout();
            this.tabReferidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReferidos)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcCliente
            // 
            this.tbcCliente.Controls.Add(this.tabReferidos);
            this.tbcCliente.Location = new System.Drawing.Point(6, 208);
            this.tbcCliente.Name = "tbcCliente";
            this.tbcCliente.SelectedIndex = 0;
            this.tbcCliente.Size = new System.Drawing.Size(709, 275);
            this.tbcCliente.TabIndex = 6;
            // 
            // tabReferidos
            // 
            this.tabReferidos.Controls.Add(this.dtgReferidos);
            this.tabReferidos.Controls.Add(this.btnAgregar);
            this.tabReferidos.Controls.Add(this.btnEditar);
            this.tabReferidos.Location = new System.Drawing.Point(4, 22);
            this.tabReferidos.Name = "tabReferidos";
            this.tabReferidos.Padding = new System.Windows.Forms.Padding(3);
            this.tabReferidos.Size = new System.Drawing.Size(701, 249);
            this.tabReferidos.TabIndex = 3;
            this.tabReferidos.Text = "Registro de Referidos de Cliente";
            this.tabReferidos.UseVisualStyleBackColor = true;
            // 
            // dtgReferidos
            // 
            this.dtgReferidos.AllowUserToAddRows = false;
            this.dtgReferidos.AllowUserToDeleteRows = false;
            this.dtgReferidos.AllowUserToResizeColumns = false;
            this.dtgReferidos.AllowUserToResizeRows = false;
            this.dtgReferidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgReferidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgReferidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgReferidos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgReferidos.Location = new System.Drawing.Point(13, 17);
            this.dtgReferidos.MultiSelect = false;
            this.dtgReferidos.Name = "dtgReferidos";
            this.dtgReferidos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgReferidos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgReferidos.RowHeadersVisible = false;
            this.dtgReferidos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgReferidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReferidos.Size = new System.Drawing.Size(619, 219);
            this.dtgReferidos.TabIndex = 9;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(638, 17);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(638, 64);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // conBusCliente
            // 
            this.conBusCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCliente.idCli = 0;
            this.conBusCliente.Location = new System.Drawing.Point(6, 27);
            this.conBusCliente.Margin = new System.Windows.Forms.Padding(4);
            this.conBusCliente.Name = "conBusCliente";
            this.conBusCliente.Size = new System.Drawing.Size(535, 182);
            this.conBusCliente.TabIndex = 0;
            this.conBusCliente.ClicBuscar += new System.EventHandler(this.conBusCliente_ClicBuscar);
            // 
            // conSplaf1
            // 
            this.conSplaf1.AutoSize = true;
            this.conSplaf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.conSplaf1.ForeColor = System.Drawing.Color.Red;
            this.conSplaf1.Location = new System.Drawing.Point(4, 655);
            this.conSplaf1.Name = "conSplaf1";
            this.conSplaf1.Size = new System.Drawing.Size(19, 20);
            this.conSplaf1.TabIndex = 2;
            this.conSplaf1.Text = "_";
            this.conSplaf1.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(648, 489);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(511, 489);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(581, 489);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(19, 138);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(51, 13);
            this.lblBase3.TabIndex = 13;
            this.lblBase3.Text = "Oficina:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(19, 160);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 14;
            this.lblBase1.Text = "Asesor:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(19, 184);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(139, 13);
            this.lblBase2.TabIndex = 15;
            this.lblBase2.Text = "Estado los Andes Club:";
            // 
            // txtAgencia
            // 
            this.txtAgencia.Enabled = false;
            this.txtAgencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgencia.Location = new System.Drawing.Point(169, 136);
            this.txtAgencia.MaxLength = 10;
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Size = new System.Drawing.Size(184, 19);
            this.txtAgencia.TabIndex = 16;
            // 
            // txtAsesor
            // 
            this.txtAsesor.Enabled = false;
            this.txtAsesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsesor.Location = new System.Drawing.Point(169, 160);
            this.txtAsesor.MaxLength = 10;
            this.txtAsesor.Name = "txtAsesor";
            this.txtAsesor.Size = new System.Drawing.Size(357, 19);
            this.txtAsesor.TabIndex = 17;
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(169, 184);
            this.txtEstado.MaxLength = 10;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(184, 19);
            this.txtEstado.TabIndex = 18;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(586, 10);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(104, 13);
            this.lblBase5.TabIndex = 21;
            this.lblBase5.Text = "Los Andes Club :";
            // 
            // txtCalificacion
            // 
            this.txtCalificacion.Enabled = false;
            this.txtCalificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalificacion.Location = new System.Drawing.Point(556, 27);
            this.txtCalificacion.MaxLength = 10;
            this.txtCalificacion.Multiline = true;
            this.txtCalificacion.Name = "txtCalificacion";
            this.txtCalificacion.Size = new System.Drawing.Size(156, 44);
            this.txtCalificacion.TabIndex = 22;
            this.txtCalificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase30
            // 
            this.lblBase30.AutoSize = true;
            this.lblBase30.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase30.ForeColor = System.Drawing.Color.Navy;
            this.lblBase30.Location = new System.Drawing.Point(7, 10);
            this.lblBase30.Name = "lblBase30";
            this.lblBase30.Size = new System.Drawing.Size(104, 13);
            this.lblBase30.TabIndex = 47;
            this.lblBase30.Text = "Los Andes Club :";
            // 
            // frmProgFidelizacionClie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 574);
            this.Controls.Add(this.lblBase30);
            this.Controls.Add(this.txtCalificacion);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtAsesor);
            this.Controls.Add(this.txtAgencia);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.conSplaf1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.conBusCliente);
            this.Controls.Add(this.tbcCliente);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProgFidelizacionClie";
            this.Text = "Fidelización de Clientes";
            this.Load += new System.EventHandler(this.frmProgFidelizacionClie_Load);
            this.Controls.SetChildIndex(this.tbcCliente, 0);
            this.Controls.SetChildIndex(this.conBusCliente, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.conSplaf1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtAgencia, 0);
            this.Controls.SetChildIndex(this.txtAsesor, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtCalificacion, 0);
            this.Controls.SetChildIndex(this.lblBase30, 0);
            this.tbcCliente.ResumeLayout(false);
            this.tabReferidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReferidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.tbcBase tbcCliente;
        private System.Windows.Forms.TabPage tabReferidos;
        private GEN.ControlesBase.ConBusCli conBusCliente;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnAgregar btnAgregar;
        private GEN.ControlesBase.dtgBase dtgReferidos;
        private GEN.ControlesBase.conSplaf conSplaf1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtAgencia;
        private GEN.ControlesBase.txtBase txtAsesor;
        private GEN.ControlesBase.txtBase txtEstado;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtCalificacion;
        private GEN.ControlesBase.lblBase lblBase30;
        //private GEN.ControlesBase.cboTipDocumento cboTipDocumento2;
    }
}
