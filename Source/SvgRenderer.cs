using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Svg
{
    public abstract class SvgRenderer : IDisposable
    {
        public abstract Region Clip { get; set; }

        public abstract SmoothingMode SmoothingMode { get; set; }

        public abstract PixelOffsetMode PixelOffsetMode { get; set; }

        public abstract CompositingQuality CompositingQuality { get; set; }

        public abstract TextRenderingHint TextRenderingHint { get; set; }

        public abstract int TextContrast { get; set; }

        public abstract Matrix Transform { get; set; }

        /// <summary>
        /// Creates a new <see cref="SvgRenderer"/> from the specified <see cref="Image"/>.
        /// </summary>
        /// <param name="image"><see cref="Image"/> from which to create the new <see cref="SvgRenderer"/>.</param>
        public static SvgRenderer FromImage(Image image)
        {
            SvgRenderer renderer = new GraphicsSvgRenderer(Graphics.FromImage(image));
            return renderer;
        }

        /// <summary>
        /// Creates a new <see cref="SvgRenderer"/> from the specified <see cref="Graphics"/>.
        /// </summary>
        /// <param name="graphics">The <see cref="Graphics"/> to create the renderer from.</param>
        public static SvgRenderer FromGraphics(Graphics graphics)
        {
            SvgRenderer renderer = new GraphicsSvgRenderer(graphics);
            return renderer;
        }

        public abstract void DrawImageUnscaled(Image image, Point location);

        public abstract void DrawImage(Image image, RectangleF destRect, RectangleF srcRect, GraphicsUnit graphicsUnit);

        public abstract void SetClip(Region region);

        public abstract void FillPath(Brush brush, GraphicsPath path);

        public abstract void DrawPath(Pen pen, GraphicsPath path);

        public abstract void TranslateTransform(float dx, float dy, MatrixOrder order);

        public abstract void TranslateTransform(float dx, float dy);

        public abstract void ScaleTransform(float sx, float sy, MatrixOrder order);

        public abstract void ScaleTransform(float sx, float sy);

        public abstract void Save();

        public abstract void Dispose();

        public abstract SizeF MeasureString(string text, Font font);
    }
}