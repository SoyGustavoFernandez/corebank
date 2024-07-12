using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboSegmentoSocio : cboBase
    {
        private clsCNSegmentoSocio ObjSegmento = new clsCNSegmentoSocio();
        public cboSegmentoSocio()
        {
            InitializeComponent();
        }

        public cboSegmentoSocio(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        public void ListarSegmento(int idTipoPersona)
        {
            DataTable dtSegmento = ObjSegmento.CNListaSegmentoSocio(idTipoPersona);
            this.DataSource = dtSegmento;
            this.ValueMember = dtSegmento.Columns["idSegmentoSocio"].ToString();
            this.DisplayMember = dtSegmento.Columns["cSegmentoSocio"].ToString();
        }
    }
}
