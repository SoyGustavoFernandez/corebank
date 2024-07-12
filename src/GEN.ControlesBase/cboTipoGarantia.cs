using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoGarantia : cboBase
    {
        
        public cboTipoGarantia()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoGarantia(IContainer container)
        {
            container.Add(this);
            InitializeComponent();            
            this.DataSource = new clsCNGarantia().listarTipoGarantia();
            this.ValueMember = "idTipoGarantia";
            this.DisplayMember = "cTipoGarantia";
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        public void cargarTipoByClase(int idClase)
        {
            var dt = new clsCNGarantia().listarTipoGarantia();

            DataTable dtTipoGarantia = dt.Clone();

            (from item in dt.AsEnumerable()
             where (int)item["idClaseGarantia"] == idClase
             select item).CopyToDataTable(dtTipoGarantia, LoadOption.OverwriteChanges);

            this.DataSource = dtTipoGarantia;
            this.ValueMember = "idTipoGarantia";
            this.DisplayMember = "cTipoGarantia";
        }

        /* Funciones para el cambio de estado */
        public void cargarTipoByClaseFiltroCambioEstado(int idClase)
        {
            var dt = new clsCNGarantia().listarTipoGarantiaFiltroCambioEstado(idClase);

            this.DataSource = dt;
            this.ValueMember = "idTipoGarantia";
            this.DisplayMember = "cTipoGarantia";
            
        }

    }
}
