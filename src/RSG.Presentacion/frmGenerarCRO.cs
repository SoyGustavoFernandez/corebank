using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using System.IO;
using RSG.CapaNegocio;
using EntityLayer;
using System.Xml;

namespace RSG.Presentacion
{
    public partial class frmGenerarCRO : frmBase
    {
        private clsCNCro objCro;
        private const string cTituloMsjes = "Generacion de Reportes CRO";

        #region Constructores

        public frmGenerarCRO()
        {
            InitializeComponent();
            objCro = new clsCNCro();
        }

        #endregion

        #region Eventos

        private void frmGenerarCRO_Load(object sender, EventArgs e)
        {
            CargarNombresReportes();
            CargarTipoProceso();
            CargarTipoEnvio();

            cboTipoProceso.SelectedIndex = -1;
            cboMeses.SelectedIndex = -1;
            nudAnio.Value = clsVarGlobal.dFecSystem.Date.Year;

            cboTipoEnvio.SelectedIndex = 0;
            cboTipoEnvio.Enabled = false;
        }

        private void chcSelec_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chklbReportes.Items.Count; i++)
            {
                chklbReportes.SetItemChecked(i, chcSelec.Checked);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            GenerarArchivos();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string ruta = dialog.SelectedPath;
                txtPath.Text = ruta;
            }
        }

        #endregion

        #region Métodos

        private bool ValidarDatos()
        {
            //==================================================================
            //--Validar Datos del Reporte
            //==================================================================
            if (cboTipoProceso.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el Tipo de Proceso del Reporte",
                    cTituloMsjes,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (cboTipoEnvio.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de envio del reporte.",
                    cTituloMsjes,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (cboMeses.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el mes del periodo del reporte.",
                    cTituloMsjes,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (nudAnio.Value < 0)
            {
                MessageBox.Show("Seleccione el año del periodo del reporte.",
                    cTituloMsjes,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtPath.Text.Trim()))
            {
                MessageBox.Show("Seleccione la ruta para la generación de archivos.",
                    cTituloMsjes,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CargarNombresReportes()
        {
            DataTable dtReportes = new DataTable();
            dtReportes.Columns.Add("nNroReporte", typeof(int));
            dtReportes.Columns.Add("cReporte", typeof(string));

            dtReportes.Rows.Add(1, "CR01 - Información de los clientes y garantes");
            dtReportes.Rows.Add(2, "CR02 - Stock de los activos recibidos como garantías ");
            dtReportes.Rows.Add(3, "CR03 - Operaciones de crédito");
            dtReportes.Rows.Add(4, "CR04 - Salidas de las operaciones individuales");
            dtReportes.Rows.Add(5, "CR05 - Transferencias de Cartera");
            dtReportes.Rows.Add(6, "CR06 - Modelos de Rating");

            chklbReportes.DataSource = dtReportes;
            chklbReportes.ValueMember = "nNroReporte";
            chklbReportes.DisplayMember = "cReporte";
        }

        private void CargarTipoProceso()
        {
            DataTable dtTipoProc = new DataTable();
            dtTipoProc.Columns.Add("cValTipProc", typeof(string));
            dtTipoProc.Columns.Add("cTipProc", typeof(string));

            dtTipoProc.Rows.Add("N", "Envio Regular");
            dtTipoProc.Rows.Add("R", "Reproceso");

            cboTipoProceso.ValueMember = "cValTipProc";
            cboTipoProceso.DisplayMember = "cTipProc";
            cboTipoProceso.DataSource = dtTipoProc;
        }

        private void CargarTipoEnvio()
        {
            DataTable dtTipoEnvio = new DataTable();
            dtTipoEnvio.Columns.Add("cValTipEnv", typeof(string));
            dtTipoEnvio.Columns.Add("cTipEnv", typeof(string));

            DataRow dr = dtTipoEnvio.NewRow();
            dr["cValTipEnv"] = "F";
            dr["cTipEnv"] = "Informacion al dia del Cierre";
            dtTipoEnvio.Rows.Add(dr);

            DataRow dr1 = dtTipoEnvio.NewRow();
            dr1["cValTipEnv"] = "X";
            dr1["cTipEnv"] = "Reporte sin Datos";
            dtTipoEnvio.Rows.Add(dr1);

            DataRow dr2 = dtTipoEnvio.NewRow();
            dr2["cValTipEnv"] = "I";
            dr2["cTipEnv"] = "Informacion Adelantada";
            dtTipoEnvio.Rows.Add(dr2);

            cboTipoEnvio.DataSource = dtTipoEnvio;
            cboTipoEnvio.ValueMember = dtTipoEnvio.Columns["cValTipEnv"].ToString();
            cboTipoEnvio.DisplayMember = dtTipoEnvio.Columns["cTipEnv"].ToString();
        }

        private void GenerarArchivos()
        {
            DataTable result = new DataTable();
            DateTime dFecha = new DateTime(Convert.ToInt16(nudAnio.Value), Convert.ToInt16(cboMeses.SelectedValue), 1).AddMonths(1).AddDays(-1);
            foreach (DataRowView item in chklbReportes.CheckedItems)
            {
                switch (Convert.ToInt16(item.Row["nNroReporte"]))
                {
                    case 1:
                        result = objCro.CNCR01(dFecha, cboTipoProceso.SelectedValue.ToString(), cboTipoEnvio.SelectedValue.ToString());
                        CrearArchivo(result.Rows[0]["cro"].ToString(), "CR01" + dFecha.ToString("yyyyMM") + Convert.ToInt32(clsVarApl.dicVarGen["cCodInst"]));
                        break;
                    case 2:
                        result = objCro.CNCR02(dFecha, cboTipoProceso.SelectedValue.ToString(), cboTipoEnvio.SelectedValue.ToString());
                        CrearArchivo(result.Rows[0]["cro"].ToString(), "CR02" + dFecha.ToString("yyyyMM") + Convert.ToInt32(clsVarApl.dicVarGen["cCodInst"]));
                        break;
                    case 3:
                        result = objCro.CNCR03(dFecha, cboTipoProceso.SelectedValue.ToString(), cboTipoEnvio.SelectedValue.ToString());
                        CrearArchivo(result.Rows[0]["cro"].ToString(), "CR03" + dFecha.ToString("yyyyMM") + Convert.ToInt32(clsVarApl.dicVarGen["cCodInst"]));
                        break;
                    case 4:
                        result = objCro.CNCR04(dFecha, cboTipoProceso.SelectedValue.ToString(), cboTipoEnvio.SelectedValue.ToString());
                        CrearArchivo(result.Rows[0]["cro"].ToString(), "CR04" + dFecha.ToString("yyyyMM") + Convert.ToInt32(clsVarApl.dicVarGen["cCodInst"]));
                        break;
                    case 5:
                        result = objCro.CNCR05(dFecha, cboTipoProceso.SelectedValue.ToString(), cboTipoEnvio.SelectedValue.ToString());
                        CrearArchivo(result.Rows[0]["cro"].ToString(), "CR05" + dFecha.ToString("yyyyMM") + Convert.ToInt32(clsVarApl.dicVarGen["cCodInst"]));
                        break;
                    case 6:
                        result = objCro.CNCR06(dFecha, cboTipoProceso.SelectedValue.ToString(), cboTipoEnvio.SelectedValue.ToString());
                        CrearArchivo(result.Rows[0]["cro"].ToString(), "CR06" + dFecha.ToString("yyyyMM") + Convert.ToInt32(clsVarApl.dicVarGen["cCodInst"]));
                        break;
                }
            }

            MessageBox.Show("Archivos Generados Correctamente.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CrearArchivo(string cXml, string cNombre)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(cXml);
                UTF8Encoding encoding = new UTF8Encoding(false);
                StringWriterWithEncoding sw = new StringWriterWithEncoding(encoding);
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t",
                    NewLineChars = "\r\n",
                    NewLineHandling = NewLineHandling.Replace,
                    Encoding = encoding
                };

                using (XmlWriter writer = XmlWriter.Create(sw, settings))
                {
                    doc.Save(writer);
                }

                string cPathFile = string.Format(@"{0}\{1}.xml", txtPath.Text.Trim(),cNombre);
                File.WriteAllText(cPathFile, sw.ToString(), encoding);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #endregion

    }

    public sealed class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding encoding;

        public StringWriterWithEncoding(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public override Encoding Encoding
        {
            get { return encoding; }
        }
    }
}
