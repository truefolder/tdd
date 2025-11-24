using System.Drawing;

namespace TagCloud.CoordinatesProviders;

public interface ICoordinatesProvider
{
    public IEnumerable<Point> GetNextPoint();
}