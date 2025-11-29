using System.Drawing;

namespace TagCloud.CoordinatesProviders;

public class ArchimedesSpiral(PointF center, float tightness, float distanceBetweenPoints) : ICoordinatesProvider
{
    public IEnumerable<PointF> GetNextPoint()
    {
        var degreeStep = distanceBetweenPoints * MathF.PI / 180;
        for (var degree = 0f; ; degree += degreeStep)
        {
            var radius = tightness * degree;
            
            var coords = ConvertPolarCoordsToCartesian(radius, degree);
            
            coords.x += center.X;
            coords.y += center.Y;
            yield return new PointF(coords.x, coords.y);
        }
        // ReSharper disable once IteratorNeverReturns
        // TODO: это норм или нет?
    }
    
    private (float x, float y) ConvertPolarCoordsToCartesian(float radius, float degree)
    {
        var x = radius * MathF.Cos(degree);
        var y = radius * MathF.Sin(degree);
        return (x, y);
    }
}