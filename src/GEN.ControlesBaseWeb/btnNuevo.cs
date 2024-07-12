using System;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("GEN.ControlesBaseWeb", "SolIntELS")]
namespace GEN.ControlesBaseWeb
{
    [ToolboxData("<{0}:btnNuevo runat=server></{0}:btnNuevo>")]
    public class btnNuevo : Button
    {
        protected override void Render(HtmlTextWriter writer)
        {
            this.Text = "Nuevo";
            this.CssClass = "btnBase_Nuevo";
            base.Render(writer);
        }
    }
}