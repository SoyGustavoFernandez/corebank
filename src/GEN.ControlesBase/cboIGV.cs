using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboIGV : cboBase
    {
        #region atributos
        DataTable dtIGV;

        #endregion

        #region inicialización
        public cboIGV()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboIGV(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.cargarDatos();
        }
        #endregion

        #region inicialización
        public void cargarDatos()
        {

            clsCNIGV oCNIGV = new clsCNIGV();
            dtIGV = oCNIGV.obtenerListaIGV();

            this.DataSource = dtIGV;
            this.ValueMember = dtIGV.Columns["idIGV"].ToString();
            this.DisplayMember = dtIGV.Columns["nValorIGV"].ToString();
        }
        #endregion
    }
}
