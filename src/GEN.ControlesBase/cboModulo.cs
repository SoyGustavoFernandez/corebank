using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboModulo :  cboBase
    {
        public DataTable dtModulo;
        public cboModulo()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboModulo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            dtModulo = new clsCNModulo().LisModulo();
            this.DataSource = dtModulo;
            this.ValueMember = dtModulo.Columns["idModulo"].ToString();
            this.DisplayMember = dtModulo.Columns["cModulo"].ToString();
        }

        public void LisModuloBaseNegativa()
        {
            dtModulo = new clsCNModulo().LisModulo();
            dtModulo.DefaultView.RowFilter = ("lBaseNegativa = 1");

            this.DataSource = dtModulo;
            this.ValueMember = dtModulo.Columns["idModulo"].ToString();
            this.DisplayMember = dtModulo.Columns["cModulo"].ToString();
        }

        public void ListarSoloModulos()
        {
            dtModulo = new clsCNModulo().LisModulo();
            var enumModulos = dtModulo.AsEnumerable().Where(x => Convert.ToInt32(x["idModulo"]) > 0);
            if (enumModulos.Any())
            {
                dtModulo = enumModulos.CopyToDataTable();
            }

            ValueMember = "idModulo";
            DisplayMember = "cModulo";
            DataSource = dtModulo;
        }
        public void ListarTodosModulos() //jcasas
        {
            dtModulo = new clsCNModulo().LisModulo();
      
            ValueMember = "idModulo";
            DisplayMember = "cModulo";
            DataSource = dtModulo;
        }
    }
}
