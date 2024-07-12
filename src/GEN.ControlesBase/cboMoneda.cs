using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboMoneda : cboBase
    {
        public cboMoneda()
        {
            InitializeComponent();
            
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboMoneda(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            CargaDatos();
        }

        public void CargaDatos()
        {
            clsCNMoneda ListadoMoneda = new clsCNMoneda();
            DataTable dt = ListadoMoneda.listarMoneda();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public void MonedasYNinguno()
        {
            clsCNMoneda ListadoMoneda = new clsCNMoneda();
            DataTable dt = ListadoMoneda.listarMoneda();

            DataRow row = dt.NewRow();
            row["idMoneda"] = -1;
            row["cMoneda"] = "NINGUNO";
            dt.Rows.Add(row);

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString(); 
        }

        public void MonedasYTodos()
        {
            clsCNMoneda ListadoMoneda = new clsCNMoneda();
            DataTable dt = ListadoMoneda.listarMoneda();
            
            DataRow row = dt.NewRow();
            row["idMoneda"] = 0;
            row["cMoneda"] = "TODOS";
            dt.Rows.Add(row);
                        
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();   
        }

        public void MonedasLimiteCob()
        {
            clsCNMoneda ListadoMoneda = new clsCNMoneda();
            DataTable dt = ListadoMoneda.listarMoneda();

            DataRow row = dt.NewRow();
            row["idMoneda"] =3;
            row["cMoneda"] = "AMBAS MONEDAS";
            dt.Rows.Add(row);

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
        public DataTable CargaDatosConta()
        {
            clsCNMoneda ListadoMoneda = new clsCNMoneda();
            DataTable dt = ListadoMoneda.listarMonedaConta() ;
            dt.Rows[0]["cMoneda"]="REEXPRESADO";
            return  dt;            
        }
        public void CargaDatosContaIntegrado()
        {
            clsCNMoneda ListadoMoneda = new clsCNMoneda();
            DataTable dt = ListadoMoneda.listarMonedaConta();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
        public void CargaDatosContaTodos()
        {
            clsCNMoneda ListadoMoneda = new clsCNMoneda();
            DataTable dt = ListadoMoneda.listarMonedaConta();
            DataRow row = dt.NewRow();
            row["idMoneda"] = 3;
            row["cMoneda"] = "DOLAR ORIGINAL";
            dt.Rows.Add(row);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
