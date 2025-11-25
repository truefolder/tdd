using System.Drawing;
using TagCloud.CoordinatesProviders;

namespace TagCloud;

public class CircularCloudLayouter(Point center, ICoordinatesProvider coordinatesProvider)
{
    public List<Rectangle> Rectangles = [];
    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        var rect = new Rectangle(GetNextRectanglePoint(rectangleSize), rectangleSize);
        return rect;
    }

    private Point GetNextRectanglePoint(Size rectangleSize)
    {
        var nextPoint = coordinatesProvider.GetNextPoint();

        throw new NotImplementedException();
    }
}