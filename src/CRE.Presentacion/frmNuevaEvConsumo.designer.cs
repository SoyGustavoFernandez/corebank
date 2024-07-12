namespace CRE.Presentacion
{
    partial class frmNuevaEvConsumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaEvConsumo));
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.panelDG = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgSolicitud = new GEN.ControlesBase.dtgBase(this.components);
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuitar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.grbEvalDet = new GEN.ControlesBase.grbBase(this.components);
            this.conCreditoTasa1 = new GEN.ControlesBase.ConCreditoTasa();
            this.grbCatLab = new GEN.ControlesBase.grbBase(this.components);
            this.nudAniosExperiencia = new GEN.ControlesBase.nudBase(this.components);
            this.rbtnIndependiente = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnDependiente = new GEN.ControlesBase.rbtnBase(this.components);
            this.cboCatLab = new GEN.ControlesBase.cboCatLaboral(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btn_Vincular1 = new GEN.BotonesBase.Btn_Vincular();
            this.panelGlobal.SuspendLayout();
            this.panelDG.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitud)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grbEvalDet.SuspendLayout();
            this.grbCatLab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAniosExperiencia)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(362, 496);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(428, 496);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 6;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(493, 496);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(4, 4);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(556, 83);
            this.conBusCli1.TabIndex = 0;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // panelGlobal
            // 
            this.panelGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGlobal.Controls.Add(this.panelDG);
            this.panelGlobal.Location = new System.Drawing.Point(4, 93);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(493, 87);
            this.panelGlobal.TabIndex = 1;
            // 
            // panelDG
            // 
            this.panelDG.Controls.Add(this.panel2);
            this.panelDG.Controls.Add(this.panelMenu);
            this.panelDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDG.Location = new System.Drawing.Point(0, 0);
            this.panelDG.Name = "panelDG";
            this.panelDG.Size = new System.Drawing.Size(491, 85);
            this.panelDG.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgSolicitud);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 61);
            this.panel2.TabIndex = 25;
            // 
            // dtgSolicitud
            // 
            this.dtgSolicitud.AllowUserToAddRows = false;
            this.dtgSolicitud.AllowUserToDeleteRows = false;
            this.dtgSolicitud.AllowUserToResizeColumns = false;
            this.dtgSolicitud.AllowUserToResizeRows = false;
            this.dtgSolicitud.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolicitud.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSolicitud.Location = new System.Drawing.Point(0, 0);
            this.dtgSolicitud.MultiSelect = false;
            this.dtgSolicitud.Name = "dtgSolicitud";
            this.dtgSolicitud.ReadOnly = true;
            this.dtgSolicitud.RowHeadersVisible = false;
            this.dtgSolicitud.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitud.Size = new System.Drawing.Size(491, 61);
            this.dtgSolicitud.TabIndex = 0;
            this.dtgSolicitud.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.menuStrip1);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(491, 24);
            this.panelMenu.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCancelar,
            this.tsmQuitar,
            this.tsmAgregar});
            this.menuStrip1.Location = new System.Drawing.Point(200, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(291, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmCancelar
            // 
            this.tsmCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmCancelar.Enabled = false;
            this.tsmCancelar.Name = "tsmCancelar";
            this.tsmCancelar.Size = new System.Drawing.Size(12, 20);
            this.tsmCancelar.Text = "tsmCancelar";
            this.tsmCancelar.ToolTipText = "Cancelar edición.";
            this.tsmCancelar.Visible = false;
            // 
            // tsmQuitar
            // 
            this.tsmQuitar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmQuitar.Checked = true;
            this.tsmQuitar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmQuitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmQuitar.Enabled = false;
            this.tsmQuitar.Name = "tsmQuitar";
            this.tsmQuitar.Size = new System.Drawing.Size(12, 20);
            this.tsmQuitar.Text = "Quitar";
            this.tsmQuitar.ToolTipText = "Eliminar registro seleccionado.";
            this.tsmQuitar.Visible = false;
            // 
            // tsmAgregar
            // 
            this.tsmAgregar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmAgregar.Enabled = false;
            this.tsmAgregar.Name = "tsmAgregar";
            this.tsmAgregar.Size = new System.Drawing.Size(12, 20);
            this.tsmAgregar.Text = "Agregar";
            this.tsmAgregar.ToolTipText = "Agregar registro del formulario.";
            this.tsmAgregar.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solicitudes de crédito";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbEvalDet
            // 
            this.grbEvalDet.Controls.Add(this.conCreditoTasa1);
            this.grbEvalDet.Location = new System.Drawing.Point(4, 186);
            this.grbEvalDet.Name = "grbEvalDet";
            this.grbEvalDet.Size = new System.Drawing.Size(336, 331);
            this.grbEvalDet.TabIndex = 3;
            this.grbEvalDet.TabStop = false;
            this.grbEvalDet.Text = "Detalle de evaluación";
            // 
            // conCreditoTasa1
            // 
            this.conCreditoTasa1.AutoSize = true;
            this.conCreditoTasa1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conCreditoTasa1.CuotasEnabled = true;
            this.conCreditoTasa1.DiasGraciaEnabled = false;
            this.conCreditoTasa1.FechaDesembolsoEnabled = true;
            this.conCreditoTasa1.lMostrarTodosNivCred = false;
            this.conCreditoTasa1.Location = new System.Drawing.Point(4, 16);
            this.conCreditoTasa1.MonedaEnabled = true;
            this.conCreditoTasa1.MontoEnabled = true;
            this.conCreditoTasa1.Name = "conCreditoTasa1";
            this.conCreditoTasa1.NivelesProductoEnabled = true;
            this.conCreditoTasa1.PlazoCuotaEnabled = true;
            this.conCreditoTasa1.Size = new System.Drawing.Size(325, 275);
            this.conCreditoTasa1.TabIndex = 0;
            this.conCreditoTasa1.TEAEnabled = true;
            this.conCreditoTasa1.TipoPeriodoEnabled = true;
            this.conCreditoTasa1.TipoTasaCreditoEnabled = true;
            // 
            // grbCatLab
            // 
            this.grbCatLab.Controls.Add(this.nudAniosExperiencia);
            this.grbCatLab.Controls.Add(this.rbtnIndependiente);
            this.grbCatLab.Controls.Add(this.rbtnDependiente);
            this.grbCatLab.Controls.Add(this.cboCatLab);
            this.grbCatLab.Controls.Add(this.lblBase3);
            this.grbCatLab.Controls.Add(this.lblBase2);
            this.grbCatLab.Controls.Add(this.lblBase1);
            this.grbCatLab.Location = new System.Drawing.Point(346, 186);
            this.grbCatLab.Name = "grbCatLab";
            this.grbCatLab.Size = new System.Drawing.Size(214, 113);
            this.grbCatLab.TabIndex = 4;
            this.grbCatLab.TabStop = false;
            this.grbCatLab.Text = "Cliente";
            // 
            // nudAniosExperiencia
            // 
            this.nudAniosExperiencia.Location = new System.Drawing.Point(132, 86);
            this.nudAniosExperiencia.Name = "nudAniosExperiencia";
            this.nudAniosExperiencia.Size = new System.Drawing.Size(73, 20);
            this.nudAniosExperiencia.TabIndex = 3;
            this.nudAniosExperiencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rbtnIndependiente
            // 
            this.rbtnIndependiente.AutoSize = true;
            this.rbtnIndependiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnIndependiente.Location = new System.Drawing.Point(116, 66);
            this.rbtnIndependiente.Name = "rbtnIndependiente";
            this.rbtnIndependiente.Size = new System.Drawing.Size(93, 17);
            this.rbtnIndependiente.TabIndex = 2;
            this.rbtnIndependiente.TabStop = true;
            this.rbtnIndependiente.Text = "Independiente";
            this.rbtnIndependiente.UseVisualStyleBackColor = true;
            // 
            // rbtnDependiente
            // 
            this.rbtnDependiente.AutoSize = true;
            this.rbtnDependiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnDependiente.Location = new System.Drawing.Point(116, 43);
            this.rbtnDependiente.Name = "rbtnDependiente";
            this.rbtnDependiente.Size = new System.Drawing.Size(86, 17);
            this.rbtnDependiente.TabIndex = 1;
            this.rbtnDependiente.TabStop = true;
            this.rbtnDependiente.Text = "Dependiente";
            this.rbtnDependiente.UseVisualStyleBackColor = true;
            // 
            // cboCatLab
            // 
            this.cboCatLab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCatLab.FormattingEnabled = true;
            this.cboCatLab.Location = new System.Drawing.Point(116, 16);
            this.cboCatLab.Name = "cboCatLab";
            this.cboCatLab.Size = new System.Drawing.Size(91, 21);
            this.cboCatLab.TabIndex = 0;
            this.cboCatLab.SelectedIndexChanged += new System.EventHandler(this.cboCatLab_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(3, 89);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(128, 13);
            this.lblBase3.TabIndex = 18;
            this.lblBase3.Text = "Años de experiencia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(3, 45);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(106, 13);
            this.lblBase2.TabIndex = 18;
            this.lblBase2.Text = "Tipo de ingresos:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(3, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(111, 13);
            this.lblBase1.TabIndex = 19;
            this.lblBase1.Text = "Categoría laboral:";
            // 
            // btn_Vincular1
            // 
            this.btn_Vincular1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Vincular1.BackgroundImage")));
            this.btn_Vincular1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Vincular1.Image = ((System.Drawing.Image)(resources.GetObject("btn_Vincular1.Image")));
            this.btn_Vincular1.Location = new System.Drawing.Point(500, 94);
            this.btn_Vincular1.Name = "btn_Vincular1";
            this.btn_Vincular1.Size = new System.Drawing.Size(60, 50);
            this.btn_Vincular1.TabIndex = 2;
            this.btn_Vincular1.Text = "&Vincular";
            this.btn_Vincular1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Vincular1.UseVisualStyleBackColor = true;
            this.btn_Vincular1.Click += new System.EventHandler(this.btn_Vincular1_Click);
            // 
            // frmNuevaEvConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 574);
            this.Controls.Add(this.btn_Vincular1);
            this.Controls.Add(this.grbCatLab);
            this.Controls.Add(this.grbEvalDet);
            this.Controls.Add(this.panelGlobal);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmNuevaEvConsumo";
            this.Text = "Nueva evaluación";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Shown += new System.EventHandler(this.frmNuevaEvConsumo_Shown);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.panelGlobal, 0);
            this.Controls.SetChildIndex(this.grbEvalDet, 0);
            this.Controls.SetChildIndex(this.grbCatLab, 0);
            this.Controls.SetChildIndex(this.btn_Vincular1, 0);
            this.panelGlobal.ResumeLayout(false);
            this.panelDG.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitud)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grbEvalDet.ResumeLayout(false);
            this.grbEvalDet.PerformLayout();
            this.grbCatLab.ResumeLayout(false);
            this.grbCatLab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAniosExperiencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private System.Windows.Forms.Panel panelGlobal;
        private System.Windows.Forms.Panel panelDG;
        private System.Windows.Forms.Panel panel2;
        private GEN.ControlesBase.dtgBase dtgSolicitud;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmCancelar;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitar;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregar;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.grbBase grbEvalDet;
        private GEN.ControlesBase.grbBase grbCatLab;
        private GEN.ControlesBase.rbtnBase rbtnIndependiente;
        private GEN.ControlesBase.rbtnBase rbtnDependiente;
        private GEN.ControlesBase.cboCatLaboral cboCatLab;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.nudBase nudAniosExperiencia;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.Btn_Vincular btn_Vincular1;
        private GEN.ControlesBase.ConCreditoTasa conCreditoTasa1;
    }
}

