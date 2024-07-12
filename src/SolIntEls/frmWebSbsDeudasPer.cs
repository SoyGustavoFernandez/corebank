using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;

namespace SolIntEls
{
    public partial class frmWebSbsDeudasPer : frmBase
    {
        #region Variable Globales



        #endregion

        public frmWebSbsDeudasPer()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.wbrDniReniec.Url = new Uri(clsVarApl.dicVarGen["curlDeudasSBS"]);
            this.wbrDniReniec.Refresh(); 
        }


        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;


            return lValida;
        }

        private void formatoGrid()
        {

        }

        private void limpiar()
        {

        }

        #endregion
    }
}
