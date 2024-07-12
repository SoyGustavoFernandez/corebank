namespace CRE.Presentacion
{
    partial class frmSeleccionarDocEvalAnterior
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionarDocEvalAnterior));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgDocumentosEvalAnterior = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelImg = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelPdf = new System.Windows.Forms.Panel();
            this.contPdf = new AxAcroPDFLib.AxAcroPDF();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAlerta = new System.Windows.Forms.Label();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.cboTipoEvaluacion = new GEN.ControlesBase.cboBase(this.components);
            this.lblTipoVisita = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentosEvalAnterior)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPdf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 4);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(321, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Elija los documentos correspondientes para evaluación";
            // 
            // dtgDocumentosEvalAnterior
            // 
            this.dtgDocumentosEvalAnterior.AllowUserToAddRows = false;
            this.dtgDocumentosEvalAnterior.AllowUserToDeleteRows = false;
            this.dtgDocumentosEvalAnterior.AllowUserToResizeColumns = false;
            this.dtgDocumentosEvalAnterior.AllowUserToResizeRows = false;
            this.dtgDocumentosEvalAnterior.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDocumentosEvalAnterior.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgDocumentosEvalAnterior.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDocumentosEvalAnterior.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgDocumentosEvalAnterior.Location = new System.Drawing.Point(7, 60);
            this.dtgDocumentosEvalAnterior.MultiSelect = false;
            this.dtgDocumentosEvalAnterior.Name = "dtgDocumentosEvalAnterior";
            this.dtgDocumentosEvalAnterior.RowHeadersVisible = false;
            this.dtgDocumentosEvalAnterior.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDocumentosEvalAnterior.Size = new System.Drawing.Size(695, 199);
            this.dtgDocumentosEvalAnterior.TabIndex = 12;
            this.dtgDocumentosEvalAnterior.TabStop = false;
            this.dtgDocumentosEvalAnterior.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumentosEvalAnterior_CellContentClick_1);
            this.dtgDocumentosEvalAnterior.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumentosEvalAnterior_CellValueChanged);
            this.dtgDocumentosEvalAnterior.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgDocumentosEvalAnterior_DataError);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panelImg);
            this.flowLayoutPanel1.Controls.Add(this.panelPdf);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 263);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(704, 695);
            this.flowLayoutPanel1.TabIndex = 65;
            // 
            // panelImg
            // 
            this.panelImg.Controls.Add(this.pictureBox1);
            this.panelImg.Location = new System.Drawing.Point(3, 3);
            this.panelImg.Name = "panelImg";
            this.panelImg.Size = new System.Drawing.Size(698, 310);
            this.panelImg.TabIndex = 17;
            this.panelImg.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(695, 305);
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // panelPdf
            // 
            this.panelPdf.Controls.Add(this.contPdf);
            this.panelPdf.Location = new System.Drawing.Point(3, 319);
            this.panelPdf.Name = "panelPdf";
            this.panelPdf.Size = new System.Drawing.Size(698, 310);
            this.panelPdf.TabIndex = 67;
            this.panelPdf.Visible = false;
            // 
            // contPdf
            // 
            this.contPdf.Enabled = true;
            this.contPdf.Location = new System.Drawing.Point(0, 0);
            this.contPdf.Name = "contPdf";
            this.contPdf.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("contPdf.OcxState")));
            this.contPdf.Size = new System.Drawing.Size(698, 310);
            this.contPdf.TabIndex = 66;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAlerta);
            this.panel1.Controls.Add(this.btnAceptar1);
            this.panel1.Controls.Add(this.btnCancelar1);
            this.panel1.Location = new System.Drawing.Point(3, 635);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 57);
            this.panel1.TabIndex = 17;
            // 
            // lblAlerta
            // 
            this.lblAlerta.AutoSize = true;
            this.lblAlerta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlerta.ForeColor = System.Drawing.Color.Red;
            this.lblAlerta.Location = new System.Drawing.Point(4, 40);
            this.lblAlerta.Name = "lblAlerta";
            this.lblAlerta.Size = new System.Drawing.Size(417, 13);
            this.lblAlerta.TabIndex = 17;
            this.lblAlerta.Text = "No hay archivos disponibles para este cliente en su evaluación anterior.";
            this.lblAlerta.Visible = false;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(571, 3);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 6;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click_1);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(637, 3);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click_1);
            // 
            // cboTipoEvaluacion
            // 
            this.cboTipoEvaluacion.FormattingEnabled = true;
            this.cboTipoEvaluacion.Location = new System.Drawing.Point(135, 33);
            this.cboTipoEvaluacion.Name = "cboTipoEvaluacion";
            this.cboTipoEvaluacion.Size = new System.Drawing.Size(121, 21);
            this.cboTipoEvaluacion.TabIndex = 66;
            this.cboTipoEvaluacion.SelectedValueChanged += new System.EventHandler(this.cboTipoEvaluacion_SelectedValueChanged);
            // 
            // lblTipoVisita
            // 
            this.lblTipoVisita.AutoSize = true;
            this.lblTipoVisita.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoVisita.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoVisita.Location = new System.Drawing.Point(15, 36);
            this.lblTipoVisita.Name = "lblTipoVisita";
            this.lblTipoVisita.Size = new System.Drawing.Size(114, 13);
            this.lblTipoVisita.TabIndex = 67;
            this.lblTipoVisita.Text = "Tipo de evaluación";
            // 
            // frmSeleccionarDocEvalAnterior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(712, 1002);
            this.Controls.Add(this.lblTipoVisita);
            this.Controls.Add(this.cboTipoEvaluacion);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dtgDocumentosEvalAnterior);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmSeleccionarDocEvalAnterior";
            this.Text = "Selección de documentos de evaluación anterior";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSeleccionarDocEvalAnterior_FormClosing);
            this.Load += new System.EventHandler(this.frmSeleccionarDocEvalAnterior_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtgDocumentosEvalAnterior, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cboTipoEvaluacion, 0);
            this.Controls.SetChildIndex(this.lblTipoVisita, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumentosEvalAnterior)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPdf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.DataGridView dtgDocumentosEvalAnterior;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private AxAcroPDFLib.AxAcroPDF contPdf;
        private System.Windows.Forms.Panel panel1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelPdf;
        private System.Windows.Forms.Panel panelImg;
        private System.Windows.Forms.Label lblAlerta;
        private GEN.ControlesBase.cboBase cboTipoEvaluacion;
        private GEN.ControlesBase.lblBase lblTipoVisita;
    }
}