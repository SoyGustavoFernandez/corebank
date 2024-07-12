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
    [System.Drawing.ToolboxBitmap(typeof(TreeView))]
    [ToolboxData("<{0}:trvBase runat=server></{0}:trvBase>")]
    public class trvBase : TreeView
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.ShowLines = true;
            this.SelectedNodeStyle.CssClass = "treeNodeSeleccionado";                    
            this.CssClass = "treeViewBase";            
            this.NodeStyle.CssClass = "treeNodeBase";          
        }
    }
}
