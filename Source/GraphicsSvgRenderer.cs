using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Svg
{
    public sealed class GraphicsSvgRenderer : SvgRenderer
    {
        private Graphics _innerGraphics;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgRenderer"/> class.
        /// </summary>
        internal GraphicsSvgRenderer(Graphics innerGraphics)
        {
            _innerGraphics = innerGraphics;
        }

        public override Region Clip
        {
            get { return this._innerGraphics.Clip; }
            set { this._innerGraphics.Clip = value; }
        }

        public override void DrawImageUnscaled(Image image, Point location)
        {
            this._innerGraphics.DrawImageUnscaled(image, location);
        }

        public override void DrawImage(Image image, RectangleF destRect, RectangleF srcRect, GraphicsUnit graphicsUnit)
        {
            _innerGraphics.DrawImage(image, destRect, srcRect, graphicsUnit);
        }

        public override void SetClip(Region region)
        {
            this._innerGraphics.SetClip(region, CombineMode.Complement);
        }

        public override void FillPath(Brush brush, GraphicsPath path)
        {
            this._innerGraphics.FillPath(brush, path);
        }

        public override void DrawPath(Pen pen, GraphicsPath path)
        {
            this._innerGraphics.DrawPath(pen, path);
        }

        public override void TranslateTransform(float dx, float dy, MatrixOrder order)
        {
            this._innerGraphics.TranslateTransform(dx, dy, order);
        }

        public override void TranslateTransform(float dx, float dy)
        {
            this.TranslateTransform(dx, dy, MatrixOrder.Append);
        }

        public override void ScaleTransform(float sx, float sy, MatrixOrder order)
        {
            this._innerGraphics.ScaleTransform(sx, sy, order);
        }

        public override void ScaleTransform(float sx, float sy)
        {
            this.ScaleTransform(sx, sy, MatrixOrder.Append);
        }

        public override SmoothingMode SmoothingMode
        {
            get { return this._innerGraphics.SmoothingMode; }
            set { this._innerGraphics.SmoothingMode = value; }
        }

        public override PixelOffsetMode PixelOffsetMode
        {
            get { return this._innerGraphics.PixelOffsetMode; }
            set { this._innerGraphics.PixelOffsetMode = value; }
        }

        public override CompositingQuality CompositingQuality
        {
            get { return this._innerGraphics.CompositingQuality; }
            set { this._innerGraphics.CompositingQuality = value; }
        }

        public override TextRenderingHint TextRenderingHint
        {
            get { return this._innerGraphics.TextRenderingHint; }
            set { this._innerGraphics.TextRenderingHint = value; }
        }

        public override int TextContrast
        {
            get { return this._innerGraphics.TextContrast; }
            set { this._innerGraphics.TextContrast = value; }
        }

        public override Matrix Transform
        {
            get { return this._innerGraphics.Transform; }
            set { this._innerGraphics.Transform = value; }
        }

        public override void Save()
        {
            this._innerGraphics.Save();
        }

        public override void Dispose()
        {
            this._innerGraphics.Dispose();
        }

        public override SizeF MeasureString(string text, Font font)
        {
        	var ff = font.FontFamily;
        	float lineSpace = ff.GetLineSpacing(font.Style);
        	float ascent = ff.GetCellAscent(font.Style);
        	float baseline =  font.GetHeight(this._innerGraphics) * ascent / lineSpace;
        	
        	StringFormat format = StringFormat.GenericTypographic;
        	format.SetMeasurableCharacterRanges(new CharacterRange[]{new CharacterRange(0, text.Length)});
        	Region[] r = this._innerGraphics.MeasureCharacterRanges(text, font, new Rectangle(0, 0, 1000, 1000), format);
        	RectangleF rect = r[0].GetBounds(this._innerGraphics);
        	
        	return new SizeF(rect.Width, baseline);
        }
    }
}