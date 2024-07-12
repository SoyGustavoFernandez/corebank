using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.ControlesBase;
using EntityLayer;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboPersonal : cboBase
    {
        public Int32 idAgencia = clsVarGlobal.nIdAgencia;

        public cboPersonal()
        {
            InitializeComponent();
        }

        public cboPersonal(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            clsCNPersonal Listapersonal = new clsCNPersonal();
            DataTable dt = Listapersonal.ListaPersonal(idAgencia);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idUsuario"].ToString();
            this.DisplayMember = dt.Columns["cNombre"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        public void CargarcboPersonal(int idAgenciaAsig)
        {
            
            clsCNPersonal Listapersonal = new clsCNPersonal();
            DataTable dt = Listapersonal.ListaPersonal(idAgenciaAsig);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idUsuario"].ToString();
            this.DisplayMember = dt.Columns["cNombre"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;

        }


    }
}
