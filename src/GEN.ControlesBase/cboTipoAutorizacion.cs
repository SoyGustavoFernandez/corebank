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
    public partial class cboTipoAutorizacion : cboBase
    {
        private clsCNTipAutUsoDatos cnobjTipo = new clsCNTipAutUsoDatos();
        public DataTable datoTipoAutorizacion;

        public cboTipoAutorizacion()
        {
            InitializeComponent();
        }

        public cboTipoAutorizacion(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            DataTable dtTipo = cnobjTipo.CNListaTipoAutUsoDatos();
            datoTipoAutorizacion = dtTipo;
            this.DataSource = dtTipo;
            this.DisplayMember = dtTipo.Columns["cTipo"].ToString();
            this.ValueMember = dtTipo.Columns["idTipo"].ToString();
        }

        public void filtroTodosAutorizaciones(){
            DataTable dtTipo = cnobjTipo.CNListaTipoAutUsoDatos();
            datoTipoAutorizacion = dtTipo;

            DataRow row = dtTipo.NewRow();
            row["idTipo"] = 0;
            row["cTipo"] = "TODOS";

            row["nTiempoVigencia"] = 0;
            dtTipo.Rows.Add(row);


            this.DataSource = dtTipo;
            this.ValueMember = dtTipo.Columns[0].ToString();
            this.DisplayMember = dtTipo.Columns[1].ToString();
            this.ValueMember = dtTipo.Columns["idTipo"].ToString();
            this.DisplayMember = dtTipo.Columns["cTipo"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public int obtenerTiempo(int idTipo){
            int nTiempo = 0;
                for(int i=0; i < datoTipoAutorizacion.Rows.Count; i++)
                {
                    if ((int)datoTipoAutorizacion.Rows[i]["idTipo"] == idTipo)
                    {
                        nTiempo = (int)datoTipoAutorizacion.Rows[i]["nTiempoVigencia"];
                    }
                }
                return nTiempo;
        }
    }
}
