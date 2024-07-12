using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    internal class clsPopUp
    {
    }

    [Flags]
    public enum PopupAnimations
    {
        /// <summary>
        /// Uses no animation.
        /// </summary>
        None = 0,
        /// <summary>
        /// Animates the window from left to right. This flag can be used with roll or slide animation.
        /// </summary>
        LeftToRight = 0x00001,
        /// <summary>
        /// Animates the window from right to left. This flag can be used with roll or slide animation.
        /// </summary>
        RightToLeft = 0x00002,
        /// <summary>
        /// Animates the window from top to bottom. This flag can be used with roll or slide animation.
        /// </summary>
        TopToBottom = 0x00004,
        /// <summary>
        /// Animates the window from bottom to top. This flag can be used with roll or slide animation.
        /// </summary>
        BottomToTop = 0x00008,
        /// <summary>
        /// Makes the window appear to collapse inward if it is hiding or expand outward if the window is showing.
        /// </summary>
        Center = 0x00010,
        /// <summary>
        /// Uses a slide animation.
        /// </summary>
        Slide = 0x40000,
        /// <summary>
        /// Uses a fade effect.
        /// </summary>
        Blend = 0x80000,
        /// <summary>
        /// Uses a roll animation.
        /// </summary>
        Roll = 0x100000,
        /// <summary>
        /// Uses a default animation.
        /// </summary>
        SystemDefault = 0x200000,
    }

    public struct GripBounds
    {
        private const int GripSize = 6;
        private const int CornerGripSize = GripSize << 1;

        public GripBounds(Rectangle clientRectangle)
        {
            this.clientRectangle = clientRectangle;
        }

        private Rectangle clientRectangle;
        public Rectangle ClientRectangle
        {
            get { return clientRectangle; }
            //set { clientRectangle = value; }
        }

        public Rectangle Bottom
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Y = rect.Bottom - GripSize + 1;
                rect.Height = GripSize;
                return rect;
            }
        }

        public Rectangle BottomRight
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Y = rect.Bottom - CornerGripSize + 1;
                rect.Height = CornerGripSize;
                rect.X = rect.Width - CornerGripSize + 1;
                rect.Width = CornerGripSize;
                return rect;
            }
        }

        public Rectangle Top
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Height = GripSize;
                return rect;
            }
        }

        public Rectangle TopRight
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Height = CornerGripSize;
                rect.X = rect.Width - CornerGripSize + 1;
                rect.Width = CornerGripSize;
                return rect;
            }
        }

        public Rectangle Left
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Width = GripSize;
                return rect;
            }
        }

        public Rectangle BottomLeft
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Width = CornerGripSize;
                rect.Y = rect.Height - CornerGripSize + 1;
                rect.Height = CornerGripSize;
                return rect;
            }
        }

        public Rectangle Right
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.X = rect.Right - GripSize + 1;
                rect.Width = GripSize;
                return rect;
            }
        }

        public Rectangle TopLeft
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Width = CornerGripSize;
                rect.Height = CornerGripSize;
                return rect;
            }
        }
    }
}


