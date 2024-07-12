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
    public partial class cboCargoPersonalcs : cboBase
    {
        public cboCargoPersonalcs()
        {
            InitializeComponent();
        }

        public cboCargoPersonalcs(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            
        }
        public void CargarCargo(int idArea) { 
            clsCNListaCargoPersonal objCargoPersonal = new clsCNListaCargoPersonal();
            DataTable dtCargoPersonal = objCargoPersonal.ListacargoPersonal(idArea);
            this.DataSource = dtCargoPersonal;
            this.ValueMember = dtCargoPersonal.Columns[0].ToString();
            this.DisplayMember = dtCargoPersonal.Columns[1].ToString();        
        }
        public void CargarCargoTodos(int idArea)
        {
            clsCNListaCargoPersonal objCargoPersonal = new clsCNListaCargoPersonal();
            DataTable dtCargoPersonal = objCargoPersonal.ListacargoPersonalTodos(idArea);
            this.DataSource = dtCargoPersonal;
            this.ValueMember = dtCargoPersonal.Columns[0].ToString();
            this.DisplayMember = dtCargoPersonal.Columns[1].ToString();
        }
    }
}
