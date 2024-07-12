namespace CRE.Presentacion
{
    partial class frmExpedienteDocumentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedienteDocumentos));
            this.dtgDetalleSolExp = new GEN.ControlesBase.dtgBase(this.components);
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnQuitar1 = new GEN.BotonesBase.btnQuitar();
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.txtNroFolCre = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNroFolAho = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroFolVal = new GEN.ControlesBase.txtBase(this.components);
            this.btnImprimir2 = new GEN.BotonesBase.btnImprimir();
            this.btnImprimir3 = new GEN.BotonesBase.btnImprimir();
            this.btnImprimir4 = new GEN.BotonesBase.btnImprimir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleSolExp)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDetalleSolExp
            // 
            this.dtgDetalleSolExp.AllowUserToAddRows = false;
            this.dtgDetalleSolExp.AllowUserToDeleteRows = false;
            this.dtgDetalleSolExp.AllowUserToResizeColumns = false;
            this.dtgDetalleSolExp.AllowUserToResizeRows = false;
            this.dtgDetalleSolExp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgDetalleSolExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleSolExp.Location = new System.Drawing.Point(15, 178);
            this.dtgDetalleSolExp.MultiSelect = false;
            this.dtgDetalleSolExp.Name = "dtgDetalleSolExp";
            this.dtgDetalleSolExp.ReadOnly = true;
            this.dtgDetalleSolExp.RowHeadersVisible = false;
            this.dtgDetalleSolExp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleSolExp.Size = new System.Drawing.Size(492, 215);
            this.dtgDetalleSolExp.TabIndex = 12;
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(12, 8);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(561, 105);
            this.conBusCli1.TabIndex = 14;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 129);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(210, 13);
            this.lblBase3.TabIndex = 12;
            this.lblBase3.Text = "Detalle Documentos del Expediente";
            // 
            // btnQuitar1
            // 
            this.btnQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar1.BackgroundImage")));
            this.btnQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar1.Location = new System.Drawing.Point(513, 240);
            this.btnQuitar1.Name = "btnQuitar1";
            this.btnQuitar1.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar1.TabIndex = 20;
            this.btnQuitar1.Text = "&Quitar";
            this.btnQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar1.UseVisualStyleBackColor = true;
            this.btnQuitar1.Click += new System.EventHandler(this.btnQuitar1_Click);
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(513, 187);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 19;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(513, 402);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(447, 402);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 21;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click_1);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(15, 402);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 22;
            this.btnImprimir1.Text = "&Todos";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // txtNroFolCre
            // 
            this.txtNroFolCre.Location = new System.Drawing.Point(132, 152);
            this.txtNroFolCre.Name = "txtNroFolCre";
            this.txtNroFolCre.Size = new System.Drawing.Size(65, 20);
            this.txtNroFolCre.TabIndex = 23;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 155);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(118, 13);
            this.lblBase1.TabIndex = 12;
            this.lblBase1.Text = "Nro. Folios Crédito:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(202, 155);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(115, 13);
            this.lblBase2.TabIndex = 12;
            this.lblBase2.Text = "Nro. Folios Ahorro:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(389, 155);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(132, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Nro. Folios Valorados:";
            // 
            // txtNroFolAho
            // 
            this.txtNroFolAho.Location = new System.Drawing.Point(317, 152);
            this.txtNroFolAho.Name = "txtNroFolAho";
            this.txtNroFolAho.Size = new System.Drawing.Size(65, 20);
            this.txtNroFolAho.TabIndex = 23;
            // 
            // txtNroFolVal
            // 
            this.txtNroFolVal.Location = new System.Drawing.Point(519, 152);
            this.txtNroFolVal.Name = "txtNroFolVal";
            this.txtNroFolVal.Size = new System.Drawing.Size(65, 20);
            this.txtNroFolVal.TabIndex = 23;
            // 
            // btnImprimir2
            // 
            this.btnImprimir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir2.BackgroundImage")));
            this.btnImprimir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir2.Location = new System.Drawing.Point(82, 402);
            this.btnImprimir2.Name = "btnImprimir2";
            this.btnImprimir2.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir2.TabIndex = 24;
            this.btnImprimir2.Text = "C&rédito";
            this.btnImprimir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir2.UseVisualStyleBackColor = true;
            this.btnImprimir2.Click += new System.EventHandler(this.btnImprimir2_Click);
            // 
            // btnImprimir3
            // 
            this.btnImprimir3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir3.BackgroundImage")));
            this.btnImprimir3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir3.Location = new System.Drawing.Point(148, 402);
            this.btnImprimir3.Name = "btnImprimir3";
            this.btnImprimir3.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir3.TabIndex = 25;
            this.btnImprimir3.Text = "A&horro";
            this.btnImprimir3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir3.UseVisualStyleBackColor = true;
            this.btnImprimir3.Click += new System.EventHandler(this.btnImprimir3_Click);
            // 
            // btnImprimir4
            // 
            this.btnImprimir4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir4.BackgroundImage")));
            this.btnImprimir4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir4.Location = new System.Drawing.Point(215, 402);
            this.btnImprimir4.Name = "btnImprimir4";
            this.btnImprimir4.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir4.TabIndex = 26;
            this.btnImprimir4.Text = "&Valorado";
            this.btnImprimir4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir4.UseVisualStyleBackColor = true;
            this.btnImprimir4.Click += new System.EventHandler(this.btnImprimir4_Click);
            // 
            // frmExpedienteDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 481);
            this.Controls.Add(this.btnImprimir4);
            this.Controls.Add(this.btnImprimir3);
            this.Controls.Add(this.btnImprimir2);
            this.Controls.Add(this.txtNroFolVal);
            this.Controls.Add(this.txtNroFolAho);
            this.Controls.Add(this.txtNroFolCre);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnQuitar1);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.dtgDetalleSolExp);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmExpedienteDocumentos";
            this.Text = "Registro de Documentos del Expediente";
            this.Load += new System.EventHandler(this.frmEntregaExpediente_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgDetalleSolExp, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.btnQuitar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.txtNroFolCre, 0);
            this.Controls.SetChildIndex(this.txtNroFolAho, 0);
            this.Controls.SetChildIndex(this.txtNroFolVal, 0);
            this.Controls.SetChildIndex(this.btnImprimir2, 0);
            this.Controls.SetChildIndex(this.btnImprimir3, 0);
            this.Controls.SetChildIndex(this.btnImprimir4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleSolExp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgDetalleSolExp;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.BotonesBase.btnQuitar btnQuitar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.txtBase txtNroFolCre;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtNroFolAho;
        private GEN.ControlesBase.txtBase txtNroFolVal;
        private GEN.BotonesBase.btnImprimir btnImprimir2;
        private GEN.BotonesBase.btnImprimir btnImprimir3;
        private GEN.BotonesBase.btnImprimir btnImprimir4;
    }
}