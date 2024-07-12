namespace SPL.Presentacion
{
    partial class FrmImpresionMasiva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImpresionMasiva));
            this.cboTipoEvalScoring1 = new GEN.ControlesBase.cboTipoEvalScoring(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.nudBase1 = new GEN.ControlesBase.nudBase(this.components);
            this.nudBase2 = new GEN.ControlesBase.nudBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudBase1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBase2)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipoEvalScoring1
            // 
            this.cboTipoEvalScoring1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEvalScoring1.FormattingEnabled = true;
            this.cboTipoEvalScoring1.Location = new System.Drawing.Point(153, 23);
            this.cboTipoEvalScoring1.Name = "cboTipoEvalScoring1";
            this.cboTipoEvalScoring1.Size = new System.Drawing.Size(187, 21);
            this.cboTipoEvalScoring1.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(46, 26);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(101, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Tipo Evaluación:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 53);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(135, 13);
            this.lblBase2.TabIndex = 7;
            this.lblBase2.Text = "Nro Evaluacion Inicial:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(20, 79);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(127, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Nro Evaluacion Final:";
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(153, 102);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 9;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // nudBase1
            // 
            this.nudBase1.Location = new System.Drawing.Point(153, 51);
            this.nudBase1.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudBase1.Name = "nudBase1";
            this.nudBase1.Size = new System.Drawing.Size(120, 20);
            this.nudBase1.TabIndex = 10;
            // 
            // nudBase2
            // 
            this.nudBase2.Location = new System.Drawing.Point(153, 77);
            this.nudBase2.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudBase2.Name = "nudBase2";
            this.nudBase2.Size = new System.Drawing.Size(120, 20);
            this.nudBase2.TabIndex = 11;
            // 
            // FrmImpresionMasiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 190);
            this.Controls.Add(this.nudBase2);
            this.Controls.Add(this.nudBase1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoEvalScoring1);
            this.Name = "FrmImpresionMasiva";
            this.Text = "Impresion Masiva de Evaluaciones";
            this.Controls.SetChildIndex(this.cboTipoEvalScoring1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.nudBase1, 0);
            this.Controls.SetChildIndex(this.nudBase2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudBase1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBase2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboTipoEvalScoring cboTipoEvalScoring1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.nudBase nudBase1;
        private GEN.ControlesBase.nudBase nudBase2;
    }
}