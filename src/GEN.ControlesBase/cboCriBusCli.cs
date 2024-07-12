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
    public partial class cboCriBusCli : cboBase
    {
        public cboCriBusCli()
        {
            InitializeComponent();
        }

        public cboCriBusCli(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            cargaDatos();
          }
        public void cargaDatos(bool lBloqueaBusquedaNombre = false)
        {
            clsCNCriBusCli ListaCriBusCli = new clsCNCriBusCli();
            DataTable TablaCriBus = ListaCriBusCli.ListarCriBusCli();
            DataTable dtCriBus = TablaCriBus.Clone();
            foreach (DataRow item in TablaCriBus.Rows)
            {
                if (Convert.ToBoolean(item["lVigente"]) && !(Convert.ToInt32(item["idCriBusCli"]) == 2 && lBloqueaBusquedaNombre))
                {
                    dtCriBus.ImportRow(item);
                }
            }
            this.DataSource = dtCriBus;
            this.ValueMember = dtCriBus.Columns[0].ToString();
            this.DisplayMember = dtCriBus.Columns[1].ToString();
        }
    }
}
