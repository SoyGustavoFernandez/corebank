using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;
namespace GEN.ControlesBase
{
    public partial class cboCanalRegistro : cboBase
    {
        public DataTable datoTipoAutorizacion;

        public cboCanalRegistro()
        {
            InitializeComponent();
        }

        public cboCanalRegistro(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            
        }
        public void cargarCanalRegistro()
        {
            clsCNTipAutUsoDatos cnobjTipo = new clsCNTipAutUsoDatos();

            DataTable dtTipo = cnobjTipo.CNListaCanalRegistro();
            datoTipoAutorizacion = dtTipo;
            this.DataSource = dtTipo;
            this.DisplayMember = dtTipo.Columns["cCanalRegistro"].ToString();
            this.ValueMember = dtTipo.Columns["idCanalRegistro"].ToString();
        }
        public void filtroTodosAutorizaciones(){
            clsCNTipAutUsoDatos cnobjTipo = new clsCNTipAutUsoDatos();
            DataTable dtTipo = cnobjTipo.CNListaCanalRegistro();
            datoTipoAutorizacion = dtTipo;

            DataRow row = dtTipo.NewRow();
            row["idCanalRegistro"] = 0;
            row["cCanalRegistro"] = "TODOS";
             
            dtTipo.Rows.Add(row);


            this.DataSource = dtTipo;
            this.ValueMember = dtTipo.Columns[0].ToString();
            this.DisplayMember = dtTipo.Columns[1].ToString();
            this.ValueMember = dtTipo.Columns["idCanalRegistro"].ToString();
            this.DisplayMember = dtTipo.Columns["cCanalRegistro"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
         
    }
}
