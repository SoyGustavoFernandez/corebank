namespace CAJ.Presentacion
{
    partial class frmConciliacionServWesternUnion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConciliacionServWesternUnion));
            this.cboZona = new GEN.ControlesBase.cboZona(this.components);
            this.cboColaborador = new GEN.ControlesBase.cboBase(this.components);
            this.cboAgencia = new GEN.ControlesBase.cboBase(this.components);
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFecha = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtTotSoles2 = new GEN.ControlesBase.txtBase(this.components);
            this.txtTotDolar1 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboTipRec = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgWesternUnionExcel = new System.Windows.Forms.DataGridView();
            this.lblEstadoConciliacion = new System.Windows.Forms.Label();
            this.txtTotDolar2 = new GEN.ControlesBase.txtBase(this.components);
            this.txtTotSoles1 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.dtgEmisionRec = new System.Windows.Forms.DataGridView();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape4 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnComparar = new System.Windows.Forms.Button();
            this.btnVincular = new GEN.BotonesBase.Btn_Vincular();
            this.btnConsultar = new GEN.BotonesBase.btnConsultar();
            this.btnImportar = new GEN.BotonesBase.Boton();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgWesternUnionExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmisionRec)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboZona
            // 
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(42, 51);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(220, 21);
            this.cboZona.TabIndex = 8;
            this.cboZona.SelectedIndexChanged += new System.EventHandler(this.cboZona_SelectedIndexChanged);
            // 
            // cboColaborador
            // 
            this.cboColaborador.FormattingEnabled = true;
            this.cboColaborador.Location = new System.Drawing.Point(532, 51);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(256, 21);
            this.cboColaborador.TabIndex = 14;
            // 
            // cboAgencia
            // 
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(286, 51);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(215, 21);
            this.cboAgencia.TabIndex = 15;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(286, 99);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(215, 20);
            this.dtpFecha.TabIndex = 18;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFecha.ForeColor = System.Drawing.Color.Navy;
            this.lblFecha.Location = new System.Drawing.Point(283, 83);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 13);
            this.lblFecha.TabIndex = 19;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(39, 32);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 20;
            this.lblBase1.Text = "Región:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(283, 32);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 21;
            this.lblBase2.Text = "Agencia:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(529, 35);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 22;
            this.lblBase3.Text = "Usuario:";
            // 
            // txtTotSoles2
            // 
            this.txtTotSoles2.Enabled = false;
            this.txtTotSoles2.Location = new System.Drawing.Point(658, 467);
            this.txtTotSoles2.Name = "txtTotSoles2";
            this.txtTotSoles2.Size = new System.Drawing.Size(82, 20);
            this.txtTotSoles2.TabIndex = 24;
            // 
            // txtTotDolar1
            // 
            this.txtTotDolar1.Enabled = false;
            this.txtTotDolar1.Location = new System.Drawing.Point(329, 467);
            this.txtTotDolar1.Name = "txtTotDolar1";
            this.txtTotDolar1.Size = new System.Drawing.Size(83, 20);
            this.txtTotDolar1.TabIndex = 25;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(678, 23);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(134, 13);
            this.lblBase4.TabIndex = 26;
            this.lblBase4.Text = "Western Union (Excel)";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(227, 23);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(68, 13);
            this.lblBase5.TabIndex = 27;
            this.lblBase5.Text = "Core Bank";
            // 
            // cboTipRec
            // 
            this.cboTipRec.FormattingEnabled = true;
            this.cboTipRec.Location = new System.Drawing.Point(42, 98);
            this.cboTipRec.Name = "cboTipRec";
            this.cboTipRec.Size = new System.Drawing.Size(220, 21);
            this.cboTipRec.TabIndex = 28;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(39, 82);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(171, 13);
            this.lblBase6.TabIndex = 29;
            this.lblBase6.Text = "Tipo de Recibo (Core Bank):";
            // 
            // dtgWesternUnionExcel
            // 
            this.dtgWesternUnionExcel.AllowUserToResizeColumns = false;
            this.dtgWesternUnionExcel.AllowUserToResizeRows = false;
            this.dtgWesternUnionExcel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgWesternUnionExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgWesternUnionExcel.Location = new System.Drawing.Point(496, 39);
            this.dtgWesternUnionExcel.Name = "dtgWesternUnionExcel";
            this.dtgWesternUnionExcel.ReadOnly = true;
            this.dtgWesternUnionExcel.ShowEditingIcon = false;
            this.dtgWesternUnionExcel.Size = new System.Drawing.Size(476, 275);
            this.dtgWesternUnionExcel.TabIndex = 32;
            this.dtgWesternUnionExcel.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgWesternUnionExcel_ColumnHeaderMouseClick);
            this.dtgWesternUnionExcel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dtgWesternUnionExcel_Scroll);
            // 
            // lblEstadoConciliacion
            // 
            this.lblEstadoConciliacion.AutoSize = true;
            this.lblEstadoConciliacion.ForeColor = System.Drawing.Color.Red;
            this.lblEstadoConciliacion.Location = new System.Drawing.Point(448, 468);
            this.lblEstadoConciliacion.Name = "lblEstadoConciliacion";
            this.lblEstadoConciliacion.Size = new System.Drawing.Size(129, 13);
            this.lblEstadoConciliacion.TabIndex = 34;
            this.lblEstadoConciliacion.Text = "Conciliación no Realizada";
            // 
            // txtTotDolar2
            // 
            this.txtTotDolar2.Enabled = false;
            this.txtTotDolar2.Location = new System.Drawing.Point(815, 467);
            this.txtTotDolar2.Name = "txtTotDolar2";
            this.txtTotDolar2.Size = new System.Drawing.Size(81, 20);
            this.txtTotDolar2.TabIndex = 35;
            // 
            // txtTotSoles1
            // 
            this.txtTotSoles1.Enabled = false;
            this.txtTotSoles1.Location = new System.Drawing.Point(171, 467);
            this.txtTotSoles1.Name = "txtTotSoles1";
            this.txtTotSoles1.Size = new System.Drawing.Size(83, 20);
            this.txtTotSoles1.TabIndex = 36;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(601, 470);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(52, 13);
            this.lblBase8.TabIndex = 40;
            this.lblBase8.Text = "Total S/";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(746, 470);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(64, 13);
            this.lblBase10.TabIndex = 41;
            this.lblBase10.Text = "Total USD";
            // 
            // dtgEmisionRec
            // 
            this.dtgEmisionRec.AllowUserToResizeColumns = false;
            this.dtgEmisionRec.AllowUserToResizeRows = false;
            this.dtgEmisionRec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEmisionRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEmisionRec.Location = new System.Drawing.Point(6, 39);
            this.dtgEmisionRec.Name = "dtgEmisionRec";
            this.dtgEmisionRec.ReadOnly = true;
            this.dtgEmisionRec.ShowEditingIcon = false;
            this.dtgEmisionRec.Size = new System.Drawing.Size(485, 275);
            this.dtgEmisionRec.TabIndex = 42;
            this.dtgEmisionRec.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgEmisionRec_ColumnHeaderMouseClick);
            this.dtgEmisionRec.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dtgEmisionRec_Scroll);
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(62, 524);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(137, 13);
            this.lblBase11.TabIndex = 45;
            this.lblBase11.Text = "Registros Coincidentes";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(62, 543);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(278, 13);
            this.lblBase12.TabIndex = 46;
            this.lblBase12.Text = "Registros No Coincidentes o Contenido Faltante";
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(62, 562);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(241, 13);
            this.lblBase13.TabIndex = 47;
            this.lblBase13.Text = "Registros Coincidentes para Verificación ";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(62, 581);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(166, 13);
            this.lblBase14.TabIndex = 48;
            this.lblBase14.Text = "Registros Sin Comparación ";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(260, 470);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(64, 13);
            this.lblBase9.TabIndex = 49;
            this.lblBase9.Text = "Total USD";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(114, 470);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(52, 13);
            this.lblBase7.TabIndex = 50;
            this.lblBase7.Text = "Total S/";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shapeContainer2);
            this.groupBox1.Location = new System.Drawing.Point(16, 504);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 102);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leyenda";
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(3, 16);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape4,
            this.rectangleShape3,
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer2.Size = new System.Drawing.Size(341, 83);
            this.shapeContainer2.TabIndex = 0;
            this.shapeContainer2.TabStop = false;
            // 
            // rectangleShape4
            // 
            this.rectangleShape4.BackColor = System.Drawing.Color.LightYellow;
            this.rectangleShape4.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape4.BorderColor = System.Drawing.Color.LightYellow;
            this.rectangleShape4.Location = new System.Drawing.Point(23, 62);
            this.rectangleShape4.Name = "rectangleShape4";
            this.rectangleShape4.Size = new System.Drawing.Size(10, 10);
            // 
            // rectangleShape3
            // 
            this.rectangleShape3.BackColor = System.Drawing.Color.LightPink;
            this.rectangleShape3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape3.BorderColor = System.Drawing.Color.LightPink;
            this.rectangleShape3.Location = new System.Drawing.Point(22, 24);
            this.rectangleShape3.Name = "rectangleShape3";
            this.rectangleShape3.Size = new System.Drawing.Size(10, 10);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackColor = System.Drawing.Color.White;
            this.rectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape2.BorderColor = System.Drawing.Color.White;
            this.rectangleShape2.Location = new System.Drawing.Point(22, 43);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(10, 10);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.LightGreen;
            this.rectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape1.BorderColor = System.Drawing.Color.LightGreen;
            this.rectangleShape1.Location = new System.Drawing.Point(22, 6);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(10, 10);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(16, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(981, 123);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtgWesternUnionExcel);
            this.groupBox3.Controls.Add(this.dtgEmisionRec);
            this.groupBox3.Controls.Add(this.lblBase5);
            this.groupBox3.Controls.Add(this.lblBase4);
            this.groupBox3.Location = new System.Drawing.Point(19, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(978, 351);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tablas de comparación de recibos (Western Union)";
            // 
            // btnComparar
            // 
            this.btnComparar.BackgroundImage = global::CAJ.Presentacion.Properties.Resources.btnUnir;
            this.btnComparar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnComparar.Location = new System.Drawing.Point(793, 543);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.Size = new System.Drawing.Size(72, 50);
            this.btnComparar.TabIndex = 43;
            this.btnComparar.Text = "&Comparar";
            this.btnComparar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnComparar.UseVisualStyleBackColor = true;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            // 
            // btnVincular
            // 
            this.btnVincular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincular.BackgroundImage")));
            this.btnVincular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincular.Enabled = false;
            this.btnVincular.Image = ((System.Drawing.Image)(resources.GetObject("btnVincular.Image")));
            this.btnVincular.Location = new System.Drawing.Point(871, 543);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(60, 50);
            this.btnVincular.TabIndex = 33;
            this.btnVincular.Text = "&Vincular";
            this.btnVincular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincular.UseVisualStyleBackColor = true;
            this.btnVincular.Click += new System.EventHandler(this.btn_Vincular_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar.BackgroundImage")));
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar.Location = new System.Drawing.Point(662, 543);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar.TabIndex = 23;
            this.btnConsultar.Text = "&Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackgroundImage = global::CAJ.Presentacion.Properties.Resources.exportexcel;
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar.Enabled = false;
            this.btnImportar.Location = new System.Drawing.Point(728, 543);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(60, 50);
            this.btnImportar.TabIndex = 3;
            this.btnImportar.Text = "&Importar Excel";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(937, 543);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 54;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmConciliacionServWesternUnion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 631);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.lblBase14);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.lblBase12);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.btnComparar);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.txtTotSoles1);
            this.Controls.Add(this.txtTotDolar2);
            this.Controls.Add(this.lblEstadoConciliacion);
            this.Controls.Add(this.btnVincular);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.cboTipRec);
            this.Controls.Add(this.txtTotDolar1);
            this.Controls.Add(this.txtTotSoles2);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.cboColaborador);
            this.Controls.Add(this.cboZona);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmConciliacionServWesternUnion";
            this.Text = "Conciliación de Servicios Western Union";
            this.Load += new System.EventHandler(this.frmConciliacionServWesternUnion_Load);
            this.Shown += new System.EventHandler(this.frmConciliacionServWesternUnion_Shown);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnImportar, 0);
            this.Controls.SetChildIndex(this.cboZona, 0);
            this.Controls.SetChildIndex(this.cboColaborador, 0);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.lblFecha, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnConsultar, 0);
            this.Controls.SetChildIndex(this.txtTotSoles2, 0);
            this.Controls.SetChildIndex(this.txtTotDolar1, 0);
            this.Controls.SetChildIndex(this.cboTipRec, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.btnVincular, 0);
            this.Controls.SetChildIndex(this.lblEstadoConciliacion, 0);
            this.Controls.SetChildIndex(this.txtTotDolar2, 0);
            this.Controls.SetChildIndex(this.txtTotSoles1, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.btnComparar, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.lblBase12, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            this.Controls.SetChildIndex(this.lblBase14, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgWesternUnionExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmisionRec)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.Boton btnImportar;
        private GEN.ControlesBase.cboZona cboZona;
        private GEN.ControlesBase.cboBase cboColaborador;
        private GEN.ControlesBase.cboBase cboAgencia;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.lblBase lblFecha;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnConsultar btnConsultar;
        private GEN.ControlesBase.txtBase txtTotSoles2;
        private GEN.ControlesBase.txtBase txtTotDolar1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboTipRec;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.DataGridView dtgWesternUnionExcel;
        private GEN.BotonesBase.Btn_Vincular btnVincular;
        private System.Windows.Forms.Label lblEstadoConciliacion;
        private GEN.ControlesBase.txtBase txtTotDolar2;
        private GEN.ControlesBase.txtBase txtTotSoles1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase10;
        private System.Windows.Forms.DataGridView dtgEmisionRec;
        private System.Windows.Forms.Button btnComparar;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase7;
        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape4;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}