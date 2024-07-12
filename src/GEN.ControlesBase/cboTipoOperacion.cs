using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipoOperacion : cboBase
    {
        public clsCNGenAdmOpe ListaOpe = new clsCNGenAdmOpe();
        public DataTable dtOperacion;

        public cboTipoOperacion()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoOperacion(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            ListadoTipoOpe();
        }

        public void ListadoTipoOpe()
        {
            dtOperacion = ListaOpe.ListadoTipoOpe();
            this.DataSource = dtOperacion;
            this.ValueMember = dtOperacion.Columns["idTipoOperacion"].ToString();
            this.DisplayMember = dtOperacion.Columns["cTipoOperacion"].ToString();
        }

        public void LisTipoOperacModulo(int idModulo)
        {
            dtOperacion = ListaOpe.LisTipoOperacModulo(idModulo);
            this.DataSource = dtOperacion;
            this.ValueMember = dtOperacion.Columns["idTipoOperacion"].ToString();
            this.DisplayMember = dtOperacion.Columns["cTipoOperacion"].ToString();
        }

        public void LisTipoOperacTodosModulo(int idModulo)
        {
            dtOperacion = ListaOpe.LisTipoOperacModulo(idModulo);

            DataRow row = dtOperacion.NewRow();
            row["idTipoOperacion"] = 0;
            row["cTipoOperacion"] = "TODOS";
            dtOperacion.Rows.Add(row);

            this.DataSource = dtOperacion;
            this.ValueMember = dtOperacion.Columns["idTipoOperacion"].ToString();
            this.DisplayMember = dtOperacion.Columns["cTipoOperacion"].ToString();
        }

        public void LisTipoOperacProduc(int idProducto)
        {
            dtOperacion = ListaOpe.CNLisTipoOperacProduc(idProducto);
            //dtOperacion.DefaultView.RowFilter = ("lVigente = 1");
            DataRow[] rows;
            rows = dtOperacion.Select("lVigente = 0");

            foreach (DataRow row in rows)
                dtOperacion.Rows.Remove(row);

            this.DataSource = dtOperacion;
            this.ValueMember = dtOperacion.Columns["idTipOpeProduc"].ToString();
            this.DisplayMember = dtOperacion.Columns["cTipoOperacion"].ToString();
        }

        //Lista todos los tipos de operaciones por 'Producto que representan a los Módulos' (Productos con IdProductoPadre NULL)
        //Se usa sólo en el formulario de mantenimiento de 'Configuración de Gastos'
        public void LisTiposOperacProducto(int idProducto)
        {
            dtOperacion = ListaOpe.LisTiposOperacProducto(idProducto);

            this.DataSource = dtOperacion;
            this.ValueMember = dtOperacion.Columns["idTipoOperacion"].ToString();
            this.DisplayMember = dtOperacion.Columns["cTipoOperacion"].ToString();
        }

    }
}
