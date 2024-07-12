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
    [ToolboxData("<{0}:btnQuitar runat=server></{0}:btnQuitar>")]
    public class btnQuitar : Button
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.Text = "Quitar";
            this.CssClass = "btnBase_Quitar";
            base.Render(writer);
        }
    }
}