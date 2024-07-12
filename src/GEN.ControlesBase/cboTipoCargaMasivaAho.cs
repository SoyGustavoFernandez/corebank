using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEP.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoCargaMasivaAho : cboBase
    {
        public clsCNDeposito Ahorros = new clsCNDeposito();
        public DataTable tbTipoCargaMasiva;

        public cboTipoCargaMasivaAho()
        {
            InitializeComponent();
        }

        public cboTipoCargaMasivaAho(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            DataTable dtTemporal = new DataTable();
            dtTemporal.Columns.Add("idTipCarga", typeof(int));
            dtTemporal.Columns.Add("cTipCarga", typeof(String));
            dtTemporal.Rows.Add(1, "");
            this.DataSource = dtTemporal;
            this.ValueMember = "idTipCarga";
            this.DisplayMember = "cTipCarga";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void cargarDatos(int nModoSeleccion) 
        {
            tbTipoCargaMasiva = Ahorros.CNLisTipoCargaMasiva(nModoSeleccion);
            this.DataSource = tbTipoCargaMasiva;
            this.ValueMember = tbTipoCargaMasiva.Columns[0].ToString();
            this.DisplayMember = tbTipoCargaMasiva.Columns[1].ToString();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        } 
    }
}
