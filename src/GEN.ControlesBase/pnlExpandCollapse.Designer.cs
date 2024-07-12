namespace GEN.ControlesBase
{
    partial class pnlExpandCollapse
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
            this.components = new System.ComponentModel.Container();
            this._btnExpandCollapse = new btnExpandCollapse();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // _btnExpandCollapse
            // 
            this._btnExpandCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btnExpandCollapse.ButtonSize = btnExpandCollapse.ExpandButtonSize.Small;
            this._btnExpandCollapse.ButtonStyle = btnExpandCollapse.ExpandButtonStyle.Classic;
            this._btnExpandCollapse.IsExpanded = false;
            this._btnExpandCollapse.Location = new System.Drawing.Point(3, 3);
            this._btnExpandCollapse.Name = "_btnExpandCollapse";
            this._btnExpandCollapse.TabIndex = 0;
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 50;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // ExpandCollapsePanel
            // 
            this.Controls.Add(this._btnExpandCollapse);
            this.Size = new System.Drawing.Size(365, 319);
            this.ResumeLayout(false);
        }

        #endregion

        private btnExpandCollapse _btnExpandCollapse;
        private System.Windows.Forms.Timer animationTimer;
    }
}
