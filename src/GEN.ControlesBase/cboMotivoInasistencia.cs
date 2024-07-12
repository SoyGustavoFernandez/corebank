using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GRH.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboMotivoInasistencia : cboBase
    {
        clsCNMotivoInasistencia objMotivoInasistencia = new clsCNMotivoInasistencia();

        public cboMotivoInasistencia()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboMotivoInasistencia(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ListarMotivosPermisoUsuario()
        {
            DataTable dtMotivoPermisoUsuario = objMotivoInasistencia.CNListarMotivosPermisoUsuario();
            this.DataSource = dtMotivoPermisoUsuario;
            this.ValueMember = dtMotivoPermisoUsuario.Columns["idMotivo"].ToString();
            this.DisplayMember = dtMotivoPermisoUsuario.Columns["cMotivo"].ToString();
        }

        public void ListarMotivosPermisoRRHH()
        {
            DataTable dtMotivoPermisoRRHH = objMotivoInasistencia.CNListarMotivosPermisoRRHH();
            this.DataSource = dtMotivoPermisoRRHH;
            this.ValueMember = dtMotivoPermisoRRHH.Columns["idMotivo"].ToString();
            this.DisplayMember = dtMotivoPermisoRRHH.Columns["cMotivo"].ToString();
        }

        public void ListarMotivosJustificacion()
        {
            DataTable dtMotivoJustificacion = objMotivoInasistencia.CNListarMotivosJustificacion();
            this.DataSource = dtMotivoJustificacion;
            this.ValueMember = dtMotivoJustificacion.Columns["idMotivo"].ToString();
            this.DisplayMember = dtMotivoJustificacion.Columns["cMotivo"].ToString();
        }
    }
}
