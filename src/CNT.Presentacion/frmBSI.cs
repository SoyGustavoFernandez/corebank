using CNT.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNT.Presentacion
{
    public partial class frmBSI : frmBase
    {
        clsCNBalance objBalance = new clsCNBalance();
        public frmBSI()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFecha.Value;
            DataTable dtResultado = objBalance.CNBSI(dFecha);
            if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 0)
            {
                MessageBox.Show("Error en el proceso del BSI", "Procesa BSI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnExporTxt1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Proceso correcto del BSI", "Procesa BSI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnExporTxt1.Enabled = true;
            }
        }

        private void btnExporTxt1_Click(object sender, EventArgs e)
        {
            DateTime dfecha = dtpFecha.Value;
            string cVersion = "";
            if (rbtPreliminar.Checked)
	{
		 cVersion = "P";
	}
            else
	{
		 cVersion = "D";
	}

            DataTable dtBSI = objBalance.CNConsultaBSI(dfecha);
            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();

            string cRuta;
            string cNomArc;
            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + "\\" + clsVarApl.dicVarGen["cCodInst"] + dfecha.Year.ToString() + dfecha.Month.ToString("00") + cVersion + ".txt";
                StreamWriter sr = new StreamWriter(@cNomArc);
                string cCadena;
                for (int i = 0; i < dtBSI.Rows.Count; i++)
                {
                    cCadena = dtBSI.Rows[i]["cCadena"].ToString();
                    sr.WriteLine(cCadena);
                }
                sr.Close();
                MessageBox.Show("El archivo " + cNomArc + " Se generó correctamente", "PLE - Libro Mayor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rbtDefinitivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDefinitivo.Checked)
            {
                rbtPreliminar.Checked = false;
            }
            else
            {
                rbtPreliminar.Checked = true;
            }
        }

        private void rbtPreliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPreliminar.Checked)
            {
                rbtDefinitivo.Checked = false;
            }
            else
            {
                rbtDefinitivo.Checked = true;
            }
        }
    }
}
