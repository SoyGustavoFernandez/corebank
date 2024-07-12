namespace GEN.ControlesBase
{
    partial class ConEvalCualitativa
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtTotalPuntaje = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgEvalCualit = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmActualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.ttpCriteriosSis = new GEN.ControlesBase.ttpToolTip();
            this.bindingEvalCualit = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvalCualit)).BeginInit();
            this.panel7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEvalCualit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTotalPuntaje
            // 
            this.txtTotalPuntaje.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalPuntaje.Enabled = false;
            this.txtTotalPuntaje.Location = new System.Drawing.Point(385, 467);
            this.txtTotalPuntaje.Name = "txtTotalPuntaje";
            this.txtTotalPuntaje.Size = new System.Drawing.Size(45, 20);
            this.txtTotalPuntaje.TabIndex = 5;
            this.txtTotalPuntaje.Text = "0";
            this.txtTotalPuntaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 465);
            this.panel1.TabIndex = 78;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(428, 463);
            this.panel2.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgEvalCualit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(428, 439);
            this.panel3.TabIndex = 25;
            // 
            // dtgEvalCualit
            // 
            this.dtgEvalCualit.AllowUserToAddRows = false;
            this.dtgEvalCualit.AllowUserToDeleteRows = false;
            this.dtgEvalCualit.AllowUserToResizeColumns = false;
            this.dtgEvalCualit.AllowUserToResizeRows = false;
            this.dtgEvalCualit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEvalCualit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgEvalCualit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgEvalCualit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvalCualit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEvalCualit.Location = new System.Drawing.Point(0, 0);
            this.dtgEvalCualit.MultiSelect = false;
            this.dtgEvalCualit.Name = "dtgEvalCualit";
            this.dtgEvalCualit.RowHeadersVisible = false;
            this.dtgEvalCualit.Size = new System.Drawing.Size(428, 439);
            this.dtgEvalCualit.TabIndex = 10;
            this.dtgEvalCualit.TabStop = false;
            this.dtgEvalCualit.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEvalCualit_CellLeave);
            this.dtgEvalCualit.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dtgEvalCualit_CellToolTipTextNeeded);
            this.dtgEvalCualit.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEvalCualit_CellValueChanged);
            this.dtgEvalCualit.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEvalCualit_EditingControlShowing);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.menuStrip1);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(428, 24);
            this.panel7.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmActualizar});
            this.menuStrip1.Location = new System.Drawing.Point(200, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(228, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmActualizar
            // 
            this.tsmActualizar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmActualizar.Image = global::GEN.ControlesBase.Properties.Resources.refresh;
            this.tsmActualizar.Name = "tsmActualizar";
            this.tsmActualizar.Size = new System.Drawing.Size(28, 20);
            this.tsmActualizar.Text = "tsmActualizar";
            this.tsmActualizar.ToolTipText = "Actualizar datos de la evaluación cualitativa";
            this.tsmActualizar.Click += new System.EventHandler(this.tsmActualizar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 100;
            this.label1.Text = "Evaluación Cualitativa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel1);
            this.panel8.Controls.Add(this.lblBase1);
            this.panel8.Controls.Add(this.txtTotalPuntaje);
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(430, 488);
            this.panel8.TabIndex = 79;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(302, 470);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(81, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Total Puntaje";
            // 
            // ConEvalCualitativa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel8);
            this.Name = "ConEvalCualitativa";
            this.Size = new System.Drawing.Size(435, 493);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvalCualit)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEvalCualit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private lblBase lblBase1;
        private System.Windows.Forms.TextBox txtTotalPuntaje;
        private System.Windows.Forms.BindingSource bindingEvalCualit;
        private ttpToolTip ttpCriteriosSis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgEvalCualit;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmActualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel8;
    }
}
