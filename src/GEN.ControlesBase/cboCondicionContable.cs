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
    public partial class cboCondicionContable : cboBase
    {
        clsCNCondicionContable CondicionContable = new clsCNCondicionContable();
        public DataTable dtCondicionContable;

        public cboCondicionContable()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboCondicionContable(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            dtCondicionContable = CondicionContable.CNListarCondicionContable();

            this.DataSource = dtCondicionContable;
            this.ValueMember = dtCondicionContable.Columns["IdContable"].ToString();
            this.DisplayMember = dtCondicionContable.Columns["cContable"].ToString();
        }

        public void ListarCondicionContable(int idProducto)
        {
            dtCondicionContable = CondicionContable.CNListarConCtbProduc(idProducto);
            DataRow[] rows;
            rows = dtCondicionContable.Select("lVigente = 0");

            foreach (DataRow row in rows)
                dtCondicionContable.Rows.Remove(row);

            //dtCondicionContable.DefaultView.RowFilter = ("lVigente = 1");

            this.DataSource = dtCondicionContable;
            this.ValueMember = dtCondicionContable.Columns["idConCtbProduc"].ToString();
            this.DisplayMember = dtCondicionContable.Columns["cContable"].ToString();
        }

        //Lista todos las Condiciones Contables por 'Producto que representan a los Módulos' (Productos con IdProductoPadre NULL)
        //Se usa sólo en el formulario de mantenimiento de 'Configuración de Gastos'
        public void ListarCondicionContablexProducto(int idProducto)
        {
            dtCondicionContable = CondicionContable.ListarCondicionContablexProducto(idProducto);

            this.DataSource = dtCondicionContable;
            this.ValueMember = dtCondicionContable.Columns["IdContable"].ToString();
            this.DisplayMember = dtCondicionContable.Columns["cContable"].ToString();
        }

        public void ListarCondicionContablePorModulo(int idModulo)
        {
            dtCondicionContable = CondicionContable.CNListarConCtbModulo(idModulo);

            this.DataSource = dtCondicionContable;
            this.ValueMember = dtCondicionContable.Columns["IdContable"].ToString();
            this.DisplayMember = dtCondicionContable.Columns["cContable"].ToString();
        }

        public void listaCondicionContableXIDs(int idModulo)
        {
            dtCondicionContable = CondicionContable.listaCondicionContableXIDs(idModulo);
            this.DataSource = dtCondicionContable;
            this.ValueMember = dtCondicionContable.Columns["IdContable"].ToString();
            this.DisplayMember = dtCondicionContable.Columns["cContable"].ToString();            
        }
    }
}
