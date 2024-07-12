using CRE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboTipoCondonacion : cboBase
    {
        public cboTipoCondonacion()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;            
        }

        public cboTipoCondonacion(IContainer container)
        {
            container.Add(this);
            InitializeComponent();            
        }
        public void ListaUnaCondonacion(int idTipoCondonacion, int idPerfil)
        {
            clsCNCondonacion cnTipoCondonacion = new clsCNCondonacion();
            DataTable dt = cnTipoCondonacion.listaTipoCondonacion(idTipoCondonacion, idPerfil);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoCondonacion"].ToString();
            this.DisplayMember = dt.Columns["cNombreCondonacion"].ToString();
        }
        public void ListaCondonacionVigentes(int idPerfil)
        {
            clsCNCondonacion cnTipoCondonacion = new clsCNCondonacion();
            DataTable dt = cnTipoCondonacion.listaTipoCondonacion(0, idPerfil);
            dt.DefaultView.RowFilter = ("lVigente = 1");

            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoCondonacion"].ToString();
            this.DisplayMember = dt.Columns["cNombreCondonacion"].ToString();
        }
    }
}
