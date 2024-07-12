using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SER.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoMensaje : cboBase
    {
        public cboTipoMensaje()
        {
            InitializeComponent();
        }

        public cboTipoMensaje(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            CargaTipos();
        }

        private void CargaTipos()
        {
            DataTable dt = new clsCNMensajeTexto().CNListarTipoMensaje();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoMensaje"].ToString();
            this.DisplayMember = dt.Columns["cTipoMensaje"].ToString();
        }

    }
}
