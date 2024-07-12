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
    public partial class chklFormatoAho : chklbBase
    {
        public chklFormatoAho()
        {
            InitializeComponent();
        }

        public chklFormatoAho(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.CargarDatos();
        }
        public void CargarDatos( )
        {
            clsCNListaFormatoImp ListaFormato = new clsCNListaFormatoImp();
            DataTable dt = ListaFormato.CNListaFormato();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();

        }
    }
}
