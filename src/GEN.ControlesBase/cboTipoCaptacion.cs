using CRE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoCaptacion : cboBase
    {
        clsCNPreSolicitud cnpresolicitud = new clsCNPreSolicitud();

        public cboTipoCaptacion()
        {
            InitializeComponent();
        }

        public cboTipoCaptacion(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            var dtTipoCaptacion = cnpresolicitud.CNlistarTipoCaptacion();
            this.DataSource = dtTipoCaptacion;
            this.ValueMember = dtTipoCaptacion.Columns[0].ToString();
            this.DisplayMember = dtTipoCaptacion.Columns[1].ToString();
        }
    }
}
