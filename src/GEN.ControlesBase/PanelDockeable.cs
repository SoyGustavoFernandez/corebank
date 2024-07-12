using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace GEN.ControlesBase
{
    [Designer(typeof(UserControlDesigner))]
    public partial class PanelDockeable : UserControl
    {
        private const string Expand = "<";
        private const string Collapse = ">";
        private readonly int _originalWidth;
        private bool _isExpanded;

        [Category("Appearance")]
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;
                ResizePanel();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel DropZone
        {
            get { return panelContent; }
        }

        public PanelDockeable()
        {
            InitializeComponent();
            _originalWidth = Width;
            IsExpanded = false;
        }

        private void btnExpandCollapse_Click(object sender, EventArgs e)
        {
            IsExpanded = !IsExpanded;
        }

        private void ResizePanel()
        {
            btnExpandCollapse.Text = IsExpanded ? Collapse : Expand;
            Width = IsExpanded ? _originalWidth : btnExpandCollapse.Width;
        }
    }
    public class UserControlDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            PanelDockeable control = Control as PanelDockeable;
            if (control != null)
            {
                EnableDesignMode(control.DropZone, "DropZone");
            }
        }
    }

}
