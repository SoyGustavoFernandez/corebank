using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("GEN.ControlesBaseWeb", "SolIntELS")]
namespace GEN.ControlesBaseWeb
{
    [ToolboxData("<{0}:btnCancelar runat=server></{0}:btnCancelar>")]
    public class btnCancelar : Button
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.Text = "Cancelar";
            this.CssClass = "btnBase_Cancelar";
            base.Render(writer);
        }
    }
}
