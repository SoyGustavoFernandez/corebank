using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class cboGrupoEconomico : cboBase
    {
        clslisGrupoEconomico gruposEconomicos;

        public cboGrupoEconomico()
        {
            InitializeComponent();

            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboGrupoEconomico(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            gruposEconomicos = new clsCNGrupoEconomico().listarGrupoEco();
            this.DataSource = gruposEconomicos;
            this.ValueMember = "idGrupoEconomico";
            this.DisplayMember = "cGrupoEconomico";
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public void cargarGrupoecoByIdtipo(int idTipoGruEco)
        {
            this.DataSource = null;

            var lista = from item in new clsCNGrupoEconomico().listarGrupoEco()
                        where item.idTipoGrupoEco == idTipoGruEco
                        select item;

            this.DataSource = lista.ToList();
            this.ValueMember = "idGrupoEconomico";
            this.DisplayMember = "cGrupoEconomico";
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
    }
}
