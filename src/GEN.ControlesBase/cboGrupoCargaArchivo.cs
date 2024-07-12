using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;


namespace GEN.ControlesBase
{
    public partial class cboGrupoCargaArchivo : cboBase
    {
        clsCNGrupoCargaArchivo clsGrupo = new clsCNGrupoCargaArchivo();

        public cboGrupoCargaArchivo()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboGrupoCargaArchivo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ListarGrupoCargaArchivo()
        {
            DataTable dtOperacion = clsGrupo.CNListarGrupoCargaArchivo();
            this.DataSource = dtOperacion;
            this.ValueMember = dtOperacion.Columns["idDescTipoDoc"].ToString();
            this.DisplayMember = dtOperacion.Columns["cDescTipoDoc"].ToString();
        }
    }
}
