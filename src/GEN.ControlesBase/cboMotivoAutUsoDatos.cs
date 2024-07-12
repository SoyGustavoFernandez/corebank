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
    public partial class cboMotivoAutUsoDatos : cboBase
    {
        private clsCNTipAutUsoDatos objTipo ; 
        public DataTable datoTipoAutorizacion;

        public cboMotivoAutUsoDatos()
        {
            InitializeComponent(); 
        }

        public cboMotivoAutUsoDatos(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
          
        }
        public void CargaMotAutUsoDatoTodos()
        {
            objTipo = new clsCNTipAutUsoDatos();
            DataTable dtTipo = objTipo.CNMotivoAutUsoDatos(false);
            datoTipoAutorizacion = dtTipo;
            this.DataSource = dtTipo;
            this.DisplayMember = dtTipo.Columns["cMotivo"].ToString();
            this.ValueMember = dtTipo.Columns["idMotivo"].ToString();
        }
        public void cboMotivoAutUsoDatosRemoto()
        {
            objTipo = new clsCNTipAutUsoDatos();
            var  dtTipo = objTipo.CNMotivoAutUsoDatos(true);
            datoTipoAutorizacion = dtTipo;
             
                try
                {
                    this.DataSource = dtTipo;
                    this.DisplayMember = dtTipo.Columns["cMotivo"].ToString();
                    this.ValueMember = dtTipo.Columns["idMotivo"].ToString();
                }
                catch (Exception e)
                {

                }
             
        }
    }
}
