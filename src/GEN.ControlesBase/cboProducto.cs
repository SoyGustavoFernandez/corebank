using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboProducto : cboBase
    {
        clsCNProducto ListaProducto = new clsCNProducto();
        DataTable dt;

        public cboProducto()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboProducto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CargarProducto(Int32 CodPro, bool lVigente)
        {
            dt = ListaProducto.listarProducto(CodPro, lVigente);
            this.ValueMember = "IdProducto";
            this.DisplayMember = "cProducto";
            this.DataSource = dt;
            
        }

        public void CargarProducto(Int32 CodPro, int idOperacion = 0)
        {
            dt = ListaProducto.listarProducto(CodPro, true, true, idOperacion);
            this.ValueMember = "IdProducto";
            this.DisplayMember = "cProducto";
            this.DataSource = dt;
            
        }

        public void CargarProducto(int CodPro, bool lVigente, bool lConfigurable)
        {
            dt = ListaProducto.listarProducto(CodPro, lVigente, lConfigurable);
            this.ValueMember = "IdProducto";
            this.DisplayMember = "cProducto";
            this.DataSource = dt;
        }

        public void CargarProductoModNivel(Int32 idModulo, Int32 idNivelProd)
        {
            dt = ListaProducto.ListarProductoModNivel(idModulo, idNivelProd);
            dt.DefaultView.RowFilter = ("lVigente = 1");
            this.ValueMember = "IdProducto";
            this.DisplayMember = "cProducto";
            this.DataSource = dt;
           
        }

        public void CargarProductoModNivelRec(Int32 idModulo, Int32 idNivelProd)
        {
            //dt = ListaProducto.ListarProductoModNivel(idModulo, idNivelProd);
            dt = ListaProducto.ListarProductoModNivelRec(idModulo, idNivelProd);
            dt.DefaultView.RowFilter = ("lVigente = 1");
            this.ValueMember = "IdProducto";
            this.DisplayMember = "cProducto";
            this.DataSource = dt;

        }

        public void CargarProductoModNivelTodos(Int32 idModulo, Int32 idNivelProd)
        {
            dt = ListaProducto.ListarProductoModNivel(idModulo, idNivelProd);
            dt.DefaultView.RowFilter = ("lVigente = 1");

            dt.Rows.Add(new object[] { 0, "Todos", "Todos", 0, true });
            this.ValueMember = "IdProducto";
            this.DisplayMember = "cProducto";
            this.DataSource = dt;
            
        }

        public void ProductosYTodos(Int32 CodPro, bool lVigente)
        {
            dt = ListaProducto.listarProducto(CodPro, lVigente);

            DataRow row = dt.NewRow();
            row["idProducto"] = 0;
            row["cProducto"] = "TODOS";
            dt.Rows.Add(row);
            this.ValueMember = "IdProducto";
            this.DisplayMember = "cProducto";
            this.DataSource = dt;
            
        }

        public void ProductosYTodos(Int32 CodPro)
        {
            dt = ListaProducto.listarProducto(CodPro, true);

            DataRow row = dt.NewRow();
            row["idProducto"] = 0;
            row["cProducto"] = "TODOS";
            dt.Rows.Add(row);
            this.ValueMember = "IdProducto";
            this.DisplayMember = "cProducto";
            this.DataSource = dt;
        }
        public void SubProductoxTipoCredito(int TipoCredito, int idModulo)
        {
            dt = ListaProducto.SubProductoxTipoCredito(TipoCredito, idModulo);

            //DataRow row = dt.NewRow();
            //row["idProducto"] = 0;
            //row["cProducto"] = "TODOS";
            //dt.Rows.Add(row);
            this.ValueMember = "IdProducto";
            this.DisplayMember = "cProducto";
            this.DataSource = dt;
        }
        public void CargarProductoNivelTipEvalCred(string cIDsTipEvalCred, int nNivel, int idProducto)
        {
            dt = ListaProducto.CNCargarProductoNivelTipEvalCred(cIDsTipEvalCred, nNivel, idProducto);
            this.ValueMember = "IdProducto";
            this.DisplayMember = "cProducto";
            this.DataSource = dt;

        }
    }
}
