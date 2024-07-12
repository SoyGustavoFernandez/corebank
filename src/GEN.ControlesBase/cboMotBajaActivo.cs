using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using LOG.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboMotBajaActivo : cboBase
    {
        public cboMotBajaActivo()
        {
            InitializeComponent();
        }

        public cboMotBajaActivo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNActivos ListaMotBajaActivo = new clsCNActivos();
            DataTable dtListaMotBajaActivo = ListaMotBajaActivo.CNMotivoBajaActivos();
            this.DataSource = dtListaMotBajaActivo;
            this.ValueMember = dtListaMotBajaActivo.Columns[0].ToString();
            this.DisplayMember = dtListaMotBajaActivo.Columns[1].ToString();
        }

    }
}


