using System.Drawing;

namespace TagCloud.CoordinatesProviders;

public class ArchimedesSpiral(Point center, double tightness, double distanceBetweenPoints) : ICoordinatesProvider
{
    public IEnumerable<Point> GetNextPoint()
    {
        throw new NotImplementedException();
    }
    
    private (double x, double y) ConvertPolarCoordsToCartesian(double r, double theta)
    {
        var x = r * Math.Cos(theta);
        var y = r * Math.Sin(theta);
        return (x, y);
    }
}