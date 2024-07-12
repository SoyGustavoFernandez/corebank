namespace ADM.Presentacion
{
    partial class frmControlObjetos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlObjetos));
            this.cboModulo = new GEN.ControlesBase.cboModulo(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lstFormularios = new GEN.ControlesBase.lstBase(this.components);
            this.lstControles = new GEN.ControlesBase.lstBase(this.components);
            this.cboListaPerfil = new GEN.ControlesBase.cboListaPerfil(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbEstados = new GEN.ControlesBase.grbBase(this.components);
            this.rbtnHabilitado = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnNoHabilitado = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnVisible = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnNoVisible = new GEN.ControlesBase.rbtnBase(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboEventos = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.tbcObjetosControl = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grbEstadosRpt = new GEN.ControlesBase.grbBase(this.components);
            this.rbtnRptVisible = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnRptNoVisible = new GEN.ControlesBase.rbtnBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lstBotones = new GEN.ControlesBase.lstBase(this.components);
            this.lstReportes = new GEN.ControlesBase.lstBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnRptGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnActualizar1 = new GEN.BotonesBase.btnActualizar();
            this.grbEstados.SuspendLayout();
            this.tbcObjetosControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grbEstadosRpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(79, 35);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(195, 21);
            this.cboModulo.TabIndex = 2;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.cboModulo_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 38);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(52, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Módulo:";
            // 
            // lstFormularios
            // 
            this.lstFormularios.FormattingEnabled = true;
            this.lstFormularios.Location = new System.Drawing.Point(25, 43);
            this.lstFormularios.Name = "lstFormularios";
            this.lstFormularios.Size = new System.Drawing.Size(176, 277);
            this.lstFormularios.TabIndex = 4;
            this.lstFormularios.SelectedIndexChanged += new System.EventHandler(this.lstFormularios_SelectedIndexChanged);
            // 
            // lstControles
            // 
            this.lstControles.FormattingEnabled = true;
            this.lstControles.Location = new System.Drawing.Point(245, 42);
            this.lstControles.Name = "lstControles";
            this.lstControles.Size = new System.Drawing.Size(176, 277);
            this.lstControles.TabIndex = 4;
            this.lstControles.SelectedIndexChanged += new System.EventHandler(this.lstControles_SelectedIndexChanged);
            // 
            // cboListaPerfil
            // 
            this.cboListaPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboListaPerfil.FormattingEnabled = true;
            this.cboListaPerfil.Location = new System.Drawing.Point(79, 6);
            this.cboListaPerfil.Name = "cboListaPerfil";
            this.cboListaPerfil.Size = new System.Drawing.Size(195, 21);
            this.cboListaPerfil.TabIndex = 6;
            this.cboListaPerfil.SelectedIndexChanged += new System.EventHandler(this.cboListaPerfil_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 9);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(41, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Perfil:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(26, 25);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(74, 13);
            this.lblBase3.TabIndex = 3;
            this.lblBase3.Text = "Formularios";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(242, 24);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(62, 13);
            this.lblBase4.TabIndex = 3;
            this.lblBase4.Text = "Controles";
            // 
            // grbEstados
            // 
            this.grbEstados.Controls.Add(this.rbtnHabilitado);
            this.grbEstados.Controls.Add(this.rbtnNoHabilitado);
            this.grbEstados.Controls.Add(this.rbtnVisible);
            this.grbEstados.Controls.Add(this.rbtnNoVisible);
            this.grbEstados.Location = new System.Drawing.Point(428, 40);
            this.grbEstados.Name = "grbEstados";
            this.grbEstados.Size = new System.Drawing.Size(139, 134);
            this.grbEstados.TabIndex = 7;
            this.grbEstados.TabStop = false;
            this.grbEstados.Text = "Seleccionar Estado";
            // 
            // rbtnHabilitado
            // 
            this.rbtnHabilitado.AutoSize = true;
            this.rbtnHabilitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnHabilitado.Location = new System.Drawing.Point(17, 88);
            this.rbtnHabilitado.Name = "rbtnHabilitado";
            this.rbtnHabilitado.Size = new System.Drawing.Size(72, 17);
            this.rbtnHabilitado.TabIndex = 0;
            this.rbtnHabilitado.TabStop = true;
            this.rbtnHabilitado.Text = "Habilitado";
            this.rbtnHabilitado.UseVisualStyleBackColor = true;
            this.rbtnHabilitado.CheckedChanged += new System.EventHandler(this.rbtnHabilitado_CheckedChanged);
            // 
            // rbtnNoHabilitado
            // 
            this.rbtnNoHabilitado.AutoSize = true;
            this.rbtnNoHabilitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnNoHabilitado.Location = new System.Drawing.Point(17, 65);
            this.rbtnNoHabilitado.Name = "rbtnNoHabilitado";
            this.rbtnNoHabilitado.Size = new System.Drawing.Size(89, 17);
            this.rbtnNoHabilitado.TabIndex = 0;
            this.rbtnNoHabilitado.TabStop = true;
            this.rbtnNoHabilitado.Text = "No Habilitado";
            this.rbtnNoHabilitado.UseVisualStyleBackColor = true;
            this.rbtnNoHabilitado.CheckedChanged += new System.EventHandler(this.rbtnNoHabilitado_CheckedChanged);
            // 
            // rbtnVisible
            // 
            this.rbtnVisible.AutoSize = true;
            this.rbtnVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnVisible.Location = new System.Drawing.Point(17, 42);
            this.rbtnVisible.Name = "rbtnVisible";
            this.rbtnVisible.Size = new System.Drawing.Size(55, 17);
            this.rbtnVisible.TabIndex = 0;
            this.rbtnVisible.TabStop = true;
            this.rbtnVisible.Text = "Visible";
            this.rbtnVisible.UseVisualStyleBackColor = true;
            this.rbtnVisible.CheckedChanged += new System.EventHandler(this.rbtnVisible_CheckedChanged);
            // 
            // rbtnNoVisible
            // 
            this.rbtnNoVisible.AutoSize = true;
            this.rbtnNoVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnNoVisible.Location = new System.Drawing.Point(17, 19);
            this.rbtnNoVisible.Name = "rbtnNoVisible";
            this.rbtnNoVisible.Size = new System.Drawing.Size(72, 17);
            this.rbtnNoVisible.TabIndex = 0;
            this.rbtnNoVisible.TabStop = true;
            this.rbtnNoVisible.Text = "No Visible";
            this.rbtnNoVisible.UseVisualStyleBackColor = true;
            this.rbtnNoVisible.CheckedChanged += new System.EventHandler(this.rbtnNoVisible_CheckedChanged);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(457, 190);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(557, 468);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cboEventos
            // 
            this.cboEventos.FormattingEnabled = true;
            this.cboEventos.Location = new System.Drawing.Point(79, 62);
            this.cboEventos.Name = "cboEventos";
            this.cboEventos.Size = new System.Drawing.Size(195, 21);
            this.cboEventos.TabIndex = 10;
            this.cboEventos.SelectedIndexChanged += new System.EventHandler(this.cboEventos_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 62);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(46, 13);
            this.lblBase5.TabIndex = 3;
            this.lblBase5.Text = "Evento";
            // 
            // tbcObjetosControl
            // 
            this.tbcObjetosControl.Controls.Add(this.tabPage1);
            this.tbcObjetosControl.Controls.Add(this.tabPage2);
            this.tbcObjetosControl.Location = new System.Drawing.Point(12, 92);
            this.tbcObjetosControl.Name = "tbcObjetosControl";
            this.tbcObjetosControl.SelectedIndex = 0;
            this.tbcObjetosControl.Size = new System.Drawing.Size(605, 374);
            this.tbcObjetosControl.TabIndex = 11;
            this.tbcObjetosControl.SelectedIndexChanged += new System.EventHandler(this.tbcObjetosControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grbEstados);
            this.tabPage1.Controls.Add(this.lblBase4);
            this.tabPage1.Controls.Add(this.lstControles);
            this.tabPage1.Controls.Add(this.btnGrabar);
            this.tabPage1.Controls.Add(this.lstFormularios);
            this.tabPage1.Controls.Add(this.lblBase3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "FORMULARIOS";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grbEstadosRpt);
            this.tabPage2.Controls.Add(this.lblBase7);
            this.tabPage2.Controls.Add(this.lstBotones);
            this.tabPage2.Controls.Add(this.lstReportes);
            this.tabPage2.Controls.Add(this.lblBase6);
            this.tabPage2.Controls.Add(this.btnRptGrabar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(585, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "REPORTES";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // grbEstadosRpt
            // 
            this.grbEstadosRpt.Controls.Add(this.rbtnRptVisible);
            this.grbEstadosRpt.Controls.Add(this.rbtnRptNoVisible);
            this.grbEstadosRpt.Location = new System.Drawing.Point(424, 93);
            this.grbEstadosRpt.Name = "grbEstadosRpt";
            this.grbEstadosRpt.Size = new System.Drawing.Size(139, 69);
            this.grbEstadosRpt.TabIndex = 14;
            this.grbEstadosRpt.TabStop = false;
            this.grbEstadosRpt.Text = "Seleccionar Estado";
            // 
            // rbtnRptVisible
            // 
            this.rbtnRptVisible.AutoSize = true;
            this.rbtnRptVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnRptVisible.Location = new System.Drawing.Point(17, 42);
            this.rbtnRptVisible.Name = "rbtnRptVisible";
            this.rbtnRptVisible.Size = new System.Drawing.Size(55, 17);
            this.rbtnRptVisible.TabIndex = 0;
            this.rbtnRptVisible.TabStop = true;
            this.rbtnRptVisible.Text = "Visible";
            this.rbtnRptVisible.UseVisualStyleBackColor = true;
            this.rbtnRptVisible.CheckedChanged += new System.EventHandler(this.rbtnRptVisible_CheckedChanged);
            // 
            // rbtnRptNoVisible
            // 
            this.rbtnRptNoVisible.AutoSize = true;
            this.rbtnRptNoVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnRptNoVisible.Location = new System.Drawing.Point(17, 19);
            this.rbtnRptNoVisible.Name = "rbtnRptNoVisible";
            this.rbtnRptNoVisible.Size = new System.Drawing.Size(72, 17);
            this.rbtnRptNoVisible.TabIndex = 0;
            this.rbtnRptNoVisible.TabStop = true;
            this.rbtnRptNoVisible.Text = "No Visible";
            this.rbtnRptNoVisible.UseVisualStyleBackColor = true;
            this.rbtnRptNoVisible.CheckedChanged += new System.EventHandler(this.rbtnRptNoVisible_CheckedChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(227, 23);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(53, 13);
            this.lblBase7.TabIndex = 12;
            this.lblBase7.Text = "Botones";
            // 
            // lstBotones
            // 
            this.lstBotones.FormattingEnabled = true;
            this.lstBotones.Location = new System.Drawing.Point(230, 39);
            this.lstBotones.Name = "lstBotones";
            this.lstBotones.Size = new System.Drawing.Size(176, 277);
            this.lstBotones.TabIndex = 13;
            this.lstBotones.SelectedIndexChanged += new System.EventHandler(this.lstBotones_SelectedIndexChanged);
            // 
            // lstReportes
            // 
            this.lstReportes.FormattingEnabled = true;
            this.lstReportes.Location = new System.Drawing.Point(25, 41);
            this.lstReportes.Name = "lstReportes";
            this.lstReportes.Size = new System.Drawing.Size(176, 277);
            this.lstReportes.TabIndex = 11;
            this.lstReportes.SelectedIndexChanged += new System.EventHandler(this.lstReportes_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(26, 23);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(58, 13);
            this.lblBase6.TabIndex = 10;
            this.lblBase6.Text = "Reportes";
            // 
            // btnRptGrabar
            // 
            this.btnRptGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRptGrabar.BackgroundImage")));
            this.btnRptGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRptGrabar.Location = new System.Drawing.Point(462, 189);
            this.btnRptGrabar.Name = "btnRptGrabar";
            this.btnRptGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnRptGrabar.TabIndex = 9;
            this.btnRptGrabar.Text = "&Grabar";
            this.btnRptGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRptGrabar.UseVisualStyleBackColor = true;
            this.btnRptGrabar.Click += new System.EventHandler(this.btnRptGrabar_Click);
            // 
            // btnActualizar1
            // 
            this.btnActualizar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar1.BackgroundImage")));
            this.btnActualizar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActualizar1.Location = new System.Drawing.Point(12, 468);
            this.btnActualizar1.Name = "btnActualizar1";
            this.btnActualizar1.Size = new System.Drawing.Size(60, 50);
            this.btnActualizar1.TabIndex = 12;
            this.btnActualizar1.Text = "Act&ualizar";
            this.btnActualizar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar1.texto = "Act&ualizar";
            this.btnActualizar1.UseVisualStyleBackColor = true;
            this.btnActualizar1.Click += new System.EventHandler(this.btnActualizar1_Click);
            // 
            // frmControlObjetos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 552);
            this.Controls.Add(this.btnActualizar1);
            this.Controls.Add(this.tbcObjetosControl);
            this.Controls.Add(this.cboEventos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.cboListaPerfil);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboModulo);
            this.Name = "frmControlObjetos";
            this.Text = "Mantenimiento de controles por formulario";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.cboModulo, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboListaPerfil, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.cboEventos, 0);
            this.Controls.SetChildIndex(this.tbcObjetosControl, 0);
            this.Controls.SetChildIndex(this.btnActualizar1, 0);
            this.grbEstados.ResumeLayout(false);
            this.grbEstados.PerformLayout();
            this.tbcObjetosControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.grbEstadosRpt.ResumeLayout(false);
            this.grbEstadosRpt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboModulo cboModulo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lstBase lstFormularios;
        private GEN.ControlesBase.lstBase lstControles;
        private GEN.ControlesBase.cboListaPerfil cboListaPerfil;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbEstados;
        private GEN.ControlesBase.rbtnBase rbtnHabilitado;
        private GEN.ControlesBase.rbtnBase rbtnNoHabilitado;
        private GEN.ControlesBase.rbtnBase rbtnVisible;
        private GEN.ControlesBase.rbtnBase rbtnNoVisible;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboBase cboEventos;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.tbcBase tbcObjetosControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.ControlesBase.grbBase grbEstadosRpt;
        private GEN.ControlesBase.rbtnBase rbtnRptVisible;
        private GEN.ControlesBase.rbtnBase rbtnRptNoVisible;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lstBase lstBotones;
        private GEN.ControlesBase.lstBase lstReportes;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.BotonesBase.btnGrabar btnRptGrabar;
        private GEN.BotonesBase.btnActualizar btnActualizar1;
    }
}

