namespace GEN.ControlesBase
{
    partial class PanelDockeable
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpControles = new System.Windows.Forms.TableLayoutPanel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.btnExpandCollapse = new System.Windows.Forms.Button();
            this.tlpControles.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpControles
            // 
            this.tlpControles.ColumnCount = 2;
            this.tlpControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlpControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpControles.Controls.Add(this.panelContent, 0, 0);
            this.tlpControles.Controls.Add(this.btnExpandCollapse, 0, 0);
            this.tlpControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControles.Location = new System.Drawing.Point(0, 0);
            this.tlpControles.Name = "tlpControles";
            this.tlpControles.RowCount = 1;
            this.tlpControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControles.Size = new System.Drawing.Size(290, 300);
            this.tlpControles.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(16, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(274, 300);
            this.panelContent.TabIndex = 2;
            // 
            // btnExpandCollapse
            // 
            this.btnExpandCollapse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExpandCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpandCollapse.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpandCollapse.Location = new System.Drawing.Point(0, 0);
            this.btnExpandCollapse.Margin = new System.Windows.Forms.Padding(0);
            this.btnExpandCollapse.Name = "btnExpandCollapse";
            this.btnExpandCollapse.Size = new System.Drawing.Size(16, 300);
            this.btnExpandCollapse.TabIndex = 1;
            this.btnExpandCollapse.Text = "<";
            this.btnExpandCollapse.UseVisualStyleBackColor = true;
            this.btnExpandCollapse.Click += new System.EventHandler(this.btnExpandCollapse_Click);
            // 
            // PanelDockeable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpControles);
            this.Name = "PanelDockeable";
            this.Size = new System.Drawing.Size(290, 300);
            this.tlpControles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpControles;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnExpandCollapse;
    }
}
