using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
namespace GEN.ControlesBase
{
    public partial class cboAgencia : cboBase
    {
        public DataTable dtAgencia;
        public cboAgencia()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboAgencia(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            dtAgencia = new clsCNAgencia().LisAgen();
            this.DataSource = dtAgencia;
            this.ValueMember = dtAgencia.Columns["idAgencia"].ToString();
            this.DisplayMember = dtAgencia.Columns["cNombreAge"].ToString();
        }

        public void cargarAgencia(int idAgencia)
        {
            dtAgencia = new clsCNAgencia().LisAgen();
            this.DataSource = dtAgencia;
            this.ValueMember = dtAgencia.Columns["idAgencia"].ToString();
            this.DisplayMember = dtAgencia.Columns["cNombreAge"].ToString();
        }

        public void cargarSoloAgencias()
        {
            dtAgencia = new clsCNAgencia().LisSoloAgencias();
            this.DataSource = dtAgencia;
            this.ValueMember = dtAgencia.Columns["idAgencia"].ToString();
            this.DisplayMember = dtAgencia.Columns["cNombreAge"].ToString();
        }
        
    }
}
