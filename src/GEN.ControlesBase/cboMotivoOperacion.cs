using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CAJ.CapaNegocio;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
using CNT.CapaNegocio;
namespace GEN.ControlesBase
{
    public partial class cboMotivoOperacion : cboBase
    {
        public cboMotivoOperacion()
        {
            InitializeComponent();
        }

        public cboMotivoOperacion(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ListarMotivoOperacion(int idTipoOperacion, int idPerfil)
        {
            clsCNControlOpe ListaMotOperacion = new clsCNControlOpe();
            DataTable dt = ListaMotOperacion.CNListaMotivoOperacion(idTipoOperacion,idPerfil);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idMotivoOperacion"].ToString();
            this.DisplayMember = dt.Columns["cMotivoOperacion"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void ListarMotivoOperacionCNT(int idTipoOperacion)
        {
            clsCNMaestroCuenta ListaMotOpeCnt = new clsCNMaestroCuenta();
            DataTable dt = ListaMotOpeCnt.CNListaMotivoOpeCnt(idTipoOperacion);
            this.ValueMember = dt.Columns["idMotivoOperacion"].ToString();
            this.DisplayMember = dt.Columns["cMotivoOperacion"].ToString();
            this.DataSource = dt;
           
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
