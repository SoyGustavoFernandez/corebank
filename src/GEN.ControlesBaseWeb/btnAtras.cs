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
    [ToolboxData("<{0}:btnAtras runat=server></{0}:btnAtras>")]
    public class btnAtras : Button
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.Text = "Atras";
            this.CssClass = "btnBase_Atras";

            base.Render(writer);
        }
    }
}
