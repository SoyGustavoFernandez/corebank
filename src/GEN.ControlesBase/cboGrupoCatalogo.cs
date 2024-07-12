using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;
using LOG.CapaNegocio;


namespace GEN.ControlesBase
{
    public partial class cboGrupoCatalogo : cboBase
    {
        public cboGrupoCatalogo()
        {
            InitializeComponent();
        }

        public cboGrupoCatalogo(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        public void ListarGrupo(int idPadreGrupo, int idTipoBien, bool lTodos = false)
        {
            clsCNGrupoCatalogo objGrupo = new clsCNGrupoCatalogo();
            DataTable dt = objGrupo.CNListaGrupoCatalogo(idPadreGrupo, idTipoBien, lTodos);
            this.ValueMember = dt.Columns["idGrupoActivo"].ToString();
            this.DisplayMember = dt.Columns["cNombreGrupo"].ToString();
            this.DataSource = dt;
        }

        public void ListarGruposActivos(int idGrupoActivo)
        {
            DataTable dtGrupo = new clsCNActivos().CNListaGrupoActivos(idGrupoActivo);
            this.ValueMember = dtGrupo.Columns["idGrupoActivo"].ToString();
            this.DisplayMember = dtGrupo.Columns["cNombreGrupo"].ToString();
            this.DataSource = dtGrupo;
        }
    }
}
