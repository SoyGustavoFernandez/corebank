namespace GEN.ControlesBase
{
    partial class frmRegDocConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegDocConfiguracion));
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtNuevoArchivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.cboGrupoCargaArchivo1 = new GEN.ControlesBase.cboGrupoCargaArchivo(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.rbtIndeterminado = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtConFechaVigencia = new GEN.ControlesBase.rbtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtOrden = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtDocumentoBase = new GEN.ControlesBase.txtBase(this.components);
            this.btnMiniBusqDocumento = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.chcConfiguracionBase = new GEN.ControlesBase.chcBase(this.components);
            this.dtpFechaVigencia = new GEN.ControlesBase.dtpCorto(this.components);
            this.SuspendLayout();
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(336, 121);
            this.lblBase8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(96, 13);
            this.lblBase8.TabIndex = 10;
            this.lblBase8.Text = "Fecha vigencia:";
            this.lblBase8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNuevoArchivo
            // 
            this.txtNuevoArchivo.Location = new System.Drawing.Point(134, 68);
            this.txtNuevoArchivo.Name = "txtNuevoArchivo";
            this.txtNuevoArchivo.Size = new System.Drawing.Size(394, 20);
            this.txtNuevoArchivo.TabIndex = 5;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(7, 71);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(122, 13);
            this.lblBase9.TabIndex = 2;
            this.lblBase9.Text = "Nombre de Archivo:";
            // 
            // cboGrupoCargaArchivo1
            // 
            this.cboGrupoCargaArchivo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoCargaArchivo1.FormattingEnabled = true;
            this.cboGrupoCargaArchivo1.Location = new System.Drawing.Point(134, 36);
            this.cboGrupoCargaArchivo1.Name = "cboGrupoCargaArchivo1";
            this.cboGrupoCargaArchivo1.Size = new System.Drawing.Size(394, 21);
            this.cboGrupoCargaArchivo1.TabIndex = 4;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(17, 39);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(112, 13);
            this.lblBase3.TabIndex = 1;
            this.lblBase3.Text = "Grupo de Archivo:";
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(402, 201);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 13;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(468, 201);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 14;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // rbtIndeterminado
            // 
            this.rbtIndeterminado.AutoSize = true;
            this.rbtIndeterminado.ForeColor = System.Drawing.Color.Navy;
            this.rbtIndeterminado.Location = new System.Drawing.Point(134, 97);
            this.rbtIndeterminado.Name = "rbtIndeterminado";
            this.rbtIndeterminado.Size = new System.Drawing.Size(92, 17);
            this.rbtIndeterminado.TabIndex = 6;
            this.rbtIndeterminado.TabStop = true;
            this.rbtIndeterminado.Text = "Indeterminado";
            this.rbtIndeterminado.UseVisualStyleBackColor = true;
            this.rbtIndeterminado.CheckedChanged += new System.EventHandler(this.rbtIndeterminado_CheckedChanged);
            // 
            // rbtConFechaVigencia
            // 
            this.rbtConFechaVigencia.AutoSize = true;
            this.rbtConFechaVigencia.ForeColor = System.Drawing.Color.Navy;
            this.rbtConFechaVigencia.Location = new System.Drawing.Point(134, 120);
            this.rbtConFechaVigencia.Name = "rbtConFechaVigencia";
            this.rbtConFechaVigencia.Size = new System.Drawing.Size(132, 17);
            this.rbtConFechaVigencia.TabIndex = 7;
            this.rbtConFechaVigencia.TabStop = true;
            this.rbtConFechaVigencia.Text = "Con fecha de vigencia";
            this.rbtConFechaVigencia.UseVisualStyleBackColor = true;
            this.rbtConFechaVigencia.CheckedChanged += new System.EventHandler(this.rbtBase1_CheckedChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(82, 12);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(47, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Orden:";
            // 
            // txtOrden
            // 
            this.txtOrden.Format = "n2";
            this.txtOrden.Location = new System.Drawing.Point(134, 9);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(100, 20);
            this.txtOrden.TabIndex = 3;
            // 
            // txtDocumentoBase
            // 
            this.txtDocumentoBase.Location = new System.Drawing.Point(134, 145);
            this.txtDocumentoBase.Multiline = true;
            this.txtDocumentoBase.Name = "txtDocumentoBase";
            this.txtDocumentoBase.ReadOnly = true;
            this.txtDocumentoBase.Size = new System.Drawing.Size(352, 50);
            this.txtDocumentoBase.TabIndex = 9;
            // 
            // btnMiniBusqDocumento
            // 
            this.btnMiniBusqDocumento.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusqDocumento.BackgroundImage")));
            this.btnMiniBusqDocumento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusqDocumento.Enabled = false;
            this.btnMiniBusqDocumento.Location = new System.Drawing.Point(492, 156);
            this.btnMiniBusqDocumento.Name = "btnMiniBusqDocumento";
            this.btnMiniBusqDocumento.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusqDocumento.TabIndex = 12;
            this.btnMiniBusqDocumento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusqDocumento.UseVisualStyleBackColor = true;
            this.btnMiniBusqDocumento.Click += new System.EventHandler(this.btnMiniBusqDocumento_Click);
            // 
            // chcConfiguracionBase
            // 
            this.chcConfiguracionBase.ForeColor = System.Drawing.Color.Navy;
            this.chcConfiguracionBase.Location = new System.Drawing.Point(12, 145);
            this.chcConfiguracionBase.Name = "chcConfiguracionBase";
            this.chcConfiguracionBase.Size = new System.Drawing.Size(117, 50);
            this.chcConfiguracionBase.TabIndex = 8;
            this.chcConfiguracionBase.Text = "Configuraciones en base al siguiente archivo:";
            this.chcConfiguracionBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcConfiguracionBase.UseVisualStyleBackColor = true;
            this.chcConfiguracionBase.CheckedChanged += new System.EventHandler(this.chcConfiguracionBase_CheckedChanged);
            // 
            // dtpFechaVigencia
            // 
            this.dtpFechaVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVigencia.Location = new System.Drawing.Point(436, 116);
            this.dtpFechaVigencia.Name = "dtpFechaVigencia";
            this.dtpFechaVigencia.Size = new System.Drawing.Size(92, 20);
            this.dtpFechaVigencia.TabIndex = 15;
            // 
            // frmRegDocConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 277);
            this.Controls.Add(this.dtpFechaVigencia);
            this.Controls.Add(this.chcConfiguracionBase);
            this.Controls.Add(this.btnMiniBusqDocumento);
            this.Controls.Add(this.txtDocumentoBase);
            this.Controls.Add(this.txtOrden);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.rbtConFechaVigencia);
            this.Controls.Add(this.rbtIndeterminado);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.txtNuevoArchivo);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.cboGrupoCargaArchivo1);
            this.Controls.Add(this.lblBase3);
            this.Name = "frmRegDocConfiguracion";
            this.Text = "Registro de documentos";
            this.Load += new System.EventHandler(this.frmDocumentoConfigura_Load);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboGrupoCargaArchivo1, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.txtNuevoArchivo, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.rbtIndeterminado, 0);
            this.Controls.SetChildIndex(this.rbtConFechaVigencia, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtOrden, 0);
            this.Controls.SetChildIndex(this.txtDocumentoBase, 0);
            this.Controls.SetChildIndex(this.btnMiniBusqDocumento, 0);
            this.Controls.SetChildIndex(this.chcConfiguracionBase, 0);
            this.Controls.SetChildIndex(this.dtpFechaVigencia, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lblBase lblBase8;
        private txtBase txtNuevoArchivo;
        private lblBase lblBase9;
        private cboGrupoCargaArchivo cboGrupoCargaArchivo1;
        private lblBase lblBase3;
        private BotonesBase.btnGrabar btnGrabar1;
        private BotonesBase.btnSalir btnSalir1;
        private rbtBase rbtIndeterminado;
        private rbtBase rbtConFechaVigencia;
        private lblBase lblBase1;
        private txtNumerico txtOrden;
        private txtBase txtDocumentoBase;
        private BotonesBase.btnMiniBusq btnMiniBusqDocumento;
        private chcBase chcConfiguracionBase;
        private dtpCorto dtpFechaVigencia;
    }
}