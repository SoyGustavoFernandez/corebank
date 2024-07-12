using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    /// <summary>
    /// The ExpandCollapsePanel control displays a header that has a collapsible window that displays content.
    /// </summary>
    [Designer(typeof(ExpandCollapsePanelDesigner))]
    public partial class pnlExpandCollapse : Panel
    {
         /// <summary>
        /// Last stored size of panel's parent control
        /// <remarks>used for handling panel's Anchor property sets to Bottom when panel collapsed
        /// in OnSizeChanged method</remarks>
        /// </summary>
        private Size _previousParentSize = Size.Empty;

        /// <summary>
        /// Enable pretty simple animation of panel on expanding or collapsing
        /// </summary>
        private bool _useAnimation = true;

        /// <summary>
        /// Height of panel in expanded state
        /// </summary>
        private int _expandedHeight;

        /// <summary>
        /// Height of panel in collapsed state
        /// </summary>
        private readonly int _collapsedHeight;

        /// <summary>
        /// Height of panel in expanded state
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Height of panel in expanded state.")]
        [Browsable(true)]
        public int ExpandedHeight
        {
            get { return _expandedHeight; }
            set
            {
                _expandedHeight = value;
                if (IsExpanded)
                {
                    Height = _expandedHeight;
                }
            }
        }

        /// <summary>
        /// Set flag for expand or collapse panel content
        /// (true - expanded, false - collapsed)
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Expand or collapse panel content. " +
                     "\r\nAttention, for correct work with resizing child controls," +
                     " please set IsExpanded to \"false\" in code (for example in your Form class constructor after InitializeComponent method) and not in Forms Designer!")]
        [Browsable(true)]
        public bool IsExpanded
        {
            get { return _btnExpandCollapse.IsExpanded; }
            set 
            { 
                if(_btnExpandCollapse.IsExpanded != value)
                    _btnExpandCollapse.IsExpanded = value; 
            }
        }

        /// <summary>
        /// Header of panel
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Header of panel.")]
        [Browsable(true)]
        public override string Text
        {
            get { return _btnExpandCollapse.Text; }
            set { _btnExpandCollapse.Text = value; }
        }

        /// <summary>
        /// Enable pretty simple animation of panel on expanding or collapsing
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Enable pretty simple animation of panel on expanding or collapsing.")]
        [Browsable(true)]
        public bool UseAnimation
        {
            get { return _useAnimation; }
            set { _useAnimation = value; }
        }

        /// <summary>
        /// Visual style of the expand-collapse button.
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Visual style of the expand-collapse button.")]
        [Browsable(true)]
        public btnExpandCollapse.ExpandButtonStyle ButtonStyle
        {
            get { return _btnExpandCollapse.ButtonStyle; }
            set { _btnExpandCollapse.ButtonStyle = value; }
        }

        /// <summary>
        /// Size preset of the expand-collapse button.
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Size preset of the expand-collapse button.")]
        [Browsable(true)]
        public btnExpandCollapse.ExpandButtonSize ButtonSize
        {
            get { return _btnExpandCollapse.ButtonSize; }
            set { _btnExpandCollapse.ButtonSize = value; }
        }

        /// <summary>
        /// AutoScroll property
        /// <remarks>Overridden only to hide from designer as mindless and useless</remarks>
        /// </summary>
        [Browsable(false)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                base.AutoScroll = value;
            }
        }

        /// <summary>
        /// Font used for displays header text
        /// </summary>
        public override Font Font
        {
            get
            {
                return _btnExpandCollapse.Font;
            }
            set
            {
                _btnExpandCollapse.Font = value;
            }
        }

        /// <summary>
        /// Foreground color used for displays header text
        /// </summary>
        public override Color ForeColor
        {
            get
            {
                return _btnExpandCollapse.ForeColor;
            }
            set
            {
                _btnExpandCollapse.ForeColor = value;
            }
        }

        /// <summary>
        /// Occurs when the panel has expanded or collapsed
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Occurs when the panel has expanded or collapsed.")]
        [Browsable(true)]
        public event EventHandler<ExpandCollapseEventArgs> ExpandCollapse;


        /// <summary>
        /// Constructor
        /// </summary>
        public pnlExpandCollapse()
        {
            InitializeComponent();

            // make collapsed height equals to fit expand-collapse button
            _collapsedHeight = _btnExpandCollapse.Location.Y + _btnExpandCollapse.Size.Height + _btnExpandCollapse.Margin.Bottom;

            // right away manually scale expand-collapse button for filling the horizontal space of panel:
            _btnExpandCollapse.Size = new Size(ClientSize.Width - _btnExpandCollapse.Margin.Left - _btnExpandCollapse.Margin.Right,
                         _btnExpandCollapse.Height);

            // in spite of we always manually scale button, setting Anchor and AutoSize properties provide correct redraw of control in forms designer window
            _btnExpandCollapse.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            _btnExpandCollapse.AutoSize = true;

            // initial state of panel - expanded
            _btnExpandCollapse.IsExpanded = true;
            // subscribe for button expand-collapse state changed event
            _btnExpandCollapse.ExpandCollapse += BtnExpandCollapseExpandCollapse;
         
        }

        /// <summary>
        /// Handle button expand-collapse state changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExpandCollapseExpandCollapse(object sender, ExpandCollapseEventArgs e)
        {
            if (e.IsExpanded) // if button is expanded now
            {
                Expand(); // expand the panel
            }
            else
            {
                Collapse(); // collapse the panel
            }

            // Retrieve expand-collapse state changed event for panel
            EventHandler<ExpandCollapseEventArgs> handler = ExpandCollapse;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Expand panel content
        /// </summary>
        protected virtual void Expand()
        {
            // if animation enabled
            if (UseAnimation)
            {
                // set internal state for Expanding
                _internalPanelState = InternalPanelState.Expanding;
                // start animation now..
                StartAnimation();
            }
            else // no animation, just expand immediately
            {
                // set internal state to Normal
                _internalPanelState = InternalPanelState.Normal;
                // resize panel
                Size = new Size(Size.Width, _expandedHeight);

            }
        }

        /// <summary>
        /// Collapse panel content
        /// </summary>
        protected virtual void Collapse()
        {
            // if panel is completely expanded (animation on expanding is ended or no animation at all) 
            // *we don't want store half-expanded panel height
            if (_internalPanelState == InternalPanelState.Normal)
            {
                // store current panel height in expanded state
                _expandedHeight = Size.Height;
            }

            // if animation enabled
            if (UseAnimation)
            {
                // set internal state for Collapsing
                _internalPanelState = InternalPanelState.Collapsing;
                // start animation now..
                StartAnimation();
            }
            else // no animation, just collapse immediately
            {
                // set internal state to Normal
                _internalPanelState = InternalPanelState.Normal;
                // resize panel
                Size = new Size(Size.Width, _collapsedHeight);
            }
        }

        /// <summary>
        /// Handle panel resize event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            // we always manually scale expand-collapse button for filling the horizontal space of panel:
            _btnExpandCollapse.Size = new Size(ClientSize.Width - _btnExpandCollapse.Margin.Left - _btnExpandCollapse.Margin.Right,
                _btnExpandCollapse.Height);

            // ignore height changing from animation timer
            if(_internalPanelState != InternalPanelState.Normal)
                return;

            #region Handling panel's Anchor property sets to Bottom when panel collapsed

            if (!IsExpanded // if panel collapsed
                && ((Anchor & AnchorStyles.Bottom) != 0) //and panel's Anchor property sets to Bottom
                && Size.Height != _collapsedHeight // and panel height is changed (it could happens only if parent control just has resized)
                && Parent != null) // and panel has the parent control
            {
                // main, calculate the parent control resize diff and add it to expandedHeight value:
                _expandedHeight += Parent.Height - _previousParentSize.Height;

                // reset resized height (by base.OnSizeChanged anchor.Bottom handling) to collapsedHeight value:
                Size = new Size(Size.Width, _collapsedHeight);
            }

            // store previous size of parent control (however we need only height)
            if(Parent != null)
                _previousParentSize = Parent.Size;
            #endregion
        }

        #region Animation Code
        //	---------------------------------------------------------------------------------------
        //	The original source of this animation technique was written by
        //	Daren May for his Collapsible Panel implementation which can
        //	be found here:
        //		http://www.codeproject.com/cs/miscctrl/xpgroupbox.asp
        //   
        //	Although I found that piece of code in very good XPPanel implementation by Tom Guinther:
        //		http://www.codeproject.com/Articles/7332/Full-featured-XP-Style-Collapsible-Panel
        //  I have simplified things quite a bit, nothing is fundamentally different. 
        //  So I give many thanks to both for solving this problem.
        //	---------------------------------------------------------------------------------------

        // degree to adjust the height of the panel when animating
        private int _animationHeightAdjustment = 0;
        // current opacity level
        private int _animationOpacity = 0;

        /// <summary>
        /// Initialize animation values and start the timer
        /// </summary>
        private void StartAnimation()
        {
            _animationHeightAdjustment = 1;
            _animationOpacity = 5;
            animationTimer.Interval = 50;
            animationTimer.Enabled = true;
        }

        private void animationTimer_Tick(object sender, System.EventArgs e)
        {
            //	---------------------------------------------------------------
            //	Gradually reduce the interval between timer events so that the
            //	animation begins slowly and eventually accelerates to completion
            //	---------------------------------------------------------------
            if (animationTimer.Interval > 10)
            {
                animationTimer.Interval -= 10;
            }
            else
            {
                _animationHeightAdjustment += 2;
            }

            // Increase transparency as we collapse
            if ((_animationOpacity + 5) < byte.MaxValue)
            {
                _animationOpacity += 5;
            }

            int currOpacity = _animationOpacity;

            switch (_internalPanelState)
            {
                case InternalPanelState.Expanding:
                    // still room to expand?
                    if ((Height + _animationHeightAdjustment) < _expandedHeight)
                    {
                        Height += _animationHeightAdjustment;
                    }
                    else
                    {
                        // we are done so we dont want any transparency
                        currOpacity = byte.MaxValue;
                        Height = _expandedHeight;
                        _internalPanelState = InternalPanelState.Normal;
                    }
                    break;

                case InternalPanelState.Collapsing:
                    // still something to collapse
                    if ((Height - _animationHeightAdjustment) > _collapsedHeight)
                    {
                        Height -= _animationHeightAdjustment;
                        // continue decreasing opacity
                        currOpacity = byte.MaxValue - _animationOpacity;
                    }
                    else
                    {
                        // we are done so we dont want any transparency
                        currOpacity = byte.MaxValue;
                        Height = _collapsedHeight;
                        _internalPanelState = InternalPanelState.Normal;
                    }
                    break;

                default:
                    return;
            }

            // set the opacity for all the controls on the XPPanel
            SetControlsOpacity(currOpacity);

            // are we done?
            if (_internalPanelState == InternalPanelState.Normal)
            {
                animationTimer.Enabled = false;
            }

            Invalidate();
        }

        /// <summary>
        /// Changes the transparency of controls based upon the height of the XPPanel
        /// </summary>
        /// <remarks>
        /// Only used during animation
        /// </remarks>
        private void SetControlsOpacity(int opacity)
        {
            foreach (Control c in this.Controls)
            {
                if (c.Visible)
                {
                    try
                    {
                        if (c.BackColor != Color.Transparent)
                        {
                            c.BackColor = Color.FromArgb(opacity, c.BackColor);
                        }
                        // ignore exception from controls that do not support transparent background color
                    }
                    catch
                    {
                    }
                    c.ForeColor = Color.FromArgb(opacity, c.ForeColor);
                }
            }
        }

        /// <summary>
        /// Internal state of panel used for checking that panel is animating now
        /// </summary>
        private InternalPanelState _internalPanelState;

        /// <summary>
        /// Internal state of panel
        /// </summary>
        private enum InternalPanelState
        {
            /// <summary>
            /// No animation, completely expanded or collapsed
            /// </summary>
            Normal,
            /// <summary>
            /// Expanding animation
            /// </summary>
            Expanding,
            /// <summary>
            /// Collapsing animation
            /// </summary>
            Collapsing
        }

        #endregion Animation Code
    }

    /// <summary>
    /// Designer for the ExpandCollapsePanel control with support for a smart tag panel.
    /// <remarks>http://msdn.microsoft.com/en-us/library/ms171829.aspx</remarks>
    /// </summary>
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ExpandCollapsePanelDesigner : System.Windows.Forms.Design.ScrollableControlDesigner
    {
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu. 
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(
                        new ExpandCollapsePanelActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    /// <summary>
    /// DesignerActionList-derived class defines smart tag entries and resultant actions. 
    /// <remarks>http://msdn.microsoft.com/en-us/library/ms171829.aspx</remarks>
    /// </summary>
    public class ExpandCollapsePanelActionList : System.ComponentModel.Design.DesignerActionList
    {
        private pnlExpandCollapse panel;

        private DesignerActionUIService designerActionUISvc = null;

        //The constructor associates the control  
        //with the smart tag list. 
        public ExpandCollapsePanelActionList(IComponent component)
            : base(component)
        {
            this.panel = component as pnlExpandCollapse;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc =
                GetService(typeof(DesignerActionUIService))
                as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of  
        // GetProperties enables undo and menu updates to work properly. 
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(panel)[propName];
            if (null == prop)
                throw new ArgumentException(
                    "Matching ExpandCollapsePanel property not found!",
                    propName);
            else
                return prop;
        }

        // Properties that are targets of DesignerActionPropertyItem entries. 
        public bool IsExpanded
        {
            get
            {
                return panel.IsExpanded;
            }
            set
            {
                GetPropertyByName("IsExpanded").SetValue(panel, value);

                // Refresh the list. 
                //this.designerActionUISvc.Refresh(this.Component);
            }
        }

        public btnExpandCollapse.ExpandButtonStyle ButtonStyle
        {
            get
            {
                return panel.ButtonStyle;
            }
            set
            {
                GetPropertyByName("ButtonStyle").SetValue(panel, value);

                // Refresh the list. 
                //this.designerActionUISvc.Refresh(this.Component);
            }
        }

        public btnExpandCollapse.ExpandButtonSize ButtonSize
        {
            get
            {
                return panel.ButtonSize;
            }
            set
            {
                GetPropertyByName("ButtonSize").SetValue(panel, value);

                // Refresh the list. 
                //this.designerActionUISvc.Refresh(this.Component);
            }
        }


        // Implementation of this abstract method creates smart tag   
        // items, associates their targets, and collects into list. 
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));
            //items.Add(new DesignerActionHeaderItem("Information"));

            //Boolean property for locking color selections.
            items.Add(new DesignerActionPropertyItem("IsExpanded",
                                                     "IsExpanded", "Appearance",
                                                     "Expand/collapse the panel."));
            items.Add(new DesignerActionPropertyItem("ButtonStyle",
                                                     "ButtonStyle", "Appearance",
                                                     "Visual style of the expand-collapse button."));
            items.Add(new DesignerActionPropertyItem("ButtonSize",
                                                     "ButtonSize", "Appearance",
                                                     "Size preset of the expand-collapse button."));

            return items;
        }
    }

    public class ExpandCollapseEventArgs : EventArgs
    {
        public bool IsExpanded { get; private set; }

        public ExpandCollapseEventArgs(bool isExpanded)
        {
            IsExpanded = isExpanded;
        }
    }
}
