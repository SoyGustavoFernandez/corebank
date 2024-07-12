using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.Funciones;

namespace GEN.ControlesBase
{
    public partial class ConFechaAñoMes : UserControl
    {
        public event EventHandler eventCambio;
        DataTable dtMeses;
        public int idMes { get; set; }
        public string cMes { get; set; }
        public int anio { get; set; }

        public string cPeriodo
        {
            get { return ("00" + idMes.ToString()).Substring(("00" + idMes.ToString()).Length - 2) + @"/" + anio.ToString(); }
        }

        public string cPeriodoEncaje
        {
            get { return ("00" + idMes.ToString()).Substring(("00" + idMes.ToString()).Length - 2) + anio.ToString(); }
        }

        public ConFechaAñoMes()
        {
            InitializeComponent();
            nudAnio.Maximum = clsVarGlobal.dFecSystem.Year;
        }

        public void ActualizaPeriodo(int nMes,int nAño)
        {
            cboMeses.SelectedValue = nMes;
            nudAnio.Value = nAño;
            idMes = Convert.ToInt32(cboMeses.SelectedValue);
            cMes = cboMeses.Text;
            anio = Convert.ToInt32(nudAnio.Value);
        }

        private void cboMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            idMes = Convert.ToInt32(cboMeses.SelectedValue);
            cMes = cboMeses.Text;
            anio = Convert.ToInt32(nudAnio.Value);

            if (eventCambio != null)
                eventCambio(sender, e);
        }

        private void nudAnio_ValueChanged(object sender, EventArgs e)
        {
            idMes = Convert.ToInt32(cboMeses.SelectedValue);
            cMes = cboMeses.Text;
            anio = Convert.ToInt32(nudAnio.Value);

            if (eventCambio != null)
                eventCambio(sender, e);
        }

        private void ConFechaAñoMes_Load(object sender, EventArgs e)
        {
            idMes = Convert.ToInt32(cboMeses.SelectedValue);
            cMes = cboMeses.Text;
            anio = Convert.ToInt32(nudAnio.Value);
            nudAnio.Value = clsVarGlobal.dFecSystem.Year;
        }

        public DateTime RetornaFecha()
        {
            return new DateTime(anio, idMes, 1);
        }

    }
}
