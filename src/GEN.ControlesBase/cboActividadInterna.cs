using CLI.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboActividadInterna : cboBase
    {
        public DataTable dtActividadInt = new DataTable();
        clsCNListaActivEco cnactividadinterna = new clsCNListaActivEco();

        public cboActividadInterna()
        {
            InitializeComponent();
        }

        public cboActividadInterna(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            cargarVigentes();

        }

        public void cargarTodo()
        {
            dtActividadInt = cnactividadinterna.CNListarActividadesInternasTodo();
            if (dtActividadInt.Rows.Count > 0)
            {
                dtActividadInt = (from item in dtActividadInt.AsEnumerable()
                                  orderby item.Field<string>("cActividadInterna")
                                    select item).CopyToDataTable();
            }
            this.ValueMember = dtActividadInt.Columns[0].ToString();
            this.DisplayMember = dtActividadInt.Columns[1].ToString();
            this.DataSource = dtActividadInt;
        }
        public void cargarVigentes()
        {
            dtActividadInt = cnactividadinterna.CNListarActividadesInternasVigentes();
            if (dtActividadInt.Rows.Count > 0)
            {
                dtActividadInt = (from item in dtActividadInt.AsEnumerable()
                                  orderby item.Field<string>("cActividadInterna")
                                  select item).CopyToDataTable();
            }
            this.ValueMember = dtActividadInt.Columns[0].ToString();
            this.DisplayMember = dtActividadInt.Columns[1].ToString();
            this.DataSource = dtActividadInt;
        }
        public void cargarVigenteNinguno()
        {
            dtActividadInt = cnactividadinterna.CNListarActividadesInternasVigentes();
            DataRow dr = dtActividadInt.NewRow();
            
            dr["idActividadinterna"] = 0;
            dr["cActividadInterna"] = "** NINGUNO **";

            dtActividadInt.Rows.Add(dr);
            if (dtActividadInt.Rows.Count > 0)
            {
                dtActividadInt = (from item in dtActividadInt.AsEnumerable()
                                  orderby item.Field<string>("cActividadInterna")
                                  select item).CopyToDataTable();
            }
            
            this.ValueMember = dtActividadInt.Columns[0].ToString();
            this.DisplayMember = dtActividadInt.Columns[1].ToString();
            this.DataSource = dtActividadInt;
        }
    }
}
