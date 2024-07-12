namespace CRE.Presentacion
{
    partial class frmExperienciaClienteCalifica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExperienciaClienteCalifica));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tbCalificacion = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.lblRespuestas = new System.Windows.Forms.Label();
            this.btnRegistrar1 = new GEN.BotonesBase.Boton();
            this.txtCalificacion = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGuardar2 = new GEN.BotonesBase.Boton();
            this.btnRegresar1 = new GEN.BotonesBase.btnRegresar();
            this.label10 = new System.Windows.Forms.Label();
            this.txExcepcion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCalificacion.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.DarkRed;
            this.linkLabel1.Location = new System.Drawing.Point(41, 325);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(216, 16);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cliente no desea la Encuesta";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tbCalificacion
            // 
            this.tbCalificacion.Controls.Add(this.tabPage1);
            this.tbCalificacion.Controls.Add(this.tabPage2);
            this.tbCalificacion.Location = new System.Drawing.Point(-4, -22);
            this.tbCalificacion.Name = "tbCalificacion";
            this.tbCalificacion.SelectedIndex = 0;
            this.tbCalificacion.Size = new System.Drawing.Size(632, 401);
            this.tbCalificacion.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblRespuestas);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.lblPregunta);
            this.tabPage1.Controls.Add(this.btnRegistrar1);
            this.tabPage1.Controls.Add(this.linkLabel1);
            this.tabPage1.Controls.Add(this.txtCalificacion);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(624, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(252, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 35);
            this.panel1.TabIndex = 22;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // lblPregunta
            // 
            this.lblPregunta.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPregunta.Location = new System.Drawing.Point(41, 15);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(550, 23);
            this.lblPregunta.TabIndex = 13;
            this.lblPregunta.Text = "--";
            this.lblPregunta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPregunta.Click += new System.EventHandler(this.lblPregunta_Click);
            // 
            // lblRespuestas
            // 
            this.lblRespuestas.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuestas.Location = new System.Drawing.Point(100, 63);
            this.lblRespuestas.Name = "lblRespuestas";
            this.lblRespuestas.Size = new System.Drawing.Size(491, 200);
            this.lblRespuestas.TabIndex = 12;
            this.lblRespuestas.Text = "--";
            this.lblRespuestas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRespuestas.Click += new System.EventHandler(this.lblRespuestas_Click);
            // 
            // btnRegistrar1
            // 
            this.btnRegistrar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegistrar1.Image = global::CRE.Presentacion.Properties.Resources.btnSmallEdit;
            this.btnRegistrar1.Location = new System.Drawing.Point(282, 269);
            this.btnRegistrar1.Name = "btnRegistrar1";
            this.btnRegistrar1.Size = new System.Drawing.Size(60, 50);
            this.btnRegistrar1.TabIndex = 11;
            this.btnRegistrar1.Text = "Registrar";
            this.btnRegistrar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegistrar1.UseVisualStyleBackColor = true;
            this.btnRegistrar1.Visible = false;
            this.btnRegistrar1.Click += new System.EventHandler(this.btnRegistrar1_Click);
            // 
            // txtCalificacion
            // 
            this.txtCalificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalificacion.Location = new System.Drawing.Point(266, 237);
            this.txtCalificacion.MaxLength = 1;
            this.txtCalificacion.Name = "txtCalificacion";
            this.txtCalificacion.PasswordChar = '*';
            this.txtCalificacion.Size = new System.Drawing.Size(92, 26);
            this.txtCalificacion.TabIndex = 21;
            this.txtCalificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCalificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalificacion_KeyPress);
            this.txtCalificacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCalificacion_KeyUp);
            this.txtCalificacion.Leave += new System.EventHandler(this.txtCalificacion_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage2.Controls.Add(this.btnGuardar2);
            this.tabPage2.Controls.Add(this.btnRegresar1);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txExcepcion);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(624, 375);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "tabPage2";
            // 
            // btnGuardar2
            // 
            this.btnGuardar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGuardar2.Image = global::CRE.Presentacion.Properties.Resources.btnFileSave;
            this.btnGuardar2.Location = new System.Drawing.Point(319, 287);
            this.btnGuardar2.Name = "btnGuardar2";
            this.btnGuardar2.Size = new System.Drawing.Size(60, 50);
            this.btnGuardar2.TabIndex = 19;
            this.btnGuardar2.Text = "Guardar";
            this.btnGuardar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar2.UseVisualStyleBackColor = true;
            this.btnGuardar2.Click += new System.EventHandler(this.btnGuardar2_Click);
            // 
            // btnRegresar1
            // 
            this.btnRegresar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegresar1.BackgroundImage")));
            this.btnRegresar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegresar1.Location = new System.Drawing.Point(253, 287);
            this.btnRegresar1.Name = "btnRegresar1";
            this.btnRegresar1.Size = new System.Drawing.Size(60, 50);
            this.btnRegresar1.TabIndex = 17;
            this.btnRegresar1.Text = "Regresar";
            this.btnRegresar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegresar1.UseVisualStyleBackColor = true;
            this.btnRegresar1.Click += new System.EventHandler(this.btnRegresar1_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Firebrick;
            this.label10.Location = new System.Drawing.Point(41, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(550, 76);
            this.label10.TabIndex = 14;
            this.label10.Text = "IMPORTANTE:\r\n\r\nTodo Personal que registre información falsa se realizará la amone" +
    "stación y/o sanción correspondiente.\r\n";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txExcepcion
            // 
            this.txExcepcion.Location = new System.Drawing.Point(44, 85);
            this.txExcepcion.Multiline = true;
            this.txExcepcion.Name = "txExcepcion";
            this.txExcepcion.Size = new System.Drawing.Size(547, 98);
            this.txExcepcion.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(550, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Detallar el problema para reportar la excepción.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 23);
            this.label1.TabIndex = 23;
            this.label1.Text = "Cliente calificará:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmExperienciaClienteCalifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 398);
            this.Controls.Add(this.tbCalificacion);
            this.Name = "frmExperienciaClienteCalifica";
            this.Text = "Calificación del Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExperienciaClienteCalifica_FormClosing);
            this.Load += new System.EventHandler(this.frmExperienciaClienteCalifica_Load);
            this.Controls.SetChildIndex(this.tbCalificacion, 0);
            this.tbCalificacion.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabControl tbCalificacion;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txExcepcion;
        private GEN.BotonesBase.btnRegresar btnRegresar1;
        private GEN.BotonesBase.Boton btnRegistrar1;
        private GEN.BotonesBase.Boton btnGuardar2;
        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.Label lblRespuestas;
        private System.Windows.Forms.TextBox txtCalificacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}