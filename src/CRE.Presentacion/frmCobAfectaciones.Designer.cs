namespace CRE.Presentacion
{
    partial class frmCobAfectaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobAfectaciones));
            this.lEditado = new GEN.ControlesBase.chcBase(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.txtCorrectos = new GEN.ControlesBase.txtBase(this.components);
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            this.txtIncorrectos = new GEN.ControlesBase.txtBase(this.components);
            this.dtgCobs = new GEN.ControlesBase.dtgBase(this.components);
            this.txtTotal = new GEN.ControlesBase.txtBase(this.components);
            this.txtIdCliente = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.dtgCobsError = new GEN.ControlesBase.dtgBase(this.components);
            this.btnExporExcel2 = new GEN.BotonesBase.btnExporExcel();
            this.btnAceptarCob = new GEN.BotonesBase.BtnAceptar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.txtComentario = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.chcExportExcel = new GEN.ControlesBase.chcBase(this.components);
            this.txtMontoTotal = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtIdKardex = new GEN.ControlesBase.txtBase(this.components);
            this.txtIdCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.txtIdGrupo = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCobs)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCobsError)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lEditado
            // 
            this.lEditado.AutoSize = true;
            this.lEditado.ForeColor = System.Drawing.Color.Navy;
            this.lEditado.Location = new System.Drawing.Point(0, 30);
            this.lEditado.Name = "lEditado";
            this.lEditado.Size = new System.Drawing.Size(102, 17);
            this.lEditado.TabIndex = 13;
            this.lEditado.Text = "Habilitar Edicion";
            this.lEditado.UseVisualStyleBackColor = false;
            this.lEditado.CheckedChanged += new System.EventHandler(this.lEditado_CheckedChanged);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(300, 2);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 9;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 256);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(68, 13);
            this.lblBase2.TabIndex = 15;
            this.lblBase2.Text = "Correctos:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(916, 254);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(3, 273);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(77, 13);
            this.lblBase3.TabIndex = 16;
            this.lblBase3.Text = "Incorrectos:";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(171, 0);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 7;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(39, 291);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(40, 13);
            this.lblBase4.TabIndex = 17;
            this.lblBase4.Text = "Total:";
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(237, 0);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 6;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // txtCorrectos
            // 
            this.txtCorrectos.Enabled = false;
            this.txtCorrectos.Location = new System.Drawing.Point(81, 252);
            this.txtCorrectos.Name = "txtCorrectos";
            this.txtCorrectos.Size = new System.Drawing.Size(38, 20);
            this.txtCorrectos.TabIndex = 18;
            this.txtCorrectos.Text = "0";
            this.txtCorrectos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(105, 0);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 5;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = true;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click);
            // 
            // txtIncorrectos
            // 
            this.txtIncorrectos.Enabled = false;
            this.txtIncorrectos.Location = new System.Drawing.Point(81, 269);
            this.txtIncorrectos.Name = "txtIncorrectos";
            this.txtIncorrectos.Size = new System.Drawing.Size(38, 20);
            this.txtIncorrectos.TabIndex = 19;
            this.txtIncorrectos.Text = "0";
            this.txtIncorrectos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtgCobs
            // 
            this.dtgCobs.AllowUserToAddRows = false;
            this.dtgCobs.AllowUserToDeleteRows = false;
            this.dtgCobs.AllowUserToResizeColumns = false;
            this.dtgCobs.AllowUserToResizeRows = false;
            this.dtgCobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCobs.Location = new System.Drawing.Point(9, 42);
            this.dtgCobs.MultiSelect = false;
            this.dtgCobs.Name = "dtgCobs";
            this.dtgCobs.ReadOnly = true;
            this.dtgCobs.RowHeadersVisible = false;
            this.dtgCobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCobs.Size = new System.Drawing.Size(974, 207);
            this.dtgCobs.TabIndex = 2;
            this.dtgCobs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCobs_CellClick);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(81, 286);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(38, 20);
            this.txtTotal.TabIndex = 20;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(10, 19);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(54, 20);
            this.txtIdCliente.TabIndex = 11;
            this.txtIdCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codCliente_KeyPress);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 3);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(52, 13);
            this.lblBase1.TabIndex = 12;
            this.lblBase1.Text = "Cliente:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panelContent);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 311);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(983, 199);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.dtgCobsError);
            this.panelContent.Controls.Add(this.btnExporExcel2);
            this.panelContent.Controls.Add(this.btnAceptarCob);
            this.panelContent.Location = new System.Drawing.Point(3, 3);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(977, 193);
            this.panelContent.TabIndex = 1;
            this.panelContent.Visible = false;
            // 
            // dtgCobsError
            // 
            this.dtgCobsError.AllowUserToAddRows = false;
            this.dtgCobsError.AllowUserToDeleteRows = false;
            this.dtgCobsError.AllowUserToResizeColumns = false;
            this.dtgCobsError.AllowUserToResizeRows = false;
            this.dtgCobsError.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCobsError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCobsError.Location = new System.Drawing.Point(3, 4);
            this.dtgCobsError.MultiSelect = false;
            this.dtgCobsError.Name = "dtgCobsError";
            this.dtgCobsError.ReadOnly = true;
            this.dtgCobsError.RowHeadersVisible = false;
            this.dtgCobsError.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCobsError.Size = new System.Drawing.Size(971, 129);
            this.dtgCobsError.TabIndex = 2;
            this.dtgCobsError.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCobsError_CellClick);
            // 
            // btnExporExcel2
            // 
            this.btnExporExcel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel2.BackgroundImage")));
            this.btnExporExcel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel2.Location = new System.Drawing.Point(912, 139);
            this.btnExporExcel2.Name = "btnExporExcel2";
            this.btnExporExcel2.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel2.TabIndex = 1;
            this.btnExporExcel2.Text = "E&xcel";
            this.btnExporExcel2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel2.UseVisualStyleBackColor = true;
            this.btnExporExcel2.Click += new System.EventHandler(this.btnExporExcel2_Click);
            // 
            // btnAceptarCob
            // 
            this.btnAceptarCob.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptarCob.BackgroundImage")));
            this.btnAceptarCob.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptarCob.Location = new System.Drawing.Point(845, 139);
            this.btnAceptarCob.Name = "btnAceptarCob";
            this.btnAceptarCob.Size = new System.Drawing.Size(60, 50);
            this.btnAceptarCob.TabIndex = 0;
            this.btnAceptarCob.Text = "&Aceptar";
            this.btnAceptarCob.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptarCob.UseVisualStyleBackColor = true;
            this.btnAceptarCob.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.txtComentario);
            this.panel1.Controls.Add(this.lblBase8);
            this.panel1.Controls.Add(this.panelBotones);
            this.panel1.Controls.Add(this.txtMontoTotal);
            this.panel1.Controls.Add(this.btnSalir1);
            this.panel1.Controls.Add(this.lblBase9);
            this.panel1.Controls.Add(this.lblBase2);
            this.panel1.Controls.Add(this.lblBase3);
            this.panel1.Controls.Add(this.lblBase4);
            this.panel1.Controls.Add(this.txtCorrectos);
            this.panel1.Controls.Add(this.lblBase7);
            this.panel1.Controls.Add(this.txtIncorrectos);
            this.panel1.Controls.Add(this.lblBase6);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.txtIdKardex);
            this.panel1.Controls.Add(this.txtIdCuenta);
            this.panel1.Controls.Add(this.txtIdGrupo);
            this.panel1.Controls.Add(this.lblBase5);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.lblBase1);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Controls.Add(this.dtgCobs);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 513);
            this.panel1.TabIndex = 21;
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.lEditado);
            this.panelBotones.Controls.Add(this.btnImprimir1);
            this.panelBotones.Controls.Add(this.btnCancelar1);
            this.panelBotones.Controls.Add(this.chcExportExcel);
            this.panelBotones.Controls.Add(this.btnGrabar1);
            this.panelBotones.Controls.Add(this.btnExporExcel1);
            this.panelBotones.Location = new System.Drawing.Point(551, 253);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(363, 59);
            this.panelBotones.TabIndex = 33;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(268, 256);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(210, 47);
            this.txtComentario.TabIndex = 28;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(190, 259);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(79, 13);
            this.lblBase8.TabIndex = 29;
            this.lblBase8.Text = "Comentario:";
            // 
            // chcExportExcel
            // 
            this.chcExportExcel.AutoSize = true;
            this.chcExportExcel.Location = new System.Drawing.Point(0, 6);
            this.chcExportExcel.Name = "chcExportExcel";
            this.chcExportExcel.Size = new System.Drawing.Size(103, 17);
            this.chcExportExcel.TabIndex = 27;
            this.chcExportExcel.Text = "Exportar a Excel";
            this.chcExportExcel.UseVisualStyleBackColor = true;
            this.chcExportExcel.CheckedChanged += new System.EventHandler(this.chcExportExcel_CheckedChanged);
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Format = "n2";
            this.txtMontoTotal.Location = new System.Drawing.Point(616, 19);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(100, 20);
            this.txtMontoTotal.TabIndex = 32;
            this.txtMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(624, 3);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(78, 13);
            this.lblBase9.TabIndex = 30;
            this.lblBase9.Text = "Monto Total:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(159, 3);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(70, 13);
            this.lblBase7.TabIndex = 26;
            this.lblBase7.Text = "Operacion:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(83, 3);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(54, 13);
            this.lblBase6.TabIndex = 25;
            this.lblBase6.Text = "Credito:";
            // 
            // txtIdKardex
            // 
            this.txtIdKardex.Location = new System.Drawing.Point(167, 19);
            this.txtIdKardex.Name = "txtIdKardex";
            this.txtIdKardex.Size = new System.Drawing.Size(54, 20);
            this.txtIdKardex.TabIndex = 24;
            this.txtIdKardex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdKardex_KeyPress);
            // 
            // txtIdCuenta
            // 
            this.txtIdCuenta.Location = new System.Drawing.Point(86, 19);
            this.txtIdCuenta.Name = "txtIdCuenta";
            this.txtIdCuenta.Size = new System.Drawing.Size(54, 20);
            this.txtIdCuenta.TabIndex = 23;
            this.txtIdCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdCuenta_KeyPress);
            // 
            // txtIdGrupo
            // 
            this.txtIdGrupo.Format = "n2";
            this.txtIdGrupo.Location = new System.Drawing.Point(760, 19);
            this.txtIdGrupo.Name = "txtIdGrupo";
            this.txtIdGrupo.Size = new System.Drawing.Size(87, 20);
            this.txtIdGrupo.TabIndex = 22;
            this.txtIdGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdGrupo_KeyPress);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(757, 3);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(90, 13);
            this.lblBase5.TabIndex = 21;
            this.lblBase5.Text = "Buscar Grupo:";
            // 
            // frmCobAfectaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(988, 538);
            this.Controls.Add(this.panel1);
            this.Name = "frmCobAfectaciones";
            this.Text = "COB\'s para Afectaciones";
            this.Load += new System.EventHandler(this.frmCobAfectaciones_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCobs)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCobsError)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelBotones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.chcBase lEditado;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.txtBase txtCorrectos;
        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
        private GEN.ControlesBase.txtBase txtIncorrectos;
        private GEN.ControlesBase.dtgBase dtgCobs;
        private GEN.ControlesBase.txtBase txtTotal;
        private GEN.ControlesBase.txtBase txtIdCliente;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelContent;
        private GEN.ControlesBase.dtgBase dtgCobsError;
        private GEN.BotonesBase.btnExporExcel btnExporExcel2;
        private GEN.BotonesBase.BtnAceptar btnAceptarCob;
        private System.Windows.Forms.Panel panel1;
        private GEN.ControlesBase.txtNumerico txtIdGrupo;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtIdKardex;
        private GEN.ControlesBase.txtBase txtIdCuenta;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.chcBase chcExportExcel;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtComentario;
        private GEN.ControlesBase.txtNumerico txtMontoTotal;
        private GEN.ControlesBase.lblBase lblBase9;
        private System.Windows.Forms.Panel panelBotones;

    }
}