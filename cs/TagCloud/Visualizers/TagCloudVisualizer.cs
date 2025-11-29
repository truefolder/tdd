using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace TagCloud.Visualizers;

[SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
public class TagCloudVisualizer
{
    public void DrawRectangles(Rectangle[] rectangles, Size canvasSize, string savePath)
    {
        var bitmap = new Bitmap(canvasSize.Width, canvasSize.Height);
        var graphics = Graphics.FromImage(bitmap);
        
        var pen = new Pen(Color.Black, 1);
        DrawCenterEllipse(graphics, canvasSize);
        DrawLimitingCircle(graphics, canvasSize);
        foreach (var rectangle in rectangles)
            graphics.DrawRectangle(pen, new Rectangle(rectangle.Location + canvasSize / 2, rectangle.Size));
        bitmap.Save(savePath);
    }

    private void DrawCenterEllipse(Graphics graphics, Size canvasSize)
    {
        var brush = new SolidBrush(Color.Red);
        var size = new Size(10, 10);
        graphics.FillEllipse(brush, new Rectangle(new Point(canvasSize.Width / 2 - size.Width / 2, canvasSize.Height / 2 - size.Height / 2), size));
    }

    private void DrawLimitingCircle(Graphics graphics, Size canvasSize)
    {
        var pen = new Pen(Color.Red, 1);
        graphics.DrawEllipse(pen, new Rectangle(new Point(canvasSize.Width / 2 - canvasSize.Height / 2), canvasSize with { Width = canvasSize.Height }));
    }
}