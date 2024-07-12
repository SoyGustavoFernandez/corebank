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
    public partial class cboPersonalGen : cboBase
    {
        Int32 idAgencia = clsVarGlobal.nIdAgencia;
        public cboPersonalGen()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboPersonalGen(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            PersonaAgencia(idAgencia);

        }
        public void PersTodasAgen()
        {
            
            clsCNPersonalGen Listapersonal = new clsCNPersonalGen();
            DataTable dt = Listapersonal.ListaPersonal(0);//(0)para listar todas las agencias
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idUsuario"].ToString();
            this.DisplayMember = dt.Columns["cNombre"].ToString();

        }
        public void PersonaAgencia(int IdAgencia) 
        {
            clsCNPersonalGen Listapersonal = new clsCNPersonalGen();
            DataTable dt = Listapersonal.ListaPersonal(IdAgencia);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idUsuario"].ToString();
            this.DisplayMember = dt.Columns["cNombre"].ToString();
        }

        public void PersonaAgencia(int IdAgencia, string cVarPerfil)
        {
            clsCNPersonalGen Listapersonal = new clsCNPersonalGen();
            DataTable dt = Listapersonal.CNListaPersonalPerfil(IdAgencia, cVarPerfil);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idUsuario"].ToString();
            this.DisplayMember = dt.Columns["cNombre"].ToString();
        }
    }
}
