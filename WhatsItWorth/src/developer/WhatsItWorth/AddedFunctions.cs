// AddedFunctions.cs by Ben Ebadinia

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WhatsItWorth
{
        // A panel that paints a linear gradient background from LeftColor to RightColor at the given Angle.
        public class Gradient : Panel
        {
            public Color LeftColor { get; set; }
            public Color RightColor { get; set; }
            public float Angle { get; set; }

            protected override void OnPaint(PaintEventArgs e)
            {
                // Use 'using' to properly dispose of brush resources.
                using (var brush = new LinearGradientBrush(this.ClientRectangle, this.LeftColor, this.RightColor, this.Angle))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
                base.OnPaint(e);
            }
        }

        // A picture box with an elliptical region, rendering as a rounded (circular/oval) image.
        public class RoundedPicture : PictureBox
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                using (var path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                    this.Region = new System.Drawing.Region(path);
                }
                base.OnPaint(e);
            }
        }

}
