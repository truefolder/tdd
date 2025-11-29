using System.Drawing;
using TagCloud.Utils;

namespace TagCloud.CoordinatesProviders;

public class ArchimedesSpiral(PointF center, float tightness, float distanceBetweenPoints) : ICoordinatesProvider
{
    public IEnumerable<PointF> GetNextPoint()
    {
        var degreeStep = distanceBetweenPoints * MathF.PI / 180;
        for (var degree = 0f; ; degree += degreeStep)
        {
            var radius = tightness * degree;
            
            var coords = PolarCoordinatesUtils.ConvertPolarCoordsToCartesian(radius, degree);
            
            coords.x += center.X;
            coords.y += center.Y;
            yield return new PointF(coords.x, coords.y);
        }
        // ReSharper disable once IteratorNeverReturns
        // TODO: это норм или нет?
    }
}