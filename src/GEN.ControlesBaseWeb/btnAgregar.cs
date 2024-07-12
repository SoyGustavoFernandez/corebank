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
    [ToolboxData("<{0}:btnAgregar runat=server></{0}:btnAgregar>")]
    public class btnAgregar : Button
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.Text = "Agregar";
            this.CssClass = "btnBase_Agregar";

            base.Render(writer);
        }
    }
}
