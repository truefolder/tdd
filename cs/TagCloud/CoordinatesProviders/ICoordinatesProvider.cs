using System.Drawing;

namespace TagCloud.CoordinatesProviders;

public interface ICoordinatesProvider
{
    public IEnumerable<PointF> GetNextPoint();
}