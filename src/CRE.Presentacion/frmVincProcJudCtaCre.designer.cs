namespace CRE.Presentacion
{
    partial class frmVincProcJudCtaCre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVincProcJudCtaCre));
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.grbProcJud = new GEN.ControlesBase.grbBase(this.components);
            this.dtgProcJud = new GEN.ControlesBase.dtgBase(this.components);
            this.grbCtaCred = new GEN.ControlesBase.grbBase(this.components);
            this.dtgCtaCred = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btn_Vincular = new GEN.BotonesBase.Btn_Vincular();
            this.grbProcJud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcJud)).BeginInit();
            this.grbCtaCred.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCtaCred)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(13, 12);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(532, 105);
            this.conBusCli.TabIndex = 2;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // grbProcJud
            // 
            this.grbProcJud.Controls.Add(this.dtgProcJud);
            this.grbProcJud.Location = new System.Drawing.Point(13, 123);
            this.grbProcJud.Name = "grbProcJud";
            this.grbProcJud.Size = new System.Drawing.Size(533, 188);
            this.grbProcJud.TabIndex = 3;
            this.grbProcJud.TabStop = false;
            this.grbProcJud.Text = "Procesos Judiciales";
            // 
            // dtgProcJud
            // 
            this.dtgProcJud.AllowUserToAddRows = false;
            this.dtgProcJud.AllowUserToDeleteRows = false;
            this.dtgProcJud.AllowUserToResizeColumns = false;
            this.dtgProcJud.AllowUserToResizeRows = false;
            this.dtgProcJud.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProcJud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProcJud.Location = new System.Drawing.Point(10, 19);
            this.dtgProcJud.MultiSelect = false;
            this.dtgProcJud.Name = "dtgProcJud";
            this.dtgProcJud.ReadOnly = true;
            this.dtgProcJud.RowHeadersVisible = false;
            this.dtgProcJud.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProcJud.Size = new System.Drawing.Size(512, 150);
            this.dtgProcJud.TabIndex = 0;
            // 
            // grbCtaCred
            // 
            this.grbCtaCred.Controls.Add(this.dtgCtaCred);
            this.grbCtaCred.Location = new System.Drawing.Point(13, 317);
            this.grbCtaCred.Name = "grbCtaCred";
            this.grbCtaCred.Size = new System.Drawing.Size(533, 188);
            this.grbCtaCred.TabIndex = 4;
            this.grbCtaCred.TabStop = false;
            this.grbCtaCred.Text = "Cuentas de Crédito";
            // 
            // dtgCtaCred
            // 
            this.dtgCtaCred.AllowUserToAddRows = false;
            this.dtgCtaCred.AllowUserToDeleteRows = false;
            this.dtgCtaCred.AllowUserToResizeColumns = false;
            this.dtgCtaCred.AllowUserToResizeRows = false;
            this.dtgCtaCred.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCtaCred.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCtaCred.Location = new System.Drawing.Point(10, 19);
            this.dtgCtaCred.MultiSelect = false;
            this.dtgCtaCred.Name = "dtgCtaCred";
            this.dtgCtaCred.ReadOnly = true;
            this.dtgCtaCred.RowHeadersVisible = false;
            this.dtgCtaCred.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCtaCred.Size = new System.Drawing.Size(512, 150);
            this.dtgCtaCred.TabIndex = 0;
            this.dtgCtaCred.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCtaCred_CellContentClick);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(485, 511);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(419, 511);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btn_Vincular
            // 
            this.btn_Vincular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Vincular.BackgroundImage")));
            this.btn_Vincular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Vincular.Image = ((System.Drawing.Image)(resources.GetObject("btn_Vincular.Image")));
            this.btn_Vincular.Location = new System.Drawing.Point(353, 511);
            this.btn_Vincular.Name = "btn_Vincular";
            this.btn_Vincular.Size = new System.Drawing.Size(60, 50);
            this.btn_Vincular.TabIndex = 7;
            this.btn_Vincular.Text = "&Vincular";
            this.btn_Vincular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Vincular.UseVisualStyleBackColor = true;
            this.btn_Vincular.Click += new System.EventHandler(this.btn_Vincular_Click);
            // 
            // frmVincProcJudCtaCre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 589);
            this.Controls.Add(this.btn_Vincular);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbCtaCred);
            this.Controls.Add(this.grbProcJud);
            this.Controls.Add(this.conBusCli);
            this.Name = "frmVincProcJudCtaCre";
            this.Text = "Vincular procesos judiciales a créditos";
            this.Load += new System.EventHandler(this.frmVincProcJudCtaCre_Load);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.grbProcJud, 0);
            this.Controls.SetChildIndex(this.grbCtaCred, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btn_Vincular, 0);
            this.grbProcJud.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcJud)).EndInit();
            this.grbCtaCred.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCtaCred)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.grbBase grbProcJud;
        private GEN.ControlesBase.dtgBase dtgProcJud;
        private GEN.ControlesBase.grbBase grbCtaCred;
        private GEN.ControlesBase.dtgBase dtgCtaCred;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.Btn_Vincular btn_Vincular;
    }
}