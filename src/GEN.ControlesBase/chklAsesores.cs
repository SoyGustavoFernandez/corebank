using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class chklAsesores : chklbBase
    {
        //Int32 idAgencia = clsVarGlobal.nIdAgencia;
        public Int32 idAgencia;
        public chklAsesores()
        {
            InitializeComponent();
        }

        public chklAsesores(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.CargarDatos(idAgencia);

           
        }
        public void CargarDatos(int idAgencia)
        {
            clsCNPersonalCreditos ListaPersonalCre = new clsCNPersonalCreditos();
            DataTable dt = ListaPersonalCre.ListarPersonalCre(idAgencia);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();

        }
    }
}
